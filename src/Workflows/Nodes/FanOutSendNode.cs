using Microsoft.Extensions.DependencyInjection;
using XPoster.Contracts;
using XPoster.Models;
using XPoster.Workflows.Abstractions;
using XPoster.Workflows.Models;
using XPoster.Workflows.Services;
using XPoster.Workflows.Utilities;

namespace XPoster.Workflows.Nodes;

/// <summary>
/// Fans out the generated text across all senders, adapting the summary length per sender.
/// When a sender's <c>MessageMaxLength</c> is shorter than the text and a fallback source
/// is available, the node re-summarises the original source content for that sender.
/// Bridges <see cref="MediaAttachment.Data"/> to the legacy <c>Post.Image</c> byte array.
/// </summary>
public sealed class FanOutSendNode : ITerminalNode
{
    /// <inheritdoc />
    public string NodeType => "FanOutSend";

    private readonly IServiceProvider _serviceProvider;
    private readonly IStepOptionsResolver _stepOptionsResolver;
    private readonly ITagReplacementService _tagReplacementService;

    /// <summary>Initializes a new instance of the <see cref="FanOutSendNode"/> class.</summary>
    public FanOutSendNode(
        IServiceProvider serviceProvider,
        IStepOptionsResolver stepOptionsResolver,
        ITagReplacementService tagReplacementService)
    {
        _serviceProvider = serviceProvider;
        _stepOptionsResolver = stepOptionsResolver;
        _tagReplacementService = tagReplacementService;
    }

    /// <inheritdoc />
    public async Task<WorkflowNodeResult> ExecuteAsync(WorkflowNodeInput input, CancellationToken ct)
    {
        var textKey = NodeParameterExtractor.GetParameter<string>(input.Parameters, "TextKey");
        var fallbackSourceKey = NodeParameterExtractor.GetParameter<string?>(input.Parameters, "FallbackSourceKey", null);
        var mediaKey = NodeParameterExtractor.GetParameter<string?>(input.Parameters, "MediaKey", null);
        var stepId = NodeParameterExtractor.GetParameter<string?>(input.Parameters, "StepId", null);

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
                var provider = NodeParameterExtractor.GetProvider(input.Parameters);
                var textProvider = _serviceProvider.GetKeyedService<ITextToTextProvider>(provider);

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
                Image = media?.Data
            };
        }

        input.Context.SetData(WorkflowContextKeys.SendResults, postMap);
        return new WorkflowNodeResult(Success: true, Output: postMap, ErrorMessage: null);
    }
}