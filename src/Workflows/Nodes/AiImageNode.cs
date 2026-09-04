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
/// Failure behaviour depends on the <c>Required</c> node parameter:
/// when <c>true</c> a failed/empty image is a hard failure (blocking the workflow);
/// when <c>false</c> (default) it is a soft failure (workflow continues without an image).
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
        var required = NodeParameterExtractor.GetParameter<bool>(input.Parameters, "Required", false);

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
            const string error = "Image generation returned empty or failed content.";
            return required
                ? new WorkflowNodeResult(false, null, error)
                : new WorkflowNodeResult(true, null, error);
        }

        var media = new MediaAttachment(
            Data: imageBytes,
            Type: MediaType.Image,
            MimeType: "image/png",
            FileName: "generated_image.png");

        return new WorkflowNodeResult(true, media, null);
    }
}