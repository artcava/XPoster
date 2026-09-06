# Extending XPoster

XPoster is designed around three extension points: **Workflows** (content strategies as config-driven node DAGs), **Senders** (platform plugins), and **AI Providers** (model integrations). Each maps to a dedicated abstraction and can be implemented without modifying any existing component:

| Extension point | Abstraction | How it is added |
|---|---|---|
| **Workflow** (content strategy) | Config-declared DAG of keyed `IWorkflowNode` adapters | New `Workflows__<key>` / `PromptSteps__<StepId>` configuration sections — **no code**; custom node logic via a new `IWorkflowNode` (or `ITerminalNode`) + keyed DI registration |
| **Sender** (platform) | `ISender` keyed by `SenderPlatform` | New class + keyed DI registration + enum value + `Schedule` slot |
| **AI Provider** (model) | `ITextToTextProvider` / `ITextToImageProvider` keyed by `AiProvider` | New class + keyed DI registration + enum value + options file |

> For the architectural rationale behind each extension point, see [`architecture.md` §5](architecture.md#5-extension-points) and ADR-006 in [`docs/analysis/`](analysis/).

---

## Adding a New Workflow (Content Strategy)

A workflow is a **directed acyclic graph of nodes** declared in configuration. The DAG engine (`WorkflowExecutionEngine`) runs nodes in topological order; each node is resolved from DI by its `Type` key and acts as an adapter bridging the shared `WorkflowContext` to an infrastructure service (`IFeedService`, AI providers, `ICryptoService`, senders…). The **terminal node** — always a `FanOutSend` in practice but any `ITerminalNode` works — writes the final `SenderPlatform → Post` map into the context under `WorkflowContextKeys.SendResults`.

Most new content strategies are **pure configuration**: no code, no rebuild, no redeploy.

### Step 1 — Define the workflow DAG

Every workflow lives under a `Workflows__<WorkflowKey>` configuration section. The workflow key is what a `Schedule` slot references. Each node is described by:

| Field | Description |
|---|---|
| `Workflows__<key>__Nodes__N__Id` | Unique node id within the workflow. |
| `Workflows__<key>__Nodes__N__Type` | Node type — the keyed `IWorkflowNode` resolution key (`"FetchRss"`, `"AiText"`, `"AiImage"`, `"FanOutSend"`, `"AcquireCryptoValue"`, `"BuildPowerLawPost"`, or your own). |
| `Workflows__<key>__Nodes__N__Parameters__<P>` | Node-specific parameters (see node catalogue below). Values are plain strings; `NodeParameterExtractor` converts them (including JSON-array strings) at runtime. |
| `Workflows__<key>__Nodes__N__OutputKey` | Context key under which the node's output is stored by the engine. |
| `Workflows__<key>__Nodes__N__NextNodeIds__M` | DAG edges. Empty list = the **terminal** node (exactly one required). |

**Built-in node catalogue** (registering each new workflow automatically binds these via `AddWorkflows`):

| `Type` | Adapter (adapter → infra service) | `Parameters` | Output / behaviour |
|---|---|---|---|
| `FetchRss` | `FetchRssNode` → `IFeedService` | `Urls` (JSON-array string) | Concatenated feed content for a 24-hour window, pre-filtered by the tag-replacement keywords. No `Urls` → hard failure. |
| `AiText` | `AiTextNode` → keyed `ITextToTextProvider` | `Provider` (default `OpenAi`), `StepId`, `InputKey` | Generated text; reads the input text from the context under `InputKey`. Throws `InvalidOperationException` if the provider has no text capability. |
| `AiImage` | `AiImageNode` → keyed `ITextToImageProvider` | `Provider`, `StepId`, `InputKey`, `Required` (default `false`) | `MediaAttachment`. Missing image provider always throws; when `Required: false` a failed/empty image is a **soft failure** (workflow continues image-less), when `true` it blocks the workflow. |
| `FanOutSend` | `FanOutSendNode` (**terminal**) | `TextKey`, `FallbackSourceKey`, `StepId`, `MediaKey` | Writes the `SenderPlatform → Post` map under `WorkflowContextKeys.SendResults`. Orders senders by `MessageMaxLength` descending; re-summarises `FallbackSourceKey` at a per-sender character cap (via `StepId`) or truncates. |
| `AcquireCryptoValue` | `AcquireCryptoValueNode` → `ICryptoService` | `Symbol` (default `BTC`) | Live market price (decimal) from crypto service. |
| `BuildPowerLawPost` | `BuildPowerLawPostNode` → `ITimeProvider` | `Symbol`, `ActualValueKey` | Deterministic Power Law fair-value post text (genesis 2009-01-03) plus signed % delta when the actual value is positive. |

A config-only example — a 3-node text-only workflow fanned out to X and LinkedIn:

```jsonc
// src/local.settings.json (add alongside the existing Workflows__* sections)
"Workflows__EtfNews__Nodes__0__Id":                 "fetch-rss",
"Workflows__EtfNews__Nodes__0__Type":               "FetchRss",
"Workflows__EtfNews__Nodes__0__Parameters__Urls":   "[\"https://cointelegraph.com/rss/tag/bitcoin-etf\"]",
"Workflows__EtfNews__Nodes__0__OutputKey":          "sourceContent",
"Workflows__EtfNews__Nodes__0__NextNodeIds__0":     "summarise",

"Workflows__EtfNews__Nodes__1__Id":                 "summarise",
"Workflows__EtfNews__Nodes__1__Type":               "AiText",
"Workflows__EtfNews__Nodes__1__Parameters__Provider": "DeepSeek",
"Workflows__EtfNews__Nodes__1__Parameters__StepId": "Etf.Summary",
"Workflows__EtfNews__Nodes__1__Parameters__InputKey": "sourceContent",
"Workflows__EtfNews__Nodes__1__OutputKey":          "baseSummary",
"Workflows__EtfNews__Nodes__1__NextNodeIds__0":     "fan-out-send",

"Workflows__EtfNews__Nodes__2__Id":                 "fan-out-send",
"Workflows__EtfNews__Nodes__2__Type":               "FanOutSend",
"Workflows__EtfNews__Nodes__2__Parameters__TextKey":          "baseSummary",
"Workflows__EtfNews__Nodes__2__Parameters__FallbackSourceKey": "sourceContent",
"Workflows__EtfNews__Nodes__2__Parameters__StepId":           "Etf.Summary"
```

### Step 2 — Define the prompt steps

Prompt tuning is externalised to the `PromptSteps` section and bound lazily at execution time by `IStepOptionsResolver` (`ConfigurationStepOptionsResolver`). Each `StepId` referenced by an `AiText`/`AiImage`/`FanOutSend` node **must** have a matching `PromptSteps__<StepId>` entry, or execution fails with `InvalidOperationException`:

```jsonc
// src/local.settings.json
"PromptSteps__Etf.Summary__SystemPromptTemplate":    "You are a crypto ETF analyst writing concise summaries.",
"PromptSteps__Etf.Summary__UserPromptTemplate":      "Summarise the following news into {MaxChars} characters:",
"PromptSteps__Etf.Summary__Temperature":             "0.4",
"PromptSteps__Etf.Summary__MaxOutputLength":         "2500",
"PromptSteps__Etf.Summary__ImageQuantity":     "0",
"PromptSteps__Etf.Summary__InputTextLabel":          "News:"
```

Available fields: `SystemPromptTemplate`, `UserPromptTemplate`, `Temperature`, `MaxOutputLength`, `MaxTokenBudget`, `InputTextLabel`, `ImageQuantity`, `ImageSize`.

> The `{MaxChars}` token in a prompt template is replaced with `MaxOutputLength` at call time; `InputTextLabel` defaults to `{Text}`. `AiTextNode`/`AiImageNode` pass the `StepId` you named — the same step can be reused by multiple nodes (e.g. `FanOutSend` re-summarises with `FanOutSend`'s `StepId`, setting `MaxOutputLength` to the target sender's `MessageMaxLength`).

### Step 3 — Schedule the workflow

Attach the workflow to a slot in the `Schedule` section. Every profile resolves as a `WorkflowOrchestrator` driven by the workflow key:

```jsonc
// src/local.settings.json
"Schedule__3__Hour":       "13",
"Schedule__3__Workflow":   "EtfNews",
"Schedule__3__Senders__0": "X",
"Schedule__3__Senders__1": "LinkedIn"
```

For local integration testing, use the dry-run senders instead (they probe the configuration for a non-empty top-level `XApiKey` and log the post without publishing):

```jsonc
"Schedule__4__Hour":       "14",
"Schedule__4__Workflow":   "EtfNews",
"Schedule__4__Senders__0": "DryRunMaxLength",
"Schedule__4__Senders__1": "DryRunShortLength"
```

No profile-provider code exists to update: `ConfigurationSlotProfileProvider` reads the `Schedule` section at runtime. Adding, changing, or removing a slot is a configuration-only change.

> Structural validation runs at **startup** (`AddWorkflows` throws for missing node references, cycles, or anything other than exactly one terminal node) and again at every execution; the terminal node's `ITerminalNode` contract is verified at execution time when the instance is resolved via DI.

### Step 4 (optional) — Add a custom node type

If no built-in node fits, write an adapter node. A node receives a `WorkflowNodeInput` (the thread-safe `WorkflowContext`, its untyped `Parameters`, and the slot's `IReadOnlyList<ISender>`) and returns a `WorkflowNodeResult(bool Success, object? Output, string? ErrorMessage)`. The engine stores a successful `Output` into the context under the node's `OutputKey`.

```csharp
// src/Workflows/Nodes/MarketTickerNode.cs
using XPoster.Workflows.Abstractions;
using XPoster.Workflows.Utilities;

public sealed class MarketTickerNode : IWorkflowNode
{
    public string NodeType => "MarketTicker";            // must match the config "Type"

    private readonly IMarketDataService _marketData;       // your service (constructor injection)

    public MarketTickerNode(IMarketDataService marketData) => _marketData = marketData;

    public async Task<WorkflowNodeResult> ExecuteAsync(WorkflowNodeInput input, CancellationToken ct)
    {
        var symbols = NodeParameterExtractor.GetParameter<List<string>>(input.Parameters, "Symbols");
        var ticker = await _marketData.GetTickerAsync(symbols, ct);

        if (ticker is null)
            return new WorkflowNodeResult(false, null, "Ticker data was empty.");

        return new WorkflowNodeResult(true, ticker, null);   // engine stores it under OutputKey
    }
}
```

Register it as a keyed node alongside the built-ins in `AddWorkflows` (`src/Workflows/Configuration/WorkflowServiceCollectionExtensions.cs`):

```csharp
services.AddKeyedTransient<IWorkflowNode, MarketTickerNode>("MarketTicker");
```

Then reference it from any workflow DAG with `"Workflows__<key>__Nodes__N__Type": "MarketTicker"`.

A **custom terminal node** implements `ITerminalNode` and is the one node that writes the dispatch map itself:

```csharp
// src/Workflows/Nodes/QuoteFanOutNode.cs
using XPoster.Contracts;
using XPoster.Workflows.Abstractions;
using XPoster.Workflows.Models;
using XPoster.Workflows.Utilities;

public sealed class QuoteFanOutNode : ITerminalNode
{
    public string NodeType => "QuoteFanOut";

    public Task<WorkflowNodeResult> ExecuteAsync(WorkflowNodeInput input, CancellationToken ct)
    {
        var textKey = NodeParameterExtractor.GetParameter<string>(input.Parameters, "TextKey");
        var text = input.Context.GetData<string>(textKey);

        var post = new Post { Content = text };
        var postsByPlatform = input.Senders
            .ToDictionary(s => s.Platform, _ => (Post?)post);

        input.Context.SetData(WorkflowContextKeys.SendResults, postsByPlatform);
        return Task.FromResult(new WorkflowNodeResult(true, null, null));
    }
}
```

---

## Adding a New Sender (Platform)

A sender is a class that implements `ISender` and knows how to publish a `Post` to a specific social network. It owns all platform-specific concerns: authentication, payload serialisation, rate-limit handling, and error mapping.

```csharp
// src/Contracts/Interfaces/ISender.cs
public interface ISender
{
    SenderPlatform Platform { get; }        // routing key in the post dispatch map
    int MessageMaxLength { get; }           // platform character limit
    Task<bool> SendAsync(Post post, CancellationToken ct = default);
}
```

Sender credentials are loaded from Azure Key Vault at application startup via the Key Vault Configuration Provider and injected through `IOptions<TCredentials>` — no Key Vault calls occur at publish time.

### Step 1 — Add the credentials DTO + validation

Create the DTO with its `SectionName` and a validator in `src/Credentials/`:

```csharp
// src/Credentials/TikTokCredentials.cs
namespace XPoster.Credentials;

public class TikTokCredentials
{
    public const string SectionName = "TikTokCredentials";

    public string TikTokAccessToken { get; init; } = string.Empty;
    public string TikTokClientKey   { get; init; } = string.Empty;
}
```

```csharp
// src/Credentials/TikTokCredentialsValidator.cs
using Microsoft.Extensions.Options;

namespace XPoster.Credentials;

public class TikTokCredentialsValidator : IValidateOptions<TikTokCredentials>
{
    public ValidateOptionsResult Validate(string? name, TikTokCredentials options)
    {
        var failures = new List<string>();

        if (string.IsNullOrWhiteSpace(options.TikTokAccessToken))
            failures.Add($"{nameof(TikTokCredentials.TikTokAccessToken)} is required.");

        if (string.IsNullOrWhiteSpace(options.TikTokClientKey))
            failures.Add($"{nameof(TikTokCredentials.TikTokClientKey)} is required.");

        return failures.Count > 0
            ? ValidateOptionsResult.Fail(failures)
            : ValidateOptionsResult.Success;
    }
}
```

Register the binding and validator in the existing `AddCredentials` extension method (`src/Credentials/CredentialsExtensions.cs`) — do **not** create a separate registration path:

```csharp
services
    .AddOptions<TikTokCredentials>()
    .Bind(configuration.GetSection(TikTokCredentials.SectionName));

services.AddSingleton<IValidateOptions<TikTokCredentials>, TikTokCredentialsValidator>();
```

`CredentialsStartupValidator` aggregates all credential sections on `Validate()` and throws an `InvalidOperationException` at startup listing every missing property — the app fails fast instead of failing at publish time.

> The Key Vault Configuration Provider maps secret names to `IConfiguration` keys using the Azure SDK default convention: a secret named `TikTokCredentialsTikTokAccessToken` is available as `TikTokCredentials--TikTokAccessToken`. `SectionName` is the prefix that ties secret names to the credentials DTO.

### Step 2 — Implement ISender

```csharp
// src/SenderPlugins/TikTokSender.cs
using Microsoft.Extensions.Options;
using XPoster.Contracts;
using XPoster.Credentials;

public class TikTokSender : ISender
{
    private readonly TikTokCredentials _credentials;
    private readonly ILogger<TikTokSender> _logger;

    public TikTokSender(IOptions<TikTokCredentials> credentials, ILogger<TikTokSender> logger)
    {
        ArgumentNullException.ThrowIfNull(credentials);
        ArgumentNullException.ThrowIfNull(logger);

        _credentials = credentials.Value;
        _logger = logger;
    }

    public SenderPlatform Platform => SenderPlatform.TikTok;

    public int MessageMaxLength => 150;

    public async Task<bool> SendAsync(Post post, CancellationToken ct = default)
    {
        if (post is null)
        {
            _logger.LogWarning("[TikTokSender] Received null post — skipping.");
            return false;
        }

        // Use _credentials.TikTokAccessToken and _credentials.TikTokClientKey here.
        // Return false (do not throw) on non-fatal platform errors.
        return true;
    }
}
```

> `MessageMaxLength` must reflect the platform's actual character limit. `FanOutSendNode` reads this value from each resolved sender to order them (descending, widest first) and to decide whether to re-summarise the text for a given platform. An incorrect value leads to content that is too long or wastes character budget.

### Step 3 — Register the sender in DI

Add a keyed registration in `AddXPosterSenderPlugins` (`src/Extensions/SenderPluginsServiceCollectionExtensions.cs`):

```csharp
// TikTok sender plugin
services.AddKeyedTransient<ISender, TikTokSender>(SenderPlatform.TikTok);
```

### Step 4 — Add the SenderPlatform enum value

Append a value to `SenderPlatform` (`src/Contracts/Enums/SenderPlatform.cs`). Each value maps to exactly one sender class, independent of which workflow produces the content:

```csharp
public enum SenderPlatform
{
    // existing values ...
    TikTok,
}
```

`SenderPlatform` represents **where** to publish. It is orthogonal to the workflow (what content strategy to use), so a single `TikTok` value is referenced by any `Schedule` slot that targets TikTok.

### Step 5 — Add the secrets to Key Vault

Add one secret per credentials property, using the `{SectionName}--{PropertyName}` naming convention:

```bash
az keyvault secret set --vault-name <your-keyvault-name> --name TikTokCredentials--TikTokAccessToken --value "<value>"
az keyvault secret set --vault-name <your-keyvault-name> --name TikTokCredentials--TikTokClientKey   --value "<value>"
```

For local development only, set them in `src/local.settings.json` using the double-underscore separator:

```jsonc
"TikTokCredentials__TikTokAccessToken": "<local-dev-value>",
"TikTokCredentials__TikTokClientKey":   "<local-dev-value>"
```

> Do not add social-platform credentials to `src/local.settings.json.example`. Use Key Vault for all non-local environments.

### Step 6 — Wire the new platform into a Schedule slot

There is nothing to wire in the factory. `OrchestratorFactory.ResolveSenders` resolves each `profile.SenderPlatform` through `GetKeyedService<ISender>(platform)`, so the new platform works the moment the enum value and registration exist:

```csharp
// src/Orchestrators/OrchestratorFactory.cs — ResolveSenders helper (no change needed)
var sender = _serviceProvider.GetKeyedService<ISender>(platform);
return sender == null ? Array.Empty<ISender>() : new[] { sender };
```

Reference the platform from any slot (the slot's workflows fan out to every configured sender):

```jsonc
"Schedule__5__Hour":       "15",
"Schedule__5__Workflow":   "EtfNews",
"Schedule__5__Senders__0": "TikTok",
"Schedule__5__Senders__1": "X"
```

> The order of `Senders__N` values is irrelevant — `FanOutSendNode` sorts senders by `MessageMaxLength` descending at runtime.

---

## Adding a New AI Provider

The AI layer uses two capability interfaces — `ITextToTextProvider` and `ITextToImageProvider` — registered as **keyed services** by `AiProvider`. Selection is a **per-node** decision: `AiTextNode` / `AiImageNode` read the `Provider` parameter and resolve `GetKeyedService<T>(provider)` at execution time, so a single workflow can mix providers per node (e.g. DeepSeek for the summary, FalAi for the image). There is no factory class or switch expression to modify.

### Capability model

A provider can implement one or both capability interfaces:

| Provider | `ITextToTextProvider` | `ITextToImageProvider` |
|---|---|---|
| `OpenAi` | ✓ | ✓ |
| `AzureFoundry` | ✓ | ✓ |
| `DeepSeek` | ✓ | ✗ |
| `Perplexity` | ✓ | ✗ |
| `FalAi` | ✗ | ✓ |

`null` keyed resolution is **intentional**: a node that names a provider without the matching capability throws `InvalidOperationException` at the point of use (e.g. `ITextToTextProvider for 'FalAi' is not registered.`) rather than silently degrading. Use `AiImage Required: false` to tolerate a *failed image call*, not a missing capability.

### Step 1 — Add the Enum Value

Append a new value to `AiProvider` (`src/Contracts/Enums/AiProvider.cs`). Assign an explicit integer to avoid renumbering existing values, and add a `[Description]` attribute if the display label differs from the enum name:

```csharp
public enum AiProvider
{
    None         = 0,
    OpenAi       = 1,
    Perplexity   = 2,
    AzureFoundry = 3,
    DeepSeek     = 4,
    FalAi        = 5,
    [Description("Anthropic")]
    Anthropic    = 6,  // new
}
```

### Step 2 — Implement the Capability Interface(s)

Provider methods receive typed value objects (`PromptRequest` / `ImagePromptRequest`) constructed by the AI nodes. Providers must not impose any prompt-shaping logic; they execute the request as supplied — prompt intent lives in the nodes via `PromptSteps` configuration.

**Text + Image provider** (e.g. Anthropic supports both):

```csharp
// src/Services/Ai/AnthropicService.cs
public class AnthropicService : ITextToTextProvider, ITextToImageProvider
{
    public async Task<string> GenerateTextAsync(PromptRequest request, CancellationToken ct = default)
    {
        // Use request.SystemPromptTemplate, request.UserPromptTemplate,
        // request.InputText, request.Temperature, request.MaxOutputLength, etc.
        // Call Anthropic Messages API for text generation.
        return generatedText;
    }

    public async Task<byte[]> GenerateImageAsync(ImagePromptRequest request, CancellationToken ct = default)
    {
        // Use request.SystemPromptTemplate, request.UserPromptTemplate,
        // request.InputText, request.ImageQuantity, request.ImageSize, etc.
        return imageBytes;
    }
}
```

**Text-only provider** (no image model):

```csharp
// src/Services/Ai/MyTextOnlyService.cs
public class MyTextOnlyService : ITextToTextProvider
{
    public async Task<string> GenerateTextAsync(PromptRequest request, CancellationToken ct = default)
    {
        // Execute the text-to-text step using request fields.
    }
    // No GenerateImageAsync — ITextToImageProvider is not implemented.
    // Nodes naming this provider for AI image generation throw InvalidOperationException — intentional.
}
```

**Image-only provider** (specialised diffusion model):

```csharp
// src/Services/Ai/MyImageOnlyService.cs
public class MyImageOnlyService : ITextToImageProvider
{
    public async Task<byte[]> GenerateImageAsync(ImagePromptRequest request, CancellationToken ct = default)
    {
        // Execute the image generation step using request fields.
    }
    // No GenerateTextAsync — ITextToTextProvider is not implemented.
}
```

### Step 3 — Register as Keyed Services

Add the keyed registrations in `AddXPosterAiProviders` (`src/Extensions/AiProviderServiceCollectionExtensions.cs`). Register only the interfaces the service actually implements:

```csharp
// Text + Image provider
services.AddKeyedTransient<ITextToTextProvider,  AnthropicService>(AiProvider.Anthropic);
services.AddKeyedTransient<ITextToImageProvider, AnthropicService>(AiProvider.Anthropic);

// Text-only provider
services.AddKeyedTransient<ITextToTextProvider, MyTextOnlyService>(AiProvider.MyTextOnly);
// No ITextToImageProvider registration — GetKeyedService returns null for this key

// Image-only provider
services.AddKeyedTransient<ITextToImageProvider, MyImageOnlyService>(AiProvider.MyImageOnly);
// No ITextToTextProvider registration — GetKeyedService returns null for this key
```

No switch expression, no factory class, and no `_supportedProviders` set to maintain. The keyed DI registration is the single source of truth for capability availability. Never add keyed AI registrations outside `AddXPosterAiProviders`.

### Step 4 — Add the Options Class

Every AI provider **must** ship an `*Options.cs` file alongside its `*OptionsValidator.cs` in `src/Models/<ProviderName>/` — the single source of truth for the configuration section key:

```
src/Models/
  Anthropic/
    AnthropicOptions.cs
    AnthropicOptionsValidator.cs
```

`AnthropicOptions` declares `SectionName = "Anthropic"`. Register it in `AddAiProviderOptions` (`src/Extensions/AiProviderOptionsCompositionExtensions.cs`), the single entry point `Program.cs` uses for AI option wiring:

```csharp
services.Configure<AnthropicOptions>(configuration.GetSection(AnthropicOptions.SectionName));
services.AddSingleton<IValidateOptions<AnthropicOptions>, AnthropicOptionsValidator>();
```

Add the corresponding configuration section using `SectionName` as the prefix (`Anthropic__Endpoint`, `Anthropic__ApiKey`, …). Then point any `AiText`/`AiImage` node at it with `Parameters__Provider: "Anthropic"`.

---

## Design Constraints

All extensions must respect the following invariants to integrate correctly with the pipeline:

- **Senders must be stateless.** Do not cache authentication tokens in instance fields; inject them via `IOptions<TCredentials>` (bound at startup from Key Vault via the Configuration Provider). The DI container manages lifetime.
- **`SendAsync` must return `false`, not throw, on non-fatal platform errors.** Throwing from a sender propagates the exception to `XFunction` and prevents App Insights from recording a clean skip.
- **`MessageMaxLength` must be accurate.** `FanOutSendNode` reads this value to order senders (widest limit first) and to decide whether to re-summarise content per platform. An incorrect value causes content that is either silently truncated at the platform layer or wastes character budget on secondary re-summarisation.
- **Every workflow must have exactly one terminal node** (a node with empty `NextNodeIds`) that implements `ITerminalNode` and writes `WorkflowContextKeys.SendResults`. Dangling node references, cycles, and multiple/zero terminals are rejected at startup by `AddWorkflows`.
- **Node identifiers must be unique within a workflow**, and `Workflows__<key>__Nodes__N__Type` must be a keyed `IWorkflowNode` whose `NodeType` matches — otherwise execution fails with `No IWorkflowNode registered with key '<Type>'.`
- **Nodes return values, they don't mutate the context to store their output.** Return a successful `WorkflowNodeResult` with the `Output` set; the engine stores it under `OutputKey`. Context reads use `WorkflowContext.GetData<T>` / `TryGetData<T>`; writes to `Workflow.SendResults` are the terminal node's job.
- **`NodeParameterExtractor` is the canonical parameter reader.** Node parameters arrive as configuration strings (or `JsonElement`s); use `GetParameter<T>(input.Parameters, "Key", default)` to convert them — including JSON-array strings like `Urls`.
- **Every `StepId` referenced by an AI node must exist under `PromptSteps`**, or execution fails with `InvalidOperationException`. Configure `{MaxChars}` and `InputTextLabel` in the step to shape the prompt.
- **An AI node's `Provider` must have the matching capability.** `AiText` needs an `ITextToTextProvider`; `AiImage` needs an `ITextToImageProvider`. A missing capability throws — do not "stub" an interface you don't support.
- **`AiImage Required` governs failure, not capability.** `Required: false` (default) lets a *failed/empty image call* soft-fail; a missing image provider throws regardless.
- **AI provider services must implement only the capability interfaces they actually support.** Do not implement `ITextToImageProvider` on a text-only provider as a no-op or `NotSupportedException` stub — leave the interface unimplemented and omit the keyed DI registration. The `null`-resolution contract is the canonical signal for "capability not available".
- **Keyed AI provider registrations live exclusively in `AddXPosterAiProviders()`.** Never add `AddKeyedTransient<ITextToTextProvider, ...>` or `AddKeyedTransient<ITextToImageProvider, ...>` calls outside that method.
- **All external HTTP calls must go through `IHttpClientFactory` named clients** registered in `AddHttpClients` (`HttpClientExtensions`). This ensures connection pooling and the Polly resilience pipeline (retry, circuit breaker, attempt timeout, HTTP 429/5xx handling). Creating `new HttpClient()` inline is prohibited; new outbound integrations add a named client instead.
- **Every new sender must be registered through the existing `AddCredentials` extension method** (`src/Credentials/CredentialsExtensions.cs`), declaring `SectionName` on the credentials DTO. `Program.cs` must use only the extension methods — never raw `Configure<T>` + `GetSection("...")` literals for credentials.
- **Every new AI provider must ship an `*Options.cs` file** in `src/Models/<ProviderName>/` declaring `SectionName` and register through `AddAiProviderOptions`. `Program.cs` must use only the extension method.
- **New platforms and workflows are config-only additions.** Never hard-code a `ScheduledOrchestrationProfile` or a workflow DAG in code; `ConfigurationSlotProfileProvider` and `AddWorkflows` read the `Schedule` / `Workflows` / `PromptSteps` sections at runtime/startup.
- **Dry-run slots are just `Schedule` slots with dry-run senders.** They verify AI + workflow wiring locally without publishing. The dry-run probe requires a non-empty top-level `XApiKey` in configuration (as delivered by the Key Vault Configuration Provider).
- **Never require an image for a platform that cannot display one** — image posts target Instagram/Facebook container flows; keep `AiImage` optional unless every fan-out sender supports media.
- See [`architecture.md`](architecture.md) for full ADRs and design-pattern rationale, and [`configuration.md`](configuration.md) for the canonical `Workflows__*`, `PromptSteps__*`, and `Schedule` example.