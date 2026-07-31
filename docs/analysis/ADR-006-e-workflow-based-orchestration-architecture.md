# ADR 006: Workflow-Based Orchestration Architecture

## Status

**Proposed**

## Context

The XPoster system currently uses a monolithic orchestrator hierarchy (`FeedOrchestrator`, `PowerLawOrchestrator`, `NoOrchestrator`) where each orchestrator is hardcoded to a specific pipeline. Each orchestrator encapsulates its own sequence of operations, prompt roles, and context types. This design works for a small number of fixed pipelines but does not scale as new publishing use cases emerge.

The system's evolution toward a workflow-based architecture is driven by:

1. **Diverse data sources**: different orchestrators may need to ingest from RSS feeds, MCP servers, private databases, webhooks, or user-defined APIs.
2. **Flexible processing chains**: the sequence of AI calls, transformations, and validations should be configurable per slot.
3. **Reusable steps**: a processing step from a feed pipeline might be reused in an alert or law-based pipeline.
4. **Fan-out and Fan-in patterns with agnostic media and length-aware content adaptation**: a single step's output must be consumable by multiple downstream steps in parallel, and converging branches must be synchronized before execution of dependent nodes. Content exceeding a sender's character limit must be re-generated or truncated according to sender constraints (`MessageMaxLength`), while attached media (images, videos, documents) must be handled generically without coupling to specific orchestrator types.
5. **External configuration**: all node behaviors and data flow mappings must remain configurable via `appsettings.json` or external providers, not hardcoded.

## Critical Requirement: Preserve Fan-Out with Agnostic Content & Media Adaptation

The system's fan-out pattern ensures that content generated from a single execution can be dispatched to multiple target platforms (Senders) with varying constraints. This pattern must support:

1. **Primary sender selection**: senders are ordered by `MessageMaxLength` descending; the widest sender (largest character limit) drives the primary content target.
2. **Dynamic input key mapping**: the fan-out node resolves its inputs (text, fallback generation source, attached media) dynamically from context keys declared in configuration.
3. **Media type neutrality**: media attachments are encapsulated generically (`MediaAttachment` supporting images, videos, documents, or `null`), allowing text-only workflows (e.g., `PowerLawOrchestrator`), image-attached workflows (`FeedOrchestrator`), and future video/document pipelines to share the exact same fan-out logic.
4. **Per-sender content adaptation**: for each subsequent sender (in descending limit order):
   - If the previous text fits within the current sender's `MessageMaxLength`, it is reused.
   - If it exceeds the limit and a fallback source key is provided, new content is generated from the **original source content** respecting the sender's limit.
   - If no fallback source is configured, safe length-adaptation (truncation) is applied.
5. **Post assembly**: each sender receives a `Post` containing tailored text and the shared `MediaAttachment` (if present).

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

### 5. Data Dependencies & Key Hardcoding in Nodes

Nodes previously assumed fixed key names (e.g., `"sourceContent"`, `"image"`, `"sendResults"`). This breaks compatibility with orchestrators that do not produce images (e.g., `PowerLawOrchestrator`) or workflows that ingest from non-feed sources. Node input/output keys must be configured dynamically via workflow definition parameters.

### 6. Media Coupling

Posts currently assume image payloads (`byte[]`). Future channels or existing text-only channels require a media-agnostic abstraction (`MediaAttachment`) that supports images, videos, documents, or text-only posts without modifying workflow nodes.

## Decision

We will transition from a fixed orchestrator-per-pipeline model to a **workflow-based Directed Acyclic Graph (DAG) architecture**. The workflow will be defined externally in configuration and executed dynamically by a thread-safe workflow engine.

### Core Principles

1. **Workflow = Directed Acyclic Graph (DAG) of nodes**
2. **Node = atomic unit of work** (data fetching, AI call, transformation, validation, sending)
3. **Context = thread-safe shared state** passed between nodes during execution, using standardized system keys and dynamic user keys
4. **DAG Execution Engine = topological scheduler** supporting parallel execution (Fan-Out), branch synchronization (Fan-In), cycle validation, and explicit data dependencies
5. **Step identification is string-based** (not enum-based), scoped to the workflow definition
6. **Fan-out is a generalized, media-agnostic node pattern** that dynamically resolves text, fallback content sources, and media attachments (`MediaAttachment`) based on node parameters

