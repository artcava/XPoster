# ADR 006: Workflow-Based DAG Orchestration Architecture (Definitive)

## Status

**Proposed**

## Context

The current XPoster architecture relies on a rigid, monolithic orchestrator hierarchy (`FeedOrchestrator`, `PowerLawOrchestrator`, `NoOrchestrator`). Each slot or pipeline is bound to a specific class that hardcodes the execution sequence, AI service invocations, and target publishing channels.

Analysis of the current `Program.cs`, `OrchestratorFactory`, and the codebase revealed the following critical limitations:

1. **Tight Coupling to Enums and Proprietary Contexts**: `FeedOrchestrator` depends directly on `FeedOrchestratorContext` and the `PromptRole` enum (`Summary`, `ImagePromptDerivation`, `ImageGeneration`). Adding any new step or pipeline variant requires extending enums and recompiling core code.
2. **Keyed Services and Dynamic Injection**: In `Program.cs`, AI providers are registered as Keyed Services (`AddXPosterAiProviders()`). Directly injecting `ITextToTextProvider` into a rigid node prevents selecting AI providers (`"OpenAi"`, `"DeepSeek"`, `"FalAi"`) dynamically per step via JSON configuration.
3. **Payload Type Rigidity**: The `Post` structure assumes media attachments are exclusively `byte[]` image arrays. It lacks abstractions for text-only posts, videos, or multi-media documents.
4. **Hardcoded Variable Keys**: Current execution steps assume fixed key names (e.g., `"sourceContent"`), preventing node reuse across pipelines with different input sources (e.g., RSS feeds, calculation engines, webhooks).
5. **Inability to Support Parallel Branching (DAGs)**: The sequential execution model cannot handle parallel branches (e.g., generating text and image prompts concurrently) or dynamic text re-summarization tailored to senders with varying `MessageMaxLength` constraints.
6. **No Integration Point**: The existing `OrchestratorFactory` uses reflection (`Activator.CreateInstance`) to instantiate orchestrators. There is no way to introduce the workflow engine without either replacing or wrapping this factory pattern.

### Current Architecture Reference

| Component | File | Role |
|---|---|---|
| `IOrchestrator` | `src/Contracts/Interfaces/IOrchestrator.cs` | Orchestrator contract |
| `BaseOrchestrator` | `src/Orchestrators/BaseOrchestrator.cs` | Fan-out dispatch to senders |
| `FeedOrchestrator` | `src/Orchestrators/FeedOrchestrator.cs` | RSS → AI text → AI image → posts |
| `PowerLawOrchestrator` | `src/Orchestrators/PowerLawOrchestrator.cs` | Deterministic math-based posts |
| `OrchestratorFactory` | `src/Orchestrators/OrchestratorFactory.cs` | Hour-based slot resolution |
| `Post` | `src/Models/Post.cs` | `Content` + `byte[]? Image` |
| `PromptRole` | `src/Models/PromptRole.cs` | Enum: Summary, ImagePromptDerivation, ImageGeneration |
| `FeedOrchestratorContext` | `src/Models/FeedOrchestratorContext.cs` | FeedUrls + PromptOptions |
| `PromptStepOptions` | `src/Models/PromptStepOptions.cs` | Role + templates + temperature + limits |
| `FeedPromptOptions` | `src/Models/FeedPromptOptions.cs` | `GetStep(PromptRole)` lookup |
| `ScheduledOrchestrationProfile` | `src/Models/ScheduledOrchestrationProfile.cs` | Hour + orchestrator type + providers + platforms |
| `ISlotProfileProvider` | `src/Contracts/Interfaces/ISlotProfileProvider.cs` | Profile resolution |
| `local.settings.json` | `src/local.settings.json` | Azure Functions configuration (no appsettings.json) |

---

## Decision

We will adopt a **Workflow Engine based on a Directed Acyclic Graph (DAG)** while leaving the **business logic of legacy infrastructure services (`FeedService`, `OpenAiService`, `TagReplacementService`) completely intact**.

Workflow nodes (`IWorkflowNode`) will act as **Adapters**: they will bridge the thread-safe `WorkflowContext` to existing service interfaces, parsing execution parameters via a utility (`NodeParameterExtractor`) and resolving prompt configurations via `IStepOptionsResolver`.

