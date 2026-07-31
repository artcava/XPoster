# ADR 006: Integration of Legacy Services into Dynamic DAG Workflow Engine Architecture

## Status

**Proposed**

## Context

The current XPoster architecture relies on a rigid, monolithic orchestrator hierarchy (`FeedOrchestrator`, `PowerLawOrchestrator`, `NoOrchestrator`). Each slot or pipeline is bound to a specific class that hardcodes the execution sequence, AI service invocations, and target publishing channels.

Analysis of the current `Program.cs` and the codebase revealed the following critical limitations:

1. **Tight Coupling to Enums and Proprietary Contexts**: `FeedOrchestrator` depends directly on `FeedOrchestratorContext` and the `PromptRole` enum (`Summary`, `ImagePromptDerivation`, `ImageGeneration`). Adding any new step or pipeline variant requires extending enums and recompiling core code.
2. **Keyed Services and Dynamic Injection**: In `Program.cs`, AI providers are registered as Keyed Services (`AddXPosterAiProviders()`). Directly injecting `ITextToTextProvider` into a rigid node prevents selecting AI providers (`"OpenAi"`, `"DeepSeek"`, `"FalAi"`) dynamically per step via JSON configuration.
3. **Payload Type Rigidity**: The `Post` structure assumes media attachments are exclusively `byte[]` image arrays. It lacks abstractions for text-only posts, videos, or multi-media documents.
4. **Hardcoded Variable Keys**: Current execution steps assume fixed key names (e.g., `"sourceContent"`), preventing node reuse across pipelines with different input sources (e.g., RSS feeds, calculation engines, webhooks).
5. **Inability to Support Parallel Branching (DAGs)**: The sequential execution model cannot handle parallel branches (e.g., generating text and image prompts concurrently) or dynamic text re-summarization tailored to senders with varying `MessageMaxLength` constraints.

---

## Decision

We will adopt a **Workflow Engine based on a Directed Acyclic Graph (DAG)** while leaving the **business logic of legacy infrastructure services (`FeedService`, `OpenAiService`, `TagReplacementService`) completely intact**.

Workflow nodes (`IWorkflowNode`) will act as **Adapters**: they will bridge the thread-safe `WorkflowContext` to existing service interfaces, parsing execution parameters via a utility (`NodeParameterExtractor`) and resolving prompt configurations via `IStepOptionsResolver`.

### Architectural Principles

1. **Zero Breaking Changes to Infrastructure Services**: Services registered in `Program.cs` (`IFeedService`, `ITagReplacementProvider`, `ITagReplacementService`, etc.) remain untouched.
2. **Deprecation of `PromptRole` and `FeedOrchestratorContext`**: Prompt configurations are retrieved directly from `appsettings.json` under `PromptSteps:{StepId}` via `IStepOptionsResolver`.
3. **Media-Agnostic Abstraction (`MediaAttachment`)**: Native support for images, videos, and documents through a single record.
4. **Decoupling via Dynamic Keys**: Each node receives the context keys to read from and write to via configuration parameters (`InputKey`, `OutputKey`, `TextKey`, `MediaKey`, `FallbackSourceKey`).
5. **Thread-Safe Context Isolation (`WorkflowContext`)**: Uses `ConcurrentDictionary` to guarantee safety during parallel branch executions.
6. **Dynamic Node and AI Provider Resolution**: Workflow nodes and AI providers are resolved dynamically at runtime via .NET **Keyed Services**.

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

Handles heuristic conversion from JSON representations (such as `JsonElement`) to strongly-typed C# objects.

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

Replaces the `PromptRole` enum by binding configuration directly from the `PromptSteps:{StepId}` section in `IConfiguration`.

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
        
        // Compute in-degrees for topological sorting of the DAG
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
}

```

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
                    finalText = currentText[..sender.MessageMaxLength];
                }
            }
            else
            {
                finalText = currentText[..sender.MessageMaxLength];
            }

            currentText = finalText;
            var formattedContent = _tagReplacementService.Apply(finalText);

            postMap[sender.Platform] = new Post
            {
                Content = formattedContent,
                Media = media
            };
        }

        input.Context.SetData(WorkflowContextKeys.SendResults, postMap);
        return new WorkflowNodeResult(Success: true, Output: postMap, ErrorMessage: null);
    }
}

```

---

## Dependency Injection Refactoring (`Program.cs`)

Below is the exact update to `Program.cs`, removing legacy `FeedOrchestratorContext` registrations and adding workflow engine contracts and adapter nodes as Keyed Services:

```csharp
// --- REMOVAL OF LEGACY CONTEXT ---
// builder.Services.AddKeyedSingleton<FeedOrchestratorContext>("Bitcoin", (sp, _) =>
//     builder.Configuration.GetSection("FeedSlotContexts:Bitcoin").Get<FeedOrchestratorContext>()!);

// --- WORKFLOW ENGINE REGISTRATIONS ---
builder.Services.AddSingleton<IStepOptionsResolver, ConfigurationStepOptionsResolver>();
builder.Services.AddTransient<IWorkflowEngine, WorkflowExecutionEngine>();

// --- WORKFLOW NODE REGISTRATIONS (KEYED SERVICES) ---
builder.Services.AddKeyedTransient<IWorkflowNode, FetchRssNode>("FetchRss");
builder.Services.AddKeyedTransient<IWorkflowNode, AiTextNode>("AiText");
builder.Services.AddKeyedTransient<IWorkflowNode, AiImageNode>("AiImage");
builder.Services.AddKeyedTransient<IWorkflowNode, FanOutSendNode>("FanOutSend");

```

---

## Configuration Example (`appsettings.json`)

```json
{
  "PromptSteps": {
    "Feed.Summary": {
      "SystemPromptTemplate": "Summarize in under {MaxChars} characters.",
      "UserPromptTemplate": "{Text}",
      "Temperature": 0.3,
      "MaxTokenBudget": 500
    },
    "Feed.ImagePromptDerivation": {
      "SystemPromptTemplate": "Create an image generation prompt.",
      "UserPromptTemplate": "{Text}",
      "Temperature": 0.7,
      "MaxTokenBudget": 200
    },
    "Feed.ImageGeneration": {
      "ImageSize": "1024x1024",
      "ImageQuantity": 1
    }
  },
  "Workflows": {
    "Bitcoin": {
      "SlotKey": "Bitcoin",
      "Nodes": [
        {
          "Id": "fetch-rss",
          "Type": "FetchRss",
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

## Consequences

### Positive

* **Zero Rewriting of Infrastructure Services**: `FeedService`, `OpenAiService`, `TagReplacementService`, and all registered AI providers in `Program.cs` remain completely unchanged.
* **Architectural Flexibility**: Modifying or introducing new workflow steps occurs purely via configuration files without code recompilation or enum modifications.
* **Multi-Media Support**: `MediaAttachment` expands system capabilities to handle text, images, videos, and multi-page documents seamlessly.
* **Parallel Execution Safety**: Concurrent execution of independent DAG branches over a thread-safe `WorkflowContext` prevents race conditions.

### Negative

* **Configuration Overhead**: Mismatches between context keys (`InputKey`, `OutputKey`) will cause runtime exceptions. Rigorous DAG validation during startup is recommended to mitigate this.

## Related Issues

* #245 — Design extensible OrchestratorContext registration
* #246 — Design PromptRole scoping strategy