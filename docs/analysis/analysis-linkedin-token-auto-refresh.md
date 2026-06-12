# Analysis: LinkedIn Authorization Token Auto-Refresh

**Feature**: Phase 2 — `Linkedin auto-update authorization token`  
**Status**: Draft — for review and issue generation  
**Author**: Marco Cavallo  
**Date**: 2026-03-24  
**Related Roadmap Item**: Phase 2 – Stabilization

---

## 1. Problem Statement

The current LinkedIn integration in XPoster uses a **static OAuth 2.0 access token** stored as an Azure App Setting (`LINKEDIN_ACCESS_TOKEN`). This token expires every **60 days**, requiring a manual renewal process:

1. Manually trigger the LinkedIn OAuth flow in a browser
2. Copy the new `access_token` from the redirect response
3. Update the value in Azure Portal → Function App → Configuration → Application Settings
4. Restart the Function App

This manual intervention introduces operational risk:
- If the token expires unnoticed, all LinkedIn posts silently fail
- There is no alerting in place specifically for authentication failures on LinkedIn
- The 60-day cadence is easy to miss, especially during vacations or busy periods

---

## 2. LinkedIn OAuth 2.0 Token Lifecycle — Background

LinkedIn uses **OAuth 2.0 Authorization Code Flow** for 3-legged access. The relevant token types are:

| Token Type | TTL | Notes |
|---|---|---|
| `access_token` | 60 days | Used by InSender for API calls |
| `refresh_token` | 365 days | Can be used to obtain a new access_token without re-authorization |
| `id_token` (OIDC) | Short-lived | Not relevant here |

### Key Insight
LinkedIn supports **refresh tokens** (when the `r_liteprofile` or `w_member_social` scopes are requested and the app has "Sign In with LinkedIn using OpenID Connect" enabled). The refresh token is valid for **365 days** and can be used to obtain a new access token **silently**, without user interaction.

