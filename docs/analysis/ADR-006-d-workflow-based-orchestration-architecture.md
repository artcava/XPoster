# ADR 006: Workflow-Based Orchestration Architecture

## Status

**Proposed**

## Context

The XPoster system currently uses a monolithic orchestrator hierarchy (`FeedOrchestrator`, `PowerLawOrchestrator`, `NoOrchestrator`) where each orchestrator is hardcoded to a specific pipeline. Each orchestrator encapsulates its own sequence of operations, prompt roles, and context types. This design works for a small number of fixed pipelines but does not scale as new publishing use cases emerge.

The system's evolution toward a workflow-based architecture is driven by:

1. **Diverse data sources**: different orchestrators may need to ingest from RSS feeds, MCP servers, private databases, webhooks, or user-defined APIs.
2. **Flexible processing chains**: the sequence of AI calls, transformations, and validations should be configurable per slot.
3. **Reusable steps**: the `Summary` step from a feed pipeline might be reused in an alert pipeline.
4. **Fan-out and Fan-in patterns with length-aware content generation**: a single step's output must be consumable by multiple downstream steps in parallel, and converging branches must be synchronized before execution of dependent nodes. Content exceeding a sender's character limit must be re-generated from source material using platform-specific text generation constraints.
5. **External configuration**: all node behaviors must remain configurable via `appsettings.json` or external providers, not hardcoded.

## Critical Requirement: Preserve Fan-Out with Length-Aware Content Generation

The current `FeedOrchestrator` implements a specific fan-out pattern that **must be preserved**:

1. **Primary sender selection**: senders are ordered by `MessageMaxLength` descending; the widest sender (largest character limit) is designated as the primary.
2. **Base summary generation**: the primary sender's limit drives the initial AI summary from the raw feed content.
3. **Image generation**: the base summary is used to derive an image prompt and generate an image (once per workflow execution).
4. **Per-sender content adaptation**: for each subsequent sender (in descending limit order):
   - If the previous summary fits within the current sender's `MessageMaxLength`, it is reused.
   - If it exceeds the limit, a new AI summary is generated from the **original feed content** (not from the previous summary), respecting the current sender's limit.
5. **Post assembly**: each sender receives a `Post` with the appropriate summary (length-adapted) and the shared image (if generated).

This behaviour ensures:
- **Quality**: the base summary is generated with the most generous token budget.
- **Efficiency**: summaries are reused where possible, avoiding unnecessary AI calls.
- **Correctness**: re-summarisation always goes back to the source material, preventing compounding truncation.
- **Image consistency**: a single image is generated per slot, avoiding duplicate AI image costs.

## Problem Statement

The current architecture has tightly coupled design constraints that prevent flexible orchestration:

### 1. Orchestrator Context Registration Is Hardcoded & Thread-Unsafe

`FeedOrchestratorContext` is registered with a hardcoded key in `Program.cs`. Each new orchestrator type requires explicit DI registration. Moreover, existing context abstractions rely on non-thread-safe state storage (`Dictionary<string, object>`), making parallel branch execution impossible without causing race conditions.

### 2. PromptRole Is Tightly Coupled to FeedOrchestrator

The `PromptRole` enum (`Summary`, `ImagePromptDerivation`, `ImageGeneration`) is meaningful only for `FeedOrchestrator`. Extending a shared enum pollutes the domain model with orchestrator-specific concerns.

### 3. Service Invocation Is Implicit & Pipeline Execution Is Rigid

`FeedService` and AI providers are called directly inside concrete orchestrators. There is no abstraction for executing an atomic graph node or passing outputs safely between nodes. A naive sequential execution model fails to support Directed Acyclic Graphs (DAGs) with branching (Fan-Out) and converging nodes (Fan-In).

### 4. Parameter Deserialization Weakness

Configuring dynamic workflows via JSON introduces `JsonElement` representation for un-typed parameters in `IReadOnlyDictionary<string, object>`. Attempting direct casting without safe extraction utilities leads to runtime `InvalidCastException`.

### 5. Data Dependencies Across Workflow Nodes

