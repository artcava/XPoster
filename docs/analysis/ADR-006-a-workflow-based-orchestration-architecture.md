```md
# ADR 006-a: Workflow-Based Orchestration Architecture

## Status

**Proposed**

## Context

The XPoster system currently uses a monolithic orchestrator hierarchy (`FeedOrchestrator`, `PowerLawOrchestrator`, `NoOrchestrator`) where each orchestrator is hardcoded to a specific pipeline. Each orchestrator encapsulates its own sequence of operations, prompt roles, and context types. This design works for a small number of fixed pipelines but does not scale as new publishing use cases emerge.

The system's evolution toward a workflow-based architecture is driven by:

1. **Diverse data sources**: different orchestrators may need to ingest from RSS feeds, MCP servers, private databases, webhooks, or user-defined APIs
2. **Flexible processing chains**: the sequence of AI calls, transformations, and validations should be configurable per slot
3. **Reusable steps**: the `Summary` step from a feed pipeline might be reused in an alert pipeline
4. **Fan-out patterns**: a single step's output should be consumable by multiple downstream steps (e.g., summary → both post text and image prompt)
5. **External configuration**: all node behaviors must remain configurable via `appsettings.json` or providers, not hardcoded

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

## Decision

We will transition from a fixed orchestrator-per-pipeline model to a **workflow-based node graph architecture**. The workflow will be defined externally in configuration, and the system will execute it dynamically at runtime.

### Core Principles

1. **Workflow = Directed Acyclic Graph (DAG) of nodes**
2. **Node = atomic unit of work** (data fetching, AI call, transformation, validation, sending)
3. **Context = shared state** passed between nodes (not per-orchestrator, but per-slot)
4. **Node types are pluggable** via DI and configuration
5. **Step identification is string-based** (not enum-based), scoped to the workflow definition

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
}

public class WorkflowContext : IWorkflowContext
{
    public string SlotKey { get; init; }
    private readonly Dictionary<string, object> _data = new();

    public T GetData<T>(string key) => (T)_data[key];
    public void SetData(string key, object value) => _data[key] = value;
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
    object? PreviousOutput);

public record WorkflowNodeResult(
    bool Success,
    object? Output,
    IReadOnlyList<string>? NextNodeIds,
    string? ErrorMessage);
```

**Node types**:

| Node Type | Responsibility |
|-----------|----------------|
| `FetchHttpNode` | Fetch data from an HTTP endpoint (RSS feed, MCP server, API) |
| `DatabaseQueryNode` | Query a database with a configured query |
| `AiTextNode` | Call an AI provider for text generation (summary, draft, etc.) |
| `AiImageNode` | Call an AI provider for image generation |
| `TransformNode` | Apply transformations (truncate to max length, regex replace, etc.) |
| `ConditionalNode` | Branch based on context values |
| `SendNode` | Publish the final post to the configured sender platform |

### 3. Workflow Configuration

Workflows are defined in `appsettings.json` with a schema that describes the node graph:

```json
{
  "Workflows": {
    "Bitcoin": {
      "SlotKey": "Bitcoin",
      "EntryNodeId": "fetch-feeds",
      "Nodes": [
        {
          "Id": "fetch-feeds",
          "Type": "FetchHttp",
          "Parameters": {
            "Urls": [ "https://bitcoin.org/feed.xml", "https://coindesk.com/feed" ],
            "ParserType": "RssXml"
          },
          "NextNodeIds": [ "generate-summary", "image-prompt" ]
        },
        {
          "Id": "generate-summary",
          "Type": "AiText",
          "Parameters": {
            "Provider": "OpenAi",
            "SystemPrompt": "Summarise the following Bitcoin news concisely...",
            "MaxOutputLength": 280
          },
          "NextNodeIds": [ "prepare-post" ]
        },
        {
          "Id": "image-prompt",
          "Type": "AiText",
          "Parameters": {
            "Provider": "DeepSeek",
            "SystemPrompt": "Derive an image prompt from the following summary...",
            "MaxOutputLength": 100
          },
          "NextNodeIds": [ "generate-image" ]
        },
        {
          "Id": "generate-image",
          "Type": "AiImage",
          "Parameters": {
            "Provider": "FalAi",
            "Size": "1024x1024",
            "Quantity": 1
          },
          "NextNodeIds": [ "prepare-post" ]
        },
        {
          "Id": "prepare-post",
          "Type": "Transform",
          "Parameters": {
            "InputKeys": [ "summary", "image-url" ],
            "OutputKey": "post",
            "TransformType": "PostComposer"
          },
          "NextNodeIds": [ "send-post" ]
        },
        {
          "Id": "send-post",
          "Type": "Send",
          "Parameters": {
            "Platforms": [ "X", "LinkedIn" ]
          },
          "NextNodeIds": []
        }
      ]
    }
  }
}
```

### 4. Step Identification Strategy

Replace the `PromptRole` enum with **string-based step identifiers** scoped to each workflow:

```csharp
public sealed record WorkflowStepOptions
{
    public required string StepId { get; init; }
    public required string SystemPromptTemplate { get; init; }
    public required string UserPromptTemplate { get; init; }
    // ... other properties (Temperature, MaxOutputLength, etc.)
}
```