### Architectural Principles

1. **Zero Breaking Changes to Infrastructure Services**: Services registered in `Program.cs` (`IFeedService`, `ITagReplacementProvider`, `ITagReplacementService`, etc.) remain untouched.
2. **Deprecation of `PromptRole` and `FeedOrchestratorContext`**: Prompt configurations are retrieved directly from `local.settings.json` under `PromptSteps:{StepId}` via `IStepOptionsResolver`. The `FeedPromptOptions.GetStep(PromptRole)` lookup is replaced by string-keyed step resolution.
3. **Media-Agnostic Abstraction (`MediaAttachment`)**: Native support for images, videos, and documents through a single record.
4. **Decoupling via Dynamic Keys**: Each node receives the context keys to read from and write to via configuration parameters (`InputKey`, `OutputKey`, `TextKey`, `MediaKey`, `FallbackSourceKey`).
5. **Thread-Safe Context Isolation (`WorkflowContext`)**: Uses `ConcurrentDictionary` to guarantee safety during parallel branch executions.
6. **Dynamic Node and AI Provider Resolution**: Workflow nodes and AI providers are resolved dynamically at runtime via .NET **Keyed Services**.
7. **Bridging Strategy**: A `WorkflowOrchestrator` implements `IOrchestrator` and delegates to `IWorkflowEngine`, preserving the existing `OrchestratorFactory` pattern and `ScheduledOrchestrationProfile` resolution.

---

## Detailed Component Specifications

### 1. DAG Engine Contracts (`IWorkflowNode`, Input, Result)

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
```

**Note**: `WorkflowNodeInput` passes the full `Senders` list. Individual nodes decide whether to fan-out (e.g., `FanOutSendNode`) or not.

---

### 2. Thread-Safe Execution Context & Media Model

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

    public void SetData(string key, object value) => _data[key] = value;
    public bool HasData(string key) => _data.ContainsKey(key);
}
```

---

### 3. Parameter Extractor Utility (`NodeParameterExtractor`)

Handles heuristic conversion from JSON representations (such as `JsonElement`) to strongly-typed C# objects. This is critical because `IConfiguration` binds JSON values as `JsonElement` when deserialized into `Dictionary<string, object>`.

```csharp
namespace XPoster.Workflows.Utilities;

public static class NodeParameterExtractor
{
    public static T GetParameter<T>(IReadOnlyDictionary<string, object> parameters, string key, T defaultValue = default!)
    {
        if (!parameters.TryGetValue(key, out var val) || val == null)
            return defaultValue;

        if (val is T typedVal)
            return typedVal;

        if (val is JsonElement jsonElement)
        {
            var rawText = jsonElement.GetRawText();
            var deserialized = JsonSerializer.Deserialize<T>(rawText);
            return deserialized ?? defaultValue;
        }

        try
        {
            return (T)Convert.ChangeType(val, typeof(T));
        }
        catch
        {
            return defaultValue;
        }
    }
}
```

---

### 4. Step Options Resolver (`IStepOptionsResolver`)

Replaces the `PromptRole` enum by binding configuration directly from the `PromptSteps:{StepId}` section in `IConfiguration`. Each node specifies its own `StepId` parameter, decoupling step resolution from enum values.

**Important**: The current `PromptStepOptions` record (at `src/Models/PromptStepOptions.cs:1-55`) contains a `Role` property of type `PromptRole`. The new `PromptStepOptions` used by `IStepOptionsResolver` is a **separate, simplified record** that drops the `Role` property. The existing `PromptStepOptions` and `FeedPromptOptions` are **deprecated but not removed** during the transition period.

```csharp
namespace XPoster.Workflows.Services;

public interface IStepOptionsResolver
{
    PromptStepOptions Resolve(string stepId);
}

public class ConfigurationStepOptionsResolver : IStepOptionsResolver
{
    private readonly IConfiguration _configuration;

    public ConfigurationStepOptionsResolver(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public PromptStepOptions Resolve(string stepId)
    {
        var stepOptions = _configuration
            .GetSection($"PromptSteps:{stepId}")
            .Get<PromptStepOptions>();

        return stepOptions ?? throw new InvalidOperationException($"PromptStepOptions missing for StepId: '{stepId}'.");
    }
}
```

