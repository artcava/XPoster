# Configuration Reference

All configuration is passed via environment variables — locally in `src/local.settings.json`, in production via Azure App Settings (or Key Vault references).

The file [`src/local.settings.json.example`](../src/local.settings.json.example) is the canonical starting template: copy it to `src/local.settings.json`, fill in the empty strings, and the function is ready to run locally.

---

## Quick-Start Checklist

For a minimal local setup with the default provider (`OpenAi`) you need at minimum:

- [ ] `AzureWebJobsStorage` — Azurite or a real Storage Account connection string
- [ ] `X_API_KEY`, `X_API_SECRET`, `X_ACCESS_TOKEN`, `X_ACCESS_TOKEN_SECRET`
- [ ] `IN_ACCESS_TOKEN` + one of `IN_OWNER` / `IN_ORG_ID`
- [ ] `OpenAI__ApiKey`
- [ ] (Optional) `APPLICATIONINSIGHTS_CONNECTION_STRING` for local telemetry

For the `DeepSeekWithFal` provider (HybridAiService), replace the OpenAI block with:

- [ ] `DeepSeek__ApiKey`
- [ ] `FalAi__ApiKey`

---

## Azure Functions Runtime

| Variable | Type | Required | Default | Description |
|---|---|---|---|---|
| `AzureWebJobsStorage` | string | ✅ Yes | `UseDevelopmentStorage=true` | Storage connection string. Use `UseDevelopmentStorage=true` with Azurite locally; use a full Azure Storage Account connection string in production. |
| `FUNCTIONS_WORKER_RUNTIME` | string | ✅ Yes | `dotnet-isolated` | Must be `dotnet-isolated` for .NET 8 isolated worker. Do not change. |

---

## Scheduler

| Variable | Type | Required | Default | Description |
|---|---|---|---|---|
| `CronSchedule` | string | ✅ Yes | `0 0 6,8,14,16 * * *` | 6-field NCRONTAB expression (`{second} {minute} {hour} {day} {month} {dayOfWeek}`) controlling execution frequency. |

**Common expressions:**

| Expression | Fires at |
|---|---|
| `0 0 6,8,14,16 * * *` | 06:00, 08:00, 14:00, 16:00 every day (default) |
| `0 0 * * * *` | Every hour on the hour |
| `0 0 9,12,15,18 * * 1-5` | 09:00, 12:00, 15:00, 18:00 Mon–Fri |
| `*/30 * * * * *` | Every 30 seconds (dev/test only) |

---

## AI Provider Selector

| Variable | Type | Required | Default | Description |
|---|---|---|---|---|
| `AiProvider` | string | No | `OpenAi` | Selects the `IAiService` implementation injected into AI-enabled generators. Supported values: `OpenAi`, `AzureFoundry`, `DeepSeekWithFal`. |

| `AiProvider` value | Resolved service | Text backend | Image backend |
|---|---|---|---|
| `OpenAi` | `OpenAiService` | `OpenAI__ChatEndpoint` | `OpenAI__ImageEndpoint` |
| `AzureFoundry` | `AzureFoundryService` | `AzureFoundry__Endpoint` + `AzureFoundry__DeploymentName` | `AzureFoundry__ImageDeploymentName` |
| `DeepSeekWithFal` | `HybridAiService` | `DeepSeek__*` | `FalAi__*` |

> Only the configuration block that corresponds to the selected `AiProvider` is required at runtime. The other provider blocks are ignored.

---

## Twitter / X

