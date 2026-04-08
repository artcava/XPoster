# Configuration Reference

All configuration is passed via environment variables (locally in `src/local.settings.json`, in production via Azure App Settings).

## Scheduler

| Variable | Type | Required | Default | Description |
|---|---|---|---|---|
| `CronSchedule` | string | ✅ Yes | `0 0 6,8,14,16 * * *` | 6-field cron expression controlling execution frequency |

## Twitter / X

| Variable | Type | Required | Description |
|---|---|---|---|
| `X_API_KEY` | string | ✅ Yes | Twitter App API Key |
| `X_API_SECRET` | string | ✅ Yes | Twitter App API Secret |
| `X_ACCESS_TOKEN` | string | ✅ Yes | User Access Token |
| `X_ACCESS_TOKEN_SECRET` | string | ✅ Yes | User Access Token Secret |

> Obtain from [developer.twitter.com](https://developer.twitter.com) → Your App → Keys and Tokens.

## LinkedIn

| Variable | Type | Required | Description |
|---|---|---|---|
| `IN_ACCESS_TOKEN` | string | ✅ Yes | LinkedIn OAuth 2.0 access token. Obtain from LinkedIn Developer Portal → OAuth credentials. Expires every 60 days (manual rotation required). |
| `IN_OWNER` | string | ✅ Yes | Numeric LinkedIn person ID of the account that will author posts (e.g. `123456789`). Find it via `GET https://api.linkedin.com/v2/userinfo`. Posts are published as `urn:li:person:{IN_OWNER}`. |

## Instagram

| Variable | Type | Required | Description |
|---|---|---|---|
| `IG_ACCESS_TOKEN` | string | ✅ Yes | Long-lived Instagram Graph API access token. |
| `IG_ACCOUNT_ID` | string | ✅ Yes | Numeric Instagram Business Account ID used in Graph API calls. |

> ⚠️ Instagram is not yet active in production. See issue #XX (Instagram production readiness) for the full enablement checklist.

## AI (OpenAI)

| Variable | Type | Required | Description |
|---|---|---|---|
| `OPENAI_API_KEY` | string | ✅ Yes | OpenAI platform API key. Used by `AiService` for both text summarisation (`gpt-4.1-nano`) and image generation (`gpt-image-1.5`). |

## Azure Functions Runtime

| Variable | Type | Required | Default | Description |
|---|---|---|---|---|
| `AzureWebJobsStorage` | string | ✅ Yes | `UseDevelopmentStorage=true` | Storage connection string (Azurite locally, Storage Account in prod) |
| `FUNCTIONS_WORKER_RUNTIME` | string | ✅ Yes | `dotnet-isolated` | Must be `dotnet-isolated` for .NET 8 isolated worker |
| `APPLICATIONINSIGHTS_CONNECTION_STRING` | string | ❌ No | — | Connection string for Application Insights monitoring |

## Security Notes

- Never commit `local.settings.json` — it is in `.gitignore`.
- Use `src/local.settings.json.example` as the starting template.
- For CI/CD, store secrets in **GitHub Actions Secrets**, never in workflow YAML.

---

## Future / Planned

The following keys are reserved for a future migration back to Azure OpenAI. They are not read by any code in the current version.

- `AZURE_OPENAI_KEY`
- `AZURE_OPENAI_ENDPOINT`
- `AZURE_OPENAI_DEPLOYMENT_NAME`
- `LINKEDIN_CLIENT_ID`
- `LINKEDIN_CLIENT_SECRET`
- `KEYVAULT_URI`