The `PromptStepOptions` record for the workflow engine:

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

---

### 5. Workflow Engine Definition and Execution (`IWorkflowEngine`)

```csharp
namespace XPoster.Workflows.Engine;

public record WorkflowNodeDefinition(
    string Id,
    string Type,
    Dictionary<string, object> Parameters,
    string? OutputKey,
    List<string> NextNodeIds);

public record WorkflowDefinition(
    string SlotKey,
    List<WorkflowNodeDefinition> Nodes);

public record WorkflowExecutionResult(
    bool Success,
    IWorkflowContext Context,
    string? ErrorMessage);

public interface IWorkflowEngine
{
    Task<WorkflowExecutionResult> ExecuteAsync(WorkflowDefinition definition, IReadOnlyList<ISender> senders, CancellationToken ct);
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

    public async Task<WorkflowExecutionResult> ExecuteAsync(WorkflowDefinition definition, IReadOnlyList<ISender> senders, CancellationToken ct)
    {
        var context = new WorkflowContext { SlotKey = definition.SlotKey };
        var nodeMap = definition.Nodes.ToDictionary(n => n.Id);

        // Validate DAG: detect cycles and missing references
        var validationError = ValidateDag(definition, nodeMap);
        if (validationError != null)
        {
            return new WorkflowExecutionResult(false, context, validationError);
        }

        // Compute in-degrees for topological sorting (Kahn's algorithm)
        var inDegree = definition.Nodes.ToDictionary(n => n.Id, _ => 0);
        foreach (var node in definition.Nodes)
        {
            foreach (var nextId in node.NextNodeIds)
            {
                if (inDegree.ContainsKey(nextId))
                    inDegree[nextId]++;
            }
        }

        var readyNodes = new Queue<string>(inDegree.Where(kvp => kvp.Value == 0).Select(kvp => kvp.Key));

        while (readyNodes.Count > 0)
        {
            var currentNodeId = readyNodes.Dequeue();
            var nodeDef = nodeMap[currentNodeId];

            _logger.LogInformation("Executing node '{NodeId}' of type '{NodeType}' for slot '{SlotKey}'", nodeDef.Id, nodeDef.Type, definition.SlotKey);

            var nodeInstance = _serviceProvider.GetKeyedService<IWorkflowNode>(nodeDef.Type);
            if (nodeInstance == null)
            {
                return new WorkflowExecutionResult(false, context, $"No IWorkflowNode registered with key '{nodeDef.Type}'.");
            }

            var input = new WorkflowNodeInput(context, nodeDef.Parameters, senders);
            var result = await nodeInstance.ExecuteAsync(input, ct);

            if (!result.Success)
            {
                _logger.LogError("Node '{NodeId}' failed: {Error}", nodeDef.Id, result.ErrorMessage);
                return new WorkflowExecutionResult(false, context, result.ErrorMessage);
            }

            if (!string.IsNullOrEmpty(nodeDef.OutputKey) && result.Output != null)
            {
                context.SetData(nodeDef.OutputKey, result.Output);
            }

            foreach (var nextId in nodeDef.NextNodeIds)
            {
                inDegree[nextId]--;
                if (inDegree[nextId] == 0)
                {
                    readyNodes.Enqueue(nextId);
                }
            }
        }

        return new WorkflowExecutionResult(true, context, null);
    }

    private string? ValidateDag(WorkflowDefinition definition, Dictionary<string, WorkflowNodeDefinition> nodeMap)
    {
        // Check for missing references
        foreach (var node in definition.Nodes)
        {
            foreach (var nextId in node.NextNodeIds)
            {
                if (!nodeMap.ContainsKey(nextId))
                    return $"Node '{node.Id}' references non-existent node '{nextId}'.";
            }
        }

        // Check for cycles using DFS
        var visited = new HashSet<string>();
        var inStack = new HashSet<string>();

        bool HasCycle(string nodeId)
        {
            if (inStack.Contains(nodeId)) return true;
            if (visited.Contains(nodeId)) return false;

            visited.Add(nodeId);
            inStack.Add(nodeId);

            if (nodeMap.TryGetValue(nodeId, out var nodeDef))
            {
                foreach (var nextId in nodeDef.NextNodeIds)
                {
                    if (HasCycle(nextId)) return true;
                }
            }

            inStack.Remove(nodeId);
            return false;
        }

        foreach (var nodeId in nodeMap.Keys)
        {
            if (HasCycle(nodeId))
                return $"Cycle detected involving node '{nodeId}'.";
        }

        return null;
    }
}
```

