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
- [ ] `FeedOptions__Urls__0` — at least one RSS feed URL
- [ ] (Optional) `APPLICATIONINSIGHTS_CONNECTION_STRING` for local telemetry

For the `DeepSeekWithFal` provider (HybridAiService), replace the OpenAI block with:

- [ ] `DeepSeek__ApiKey`
- [ ] `FalAi__ApiKey`

> 💡 For local development, run `az login` before starting the function. `KeyVaultService` uses `DefaultAzureCredential`, which picks up your Azure CLI session automatically.

### 🧪 Quick-Start: DryRunSender (no social API credentials needed)

If you only want to verify the end-to-end pipeline locally **without publishing to any social platform**, you can use `DryRunSender`. This is the recommended first step for new contributors or when onboarding a new environment.

- [ ] `AzureWebJobsStorage` — `UseDevelopmentStorage=true` (Azurite)
- [ ] `KEYVAULT_URI` — Key Vault URI (needed for the connectivity probe)
- [ ] `OpenAI__ApiKey` — required if `AiProvider = OpenAi` (default)
- [ ] `FeedOptions__Urls__0` — at least one RSS feed URL
- [ ] `az login` executed in the terminal before `func start`
- [ ] `EnableDryRunSlot` set to `true` in `local.settings.json` (registers the dry-run slot via `DryRunSlotProfileProvider`)
- [ ] `ForceHour` set to `9` in `local.settings.json` (routes execution to the dry-run slot regardless of wall-clock time)
- [ ] **No** Twitter/X, LinkedIn, or Instagram secrets required

