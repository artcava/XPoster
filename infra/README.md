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

| Secret name | Description |
|---|---|
| `LinkedInAccessToken` | LinkedIn OAuth access token (~60 days) |
| `LinkedInClientId` | LinkedIn app Client ID |
| `LinkedInClientSecret` | LinkedIn app Client Secret |
| `{Platform}AccessToken` | Pattern for future platforms (e.g. `InstagramAccessToken`) |