**Reference**: [LinkedIn OAuth 2.0 – Refreshing an Access Token](https://learn.microsoft.com/en-us/linkedin/shared/authentication/programmatic-refresh-tokens)

---

## 3. Current Architecture — Relevant Components

```
InSender (src/SenderPlugins/InSender.cs)
  └── uses: LINKEDIN_ACCESS_TOKEN (env var)
  └── calls: LinkedIn REST API v2 (posts endpoint)

Program.cs
  └── DI registration of InSender
  └── env vars loaded from Azure App Settings / local.settings.json
```

The token is consumed **statically at startup** via `Environment.GetEnvironmentVariable("LINKEDIN_ACCESS_TOKEN")`. There is no refresh logic or token lifecycle awareness.

---

## 4. Proposed Solution — Architecture

### 4.1 Strategy: Proactive Refresh via Azure Function Timer

A dedicated `TimerTrigger` Azure Function (`LinkedInTokenRefresherFunction`) runs periodically (e.g., every 45 days) and:

1. Reads the current `refresh_token` from **Azure Key Vault**
2. Calls the LinkedIn token refresh endpoint
3. Writes the new `access_token` and optionally the new `refresh_token` back to Key Vault
4. Updates the Azure Function App's Application Setting `LINKEDIN_ACCESS_TOKEN` via the **Azure Management API** (or via Key Vault reference)

### 4.2 Alternative: Key Vault Reference + Automatic Reload

Instead of updating the App Setting directly, use **Azure Key Vault References** in App Settings:

```
LINKEDIN_ACCESS_TOKEN = @Microsoft.KeyVault(SecretUri=https://<vault>.vault.azure.net/secrets/LinkedInAccessToken/)
```

With this approach:
- InSender always reads the token via Key Vault reference (auto-resolved by the runtime)
- The refresh function only needs to **update the Key Vault secret version**
- The Function App picks up the new value on next execution (no restart needed if using latest version reference without pinned version)

**This is the recommended approach** as it decouples secret rotation from App Settings management.

### 4.3 Comparison of Approaches

| Approach | Complexity | Security | Requires Restart | Dependencies |
|---|---|---|---|---|
| A. Manual update (current) | Low | Medium | Yes | None |
| B. Timer Function + App Settings update via Management API | High | High | Yes | Azure SDK, RBAC role |
| C. Timer Function + Key Vault secret update | Medium | Very High | No (with unversioned ref) | Key Vault, Managed Identity |
| D. Key Vault Reference only (no auto-refresh timer) | Low | Very High | No | Key Vault |

**Recommendation**: **Option C** — Timer Function + Key Vault secret update.

---

## 5. Detailed Implementation Plan

### Step 1: LinkedIn App Configuration
- Enable **"Sign In with LinkedIn using OpenID Connect"** on the LinkedIn Developer App
- Verify that `r_liteprofile` and `w_member_social` scopes are granted
- Perform a **one-time manual OAuth flow** to obtain both `access_token` AND `refresh_token`
- Store both tokens in Azure Key Vault as separate secrets:
  - `LinkedInAccessToken`
  - `LinkedInRefreshToken`

### Step 2: Azure Key Vault Setup
- Create or reuse an Azure Key Vault in the `XPosterRG` resource group
- Enable **System Assigned Managed Identity** on the Function App (if not already active)
- Grant the Managed Identity the role: **Key Vault Secrets Officer** (read + write secrets)

```bash
az keyvault create --name xposter-kv --resource-group XPosterRG --location westeurope

az keyvault secret set --vault-name xposter-kv --name LinkedInAccessToken --value "<token>"
az keyvault secret set --vault-name xposter-kv --name LinkedInRefreshToken --value "<refresh_token>"

# Grant Managed Identity access
az keyvault set-policy --name xposter-kv \
  --object-id <managed-identity-object-id> \
  --secret-permissions get set list
```

### Step 3: Update InSender to Read from Key Vault
- Replace `Environment.GetEnvironmentVariable("LINKEDIN_ACCESS_TOKEN")` with a Key Vault reference or a `SecretClient` injection
- Preferred: use **App Setting with Key Vault Reference** so no code change is needed in InSender:

```json
// Azure App Settings
"LINKEDIN_ACCESS_TOKEN": "@Microsoft.KeyVault(VaultName=xposter-kv;SecretName=LinkedInAccessToken)"
```

### Step 4: Implement `LinkedInTokenRefresherFunction`

New file: `src/Functions/LinkedInTokenRefresherFunction.cs`

```csharp
[Function("LinkedInTokenRefresher")]
public async Task Run(
    [TimerTrigger("%LinkedInTokenRefreshSchedule%")] TimerInfo timer,
    ILogger<LinkedInTokenRefresherFunction> logger)
{
    logger.LogInformation("Starting LinkedIn token refresh...");

    var refreshToken = await _keyVaultService.GetSecretAsync("LinkedInRefreshToken");
    var (newAccessToken, newRefreshToken) = await _linkedInAuthService.RefreshTokenAsync(refreshToken);

    await _keyVaultService.SetSecretAsync("LinkedInAccessToken", newAccessToken);
    if (!string.IsNullOrEmpty(newRefreshToken))
        await _keyVaultService.SetSecretAsync("LinkedInRefreshToken", newRefreshToken);

    logger.LogInformation("LinkedIn token refreshed successfully.");
}
```

Default schedule: `0 0 9 */45 * *` (every 45 days at 9:00 AM — well before the 60-day expiry).

### Step 5: Implement `LinkedInAuthService`

New file: `src/Services/LinkedInAuthService.cs`

```csharp
public async Task<(string accessToken, string refreshToken)> RefreshTokenAsync(string refreshToken)
{
    var requestBody = new FormUrlEncodedContent(new[]
    {
        new KeyValuePair<string, string>("grant_type", "refresh_token"),
        new KeyValuePair<string, string>("refresh_token", refreshToken),
        new KeyValuePair<string, string>("client_id", _clientId),
        new KeyValuePair<string, string>("client_secret", _clientSecret),
    });

    var response = await _httpClient.PostAsync("https://www.linkedin.com/oauth/v2/accessToken", requestBody);
    response.EnsureSuccessStatusCode();

    var result = await response.Content.ReadFromJsonAsync<LinkedInTokenResponse>();
    return (result.AccessToken, result.RefreshToken);
}
```

LinkedIn token refresh endpoint: `POST https://www.linkedin.com/oauth/v2/accessToken`

### Step 6: Add Alerting for Refresh Failures
- Application Insights alert: if `LinkedInTokenRefresher` logs `severityLevel >= 3` → send email alert
- Add a **KQL alert rule** (as per `docs/monitoring.md` pattern):

```kql
traces
| where timestamp > ago(2h)
| where message contains "LinkedIn token refresh"
| where severityLevel >= 3
```

### Step 7: Expiry Warning Alert (Defense in Depth)
- Add a secondary timer-triggered check that **reads the token expiry date** stored as Key Vault secret metadata (tags) and logs a warning 15 days before expiry
- This serves as a fallback in case the refresh function itself fails

---

## 6. New Environment Variables Required

| Variable | Storage | Description |
|---|---|---|
| `LINKEDIN_CLIENT_ID` | Key Vault / App Setting | LinkedIn app client ID |
| `LINKEDIN_CLIENT_SECRET` | Key Vault | LinkedIn app client secret |
| `LINKEDIN_ACCESS_TOKEN` | Key Vault Reference | Current access token (auto-refreshed) |
| `LINKEDIN_REFRESH_TOKEN` | Key Vault | Refresh token (valid 365 days) |
| `LinkedInTokenRefreshSchedule` | App Setting | Cron for refresh timer (e.g., `0 0 9 */45 * *`) |
| `KEYVAULT_URI` | App Setting | `https://xposter-kv.vault.azure.net/` |

---

## 7. Dependencies & Prerequisites

- [ ] LinkedIn Developer App must have OpenID Connect enabled (verify in [LinkedIn Developer Portal](https://www.linkedin.com/developers/))
- [ ] One-time manual OAuth flow to obtain initial `refresh_token`
- [ ] Azure Key Vault provisioned in `XPosterRG`
- [ ] System Assigned Managed Identity enabled on Function App
- [ ] `Azure.Security.KeyVault.Secrets` NuGet package added to `src/XPoster.csproj`
- [ ] `Azure.Identity` NuGet package (for `DefaultAzureCredential`)
- [ ] `local.settings.json.example` updated with new variables

---

## 8. Risk Analysis

| Risk | Likelihood | Impact | Mitigation |
|---|---|---|---|
| LinkedIn disables refresh tokens for the app | Low | High | Monitor LinkedIn changelog; maintain manual fallback procedure |
| Refresh token itself expires (365d) | Low | High | Expiry warning alert (Step 7); calendar reminder as backup |
| Key Vault unavailable during refresh | Very Low | Medium | Retry logic in `LinkedInTokenRefresherFunction`; Application Insights alert |
| RBAC misconfiguration blocks Key Vault access | Medium | High | IaC (Bicep) for role assignments; test in staging before prod |
| LinkedIn API rate limit on token endpoint | Very Low | Low | One call every 45 days — well within limits |

---

## 9. Proposed GitHub Issues

Once this document is reviewed, the following issues should be created:

1. **[INFRA] Provision Azure Key Vault and Managed Identity for XPoster** — Key Vault setup, RBAC, store initial tokens
2. **[CONFIG] Migrate LINKEDIN_ACCESS_TOKEN to Key Vault Reference** — Update App Settings, validate InSender still works
3. **[DEV] Implement LinkedInAuthService (token refresh logic)** — HTTP call, response parsing, unit tests
4. **[DEV] Implement LinkedInTokenRefresherFunction (timer trigger)** — New Azure Function, DI registration, schedule config
5. **[DEV] Implement KeyVaultService abstraction** — Wrapper around `SecretClient` for testability
6. **[OPS] Add Application Insights alert for LinkedIn token refresh failures** — KQL alert rule, action group
7. **[OPS] Add token expiry warning mechanism** — Tag-based expiry tracking, 15-day advance warning
8. **[DOCS] Update configuration.md and local.settings.json.example** — Document new variables and Key Vault setup

---

## 10. Open Questions

- [ ] Is the LinkedIn Developer App currently configured with OpenID Connect enabled? Needs verification.
- [ ] Should `LINKEDIN_CLIENT_SECRET` be stored in Key Vault or is it acceptable as a regular App Setting (encrypted at rest by Azure)?
- [ ] Should the Key Vault be shared with future features (Instagram token, etc.) or scoped to LinkedIn only for now?
- [ ] Preferred cron for the refresh timer: every 45 days? Or a fixed monthly schedule (day 1 of each month) for predictability?

---

*This document is intended as input for sprint planning and issue generation. Review, comment, and update the Open Questions section before proceeding.*
