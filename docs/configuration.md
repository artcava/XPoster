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
| `IN_OWNER` | string | ⚠️ One of `IN_OWNER` / `IN_ORG_ID` | Numeric LinkedIn person ID of the account that will author posts (e.g. `123456789`). Find it via `GET https://api.linkedin.com/v2/userinfo`. Posts are published as `urn:li:person:{IN_OWNER}`. Ignored when `IN_ORG_ID` is set. |
| `IN_ORG_ID` | string | ⚠️ One of `IN_OWNER` / `IN_ORG_ID` | Numeric LinkedIn organization ID for publishing on behalf of a company page (e.g. `98765432`). When set, takes precedence over `IN_OWNER`. Posts are published as `urn:li:organization:{IN_ORG_ID}`. |

## Instagram

| Variable | Type | Required | Description |
|---|---|---|---|
| `IG_ACCESS_TOKEN` | string | ✅ Yes | Long-lived Instagram Graph API access token. |
| `IG_ACCOUNT_ID` | string | ✅ Yes | Numeric Instagram Business Account ID used in Graph API calls. |

> ⚠️ Instagram is not yet active in production. See issue #XX (Instagram production readiness) for the full enablement checklist.

## AI (OpenAI)

Configuration is bound from the `OpenAI` section using double-underscore notation in Azure App Settings / `local.settings.json` (e.g. `OpenAI__ApiKey`).

| Setting | Type | Required | Default | Description |
|---|---|---|---|---|
| `OpenAI__ApiKey` | string | ✅ Yes | — | OpenAI platform API key. Used by `OpenAiService` for all API calls. |
| `OpenAI__ChatEndpoint` | string | No | `https://api.openai.com/v1/chat/completions` | Chat Completions API URL. |
| `OpenAI__ChatModel` | string | No | `gpt-4.1-nano` | Model used for text summarisation and image prompt generation. |
| `OpenAI__SummaryTemperature` | double | No | `0.5` | Temperature for summary generation. |
| `OpenAI__SummaryMaxTokensPerChar` | int | No | `5` | Divisor to convert a character budget to `max_tokens`. |
| `OpenAI__SummarySafetyMarginChars` | int | No | `50` | Character margin subtracted from the budget in the system prompt. |
| `OpenAI__ImageEndpoint` | string | No | `https://api.openai.com/v1/images/generations` | Image Generations API URL. |
| `OpenAI__ImageModel` | string | No | `gpt-image-1.5` | Model used for image generation. |
| `OpenAI__ImageSize` | string | No | `1024x1024` | Output image size. |
| `OpenAI__ImageCount` | int | No | `1` | Number of images to generate per request. |

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