Nodes often depend on the outputs of specific predecessor nodes (e.g., image prompt derivation requires the base summary output from text generation, not raw feed content). Workflow graph definitions must correctly model both execution order (DAG edges) and context keys (data flow).

### 6. Standardized Output Contract vs. Hardcoded Keys

Using magic strings for workflow execution output (e.g., `"sendResults"`) across different layers creates fragility. The system requires strongly-typed, standardized workflow context keys.

## Decision

We will transition from a fixed orchestrator-per-pipeline model to a **workflow-based Directed Acyclic Graph (DAG) architecture**. The workflow will be defined externally in configuration and executed dynamically by a thread-safe workflow engine.

### Core Principles

1. **Workflow = Directed Acyclic Graph (DAG) of nodes**
2. **Node = atomic unit of work** (data fetching, AI call, transformation, validation, sending)
3. **Context = thread-safe shared state** passed between nodes during execution, using standardized system keys
4. **DAG Execution Engine = topological scheduler** supporting parallel execution (Fan-Out), branch synchronization (Fan-In), cycle validation, and explicit data dependencies
5. **Step identification is string-based** (not enum-based), scoped to the workflow definition
6. **Fan-out is a generalized node pattern** using a generic text generation service abstraction to produce platform-tailored post content based on `MessageMaxLength`

---

## Proposed Architecture

### 1. Thread-Safe Workflow Context & Standardized Keys

Introduce a thread-safe context implementation using `ConcurrentDictionary` and a centralized constant class for framework keys:

```csharp
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

    public T GetData<T>(string key)
    {
        if (_data.TryGetValue(key, out var value) && value is T typedValue)
        {
            return typedValue;
        }
        throw new KeyNotFoundException($"Key '{key}' with type '{typeof(T).Name}' was not found in WorkflowContext.");
    }

    public bool TryGetData<T>(string key, out T? value)
    {
        if (_data.TryGetValue(key, out var val) && val is T typedValue)
        {
            value = typedValue;
            return true;
        }
        value = default;
        return false;
    }

    public void SetData(string key, object value)
    {
        _data[key] = value;
    }

    public bool HasData(string key) => _data.ContainsKey(key);
}

```

### 2. Node Abstraction & Safe Parameter Deserialization

Define the contract for any workflow node:

```csharp
public interface IWorkflowNode
{
    string NodeType { get; }
    Task<WorkflowNodeResult> ExecuteAsync(WorkflowNodeInput input, CancellationToken ct);
}

public record WorkflowNodeInput(
    IWorkflowContext Context,
    IReadOnlyDictionary<string, object> Parameters,
    IReadOnlyList<ISender> Senders);

public record WorkflowNodeResult(
    bool Success,
    object? Output,
    string? ErrorMessage);

```

Provide a parameter extraction utility to safely handle `JsonElement` values originating from `appsettings.json`:

```csharp
public static class NodeParameterExtractor
{
    public static T GetParameter<T>(IReadOnlyDictionary<string, object> parameters, string key, T defaultValue = default!)
    {
        if (!parameters.TryGetValue(key, out var rawVal))
            return defaultValue;

        if (rawVal is JsonElement element)
        {
            return JsonSerializer.Deserialize<T>(element.GetRawText()) ?? defaultValue;
        }

        if (rawVal is T typedVal)
            return typedVal;

        return defaultValue;
    }
}

```

### 3. DAG Workflow Execution Engine (Fan-Out & Fan-In Support)

A dedicated `WorkflowExecutionEngine` validates cycle absence (via In-Degree reduction) and handles node scheduling. Converging nodes (Fan-In) wait until all predecessor nodes have completed before executing.

