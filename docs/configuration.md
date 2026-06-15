# Configuration Reference

All configuration is passed via environment variables — locally in `src/local.settings.json`, in production via Azure App Settings.

The file [`src/local.settings.json.example`](../src/local.settings.json.example) is the canonical starting template: copy it to `src/local.settings.json`, fill in the empty strings, and the function is ready to run locally.

> ⚠️ Sender credentials (Twitter/X, LinkedIn, Instagram) are **no longer configured via environment variables**. They are resolved at runtime by `KeyVaultService` directly from Azure Key Vault. See the [Key Vault](#key-vault) section below.

---

## Quick-Start Checklist

For a minimal local setup with the default provider (`OpenAi`) you need at minimum:

- [ ] `AzureWebJobsStorage` — Azurite or a real Storage Account connection string
- [ ] `KEYVAULT_URI` — URI of the Azure Key Vault instance holding all sender credentials
- [ ] `OpenAI__ApiKey`
- [ ] (Optional) `APPLICATIONINSIGHTS_CONNECTION_STRING` for local telemetry

For the `DeepSeekWithFal` provider (HybridAiService), replace the OpenAI block with:

- [ ] `DeepSeek__ApiKey`
- [ ] `FalAi__ApiKey`

> 💡 For local development, run `az login` before starting the function. `KeyVaultService` uses `DefaultAzureCredential`, which picks up your Azure CLI session automatically.

---

## Full `local.settings.json` Example

The file below mirrors [`src/local.settings.json.example`](../src/local.settings.json.example) exactly, with inline comments explaining every key.

```jsonc
{
  "IsEncrypted": false,
  "Values": {

    // ── Azure Functions Runtime ──────────────────────────────────────────
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    // Use Azurite (local emulator) or a real Storage Account connection string.

    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    // Required by the .NET 8 isolated worker model. Do not change.

    // ── Scheduler ────────────────────────────────────────────────────────
    "CronSchedule": "0 0 6,8,14,16 * * *",
    // 6-field NCRONTAB expression: {second} {minute} {hour} {day} {month} {dayOfWeek}
    // Default fires at 06:00, 08:00, 14:00, 16:00 every day.
    // Use "*/30 * * * * *" for rapid testing (every 30 seconds, dev/test only).

    // ── AI Provider Selector ─────────────────────────────────────────────
    "AiProvider": "OpenAi",
    // Selects the IAiService implementation injected into AI-enabled orchestrators.
    // Supported values: OpenAi | AzureFoundry | DeepSeekWithFal

    // ── Key Vault ────────────────────────────────────────────────────────
    "KEYVAULT_URI": "https://<your-keyvault-name>.vault.azure.net/",
    // URI of the Azure Key Vault instance holding all sender OAuth credentials.
    // Local dev: run `az login` — DefaultAzureCredential picks up your CLI session.
    // Azure deployment: Managed Identity handles authentication automatically.
    //
    // Required secrets in Key Vault (exact casing enforced):
    //   XApiKey               — X (Twitter) API key
    //   XApiSecret            — X (Twitter) API secret
    //   XAccessToken          — X (Twitter) access token
    //   XAccessTokenSecret    — X (Twitter) access token secret
    //   LinkedInAccessToken   — LinkedIn OAuth 2.0 Bearer token
    //   LinkedInOwnerCode     — LinkedIn person/owner ID
    //   LinkedInOrgId         — LinkedIn organization ID (optional; org posts)
    //   IgAccessToken         — Instagram Graph API access token
    //   IgAccountId           — Instagram account ID

    // ══ AI — OpenAI (AiProvider = "OpenAi") ═════════════════════════════
    "OpenAI__ApiKey": "",
    // Required. OpenAI platform API key. Obtain from platform.openai.com > API Keys.

    "OpenAI__ChatEndpoint": "https://api.openai.com/v1/chat/completions",
    // Chat Completions API URL. Override to point at an Azure OpenAI or other
    // OpenAI-compatible endpoint.

    "OpenAI__ChatModel": "gpt-4.1-nano",
    "OpenAI__SummaryTemperature": "0.5",
    "OpenAI__SummaryMaxTokensPerChar": "5",
    "OpenAI__SummarySafetyMarginChars": "50",
    "OpenAI__SummarySystemPromptTemplate": "You are an assistant that summarizes text concisely. It's very important that you keep summaries under {MaxChars} characters.",
    "OpenAI__SummaryUserPromptTemplate": "Summarize this text in a few sentences. text: {Text}",
    "OpenAI__ImageEndpoint": "https://api.openai.com/v1/images/generations",
    "OpenAI__ImageModel": "gpt-image-1.5",
    "OpenAI__ImageSize": "1024x1024",
    "OpenAI__ImageCount": "1",
    "OpenAI__ImagePromptSystemTemplate": "You are an assistant that generates image prompts for an AI image generation model based on text summaries. Create a concise, vivid prompt in English that reflects the summary's content, includes a Bitcoin-related element (e.g., a coin), and avoids text, signs, or words in the image. Respect content policy for generating images.",
    "OpenAI__ImagePromptUserTemplate": "Generate an image prompt based on this summary: {Summary}",
    "OpenAI__ImagePromptMaxTokens": "60",
    "OpenAI__ImagePromptTemperature": "0.7",

    // ══ AI — Azure AI Foundry (AiProvider = "AzureFoundry") ══════════════
    "AzureFoundry__Endpoint": "",
    "AzureFoundry__ApiKey": "",
    "AzureFoundry__DeploymentName": "",
    "AzureFoundry__ImageDeploymentName": "",
    "AzureFoundry__ApiVersion": "2024-02-01",
    "AzureFoundry__SummaryTemperature": "0.5",
    "AzureFoundry__SummaryMaxTokensPerChar": "5",
    "AzureFoundry__SummarySafetyMarginChars": "50",
    "AzureFoundry__SummarySystemPromptTemplate": "You are an assistant that summarizes text concisely. It's very important that you keep summaries under {MaxChars} characters.",
    "AzureFoundry__SummaryUserPromptTemplate": "Summarize this text in a few sentences. text: {Text}",
    "AzureFoundry__ImagePromptSystemTemplate": "You are an assistant that generates image prompts for an AI image generation model based on text summaries. Create a concise, vivid prompt in English that reflects the summary's content, includes a Bitcoin-related element (e.g., a coin), and avoids text, signs, or words in the image. Respect content policy for generating images.",
    "AzureFoundry__ImagePromptUserTemplate": "Generate an image prompt based on this summary: {Summary}",
    "AzureFoundry__ImagePromptMaxTokens": "60",
    "AzureFoundry__ImagePromptTemperature": "0.7",

    // ══ AI — DeepSeek (AiProvider = "DeepSeekWithFal", text half) ═════════
    "DeepSeek__Endpoint": "https://api.deepseek.com",
    "DeepSeek__ApiKey": "",
    "DeepSeek__DeploymentName": "deepseek-chat",
    "DeepSeek__SummaryTemperature": "0.5",
    "DeepSeek__SummaryMaxTokensPerChar": "5",
    "DeepSeek__SummarySafetyMarginChars": "50",
    "DeepSeek__SummarySystemPromptTemplate": "You are an assistant that summarizes text concisely. It's very important that you keep summaries under {MaxChars} characters.",
    "DeepSeek__SummaryUserPromptTemplate": "Summarize this text in a few sentences. text: {Text}",
    "DeepSeek__ImagePromptSystemTemplate": "You are an assistant that generates image prompts for an AI image generation model based on text summaries. Create a concise, vivid prompt in English that reflects the summary's content, includes a Bitcoin-related element (e.g., a coin), and avoids text, signs, or words in the image. Respect content policy for generating images.",
    "DeepSeek__ImagePromptUserTemplate": "Generate an image prompt based on this summary: {Summary}",
    "DeepSeek__ImagePromptMaxTokens": "60",
    "DeepSeek__ImagePromptTemperature": "0.7",

    // ══ AI — fal.ai (AiProvider = "DeepSeekWithFal", image half) ══════════
    "FalAi__ApiKey": "",
    "FalAi__ModelId": "fal-ai/flux/schnell",
    "FalAi__ImageSize": "landscape_4_3",
    "FalAi__NumInferenceSteps": "4",

    // ── Observability ─────────────────────────────────────────────────────
    "APPLICATIONINSIGHTS_CONNECTION_STRING": ""
    // Application Insights connection string.
    // When present, the isolated worker SDK automatically registers the telemetry pipeline.
  }
}
```

> **Note on `jsonc`:** `local.settings.json` does **not** support inline comments at runtime. The `jsonc`-annotated block above is for documentation only. The actual [`src/local.settings.json.example`](../src/local.settings.json.example) file uses plain JSON with empty-string placeholders.

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
| `AiProvider` | string | No | `OpenAi` | Selects the `IAiService` implementation injected into AI-enabled orchestrators. Supported values: `OpenAi`, `AzureFoundry`, `DeepSeekWithFal`. |

| `AiProvider` value | Resolved service | Text backend | Image backend |
|---|---|---|---|
| `OpenAi` | `OpenAiService` | `OpenAI__ChatEndpoint` | `OpenAI__ImageEndpoint` |
| `AzureFoundry` | `AzureFoundryService` | `AzureFoundry__Endpoint` + `AzureFoundry__DeploymentName` | `AzureFoundry__ImageDeploymentName` |
| `DeepSeekWithFal` | `HybridAiService` | `DeepSeek__*` | `FalAi__*` |

> Only the configuration block that corresponds to the selected `AiProvider` is required at runtime. The other provider blocks are ignored.

---

## Key Vault

All sender OAuth credentials (Twitter/X, LinkedIn, Instagram) are resolved at runtime by `KeyVaultService` (`IKeyVaultService`) directly from Azure Key Vault. They are **not** stored in environment variables or App Settings.

| Variable | Type | Required | Description |
|---|---|---|---|
| `KEYVAULT_URI` | string | ✅ Yes | Full URI of the Azure Key Vault instance, e.g. `https://<vault-name>.vault.azure.net/`. |

### Authentication

`KeyVaultService` uses `DefaultAzureCredential` from `Azure.Identity`, which resolves credentials in the following order:

| Environment | Credential used |
|---|---|
| Local development | Azure CLI session (`az login`) |
| Azure (production) | Function App Managed Identity (no secrets required) |

For local development, ensure the identity used with `az login` has the **Key Vault Secrets User** role on the vault.

### Required Secrets in Key Vault

Secret names are case-sensitive. The following secrets must be present in the vault:

#### Twitter / X

| Secret name | Description |
|---|---|
| `XApiKey` | Twitter App API Key (Consumer Key). Obtain from [developer.twitter.com](https://developer.twitter.com) → Your App → Keys and Tokens. The app must have **Read and Write** permissions. |
| `XApiSecret` | Twitter App API Secret (Consumer Secret). |
| `XAccessToken` | User Access Token (OAuth 1.0a). |
| `XAccessTokenSecret` | User Access Token Secret (OAuth 1.0a). |

#### LinkedIn

| Secret name | Required | Description |
|---|---|---|
| `LinkedInAccessToken` | ✅ Yes | LinkedIn OAuth 2.0 access token. Obtain from [LinkedIn Developer Portal](https://developer.linkedin.com) → OAuth credentials. **Expires every 60 days** — manual rotation is currently required. |
| `LinkedInOwnerCode` | ⚠️ One of `LinkedInOwnerCode` / `LinkedInOrgId` | Numeric LinkedIn person ID of the account that will author posts (e.g. `123456789`). Resolve via `GET https://api.linkedin.com/v2/userinfo`. Posts are published as `urn:li:person:{id}`. Ignored when `LinkedInOrgId` is set. |
| `LinkedInOrgId` | ⚠️ One of `LinkedInOwnerCode` / `LinkedInOrgId` | Numeric LinkedIn organization ID for publishing on behalf of a company page (e.g. `98765432`). When set, takes precedence over `LinkedInOwnerCode`. Posts are published as `urn:li:organization:{id}`. |

> ⚠️ LinkedIn token refresh is currently limited to organization accounts. Personal member accounts require manual renewal every 60 days. See the [Roadmap](../README.md#roadmap) for the automated refresh milestone.

#### Instagram

> ⚠️ Instagram publishing is **not yet active in production**. These secrets are read by `IgSender` but the slot is disabled in `OrchestratorFactory`. See issue [#72](https://github.com/artcava/XPoster/issues/72) for the full enablement checklist.

| Secret name | Description |
|---|---|
| `IgAccessToken` | Long-lived Instagram Graph API access token. |
| `IgAccountId` | Numeric Instagram Business Account ID used in Graph API calls. |

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
| `AzureFoundry__Endpoint` | string | ✅ Yes | — | Azure OpenAI resource endpoint (e.g. `https://<resource>.openai.azure.com/`). |
| `AzureFoundry__ApiKey` | string | ✅ Yes* | — | Azure OpenAI resource key. *Omit when using Managed Identity. |
| `AzureFoundry__DeploymentName` | string | ✅ Yes | — | Chat deployment name as configured in Azure AI Foundry. |
| `AzureFoundry__ImageDeploymentName` | string | ✅ Yes | — | Image generation deployment name. |
| `AzureFoundry__ApiVersion` | string | No | `2024-02-01` | Azure OpenAI REST API version. |

### Tuning (same semantics as OpenAI)

| Setting | Type | Default |
|---|---|---|
| `AzureFoundry__SummaryTemperature` | double | `0.5` |
| `AzureFoundry__SummaryMaxTokensPerChar` | int | `5` |
| `AzureFoundry__SummarySafetyMarginChars` | int | `50` |
| `AzureFoundry__SummarySystemPromptTemplate` | string | *(see example)* |
| `AzureFoundry__SummaryUserPromptTemplate` | string | *(see example)* |
| `AzureFoundry__ImagePromptSystemTemplate` | string | *(see example)* |
| `AzureFoundry__ImagePromptUserTemplate` | string | *(see example)* |
| `AzureFoundry__ImagePromptMaxTokens` | int | `60` |
| `AzureFoundry__ImagePromptTemperature` | double | `0.7` |

---

## AI — DeepSeek (`AiProvider = DeepSeekWithFal`, text half)

`DeepSeekService` handles `GetSummaryAsync` and `GetImagePromptAsync` inside `HybridAiService`. Configuration bound from the `DeepSeek` prefix (e.g. `DeepSeek__ApiKey`).

### Connection

| Setting | Type | Required | Default | Description |
|---|---|---|---|---|
| `DeepSeek__Endpoint` | string | No | `https://api.deepseek.com` | DeepSeek API base URL. |
| `DeepSeek__ApiKey` | string | ✅ Yes | — | DeepSeek API key. Obtain from [platform.deepseek.com](https://platform.deepseek.com). |
| `DeepSeek__DeploymentName` | string | No | `deepseek-chat` | DeepSeek model name (e.g. `deepseek-chat`, `deepseek-reasoner`). |

### Tuning

| Setting | Type | Default | Description |
|---|---|---|---|
| `DeepSeek__SummaryTemperature` | double | `0.5` | Temperature for summary generation. |
| `DeepSeek__SummaryMaxTokensPerChar` | int | `5` | Divisor: character budget ÷ value = max_tokens. |
| `DeepSeek__SummarySafetyMarginChars` | int | `50` | Safety margin characters. |
| `DeepSeek__SummarySystemPromptTemplate` | string | *(see example)* | System prompt for summarisation. Supports `{MaxChars}`. |
| `DeepSeek__SummaryUserPromptTemplate` | string | *(see example)* | User prompt for summarisation. Supports `{Text}`. |
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
- Sender credentials live exclusively in Azure Key Vault and are never stored as environment variables or App Settings, in any environment.
- For CI/CD, store secrets as **GitHub Actions Secrets**; never embed them in workflow YAML files.
- In production, the Function App Managed Identity must be granted the **Key Vault Secrets User** role on the vault — no manual credential management is required.
