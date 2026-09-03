using Microsoft.Extensions.DependencyInjection;
using XPoster.Contracts;
using XPoster.Models;
using XPoster.Workflows.Abstractions;
using XPoster.Workflows.Models;
using XPoster.Workflows.Services;
using XPoster.Workflows.Utilities;

namespace XPoster.Workflows.Nodes;

/// <summary>
/// Generates an image using a dynamically-resolved AI provider.
/// Adapter for keyed <see cref="ITextToImageProvider"/>.
/// On failure returns <c>Output=null</c> (soft failure) so the workflow can continue without an image.
/// </summary>
public sealed class AiImageNode : IWorkflowNode
{
    /// <inheritdoc />
    public string NodeType => "AiImage";

    private readonly IServiceProvider _serviceProvider;
    private readonly IStepOptionsResolver _stepOptionsResolver;

    /// <summary>Initializes a new instance of the <see cref="AiImageNode"/> class.</summary>
    public AiImageNode(IServiceProvider serviceProvider, IStepOptionsResolver stepOptionsResolver)
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

        var promptText = input.Context.GetData<string>(inputKey);
        var stepOptions = _stepOptionsResolver.Resolve(stepId);

        var imageProvider = _serviceProvider.GetKeyedService<ITextToImageProvider>(provider)
            ?? throw new InvalidOperationException($"ITextToImageProvider for '{provider}' is not registered.");

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