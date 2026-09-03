# ADR 006: Workflow-Based Orchestration Architecture

## Status

**Proposed**

## Context

The XPoster system currently uses a monolithic orchestrator hierarchy (`FeedOrchestrator`, `PowerLawOrchestrator`, `NoOrchestrator`) where each orchestrator is hardcoded to a specific pipeline. Each orchestrator encapsulates its own sequence of operations, prompt roles, and context types. This design works for a small number of fixed pipelines but does not scale as new publishing use cases emerge.

The system's evolution toward a workflow-based architecture is driven by:

1. **Diverse data sources**: different orchestrators may need to ingest from RSS feeds, MCP servers, private databases, webhooks, or user-defined APIs
2. **Flexible processing chains**: the sequence of AI calls, transformations, and validations should be configurable per slot
3. **Reusable steps**: the `Summary` step from a feed pipeline might be reused in an alert pipeline
4. **Fan-out patterns with length-aware re-summarisation**: a single step's output must be consumable by multiple downstream steps, with the ability to re-generate content when it exceeds a sender's character limit
5. **External configuration**: all node behaviors must remain configurable via `appsettings.json` or providers, not hardcoded

## Critical Requirement: Preserve Fan-Out with Length-Aware Re-Summarisation

The current `FeedOrchestrator` implements a specific fan-out pattern that **must be preserved**:

1. **Primary sender selection**: senders are ordered by `MessageMaxLength` descending; the widest sender (largest character limit) is designated as the primary
2. **Base summary generation**: the primary sender's limit drives the initial AI summary from the raw feed content
3. **Image generation**: the base summary is used to derive an image prompt and generate an image (once per workflow execution)
4. **Per-sender re-summarisation**: for each subsequent sender (in descending limit order):
   - If the previous summary fits within the current sender's `MessageMaxLength`, it is reused
   - If it exceeds the limit, a new AI summary is generated from the **original feed content** (not from the previous summary), respecting the current sender's limit
5. **Post assembly**: each sender receives a `Post` with the appropriate summary (length-adapted) and the shared image (if generated)

This behaviour is not arbitrary — it ensures:
- **Quality**: the base summary is generated with the most generous token budget
- **Efficiency**: summaries are reused where possible, avoiding unnecessary AI calls
- **Correctness**: re-summarisation always goes back to the source material, preventing compounding truncation
- **Image consistency**: a single image is generated per slot, avoiding duplicate AI image costs

## Problem Statement

The current architecture has three tightly coupled design constraints that prevent workflow-based orchestration:

### 1. Orchestrator Context Registration Is Hardcoded

`FeedOrchestratorContext` is registered with a hardcoded key in `Program.cs`:

```csharp
builder.Services.AddKeyedSingleton<FeedOrchestratorContext>("Bitcoin", (sp, _) =>
    builder.Configuration.GetSection("FeedSlotContexts:Bitcoin").Get<FeedOrchestratorContext>()!);
```

Each new orchestrator type requires a similar explicit registration. The factory then special-cases resolution via `ResolveFeedOrchestratorContext`, which prevents a generic context resolution strategy.

### 2. PromptRole Is Tightly Coupled to FeedOrchestrator

The `PromptRole` enum is defined as:

```csharp
public enum PromptRole
{
    Summary,
    ImagePromptDerivation,
    ImageGeneration
}
```

These values are meaningful only for `FeedOrchestrator`. A different orchestrator (e.g., `AlertOrchestrator`) would need entirely different steps (`AlertDraft`, `HeadlineExtraction`, `SentimentAnalysis`). Extending the shared enum pollutes the model with orchestrator-specific concerns.

### 3. Service Invocation Is Implicit

The `FeedService` is called directly inside `FeedOrchestrator`. There is no abstraction for "executing a node" or "passing output from one node to the next". This makes the pipeline rigid and hard to reconfigure without code changes.

### 4. Fan-Out Logic Is Embedded in the Orchestrator

The length-aware re-summarisation loop is hardcoded in `FeedOrchestrator.OrchestrateAsync`. This logic must be extracted into a reusable workflow pattern so that:
- New workflows can opt into the same fan-out behaviour
- The fan-out strategy can be configured (e.g., primary selection criteria, re-summarisation source)
- Senders can be reordered or filtered without code changes

## Decision

We will transition from a fixed orchestrator-per-pipeline model to a **workflow-based node graph architecture**. The workflow will be defined externally in configuration, and the system will execute it dynamically at runtime.

### Core Principles