> See the [DryRunSender — Local Testing](#dryrunsender--local-testing) section below for the full `local.settings.json` snippet and step-by-step instructions.

---

## Full `local.settings.json` Example

The file below mirrors [`src/local.settings.json.example`](../src/local.settings.json.example) exactly, with inline comments explaining every key.

```jsonc
{
  "IsEncrypted": false,
  "Values": {

    // ── Azure Functions Runtime ─────────────────────────────────────────────
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",

    // ── Scheduler ────────────────────────────────────────────
    "CronSchedule": "0 0 6,8,14,16 * * *",
    "ForceHour": "",
    "EnableDryRunSlot": "false",

    // ── Feed URLs ────────────────────────────────────────────
    "FeedOptions__Urls__0": "https://example.com/feed/rss",
    "FeedOptions__Urls__1": "https://another.example.com/rss",
    // Add additional entries as FeedOptions__Urls__2, __3, etc.
    // In Azure App Settings use the same flat key convention.
    // At least one URL is required for FeedOrchestrator to produce content.

    // ── AI Provider Selector ────────────────────────────────────────
    "AiProvider": "OpenAi",

    // ── Key Vault ────────────────────────────────────────────
    "KEYVAULT_URI": "https://<your-keyvault-name>.vault.azure.net/",

    // ══ AI — OpenAI (AiProvider = "OpenAi") ═════════════════════════════════════════
    "OpenAI__ApiKey": "",
    "OpenAI__ChatEndpoint": "https://api.openai.com/v1/chat/completions",
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

    // ══ AI — Azure AI Foundry (AiProvider = "AzureFoundry") ══════════════════════
    "AzureFoundry__Endpoint": "",
    "AzureFoundry__ApiKey": "",
    "AzureFoundry__DeploymentName": "",
    "AzureFoundry__ImageDeploymentName": "",
    "AzureFoundry__SummaryTemperature": "0.5",
    "AzureFoundry__SummaryMaxTokensPerChar": "5",
    "AzureFoundry__SummarySafetyMarginChars": "50",
    "AzureFoundry__SummarySystemPromptTemplate": "You are an assistant that summarizes text concisely. It's very important that you keep summaries under {MaxChars} characters.",
    "AzureFoundry__SummaryUserPromptTemplate": "Summarize this text in a few sentences. text: {Text}",
    "AzureFoundry__ImagePromptSystemTemplate": "You are an assistant that generates image prompts for an AI image generation model based on text summaries. Create a concise, vivid prompt in English that reflects the summary's content, includes a Bitcoin-related element (e.g., a coin), and avoids text, signs, or words in the image. Respect content policy for generating images.",
    "AzureFoundry__ImagePromptUserTemplate": "Generate an image prompt based on this summary: {Summary}",
    "AzureFoundry__ImagePromptMaxTokens": "60",
    "AzureFoundry__ImagePromptTemperature": "0.7",

    // ══ AI — DeepSeek (AiProvider = "DeepSeekWithFal", text half) ══════════════════
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

    // ══ AI — fal.ai (AiProvider = "DeepSeekWithFal", image half) ═════════════════
    "FalAi__ApiKey": "",
    "FalAi__ModelId": "fal-ai/flux/schnell",
    "FalAi__ImageSize": "landscape_4_3",
    "FalAi__NumInferenceSteps": "4",

    // ── Observability ────────────────────────────────────────────
    "APPLICATIONINSIGHTS_CONNECTION_STRING": ""
  }
}
```

> **Note on `jsonc`:** `local.settings.json` does **not** support inline comments at runtime. The `jsonc`-annotated block above is for documentation only. The actual [`src/local.settings.json.example`](../src/local.settings.json.example) file uses plain JSON with empty-string placeholders.

---

## Azure Functions Runtime

| Variable | Type | Required | Default | Description |
|---|---|---|---|---|
| `AzureWebJobsStorage` | string | ✅ Yes | `UseDevelopmentStorage=true` | Storage connection string. |
| `FUNCTIONS_WORKER_RUNTIME` | string | ✅ Yes | `dotnet-isolated` | Must be `dotnet-isolated` for .NET 8 isolated worker. Do not change. |

---

## Scheduler

| Variable | Type | Required | Default | Description |
|---|---|---|---|---|
| `CronSchedule` | string | ✅ Yes | `0 0 6,8,14,16 * * *` | 6-field NCRONTAB expression controlling execution frequency. |
| `ForceHour` | string | No | — | Overrides the current UTC hour used by `OrchestratorFactory.Resolve()`. Local development only. |
| `EnableDryRunSlot` | bool | No | `false` | When `true`, registers `DryRunSlotProfileProvider` appending a dry-run slot at hour 9. **Must not be `true` in production.** |

---

## Feed URLs

Feed URLs are resolved at runtime by `IFeedUrlProvider`. The default implementation, `ConfigurationFeedUrlProvider`, reads from the `FeedOptions` section bound via double-underscore notation.

| Variable | Type | Required | Default | Description |
|---|---|---|---|---|
| `FeedOptions__Urls__0` | string | ✅ Yes (at least one) | — | First RSS/Atom feed URL consumed by `FeedOrchestrator`. |
| `FeedOptions__Urls__1` | string | No | — | Second feed URL. Add further entries as `__2`, `__3`, etc. |

**Behaviour when the list is empty:** `FeedOrchestrator.OrchestrateAsync()` returns `null` (with `SendIt = false`) and emits a `LogWarning`. No AI call or sender invocation is made.

**Azure App Settings:** use the same flat double-underscore convention — e.g. `FeedOptions__Urls__0` — exactly as shown. The .NET configuration binder maps sequential numeric suffixes to `List<string>` automatically.

**Extending the provider:** to load URLs from a different source (database, Key Vault, remote config), implement `IFeedUrlProvider` and register your implementation in `Program.cs` in place of `ConfigurationFeedUrlProvider`. See [`docs/extending-xposter.md`](extending-xposter.md) for the plugin convention.

---

## AI Provider Selector

| Variable | Type | Required | Default | Description |
|---|---|---|---|---|
| `AiProvider` | string | No | `OpenAi` | Selects the `IAiService` implementation. Supported values: `OpenAi`, `AzureFoundry`, `DeepSeekWithFal`. |

---

## Key Vault

All sender OAuth credentials (Twitter/X, LinkedIn, Instagram) are resolved at runtime by `KeyVaultService` directly from Azure Key Vault.

| Variable | Type | Required | Description |
|---|---|---|---|
| `KEYVAULT_URI` | string | ✅ Yes | Full URI of the Azure Key Vault instance, e.g. `https://<vault-name>.vault.azure.net/`. |

### Authentication

`KeyVaultService` uses `DefaultAzureCredential` from `Azure.Identity`:

| Environment | Credential used |
|---|---|
| Local development | Azure CLI session (`az login`) |
| Azure (production) | Function App Managed Identity |

### Required Secrets in Key Vault

> 🧪 **Using `DryRunSender`?** Only `XApiKey` is required — it is read as a connectivity probe.

#### Twitter / X

| Secret name | Description |
|---|---|
| `XApiKey` | Twitter App API Key (Consumer Key). Also used as Key Vault connectivity probe by `DryRunSender`. |
| `XApiSecret` | Twitter App API Secret (Consumer Secret). |
| `XAccessToken` | User Access Token (OAuth 1.0a). |
| `XAccessTokenSecret` | User Access Token Secret (OAuth 1.0a). |

#### LinkedIn

| Secret name | Required | Description |
|---|---|---|
| `LinkedInAccessToken` | ✅ Yes | LinkedIn OAuth 2.0 access token. **Expires every 60 days** — manual rotation currently required. |
| `LinkedInOwnerCode` | ⚠️ One of these | Numeric LinkedIn person ID. |
| `LinkedInOrgId` | ⚠️ One of these | Numeric LinkedIn organization ID. Takes precedence over `LinkedInOwnerCode` when set. |

#### Instagram

> ⚠️ Instagram publishing is **not yet active in production**. See issue [#72](https://github.com/artcava/XPoster/issues/72).

| Secret name | Description |
|---|---|
| `IgAccessToken` | Long-lived Instagram Graph API access token. |
| `IgAccountId` | Numeric Instagram Business Account ID. |

---

## DryRunSender — Local Testing

`DryRunSender` is a no-op `ISender` implementation for local end-to-end pipeline verification. It runs the full orchestration — AI content generation, RSS feed fetch, image generation — but **never publishes to any social platform**.

### Minimal `local.settings.json` for dry-run

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    "CronSchedule": "*/30 * * * * *",
    "EnableDryRunSlot": "true",
    "ForceHour": "9",
    "FeedOptions__Urls__0": "https://example.com/feed/rss",
    "AiProvider": "OpenAi",
    "KEYVAULT_URI": "https://<your-keyvault-name>.vault.azure.net/",
    "OpenAI__ApiKey": "<your-openai-key>",
    "OpenAI__ChatEndpoint": "https://api.openai.com/v1/chat/completions",
    "OpenAI__ChatModel": "gpt-4.1-nano",
    "OpenAI__ImageEndpoint": "https://api.openai.com/v1/images/generations",
    "OpenAI__ImageModel": "gpt-image-1.5",
    "OpenAI__ImageSize": "1024x1024",
    "OpenAI__ImageCount": "1"
  }
}
```

### Step-by-step dry-run setup

1. **Authenticate with Azure CLI**
   ```bash
   az login
   ```

2. **Add `XApiKey` to Key Vault** (if not already present)
   ```bash
   az keyvault secret set \
     --vault-name <your-keyvault-name> \
     --name XApiKey \
     --value "probe-value"
   ```

3. **Start Azurite**
   ```bash
   azurite --silent --location .azurite --debug .azurite/debug.log
   ```

4. **Copy and configure `local.settings.json`**
   ```bash
   cp src/local.settings.json.example src/local.settings.json
   ```
   Set `EnableDryRunSlot` to `"true"`, `ForceHour` to `"9"`, fill in `KEYVAULT_URI`, `OpenAI__ApiKey`, and at least one `FeedOptions__Urls__N`.

5. **Start the function**
   ```bash
   cd src && func start
   ```

6. **Observe the logs.** A successful dry run produces:
   ```
   [DryRunSender] Key Vault connectivity probe: OK (secret 'XApiKey' resolved)
   [DryRunSender] Post content (743 chars): "Breaking: Bitcoin Power Law model signals..."
   [DryRunSender] Image attached: True
   [DryRunSender] Dry run complete — no post published.
   ```

7. **Cleanup** — ensure `EnableDryRunSlot` and `ForceHour` are not copied into `src/local.settings.json.example` or Azure App Settings.

---

## AI — OpenAI (`AiProvider = OpenAi`)

Configuration bound from the `OpenAI` prefix using double-underscore notation.

### Connection

| Setting | Type | Required | Default | Description |
|---|---|---|---|---|
| `OpenAI__ApiKey` | string | ✅ Yes | — | OpenAI platform API key. |
| `OpenAI__ChatEndpoint` | string | No | `https://api.openai.com/v1/chat/completions` | Chat Completions API URL. |
| `OpenAI__ChatModel` | string | No | `gpt-4.1-nano` | Model used for text summarisation and image prompt generation. |
| `OpenAI__ImageEndpoint` | string | No | `https://api.openai.com/v1/images/generations` | Image Generations API URL. |
| `OpenAI__ImageModel` | string | No | `gpt-image-1.5` | Model used for image generation. |
| `OpenAI__ImageSize` | string | No | `1024x1024` | Output image dimensions. |
| `OpenAI__ImageCount` | int | No | `1` | Number of images to generate per request. |