Obtain all four values from [developer.twitter.com](https://developer.twitter.com) → **Your App** → **Keys and Tokens**. The app must have **Read and Write** permissions.

| Variable | Type | Required | Description |
|---|---|---|---|
| `X_API_KEY` | string | ✅ Yes | Twitter App API Key (Consumer Key). |
| `X_API_SECRET` | string | ✅ Yes | Twitter App API Secret (Consumer Secret). |
| `X_ACCESS_TOKEN` | string | ✅ Yes | User Access Token (OAuth 1.0a). |
| `X_ACCESS_TOKEN_SECRET` | string | ✅ Yes | User Access Token Secret (OAuth 1.0a). |

---

## LinkedIn

| Variable | Type | Required | Description |
|---|---|---|---|
| `IN_ACCESS_TOKEN` | string | ✅ Yes | LinkedIn OAuth 2.0 access token. Obtain from [LinkedIn Developer Portal](https://developer.linkedin.com) → OAuth credentials. **Expires every 60 days** — manual rotation is currently required. |
| `IN_OWNER` | string | ⚠️ One of `IN_OWNER` / `IN_ORG_ID` | Numeric LinkedIn person ID of the account that will author posts (e.g. `123456789`). Resolve via `GET https://api.linkedin.com/v2/userinfo`. Posts are published as `urn:li:person:{IN_OWNER}`. Ignored when `IN_ORG_ID` is set. |
| `IN_ORG_ID` | string | ⚠️ One of `IN_OWNER` / `IN_ORG_ID` | Numeric LinkedIn organization ID for publishing on behalf of a company page (e.g. `98765432`). When set, takes precedence over `IN_OWNER`. Posts are published as `urn:li:organization:{IN_ORG_ID}`. |

> ⚠️ LinkedIn token refresh is currently limited to organization accounts (`IN_ORG_ID`). Personal member accounts require manual renewal every 60 days. See the [Roadmap](../README.md#roadmap) for the automated refresh milestone.

---

## Instagram

> ⚠️ Instagram publishing is **not yet active in production**. These variables are read by `IgSender` but the slot is disabled in `GeneratorFactory`. See issue [#72](https://github.com/artcava/XPoster/issues/72) for the full enablement checklist.

| Variable | Type | Required | Description |
|---|---|---|---|
| `IG_ACCESS_TOKEN` | string | ✅ Yes (when enabled) | Long-lived Instagram Graph API access token. |
| `IG_ACCOUNT_ID` | string | ✅ Yes (when enabled) | Numeric Instagram Business Account ID used in Graph API calls. |

---

## AI — OpenAI (`AiProvider = OpenAi`)

Configuration bound from the `OpenAI` prefix using double-underscore notation in Azure App Settings / `local.settings.json` (e.g. `OpenAI__ApiKey`).

### Connection

| Setting | Type | Required | Default | Description |
|---|---|---|---|---|
| `OpenAI__ApiKey` | string | ✅ Yes | — | OpenAI platform API key. |
| `OpenAI__ChatEndpoint` | string | No | `https://api.openai.com/v1/chat/completions` | Chat Completions API URL. Override to point at an Azure OpenAI or other OpenAI-compatible endpoint. |
| `OpenAI__ChatModel` | string | No | `gpt-4.1-nano` | Model used for text summarisation and image prompt generation. |
| `OpenAI__ImageEndpoint` | string | No | `https://api.openai.com/v1/images/generations` | Image Generations API URL. |
| `OpenAI__ImageModel` | string | No | `gpt-image-1.5` | Model used for image generation. |
| `OpenAI__ImageSize` | string | No | `1024x1024` | Output image dimensions (e.g. `1024x1024`, `1792x1024`). |
| `OpenAI__ImageCount` | int | No | `1` | Number of images to generate per request. |

### Summarisation Tuning

| Setting | Type | Default | Description |
|---|---|---|---|
| `OpenAI__SummaryTemperature` | double | `0.5` | Temperature for summary generation. Lower = more deterministic. |
| `OpenAI__SummaryMaxTokensPerChar` | int | `5` | Divisor to convert a character budget to `max_tokens` (budget ÷ value). |
| `OpenAI__SummarySafetyMarginChars` | int | `50` | Character margin subtracted from the platform character limit before passing `{MaxChars}` to the prompt. |
| `OpenAI__SummarySystemPromptTemplate` | string | *(see example)* | System prompt for summarisation. Supports `{MaxChars}` placeholder. |
| `OpenAI__SummaryUserPromptTemplate` | string | *(see example)* | User prompt for summarisation. Supports `{Text}` placeholder. |

### Image Prompt Tuning

| Setting | Type | Default | Description |
|---|---|---|---|
| `OpenAI__ImagePromptSystemTemplate` | string | *(see example)* | System prompt for image prompt generation. No placeholders. |
| `OpenAI__ImagePromptUserTemplate` | string | *(see example)* | User prompt for image prompt generation. Supports `{Summary}` placeholder. |
| `OpenAI__ImagePromptMaxTokens` | int | `60` | Max tokens for image prompt generation requests. |
| `OpenAI__ImagePromptTemperature` | double | `0.7` | Temperature for image prompt generation requests. |

---

## AI — Azure AI Foundry (`AiProvider = AzureFoundry`)

Configuration bound from the `AzureFoundry` prefix using double-underscore notation (e.g. `AzureFoundry__Endpoint`).

### Connection

| Setting | Type | Required | Default | Description |
|---|---|---|---|---|
| `AzureFoundry__Endpoint` | string | ✅ Yes | — | Base endpoint for your Azure AI Foundry resource (e.g. `https://my-hub.openai.azure.com/`). |
| `AzureFoundry__ApiKey` | string | ✅ Yes | — | API key sent as the `api-key` header. |
| `AzureFoundry__DeploymentName` | string | ✅ Yes | — | Chat deployment name used for summary and image-prompt generation. |
| `AzureFoundry__ImageDeploymentName` | string | No | — | Image deployment name used by `GenerateImageAsync`. Leave empty if the same deployment handles both. |
| `AzureFoundry__ApiVersion` | string | No | `2024-02-01` | Azure OpenAI REST API version appended to all requests. |

### Summarisation Tuning

| Setting | Type | Default | Description |
|---|---|---|---|
| `AzureFoundry__SummaryTemperature` | double | `0.5` | Temperature for summary generation. |
| `AzureFoundry__SummaryMaxTokensPerChar` | int | `5` | Divisor to convert character budget to `max_tokens`. |
| `AzureFoundry__SummarySafetyMarginChars` | int | `50` | Character margin subtracted from budget. |
| `AzureFoundry__SummarySystemPromptTemplate` | string | *(see example)* | System prompt for summarisation. Supports `{MaxChars}`. |
| `AzureFoundry__SummaryUserPromptTemplate` | string | *(see example)* | User prompt for summarisation. Supports `{Text}`. |

### Image Prompt Tuning

| Setting | Type | Default | Description |
|---|---|---|---|
| `AzureFoundry__ImagePromptSystemTemplate` | string | *(see example)* | System prompt for image-prompt generation. |
| `AzureFoundry__ImagePromptUserTemplate` | string | *(see example)* | User prompt for image-prompt generation. Supports `{Summary}`. |
| `AzureFoundry__ImagePromptMaxTokens` | int | `60` | Max tokens for image-prompt generation. |
| `AzureFoundry__ImagePromptTemperature` | double | `0.7` | Temperature for image-prompt generation. |

---

## AI — DeepSeek (`AiProvider = DeepSeekWithFal`, text half)

`DeepSeekService` handles `GetSummaryAsync` and `GetImagePromptAsync` inside `HybridAiService`. Configuration bound from the `DeepSeek` prefix (e.g. `DeepSeek__ApiKey`).

### Connection

| Setting | Type | Required | Default | Description |
|---|---|---|---|---|
| `DeepSeek__Endpoint` | string | No | `https://api.deepseek.com` | DeepSeek REST API base URL. |
| `DeepSeek__ApiKey` | string | ✅ Yes | — | DeepSeek platform API key. Obtain from [platform.deepseek.com](https://platform.deepseek.com). |
| `DeepSeek__DeploymentName` | string | No | `deepseek-chat` | Model identifier (e.g. `deepseek-chat`, `deepseek-reasoner`). |

### Summarisation Tuning

| Setting | Type | Default | Description |
|---|---|---|---|
| `DeepSeek__SummaryTemperature` | double | `0.5` | Temperature for summary generation. |
| `DeepSeek__SummaryMaxTokensPerChar` | int | `5` | Divisor to convert character budget to `max_tokens`. |
| `DeepSeek__SummarySafetyMarginChars` | int | `50` | Character margin subtracted from budget. |
| `DeepSeek__SummarySystemPromptTemplate` | string | *(see example)* | System prompt for summarisation. Supports `{MaxChars}`. |
| `DeepSeek__SummaryUserPromptTemplate` | string | *(see example)* | User prompt for summarisation. Supports `{Text}`. |

### Image Prompt Tuning

| Setting | Type | Default | Description |
|---|---|---|---|
| `DeepSeek__ImagePromptSystemTemplate` | string | *(see example)* | System prompt for image-prompt generation. |
| `DeepSeek__ImagePromptUserTemplate` | string | *(see example)* | User prompt for image-prompt generation. Supports `{Summary}`. |
| `DeepSeek__ImagePromptMaxTokens` | int | `60` | Max tokens for image-prompt generation. |
| `DeepSeek__ImagePromptTemperature` | double | `0.7` | Temperature for image-prompt generation. |

---

## AI — fal.ai (`AiProvider = DeepSeekWithFal`, image half)

`FalAiImageService` handles `GenerateImageAsync` inside `HybridAiService`. Configuration bound from the `FalAi` prefix (e.g. `FalAi__ApiKey`).

| Setting | Type | Required | Default | Description |
|---|---|---|---|---|
| `FalAi__ApiKey` | string | ✅ Yes | — | fal.ai API key. Obtain from [fal.ai/dashboard](https://fal.ai/dashboard). |
| `FalAi__ModelId` | string | No | `fal-ai/flux/schnell` | fal.ai model identifier (e.g. `fal-ai/flux/schnell`, `fal-ai/flux-pro`). |
| `FalAi__ImageSize` | string | No | `landscape_4_3` | Named size preset accepted by the fal.ai API (e.g. `landscape_4_3`, `square`, `portrait_4_3`). |
| `FalAi__NumInferenceSteps` | int | No | `4` | Number of diffusion inference steps. Lower = faster and cheaper; higher = better quality. |

> ℹ️ `FalAi__ModelId` defaults to the FLUX Schnell variant, which is optimised for speed. Switch to `fal-ai/flux-pro` for higher-quality output at increased cost per image.

---

## Observability

| Variable | Type | Required | Default | Description |
|---|---|---|---|---|
| `APPLICATIONINSIGHTS_CONNECTION_STRING` | string | No | — | Application Insights connection string. When present, the isolated worker SDK automatically registers the telemetry pipeline. Format: `InstrumentationKey=<key>;IngestionEndpoint=https://<region>.in.applicationinsights.azure.com/`. |

---

## Security Notes

- Never commit `local.settings.json` — it is listed in `.gitignore`.
- Use [`src/local.settings.json.example`](../src/local.settings.json.example) as the starting template; it contains no real secrets.
- For CI/CD, store secrets as **GitHub Actions Secrets**; never embed them in workflow YAML files.
- In production, consider using **Azure Key Vault references** in App Settings to avoid storing secrets as plain-text values in the portal.

---

## Future / Planned

The following keys are reserved for future features and are not read by any code in the current version.

| Key | Notes |
|---|---|
| `LINKEDIN_CLIENT_ID` / `LINKEDIN_CLIENT_SECRET` | Required for automated LinkedIn token refresh (OAuth 2.0 PKCE flow — planned). |
| `KEYVAULT_URI` | Azure Key Vault integration for secrets management (planned). |