**Note on Parallel Execution**: The current implementation uses Kahn's algorithm for sequential topological execution. True parallel execution of independent branches (nodes with the same in-degree that become ready simultaneously) can be added as a future enhancement by batching nodes from the queue and executing them via `Task.WhenAll`. The thread-safe `WorkflowContext` already supports this.

---

### 6. Adapter Node Implementations

#### A. `FetchRssNode` (Adapter for `IFeedService` and `ITagReplacementProvider`)

```csharp
namespace XPoster.Workflows.Nodes;

public class FetchRssNode : IWorkflowNode
{
    public string NodeType => "FetchRss";

    private readonly IFeedService _feedService;
    private readonly ITagReplacementProvider _tagReplacementProvider;

    public FetchRssNode(IFeedService feedService, ITagReplacementProvider tagReplacementProvider)
    {
        _feedService = feedService;
        _tagReplacementProvider = tagReplacementProvider;
    }

    public async Task<WorkflowNodeResult> ExecuteAsync(WorkflowNodeInput input, CancellationToken ct)
    {
        var urls = NodeParameterExtractor.GetParameter<List<string>>(input.Parameters, "Urls", []);
        if (urls.Count == 0)
        {
            return new WorkflowNodeResult(false, null, "No URLs provided for FetchRss node.");
        }

        var end = DateTimeOffset.UtcNow;
        var start = end.AddDays(-1);
        var keywords = _tagReplacementProvider.GetReplacements().Keys;

        var sb = new StringBuilder();
        foreach (var url in urls)
        {
            var feeds = await _feedService.GetFeedsAsync(url, start, end, keywords, ct);
            foreach (var feed in feeds)
            {
                sb.AppendLine($"{feed.Title}: {feed.Content}");
            }
        }

        var content = sb.ToString();
        if (string.IsNullOrWhiteSpace(content))
        {
            return new WorkflowNodeResult(false, null, "No RSS feed content retrieved in the last 24 hours.");
        }

        return new WorkflowNodeResult(true, content, null);
    }
}
```

#### B. `AiTextNode` (Adapter for Keyed `ITextToTextProvider`)

```csharp
namespace XPoster.Workflows.Nodes;

public class AiTextNode : IWorkflowNode
{
    public string NodeType => "AiText";

    private readonly IServiceProvider _serviceProvider;
    private readonly IStepOptionsResolver _stepOptionsResolver;

    public AiTextNode(IServiceProvider serviceProvider, IStepOptionsResolver stepOptionsResolver)
    {
        _serviceProvider = serviceProvider;
        _stepOptionsResolver = stepOptionsResolver;
    }

    public async Task<WorkflowNodeResult> ExecuteAsync(WorkflowNodeInput input, CancellationToken ct)
    {
        var providerName = NodeParameterExtractor.GetParameter<string>(input.Parameters, "Provider", "OpenAi");
        var stepId = NodeParameterExtractor.GetParameter<string>(input.Parameters, "StepId");
        var inputKey = NodeParameterExtractor.GetParameter<string>(input.Parameters, "InputKey");

        var inputText = input.Context.GetData<string>(inputKey);
        var stepOptions = _stepOptionsResolver.Resolve(stepId);

        var textProvider = _serviceProvider.GetKeyedService<ITextToTextProvider>(providerName)
            ?? throw new InvalidOperationException($"ITextToTextProvider for '{providerName}' is not registered.");

        var request = new PromptRequest
        {
            InputText = inputText,
            SystemPromptTemplate = stepOptions.SystemPromptTemplate,
            UserPromptTemplate = stepOptions.UserPromptTemplate,
            Temperature = stepOptions.Temperature,
            MaxOutputLength = stepOptions.MaxOutputLength,
            MaxTokenBudget = stepOptions.MaxTokenBudget,
            InputTextLabel = stepOptions.InputTextLabel
        };

        var resultText = await textProvider.GenerateTextAsync(request, ct);

        if (string.IsNullOrWhiteSpace(resultText))
        {
            return new WorkflowNodeResult(false, null, $"Text generation failed for step '{stepId}'.");
        }

        return new WorkflowNodeResult(true, resultText, null);
    }
}
```