```csharp
public interface IWorkflowEngine
{
    Task ExecuteAsync(WorkflowDefinition workflow, IWorkflowContext context, IReadOnlyList<ISender> senders, CancellationToken ct);
}

public class WorkflowExecutionEngine : IWorkflowEngine
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<WorkflowExecutionEngine> _logger;

    public WorkflowExecutionEngine(IServiceProvider serviceProvider, ILogger<WorkflowExecutionEngine> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public async Task ExecuteAsync(WorkflowDefinition workflow, IWorkflowContext context, IReadOnlyList<ISender> senders, CancellationToken ct)
    {
        ValidateAcyclicGraph(workflow);

        var inDegree = workflow.Nodes.ToDictionary(n => n.Id, _ => 0);
        var predecessorsMap = workflow.Nodes.ToDictionary(n => n.Id, _ => new List<string>());

        foreach (var node in workflow.Nodes)
        {
            foreach (var nextId in node.NextNodeIds)
            {
                if (inDegree.ContainsKey(nextId))
                {
                    inDegree[nextId]++;
                    predecessorsMap[nextId].Add(node.Id);
                }
            }
        }

        var completedNodes = new ConcurrentDictionary<string, bool>();
        var nodeMap = workflow.Nodes.ToDictionary(n => n.Id);
        var readyNodes = new ConcurrentQueue<string>(workflow.Nodes.Where(n => inDegree[n.Id] == 0).Select(n => n.Id));

        while (completedNodes.Count < workflow.Nodes.Count)
        {
            var currentBatch = new List<string>();
            while (readyNodes.TryDequeue(out var nodeId))
            {
                currentBatch.Add(nodeId);
            }

            if (currentBatch.Count == 0 && completedNodes.Count < workflow.Nodes.Count)
            {
                throw new InvalidOperationException("Workflow execution deadlocked. Graph contains unhandled cycles or missing dependencies.");
            }

            // Execute independent branches concurrently
            await Task.WhenAll(currentBatch.Select(async nodeId =>
            {
                var nodeDef = nodeMap[nodeId];
                var node = _serviceProvider.GetKeyedService<IWorkflowNode>(nodeDef.Type)
                    ?? throw new InvalidOperationException($"Workflow node type '{nodeDef.Type}' is not registered.");

                var input = new WorkflowNodeInput(context, nodeDef.Parameters, senders);
                
                _logger.LogInformation("Executing node '{NodeId}' ({NodeType})", nodeDef.Id, nodeDef.Type);
                var result = await node.ExecuteAsync(input, ct);

                if (!result.Success)
                {
                    throw new WorkflowExecutionException($"Node '{nodeId}' failed: {result.ErrorMessage}");
                }

                if (!string.IsNullOrEmpty(nodeDef.OutputKey) && result.Output != null)
                {
                    context.SetData(nodeDef.OutputKey, result.Output);
                }

                completedNodes.TryAdd(nodeId, true);
            }));

            // Re-evaluate ready nodes whose dependencies are satisfied (Fan-In)
            foreach (var node in workflow.Nodes)
            {
                if (!completedNodes.ContainsKey(node.Id) && !readyNodes.Contains(node.Id))
                {
                    if (predecessorsMap[node.Id].All(predId => completedNodes.ContainsKey(predId)))
                    {
                        readyNodes.Enqueue(node.Id);
                    }
                }
            }
        }
    }

    private static void ValidateAcyclicGraph(WorkflowDefinition workflow)
    {
        var inDegree = workflow.Nodes.ToDictionary(n => n.Id, _ => 0);
        foreach (var node in workflow.Nodes)
        {
            foreach (var nextId in node.NextNodeIds)
            {
                if (inDegree.ContainsKey(nextId))
                    inDegree[nextId]++;
            }
        }

        var queue = new Queue<string>(inDegree.Where(kvp => kvp.Value == 0).Select(kvp => kvp.Key));
        int visited = 0;

        while (queue.Count > 0)
        {
            var id = queue.Dequeue();
            visited++;
            var node = workflow.Nodes.FirstOrDefault(n => n.Id == id);
            if (node == null) continue;

            foreach (var nextId in node.NextNodeIds)
            {
                if (inDegree.ContainsKey(nextId))
                {
                    inDegree[nextId]--;
                    if (inDegree[nextId] == 0) queue.Enqueue(nextId);
                }
            }
        }

        if (visited != workflow.Nodes.Count)
        {
            throw new InvalidOperationException($"Workflow '{workflow.SlotKey}' contains cycles or unreachable nodes.");
        }
    }
}

```

