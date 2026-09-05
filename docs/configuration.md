# Configuration Reference

All configuration is passed via environment variables — locally in `src/local.settings.json`, in production via Azure App Settings.

The file [`src/local.settings.json.example`](../src/local.settings.json.example) is the canonical starting template: copy it to `src/local.settings.json`, fill in the empty strings, and the function is ready to run locally.

> ⚠️ Sender credentials (Twitter/X, LinkedIn, Instagram, Facebook) are **no longer configured via environment variables**. They are loaded from Azure Key Vault at application startup via the **Azure Key Vault Configuration Provider** (registered in `Program.cs`), and injected into senders through standard `IOptions` / `IConfiguration` binding. No runtime secret-fetch calls occur during post publishing. See the [Key Vault](#key-vault) section below.

---

## Quick-Start Checklist

For a minimal local setup running the default **Bitcoin** workflow (5-node DAG: `FetchRss` → `AiText` → `AiText` → `AiImage` → `FanOutSend`) you need at minimum:

- [ ] `AzureWebJobsStorage` — Azurite or a real Storage Account connection string
- [ ] `KEYVAULT_URI` — URI of the Azure Key Vault instance holding all sender credentials
- [ ] `OpenAI__ApiKey` — used by the Bitcoin workflow's `AiText` and `AiText` (image-prompt) nodes
- [ ] `FalAi__ApiKey` — used by the Bitcoin workflow's `AiImage` node
- [ ] RSS feed URLs — set in `Workflows__Bitcoin__Nodes__0__Parameters__Urls` (a JSON-array string)
- [ ] (Optional) `APPLICATIONINSIGHTS_CONNECTION_STRING` for local telemetry

Each workflow node picks its own AI provider via the `Provider` parameter (`Workflows__<Workflow>__Nodes__N__Parameters__Provider`), so a single workflow can mix providers per step entirely through configuration.

For a **DeepSeek** (text-only) workflow — one without an `AiImage` node, or with `AiImage` optional (`Required: false`) — replace the `AiText` node providers with `DeepSeek`:

- [ ] `DeepSeek__ApiKey`

For a **Perplexity** (text-only) workflow, replace the `AiText` node providers with `Perplexity`:

- [ ] `Perplexity__ApiKey`

For a **fal.ai** workflow (image-only — text nodes must be absent or optional via `Required: false`), the `AiImage` node uses `FalAi`:

- [ ] `FalAi__ApiKey`

A workflow may mix providers freely: e.g. `AiText` node with `DeepSeek` for the summary and `AiImage` with `FalAi` for the image — no separate slots or special provider combination needed.

> 💡 For local development, run `az login` before starting the function. The Key Vault Configuration Provider uses `DefaultAzureCredential`, which picks up your Azure CLI session automatically and loads all secrets into `IConfiguration` at startup.

### 🧪 Quick-Start: DryRunSender (no social API credentials needed)

If you only want to verify the end-to-end pipeline locally **without publishing to any social platform**, you can use the dry-run senders. This is the recommended first step for new contributors or when onboarding a new environment.

- [ ] `AzureWebJobsStorage` — `UseDevelopmentStorage=true` (Azurite)
- [ ] `KEYVAULT_URI` — Key Vault URI (needed for the Configuration Provider to load at startup)
- [ ] At least one Key Vault secret that the dry-run sender can probe — the dry-run implementation checks that `XApiKey` is non-empty and fails the run otherwise
- [ ] `OpenAI__ApiKey` / `FalAi__ApiKey` — the providers declared by the workflow's nodes (see [Workflows (Node DAGs)](#workflows-node-dags))
- [ ] RSS feed URLs — set in `Workflows__Bitcoin__Nodes__0__Parameters__Urls`
- [ ] `az login` executed in the terminal before `func start`
- [ ] A `Schedule` slot whose senders are the dry-run platforms — e.g. `Schedule__2__…` with `Senders__0: DryRunMaxLength` and `Senders__1: DryRunShortLength`
- [ ] `ForceHour` set to the dry-run slot hour (`9`) in `local.settings.json` (routes execution to the dry-run slot regardless of wall-clock time)
- [ ] **No** Twitter/X, LinkedIn, Instagram, or Facebook publishing secrets required — only the `XApiKey` probe secret above

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
    "CronSchedule": "0 50 * * * *",
    "ContainerPollingSchedule": "0 */2 * * * *",

    // -----------------------------------------------------------------------
    // Local development slot override.
    // Set to a UTC hour (0-23) matching an entry in the Schedule configuration
    // to force that orchestrator slot without waiting for the real clock.
    // Examples:
    //   "ForceHour": "6"   → Bitcoin   / WorkflowOrchestrator (5-node DAG)
    //   "ForceHour": "9"   → DryRun    / WorkflowOrchestrator (a Schedule slot with dry-run senders)
    //   "ForceHour": "14"  → PowerLaw  / WorkflowOrchestrator (3-node DAG)
    // Remove or leave empty to use the real UTC clock (production behaviour).
    // Only honoured in the Development environment (LocalOverrideTimeProvider).
    // -----------------------------------------------------------------------
    "ForceHour": "9",

    // -----------------------------------------------------------------------
    // Dry-run testing (local integration testing without social platform publishing).
    //
    // A dry-run slot is just an ordinary Schedule entry whose senders are the
    // dry-run platforms. They log the post instead of publishing, exercising the
    // full workflow (RSS, AI providers, image, tag replacement) without posting.
    //
    //   1. Add a Schedule slot with the dry-run senders you want, e.g.:
    //        "Schedule__2__Hour":           "9",
    //        "Schedule__2__Workflow":       "PowerLaw",
    //        "Schedule__2__Senders__0":     "DryRunMaxLength",
    //        "Schedule__2__Senders__1":     "DryRunShortLength",
    //   2. Set "ForceHour": "9" so the dry-run slot is the only one selected.
    //   3. Ensure at least the "XApiKey" secret is present in Key Vault: the
    //      dry-run sender probes it to verify the Configuration Provider loaded
    //      secrets successfully, and returns false otherwise.
    //
    // IMPORTANT — do NOT put a dry-run sender in production (Azure) app settings.
    // -----------------------------------------------------------------------

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
    //   LinkedInCredentials--LinkedInAccessToken  → LinkedInCredentials.LinkedInAccessToken
    //   LinkedInCredentials--LinkedInOwnerCode    → LinkedInCredentials.LinkedInOwnerCode
    //   LinkedInCredentials--LinkedInOrgId        → LinkedInCredentials.LinkedInOrgId (optional; org posts)
    //   XCredentials--XApiKey         → XCredentials.XApiKey
    //   XCredentials--XApiSecret      → XCredentials.XApiSecret
    //   XCredentials--XAccessToken    → XCredentials.XAccessToken
    //   XCredentials--XAccessTokenSecret → XCredentials.XAccessTokenSecret
    //   InstagramCredentials--InstagramAccessToken → InstagramCredentials.InstagramAccessToken
    //   InstagramCredentials--InstagramAccountId   → InstagramCredentials.InstagramAccountId
    //   FacebookCredentials--FacebookAccessToken   → FacebookCredentials.FacebookAccessToken
    //   FacebookCredentials--FacebookPageId        → FacebookCredentials.FacebookPageId
    //
    // Dry-run probe: DryRunSender reads the TOP-LEVEL key "XApiKey" (any non-empty
    // value) as a configuration-probe signal. For local dry-runs set "XApiKey"
    // directly in local.settings.json; for dry-runs behind Key Vault keep a plain
    // "XApiKey" secret (distinct from "XCredentials--XApiKey" for the real XSender).
    // -----------------------------------------------------------------------
    "KEYVAULT_URI": "https://<your-keyvault-name>.vault.azure.net/",

    // -----------------------------------------------------------------------
    // ── Azure Blob Storage & Instagram Polling ──
    // -----------------------------------------------------------------------
    "AZURE_STORAGE_CONNECTION_STRING": "UseDevelopmentStorage=true",
    "AZURE_STORAGE_CONTAINER_NAME": "xposter-images",

    // -----------------------------------------------------------------------
    // AI Provider — connectivity and model capability settings only.
    // Prompt templates and intent are owned by each workflow step via
    // PromptSteps + Workflows (see below). Only keep here what the provider
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
    // Prompt steps — prompt configuration for the workflow engine.
    //
    // IStepOptionsResolver (ConfigurationStepOptionsResolver) binds each step
    // from the PromptSteps:<StepId> section. A workflow node references a step
    // via its "StepId" parameter, e.g. "Feed.Summary".
    // -----------------------------------------------------------------------

    "PromptSteps__Feed.Summary__SystemPromptTemplate": "You are an assistant that summarizes text concisely. It's very important that you keep summaries under {MaxChars} characters.",
    "PromptSteps__Feed.Summary__UserPromptTemplate": "Summarize this text in a few sentences. text: {Text}",
    "PromptSteps__Feed.Summary__Temperature": "0.5",
    "PromptSteps__Feed.Summary__MaxTokenBudget": "600",
    "PromptSteps__Feed.Summary__InputTextLabel": "{Text}",

    "PromptSteps__Feed.ImagePromptDerivation__SystemPromptTemplate": "You are an assistant that generates image prompts for an AI image generation model based on text summaries. Create a concise, vivid prompt in English that reflects the summary's content, includes a Bitcoin-related element (e.g., a coin), and avoids text, signs, or words in the image. Respect content policy for generating images.",
    "PromptSteps__Feed.ImagePromptDerivation__UserPromptTemplate": "Generate an image prompt based on this summary: {Summary}",
    "PromptSteps__Feed.ImagePromptDerivation__Temperature": "0.7",
    "PromptSteps__Feed.ImagePromptDerivation__MaxTokenBudget": "300",
    "PromptSteps__Feed.ImagePromptDerivation__InputTextLabel": "{Summary}",

    "PromptSteps__Feed.ImageGeneration__SystemPromptTemplate": "",
    "PromptSteps__Feed.ImageGeneration__UserPromptTemplate": "{Text}",
    "PromptSteps__Feed.ImageGeneration__ImageQuantity": "1",
    "PromptSteps__Feed.ImageGeneration__ImageSize": "1024x1024",
    "PromptSteps__Feed.ImageGeneration__InputTextLabel": "{Text}",

    // -----------------------------------------------------------------------
    // Workflows — per-slot workflow DAGs for the workflow engine.
    //
    // Each node has: Id (unique), Type (a keyed IWorkflowNode resolution key),
    // Parameters (node-specific), OutputKey (context key storing the output),
    // NextNodeIds (edges of the DAG).
    //
    // Bitcoin slot — 5-node pipeline: fetch-rss → generate-summary →
    // generate-image-prompt → generate-image → fan-out-send.
    // -----------------------------------------------------------------------

    "Workflows__Bitcoin__Nodes__0__Id": "fetch-rss",
    "Workflows__Bitcoin__Nodes__0__Type": "FetchRss",
    // RSS URLs are passed as a JSON-array string; NodeParameterExtractor
    // deserializes it into the node's List<string> Urls parameter.
    "Workflows__Bitcoin__Nodes__0__Parameters__Urls": "[\"https://cointelegraph.com/rss/tag/bitcoin\",\"https://www.coindesk.com/arc/outboundfeeds/rss\"]",
    "Workflows__Bitcoin__Nodes__0__OutputKey": "sourceContent",
    "Workflows__Bitcoin__Nodes__0__NextNodeIds__0": "generate-summary",

    "Workflows__Bitcoin__Nodes__1__Id": "generate-summary",
    "Workflows__Bitcoin__Nodes__1__Type": "AiText",
    "Workflows__Bitcoin__Nodes__1__Parameters__Provider": "OpenAi",
    "Workflows__Bitcoin__Nodes__1__Parameters__StepId": "Feed.Summary",
    "Workflows__Bitcoin__Nodes__1__Parameters__InputKey": "sourceContent",
    "Workflows__Bitcoin__Nodes__1__OutputKey": "baseSummary",
    "Workflows__Bitcoin__Nodes__1__NextNodeIds__0": "generate-image-prompt",

    "Workflows__Bitcoin__Nodes__2__Id": "generate-image-prompt",
    "Workflows__Bitcoin__Nodes__2__Type": "AiText",
    "Workflows__Bitcoin__Nodes__2__Parameters__Provider": "OpenAi",
    "Workflows__Bitcoin__Nodes__2__Parameters__StepId": "Feed.ImagePromptDerivation",
    "Workflows__Bitcoin__Nodes__2__Parameters__InputKey": "baseSummary",
    "Workflows__Bitcoin__Nodes__2__OutputKey": "imagePrompt",
    "Workflows__Bitcoin__Nodes__2__NextNodeIds__0": "generate-image",

    "Workflows__Bitcoin__Nodes__3__Id": "generate-image",
    "Workflows__Bitcoin__Nodes__3__Type": "AiImage",
    "Workflows__Bitcoin__Nodes__3__Parameters__Provider": "FalAi",
    "Workflows__Bitcoin__Nodes__3__Parameters__StepId": "Feed.ImageGeneration",
    "Workflows__Bitcoin__Nodes__3__Parameters__InputKey": "imagePrompt",
    // Required controls AiImage failure handling (default false = soft failure,
    // publish without image; true = hard failure, block the workflow when no image).
    "Workflows__Bitcoin__Nodes__3__Parameters__Required": "false",
    "Workflows__Bitcoin__Nodes__3__OutputKey": "attachedMedia",
    "Workflows__Bitcoin__Nodes__3__NextNodeIds__0": "fan-out-send",

    "Workflows__Bitcoin__Nodes__4__Id": "fan-out-send",
    "Workflows__Bitcoin__Nodes__4__Type": "FanOutSend",
    "Workflows__Bitcoin__Nodes__4__Parameters__TextKey": "baseSummary",
    "Workflows__Bitcoin__Nodes__4__Parameters__FallbackSourceKey": "sourceContent",
    "Workflows__Bitcoin__Nodes__4__Parameters__StepId": "Feed.Summary",
    "Workflows__Bitcoin__Nodes__4__Parameters__MediaKey": "attachedMedia",

    // -----------------------------------------------------------------------
    // PowerLaw slot — 3-node deterministic pipeline (no AI, no image):
    // acquire-value → build-post → fan-out-send.
    //
    // BuildPowerLawPostNode reads the acquired price from the context key given
    // by its ActualValueKey parameter ("PowerLaw.ActualValue"), which is the
    // OutputKey of the acquire node. The Symbol parameter is independent per
    // node, so the workflow can target any crypto (e.g. "ETH") by changing it.
    // -----------------------------------------------------------------------

    "Workflows__PowerLaw__Nodes__0__Id": "acquire-value",
    "Workflows__PowerLaw__Nodes__0__Type": "AcquireCryptoValue",
    "Workflows__PowerLaw__Nodes__0__Parameters__Symbol": "BTC",
    "Workflows__PowerLaw__Nodes__0__OutputKey": "PowerLaw.ActualValue",
    "Workflows__PowerLaw__Nodes__0__NextNodeIds__0": "build-post",

    "Workflows__PowerLaw__Nodes__1__Id": "build-post",
    "Workflows__PowerLaw__Nodes__1__Type": "BuildPowerLawPost",
    "Workflows__PowerLaw__Nodes__1__Parameters__Symbol": "BTC",
    "Workflows__PowerLaw__Nodes__1__Parameters__ActualValueKey": "PowerLaw.ActualValue",
    "Workflows__PowerLaw__Nodes__1__OutputKey": "PowerLaw.PostText",
    "Workflows__PowerLaw__Nodes__1__NextNodeIds__0": "fan-out-send",

    "Workflows__PowerLaw__Nodes__2__Id": "fan-out-send",
    "Workflows__PowerLaw__Nodes__2__Type": "FanOutSend",
    "Workflows__PowerLaw__Nodes__2__Parameters__TextKey": "PowerLaw.PostText",

    // -----------------------------------------------------------------------
    // Schedule — config-driven orchestration slots (see ConfigurationSlotProfileProvider).
    //
    // Every slot maps to a WorkflowOrchestrator whose workflow key matches a
    // WorkflowDefinition registered under Workflows__<Workflow>__*. This makes it
    // possible to schedule any workflow at any hour with no code change or release.
    //
    // Flat Azure Functions naming convention: Schedule__<index>__<field>.
    //   Hour         : hour of day (0-23) when the slot is active.
    //   Workflow     : workflow key (must match a Workflows__<key> section above).
    //   Senders__N   : target sender platform name, e.g. "LinkedIn" or "X".
    //
    // The AI provider is NOT selected here — each workflow node chooses its own
    // provider via Workflows__<key>__Nodes__N__Parameters__Provider.
    // -----------------------------------------------------------------------
    "Schedule__0__Hour": "6",
    "Schedule__0__Workflow": "Bitcoin",
    "Schedule__0__Senders__0": "LinkedIn",
    "Schedule__0__Senders__1": "X",
    "Schedule__0__Senders__2": "Facebook",
    "Schedule__0__Senders__3": "Instagram",

    "Schedule__1__Hour": "14",
    "Schedule__1__Workflow": "PowerLaw",
    "Schedule__1__Senders__0": "LinkedIn",
    "Schedule__1__Senders__1": "X",
    "Schedule__1__Senders__2": "Facebook",

    // To add a local-only dry-run slot (logged outgoing, not published), set
    // "ForceHour" to the slot hour and add its Schedule entry:
    //   "Schedule__2__Hour": "9",
    //   "Schedule__2__Workflow": "PowerLaw",
    //   "Schedule__2__Senders__0": "DryRunMaxLength",   // MessageMaxLength = int.MaxValue
    //   "Schedule__2__Senders__1": "DryRunShortLength", // MessageMaxLength = 250

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
| `FUNCTIONS_WORKER_RUNTIME` | string | ✅ Yes | `dotnet-isolated` | Must be `dotnet-isolated` for .NET 10 isolated worker. Do not change. |

---

## Scheduler

The execution cadence is split into two concerns:

- **`CronSchedule`** — the timer firing frequency. The function fires on this cron, but **which workflow runs at a given UTC hour is decided by the `Schedule` configuration section** (`Schedule__N__Hour`, `Schedule__N__Workflow`, `Schedule__N__Senders__M`). If no slot matches the current hour, `NoOrchestrator` is used.
- **`Schedule__N__…`** — the per-hour slot mapping, read by `ConfigurationSlotProfileProvider`. Every entry maps to a `WorkflowOrchestrator` whose workflow key must match a `Workflows__<key>` section.

| Variable | Type | Required | Default | Description |
|---|---|---|---|---|
| `CronSchedule` | string | ✅ Yes | `0 50 * * * *` | 6-field NCRONTAB expression controlling the timer firing frequency (every hour at minute 50 in the example). The slot selected per hour comes from `Schedule__N__…`. |
| `ContainerPollingSchedule` | string | ✅ Yes | `0 */2 * * * *` | 6-field NCRONTAB expression for `XPosterContainerPollingFunction`, which polls and publishes pending Instagram media containers. |
| `ForceHour` | string | No | — | Forces the UTC hour used by `OrchestratorFactory.Resolve()` via `LocalOverrideTimeProvider`. Honoured **only in the Development environment** and only when present and non-empty. |
| `Schedule__N__Hour` | int | ✅ Yes | — | Hour of day (0–23) when the slot is active. |
| `Schedule__N__Workflow` | string | ✅ Yes | — | Workflow key; must match a `Workflows__<key>` section, otherwise the slot resolves to `NoOrchestrator`. |
| `Schedule__N__Senders__M` | string | ✅ Yes | — | Target sender platform name (e.g. `LinkedIn`, `X`, `Facebook`, `Instagram`, `DryRunMaxLength`, `DryRunShortLength`). Unknown names are skipped with a warning. |

---

## Schedule Slots and Multi-Platform Fan-Out

The orchestration schedule is fully **configuration-driven**. `ConfigurationSlotProfileProvider` (the single `ISlotProfileProvider` registered in `Program.cs`) reads every entry from the `Schedule` configuration section and maps each one to a `WorkflowOrchestrator` whose `OrchestratorContextKey` is the slot's workflow key. There is no embedded production-schedule code anymore — adding or changing a slot is a configuration change only.

### Sender ordering in fan-out slots

`FanOutSendNode` re-orders senders internally by descending `MessageMaxLength` at runtime before producing per-sender content. The declaration order within a slot's `Senders` list does not affect fan-out execution — the widest sender is always the primary and drives the base summary generation; each narrower sender receives a re-summarised variant only when the base text exceeds its limit and a fallback source is available (see [Workflows](#workflows-node-dags)).

| Platform | `MessageMaxLength` | Role in a fan-out slot |
|---|---|---|
| Facebook | 3 000 | Widest limit — selected as primary by `FanOutSendNode`; base summary generated at this length |
| LinkedIn | 2 800 | Secondary — re-summarisation triggered only when base summary exceeds 2 800 chars |
| Instagram | 2 200 | Tertiary — re-summarisation triggered only when base summary exceeds 2 200 chars |
| X (Twitter) | 250 | Narrowest — always triggers re-summarisation when base summary exceeds 250 chars |
| `DryRunMaxLength` | `int.MaxValue` | Local testing only — always selected as primary when present |
| `DryRunShortLength` | 250 | Local testing only — exercises the re-summarisation path |

> 💡 **Cost implication:** a single fan-out slot with N senders replaces N separate schedule slots. Base summary and image are generated once; only cheap per-sender re-summarisation AI calls are added when needed. See the [Token / Credit Savings](#token--credit-savings) section below.

### Production slot example

```jsonc
// local.settings.json — production schedule
"Schedule__0__Hour": "6",
"Schedule__0__Workflow": "Bitcoin",
"Schedule__0__Senders__0": "LinkedIn",
"Schedule__0__Senders__1": "X",
"Schedule__0__Senders__2": "Facebook",
"Schedule__0__Senders__3": "Instagram",

"Schedule__1__Hour": "14",
"Schedule__1__Workflow": "PowerLaw",
"Schedule__1__Senders__0": "LinkedIn",
"Schedule__1__Senders__1": "X",
"Schedule__1__Senders__2": "Facebook",
```

At hour 6 the `Bitcoin` workflow (5-node DAG) runs once, generates the base summary and image, then fans out via `FanOutSend` to LinkedIn, X, Instagram, and Facebook in parallel. The `PowerLaw` slot at hour 14 computes deterministic content from crypto price data — no AI calls involved.

### Dry-run slot example

A dry-run slot is just an ordinary `Schedule` entry whose senders are the dry-run platforms. `ForceHour` pins the clock locally so this slot is selected at startup:

```jsonc
// local.settings.json — local-only dry-run (never in production)
"Schedule__2__Hour": "9",
"Schedule__2__Workflow": "PowerLaw",
"Schedule__2__Senders__0": "DryRunMaxLength",
"Schedule__2__Senders__1": "DryRunShortLength",

"ForceHour": "9"
```

The dry-run senders log the post content instead of publishing; the two-length combination exercises both the primary path (unlimited) and the re-summarisation path (250 chars).

---

## Token / Credit Savings

| Scenario | Full AI text pipelines | Image calls |
|---|---|---|
| Separate schedule entries (3 slots) | 3× full pipeline (feed fetch + summary + image prompt) | 3× |
| Fan-out slot (3 senders, 1 schedule entry) | 1× full pipeline + up to 2× cheap re-summarisation | 1× |
| **Saving** | **~67 % fewer full AI pipelines** | **~67 % fewer image credits** |

The base summary is generated once (size it by setting `MaxOutputLength` on the summary step — for a fan-out slot, use the widest sender's limit). When the base text already fits within a secondary sender's character limit, that sender's AI re-summarisation call is skipped entirely.

---

## Prompt Steps

Prompt configuration for the workflow engine is defined in the `PromptSteps` section, keyed by an arbitrary step id (`PromptSteps__<StepId>__*`). `ConfigurationStepOptionsResolver` binds each step at runtime; workflow nodes reference a step via their `StepId` parameter (e.g. an `AiText` node with `StepId = Feed.Summary`).

### Configuration structure

```jsonc
PromptSteps__<StepId>__SystemPromptTemplate → system message template
PromptSteps__<StepId>__UserPromptTemplate   → user message template
PromptSteps__<StepId>__Temperature          → sampling temperature (optional)
PromptSteps__<StepId>__MaxOutputLength      → max output characters (optional)
PromptSteps__<StepId>__MaxTokenBudget       → upper token budget (optional)
PromptSteps__<StepId>__InputTextLabel       → label used for input-text substitution
PromptSteps__<StepId>__ImageQuantity        → images per call (image steps only)
PromptSteps__<StepId>__ImageSize            → size preset (image steps only)
```

### `PromptStepOptions` fields

| Setting | Type | Required | Description |
|---|---|---|---|
| `SystemPromptTemplate` | string | ✅ Yes | System message template. Supports `{MaxChars}`, interpolated from `MaxOutputLength`. |
| `UserPromptTemplate` | string | ✅ Yes | User message template with the input-text label (e.g. `{Text}`, `{Summary}`). |
| `Temperature` | double? | No | Sampling temperature. Omit to use the provider default. |
| `MaxOutputLength` | int? | No | Maximum output characters; placed where `{MaxChars}` appears. For fan-out re-summarisation it is overridden per sender by `ISender.MessageMaxLength`. |
| `MaxTokenBudget` | int? | No | Upper token budget for the call. Omit to use the provider default. |
| `InputTextLabel` | string? | No | Label wrapped around the input text in the templates (e.g. `{Text}`). |
| `ImageQuantity` | int? | No | Images to generate per call. Image steps only. |
| `ImageSize` | string? | No | Size preset (e.g. `1024x1024`). Image steps only. |

An `AiText` node can target any step — there is no fixed role set. The same step can be reused by multiple nodes (e.g. `FanOutSend` re-summarisation reuses the `Feed.Summary` step).

### Minimal example

```json
"PromptSteps__Feed.Summary__SystemPromptTemplate": "You are an assistant that summarizes text concisely. Keep summaries under {MaxChars} characters.",
"PromptSteps__Feed.Summary__UserPromptTemplate": "Summarize this text in a few sentences. text: {Text}",
"PromptSteps__Feed.Summary__Temperature": "0.5",
"PromptSteps__Feed.Summary__MaxTokenBudget": "600",
"PromptSteps__Feed.Summary__InputTextLabel": "{Text}",

"PromptSteps__Feed.ImageGeneration__SystemPromptTemplate": "",
"PromptSteps__Feed.ImageGeneration__UserPromptTemplate": "{Text}",
"PromptSteps__Feed.ImageGeneration__ImageQuantity": "1",
"PromptSteps__Feed.ImageGeneration__ImageSize": "1024x1024",
"PromptSteps__Feed.ImageGeneration__InputTextLabel": "{Text}"
```

---

## Workflows (Node DAGs)

Each scheduled workflow is defined under the `Workflows` section as a node DAG: `Workflows__<Workflow>__Nodes__N__*`. Every node carries:

| Field | Type | Description |
|---|---|---|
| `Id` | string | Unique node identifier within the workflow. |
| `Type` | string | Keyed `IWorkflowNode` resolution key (see the [node catalogue](#node-catalogue) below). |
| `Parameters__*` | string | Node-specific parameters (provider names, input/output keys, step ids, etc.). |
| `OutputKey` | string | Context key under which the node's output is stored (optional). |
| `NextNodeIds__N` | string | Target node id(s) — the DAG edges (empty for the terminal node). |

Workflows are validated at startup by `WorkflowDefinitionValidator`: references to missing node ids, cycles, and anything other than exactly **one** terminal node (empty `NextNodeIds`) are rejected. At execution time the terminal node must implement `ITerminalNode`; `WorkflowExecutionEngine` runs nodes in topological order (Kahn's algorithm).

### Node catalogue

| `Type` | Node | Parameters | Output |
|---|---|---|---|
| `FetchRss` | `FetchRssNode` | `Urls` — JSON-array string of RSS feed URLs. Fetches a 24-hour window and pre-filters items by the tag-replacement keywords. | Concatenated feed content |
| `AiText` | `AiTextNode` | `Provider` (`AiProvider` name, default `OpenAi`), `StepId`, `InputKey` | Generated text. Throws if the provider has no `ITextToTextProvider` registered |
| `AiImage` | `AiImageNode` | `Provider`, `StepId`, `InputKey`, `Required` (`bool`, default `false`) | `MediaAttachment`. Throws if the provider has no `ITextToImageProvider`; when `Required: false` a failed/empty image is a soft-fail and the workflow continues without an image |
| `FanOutSend` | `FanOutSendNode` | `TextKey`, `FallbackSourceKey` (optional), `StepId` (optional), `MediaKey` (optional) | **Terminal** — writes the `SenderPlatform → Post` map into `Workflow.SendResults` |
| `AcquireCryptoValue` | `AcquireCryptoValueNode` | `Symbol` (default `BTC`) | Current crypto market price (decimal) |
| `BuildPowerLawPost` | `BuildPowerLawPostNode` | `Symbol` (default `BTC`), `ActualValueKey` (context key holding the acquired price) | Deterministic Power Law fair-value post text |

### Fan-out notes

- `FanOutSend` re-orders senders by descending `MessageMaxLength`; the widest sender's limit drives the base text. When the base text exceeds a narrower sender's limit **and** `FallbackSourceKey` + `StepId` are set, it re-summarises the fallback source against that sender's limit; otherwise it truncates (see [Schedule Slots and Multi-Platform Fan-Out](#schedule-slots-and-multi-platform-fan-out)).
- `WorkflowOrchestrator` derives `ProduceImage` from the DAG itself: `true` whenever an `AiImage` node is present.
---

## Feed HTTP Client

`FeedService` fetches RSS/Atom feeds via the named HTTP client `"Feed"`, registered in `HttpClientExtensions.AddHttpClients()`. Every named client is wrapped in a Polly `AddStandardResilienceHandler` pipeline. Values are **hardcoded in code** (there are no configuration knobs):

| Pipeline layer | Feed client value |
|---|---|
| Attempt timeout | 15 s |
| Total request timeout | 60 s |
| Retry | 3 attempts, 2 s base delay (honours the server's `Retry-After` header when present) |
| Circuit breaker | Break duration 30 s; sampling duration 35 s |
| Metrics | Treated as retriable/breaking: network exceptions plus HTTP `429`, `500`, `502`, `503`, `504` |

The same helper registers resilient clients for every AI provider and social sender (`LinkedIn`, `Instagram`, `Facebook`). Image/feed providers use wider timeouts: FalAi 60 s attempts / 300 s total; Feed 15 s attempts / 60 s total. The X client signs requests independently and is not created through `AddHttpClients`.

---

## Tag Replacements

`FanOutSendNode` applies a word-to-hashtag replacement pass on the final text **independently per sender**, after each per-sender text is finalised. Replacements are resolved at runtime by `ITagReplacementService`, backed by `ITagReplacementProvider`. The default implementation, `ConfigurationTagReplacementProvider`, reads from the `TagReplacementOptions:Replacements` section bound via double-underscore notation.

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

**Behaviour with an empty or absent section:** `ConfigurationTagReplacementProvider` returns an empty `IReadOnlyDictionary<string, string>`. `FanOutSendNode` applies no replacements and passes the final text through unchanged. This is a valid configuration — no warning is emitted.

**Extending the provider:** to source replacements from a different store (database, remote config, Key Vault), implement `ITagReplacementProvider` and register the new implementation in `Program.cs` in place of `ConfigurationTagReplacementProvider`.

---

## AI Provider Selector

XPoster uses a **capability-based** AI provider model. Each `AiProvider` value is registered as a keyed DI service exposing one or both capability interfaces (`ITextToTextProvider`, `ITextToImageProvider`). Provider selection is a **per-node** decision, not a global one: an `AiText` or `AiImage` node carries a `Provider` parameter (default `OpenAi`). The node resolves the corresponding capability with `GetKeyedService<T>(provider)` at execution time.

Separation of concerns: AI provider settings (`AiProvider__*`) cover only **connectivity** — endpoint, credentials, and model name. Prompt templates, temperature, token budget, and image parameters live in `PromptSteps`. This lets a single workflow mix providers per node and reuse the same step across different models without any provider-level config change.

> There is **no** global `AiProvider` setting. Delete any leftover `AiProvider` key from older configurations; the provider is declared on each node (the provider is bound under `Workflows__<Workflow>__Nodes__N__Parameters__Provider`).

### Valid `AiProvider` values

| Value | `ITextToTextProvider` | `ITextToImageProvider` | Notes |
|---|---|---|---|
| `OpenAi` | ✅ | ✅ | Full text + image capabilities |
| `AzureFoundry` | ✅ | ✅ | Full text + image capabilities |
| `DeepSeek` | ✅ | ❌ | Text only — cannot be used by an `AiImage` node |
| `Perplexity` | ✅ | ❌ | Text only — cannot be used by an `AiImage` node |
| `FalAi` | ❌ | ✅ | Image only — cannot be used by an `AiText` node |
| `None` | ❌ | ❌ | No AI — reserved; do not use in production nodes |

### Invalid node combinations

The following combinations fail loudly at node execution (not silently):

- A `Provider: FalAi` node resolved through `ITextToTextProvider` (`AiText`) — `GetKeyedService` returns `null` and the node throws `InvalidOperationException`, failing the workflow.
- A `Provider: DeepSeek` or `Perplexity` node resolved through `ITextToImageProvider` (`AiImage`) — throws `InvalidOperationException`, failing the workflow.

Note that `AiImage` soft-fails (`Required: false`) only when the image **call** returns empty/failed bytes — a missing image provider is always a hard error.

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

> 🧪 **Using `DryRunSender`?** No live social-platform credentials are required. `DryRunSender` only probes configuration for a non-empty top-level `XApiKey` (any value) — provide it as a plain `XApiKey` secret in Key Vault or as an app setting in `local.settings.json`. `KEYVAULT_URI` must always be reachable: the Configuration Provider fails hard at startup if it is missing (see [DryRunSender — Local Testing](#drynunsender--local-testing)).

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

`DryRunSender` is a no-op `ISender` for local end-to-end verification. The full workflow runs — feed fetch, AI text/image generation — but the post is **logged, never published** to any social platform.

Two registered dry-run sender types exist, distinguished by their `Schedule__N__Senders__M` discriminator:

| Discriminator | Class | MessageMaxLength |
|---|---|---|
| `DryRunMaxLength` | `DryRunMaxLengthSender` | `int.MaxValue` |
| `DryRunShortLength` | `DryRunShortLengthSender` | `250` |

Any `Schedule` slot whose senders reference these platforms behaves as a dry-run. Listing both lengths exercises the same fan-out loop as a production slot: the unlimited sender is always the primary (widest limit), and the 250-char sender drives the re-summarisation path.

### Configuration probe

`DryRunSender.SendAsync` first validates the wiring by probing configuration for a non-empty top-level `XApiKey` value (any content). If missing, it logs `[DryRun] Configuration probe failed: 'XApiKey' is missing or empty` and returns `false`. Supply it as:
- an app setting `"XApiKey": "<any-non-empty-value>"` in `local.settings.json` for local runs, or
- a plain `XApiKey` secret in Key Vault (distinct from `XCredentials--XApiKey`, which feeds the live `XSender`).

### Minimal `local.settings.json` for dry-run

```jsonc
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    "CronSchedule": "0 50 * * * *",
    "ContainerPollingSchedule": "0 */2 * * * *",
    "ForceHour": "9",
    "XApiKey": "<any-non-empty-value>",
    "KEYVAULT_URI": "https://<your-keyvault-name>.vault.azure.net/",
    "OpenAI__ApiKey": "<your-openai-key>",
    "OpenAI__Endpoint": "https://api.openai.com/v1/",
    "OpenAI__TextModelName": "gpt-4.1-nano",
    "OpenAI__ImageModelName": "gpt-image-1.5",

    // Reuse the PowerLaw workflow definition (Workflows__PowerLaw__*) and add a dry-run slot:
    "Schedule__2__Hour": "9",
    "Schedule__2__Workflow": "PowerLaw",
    "Schedule__2__Senders__0": "DryRunMaxLength",
    "Schedule__2__Senders__1": "DryRunShortLength"
  }
}
```

`ForceHour` pins the clock to UTC hour 9 in Development (`LocalOverrideTimeProvider`) so the `Schedule__2` slot is selected at startup. Do **not** set `ForceHour` in production — there the slot runs at its natural hour.

### Step-by-step dry-run setup

1. **Start Azurite**
   ```bash
   azurite --silent --location .azurite --debug .azurite/debug.log
   ```

2. **Copy and configure `local.settings.json`**
   ```bash
   cp src/local.settings.json.example src/local.settings.json
   ```
   Fill in `KEYVAULT_URI`, `OpenAI__ApiKey`, the top-level `XApiKey` probe, and uncomment/keep the `Schedule__2` dry-run slot. RSS URLs come from the workflow(s) you schedule (`Workflows__<Workflow>__Nodes__0__Parameters__Urls`).

3. **Start the function**
   ```bash
   cd src && func start
   ```

4. **Observe the logs.** The probe then the per-sender output are logged:
   ```
   [DryRun] Configuration probe succeeded ('XApiKey' is present, length=16)
   [DryRun] Post content (112 chars): "Value of #BTC for the #powerlaw today would be: 123456.78 #USD
   +1.23%"
   [DryRunSender] Dry run complete — no post published.
   ```

5. **Cleanup** — ensure `Schedule__2` (dry-run senders) and `ForceHour` are not copied into production Azure App Settings or `src/local.settings.json.example`.

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

> Prompt templates, temperature, and token budget live in `PromptSteps`, referenced by the workflow nodes through their `StepId` (see [Prompt Steps](#prompt-steps)). Provider settings configure connectivity only.

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

The Azure AI Foundry endpoint is OpenAI-compatible; model names (deployment names) are configured above and referenced by the workflow nodes' `Provider: AzureFoundry`. Prompt templates and generation tuning come from `PromptSteps`.

> See [docs/integrations/setup-azure-foundry.md](integrations/setup-azure-foundry.md) for the full setup guide.

---

## AI — DeepSeek (`AiProvider = DeepSeek`)

Configuration bound from the `DeepSeek` prefix using double-underscore notation.

**Capabilities:** `ITextToTextProvider` ✅ · `ITextToImageProvider` ❌ (text-only — assign `Provider: DeepSeek` on `AiText` nodes only)

| Setting | Type | Required | Default | Description |
|---|---|---|---|---|
| `DeepSeek__ApiKey` | string | ✅ Yes | — | DeepSeek platform API key. |
| `DeepSeek__Endpoint` | string | No | `https://api.deepseek.com` | DeepSeek API base URL. |
| `DeepSeek__TextModelName` | string | No | `deepseek-chat` | Model identifier. |

The DeepSeek endpoint is OpenAI-compatible. Prompt templates and generation tuning come from `PromptSteps`; assign `Provider: DeepSeek` on the workflow's `AiText` nodes (never on an `AiImage` node).

> See [docs/integrations/setup-deepseek.md](integrations/setup-deepseek.md) for the full setup guide.

---

## AI — fal.ai (`AiProvider = FalAi`)

Configuration bound from the `FalAi` prefix using double-underscore notation.

**Capabilities:** `ITextToTextProvider` ❌ · `ITextToImageProvider` ✅ (image-only — assign `Provider: FalAi` on `AiImage` nodes only)

| Setting | Type | Required | Default | Description |
|---|---|---|---|---|
| `FalAi__ApiKey` | string | ✅ Yes | — | fal.ai API key. |
| `FalAi__Endpoint` | string | No | — | fal.ai API base URL. |
| `FalAi__ImageModelName` | string | No | `fal-ai/flux/schnell` | fal.ai model identifier. |
| `FalAi__NumInferenceSteps` | int | No | `4` | Number of diffusion steps. |

> See [docs/integrations/setup-falai.md](integrations/setup-falai.md) for the full setup guide.

---

## AI — Perplexity (`AiProvider = Perplexity`)

Configuration bound from the `Perplexity` prefix using double-underscore notation.

**Capabilities:** `ITextToTextProvider` ✅ · `ITextToImageProvider` ❌ (text-only — assign `Provider: Perplexity` on `AiText` nodes only)

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
