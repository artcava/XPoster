using System.Text;
using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.Orchestrators;

/// <summary>
/// Orchestrates a social-media post by aggregating RSS news from the last 24 hours,
/// summarising the content via AI, and optionally attaching an AI-generated image.
/// Implements a fan-out pattern: the base summary and image are generated once from
/// the primary sender (widest MessageMaxLength), then each secondary sender receives
/// an AI re-summarisation from the original feed content only when the previous summary
/// exceeds its limit.
/// </summary>
public class FeedOrchestrator : BaseOrchestrator
{
    private readonly IFeedService _feedService;
    private readonly ITagReplacementProvider _tagReplacementProvider;
    private readonly ITagReplacementService _tagReplacementService;
    private readonly ITextToTextProvider? _textProvider;
    private readonly ITextToImageProvider? _imageProvider;
    private readonly FeedOrchestratorContext _context;
    private bool _sendIt = true;

    /// <inheritdoc/>
    public override string Name => typeof(FeedOrchestrator).Name;

    /// <inheritdoc/>
    public override bool SendIt
    {
        get => _sendIt;
        set => _sendIt = value;
    }

    /// <inheritdoc/>
    public override bool ProduceImage
    {
        get => true;
        set => throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public override IReadOnlyList<SenderPlatform> SupportedPlatforms { get; } =
        new List<SenderPlatform>
        {
            SenderPlatform.X,
            SenderPlatform.LinkedIn,
            SenderPlatform.Instagram,
            SenderPlatform.DryRun
        }.AsReadOnly();

    /// <summary>
    /// Initialises a new instance of <see cref="FeedOrchestrator"/>.
    /// </summary>
    public FeedOrchestrator(
        IReadOnlyList<ISender> senders,
        ILogger<FeedOrchestrator> logger,
        IFeedService feedService,
        FeedOrchestratorContext context,
        ITagReplacementProvider tagReplacementProvider,
        ITagReplacementService tagReplacementService,
        ITextToTextProvider? textProvider,
        ITextToImageProvider? imageProvider = null)
        : base(senders, logger)
    {
        _feedService = feedService;
        _tagReplacementProvider = tagReplacementProvider;
        _tagReplacementService = tagReplacementService;
        _textProvider = textProvider;
        _context = context;
        _imageProvider = imageProvider;
    }
    /// <summary>
    /// Orchestrates a social-media post by aggregating RSS news from the last 24 hours,
    /// summarising the content via AI, and optionally attaching an AI-generated image.
    /// </summary>
    /// <param name="ct"></param>
    /// <returns></returns>
    public override async Task<IReadOnlyDictionary<SenderPlatform, Post?>> OrchestrateAsync(CancellationToken ct = default)
    {
        if (_textProvider is null)
        {
            _logger.LogError("[FeedOrchestrator] ITextToTextProvider is not configured.");
            _sendIt = false;
            return new Dictionary<SenderPlatform, Post?>().AsReadOnly();
        }

        if (_senders.Count == 0)
        {
            _logger.LogError("[FeedOrchestrator] No senders configured for this slot.");
            _sendIt = false;
            return new Dictionary<SenderPlatform, Post?>().AsReadOnly();
        }

        ct.ThrowIfCancellationRequested();
        var feedContent = await AcquireFeedContentAsync(ct);
        if (string.IsNullOrWhiteSpace(feedContent))
            return new Dictionary<SenderPlatform, Post?>().AsReadOnly();

        ct.ThrowIfCancellationRequested();
        var orderedSenders = _senders.OrderByDescending(s => s.MessageMaxLength).ToList();
        var primarySender = orderedSenders[0];

        _logger.LogInformation(
            "[FeedOrchestrator] Generating base summary via text provider for primary sender {Platform} (limit {Limit}).",
            primarySender.Platform,
            primarySender.MessageMaxLength);

        var summaryStep = _context.PromptOptions.GetStep(PromptRole.Summary);
        var summaryRequest = BuildPromptRequest(
            feedContent,
            summaryStep,
            primarySender.MessageMaxLength);

        var rawBaseSummary = await _textProvider.GenerateTextAsync(summaryRequest, ct);
        if (string.IsNullOrWhiteSpace(rawBaseSummary))
        {
            _logger.LogError(
                "[FeedOrchestrator] Base summary generation failed for primary sender {Platform}.",
                primarySender.Platform);
            _sendIt = false;
            return new Dictionary<SenderPlatform, Post?>().AsReadOnly();
        }

        ct.ThrowIfCancellationRequested();
        var imageBytes = await GenerateImageAsync(rawBaseSummary, ct);

        var result = new Dictionary<SenderPlatform, Post?>();
        var previousSummary = rawBaseSummary;

        foreach (var sender in orderedSenders)
        {
            ct.ThrowIfCancellationRequested();

            string summaryForSender;
            if (previousSummary.Length <= sender.MessageMaxLength)
            {
                summaryForSender = previousSummary;
            }
            else
            {
                _logger.LogInformation(
                    "[FeedOrchestrator] Re-summarising via text provider for sender {Platform} (limit {Limit}).",
                    sender.Platform,
                    sender.MessageMaxLength);

                var reSummaryRequest = BuildPromptRequest(
                    feedContent,
                    summaryStep,
                    sender.MessageMaxLength);

                var reSummarised = await _textProvider.GenerateTextAsync(reSummaryRequest, ct);

                if (string.IsNullOrWhiteSpace(reSummarised))
                {
                    _logger.LogWarning(
                        "[FeedOrchestrator] Re-summarisation failed for sender {Platform} (limit {Limit}). Null entry added.",
                        sender.Platform,
                        sender.MessageMaxLength);

                    result[sender.Platform] = null;
                    continue;
                }

                summaryForSender = reSummarised;
            }

            previousSummary = summaryForSender;
            var content = _tagReplacementService.Apply(summaryForSender);
            result[sender.Platform] = new Post
            {
                Content = content,
                Image = imageBytes
            };
        }

        return result.AsReadOnly();
    }

    private async Task<string> AcquireFeedContentAsync(CancellationToken ct = default)
    {
        var feedUrls = _context.FeedUrls;
        if (feedUrls.Count == 0)
        {
            _logger.LogWarning("[FeedOrchestrator] FeedOrchestratorContext has no feed URLs configured.");
            _sendIt = false;
            return string.Empty;
        }

        var end = DateTimeOffset.UtcNow;
        var start = end.AddDays(-1);

        var replacementKeys = _tagReplacementProvider.GetReplacements().Keys;
        var allFeeds = new List<RSSFeed>();

        foreach (var url in feedUrls)
        {
            ct.ThrowIfCancellationRequested();

            var feeds = await _feedService.GetFeedsAsync(
                url,
                start,
                end,
                replacementKeys,
                ct);

            if (feeds is not null && feeds.Any())
                allFeeds.AddRange(feeds);
        }

        if (allFeeds.Count == 0)
        {
            _logger.LogWarning("[FeedOrchestrator] No feeds found in the last 24 hours.");
            _sendIt = false;
            return string.Empty;
        }

        var sb = new StringBuilder();
        foreach (var feed in allFeeds)
            sb.AppendLine($"{feed.Title}: {feed.Content}");

        return sb.ToString();
    }

    private async Task<byte[]?> GenerateImageAsync(string rawBaseSummary, CancellationToken ct = default)
    {
        if (_imageProvider is null)
            return null;

        try
        {
            _logger.LogInformation("[FeedOrchestrator] Deriving image prompt via text provider from base summary.");
            var imagePromptStep = _context.PromptOptions.GetStep(PromptRole.ImagePromptDerivation);
            var imagePromptReq = BuildPromptRequest(
                rawBaseSummary,
                imagePromptStep,
                imagePromptStep.MaxOutputLength ?? 500);

            var derivedPrompt = await _textProvider!.GenerateTextAsync(imagePromptReq, ct);
            if (string.IsNullOrWhiteSpace(derivedPrompt))
                derivedPrompt = rawBaseSummary;

            _logger.LogInformation("[FeedOrchestrator] Generating image from prompt.");
            var imageGenStep = _context.PromptOptions.GetStep(PromptRole.ImageGeneration);

            var imageRequest = new ImagePromptRequest
            {
                InputText = derivedPrompt,
                SystemPromptTemplate = imageGenStep.SystemPromptTemplate,
                UserPromptTemplate = imageGenStep.UserPromptTemplate,
                Temperature = imageGenStep.Temperature,
                ImageQuantity = imageGenStep.ImageQuantity,
                ImageSize = imageGenStep.ImageSize,
                InputTextLabel = imageGenStep.InputTextLabel
            };

            var image = await _imageProvider.GenerateImageAsync(imageRequest, ct);
            return image is { Length: > 0 } ? image : null;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "[FeedOrchestrator] Image generation failed. Post will be published without image.");
            return null;
        }
    }

    private static PromptRequest BuildPromptRequest(
        string inputText,
        PromptStepOptions step,
        int maxOutputLength)
    {
        return new PromptRequest
        {
            InputText = inputText,
            SystemPromptTemplate = step.SystemPromptTemplate,
            UserPromptTemplate = step.UserPromptTemplate,
            Temperature = step.Temperature,
            MaxOutputLength = maxOutputLength,
            MaxTokenBudget = step.MaxTokenBudget,
            InputTextLabel = step.InputTextLabel
        };
    }
}