#### C. `AiImageNode` (Adapter for Keyed `ITextToImageProvider` -> `MediaAttachment`)

```csharp
namespace XPoster.Workflows.Nodes;

public class AiImageNode : IWorkflowNode
{
    public string NodeType => "AiImage";

    private readonly IServiceProvider _serviceProvider;
    private readonly IStepOptionsResolver _stepOptionsResolver;

    public AiImageNode(IServiceProvider serviceProvider, IStepOptionsResolver stepOptionsResolver)
    {
        _serviceProvider = serviceProvider;
        _stepOptionsResolver = stepOptionsResolver;
    }

    public async Task<WorkflowNodeResult> ExecuteAsync(WorkflowNodeInput input, CancellationToken ct)
    {
        var providerName = NodeParameterExtractor.GetParameter<string>(input.Parameters, "Provider", "OpenAi");
        var stepId = NodeParameterExtractor.GetParameter<string>(input.Parameters, "StepId");
        var inputKey = NodeParameterExtractor.GetParameter<string>(input.Parameters, "InputKey");

        var promptText = input.Context.GetData<string>(inputKey);
        var stepOptions = _stepOptionsResolver.Resolve(stepId);

        var imageProvider = _serviceProvider.GetKeyedService<ITextToImageProvider>(providerName)
            ?? throw new InvalidOperationException($"ITextToImageProvider for '{providerName}' is not registered.");

        var request = new ImagePromptRequest
        {
            InputText = promptText,
            SystemPromptTemplate = stepOptions.SystemPromptTemplate,
            UserPromptTemplate = stepOptions.UserPromptTemplate,
            Temperature = stepOptions.Temperature,
            ImageQuantity = stepOptions.ImageQuantity,
            ImageSize = stepOptions.ImageSize,
            InputTextLabel = stepOptions.InputTextLabel
        };

        var imageBytes = await imageProvider.GenerateImageAsync(request, ct);

        if (imageBytes == null || imageBytes.Length == 0)
        {
            // Soft failure: allows workflow execution to continue without image attachment
            return new WorkflowNodeResult(true, null, "Image generation returned empty or failed content.");
        }

        var media = new MediaAttachment(
            Data: imageBytes,
            Type: MediaType.Image,
            MimeType: "image/png",
            FileName: "generated_image.png");

        return new WorkflowNodeResult(true, media, null);
    }
}
```

#### D. `FanOutSendNode` (Per-Sender Length Adaptation and `ITagReplacementService`)

**Design Decision**: The `FanOutSendNode` processes senders in descending `MessageMaxLength` order. For each sender, if the text exceeds the sender's limit and a `FallbackSourceKey` + `StepId` are provided, it re-summarizes the original source content with `MaxOutputLength` set to the sender's limit. This preserves the current `FeedOrchestrator` behavior where the longest-summary sender gets the full text and shorter-limit senders get re-summarized versions.