### 4. Fan-Out Node with Generic Text Generation Service

The `FanOutSendNode` encapsulates sender ordering and length adaptation. Instead of coupling to a narrow "re-summariser", it depends on a generic `ITextGenerationService` (or text provider abstraction) that produces tailored text content per platform based on sender constraints (`MessageMaxLength`):

```csharp
public class FanOutSendNode : IWorkflowNode
{
    public string NodeType => "FanOutSend";

    private readonly ITextGenerationService _textGenerator;
    private readonly IStepOptionsResolver _stepOptionsResolver;

    public FanOutSendNode(
        ITextGenerationService textGenerator,
        IStepOptionsResolver stepOptionsResolver)
    {
        _textGenerator = textGenerator;
        _stepOptionsResolver = stepOptionsResolver;
    }

    public async Task<WorkflowNodeResult> ExecuteAsync(WorkflowNodeInput input, CancellationToken ct)
    {
        var sourceContentKey = NodeParameterExtractor.GetParameter(input.Parameters, "SourceContentKey", "sourceContent");
        var baseSummaryKey = NodeParameterExtractor.GetParameter(input.Parameters, "BaseSummaryKey", "baseSummary");
        var imageKey = NodeParameterExtractor.GetParameter(input.Parameters, "ImageKey", "image");
        var stepId = NodeParameterExtractor.GetParameter(input.Parameters, "SummaryStepId", "Feed.Summary");

        var sourceContent = input.Context.GetData<string>(sourceContentKey);
        var baseSummary = input.Context.GetData<string>(baseSummaryKey);
        input.Context.TryGetData<byte[]>(imageKey, out var imageBytes);

        var stepOptions = _stepOptionsResolver.Resolve(stepId);
        var orderedSenders = input.Senders.OrderByDescending(s => s.MessageMaxLength).ToList();
        var postMap = new Dictionary<SenderPlatform, Post?>();
        var previousSummary = baseSummary;

        foreach (var sender in orderedSenders)
        {
            string finalSummary;

            if (previousSummary.Length <= sender.MessageMaxLength)
            {
                finalSummary = previousSummary;
            }
            else
            {
                // Generate platform/length-adapted content from original source content
                var adaptedContent = await _textGenerator.GenerateAdaptedTextAsync(
                    sourceContent, 
                    stepOptions, 
                    sender.MessageMaxLength, 
                    ct);

                if (string.IsNullOrWhiteSpace(adaptedContent))
                {
                    postMap[sender.Platform] = null;
                    continue;
                }
                finalSummary = adaptedContent;
            }

            previousSummary = finalSummary;
            postMap[sender.Platform] = new Post
            {
                Content = finalSummary,
                Image = imageBytes
            };
        }

        input.Context.SetData(WorkflowContextKeys.SendResults, postMap);
        return new WorkflowNodeResult(Success: true, Output: postMap, ErrorMessage: null);
    }
}

```

### 5. Workflow Configuration & Correct Data Dependencies

Workflows are configured in `appsettings.json`. The graph topology explicitly reflects data flow requirements.

For example, `generate-summary` produces `baseSummary`. The `generate-image-prompt` node consumes `baseSummary` (via `"InputKey": "baseSummary"`), so `generate-summary` must point to `generate-image-prompt` in its `NextNodeIds`. The `fan-out-send` node receives incoming edges from both `generate-summary` and `generate-image` (Fan-In):