### Summarisation Tuning

| Setting | Type | Default | Description |
|---|---|---|---|
| `OpenAI__SummaryTemperature` | double | `0.5` | Temperature for summary generation. |
| `OpenAI__SummaryMaxTokensPerChar` | int | `5` | Divisor to convert a character budget to `max_tokens`. |
| `OpenAI__SummarySafetyMarginChars` | int | `50` | Character margin subtracted from the platform character limit. |
| `OpenAI__SummarySystemPromptTemplate` | string | *(see example)* | System prompt. Supports `{MaxChars}`. |
| `OpenAI__SummaryUserPromptTemplate` | string | *(see example)* | User prompt. Supports `{Text}`. |

### Image Prompt Tuning

| Setting | Type | Default | Description |
|---|---|---|---|
| `OpenAI__ImagePromptSystemTemplate` | string | *(see example)* | System prompt for image prompt generation. |
| `OpenAI__ImagePromptUserTemplate` | string | *(see example)* | User prompt. Supports `{Summary}`. |
| `OpenAI__ImagePromptMaxTokens` | int | `60` | Max tokens for image prompt generation. |
| `OpenAI__ImagePromptTemperature` | double | `0.7` | Temperature for image prompt generation. |

---

## AI — Azure AI Foundry (`AiProvider = AzureFoundry`)

