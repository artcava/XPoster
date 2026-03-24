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
| `LINKEDIN_ACCESS_TOKEN` | string | — | OAuth 2.0 Bearer Token (expires every 60 days) |
| `LINKEDIN_ORGANIZATION_ID` | string | — | Numeric ID of the LinkedIn organization page |

> Generate tokens at [LinkedIn Developer Portal](https://www.linkedin.com/developers/). Note: tokens require periodic renewal (see Roadmap Phase 2).

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
- In production, prefer **Azure Key Vault references** over plain-text App Settings.
- For CI/CD, store secrets in **GitHub Actions Secrets**, never in workflow YAML.