```json
{
  "Workflows": {
    "Bitcoin": {
      "SlotKey": "Bitcoin",
      "Nodes": [
        {
          "Id": "fetch-feeds",
          "Type": "FetchHttp",
          "Parameters": {
            "Urls": [ "[https://bitcoin.org/feed.xml](https://bitcoin.org/feed.xml)" ]
          },
          "OutputKey": "sourceContent",
          "NextNodeIds": [ "generate-summary" ]
        },
        {
          "Id": "generate-summary",
          "Type": "AiText",
          "Parameters": {
            "Provider": "OpenAi",
            "StepId": "Feed.Summary",
            "InputKey": "sourceContent"
          },
          "OutputKey": "baseSummary",
          "NextNodeIds": [ "generate-image-prompt", "fan-out-send" ]
        },
        {
          "Id": "generate-image-prompt",
          "Type": "AiText",
          "Parameters": {
            "Provider": "DeepSeek",
            "StepId": "Feed.ImagePromptDerivation",
            "InputKey": "baseSummary"
          },
          "OutputKey": "imagePrompt",
          "NextNodeIds": [ "generate-image" ]
        },
        {
          "Id": "generate-image",
          "Type": "AiImage",
          "Parameters": {
            "Provider": "FalAi",
            "StepId": "Feed.ImageGeneration",
            "InputKey": "imagePrompt"
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

### 6. Workflow Orchestrator Integration

`WorkflowOrchestrator` uses `WorkflowContextKeys.SendResults` to retrieve the output produced by the workflow execution:

```csharp
public class WorkflowOrchestrator : BaseOrchestrator
{
    private readonly IWorkflowEngine _engine;
    private readonly IWorkflowDefinitionProvider _workflowProvider;
    private readonly IWorkflowContext _context;

    public WorkflowOrchestrator(
        IWorkflowEngine engine,
        IWorkflowDefinitionProvider workflowProvider,
        IWorkflowContext context,
        IEnumerable<ISender> senders,
        ILogger<WorkflowOrchestrator> logger) : base(senders, logger)
    {
        _engine = engine;
        _workflowProvider = workflowProvider;
        _context = context;
    }

    public override async Task<IReadOnlyDictionary<SenderPlatform, Post?>> OrchestrateAsync(CancellationToken ct)
    {
        var workflow = _workflowProvider.GetWorkflow(_context.SlotKey);
        
        await _engine.ExecuteAsync(workflow, _context, _senders, ct);

        return _context.GetData<IReadOnlyDictionary<SenderPlatform, Post?>>(WorkflowContextKeys.SendResults);
    }
}

```

---

## Migration Path

### Phase 1: Context, Keys & Core Infrastructure

1. Add `IWorkflowContext` and `WorkflowContext` (`ConcurrentDictionary` based).
2. Define `WorkflowContextKeys` constant class.
3. Create `NodeParameterExtractor` for safe JSON parameter handling.
4. Add unit tests for context and parameter extraction.

### Phase 2: Engine & Atomic Nodes Implementation

1. Implement `WorkflowExecutionEngine` with DAG cycle validation and Fan-Out / Fan-In scheduler.
2. Implement atomic nodes: `FetchHttpNode`, `AiTextNode`, `AiImageNode`.
3. Register nodes as Keyed Transient services in DI.

### Phase 3: Fan-Out Strategy & Generic Text Generation Integration

1. Implement `ITextGenerationService` abstraction.
2. Implement `FanOutSendNode` ensuring primary sender selection and platform-tailored fallback generation.

### Phase 4: Integration & Configuration Migration

1. Implement `WorkflowOrchestrator` using `WorkflowContextKeys.SendResults` and update `OrchestratorFactory`.
2. Migrate `Bitcoin` slot configuration to `appsettings.json` with correct data flow dependencies.

### Phase 5: Cleanup

1. Deprecate `FeedOrchestratorContext` and `PromptRole` enum.
2. Remove legacy concrete orchestrators once all slots are migrated.

---

## Consequences

### Positive

* **Correct Data & Execution DAG Topology**: Graph transitions match actual data input/output requirements across nodes.
* **Generic Fan-Out**: Decoupled from specific re-summarisation providers via generic text generation services.
* **Standardized Framework Contracts**: Standard context keys prevent magic string errors across orchestration boundaries.
* **Thread Safety**: Concurrent context operations prevent race conditions during parallel branch execution.
* **Extensible & Decoupled**: Workflows are fully declared in JSON configuration without code changes.

### Negative

* **Architectural Overhead**: Introduces explicit topological scheduling and synchronization abstractions.
* **Configuration Validation**: Workflow graphs require upfront validation to catch configuration errors before runtime.

## Related Issues

* #245 — Design extensible OrchestratorContext registration
* #246 — Design PromptRole scoping strategy