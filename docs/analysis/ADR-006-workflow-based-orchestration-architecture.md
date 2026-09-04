# ADR 006: Workflow-Based DAG Orchestration Architecture

## Status

**Accepted** — Implemented in the ADR-006 series. Replaces the
lettered revision documents `ADR-006-a` … `ADR-006-g` in `docs/analysis/`.
Covers the final architecture including the PowerLaw-to-DAG conversion
(issue #269) and config-driven scheduling (issue #270).

## Context

The pre-ADR architecture relied on a rigid, monolithic orchestrator hierarchy
(`FeedOrchestrator`, `PowerLawOrchestrator`, `NoOrchestrator`). Each slot was
bound to a concrete class that hardcoded execution order, AI invocations,
context-key names and target channels. The `OrchestratorFactory` resolved
orchestrators via reflection (`Activator.CreateInstance`).

### Limitations identified

1. **Tight coupling to enums and proprietary contexts** — `FeedOrchestrator`
   depended on `FeedOrchestratorContext` and the `PromptRole` enum
   (`Summary`, `ImagePromptDerivation`, `ImageGeneration`). New steps meant
   extending enums and recompiling core code.
2. **AI providers as keyed services** — `Program.cs` registers AI providers
   via `AddXPosterAiProviders()`. A rigid node could not select a provider
   (`OpenAi`, `AzureFoundry`, `DeepSeek`, `FalAi`, `Perplexity`) per step from
   JSON configuration.
3. **Payload type rigidity** — `Post` assumed media were exclusively `byte[]`
   image arrays; no abstraction for text-only, video, or multi-media posts.
4. **Hardcoded variable keys** — steps assumed fixed keys (e.g.
   `"sourceContent"`, `"sendResults"`), preventing node reuse across pipelines
   (RSS feeds, calculation engines, webhooks).
5. **No DAG / parallel branching** — the sequential model could not express
   parallel branches or senders with different `MessageMaxLength` requiring
   per-sender re-summarisation.
6. **No integration point** — the reflection-based `OrchestratorFactory` had no
   seam for a workflow engine without replacing/wrapping it.
7. **Parameter deserialisation weakness** — `IConfiguration` binds JSON arrays
   as `JsonElement` inside `Dictionary<string, object>`; naive casts caused
   runtime `InvalidCastException`s.
8. **Media coupling** — nodes assumed byte-array images, coupling node logic to
   one media kind.

### Legacy components (all removed by this ADR)

| Component | File |
|---|---|
| `IOrchestrator` / `BaseOrchestrator` | `src/Contracts/Interfaces/IOrchestrator.cs`, `src/Orchestrators/BaseOrchestrator.cs` (kept) |
| `FeedOrchestrator` | `src/Orchestrators/FeedOrchestrator.cs` (removed) |
| `PowerLawOrchestrator` | `src/Orchestrators/PowerLawOrchestrator.cs` (removed) |
| `OrchestratorFactory` | `src/Orchestrators/OrchestratorFactory.cs` (simplified) |
| `FeedOrchestratorContext` | `src/Models/FeedOrchestratorContext.cs` (removed) |
| `FeedPromptOptions` / `PromptRole` | `src/Models/FeedPromptOptions.cs`, `src/Models/PromptRole.cs` (deprecated/removed) |
| `DefaultSlotProfileProvider` | `src/Providers/DefaultSlotProfileProvider.cs` (removed) |
| `DryRunSlotProfileProvider` | `src/Providers/DryRunSlotProfileProvider.cs` (removed) |
| `FeedSlotContexts__*` config | legacy (removed) |

---

## Critical requirement — preserve fan-out with length-aware re-summarisation

The existing `FeedOrchestrator` behaviour is a hard constraint and must be
preserved:

1. Senders are ordered by `MessageMaxLength` **descending**; the widest sender
   receives the base summary.
2. A single image is generated per execution and attached to every post.
3. Each sender either **reuses** the current summary or **re-summarises the
   original source content** (not the previous sender's variant) when the text
   exceeds its `MessageMaxLength`.
4. Tag replacement is applied to the final text per sender.
5. Posts are assembled and dispatched by platform.

Rationale: *Quality* (best model output for the widest target), *Efficiency*
(one model call per unique length), *Correctness* (re-summarise from the
original source, never from an already-truncated variant), *Image consistency*
(one image, attached to every post).

The `FanOutSendNode` below is the generalised form of this behaviour.

---

## Decision

Adopt a **Workflow Engine based on a Directed Acyclic Graph (DAG)** while
leaving the business logic of the infrastructure services
(`IFeedService`, `OpenAiService`, `ITagReplacementService`,
`ICryptoService`, `ITimeProvider`, AI providers) completely intact.
Workflow nodes are **Adapters**: they bridge a thread-safe `WorkflowContext`
to existing services, parsing parameters via `NodeParameterExtractor` and
resolving prompt configuration via `IStepOptionsResolver`.

### Architectural principles

1. **Zero breaking changes to infrastructure services** — all services
   registered in `Program.cs` remain untouched.
2. **`PromptRole`/`FeedOrchestratorContext` deprecation** — prompt
   configuration is resolved from the `PromptSteps:{StepId}` section via
   `IStepOptionsResolver`; step ids are strings, not enum values.
3. **Media-agnostic abstraction** — `MediaAttachment` supports images, videos,
   and documents; `FanOutSendNode` bridges `MediaAttachment.Data` to the
   legacy `Post.Image` byte array so `Post` is never modified.
4. **Decoupling via dynamic keys** — nodes read/write context keys declared as
   parameters (`InputKey`, `OutputKey`, `TextKey`, `MediaKey`,
   `FallbackSourceKey`, `ActualValueKey`).
5. **Thread-safe context isolation** — `WorkflowContext` is backed by
   `ConcurrentDictionary`; safe for parallel branch execution.
6. **Dynamic resolution via keyed services** — node types and AI providers are
   resolved with .NET keyed services (`.NET 8+ Keyed DI`).
7. **One terminal node per DAG** — every workflow has exactly one terminal node
   implementing `ITerminalNode` that writes `WorkflowContextKeys.SendResults`;
   enforced by `WorkflowDefinitionValidator`.
8. **Config-driven scheduling** — the whole orchestration schedule
   (hour → workflow → senders) is data-driven (`Schedule` section), so new
   workflows can be scheduled at any hour with no code change.
9. **Media presence derived from the DAG** — `WorkflowOrchestrator.ProduceImage`
   is `true` iff the workflow contains an `AiImage` node.

---

## Detailed component specifications

### 1. Engine contracts — `IWorkflowNode`, `ITerminalNode`, input/result

```csharp
namespace XPoster.Workflows.Abstractions;

public record WorkflowNodeInput(
    IWorkflowContext Context,
    IReadOnlyDictionary<string, object> Parameters,
    IReadOnlyList<ISender> Senders);

public record WorkflowNodeResult(
    bool Success,
    object? Output,
    string? ErrorMessage);

public interface IWorkflowNode
{
    string NodeType { get; }
    Task<WorkflowNodeResult> ExecuteAsync(WorkflowNodeInput input, CancellationToken ct);
}

// Terminal marker: the node responsible for writing WorkflowContextKeys.SendResults.
public interface ITerminalNode : IWorkflowNode { }
```

### 2. Thread-safe context, media model, standardised keys

```csharp
namespace XPoster.Workflows.Models;

public enum MediaType { Image, Video, Document }

public record MediaAttachment(byte[] Data, MediaType Type, string MimeType, string FileName);

public static class WorkflowContextKeys
{
    public const string SendResults = "Workflow.SendResults";
}

public interface IWorkflowContext
{
    string SlotKey { get; }
    T GetData<T>(string key);
    bool TryGetData<T>(string key, out T? value);
    void SetData(string key, object value);
    bool HasData(string key);
}

public class WorkflowContext : IWorkflowContext
{
    public required string SlotKey { get; init; }
    private readonly ConcurrentDictionary<string, object> _data = new();
    public T GetData<T>(string key) { /* throws KeyNotFoundException on miss */ }
    public bool TryGetData<T>(string key, out T? value) { /* safe read */ }
    public void SetData(string key, object value) => _data[key] = value;
    public bool HasData(string key) => _data.ContainsKey(key);
}
```

`WorkflowContextKeys.SendResults` replaces the fragile `"sendResults"` magic
string: the terminal node writes a `Dictionary<SenderPlatform, Post?>` under
this key, which is the *standardised output contract* consumed by the
orchestrator bridge.

### 3. `NodeParameterExtractor`

Heuristic conversion from configuration values (often `JsonElement`) to
strongly-typed parameters:

```csharp
namespace XPoster.Workflows.Utilities;

public static class NodeParameterExtractor
{
    public static T GetParameter<T>(IReadOnlyDictionary<string, object> parameters,
        string key, T defaultValue = default!);
    // Steps: direct cast → JsonElement deserialisation → Convert.ChangeType fallback.
    public static AiProvider GetProvider(IReadOnlyDictionary<string, object> parameters);
        // Reads "Provider" (default OpenAi) and maps the enum name.
}
```

### 4. `IStepOptionsResolver` — string-keyed prompt configuration

```csharp
namespace XPoster.Workflows.Services;

public interface IStepOptionsResolver
{
    PromptStepOptions Resolve(string stepId);
}

public sealed class ConfigurationStepOptionsResolver : IStepOptionsResolver
{
    public PromptStepOptions Resolve(string stepId)
        => _configuration.GetSection($"PromptSteps:{stepId}").Get<PromptStepOptions>()
        ?? throw new InvalidOperationException($"PromptStepOptions missing for StepId: '{stepId}'.");
}
```

`PromptStepOptions` (workflow-engine variant; no `Role`):

```csharp
namespace XPoster.Workflows.Models;

public sealed record PromptStepOptions
{
    public required string SystemPromptTemplate { get; init; }
    public required string UserPromptTemplate { get; init; }
    public double? Temperature { get; init; }
    public int? MaxOutputLength { get; init; }
    public int? MaxTokenBudget { get; init; }
    public string? InputTextLabel { get; init; }
    public int? ImageQuantity { get; init; }
    public string? ImageSize { get; init; }
}
```

### 5. Workflow definition, engine, and DAG validation

```csharp
namespace XPoster.Workflows.Engine;

public record WorkflowNodeDefinition(
    string Id,
    string Type,
    Dictionary<string, object> Parameters,
    string? OutputKey,
    List<string> NextNodeIds);

public record WorkflowDefinition(string SlotKey, List<WorkflowNodeDefinition> Nodes);

public record WorkflowExecutionResult(bool Success, IWorkflowContext Context, string? ErrorMessage);

public interface IWorkflowEngine
{
    Task<WorkflowExecutionResult> ExecuteAsync(WorkflowDefinition definition,
        IReadOnlyList<ISender> senders, CancellationToken ct);
}
```

`WorkflowExecutionEngine` executes nodes in **topological order (Kahn's
algorithm)** after validation. Independent ready nodes are queued; true
parallel execution can be added as a future enhancement by batching the queue
with `Task.WhenAll` — the thread-safe context already supports it.

**`WorkflowDefinitionValidator`** (static) enforces the DAG invariants:

```csharp
namespace XPoster.Workflows.Engine;

public static class WorkflowDefinitionValidator
{
    // Runs at registration time (AddWorkflows throws InvalidOperationException when invalid):
    //   1. every NextNodeIds reference exists;
    //   2. no cycles (DFS);
    //   3. exactly one terminal node (a node with empty NextNodeIds).
    public static string? ValidateStructural(WorkflowDefinition definition);

    // Runs at execution time: the uniquely-terminal node must implement ITerminalNode.
    public static string? ValidateTerminalNodeContract(WorkflowDefinition definition,
        IServiceProvider serviceProvider);
}
```

### 6. Adapter nodes

All adapter nodes are registered as keyed `IWorkflowNode` instances and read
their parameters from configuration via `NodeParameterExtractor`.

#### A. `FetchRssNode` (`"FetchRss"`) — adapter for `IFeedService`
- Parameters: `Urls` (JSON array string), optional date window.
- Reads RSS content for the last 24h, filters by tag-replacement keywords,
  returns the concatenated text under `OutputKey` (e.g. `"sourceContent"`).
- Hard-fails when no content is retrieved.

#### B. `AiTextNode` (`"AiText"`) — adapter for keyed `ITextToTextProvider`
- Parameters: `Provider` (default `"OpenAi"`), `StepId`, `InputKey`.
- Resolves `stepOptions = IStepOptionsResolver.Resolve(stepId)` and calls the
  provider's `GenerateTextAsync`, storing the result under `OutputKey`.
- Hard-fails on empty/whitespace output.

#### C. `AiImageNode` (`"AiImage"`) — adapter for keyed `ITextToImageProvider`
- Parameters: `Provider`, `StepId`, `InputKey`, **`Required`** (default `false`).
- `Required=false` → **soft failure**: empty output returns success with no
  media; the workflow continues and the post is published without an image.
- `Required=true` → **hard failure**: empty output blocks the workflow.
- Success produces a `MediaAttachment(Image, "image/png", "generated_image.png")`
  stored under `OutputKey` (e.g. `"attachedMedia"`).

#### D. `FanOutSendNode` (`"FanOutSend"`) — terminal, adapter for keyed
`ITextToTextProvider` + `ITagReplacementService`
- Implements `ITerminalNode`; parameters: `TextKey`, `FallbackSourceKey?`,
  `MediaKey?`, `StepId?`, `Provider?` (default `OpenAi`).
- Behaviour (preserves the critical requirement):
  1. orders senders by `MessageMaxLength` descending;
  2. if `primaryText.Length <= sender.MessageMaxLength` → reuse primary text;
  3. else, when `FallbackSourceKey`+`StepId` are present, **re-summarises the
     original fallback source** via the keyed text provider with
     `MaxOutputLength = sender.MessageMaxLength` (truncates if no provider);
  4. else truncates to `sender.MessageMaxLength`;
  5. applies `_tagReplacementService.Apply(text)` per sender;
  6. bridges `MediaAttachment.Data` → `Post.Image` (byte array) without
     modifying `Post`;
  7. writes `Dictionary<SenderPlatform, Post?>` to `WorkflowContextKeys.SendResults`.

#### E. `AcquireCryptoValueNode` (`"AcquireCryptoValue"`) — adapter for `ICryptoService` (issue #269)
```csharp
public sealed class AcquireCryptoValueNode : IWorkflowNode
{
    public string NodeType => "AcquireCryptoValue";
    private readonly ICryptoService _cryptoService;

    public async Task<WorkflowNodeResult> ExecuteAsync(WorkflowNodeInput input, CancellationToken ct)
    {
        var symbol = NodeParameterExtractor.GetParameter<string>(input.Parameters, "Symbol", "BTC");
        var actualValue = await _cryptoService.GetCryptoValue(symbol);
        return new WorkflowNodeResult(true, actualValue, null);
    }
}
```
Stores the live price under `OutputKey` (e.g. `"PowerLaw.ActualValue"`).
`Symbol` is a node parameter, so any crypto is reusable by changing config.

#### F. `BuildPowerLawPostNode` (`"BuildPowerLawPost"`) — deterministic post (issue #269)
```csharp
public sealed class BuildPowerLawPostNode : IWorkflowNode
{
    public static readonly DateTime Genesis = new(2009, 1, 3);
    public string NodeType => "BuildPowerLawPost";
    private readonly ITimeProvider _timeProvider;

    public async Task<WorkflowNodeResult> ExecuteAsync(WorkflowNodeInput input, CancellationToken ct)
    {
        var symbol = NodeParameterExtractor.GetParameter<string>(input.Parameters, "Symbol", "BTC");
        var actualValueKey = NodeParameterExtractor.GetParameter<string>(input.Parameters, "ActualValueKey");
        var tag = "#" + symbol.ToUpperInvariant();

        var date = _timeProvider.GetCurrentTime().Date;
        if (date <= Genesis)
            return new WorkflowNodeResult(false, null,
                $"Invalid date: {date:d} is on or before the Power Law genesis block.");

        var days = (date - Genesis).Days;
        var fairValue = Math.Pow(10, -17) * Math.Pow(days, 5.83d);

        var content = $"Value of {tag} for the #powerlaw today would be: {fairValue:F2} #USD";

        if (input.Context.TryGetData<decimal>(actualValueKey, out var actualValue) && actualValue > 0)
            content += $"\n{100.00m - (actualValue / (decimal)fairValue * 100):+0.00;-0.00}%";

        return new WorkflowNodeResult(true, content, null);
    }
}
```
Guards `date > 2009-01-03`, computes the Santostasi power-law fair value
(`10^-17 · days^5.83`) and appends the signed percentage delta vs. the live
price read from context via `ActualValueKey` (e.g. `"PowerLaw.ActualValue"`).
Writes the post text under `OutputKey` (`"PowerLaw.PostText"`).

#### Future node types (catalog from ADR-006-a, not yet implemented)
`FetchHttpNode` (generic HTTP/RSS/MCP), `DatabaseQueryNode`, `TransformNode`
(e.g. `TransformType: "PostComposer"`), `ConditionalNode`, `SendNode` — the
engine, context, and keyed-DI infrastructure support them without changes.

### 7. `WorkflowOrchestrator` — bridge between `IOrchestrator` and `IWorkflowEngine`

```csharp
public class WorkflowOrchestrator : BaseOrchestrator
{
    public override string Name => "WorkflowOrchestrator";
    public override bool SendIt { get; set; } = true;

    // Derived from the DAG: an image is expected iff the workflow has an AiImage node.
    public override bool ProduceImage
    {
        get => _workflowDefinition.Nodes.Any(n => n.Type == "AiImage");
        set => throw new NotSupportedException("ProduceImage is derived from the workflow DAG and cannot be set directly.");
    }

    public override IReadOnlyList<SenderPlatform> SupportedPlatforms { get; } =
        new[] { SenderPlatform.X, SenderPlatform.LinkedIn,
                SenderPlatform.Instagram, SenderPlatform.Facebook }.AsReadOnly();

    public override async Task<IReadOnlyDictionary<SenderPlatform, Post?>> OrchestrateAsync(CancellationToken ct = default)
    {
        var result = await _workflowEngine.ExecuteAsync(_workflowDefinition, _senders, ct);
        if (!result.Success) { _sendIt = false; return Empty; }
        if (result.Context.TryGetData<Dictionary<SenderPlatform, Post?>>(
                WorkflowContextKeys.SendResults, out var postMap))
            return postMap.AsReadOnly();
        _sendIt = false; return Empty;
    }
}
```

On failure or missing `SendResults` the orchestrator returns an empty map and
sets `SendIt = false`, so callers never crash.

### 8. Config-driven scheduling — `ConfigurationSlotProfileProvider` (issue #270)

The schedule is fully data-driven. Every configured slot maps to a
`WorkflowOrchestrator` whose `OrchestratorContextKey` is the workflow key.

```csharp
namespace XPoster.Models;

public sealed class SlotScheduleOptions
{
    public string? Workflow { get; init; }        // → OrchestratorContextKey
    public int Hour { get; init; }                // 0-23
    public List<string> Senders { get; init; } = new();  // platform names
}
```

`ConfigurationSlotProfileProvider.GetProfiles()`:
1. iterates the `Schedule` section (`Schedule__N__*` flat convention so it
   replicates into Azure Function Environment settings);
2. skips slots with missing workflow or no senders (with warnings);
3. parses sender names to `SenderPlatform` (case-insensitive; unknown → warning);
4. builds `ScheduledOrchestrationProfile(hour, senderPlatforms,
   OrchestratorContextKey = options.Workflow, OrchestratorType = typeof(WorkflowOrchestrator))`;
5. returns profiles ordered by hour.

### 9. Dependency injection wiring

`Program.cs` (relevant slice):

```csharp
builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUri), new DefaultAzureCredential());
builder.Services.AddCredentials(builder.Configuration);   // ICredentials + validation
builder.Services.AddHttpClients();
builder.Services.AddXPosterSenderPlugins();               // keyed ISender incl. DryRun*
builder.Services.AddXPosterAiProviders();                 // keyed IT*Provider by AiProvider
builder.Services.AddSingleton<ConfigurationSlotProfileProvider>();
builder.Services.AddSingleton<ISlotProfileProvider>(sp =>
    sp.GetRequiredService<ConfigurationSlotProfileProvider>());
builder.Services.AddTransient<IOrchestratorFactory, OrchestratorFactory>();
builder.Services.AddWorkflows(builder.Configuration);     // engine + keyed nodes + definitions
builder.Services.Configure<BlobStorageOptions>(builder.Configuration);
builder.Services.AddSingleton(_ => new BlobServiceClient(
    builder.Configuration["AZURE_STORAGE_CONNECTION_STRING"]));
// ... ITimeProvider (ForceHour dev override), IFeedService, ICryptoService, etc.
```

`AddWorkflows` (registration-time validation throws on a structurally-invalid
DAG):

```csharp
public static IServiceCollection AddWorkflows(this IServiceCollection services, IConfiguration configuration)
{
    services.AddSingleton<IStepOptionsResolver, ConfigurationStepOptionsResolver>();
    services.AddTransient<IWorkflowEngine, WorkflowExecutionEngine>();

    services.AddKeyedTransient<IWorkflowNode, FetchRssNode>("FetchRss");
    services.AddKeyedTransient<IWorkflowNode, AiTextNode>("AiText");
    services.AddKeyedTransient<IWorkflowNode, AiImageNode>("AiImage");
    services.AddKeyedTransient<IWorkflowNode, FanOutSendNode>("FanOutSend");
    services.AddKeyedTransient<IWorkflowNode, AcquireCryptoValueNode>("AcquireCryptoValue");
    services.AddKeyedTransient<IWorkflowNode, BuildPowerLawPostNode>("BuildPowerLawPost");

    foreach (var slotSection in configuration.GetSection("Workflows").GetChildren())
    {
        var options = slotSection.Get<WorkflowDefinitionOptions>();
        var definition = options.ToDefinition(slotSection.Key);
        var error = WorkflowDefinitionValidator.ValidateStructural(definition);
        if (error != null)
            throw new InvalidOperationException($"Workflow '{slotSection.Key}' is invalid: {error}");
        services.AddKeyedSingleton<WorkflowDefinition>(slotSection.Key, definition);
    }
    return services;
}
```

`OrchestratorFactory.Resolve()` now resolves **every** slot through
`ResolveWorkflowOrchestrator` using `profile.OrchestratorContextKey`
(`GetKeyedService<WorkflowDefinition>(key)`); all reflection-based context
resolution and the workflow type-check branch are gone. When no definition
exists it falls back to `NoOrchestrator` (with a warning).

Senders remain keyed `ISender` registrations
(`SenderPluginsServiceCollectionExtensions`), including the dry-run variants:

| Platform | Registration | `MessageMaxLength` |
|---|---|---|
| `X`, `LinkedIn`, `Instagram`, `Facebook` | keyed `AddKeyedTransient<ISender, …Sender>` | platform-specific |
| `DryRunMaxLength` | `DryRunMaxLengthSender` | `int.MaxValue` |
| `DryRunShortLength` | `DryRunShortLengthSender` | **250** (`DryRunShortLengthSender.ShortLength`) |

`DryRunSender` is the abstract base: it **probes** configuration for a known
credential key (`XApiKey`, loaded from Key Vault) to verify startup wiring,
logs the post content + image presence, and returns `true` without any
outbound call. Using **two** dry-run platforms (unlimited + 250) exercises the
re-summarisation path of `FanOutSendNode` locally.

### 10. Configuration example (`local.settings.json`)

Azure Functions convention — `local.settings.json`, **not** `appsettings.json`.

`PromptSteps` (string-keyed, replaces `PromptRole`):

```jsonc
"PromptSteps__Feed.Summary__SystemPromptTemplate": "You are an assistant that summarizes text concisely. It's very important that you keep summaries under {MaxChars} characters.",
"PromptSteps__Feed.Summary__UserPromptTemplate": "Summarize this text in a few sentences. text: {Text}",
"PromptSteps__Feed.Summary__Temperature": "0.5",
"PromptSteps__Feed.Summary__MaxTokenBudget": "600",
"PromptSteps__Feed.Summary__InputTextLabel": "{Text}",
// Feed.ImagePromptDerivation, Feed.ImageGeneration similarly …
```

`Workflows:Bitcoin` — 5-node image pipeline:

```jsonc
"Workflows__Bitcoin__Nodes__0__Id": "fetch-rss",
"Workflows__Bitcoin__Nodes__0__Type": "FetchRss",
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
"Workflows__Bitcoin__Nodes__1__NextNodeIds__1": "fan-out-send",

"Workflows__Bitcoin__Nodes__2__Id": "generate-image-prompt",
"Workflows__Bitcoin__Nodes__2__Type": "AiText",
"Workflows__Bitcoin__Nodes__2__Parameters__Provider": "OpenAi",
"Workflows__Bitcoin__Nodes__2__Parameters__StepId": "Feed.ImagePromptDerivation",
"Workflows__Bitcoin__Nodes__2__Parameters__InputKey": "baseSummary",
"Workflows__Bitcoin__Nodes__2__OutputKey": "imagePrompt",
"Workflows__Bitcoin__Nodes__2__NextNodeIds__0": "generate-image",

"Workflows__Bitcoin__Nodes__3__Id": "generate-image",
"Workflows__Bitcoin__Nodes__3__Type": "AiImage",
"Workflows__Bitcoin__Nodes__3__Parameters__Provider": "AzureFoundry",
"Workflows__Bitcoin__Nodes__3__Parameters__StepId": "Feed.ImageGeneration",
"Workflows__Bitcoin__Nodes__3__Parameters__InputKey": "imagePrompt",
"Workflows__Bitcoin__Nodes__3__Parameters__Required": "false",
"Workflows__Bitcoin__Nodes__3__OutputKey": "attachedMedia",
"Workflows__Bitcoin__Nodes__3__NextNodeIds__0": "fan-out-send",

"Workflows__Bitcoin__Nodes__4__Id": "fan-out-send",
"Workflows__Bitcoin__Nodes__4__Type": "FanOutSend",
"Workflows__Bitcoin__Nodes__4__Parameters__TextKey": "baseSummary",
"Workflows__Bitcoin__Nodes__4__Parameters__FallbackSourceKey": "sourceContent",
"Workflows__Bitcoin__Nodes__4__Parameters__StepId": "Feed.Summary",
"Workflows__Bitcoin__Nodes__4__Parameters__MediaKey": "attachedMedia",
```

`Workflows:PowerLaw` — 3-node deterministic pipeline (issue #269), terminal is
`fan-out-send` with only `TextKey`:

```jsonc
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
```

`Schedule` (config-driven, issue #270) — production slots + local dry-run
fan-out (max + short length) at hour 9:

```jsonc
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

"Schedule__2__Hour": "9",
"Schedule__2__Workflow": "PowerLaw",
"Schedule__2__Senders__0": "DryRunMaxLength",
"Schedule__2__Senders__1": "DryRunShortLength",
```

> **Production safety**: dry-run platforms and `ForceHour` are local-only. The
> dry-run slot exercises the full DAG (acquisition → post build → fan-out
> re-summarisation) without publishing anywhere.

### 11. Migration path (as executed — Strangler Fig)

| Phase | What was done |
|---|---|
| 1. Engine alongside legacy | `IWorkflowNode`, `WorkflowContext`, `NodeParameterExtractor`, `IStepOptionsResolver`, sequential Kahn engine; `FeedOrchestrator`/`PowerLawOrchestrator` untouched. |
| 2. Bitcoin → workflow | "Bitcoin" slot migrated to `WorkflowOrchestrator` + `Workflows:Bitcoin` DAG (5 nodes). |
| 3. Legacy deprecation | `FeedOrchestrator`, `FeedOrchestratorContext`, `FeedPromptOptions`, `PromptRole`, legacy `FeedSlotContexts__*` removed. |
| 4. PowerLaw → workflow | `AcquireCryptoValueNode` + `BuildPowerLawPostNode` + `FanOutSendNode` replaced `PowerLawOrchestrator` (#269). |
| 5. Config-driven scheduling | `ConfigurationSlotProfileProvider` + `SlotScheduleOptions` replaced `DefaultSlotProfileProvider`; `OrchestratorFactory` simplified to workflow-only resolution (#270). |
| 6. DAG hardening | Single-terminal-node enforcement (`ITerminalNode` + `WorkflowDefinitionValidator`), `AiImage.Required`, `ProduceImage` derived from the DAG. |

Directories/files removed with this ADR: `PowerLawOrchestrator.cs`,
`FeedOrchestrator.cs`, `FeedOrchestratorContext.cs`, `FeedPromptOptions.cs` /
`PromptRole.cs`, `DefaultSlotProfileProvider.cs`, `DryRunSlotProfileProvider.cs`,
`DryRunSenderSource.cs`, `DryRunSenderOptions.cs`, `IDryRunSenderSource.cs`,
and the legacy single `DryRun` platform.

### 12. Testing

| Area | Tests |
|---|---|
| PowerLaw nodes | `AcquireCryptoValueNodeTests`, `BuildPowerLawPostNodeTests` |
| DAG validation | `WorkflowDefinitionValidatorTests` (cycles, dangling refs, 0/2 terminals, terminal contract) |
| Engine | `WorkflowExecutionEngineTests` (incl. PowerLaw end-to-end DAG) |
| Config scheduling | `ConfigurationSlotProfileProviderTests`, `ScheduledOrchestrationProfileTests` |
| DI | `WorkflowServiceCollectionExtensionsTests`, `OrchestratorFactoryTests` |
| Fan-out / dry-run | `FanOutSendNodeTests` (multi-sender re-summarisation, media bridge), `DryRunSenderTests` |
| Orchestrator bridge | `WorkflowOrchestratorTests` |

Removed with the legacy pipeline: `FeedOrchestratorTests`,
`FeedOrchestratorFeedUrlProviderTests`, `PowerLawOrchestratorTests`,
`DefaultSlotProfileProviderTests`, `DryRunSenderSourceTests`.

---

## Consequences

### Positive

- **Zero rewriting of infrastructure services** — `IFeedService`,
  `OpenAiService`, `ITagReplacementService`, `ICryptoService`, `ITimeProvider`
  and all AI providers are unchanged.
- **Configuration-only extensibility** — new workflows, node parameters,
  prompt steps and schedule slots require no code change or recompilation.
- **Multi-media support** — `MediaAttachment` covers text/video/document
  pipelines; `Post` remains untouched.
- **Parallel-execution safety** — thread-safe `WorkflowContext` enables future
  `Task.WhenAll` batching of independent branches.
- **Backward-compatible bridge** — `WorkflowOrchestrator` preserves the
  `IOrchestrator` contract; the fan-out with length-aware re-summarisation is
  preserved verbatim (`Critical requirement` above).
- **Fail-fast validation** — structural DAG validation at registration and the
  terminal-node contract at execution prevent misconfigured workflows from
  reaching runtime.
- **Deterministic, testable PowerLaw** — pure nodes replace a stateful
  orchestrator, with direct unit coverage (#269).

### Negative

- **Configuration overhead** — `InputKey`/`OutputKey` mismatches are runtime
  concerns; structural DAG validation does not catch key-level mistakes.
- **Abstraction complexity** — the engine adds layers; simple single-node
  workflows must still implement the orchestrator/DAG contract.
- **Fully config-driven schedule** — a bad `Schedule` entry is skipped with a
  log warning; operators must monitor for silently-dropped slots.

### Trade-offs (from ADR-006-a/b)

| Aspect | Before | After |
|---|---|---|
| Flexibility | Enum-bound, compile-time | JSON/config-driven, runtime |
| Complexity | Monolithic orchestrators | DAG engine + adapters (more abstractions) |
| Fan-out logic | Embedded in `FeedOrchestrator` | Encapsulated in `FanOutSendNode` |
| Maintainability | New step ⇒ new enum + recompile | New step ⇒ config entry |

---

## Open questions

1. **Configurable retry / fallback** — per-node retry policies and optional
   fallback nodes (not implemented; could be added to the engine).
2. **Parallel fan-out limits** — concurrent node execution with configurable
   concurrency limits (context already thread-safe).
3. **Context persistence** — `IWorkflowContext` is intentionally in-memory;
   persistence between retries is out of scope.
4. **Re-summarisation source** — a future `ReSummarisationSourceKey` parameter
   to pick the source other than the default fallback (original feed content).
5. **Media-accurate fan-out** — future video/document workflows may need the
   fan-out node to honour per-sender media-type constraints.

---

## Related issues

- #245 — Design extensible OrchestratorContext registration
- #246 — Design PromptRole scoping strategy
- #269 — Convert PowerLawOrchestrator to workflow DAG nodes
- #270 — Convert slot scheduling to config-driven workflow selection
- #176 — Multi-platform fan-out feature
- PRs #264–#271 track the ADR-006 implementation process

## References

- n8n workflow node model
- Azure Durable Functions fan-out/fan-in
- .NET keyed DI (keyed services)
- Legacy fan-out anchor: `src/Orchestrators/FeedOrchestrator.cs`