A `Workflow` references its own step IDs. There is no shared enum; each workflow defines its own step lexicon. Existing `FeedPromptOptions` can be migrated by prefixing with `"Feed"` (e.g., `"Feed.Summary"`, `"Feed.ImagePromptDerivation"`, `"Feed.ImageGeneration"`).

### 5. Workflow Engine

A new `WorkflowOrchestrator` replaces the concrete orchestrator implementations. It resolves the workflow definition, executes nodes in order, and tracks the context:

```csharp
public class WorkflowOrchestrator : BaseOrchestrator
{
    private readonly IWorkflowDefinitionProvider _workflowProvider;
    private readonly IServiceProvider _serviceProvider;

    public async Task ExecuteAsync(IWorkflowContext context, CancellationToken ct)
    {
        var workflow = _workflowProvider.GetWorkflow(context.SlotKey);
        var currentNodeId = workflow.EntryNodeId;
        object? previousOutput = null;

        while (!string.IsNullOrEmpty(currentNodeId))
        {
            var nodeDef = workflow.Nodes.Single(n => n.Id == currentNodeId);
            var node = _serviceProvider.GetKeyedService<IWorkflowNode>(nodeDef.Type);
            var result = await node.ExecuteAsync(
                new WorkflowNodeInput(context, nodeDef.Parameters, previousOutput),
                ct);

            if (!result.Success)
                throw new WorkflowExecutionException(result.ErrorMessage);

            previousOutput = result.Output;
            currentNodeId = result.NextNodeIds?.FirstOrDefault();
        }
    }
}
```

### 6. Factory Integration

`OrchestratorFactory.Resolve()` now checks if the profile's `OrchestratorType` is `WorkflowOrchestrator`. If so, it resolves the context generically via `IWorkflowContext` and returns the orchestrator. No special-casing is needed for `FeedOrchestrator` or any other concrete type.

## Migration Path

### Phase 1: Introduce Workflow Context (Backward Compatible)

1. Add `IWorkflowContext` and `WorkflowContext`
2. Modify `FeedOrchestrator` to accept `IWorkflowContext` instead of `FeedOrchestratorContext` (with a shim adapter)
3. Keep existing `FeedPromptOptions` and `PromptRole` for compatibility
4. Existing tests continue to pass

### Phase 2: Node Implementation

1. Implement core node types (`FetchHttpNode`, `AiTextNode`, `AiImageNode`, `SendNode`, `TransformNode`)
2. Register nodes as keyed transient services in DI:
   ```csharp
   services.AddKeyedTransient<IWorkflowNode, FetchHttpNode>("FetchHttp");
   services.AddKeyedTransient<IWorkflowNode, AiTextNode>("AiText");
   // ...
   ```

### Phase 3: Workflow Configuration

1. Add `IWorkflowDefinitionProvider` with JSON configuration source
2. Define the first workflow equivalent to the current `Bitcoin` feed pipeline
3. Add validation to ensure no cycles and all node IDs are resolvable

### Phase 4: Orchestrator Transition

1. Introduce `WorkflowOrchestrator`
2. Update `ScheduledOrchestrationProfile` to include a `WorkflowKey` property
3. Make `WorkflowOrchestrator` the default for new slots
4. Deprecate `FeedOrchestrator`, `PowerLawOrchestrator` (keep until all slots migrate)

### Phase 5: Cleanup

1. Remove `FeedOrchestratorContext` and `PromptRole` enum
2. Update all documentation
3. Remove concrete orchestrator classes

## Consequences

### Positive

- **Extensible**: new workflows are defined in configuration, no code changes required
- **Reusable**: nodes can be composed in any order across workflows
- **Testable**: individual nodes can be unit tested in isolation
- **Observable**: workflow execution can be instrumented with telemetry per node
- **Maintainable**: adding a new data source or AI provider requires only a new node implementation

### Negative

- **Increased complexity**: workflow engine adds a new abstraction layer
- **Configuration overhead**: workflows are described in JSON, which must be validated
- **Performance**: node execution and context serialization add overhead (mitigated by singleton resolution and in-memory context)
- **Learning curve**: operators must understand workflow DAG semantics

### Trade-offs

| Aspect | Current | Proposed |
|--------|---------|----------|
| Flexibility | Low (hardcoded pipelines) | High (configurable workflows) |
| Complexity | Low | Medium |
| Performance | High (direct calls) | Medium (indirection via nodes) |
| Maintainability | Low (new orchestrator per use case) | High (new node per capability) |

## Open Questions

1. **Cycle prevention**: how do we enforce acyclic graphs at configuration load time? (Proposal: topological sort validation on load)
2. **Error handling**: how do we handle node failures? (Proposal: configurable retry policies per node; optional fallback nodes)
3. **Parallel execution**: should we support fan-out with parallel execution? (Proposal: yes, with configurable concurrency limits)
4. **State persistence**: should `IWorkflowContext` be persisted between retries? (Proposal: not initially; keep in-memory for simplicity)

## Related Issues

- #245 — Design extensible OrchestratorContext registration for multi-orchestrator support
- #246 — Design PromptRole scoping strategy for multi-orchestrator support

## References

- n8n workflow node model: https://docs.n8n.io/workflows/
- Azure Durable Functions fan-out/fan-in: https://learn.microsoft.com/en-us/azure/azure-functions/durable/durable-functions-overview
- .NET 8 Keyed DI services: https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-guidelines#keyed-services
```