```csharp
namespace XPoster.Workflows.Nodes;

public class FanOutSendNode : IWorkflowNode
{
    public string NodeType => "FanOutSend";

    private readonly IServiceProvider _serviceProvider;
    private readonly IStepOptionsResolver _stepOptionsResolver;
    private readonly ITagReplacementService _tagReplacementService;

    public FanOutSendNode(
        IServiceProvider serviceProvider,
        IStepOptionsResolver stepOptionsResolver,
        ITagReplacementService tagReplacementService)
    {
        _serviceProvider = serviceProvider;
        _stepOptionsResolver = stepOptionsResolver;
        _tagReplacementService = tagReplacementService;
    }

    public async Task<WorkflowNodeResult> ExecuteAsync(WorkflowNodeInput input, CancellationToken ct)
    {
        var textKey = NodeParameterExtractor.GetParameter<string>(input.Parameters, "TextKey");
        var fallbackSourceKey = NodeParameterExtractor.GetParameter<string?>(input.Parameters, "FallbackSourceKey", null);
        var mediaKey = NodeParameterExtractor.GetParameter<string?>(input.Parameters, "MediaKey", null);
        var stepId = NodeParameterExtractor.GetParameter<string?>(input.Parameters, "StepId", null);
        var providerName = NodeParameterExtractor.GetParameter<string>(input.Parameters, "Provider", "OpenAi");

        var primaryText = input.Context.GetData<string>(textKey);

        string? sourceContent = !string.IsNullOrEmpty(fallbackSourceKey) && input.Context.HasData(fallbackSourceKey)
            ? input.Context.GetData<string>(fallbackSourceKey)
            : null;

        MediaAttachment? media = !string.IsNullOrEmpty(mediaKey) && input.Context.HasData(mediaKey)
            ? input.Context.GetData<MediaAttachment>(mediaKey)
            : null;

        var orderedSenders = input.Senders.OrderByDescending(s => s.MessageMaxLength).ToList();
        var postMap = new Dictionary<SenderPlatform, Post?>();

        foreach (var sender in orderedSenders)
        {
            string finalText;

            if (primaryText.Length <= sender.MessageMaxLength)
            {
                finalText = primaryText;
            }
            else if (!string.IsNullOrEmpty(sourceContent) && !string.IsNullOrEmpty(stepId))
            {
                var stepOptions = _stepOptionsResolver.Resolve(stepId);
                var textProvider = _serviceProvider.GetKeyedService<ITextToTextProvider>(providerName);

                if (textProvider != null)
                {
                    var reSummaryRequest = new PromptRequest
                    {
                        InputText = sourceContent,
                        SystemPromptTemplate = stepOptions.SystemPromptTemplate,
                        UserPromptTemplate = stepOptions.UserPromptTemplate,
                        Temperature = stepOptions.Temperature,
                        MaxOutputLength = sender.MessageMaxLength,
                        MaxTokenBudget = stepOptions.MaxTokenBudget,
                        InputTextLabel = stepOptions.InputTextLabel
                    };

                    finalText = await textProvider.GenerateTextAsync(reSummaryRequest, ct);
                }
                else
                {
                    finalText = primaryText[..sender.MessageMaxLength];
                }
            }
            else
            {
                finalText = primaryText[..sender.MessageMaxLength];
            }

            var formattedContent = _tagReplacementService.Apply(finalText);

            postMap[sender.Platform] = new Post
            {
                Content = formattedContent,
                Media = media?.Data
            };
        }

        input.Context.SetData(WorkflowContextKeys.SendResults, postMap);
        return new WorkflowNodeResult(Success: true, Output: postMap, ErrorMessage: null);
    }
}
```

**Critical Detail**: The `Post.Media` property is `byte[]?`, so the `MediaAttachment.Data` is extracted when constructing the `Post`. This bridges the new `MediaAttachment` abstraction to the existing `Post` record without modifying `Post`.

---

### 7. WorkflowOrchestrator (Bridge between `IOrchestrator` and `IWorkflowEngine`)

This is the **missing integration piece** from ADR-006-f. The `WorkflowOrchestrator` implements `IOrchestrator` and delegates to `IWorkflowEngine`, allowing the existing `OrchestratorFactory` to instantiate it via the same reflection-based pattern.

