# XPoster — Infrastructure as Code (Bicep)

This directory contains the Bicep templates to provision the full Azure infrastructure for XPoster.

## Structure

```
infra/
├── main.bicep              # Entry point — orchestrates all modules
├── main.bicepparam         # Production parameters
└── modules/
    ├── storage.bicep       # Storage Account (xposterdb)
    ├── monitoring.bicep    # Application Insights (XInsights) + Log Analytics
    ├── function-app.bicep  # App Service Plan + Function App (XPosterFunction)
    └── key-vault.bicep     # Key Vault (kv-xposter) with Managed Identity access policy
```

## Prerequisites

- [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli) >= 2.50
- [Bicep CLI](https://docs.microsoft.com/en-us/azure/azure-resource-manager/bicep/install) >= 0.20
- Resource group `rg-xposter` already created in Italy North

## Deploy

```bash
# Login
az login

# Deploy full infrastructure
az deployment group create \
  --resource-group rg-xposter \
  --template-file infra/main.bicep \
  --parameters infra/main.bicepparam
```

## Notes

- **Key Vault** uses the Vault Access Policy model (`enableRbacAuthorization: false`) — do not switch to RBAC without migrating all existing policies
- **Secrets** (LinkedIn tokens, etc.) are NOT provisioned by Bicep — they must be set manually via CLI or portal after deployment
- **System Assigned Managed Identity** is enabled on XPosterFunction and granted `get/set/list` permissions on the Key Vault
- The `do-not-delete` tag on Key Vault signals that the resource is in active use by XPosterFunction

## Secret naming convention

Secrets are bound to typed credentials DTOs via the Azure Key Vault Configuration Provider. Use the double-dash convention so a secret maps to the `SectionName:Property` configuration key expected by `IOptions<T>` (e.g. `LinkedInCredentials--LinkedInAccessToken` → `LinkedInCredentials:LinkedInAccessToken`).

| Secret name | Bound configuration key | Description |
|---|---|---|
| `XCredentials--XApiKey` | `XCredentials:XApiKey` | Twitter/X API Key (Consumer Key) |
| `XCredentials--XApiSecret` | `XCredentials:XApiSecret` | Twitter/X API Secret (Consumer Secret) |
| `XCredentials--XAccessToken` | `XCredentials:XAccessToken` | Twitter/X User Access Token |
| `XCredentials--XAccessTokenSecret` | `XCredentials:XAccessTokenSecret` | Twitter/X User Access Token Secret |
| `LinkedInCredentials--LinkedInAccessToken` | `LinkedInCredentials:LinkedInAccessToken` | LinkedIn OAuth 2.0 access token (~60 days) |
| `LinkedInCredentials--LinkedInOrgId` | `LinkedInCredentials:LinkedInOrgId` | LinkedIn organization ID (takes precedence) |
| `LinkedInCredentials--LinkedInOwnerCode` | `LinkedInCredentials:LinkedInOwnerCode` | LinkedIn numeric person ID |
| `InstagramCredentials--InstagramAccessToken` | `InstagramCredentials:InstagramAccessToken` | Instagram Graph API access token |
| `InstagramCredentials--InstagramAccountId` | `InstagramCredentials:InstagramAccountId` | Instagram Business Account ID |
| `FacebookCredentials--FacebookAccessToken` | `FacebookCredentials:FacebookAccessToken` | Facebook Graph API access token |
| `FacebookCredentials--FacebookPageId` | `FacebookCredentials:FacebookPageId` | Facebook Page numeric ID |
| `XApiKey` | `XApiKey` | Top-level probe used by `DryRunSender` (any non-empty value) |

See [docs/configuration.md](../docs/configuration.md) for the authoritative secret reference.