---

## Proposed Architecture

### 1. Media Attachment & Thread-Safe Workflow Context

Introduce `MediaAttachment` to support images, videos, documents, or text-only payloads, alongside a thread-safe context implementation using `ConcurrentDictionary`:

```csharp
namespace XPoster.Workflows.Models;

public enum MediaType
{
    Image,
    Video,
    Document
}

public record MediaAttachment(
    byte[] Data,
    MediaType Type,
    string MimeType,
    string FileName);

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
namespace XPoster.Workflows.Nodes;

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
namespace XPoster.Workflows.Utils;

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
namespace XPoster.Workflows.Engine;

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

### 4. Agnostic Fan-Out Node Implementation

`FanOutSendNode` resolves input keys (`TextKey`, `FallbackSourceKey`, `MediaKey`) dynamically from node parameters. It operates transparently whether media is attached or absent, and whether re-summarisation is supported or replaced by simple truncation:

```csharp
namespace XPoster.Workflows.Nodes;

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
        // 1. Dynamic Key Resolution from Parameters
        var textKey = NodeParameterExtractor.GetParameter<string>(input.Parameters, "TextKey");
        var fallbackSourceKey = NodeParameterExtractor.GetParameter<string?>(input.Parameters, "FallbackSourceKey", null);
        var mediaKey = NodeParameterExtractor.GetParameter<string?>(input.Parameters, "MediaKey", null);
        var stepId = NodeParameterExtractor.GetParameter<string?>(input.Parameters, "StepId", null);

        // 2. Dynamic Context Extraction
        var primaryText = input.Context.GetData<string>(textKey);

        string? sourceContent = !string.IsNullOrEmpty(fallbackSourceKey) && input.Context.HasData(fallbackSourceKey)
            ? input.Context.GetData<string>(fallbackSourceKey)
            : null;

        MediaAttachment? media = !string.IsNullOrEmpty(mediaKey) && input.Context.HasData(mediaKey)
            ? input.Context.GetData<MediaAttachment>(mediaKey)
            : null;

        // 3. Sender Adaptation Loop
        var orderedSenders = input.Senders.OrderByDescending(s => s.MessageMaxLength).ToList();
        var postMap = new Dictionary<SenderPlatform, Post?>();
        var currentText = primaryText;

        foreach (var sender in orderedSenders)
        {
            string finalText;

            if (currentText.Length <= sender.MessageMaxLength)
            {
                finalText = currentText;
            }
            else if (!string.IsNullOrEmpty(sourceContent) && !string.IsNullOrEmpty(stepId))
            {
                var stepOptions = _stepOptionsResolver.Resolve(stepId);
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
                finalText = adaptedContent;
            }
            else
            {
                // Fallback truncation if no source material or step ID is configured
                finalText = currentText[..sender.MessageMaxLength];
            }

            currentText = finalText;
            postMap[sender.Platform] = new Post
            {
                Content = finalText,
                Media = media
            };
        }

        input.Context.SetData(WorkflowContextKeys.SendResults, postMap);
        return new WorkflowNodeResult(Success: true, Output: postMap, ErrorMessage: null);
    }
}

```

### 5. Workflow Configurations Examples

#### Scenario A: Rich Feed Pipeline (`Bitcoin` - Image Attachment & Fallback Re-Summarisation)

```json
{
  "Workflows": {
    "Bitcoin": {
      "SlotKey": "Bitcoin",
      "Nodes": [
        {
          "Id": "fetch-feeds",
          "Type": "FetchHttp",
          "Parameters": { "Urls": [ "[https://bitcoin.org/feed.xml](https://bitcoin.org/feed.xml)" ] },
          "OutputKey": "sourceContent",
          "NextNodeIds": [ "generate-summary" ]
        },
        {
          "Id": "generate-summary",
          "Type": "AiText",
          "Parameters": { "Provider": "OpenAi", "StepId": "Feed.Summary", "InputKey": "sourceContent" },
          "OutputKey": "baseSummary",
          "NextNodeIds": [ "generate-image-prompt", "fan-out-send" ]
        },
        {
          "Id": "generate-image-prompt",
          "Type": "AiText",
          "Parameters": { "Provider": "DeepSeek", "StepId": "Feed.ImagePromptDerivation", "InputKey": "baseSummary" },
          "OutputKey": "imagePrompt",
          "NextNodeIds": [ "generate-image" ]
        },
        {
          "Id": "generate-image",
          "Type": "AiImage",
          "Parameters": { "Provider": "FalAi", "StepId": "Feed.ImageGeneration", "InputKey": "imagePrompt" },
          "OutputKey": "attachedMedia",
          "NextNodeIds": [ "fan-out-send" ]
        },
        {
          "Id": "fan-out-send",
          "Type": "FanOutSend",
          "Parameters": {
            "TextKey": "baseSummary",
            "FallbackSourceKey": "sourceContent",
            "MediaKey": "attachedMedia",
            "StepId": "Feed.Summary"
          },
          "NextNodeIds": []
        }
      ]
    }
  }
}