```csharp
namespace XPoster.Orchestrators;

public class WorkflowOrchestrator : BaseOrchestrator
{
    private readonly IWorkflowEngine _workflowEngine;
    private readonly WorkflowDefinition _workflowDefinition;

    public override string Name => "WorkflowOrchestrator";
    public override bool SendIt => true;
    public override bool ProduceImage => true;
    public override IReadOnlyList<SenderPlatform> SupportedPlatforms =>
        Enum.GetValues<SenderPlatform>().Where(p => p != SenderPlatform.DryRun).ToList();

    public WorkflowOrchestrator(
        IReadOnlyList<ISender> senders,
        ILogger<WorkflowOrchestrator> logger,
        IWorkflowEngine workflowEngine,
        WorkflowDefinition workflowDefinition)
        : base(senders, logger)
    {
        _workflowEngine = workflowEngine;
        _workflowDefinition = workflowDefinition;
    }

    public override async Task<Dictionary<SenderPlatform, Post?>> OrchestrateAsync(CancellationToken ct)
    {
        var result = await _workflowEngine.ExecuteAsync(_workflowDefinition, _senders, ct);

        if (!result.Success)
        {
            _logger.LogError("Workflow failed for slot '{SlotKey}': {Error}", _workflowDefinition.SlotKey, result.ErrorMessage);
            return new Dictionary<SenderPlatform, Post?>();
        }

        if (result.Context.TryGetData<Dictionary<SenderPlatform, Post?>>(WorkflowContextKeys.SendResults, out var postMap))
        {
            return postMap;
        }

        _logger.LogWarning("Workflow completed but no SendResults found in context for slot '{SlotKey}'", _workflowDefinition.SlotKey);
        return new Dictionary<SenderPlatform, Post?>();
    }
}
```

---

### 8. WorkflowDefinition Loading from Configuration

The `WorkflowDefinition` is loaded from the `Workflows:{SlotKey}` section of `local.settings.json` and registered as a keyed singleton keyed by slot name.

```csharp
namespace XPoster.Workflows.Configuration;

public static class WorkflowServiceCollectionExtensions
{
    public static IServiceCollection AddWorkflows(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IStepOptionsResolver, ConfigurationStepOptionsResolver>();
        services.AddTransient<IWorkflowEngine, WorkflowExecutionEngine>();

        // Register workflow nodes as keyed services
        services.AddKeyedTransient<IWorkflowNode, FetchRssNode>("FetchRss");
        services.AddKeyedTransient<IWorkflowNode, AiTextNode>("AiText");
        services.AddKeyedTransient<IWorkflowNode, AiImageNode>("AiImage");
        services.AddKeyedTransient<IWorkflowNode, FanOutSendNode>("FanOutSend");

        // Load and register workflow definitions from configuration
        var workflowsSection = configuration.GetSection("Workflows");
        foreach (var slotSection in workflowsSection.GetChildren())
        {
            var slotKey = slotSection.Key;
            var definition = slotSection.Get<WorkflowDefinition>();
            if (definition != null)
            {
                services.AddKeyedSingleton<WorkflowDefinition>(slotKey, (sp, _) => definition);
            }
        }

        return services;
    }
}
```

---

### 9. OrchestratorFactory Adaptation

The `OrchestratorFactory.Resolve()` method is extended to detect `WorkflowOrchestrator` and resolve the `WorkflowDefinition` from DI:

```csharp
// In OrchestratorFactory.Resolve(), after resolving senders and providers:

if (profile.OrchestratorType == typeof(WorkflowOrchestrator))
{
    var workflowDefinition = _serviceProvider.GetKeyedService<WorkflowDefinition>(profile.OrchestratorContextKey);
    if (workflowDefinition == null)
    {
        _logger.LogWarning("No WorkflowDefinition found for key '{Key}'. Returning NoOrchestrator.", profile.OrchestratorContextKey);
        return new NoOrchestrator(_serviceProvider.GetRequiredService<ILogger<NoOrchestrator>>());
    }

    var workflowEngine = _serviceProvider.GetRequiredService<IWorkflowEngine>();
    return new WorkflowOrchestrator(senders, logger, workflowEngine, workflowDefinition);
}
```

This requires adding `IWorkflowEngine` to the `_serviceProvider` resolution in the factory constructor.

---

### 10. Dependency Injection Refactoring (`Program.cs`)

Below is the exact update to `Program.cs`, removing legacy `FeedOrchestratorContext` registrations and adding workflow engine registrations:

```csharp
// --- REMOVAL OF LEGACY CONTEXT ---
// builder.Services.AddKeyedSingleton<FeedOrchestratorContext>("Bitcoin", (sp, _) =>
//     builder.Configuration.GetSection("FeedSlotContexts:Bitcoin").Get<FeedOrchestratorContext>()!);

// --- WORKFLOW ENGINE REGISTRATIONS ---
builder.Services.AddWorkflows(builder.Configuration);
```

The `AddWorkflows` extension method (from section 8) handles all workflow-related registrations.

---

### 11. Configuration Example (`local.settings.json`)

