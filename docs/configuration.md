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
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    "CronSchedule": "0 0 6,8,14,16 * * *",
    "ContainerPollingSchedule": "0 */2 * * * *",
    "AiProvider": "OpenAi",

    // -----------------------------------------------------------------------
    // Local development slot override.
    // Set to a UTC hour (0-23) matching an entry in DefaultSlotProfileProvider
    // to force that orchestrator slot without waiting for the real clock.
    // Examples:
    //   "ForceHour": "6"   → InSummaryFeed / FeedOrchestrator
    //   "ForceHour": "8"   → XSummaryFeed  / FeedOrchestrator
    //   "ForceHour": "14"  → InPowerLaw    / PowerLawOrchestrator
    //   "ForceHour": "16"  → XPowerLaw     / PowerLawOrchestrator
    // Remove or leave empty to use the real UTC clock (production behaviour).
    // -----------------------------------------------------------------------
    "ForceHour": "",

    // -----------------------------------------------------------------------
    // Dry-run testing (local integration testing without social platform publishing).
    //
    // To test the full pipeline — including Key Vault connectivity and AI provider
    // output — without posting to X/Twitter, LinkedIn, or Instagram:
    //
    //   1. Set "EnableDryRunSlot": "true"  → registers DryRunSlotProfileProvider,
    //      which appends a DryRunSend entry at hour 9 to the production schedule.
    //   2. Set "ForceHour": "9"            → forces the clock to hour 9 so the
    //      dry-run slot is selected at startup.
    //   3. Set "AiProvider" to the provider under test: "OpenAi", "AzureFoundry",
    //      "DeepSeekWithFal", or "Perplexity".
    //   4. Ensure KEYVAULT_URI is set and `az login` has been run.
    //   5. Run the function — orchestration executes normally but no post is published.
    //
    // The DryRunSender will:
    //   - Probe configuration by checking that "XApiKey" is non-empty
    //     (verifies that AddAzureKeyVault loaded secrets successfully)
    //   - Log the post content (character count + full text) and image presence
    //   - Return true without calling any social platform API
    //
    // NOTE: EnableDryRunSlot defaults to false. In production this key must be
    // absent or set to "false" — no code changes or comments required.
    // -----------------------------------------------------------------------
    "EnableDryRunSlot": "false",

    // -----------------------------------------------------------------------
    // Azure Key Vault — all sender credentials are loaded via the
    // AddAzureKeyVault Configuration Provider registered in Program.cs.
    //
    // Local development:
    //   1. Run `az login` (or set AZURE_CLIENT_ID / AZURE_CLIENT_SECRET for
    //      a service principal) so DefaultAzureCredential can authenticate.
    //   2. Set KEYVAULT_URI to your vault URI below.
    //   Secrets are read automatically at startup and bound to typed IOptions<T>.
    //
    // Azure deployment: Managed Identity handles authentication automatically.
    //
    // Required secrets in Key Vault (exact casing, matched to Options properties):
    //   LinkedInAccessToken   — LinkedIn Bearer token         → LinkedInCredentials.LinkedInAccessToken
    //   LinkedInOwnerCode     — LinkedIn person/owner ID      → LinkedInCredentials.LinkedInOwnerCode
    //   LinkedInOrgId         — LinkedIn organization ID      → LinkedInCredentials.LinkedInOrgId (optional; org posts)
    //   XApiKey               — X (Twitter) API key           → XCredentials.XApiKey
    //   XApiSecret            — X (Twitter) API secret        → XCredentials.XApiSecret
    //   XAccessToken          — X (Twitter) access token      → XCredentials.XAccessToken
    //   XAccessTokenSecret    — X (Twitter) access token sec  → XCredentials.XAccessTokenSecret
    //   InstagramAccessToken  — Instagram Graph API token     → InstagramCredentials.InstagramAccessToken
    //   InstagramAccountId    — Instagram account ID          → InstagramCredentials.InstagramAccountId
    //   FacebookAccessToken   — Facebook Graph API token      → FacebookCredentials.FacebookAccessToken
    //   FacebookAccountId     — Facebook account ID           → FacebookCredentials.FacebookPageId
    // -----------------------------------------------------------------------
    "KEYVAULT_URI": "https://<your-keyvault-name>.vault.azure.net/",

    // -----------------------------------------------------------------------
    // ── Azure Blob Storage & Instagram Polling ──
    // -----------------------------------------------------------------------
    "AZURE_STORAGE_CONNECTION_STRING": "UseDevelopmentStorage=true",
    "AZURE_STORAGE_CONTAINER_NAME": "xposter-images",

    // -----------------------------------------------------------------------
    // AI Provider — connectivity and model capability settings only.
    // Prompt templates and intent are now owned by each orchestrator slot
    // via FeedSlotContexts (see below). Only keep here what the provider
    // needs to make the HTTP call: endpoint, credentials, model name,
    // and token-budget helpers that are provider-specific.
    // -----------------------------------------------------------------------

    "OpenAI__Endpoint": "https://api.openai.com/v1/",
    "OpenAI__ApiKey": "",
    "OpenAI__TextModelName": "gpt-4.1-nano",
    "OpenAI__ImageModelName": "gpt-image-1.5",

    "AzureFoundry__Endpoint": "",
    "AzureFoundry__ApiKey": "",
    "AzureFoundry__TextModelName": "",
    "AzureFoundry__ImageModelName": "",

    "DeepSeek__Endpoint": "https://api.deepseek.com",
    "DeepSeek__ApiKey": "",
    "DeepSeek__TextModelName": "deepseek-chat",

    "Perplexity__Endpoint": "https://api.perplexity.ai",
    "Perplexity__ApiKey": "",
    "Perplexity__TextModelName": "sonar",

    "FalAi__Endpoint": "https://fal.run",
    "FalAi__ApiKey": "",
    "FalAi__ImageModelName": "fal-ai/flux/schnell",
    "FalAi__NumInferenceSteps": "4",

    // -----------------------------------------------------------------------
    // Feed slot contexts — per-slot configuration for FeedOrchestrator.
    //
    // Each named key (Feed06, Feed08, …) maps to a FeedOrchestratorContext
    // carrying the feed URLs and the ordered prompt steps for that slot.
    // The key is referenced via OrchestratorContextKey in the corresponding
    // ScheduledOrchestrationProfile entry.
    //
    // Steps array maps each PromptRole to its own settings block:
    //   Steps__0  → Role = Summary               (text-to-text)
    //   Steps__1  → Role = ImagePromptDerivation  (text-to-text)
    //   Steps__2  → Role = ImageGeneration        (text-to-image)
    //
    // Note: MaxOutputLength for the Summary role is NOT set here — it is
    // resolved at runtime from ISender.MessageMaxLength of the target sender.
    // -----------------------------------------------------------------------

    // -- Slot Feed06 (06:00 UTC) -------------------------------------------
    "FeedSlotContexts__Feed06__FeedUrls__0": "https://cointelegraph.com/rss/tag/bitcoin",
    "FeedSlotContexts__Feed06__FeedUrls__1": "https://www.coindesk.com/arc/outboundfeeds/rss",

    "FeedSlotContexts__Feed06__PromptOptions__Steps__0__Role": "Summary",
    "FeedSlotContexts__Feed06__PromptOptions__Steps__0__SystemPromptTemplate": "You are an assistant that summarizes text concisely. It's very important that you keep summaries under {MaxChars} characters.",
    "FeedSlotContexts__Feed06__PromptOptions__Steps__0__UserPromptTemplate": "Summarize this text in a few sentences. text: {Text}",
    "FeedSlotContexts__Feed06__PromptOptions__Steps__0__Temperature": "0.5",
    "FeedSlotContexts__Feed06__PromptOptions__Steps__0__MaxTokenBudget": "600",
    "FeedSlotContexts__Feed06__PromptOptions__Steps__0__InputTextLabel": "{Text}",

    "FeedSlotContexts__Feed06__PromptOptions__Steps__1__Role": "ImagePromptDerivation",
    "FeedSlotContexts__Feed06__PromptOptions__Steps__1__SystemPromptTemplate": "You are an assistant that generates image prompts for an AI image generation model based on text summaries. Create a concise, vivid prompt in English that reflects the summary's content, includes a Bitcoin-related element (e.g., a coin), and avoids text, signs, or words in the image. Respect content policy for generating images.",
    "FeedSlotContexts__Feed06__PromptOptions__Steps__1__UserPromptTemplate": "Generate an image prompt based on this summary: {Summary}",
    "FeedSlotContexts__Feed06__PromptOptions__Steps__1__Temperature": "0.7",
    "FeedSlotContexts__Feed06__PromptOptions__Steps__1__MaxTokenBudget": "300",
    "FeedSlotContexts__Feed06__PromptOptions__Steps__1__InputTextLabel": "{Summary}",

    "FeedSlotContexts__Feed06__PromptOptions__Steps__2__Role": "ImageGeneration",
    "FeedSlotContexts__Feed06__PromptOptions__Steps__2__SystemPromptTemplate": "",
    "FeedSlotContexts__Feed06__PromptOptions__Steps__2__UserPromptTemplate": "{Text}",
    "FeedSlotContexts__Feed06__PromptOptions__Steps__2__ImageQuantity": "1",
    "FeedSlotContexts__Feed06__PromptOptions__Steps__2__ImageSize": "1024x1024",
    "FeedSlotContexts__Feed06__PromptOptions__Steps__2__InputTextLabel": "{Text}",

    // -- Slot Feed08 (08:00 UTC) -------------------------------------------
    "FeedSlotContexts__Feed08__FeedUrls__0": "https://cointelegraph.com/rss/tag/bitcoin",
    "FeedSlotContexts__Feed08__FeedUrls__1": "https://www.coindesk.com/arc/outboundfeeds/rss",

    "FeedSlotContexts__Feed08__PromptOptions__Steps__0__Role": "Summary",
    "FeedSlotContexts__Feed08__PromptOptions__Steps__0__SystemPromptTemplate": "You are an assistant that summarizes text concisely. It's very important that you keep summaries under {MaxChars} characters.",
    "FeedSlotContexts__Feed08__PromptOptions__Steps__0__UserPromptTemplate": "Summarize this text in a few sentences. text: {Text}",
    "FeedSlotContexts__Feed08__PromptOptions__Steps__0__Temperature": "0.5",
    "FeedSlotContexts__Feed08__PromptOptions__Steps__0__MaxTokenBudget": "600",
    "FeedSlotContexts__Feed08__PromptOptions__Steps__0__InputTextLabel": "{Text}",

    "FeedSlotContexts__Feed08__PromptOptions__Steps__1__Role": "ImagePromptDerivation",
    "FeedSlotContexts__Feed08__PromptOptions__Steps__1__SystemPromptTemplate": "You are an assistant that generates image prompts for an AI image generation model based on text summaries. Create a concise, vivid prompt in English that reflects the summary's content, includes a Bitcoin-related element (e.g., a coin), and avoids text, signs, or words in the image. Respect content policy for generating images.",
    "FeedSlotContexts__Feed08__PromptOptions__Steps__1__UserPromptTemplate": "Generate an image prompt based on this summary: {Summary}",
    "FeedSlotContexts__Feed08__PromptOptions__Steps__1__Temperature": "0.7",
    "FeedSlotContexts__Feed08__PromptOptions__Steps__1__MaxTokenBudget": "300",
    "FeedSlotContexts__Feed08__PromptOptions__Steps__1__InputTextLabel": "{Summary}",

    "FeedSlotContexts__Feed08__PromptOptions__Steps__2__Role": "ImageGeneration",
    "FeedSlotContexts__Feed08__PromptOptions__Steps__2__SystemPromptTemplate": "",
    "FeedSlotContexts__Feed08__PromptOptions__Steps__2__UserPromptTemplate": "{Text}",
    "FeedSlotContexts__Feed08__PromptOptions__Steps__2__ImageQuantity": "1",
    "FeedSlotContexts__Feed08__PromptOptions__Steps__2__ImageSize": "1024x1024",
    "FeedSlotContexts__Feed08__PromptOptions__Steps__2__InputTextLabel": "{Text}",

    // -----------------------------------------------------------------------
    // Tag replacement provider — word-to-hashtag map applied to generated summaries.
    // Uses flat Azure Functions naming convention: TagReplacementOptions__Replacements__<word>.
    // Keys are matched case-insensitively; only the first occurrence per word is replaced.
    // Add or remove entries freely without code changes or redeployment.
    // -----------------------------------------------------------------------
    "TagReplacementOptions__Replacements__bitcoin": "#Bitcoin",
    "TagReplacementOptions__Replacements__btc": "#BTC",
    "TagReplacementOptions__Replacements__blockchain": "#Blockchain",
    "TagReplacementOptions__Replacements__fed": "#FED",

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

