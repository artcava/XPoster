# Configuration Reference

All configuration is passed via environment variables — locally in `src/local.settings.json`, in production via Azure App Settings.

The file [`src/local.settings.json.example`](../src/local.settings.json.example) is the canonical starting template: copy it to `src/local.settings.json`, fill in the empty strings, and the function is ready to run locally.

> ⚠️ Sender credentials (Twitter/X, LinkedIn, Instagram) are **no longer configured via environment variables**. They are loaded from Azure Key Vault at application startup via the **Azure Key Vault Configuration Provider** (registered in `Program.cs`), and injected into senders through standard `IOptions` / `IConfiguration` binding. No runtime secret-fetch calls occur during post publishing. See the [Key Vault](#key-vault) section below.

---

## Quick-Start Checklist

For a minimal local setup with the default provider (`OpenAi`) you need at minimum:

- [ ] `AzureWebJobsStorage` — Azurite or a real Storage Account connection string
- [ ] `KEYVAULT_URI` — URI of the Azure Key Vault instance holding all sender credentials
- [ ] `OpenAI__ApiKey`
- [ ] `FeedOptions__Urls__0` — at least one RSS feed URL
- [ ] (Optional) `APPLICATIONINSIGHTS_CONNECTION_STRING` for local telemetry

For the `DeepSeek` provider (text-only — posts without image), replace the OpenAI block with:

- [ ] `DeepSeek__ApiKey`

For the `FalAi` provider (image-only — requires a slot orchestrator that handles null `textProvider`):

- [ ] `FalAi__ApiKey`

For the `DeepSeek` + `FalAi` combination (text from DeepSeek, image from FalAi), assign each to a separate slot in `DefaultSlotProfileProvider` with the respective `AiProvider` key, and supply both:

- [ ] `DeepSeek__ApiKey`
- [ ] `FalAi__ApiKey`

For the `Perplexity` provider (text-only — posts without image), replace the OpenAI block with:

- [ ] `Perplexity__ApiKey`

> 💡 For local development, run `az login` before starting the function. The Key Vault Configuration Provider uses `DefaultAzureCredential`, which picks up your Azure CLI session automatically and loads all secrets into `IConfiguration` at startup.

### 🧪 Quick-Start: DryRunSender (no social API credentials needed)

If you only want to verify the end-to-end pipeline locally **without publishing to any social platform**, you can use `DryRunSender`. This is the recommended first step for new contributors or when onboarding a new environment.

- [ ] `AzureWebJobsStorage` — `UseDevelopmentStorage=true` (Azurite)
- [ ] `KEYVAULT_URI` — Key Vault URI (needed for the Configuration Provider to load at startup)
- [ ] `OpenAI__ApiKey` — required if `AiProvider = OpenAi` (default)
- [ ] `FeedOptions__Urls__0` — at least one RSS feed URL
- [ ] `az login` executed in the terminal before `func start`
- [ ] `EnableDryRunSlot` set to `true` in `local.settings.json` (registers the dry-run slot via `DryRunSlotProfileProvider`)
- [ ] `ForceHour` set to `9` in `local.settings.json` (routes execution to the dry-run slot regardless of wall-clock time)
- [ ] **No** Twitter/X, LinkedIn, or Instagram secrets required in Key Vault (the provider loads only what is present)

> See the [DryRunSender — Local Testing](#dryrunsender--local-testing) section below for the full `local.settings.json` snippet and step-by-step instructions.

---

## Full `local.settings.json` Example

The file below mirrors [`src/local.settings.json.example`](../src/local.settings.json.example) exactly, with inline comments explaining every key.

```jsonc
{
  "IsEncrypted": false,
  "Values": {

    // ── Azure Functions Runtime ───────────────────────────────────────────────────────
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",

    // ── Scheduler ────────────────────────────────────────────────
    "CronSchedule": "0 0 6,8,14,16 * * *",
    "ForceHour": "",
    "EnableDryRunSlot": "false",

    // ── Feed URLs ────────────────────────────────────────────────
    "FeedOptions__Urls__0": "https://example.com/feed/rss",
    "FeedOptions__Urls__1": "https://another.example.com/rss",
    // Add additional entries as FeedOptions__Urls__2, __3, etc.
    // In Azure App Settings use the same flat key convention.
    // At least one URL is required for FeedOrchestrator to produce content.

    // ── Feed HTTP Client (resilience) ─────────────────────────────────────
    "FeedOptions__AttemptTimeoutSeconds": "10",
    "FeedOptions__RetryCount": "3",
    "FeedOptions__CircuitBreakerFailureThreshold": "0.5",
    "FeedOptions__CircuitBreakerSamplingDurationSeconds": "30",
    "FeedOptions__CircuitBreakerBreakDurationSeconds": "15",

    // ── Tag Replacements ─────────────────────────────────────────
    // Optional. Maps plain words in the AI summary to hashtag equivalents.
    // FeedOrchestrator replaces the first occurrence of each key (case-insensitive).
    // An absent or empty section is valid — summaries pass through unchanged.
    "TagReplacementOptions__Replacements__bitcoin": "#Bitcoin",
    "TagReplacementOptions__Replacements__btc": "#BTC",
    // Add further entries as TagReplacementOptions__Replacements__<word>.

    // ── AI Provider Selector ──────────────────────────────────────────
    "AiProvider": "OpenAi",

    // ── Key Vault ────────────────────────────────────────────────
    "KEYVAULT_URI": "https://<your-keyvault-name>.vault.azure.net/",

    // ══ AI — OpenAI (AiProvider = "OpenAi") ═════════════════════════════════════════════════
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

    // ══ AI — Azure AI Foundry (AiProvider = "AzureFoundry") ════════════════════════════════════
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

    // ══ AI — DeepSeek (AiProvider = "DeepSeek", text-only) ══════════════════════════════
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

    // ══ AI — fal.ai (AiProvider = "FalAi", image-only) ═══════════════════════════════
    "FalAi__ApiKey": "",
    "FalAi__ModelId": "fal-ai/flux/schnell",
    "FalAi__ImageSize": "landscape_4_3",
    "FalAi__NumInferenceSteps": "4",

    // ══ AI — Perplexity (AiProvider = "Perplexity", text-only) ═══════════════════════════
    "Perplexity__Endpoint": "https://api.perplexity.ai",
    "Perplexity__ApiKey": "",
    "Perplexity__DeploymentName": "sonar",
    "Perplexity__SummaryTemperature": "0.5",
    "Perplexity__SummaryMaxTokensPerChar": "5",
    "Perplexity__SummarySafetyMarginChars": "50",
    "Perplexity__SummarySystemPromptTemplate": "You are an assistant that summarizes text concisely. It's very important that you keep summaries under {MaxChars} characters.",
    "Perplexity__SummaryUserPromptTemplate": "Summarize this text in a few sentences. text: {Text}",
    "Perplexity__ImagePromptSystemTemplate": "You are an assistant that generates image prompts for an AI image generation model based on text summaries. Create a concise, vivid prompt in English that reflects the summary's content, includes a Bitcoin-related element (e.g., a coin), and avoids text, signs, or words in the image. Respect content policy for generating images.",
    "Perplexity__ImagePromptUserTemplate": "Generate an image prompt based on this summary: {Summary}",
    "Perplexity__ImagePromptMaxTokens": "60",
    "Perplexity__ImagePromptTemperature": "0.7",

    // ── Observability ────────────────────────────────────────────────
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

## Slot Profiles and Multi-Platform Fan-Out

Slot profiles are defined in `DefaultSlotProfileProvider` (production) and `DryRunSlotProfileProvider` (local dry-run). As of the fan-out feature (#176), each `ScheduledOrchestrationProfile` accepts an `IReadOnlyList<SenderPlatform>` instead of a single `SenderPlatform`.

### Ordering rule — descending `MessageMaxLength`

Senders within a slot **must be declared in descending `MessageMaxLength` order**. The first sender (index 0, widest limit) drives base summary and image generation. Subsequent senders receive an AI re-summarisation only when the base summary exceeds their character limit; otherwise the base summary is reused as-is, skipping the AI call entirely.

| Platform | `MessageMaxLength` | Role in a fan-out slot |
|---|---|---|
| LinkedIn | 700 | Primary — widest limit; base summary generated at this length |
| Instagram | 2 200 | Secondary — but image-first; in practice usually shorter captions |
| X (Twitter) | 280 | Typically last — always triggers re-summarisation when base > 280 |
| DryRun | 500 | Local testing only |

> 💡 **Cost implication:** a single fan-out slot with N senders replaces N separate scheduled slots. Base summary and image are generated once; only cheap per-sender re-summarisation AI calls are added when needed. See the [Token / Credit Savings](#token--credit-savings) section below.

### Production slot profile example

The current `DefaultSlotProfileProvider` defines the following slots:

```csharp
// src/Orchestrators/DefaultSlotProfileProvider.cs

new ScheduledOrchestrationProfile(
    hour: 8,
    senderPlatforms: new[] { SenderPlatform.LinkedIn, SenderPlatform.X, SenderPlatform.Instagram },
    orchestratorType: typeof(FeedOrchestrator),
    textProvider:  AiProvider.OpenAi,
    imageProvider: AiProvider.OpenAi),

new ScheduledOrchestrationProfile(
    hour: 14,
    senderPlatforms: new[] { SenderPlatform.LinkedIn },
    orchestratorType: typeof(PowerLawOrchestrator)),

new ScheduledOrchestrationProfile(
    hour: 16,
    senderPlatforms: new[] { SenderPlatform.X },
    orchestratorType: typeof(PowerLawOrchestrator)),
```

At hour 8 the orchestrator runs once, generates the base summary and image, then fans out to LinkedIn, X, and Instagram in parallel. The two PowerLaw slots (hours 14 and 16) each publish deterministic content to a single platform — no AI calls involved.

### DryRun slot profile example

`DryRunSlotProfileProvider` appends a single-sender slot at hour 9 for local testing:

```csharp
// src/Orchestrators/DryRunSlotProfileProvider.cs

new ScheduledOrchestrationProfile(
    hour: 9,
    senderPlatforms: new[] { SenderPlatform.DryRun },
    orchestratorType: typeof(FeedOrchestrator),
    textProvider:  AiProvider.OpenAi,
    imageProvider: AiProvider.OpenAi)
```

Even single-sender profiles use the list constructor — the fan-out loop iterates over one element and behaves identically to the old single-sender path.

---

## Token / Credit Savings

| Scenario | Full AI text pipelines | Image calls |
|---|---|---|
| Former approach (3 separate slots) | 3× full pipeline (feed fetch + summary + image prompt) | 3× |
| Fan-out slot (3 senders, 1 slot) | 1× full pipeline + up to 2× cheap re-summarisation | 1× |
| **Saving** | **~67 % fewer full AI pipelines** | **~67 % fewer image credits** |

Re-summarisation of an already-short base summary (e.g. ~700 chars → 280 chars) is significantly cheaper than re-processing the full feed content from scratch. When the base summary already fits within a secondary sender's character limit, the AI call is skipped entirely.

---

## Feed URLs

Feed URLs are resolved at runtime by `IFeedUrlProvider`. The default implementation, `ConfigurationFeedUrlProvider`, reads from the `FeedOptions` section bound via double-underscore notation.

`FeedService` fetches each URL using the named HTTP client `"Feed"` registered in `HttpClientExtensions.AddHttpClients()`. The client is configured with a Polly resilience pipeline (per-attempt timeout → exponential-backoff retry → circuit breaker) whose parameters are driven by the `FeedOptions` resilience keys documented in the [Feed HTTP Client](#feed-http-client) section below.

| Variable | Type | Required | Default | Description |
|---|---|---|---|---|
| `FeedOptions__Urls__0` | string | ✅ Yes (at least one) | — | First RSS/Atom feed URL consumed by `FeedOrchestrator`. |
| `FeedOptions__Urls__1` | string | No | — | Second feed URL. Add further entries as `__2`, `__3`, etc. |

**Behaviour when the list is empty:** `FeedOrchestrator.OrchestrateAsync()` returns an empty collection (with `SendIt = false`) and emits a `LogWarning`. No AI call or sender invocation is made.

**Azure App Settings:** use the same flat double-underscore convention — e.g. `FeedOptions__Urls__0` — exactly as shown. The .NET configuration binder maps sequential numeric suffixes to `List<string>` automatically.

**Extending the provider:** to load URLs from a different source (database, Key Vault, remote config), implement `IFeedUrlProvider` and register your implementation in `Program.cs` in place of `ConfigurationFeedUrlProvider`. See [`docs/extending-xposter.md`](extending-xposter.md) for the plugin convention.

---

## Feed HTTP Client

`FeedService` fetches RSS/Atom feeds via the named HTTP client `"Feed"`, registered in `HttpClientExtensions.AddHttpClients()` and protected by a Polly resilience pipeline composed of three layers (innermost to outermost):

1. **Attempt timeout** — cancels a single HTTP attempt if it exceeds `AttemptTimeoutSeconds`.
2. **Retry** — retries up to `RetryCount` times with exponential back-off on transient failures (network errors, 5xx, 429).
3. **Circuit breaker** — opens the circuit when the failure ratio over `CircuitBreakerSamplingDurationSeconds` exceeds `CircuitBreakerFailureThreshold`, and keeps it open for `CircuitBreakerBreakDurationSeconds` before allowing a probe request.

All five resilience settings are optional. When omitted the values shown in the **Default** column are used.

| Variable | Type | Required | Default | Description |
|---|---|---|---|---|
| `FeedOptions__AttemptTimeoutSeconds` | int | No | `10` | Per-attempt HTTP timeout in seconds. Applied before the retry layer. |
| `FeedOptions__RetryCount` | int | No | `3` | Maximum number of retry attempts on transient failures. Set to `0` to disable retries. |
| `FeedOptions__CircuitBreakerFailureThreshold` | double | No | `0.5` | Failure ratio (0.0–1.0) that triggers the circuit breaker within the sampling window. |
| `FeedOptions__CircuitBreakerSamplingDurationSeconds` | int | No | `30` | Sliding window duration in seconds over which the failure ratio is measured. |
| `FeedOptions__CircuitBreakerBreakDurationSeconds` | int | No | `15` | Duration in seconds the circuit stays open before allowing a single probe request. |

> **Tuning guidance:** For feeds served by CDNs or well-maintained public endpoints the defaults are appropriate. For slow or unreliable internal feeds, increase `AttemptTimeoutSeconds` and reduce `RetryCount` to avoid long tail latencies. For high-frequency schedules where a broken feed should not block the pipeline, lower `CircuitBreakerFailureThreshold` to trip the breaker faster.

---

## Tag Replacements

`FeedOrchestrator` applies a word-to-hashtag replacement pass on the AI-generated summary **independently per sender**, after each per-sender summary is finalised. Replacements are resolved at runtime by `ITagReplacementProvider`. The default implementation, `ConfigurationTagReplacementProvider`, reads from the `TagReplacementOptions:Replacements` section bound via double-underscore notation.

**Matching rules:**
- Only the **first occurrence** of each configured word per post is replaced.
- Matching is **case-insensitive** — the key `bitcoin` matches `Bitcoin`, `BITCOIN`, etc.
- The replacement value is used verbatim (e.g. `#Bitcoin` preserves the casing you configure).
- Keys from this map are also passed as keywords to `FeedService.GetFeedsAsync()` to pre-filter feed items that mention the configured topics.
- In a fan-out slot, hashtag substitution is applied **independently** on each sender's final raw summary — changes on one sender's content do not affect other senders.

| Variable | Type | Required | Default | Description |
|---|---|---|---|---|
| `TagReplacementOptions__Replacements__<word>` | string | No | — | Maps `<word>` to its hashtag replacement. E.g. `TagReplacementOptions__Replacements__bitcoin` = `#Bitcoin`. |

**Example — Azure App Settings (flat key notation):**

```
TagReplacementOptions__Replacements__bitcoin   →   #Bitcoin
TagReplacementOptions__Replacements__btc       →   #BTC
TagReplacementOptions__Replacements__fed       →   #FED
```

**Behaviour with an empty or absent section:** `ConfigurationTagReplacementProvider` returns an empty `IReadOnlyDictionary<string, string>`. `FeedOrchestrator` applies no replacements and passes the summary through unchanged. This is a valid configuration — no warning is emitted.

**Extending the provider:** to source replacements from a different store (database, remote config, Key Vault), implement `ITagReplacementProvider` and register the new implementation in `Program.cs` in place of `ConfigurationTagReplacementProvider`.

---

## AI Provider Selector

XPoster uses a **capability-based** AI provider model. Each `AiProvider` value is registered as a keyed service in the DI container, exposing one or both capability interfaces (`ITextToTextProvider`, `ITextToImageProvider`). `OrchestratorFactory` resolves both capabilities independently via `GetKeyedService<T>(profile.AiProvider)` — a `null` result means the capability is not available for that provider and the orchestrator degrades gracefully.

| Variable | Type | Required | Default | Description |
|---|---|---|---|---|
| `AiProvider` | string | No | `OpenAi` | Selects the AI provider for the global override slot. Per-slot provider is set in `DefaultSlotProfileProvider`. |

### Valid `AiProvider` values

| Value | `ITextToTextProvider` | `ITextToImageProvider` | Notes |
|---|---|---|---|
| `OpenAi` | ✅ | ✅ | Full text + image capabilities |
| `AzureFoundry` | ✅ | ✅ | Full text + image capabilities |
| `DeepSeek` | ✅ | ❌ | Text only — slots using this provider publish without image |
| `Perplexity` | ✅ | ❌ | Text only — slots using this provider publish without image |
| `FalAi` | ❌ | ✅ | Image only — only valid for orchestrators that handle null `textProvider` |
| `None` | ❌ | ❌ | No AI — reserved; do not use in production slots |

> **Removed value:** `DeepSeekWithFal` has been removed. Any slot profile previously referencing `AiProvider.DeepSeekWithFal` must be updated to `AiProvider.DeepSeek` (text) or `AiProvider.FalAi` (image) as appropriate.

### Invalid slot combinations

The following combinations will cause `FeedOrchestrator` to surface an explicit error at the point of use (not silently):

- Assigning `AiProvider.FalAi` to a slot whose orchestrator calls `ITextToTextProvider.GetSummaryAsync` — `textProvider` will be `null`
- Assigning `AiProvider.DeepSeek` or `AiProvider.Perplexity` to a slot that expects image output — `imageProvider` will be `null`; the post will be published without an image

---

## Key Vault

All sender OAuth credentials (Twitter/X, LinkedIn, Instagram) are loaded from Azure Key Vault **at application startup** via the [Azure Key Vault Configuration Provider](https://learn.microsoft.com/en-us/azure/key-vault/general/key-vault-integrate-kubernetes) registered in `Program.cs` (`builder.Configuration.AddAzureKeyVault(...)`). Secrets are merged into `IConfiguration` and injected into senders through standard `IOptions` / `IConfiguration` binding — no runtime Key Vault calls occur during post publishing.

| Variable | Type | Required | Description |
|---|---|---|---|
| `KEYVAULT_URI` | string | ✅ Yes | Full URI of the Azure Key Vault instance, e.g. `https://<vault-name>.vault.azure.net/`. |

### Authentication

The Configuration Provider uses `DefaultAzureCredential` from `Azure.Identity`:

| Environment | Credential used |
|---|---|
| Local development | Azure CLI session (`az login`) |
| Azure (production) | Function App Managed Identity |

### Required Secrets in Key Vault

> 🧪 **Using `DryRunSender`?** No social-platform secrets are required — only `KEYVAULT_URI` must be reachable so the Configuration Provider can start up successfully.

> ℹ️ **Secret names do not need to be renamed.** The Key Vault Configuration Provider maps secret names directly to `IConfiguration` keys using the Azure SDK's default name-to-key mapping (hyphens become double-underscores). The secret names listed below are the exact names already present in your Key Vault.

#### Twitter / X

| Secret name | Description |
|---|---|
| `XApiKey` | Twitter App API Key (Consumer Key). |
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

The dry-run slot uses `SenderPlatforms: new[] { SenderPlatform.DryRun }` — a single-element list that exercises the same fan-out loop as a production multi-platform slot.

### Step-by-step dry-run setup

1. **Authenticate with Azure CLI**
   ```bash
   az login
   ```

2. **Start Azurite**
   ```bash
   azurite --silent --location .azurite --debug .azurite/debug.log
   ```

3. **Copy and configure `local.settings.json`**
   ```bash
   cp src/local.settings.json.example src/local.settings.json
   ```
   Set `EnableDryRunSlot` to `"true"`, `ForceHour` to `"9"`, fill in `KEYVAULT_URI`, `OpenAI__ApiKey`, and at least one `FeedOptions__Urls__N`.

4. **Start the function**
   ```bash
   cd src && func start
   ```

5. **Observe the logs.** A successful dry run produces:
   ```
   [DryRunSender] Post content (743 chars): "Breaking: Bitcoin Power Law model signals..."
   [DryRunSender] Image attached: True
   [DryRunSender] Dry run complete — no post published.
   ```

6. **Cleanup** — ensure `EnableDryRunSlot` and `ForceHour` are not copied into `src/local.settings.json.example` or Azure App Settings.

---

## AI — OpenAI (`AiProvider = OpenAi`)

Configuration bound from the `OpenAI` prefix using double-underscore notation.

**Capabilities:** `ITextToTextProvider` ✅ · `ITextToImageProvider` ✅

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

**Capabilities:** `ITextToTextProvider` ✅ · `ITextToImageProvider` ✅

| Setting | Type | Required | Default | Description |
|---|---|---|---|---|
| `AzureFoundry__Endpoint` | string | ✅ Yes | — | Azure AI Foundry resource endpoint. |
| `AzureFoundry__ApiKey` | string | ✅ Yes* | — | Resource key. *Omit when using Managed Identity. |
| `AzureFoundry__DeploymentName` | string | ✅ Yes | — | Chat deployment name. |
| `AzureFoundry__ImageDeploymentName` | string | ✅ Yes | — | Image generation deployment name. |

Summarisation and image prompt tuning settings follow the same structure as the OpenAI block above, using the `AzureFoundry__` prefix.

---

## AI — DeepSeek (`AiProvider = DeepSeek`)

Configuration bound from the `DeepSeek` prefix using double-underscore notation.

**Capabilities:** `ITextToTextProvider` ✅ · `ITextToImageProvider` ❌ (text-only — slots using this provider publish without image)

| Setting | Type | Required | Default | Description |
|---|---|---|---|---|
| `DeepSeek__ApiKey` | string | ✅ Yes | — | DeepSeek platform API key. |
| `DeepSeek__Endpoint` | string | No | `https://api.deepseek.com` | DeepSeek API base URL. |
| `DeepSeek__DeploymentName` | string | No | `deepseek-chat` | Model identifier. |

Summarisation and image prompt tuning settings follow the same structure as the OpenAI block, using the `DeepSeek__` prefix.

> **Migration note:** `AiProvider.DeepSeekWithFal` has been removed. If you previously used `DeepSeekWithFal` to combine DeepSeek text with fal.ai image generation, assign `AiProvider.DeepSeek` to text slots and `AiProvider.FalAi` to image slots independently in `DefaultSlotProfileProvider`.

---

## AI — fal.ai (`AiProvider = FalAi`)

Configuration bound from the `FalAi` prefix using double-underscore notation.

**Capabilities:** `ITextToTextProvider` ❌ · `ITextToImageProvider` ✅ (image-only — only valid for orchestrators that handle null `textProvider`)

| Setting | Type | Required | Default | Description |
|---|---|---|---|---|
| `FalAi__ApiKey` | string | ✅ Yes | — | fal.ai API key. |
| `FalAi__ModelId` | string | No | `fal-ai/flux/schnell` | fal.ai model identifier. |
| `FalAi__ImageSize` | string | No | `landscape_4_3` | Image output size preset. |
| `FalAi__NumInferenceSteps` | int | No | `4` | Number of diffusion steps. |

---

## AI — Perplexity (`AiProvider = Perplexity`)

Configuration bound from the `Perplexity` prefix using double-underscore notation.

**Capabilities:** `ITextToTextProvider` ✅ · `ITextToImageProvider` ❌ (text-only — slots using this provider publish without image; `GenerateImageAsync` has been removed)

### Connection

| Setting | Type | Required | Default | Description |
|---|---|---|---|---|
| `Perplexity__ApiKey` | string | ✅ Yes | — | Perplexity platform API key. Obtain from [perplexity.ai/settings/api](https://www.perplexity.ai/settings/api). |
| `Perplexity__Endpoint` | string | No | `https://api.perplexity.ai` | Perplexity API base URL. |
| `Perplexity__DeploymentName` | string | No | `sonar` | Model identifier passed as `model` in each chat completions request. |

### Summarisation Tuning

| Setting | Type | Default | Description |
|---|---|---|---|
| `Perplexity__SummaryTemperature` | double | `0.5` | Temperature for summary generation. |
| `Perplexity__SummaryMaxTokensPerChar` | int | `5` | Divisor to convert a character budget to `max_tokens`. |
| `Perplexity__SummarySafetyMarginChars` | int | `50` | Character margin subtracted from the platform character limit. |
| `Perplexity__SummarySystemPromptTemplate` | string | *(see example)* | System prompt. Must contain `{MaxChars}`. |
| `Perplexity__SummaryUserPromptTemplate` | string | *(see example)* | User prompt. Must contain `{Text}`. |

### Image Prompt Tuning

| Setting | Type | Default | Description |
|---|---|---|---|
| `Perplexity__ImagePromptSystemTemplate` | string | *(see example)* | System prompt for image prompt generation. No required placeholders. |
| `Perplexity__ImagePromptUserTemplate` | string | *(see example)* | User prompt. Must contain `{Summary}`. |
| `Perplexity__ImagePromptMaxTokens` | int | `60` | Max tokens for image prompt generation. |
| `Perplexity__ImagePromptTemperature` | double | `0.7` | Temperature for image prompt generation. |

> See [docs/integrations/setup-perplexity.md](integrations/setup-perplexity.md) for the full setup guide.

---

## Observability

| Variable | Type | Required | Description |
|---|---|---|---|
| `APPLICATIONINSIGHTS_CONNECTION_STRING` | string | No | Application Insights connection string. When present, the isolated worker SDK automatically registers the telemetry pipeline. |