**Important**: The project uses `local.settings.json` (Azure Functions convention), not `appsettings.json`.

```json
{
  "PromptSteps": {
    "Feed.Summary": {
      "SystemPromptTemplate": "Summarize in under {MaxChars} characters.",
      "UserPromptTemplate": "{Text}",
      "Temperature": 0.3,
      "MaxTokenBudget": 500,
      "InputTextLabel": "{Text}"
    },
    "Feed.ImagePromptDerivation": {
      "SystemPromptTemplate": "Create an image generation prompt.",
      "UserPromptTemplate": "{Text}",
      "Temperature": 0.7,
      "MaxTokenBudget": 200,
      "InputTextLabel": "{Text}"
    },
    "Feed.ImageGeneration": {
      "SystemPromptTemplate": "",
      "UserPromptTemplate": "{Text}",
      "ImageSize": "1024x1024",
      "ImageQuantity": 1,
      "InputTextLabel": "{Text}"
    }
  },
  "Workflows": {
    "Bitcoin": {
      "SlotKey": "Bitcoin",
      "Nodes": [
        {
          "Id": "fetch-rss",
          "Type": "FetchRss",
          "Parameters": { "Urls": [ "https://cointelegraph.com/rss/tag/bitcoin", "https://www.coindesk.com/arc/outboundfeeds/rss" ] },
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
          "Parameters": { "Provider": "OpenAi", "StepId": "Feed.ImagePromptDerivation", "InputKey": "baseSummary" },
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
            "StepId": "Feed.Summary",
            "Provider": "OpenAi"
          },
          "NextNodeIds": []
        }
      ]
    }
  }
}
```

---

### 12. Migration Path

The migration follows a **Strangler Fig** pattern:

1. **Phase 1 (This ADR)**: Implement the workflow engine alongside existing orchestrators. `FeedOrchestrator` and `PowerLawOrchestrator` continue to work unchanged. New workflows can be defined in configuration.

2. **Phase 2**: Migrate the `FeedOrchestrator` "Bitcoin" slot to a `WorkflowOrchestrator` with the equivalent DAG defined in `Workflows:Bitcoin` configuration. Update `DefaultSlotProfileProvider` to use `typeof(WorkflowOrchestrator)` for the Bitcoin slot.

3. **Phase 3**: Deprecate `FeedOrchestrator`, `FeedOrchestratorContext`, `FeedPromptOptions`, and the `PromptRole` enum. Remove the `Role` property from the legacy `PromptStepOptions`.

4. **Phase 4**: Optionally convert `PowerLawOrchestrator` to a workflow (though its deterministic nature may not benefit from DAG orchestration).

---

## Consequences

### Positive

* **Zero Rewriting of Infrastructure Services**: `FeedService`, `OpenAiService`, `TagReplacementService`, and all registered AI providers in `Program.cs` remain completely unchanged.
* **Architectural Flexibility**: Modifying or introducing new workflow steps occurs purely via configuration files without code recompilation or enum modifications.
* **Multi-Media Support**: `MediaAttachment` expands system capabilities to handle text, images, videos, and multi-page documents seamlessly.
* **Parallel Execution Safety**: The thread-safe `WorkflowContext` with `ConcurrentDictionary` prevents race conditions. True parallel node execution can be added as a future enhancement.
* **Backward Compatibility**: The `WorkflowOrchestrator` bridge preserves the existing `OrchestratorFactory` pattern, allowing incremental migration.
* **DAG Validation**: Cycle detection and missing reference validation at engine startup prevent runtime errors from misconfigured workflows.

### Negative

* **Configuration Overhead**: Mismatches between context keys (`InputKey`, `OutputKey`) will cause runtime exceptions. The DAG validation in the engine mitigates this for structural issues, but key-level mismatches remain a runtime concern.
* **Increased Complexity**: The workflow engine adds abstraction layers. For simple pipelines (like `PowerLawOrchestrator`), this may be over-engineering.
* **Dual Configuration Paths**: During migration, both `FeedSlotContexts` and `Workflows` sections coexist, requiring careful documentation.

---

## Related Issues

* #245 — Design extensible OrchestratorContext registration
* #246 — Design PromptRole scoping strategy