1. **Workflow = Directed Acyclic Graph (DAG) of nodes**
2. **Node = atomic unit of work** (data fetching, AI call, transformation, validation, sending)
3. **Context = shared state** passed between nodes (not per-orchestrator, but per-slot)
4. **Node types are pluggable** via DI and configuration
5. **Step identification is string-based** (not enum-based), scoped to the workflow definition
6. **Fan-out is a first-class node pattern**, not embedded logic

## Proposed Design

### 1. Workflow Context Abstraction

Introduce a shared context type that carries all data between nodes in a workflow execution:

```csharp
public interface IWorkflowContext
{
    string SlotKey { get; }
    IReadOnlyDictionary<string, object> Data { get; }
    T GetData<T>(string key);
    void SetData(string key, object value);
    bool HasData(string key);
}

public class WorkflowContext : IWorkflowContext
{
    public string SlotKey { get; init; }
    private readonly Dictionary<string, object> _data = new();

    public T GetData<T>(string key) => (T)_data[key];
    public void SetData(string key, object value) => _data[key] = value;
    public bool HasData(string key) => _data.ContainsKey(key);
}
```

**Impact**: `FeedOrchestratorContext` is replaced by `WorkflowContext` for all orchestrators. Existing `FeedOrchestrator` behavior is preserved by converting its context to a workflow context at resolution time.

### 2. Node Abstraction

Define a contract for any workflow node:

```csharp
public interface IWorkflowNode
{
    string NodeType { get; }
    Task<WorkflowNodeResult> ExecuteAsync(WorkflowNodeInput input, CancellationToken ct);
}

public record WorkflowNodeInput(
    IWorkflowContext Context,
    IReadOnlyDictionary<string, object> Parameters,
    object? PreviousOutput,
    IReadOnlyList<ISender> Senders);

public record WorkflowNodeResult(
    bool Success,
    object? Output,
    IReadOnlyList<string>? NextNodeIds,
    string? ErrorMessage);
```

### 3. Fan-Out Node: The Key to Preserving Current Behaviour

The fan-out logic is encapsulated in a dedicated node type: **`FanOutSendNode`**. This node is responsible for:

1. Receiving the base content (summary) and optional image from previous nodes
2. Ordering senders by `MessageMaxLength` descending (primary first)
3. Re-summarising from the original source when a summary exceeds a sender's limit
4. Assembling and dispatching posts to each sender

```csharp
public class FanOutSendNode : IWorkflowNode
{
    public string NodeType => "FanOutSend";

    public async Task<WorkflowNodeResult> ExecuteAsync(WorkflowNodeInput input, CancellationToken ct)
    {
        // 1. Extract data from context
        var sourceContent = input.Context.GetData<string>("sourceContent");
        var baseSummary = input.Context.GetData<string>("baseSummary");
        var imageBytes = input.Context.HasData("image") 
            ? input.Context.GetData<byte[]>("image") 
            : null;

        // 2. Order senders by MessageMaxLength descending
        var orderedSenders = input.Senders
            .OrderByDescending(s => s.MessageMaxLength)
            .ToList();

        // 3. Get the summarisation step configuration
        var summaryStep = input.Context.GetData<WorkflowStepOptions>("summaryStep");

        // 4. Fan-out loop (exactly as in FeedOrchestrator)
        var result = new Dictionary<SenderPlatform, Post?>();
        var previousSummary = baseSummary;

        foreach (var sender in orderedSenders)
        {
            string summaryForSender;

            if (previousSummary.Length <= sender.MessageMaxLength)
            {
                summaryForSender = previousSummary;
            }
            else
            {
                // Re-summarise from the original source content
                var reSummaryRequest = BuildPromptRequest(
                    sourceContent,
                    summaryStep,
                    sender.MessageMaxLength);

                var reSummarised = await ResolveTextProvider(input.Context)
                    .GenerateTextAsync(reSummaryRequest, ct);

                if (string.IsNullOrWhiteSpace(reSummarised))
                {
                    result[sender.Platform] = null;
                    continue;
                }

                summaryForSender = reSummarised;
            }

            previousSummary = summaryForSender;
            result[sender.Platform] = new Post
            {
                Content = ApplyTagReplacements(summaryForSender, input.Context),
                Image = imageBytes
            };
        }

        // 5. Store the result in context for downstream nodes (if any)
        input.Context.SetData("sendResults", result);
        input.Context.SetData("sent", true);

        return new WorkflowNodeResult(
            Success: true,
            Output: result,
            NextNodeIds: input.NextNodeIds);
    }
}
```

### 4. Workflow Configuration

Workflows are defined in `appsettings.json` with a schema that describes the node graph, including the fan-out pattern:

```json
{
  "Workflows": {
    "Bitcoin": {
      "SlotKey": "Bitcoin",
      "EntryNodeId": "fetch-feeds",
      "Senders": [ "X", "LinkedIn", "Instagram" ],
      "Nodes": [
        {
          "Id": "fetch-feeds",
          "Type": "FetchHttp",
          "Parameters": {
            "Urls": [ "https://bitcoin.org/feed.xml", "https://coindesk.com/feed" ],
            "ParserType": "RssXml"
          },
          "OutputKey": "sourceContent",
          "NextNodeIds": [ "generate-summary", "generate-image-prompt" ]
        },
        {
          "Id": "generate-summary",
          "Type": "AiText",
          "Parameters": {
            "Provider": "OpenAi",
            "StepId": "Feed.Summary",
            "MaxOutputLength": 500
          },
          "OutputKey": "baseSummary",
          "NextNodeIds": [ "fan-out-send" ]
        },
        {
          "Id": "generate-image-prompt",
          "Type": "AiText",
          "Parameters": {
            "Provider": "DeepSeek",
            "StepId": "Feed.ImagePromptDerivation",
            "MaxOutputLength": 100
          },
          "OutputKey": "imagePrompt",
          "NextNodeIds": [ "generate-image" ]
        },
        {
          "Id": "generate-image",
          "Type": "AiImage",
          "Parameters": {
            "Provider": "FalAi",
            "StepId": "Feed.ImageGeneration"
          },
          "OutputKey": "image",
          "NextNodeIds": [ "fan-out-send" ]
        },
        {
          "Id": "fan-out-send",
          "Type": "FanOutSend",
          "Parameters": {
            "SourceContentKey": "sourceContent",
            "BaseSummaryKey": "baseSummary",
            "ImageKey": "image",
            "SummaryStepId": "Feed.Summary"
          },
          "NextNodeIds": []
        }
      ]
    }
  }
}
```

### 5. Step Identification Strategy

Replace the `PromptRole` enum with **string-based step identifiers** scoped to each workflow:

```csharp
public sealed record WorkflowStepOptions
{
    public required string StepId { get; init; }
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

A `Workflow` references its own step IDs. There is no shared enum; each workflow defines its own step lexicon. Existing `FeedPromptOptions` can be migrated by prefixing with `"Feed"` (e.g., `"Feed.Summary"`, `"Feed.ImagePromptDerivation"`, `"Feed.ImageGeneration"`).

### 6. Workflow Engine

A new `WorkflowOrchestrator` replaces the concrete orchestrator implementations. It resolves the workflow definition, executes nodes in order, and tracks the context:

```csharp
public class WorkflowOrchestrator : BaseOrchestrator
{
    private readonly IWorkflowDefinitionProvider _workflowProvider;
    private readonly IServiceProvider _serviceProvider;
    private readonly IWorkflowContext _context;