### Sender ordering in fan-out slots

`FeedOrchestrator` re-orders senders internally by descending `MessageMaxLength` at runtime before producing per-sender content. The declaration order within `senderPlatforms` in a `ScheduledOrchestrationProfile` does not affect fan-out execution — the orchestrator always selects the widest sender as primary, regardless of how platforms are listed in the profile.

| Platform | `MessageMaxLength` | Role in a fan-out slot |
|---|---|---|
| Facebook | 3 000 | Widest limit — selected as primary by `FeedOrchestrator`; base summary generated at this length |
| LinkedIn | 2 800 | Secondary — re-summarisation triggered only when base summary exceeds 2 800 chars |
| Instagram | 2 200 | Tertiary — re-summarisation triggered only when base summary exceeds 2 200 chars |
| X (Twitter) | 250 | Narrowest — always triggers re-summarisation when base summary exceeds 250 chars |
| DryRun | `int.MaxValue` | Local testing only — always selected as primary when present |

> 💡 **Cost implication:** a single fan-out slot with N senders replaces N separate scheduled slots. Base summary and image are generated once; only cheap per-sender re-summarisation AI calls are added when needed. See the [Token / Credit Savings](#token--credit-savings) section below.

### Production slot profile example

The current `DefaultSlotProfileProvider` defines the following slots:

```csharp
// src/Orchestrators/DefaultSlotProfileProvider.cs

new ScheduledOrchestrationProfile(
    hour: 6,
    senderPlatforms: new[] { SenderPlatform.LinkedIn, SenderPlatform.X, SenderPlatform.Instagram, SenderPlatform.Facebook },
    orchestratorType: typeof(FeedOrchestrator),
    textProvider:  AiProvider.OpenAi,
    imageProvider: AiProvider.AzureFoundry),

new ScheduledOrchestrationProfile(
    hour: 14,
    senderPlatforms: new[] { SenderPlatform.LinkedIn, SenderPlatform.X },
    orchestratorType: typeof(PowerLawOrchestrator)),
```

At hour 6 the orchestrator runs once, generates the base summary and image, then fans out to LinkedIn, X, Instagram, and Facebook in parallel. The PowerLaw slot at hour 14 publish deterministic content to platforms — no AI calls involved.

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

When the base summary already fits within a secondary sender's character limit, the AI call is skipped entirely.

---

## Feed Slot Contexts

Each `FeedOrchestrator` slot carries its own URL list and ordered prompt pipeline, bound via `FeedSlotContexts` using double-underscore flat key notation. The context key (e.g. `Feed06`, `Feed08`) must match the `OrchestratorContextKey` defined in the corresponding `ScheduledOrchestrationProfile`.

### Configuration structure

```jsonc
FeedSlotContexts__<ContextKey>_FeedUrls_0 → first RSS feed URL for this slot
FeedSlotContexts__<ContextKey>_FeedUrls_1 → second RSS feed URL (optional)
FeedSlotContexts__<ContextKey>_PromptOptions_Steps__N__Role
FeedSlotContexts__<ContextKey>_PromptOptions_Steps__N__SystemPromptTemplate
FeedSlotContexts__<ContextKey>_PromptOptions_Steps__N__UserPromptTemplate
FeedSlotContexts__<ContextKey>_PromptOptions_Steps__N__Temperature
FeedSlotContexts__<ContextKey>_PromptOptions_Steps__N__MaxTokenBudget
FeedSlotContexts__<ContextKey>_PromptOptions_Steps__N__InputTextLabel
FeedSlotContexts__<ContextKey>_PromptOptions_Steps__N__ImageQuantity (Step ImageGeneration only)
FeedSlotContexts__<ContextKey>_PromptOptions_Steps__N__ImageSize (Step ImageGeneration only)
```


### `PromptRole` values

Each step in `Steps` carries a mandatory `Role` discriminator:

| Role | Index convention | Description |
|---|---|---|
| `Summary` | `Steps__0` | Generates the primary text summary from raw feed content. `MaxOutputLength` is **not set here** — it is resolved at runtime from `ISender.MessageMaxLength`. |
| `ImagePromptDerivation` | `Steps__1` | Derives the image-generation prompt from the summary. |
| `ImageGeneration` | `Steps__2` | Generates the image. Only `ImageQuantity` and `ImageSize` are relevant here; prompt templates may be empty. |

### `PromptStepOptions` fields

| Setting | Type | Required | Description |
|---|---|---|---|
| `Role` | `PromptRole` | ✅ Yes | Step discriminator — must be unique within the `Steps` list. |
| `SystemPromptTemplate` | string | ✅ Yes | System message template. Supports `{MaxChars}` for `Summary`, none for `ImageGeneration`. |
| `UserPromptTemplate` | string | ✅ Yes | User message template. Supports `{Text}` (`Summary`), `{Summary}` (`ImagePromptDerivation`), `{Text}` (`ImageGeneration`). |
| `Temperature` | double | No | Sampling temperature. Omit to use the provider default. |
| `MaxTokenBudget` | int | No | Upper token budget for this step. Omit to use the provider default. |
| `InputTextLabel` | string | No | Placeholder token used for input-text substitution in the templates (e.g. `{Text}`, `{Summary}`). |
| `ImageQuantity` | int | No | Images to generate per call. Relevant for `ImageGeneration` steps only. |
| `ImageSize` | string | No | Size preset (e.g. `1024x1024`). Relevant for `ImageGeneration` steps only. |

### Minimal example — two feed slots

```json
"FeedSlotContexts__Feed06__FeedUrls__0": "https://example.com/rss",
"FeedSlotContexts__Feed06__PromptOptions__Steps__0__Role": "Summary",
"FeedSlotContexts__Feed06__PromptOptions__Steps__0__SystemPromptTemplate": "You are an assistant that summarizes text concisely. Keep summaries under {MaxChars} characters.",
"FeedSlotContexts__Feed06__PromptOptions__Steps__0__UserPromptTemplate": "Summarize this text in a few sentences. text: {Text}",
"FeedSlotContexts__Feed06__PromptOptions__Steps__0__Temperature": "0.5",
"FeedSlotContexts__Feed06__PromptOptions__Steps__0__MaxTokenBudget": "600",
"FeedSlotContexts__Feed06__PromptOptions__Steps__0__InputTextLabel": "{Text}",

"FeedSlotContexts__Feed06__PromptOptions__Steps__1__Role": "ImagePromptDerivation",
"FeedSlotContexts__Feed06__PromptOptions__Steps__1__SystemPromptTemplate": "You are an assistant that generates image prompts. Create a concise, vivid prompt in English.",
"FeedSlotContexts__Feed06__PromptOptions__Steps__1__UserPromptTemplate": "Generate an image prompt based on this summary: {Summary}",
"FeedSlotContexts__Feed06__PromptOptions__Steps__1__Temperature": "0.7",
"FeedSlotContexts__Feed06__PromptOptions__Steps__1__MaxTokenBudget": "300",
"FeedSlotContexts__Feed06__PromptOptions__Steps__1__InputTextLabel": "{Summary}",

"FeedSlotContexts__Feed06__PromptOptions__Steps__2__Role": "ImageGeneration",
"FeedSlotContexts__Feed06__PromptOptions__Steps__2__SystemPromptTemplate": "",
"FeedSlotContexts__Feed06__PromptOptions__Steps__2__UserPromptTemplate": "{Text}",
"FeedSlotContexts__Feed06__PromptOptions__Steps__2__ImageQuantity": "1",
"FeedSlotContexts__Feed06__PromptOptions__Steps__2__ImageSize": "1024x1024",
"FeedSlotContexts__Feed06__PromptOptions__Steps__2__InputTextLabel": "{Text}"
```
---

## Feed HTTP Client

`FeedService` fetches RSS/Atom feeds via the named HTTP client `"Feed"`, registered in `HttpClientExtensions.AddHttpClients()` and protected by a Polly resilience pipeline composed of three layers (innermost to outermost):

1. **Attempt timeout** — cancels a single HTTP attempt if it exceeds `AttemptTimeoutSeconds`.
2. **Retry** — retries up to `RetryCount` times with exponential back-off on transient failures (network errors, 5xx, 429).
3. **Circuit breaker** — opens the circuit when the failure ratio over `CircuitBreakerSamplingDurationSeconds` exceeds `CircuitBreakerFailureThreshold`, and keeps it open for `CircuitBreakerBreakDurationSeconds` before allowing a probe request.

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
Separation of concerns (v2): AI provider settings now cover only connectivity — endpoint, credentials, and model name. Prompt templates, temperature, token budget, and image parameters are owned by each orchestrator slot via FeedSlotContexts. This means the same provider can be used by multiple slots with different prompt strategies without any provider-level config change.

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
| `XCredentials--XApiKey` | Twitter App API Key (Consumer Key). |
| `XCredentials--XApiSecret` | Twitter App API Secret (Consumer Secret). |
| `XCredentials--XAccessToken` | User Access Token (OAuth 1.0a). |
| `XCredentials--XAccessTokenSecret` | User Access Token Secret (OAuth 1.0a). |

#### LinkedIn

| Secret name | Required | Description |
|---|---|---|
| `LinkedInCredentials--LinkedInAccessToken` | ✅ Yes | LinkedIn OAuth 2.0 access token. **Expires every 60 days** — manual rotation currently required. |
| `LinkedInCredentials--LinkedInOwnerCode` | ⚠️ One of these | Numeric LinkedIn person ID. |
| `LinkedInCredentials--LinkedInOrgId` | ⚠️ One of these | Numeric LinkedIn organization ID. Takes precedence over `LinkedInOwnerCode` when set. |

#### Instagram

| Secret name | Description |
|---|---|
| `InstagramCredentials--InstagramAccessToken` | Long-lived Instagram Graph API access token. |
| `InstagramCredentials--InstagramAccountId` | Numeric Instagram Business Account ID. |

#### Facebook

| Secret name | Description |
|---|---|
| `FacebookCredentials--FacebookAccessToken` | Long-lived Facebook Graph API access token. |
| `FacebookCredentials--FacebookPageId` | Numeric Facebook Page ID. |

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
    "ContainerPollingSchedule": "0 */2 * * * *",
    "EnableDryRunSlot": "true",
    "ForceHour": "9",
    "AiProvider": "OpenAi",
    "KEYVAULT_URI": "https://<your-keyvault-name>.vault.azure.net/",
    "OpenAI__ApiKey": "<your-openai-key>",
    "OpenAI__Endpoint": "https://api.openai.com/v1/",
    "OpenAI__TextModelName": "gpt-4.1-nano",
    "OpenAI__ImageModelName": "gpt-image-1.5",
    "OpenAI__ImageSize": "1024x1024",
    "FeedSlotContexts__Feed09": "Feed09"
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
| `OpenAI__Endpoint` | string | No | `https://api.openai.com/v1/` | Chat Completions API URL. |
| `OpenAI__TextModelName` | string | No | `gpt-4.1-nano` | Model used for text summarisation and image prompt generation. |
| `OpenAI__ImageModelName` | string | No | `gpt-image-1.5` | Model used for image generation. |

> Prompt templates, temperature, and token budget are now configured per slot in FeedSlotContexts (see [Feed Slot Contexts](#feed-slot-contexts)).

> See [docs/integrations/setup-openai.md](integrations/setup-openai.md) for the full setup guide.

---

## AI — Azure AI Foundry (`AiProvider = AzureFoundry`)

Configuration bound from the `AzureFoundry` prefix.

**Capabilities:** `ITextToTextProvider` ✅ · `ITextToImageProvider` ✅

| Setting | Type | Required | Default | Description |
|---|---|---|---|---|
| `AzureFoundry__Endpoint` | string | ✅ Yes | — | Azure AI Foundry resource endpoint. |
| `AzureFoundry__ApiKey` | string | ✅ Yes* | — | Resource key. *Omit when using Managed Identity. |
| `AzureFoundry__TextModelName` | string | ✅ Yes | — | Chat deployment name. |
| `AzureFoundry__ImageModelName` | string | ✅ Yes | — | Image generation deployment name. |

Summarisation and image prompt tuning settings follow the same structure as the OpenAI block above, using the `AzureFoundry__` prefix.

> See [docs/integrations/setup-azure-foundry.md](integrations/setup-azure-foundry.md) for the full setup guide.

---

## AI — DeepSeek (`AiProvider = DeepSeek`)

Configuration bound from the `DeepSeek` prefix using double-underscore notation.

**Capabilities:** `ITextToTextProvider` ✅ · `ITextToImageProvider` ❌ (text-only — slots using this provider publish without image)

| Setting | Type | Required | Default | Description |
|---|---|---|---|---|
| `DeepSeek__ApiKey` | string | ✅ Yes | — | DeepSeek platform API key. |
| `DeepSeek__Endpoint` | string | No | `https://api.deepseek.com` | DeepSeek API base URL. |
| `DeepSeek__TextModelName` | string | No | `deepseek-chat` | Model identifier. |

Summarisation and image prompt tuning settings follow the same structure as the OpenAI block, using the `DeepSeek__` prefix.

> See [docs/integrations/setup-deepseek.md](integrations/setup-deepseek.md) for the full setup guide.

---

## AI — fal.ai (`AiProvider = FalAi`)

Configuration bound from the `FalAi` prefix using double-underscore notation.

**Capabilities:** `ITextToTextProvider` ❌ · `ITextToImageProvider` ✅ (image-only — only valid for orchestrators that handle null `textProvider`)

| Setting | Type | Required | Default | Description |
|---|---|---|---|---|
| `FalAi__ApiKey` | string | ✅ Yes | — | fal.ai API key. |
| `FalAi__Endpoint ` | string | No | — | fal.ai API base URL. |
| `FalAi__ImageModelName` | string | No | `fal-ai/flux/schnell` | fal.ai model identifier. |
| `FalAi__NumInferenceSteps` | int | No | `4` | Number of diffusion steps. |

> See [docs/integrations/setup-falai.md](integrations/setup-falai.md) for the full setup guide.

---

## AI — Perplexity (`AiProvider = Perplexity`)

Configuration bound from the `Perplexity` prefix using double-underscore notation.

**Capabilities:** `ITextToTextProvider` ✅ · `ITextToImageProvider` ❌ (text-only — slots using this provider publish without image)

### Connection

| Setting | Type | Required | Default | Description |
|---|---|---|---|---|
| `Perplexity__ApiKey` | string | ✅ Yes | — | Perplexity platform API key. Obtain from [perplexity.ai/settings/api](https://www.perplexity.ai/settings/api). |
| `Perplexity__Endpoint` | string | No | `https://api.perplexity.ai` | Perplexity API base URL. |
| `Perplexity__TextModelName` | string | No | `sonar` | Model identifier passed as `model` in each chat completions request. |

> See [docs/integrations/setup-perplexity.md](integrations/setup-perplexity.md) for the full setup guide.

---

## Observability

| Variable | Type | Required | Description |
|---|---|---|---|
| `APPLICATIONINSIGHTS_CONNECTION_STRING` | string | No | Application Insights connection string. When present, the isolated worker SDK automatically registers the telemetry pipeline. |