```

#### Scenario B: Text-Only Pipeline (`PowerLaw` - No Media, Simple Truncation/Formatting)

```json
{
  "Workflows": {
    "PowerLaw": {
      "SlotKey": "PowerLaw",
      "Nodes": [
        {
          "Id": "compute-powerlaw",
          "Type": "PowerLawCalculation",
          "Parameters": { "Model": "Santostasi" },
          "OutputKey": "rawModelText",
          "NextNodeIds": [ "fan-out-send" ]
        },
        {
          "Id": "fan-out-send",
          "Type": "FanOutSend",
          "Parameters": {
            "TextKey": "rawModelText"
          },
          "NextNodeIds": []
        }
      ]
    }
  }
}

```

### 6. Workflow Orchestrator Integration

`WorkflowOrchestrator` relies exclusively on `WorkflowContextKeys.SendResults`:

```csharp
namespace XPoster.Orchestrators;

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

### Phase 1: Context, Media & Core Infrastructure

1. Add `IWorkflowContext`, `WorkflowContext` (`ConcurrentDictionary`), and `WorkflowContextKeys`.
2. Define `MediaAttachment` and `MediaType` models.
3. Create `NodeParameterExtractor` for safe JSON parameter deserialization.
4. Add unit tests for context operations and dynamic parameter extraction.

### Phase 2: Engine & Atomic Nodes Implementation

1. Implement `WorkflowExecutionEngine` with DAG cycle validation and Fan-Out / Fan-In scheduler.
2. Implement atomic nodes: `FetchHttpNode`, `AiTextNode`, `AiImageNode`.
3. Register nodes as Keyed Transient services in DI.

### Phase 3: Generic Fan-Out Node Implementation

1. Implement `ITextGenerationService` abstraction.
2. Implement `FanOutSendNode` with dynamic key mapping, supporting both text-only and media-attached post dispatching.

### Phase 4: Integration & Workflow Configuration Migration

1. Implement `WorkflowOrchestrator` using `WorkflowContextKeys.SendResults` and update `OrchestratorFactory`.
2. Migrate `Bitcoin` (rich media) and `PowerLaw` (text-only) configurations to `appsettings.json`.

### Phase 5: Cleanup

1. Deprecate `FeedOrchestratorContext` and `PromptRole` enum.
2. Remove legacy concrete orchestrator classes (`FeedOrchestrator`, `PowerLawOrchestrator`) once all slots are migrated.

---

## Consequences

### Positive

* **Agnostic & Reusable Fan-Out**: Single `FanOutSendNode` handles text-only, image, video, and document workflows without code modification.
* **Dynamic Key Mapping**: Input/output context keys are specified entirely in configuration, preventing hardcoded key assumptions.
* **True DAG Execution**: Parallel branch execution and fan-in synchronization are natively supported.
* **Thread Safety**: Concurrent context operations prevent race conditions during parallel branch execution.
* **Standardized Framework Contracts**: Standard context keys prevent magic string errors across orchestration boundaries.

### Negative

* **Architectural Overhead**: Introduces explicit topological scheduling and synchronization abstractions.
* **Configuration Validation**: Workflow graphs require upfront validation to catch missing input keys or cyclic connections before runtime.

## Related Issues

* #245 — Design extensible OrchestratorContext registration
* #246 — Design PromptRole scoping strategy