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

### 🧪 Quick-Start: DryRunSender (no social API credentials needed)

If you only want to verify the end-to-end pipeline locally **without publishing to any social platform**, you can use `DryRunSender`. This is the recommended first step for new contributors or when onboarding a new environment.

- [ ] `AzureWebJobsStorage` — `UseDevelopmentStorage=true` (Azurite)
- [ ] `KEYVAULT_URI` — Key Vault URI (needed for the connectivity probe)
- [ ] `OpenAI__ApiKey` — required if `AiProvider = OpenAi` (default)
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
    // Use Azurite (local emulator) or a real Storage Account connection string.

    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    // Required by the .NET 8 isolated worker model. Do not change.

    // ── Scheduler ────────────────────────────────────────────
    "CronSchedule": "0 0 6,8,14,16 * * *",
    // 6-field NCRONTAB expression: {second} {minute} {hour} {day} {month} {dayOfWeek}
    // Default fires at 06:00, 08:00, 14:00, 16:00 every day.
    // Use "*/30 * * * * *" for rapid testing (every 30 seconds, dev/test only).

    "ForceHour": "",
    // When set, overrides the current UTC hour used by OrchestratorFactory.Resolve().
    // Use "9" locally together with EnableDryRunSlot = true to route to the dry-run slot.
    // Must NOT be set in production App Settings.

    "EnableDryRunSlot": "false",
    // When true, registers DryRunSlotProfileProvider (decorator over DefaultSlotProfileProvider)
    // which appends a dry-run slot at hour 9. Use together with ForceHour = "9" for local testing.
    // Must NOT be set to true in production App Settings.

    // ── AI Provider Selector ────────────────────────────────────────
    "AiProvider": "OpenAi",
    // Selects the IAiService implementation injected into AI-enabled orchestrators.
    // Supported values: OpenAi | AzureFoundry | DeepSeekWithFal

    // ── Key Vault ────────────────────────────────────────────
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
    //
    // DryRunSender only probes XApiKey to verify Key Vault connectivity.
    // No other secrets are required when using the dry-run slot.

    // ══ AI — OpenAI (AiProvider = "OpenAi") ═════════════════════════════════════════
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
| `ForceHour` | string | No | — | When set, overrides the current UTC hour used by `OrchestratorFactory.Resolve()`. Intended for local development only — set to `"9"` together with `EnableDryRunSlot = true` to force the dry-run slot. **Must not be set in production.** |
| `EnableDryRunSlot` | bool | No | `false` | When `true`, registers `DryRunSlotProfileProvider` as `ISlotProfileProvider`, which decorates `DefaultSlotProfileProvider` and appends a dry-run slot at hour 9. Use together with `ForceHour = "9"` for local pipeline testing. **Must not be `true` in production App Settings.** |

**Common expressions:**

| Expression | Fires at |
|---|-----------|
| `0 0 6,8,14,16 * * *` | 06:00, 08:00, 14:00, 16:00 every day (default) |
| `0 0 * * * *` | Every hour on the hour |
| `0 0 9,12,15,18 * * 1-5` | 09:00, 12:00, 15:00, 18:00 Mon–Fri |
| `*/30 * * * * *` | Every 30 seconds (dev/test only) |

> ⚠️ **`EnableDryRunSlot` and `ForceHour` are local-only settings.** Neither must appear in a production `CronSchedule` or Azure App Settings. The dry-run slot is added exclusively through `DryRunSlotProfileProvider`, which is only registered when `EnableDryRunSlot = true`.

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

> 🧪 **Using `DryRunSender`?** Only `XApiKey` is required in Key Vault — it is read as a connectivity probe to verify that your local `az login` session and Key Vault role assignment are working correctly. All other secrets listed below are **not** accessed during a dry run.

#### Twitter / X

