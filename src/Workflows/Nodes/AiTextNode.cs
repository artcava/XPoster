using Microsoft.Extensions.DependencyInjection;
using XPoster.Contracts;
using XPoster.Models;
using XPoster.Workflows.Abstractions;
using XPoster.Workflows.Services;
using XPoster.Workflows.Utilities;

namespace XPoster.Workflows.Nodes;

/// <summary>
/// Generates text using a dynamically-resolved AI provider.
/// Adapter for keyed <see cref="ITextToTextProvider"/>.
/// </summary>
public sealed class AiTextNode : IWorkflowNode
{
    /// <inheritdoc />
    public string NodeType => "AiText";

    private readonly IServiceProvider _serviceProvider;
    private readonly IStepOptionsResolver _stepOptionsResolver;

    /// <summary>Initializes a new instance of the <see cref="AiTextNode"/> class.</summary>
    public AiTextNode(IServiceProvider serviceProvider, IStepOptionsResolver stepOptionsResolver)
    {
        _serviceProvider = serviceProvider;
        _stepOptionsResolver = stepOptionsResolver;
    }

    /// <inheritdoc />
    public async Task<WorkflowNodeResult> ExecuteAsync(WorkflowNodeInput input, CancellationToken ct)
    {
        var provider = NodeParameterExtractor.GetProvider(input.Parameters);
        var stepId = NodeParameterExtractor.GetParameter<string>(input.Parameters, "StepId");
        var inputKey = NodeParameterExtractor.GetParameter<string>(input.Parameters, "InputKey");

        var inputText = input.Context.GetData<string>(inputKey);
        var stepOptions = _stepOptionsResolver.Resolve(stepId);

        var textProvider = _serviceProvider.GetKeyedService<ITextToTextProvider>(provider)
            ?? throw new InvalidOperationException($"ITextToTextProvider for '{provider}' is not registered.");

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