    public override async Task<IReadOnlyDictionary<SenderPlatform, Post?>> OrchestrateAsync(CancellationToken ct)
    {
        var workflow = _workflowProvider.GetWorkflow(_context.SlotKey);
        var currentNodeId = workflow.EntryNodeId;

        while (!string.IsNullOrEmpty(currentNodeId))
        {
            var nodeDef = workflow.Nodes.Single(n => n.Id == currentNodeId);
            var node = _serviceProvider.GetKeyedService<IWorkflowNode>(nodeDef.Type);
            var input = new WorkflowNodeInput(
                _context,
                nodeDef.Parameters,
                previousOutput: null,
                _senders);

            var result = await node.ExecuteAsync(input, ct);

            if (!result.Success)
                throw new WorkflowExecutionException(result.ErrorMessage);

            // Store any output in context
            if (!string.IsNullOrEmpty(nodeDef.OutputKey) && result.Output != null)
                _context.SetData(nodeDef.OutputKey, result.Output);

            currentNodeId = result.NextNodeIds?.FirstOrDefault();
        }

        // After workflow completes, the FanOutSend node has stored the final post map
        return _context.GetData<IReadOnlyDictionary<SenderPlatform, Post?>>("sendResults");
    }
}
```

### 7. Factory Integration

`OrchestratorFactory.Resolve()` now checks if the profile's `OrchestratorType` is `WorkflowOrchestrator`. If so, it resolves the context generically via `IWorkflowContext` and returns the orchestrator. No special-casing is needed for `FeedOrchestrator` or any other concrete type.

## Migration Path

### Phase 1: Introduce Workflow Context (Backward Compatible)

1. Add `IWorkflowContext` and `WorkflowContext`
2. Modify `FeedOrchestrator` to accept `IWorkflowContext` instead of `FeedOrchestratorContext` (with a shim adapter)
3. Keep existing `FeedPromptOptions` and `PromptRole` for compatibility
4. Existing tests continue to pass

### Phase 2: Node Implementation

1. Implement core node types:
   - `FetchHttpNode` — fetches data from HTTP endpoints
   - `AiTextNode` — calls AI for text generation
   - `AiImageNode` — calls AI for image generation
   - `FanOutSendNode` — **preserves the exact fan-out with re-summarisation logic**
   - `TransformNode` — applies transformations (truncation, regex, etc.)
2. Register nodes as keyed transient services in DI:
   ```csharp
   services.AddKeyedTransient<IWorkflowNode, FetchHttpNode>("FetchHttp");
   services.AddKeyedTransient<IWorkflowNode, AiTextNode>("AiText");
   services.AddKeyedTransient<IWorkflowNode, FanOutSendNode>("FanOutSend");
   // ...
   ```

### Phase 3: Workflow Configuration

1. Add `IWorkflowDefinitionProvider` with JSON configuration source
2. Define the first workflow equivalent to the current `Bitcoin` feed pipeline
3. Add validation to ensure:
   - No cycles in the graph
   - All node IDs are resolvable
   - `FanOutSendNode` has a `SummaryStepId` that exists in the workflow's steps
   - At least one sender is configured

### Phase 4: Orchestrator Transition

1. Introduce `WorkflowOrchestrator`
2. Update `ScheduledOrchestrationProfile` to include a `WorkflowKey` property
3. Make `WorkflowOrchestrator` the default for new slots
4. Deprecate `FeedOrchestrator`, `PowerLawOrchestrator` (keep until all slots migrate)

### Phase 5: Cleanup

1. Remove `FeedOrchestratorContext` and `PromptRole` enum
2. Update all documentation
3. Remove concrete orchestrator classes
4. Remove `ResolveFeedOrchestratorContext` from `OrchestratorFactory`

## Consequences

### Positive

- **Extensible**: new workflows are defined in configuration, no code changes required
- **Reusable**: nodes can be composed in any order across workflows
- **Testable**: individual nodes can be unit tested in isolation
- **Observable**: workflow execution can be instrumented with telemetry per node
- **Maintainable**: adding a new data source or AI provider requires only a new node implementation
- **Fan-out preserved**: the critical length-aware re-summarisation behaviour is encapsulated in a reusable node, guaranteeing consistency across workflows

### Negative

- **Increased complexity**: workflow engine adds a new abstraction layer
- **Configuration overhead**: workflows are described in JSON, which must be validated
- **Performance**: node execution and context serialisation add overhead (mitigated by singleton resolution and in-memory context)
- **Learning curve**: operators must understand workflow DAG semantics and fan-out configuration

### Trade-offs

| Aspect | Current | Proposed |
|--------|---------|----------|
| Flexibility | Low (hardcoded pipelines) | High (configurable workflows) |
| Complexity | Low | Medium |
| Performance | High (direct calls) | Medium (indirection via nodes) |
| Maintainability | Low (new orchestrator per use case) | High (new node per capability) |
| Fan-out logic | Embedded in orchestrator | Encapsulated in `FanOutSendNode` |

## Open Questions

1. **Cycle prevention**: how do we enforce acyclic graphs at configuration load time? (Proposal: topological sort validation on load)
2. **Error handling**: how do we handle node failures? (Proposal: configurable retry policies per node; optional fallback nodes)
3. **Parallel execution**: should we support fan-out with parallel execution for truly independent branches? (Proposal: yes, with configurable concurrency limits for nodes with multiple `NextNodeIds`)
4. **State persistence**: should `IWorkflowContext` be persisted between retries? (Proposal: not initially; keep in-memory for simplicity)
5. **Re-summarisation source**: should re-summarisation always use the original source content, or should there be a configurable option? (Proposal: keep original source as default, but allow configuration via `ReSummarisationSourceKey` parameter)

## Related Issues

- #245 — Design extensible OrchestratorContext registration for multi-orchestrator support
- #246 — Design PromptRole scoping strategy for multi-orchestrator support

## References

- n8n workflow node model: https://docs.n8n.io/workflows/
- Azure Durable Functions fan-out/fan-in: https://learn.microsoft.com/en-us/azure/azure-functions/durable/durable-functions-overview
- .NET 8 Keyed DI services: https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-guidelines#keyed-services
- Current `FeedOrchestrator` fan-out implementation: `src/Orchestrators/FeedOrchestrator.cs`