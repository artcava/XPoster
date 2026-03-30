# Configuration Reference

All configuration is passed via environment variables (locally in `src/local.settings.json`, in production via Azure App Settings or Key Vault references).

## Scheduler

| Variable | Type | Default | Description |
|---|---|---|---|
| `CronSchedule` | string | `0 5 * * * *` | 6-field cron expression controlling execution frequency |

## Twitter / X

| Variable | Type | Default | Description |
|---|---|---|---|
| `X_API_KEY` | string | — | Twitter App API Key |
| `X_API_SECRET` | string | — | Twitter App API Secret |
| `X_ACCESS_TOKEN` | string | — | User Access Token |
| `X_ACCESS_TOKEN_SECRET` | string | — | User Access Token Secret |

> Obtain from [developer.twitter.com](https://developer.twitter.com) → Your App → Keys and Tokens.

## LinkedIn

| Variable | Type | Default | Description |
|---|---|---|---|
| `LINKEDIN_ACCESS_TOKEN` | string | — | OAuth 2.0 Bearer Token — stored in Key Vault (`LinkedInAccessToken`) |
| `LINKEDIN_CLIENT_ID` | string | — | LinkedIn App Client ID — stored in Key Vault (`LinkedInClientId`) |
| `LINKEDIN_CLIENT_SECRET` | string | — | LinkedIn App Client Secret — stored in Key Vault (`LinkedInClientSecret`) |
| `LINKEDIN_ORGANIZATION_ID` | string | — | Numeric ID of the LinkedIn organization page |
| `KEYVAULT_URI` | string | — | URI of the Azure Key Vault, e.g. `https://xposter-kv.vault.azure.net/` |

> Generate tokens at [LinkedIn Developer Portal](https://www.linkedin.com/developers/).

### Azure Key Vault References

In production, `LINKEDIN_ACCESS_TOKEN`, `LINKEDIN_CLIENT_ID`, and `LINKEDIN_CLIENT_SECRET` **must not** be set as plain-text App Settings. Instead, configure them as **Azure Key Vault References** directly in the Function App's Application Settings:

```
LINKEDIN_ACCESS_TOKEN  = @Microsoft.KeyVault(VaultName=xposter-kv;SecretName=LinkedInAccessToken)
LINKEDIN_CLIENT_ID     = @Microsoft.KeyVault(VaultName=xposter-kv;SecretName=LinkedInClientId)
LINKEDIN_CLIENT_SECRET = @Microsoft.KeyVault(VaultName=xposter-kv;SecretName=LinkedInClientSecret)
KEYVAULT_URI           = https://xposter-kv.vault.azure.net/
```

**Why unversioned references?** Omitting `SecretVersion` means the Function App always resolves the latest active version automatically after each token refresh, without requiring an app restart.

**Prerequisites:**
1. The Function App must have a **System-assigned Managed Identity** enabled (Azure Portal → Function App → Identity).
2. Grant the identity the **Key Vault Secrets User** role on `xposter-kv` (Azure Portal → Key Vault → Access control (IAM)).
3. Create the three secrets in the Key Vault with the exact names above.

**Verification:** After saving the App Settings, the Azure Portal shows a green ✅ icon next to each Key Vault Reference. A yellow ⚠️ indicates a permission or secret-name mismatch.

> **Local development:** supply raw token values directly in `src/local.settings.json` (git-ignored). Key Vault References are not resolved by the local Azure Functions host.

## Instagram

| Variable | Type | Default | Description |
|---|---|---|---|
| `INSTAGRAM_ACCESS_TOKEN` | string | — | Long-lived Graph API access token |
| `INSTAGRAM_BUSINESS_ACCOUNT_ID` | string | — | Instagram Business Account ID |

> Obtain via [Meta for Developers](https://developers.facebook.com/) → Instagram Graph API.

## Azure OpenAI

| Variable | Type | Default | Description |
|---|---|---|---|
| `AZURE_OPENAI_ENDPOINT` | string | — | `https://<resource>.openai.azure.com/` |
| `AZURE_OPENAI_KEY` | string | — | API key (or omit if using Managed Identity) |
| `AZURE_OPENAI_DEPLOYMENT_NAME` | string | `gpt-4` | Name of the GPT-4 deployment in Azure OpenAI Studio |

## Azure Functions Runtime

| Variable | Type | Default | Description |
|---|---|---|---|
| `AzureWebJobsStorage` | string | `UseDevelopmentStorage=true` | Storage connection string (Azurite locally, Storage Account in prod) |
| `FUNCTIONS_WORKER_RUNTIME` | string | `dotnet-isolated` | Must be `dotnet-isolated` for .NET 8 isolated worker |

## Security Notes

- Never commit `local.settings.json` — it is in `.gitignore`.
- Use `src/local.settings.json.example` as the starting template.
- In production, **always** use **Azure Key Vault References** for secrets (LinkedIn credentials, API keys).
- For CI/CD, store secrets in **GitHub Actions Secrets**, never in workflow YAML.