| Secret name | Description |
|---|---|
| `XApiKey` | Twitter App API Key (Consumer Key). Obtain from [developer.twitter.com](https://developer.twitter.com) → Your App → Keys and Tokens. The app must have **Read and Write** permissions. Also used as Key Vault connectivity probe by `DryRunSender`. |
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

## DryRunSender — Local Testing

`DryRunSender` is a no-op `ISender` implementation designed for local end-to-end pipeline verification. It runs the full orchestration pipeline — AI content generation, RSS feed fetch, image generation — but **never publishes to any social platform**. Instead, it logs the generated post payload and probes Key Vault connectivity.

The dry-run slot is **not hardcoded** in `OrchestratorFactory`. It is appended by `DryRunSlotProfileProvider`, a decorator over `DefaultSlotProfileProvider` that is registered in `Program.cs` only when `EnableDryRunSlot = true` in app settings.

### What DryRunSender does

| Step | Behaviour |
|---|---|
| Null guard | Returns `false` and logs `Warning` if the incoming `Post` is `null` |
| Key Vault probe | Calls `GetSecretAsync("XApiKey")` to verify `az login` and Key Vault role assignment; returns `false` and logs `Error` on failure |
| Content logging | Logs character count, full post text, and whether an image is present |
| Return value | Returns `true` — no HTTP call to any social platform is made |
| `MessageMaxLength` | `int.MaxValue` — no content truncation applied |

### How the dry-run slot is activated

The dry-run slot at hour 9 is registered exclusively via DI, not via a hardcoded schedule entry:

```csharp
// Program.cs (simplified)
var enableDryRun = builder.Configuration.GetValue<bool>("EnableDryRunSlot", defaultValue: false);

if (enableDryRun)
    builder.Services.AddSingleton<ISlotProfileProvider>(sp =>
        new DryRunSlotProfileProvider(new DefaultSlotProfileProvider()));
else
    builder.Services.AddSingleton<ISlotProfileProvider, DefaultSlotProfileProvider>();
```

- When `EnableDryRunSlot = false` (default, production), only the four canonical slots (06:00, 08:00, 14:00, 16:00) are active.
- When `EnableDryRunSlot = true` (local only), the dry-run slot at hour 9 is appended. Use `ForceHour = "9"` to route any execution to it regardless of wall-clock time.

### Minimal `local.settings.json` for dry-run

The snippet below is the minimum configuration required to run a full dry-run pipeline execution locally. Only `XApiKey` needs to exist in Key Vault.

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    "CronSchedule": "*/30 * * * * *",
    "EnableDryRunSlot": "true",
    "ForceHour": "9",
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

**Key points:**
- `EnableDryRunSlot: "true"` registers `DryRunSlotProfileProvider`, which appends the dry-run slot at hour 9.
- `ForceHour: "9"` routes every execution to that slot, regardless of wall-clock time.
- `CronSchedule: "*/30 * * * * *"` triggers every 30 seconds so you can observe results quickly. Switch to a less aggressive schedule once verified.
- No Twitter/X, LinkedIn, or Instagram secrets are needed in Key Vault — only `XApiKey` must exist for the connectivity probe.

> ℹ️ `local.settings.json` is listed in `.gitignore` and is never committed to the repository. `EnableDryRunSlot` and `ForceHour` therefore carry no commit risk — they only need to be absent when copying values into `local.settings.json.example` or Azure App Settings.

### Step-by-step dry-run setup

1. **Authenticate with Azure CLI**
   ```bash
   az login
   ```
   Ensure the logged-in identity has the **Key Vault Secrets User** role on your vault.

2. **Add `XApiKey` to Key Vault** (if not already present)
   ```bash
   az keyvault secret set \
     --vault-name <your-keyvault-name> \
     --name XApiKey \
     --value "probe-value"
   ```
   The value itself is not used for publishing — any non-empty string is sufficient.

3. **Start Azurite** (Azure Storage emulator)
   ```bash
   azurite --silent --location .azurite --debug .azurite/debug.log
   ```

4. **Copy and configure `local.settings.json`**
   ```bash
   cp src/local.settings.json.example src/local.settings.json
   ```
   Then set `EnableDryRunSlot` to `"true"`, `ForceHour` to `"9"`, and fill in `KEYVAULT_URI` and `OpenAI__ApiKey`.

5. **Start the function**
   ```bash
   cd src && func start
   ```

6. **Observe the logs.** A successful dry run produces output similar to:
   ```
   [DryRunSender] Key Vault connectivity probe: OK (secret 'XApiKey' resolved)
   [DryRunSender] Post content (743 chars): "Breaking: Bitcoin Power Law model signals..."
   [DryRunSender] Image attached: True
   [DryRunSender] Dry run complete — no post published.
   ```

7. **Cleanup** — `local.settings.json` is gitignored and never committed. When you are done testing, remove `EnableDryRunSlot` and `ForceHour` (or set them to empty strings) to restore normal slot resolution. Ensure neither key is copied into:
   - `src/local.settings.json.example` (the committed template)
   - Azure App Settings of any non-local environment

### Switching AI provider for dry-run

To test with `DeepSeekWithFal` instead of OpenAI, change `AiProvider` and replace the OpenAI keys:

```json
"AiProvider": "DeepSeekWithFal",
"DeepSeek__ApiKey": "<your-deepseek-key>",
"FalAi__ApiKey": "<your-falai-key>"
```

All other dry-run settings (`EnableDryRunSlot`, `ForceHour`, `KEYVAULT_URI`, etc.) remain the same.

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
| `AzureFoundry__Endpoint` | string | ✅ Yes | — | Azure AI Foundry resource endpoint (e.g. `https://<resource>.services.ai.azure.com/openai/v1`). |
| `AzureFoundry__ApiKey` | string | ✅ Yes* | — | Azure AI Foundry resource key. *Omit when using Managed Identity. |
| `AzureFoundry__DeploymentName` | string | ✅ Yes | — | Chat deployment name as configured in Azure AI Foundry. |
| `AzureFoundry__ImageDeploymentName` | string | ✅ Yes | — | Image generation deployment name. |

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
- `EnableDryRunSlot` must never be `true` in production App Settings. Its presence would cause `DryRunSlotProfileProvider` to be registered, adding an unintended slot to the production schedule.
- `ForceHour` must never be set in production App Settings. Its presence in a production environment would cause every execution to resolve to the wrong orchestration slot.
- Neither `EnableDryRunSlot` nor `ForceHour` must appear in `src/local.settings.json.example` — the committed template must never carry development-only overrides.