Configuration bound from the `AzureFoundry` prefix.

| Setting | Type | Required | Default | Description |
|---|---|---|---|---|
| `AzureFoundry__Endpoint` | string | ✅ Yes | — | Azure AI Foundry resource endpoint. |
| `AzureFoundry__ApiKey` | string | ✅ Yes* | — | Resource key. *Omit when using Managed Identity. |
| `AzureFoundry__DeploymentName` | string | ✅ Yes | — | Chat deployment name. |
| `AzureFoundry__ImageDeploymentName` | string | ✅ Yes | — | Image generation deployment name. |

Summarisation and image prompt tuning settings follow the same structure as the OpenAI block above, using the `AzureFoundry__` prefix.

---

## AI — DeepSeek + fal.ai (`AiProvider = DeepSeekWithFal`)

### DeepSeek (text half)

| Setting | Type | Required | Default | Description |
|---|---|---|---|---|
| `DeepSeek__ApiKey` | string | ✅ Yes | — | DeepSeek platform API key. |
| `DeepSeek__Endpoint` | string | No | `https://api.deepseek.com` | DeepSeek API base URL. |
| `DeepSeek__DeploymentName` | string | No | `deepseek-chat` | Model identifier. |

Summarisation and image prompt tuning settings follow the same structure as the OpenAI block, using the `DeepSeek__` prefix.

### fal.ai (image half)

| Setting | Type | Required | Default | Description |
|---|---|---|---|---|
| `FalAi__ApiKey` | string | ✅ Yes | — | fal.ai API key. |
| `FalAi__ModelId` | string | No | `fal-ai/flux/schnell` | fal.ai model identifier. |
| `FalAi__ImageSize` | string | No | `landscape_4_3` | Image output size preset. |
| `FalAi__NumInferenceSteps` | int | No | `4` | Number of diffusion steps. |

---

## Observability

| Variable | Type | Required | Description |
|---|---|---|---|
| `APPLICATIONINSIGHTS_CONNECTION_STRING` | string | No | Application Insights connection string. When present, the isolated worker SDK automatically registers the telemetry pipeline. |
