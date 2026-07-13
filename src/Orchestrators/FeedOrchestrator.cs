using System.Text;
using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.Orchestrators;

/// <summary>
/// Orchestrates a social-media post by aggregating Bitcoin-related RSS news from the last 24 hours,
/// summarising the content via AI, and optionally attaching an AI-generated image.
/// </summary>
/// <remarks>
/// Implements a fan-out pattern: the base summary and image are generated once from the primary sender
/// (widest <c>MessageMaxLength</c>), then each secondary sender receives an AI re-summarisation
/// from the original feed content only when the previous summary exceeds its limit.
/// The previous summary is used as the fitness check: if it fits, it is reused; if it does not,
/// the AI re-summarises from the full feed content to preserve maximum context.
/// Hashtag substitution is applied independently per sender.
/// Returns an <see cref="IReadOnlyDictionary{SenderPlatform, Post}"/> keyed by <see cref="ISender.Platform"/>
/// for unambiguous nominal routing.
/// </remarks>
public class FeedOrchestrator : BaseOrchestrator
{
    private readonly IFeedService _feedService;
    private readonly IFeedUrlProvider _feedUrlProvider;
    private readonly ITagReplacementProvider _tagReplacementProvider;
    private readonly ITagReplacementService _tagReplacementService;
    private readonly ITextToTextProvider? _textProvider;
    private readonly ITextToImageProvider? _imageProvider;
    private bool _sendIt = true;

    /// <inheritdoc/>
    public override string Name => typeof(FeedOrchestrator).Name;

    /// <inheritdoc/>
    public override bool SendIt { get { return _sendIt; } set { _sendIt = value; } }

    /// <summary>Always <c>true</c>; this orchestrator produces an AI-generated image when possible.</summary>
    public override bool ProduceImage { get => true; set => throw new NotImplementedException(); }

    /// <inheritdoc/>
    public override IReadOnlyList<SenderPlatform> SupportedPlatforms { get; } =
        new List<SenderPlatform> { SenderPlatform.X, SenderPlatform.LinkedIn, SenderPlatform.Instagram, SenderPlatform.DryRun }.AsReadOnly();

    /// <summary>
    /// Initialises a new instance of <see cref="FeedOrchestrator"/>.
    /// </summary>
    /// <param name="senders">
    /// Ordered list of senders for this slot. Internally sorted by descending <c>MessageMaxLength</c>;
    /// the sender with the widest limit drives base summary generation.
    /// </param>
    /// <param name="logger">The logger for diagnostic output.</param>
    /// <param name="feedService">The service used to fetch RSS feeds.</param>
    /// <param name="feedUrlProvider">Provides the RSS/Atom feed URLs to poll.</param>
    /// <param name="tagReplacementProvider">Provides the word-to-hashtag replacement map.</param>
    /// <param name="tagReplacementService">The service used to apply tag replacements to text.</param>
    /// <param name="textProvider">The AI text provider used to generate summaries and image prompts.</param>
    /// <param name="imageProvider">The AI image provider used to generate post images. Optional.</param>
    public FeedOrchestrator(
        IReadOnlyList<ISender> senders,
        ILogger<FeedOrchestrator> logger,
        IFeedService feedService,
        IFeedUrlProvider feedUrlProvider,
        ITagReplacementProvider tagReplacementProvider,
        ITagReplacementService tagReplacementService,
        ITextToTextProvider? textProvider,
        ITextToImageProvider? imageProvider = null)
        : base(senders, logger)
    {
        _feedService = feedService;
        _feedUrlProvider = feedUrlProvider;
        _tagReplacementProvider = tagReplacementProvider;
        _tagReplacementService = tagReplacementService;
        _textProvider = textProvider;
        _imageProvider = imageProvider;
    }

    /// <summary>
    /// Acquires feed content, generates a base summary at the primary sender's limit,
    /// optionally re-summarises for secondary senders from the original feed content,
    /// applies hashtag substitution per sender, generates a shared image, and returns an
    /// <see cref="IReadOnlyDictionary{SenderPlatform, Post}"/> keyed by <see cref="ISender.Platform"/>.
    /// </summary>
    /// <param name="ct">Cancellation token propagated from the Azure Functions runtime.</param>
    /// <returns>
    /// A dictionary with one entry per configured sender, or an empty dictionary when a
    /// mandatory pipeline step fails (no feeds, empty summary, no text provider).
    /// </returns>
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

        // Step 1 — acquire feed content
        ct.ThrowIfCancellationRequested();
        var feedContent = await AcquireFeedContentAsync(ct);
        if (string.IsNullOrWhiteSpace(feedContent))
            return new Dictionary<SenderPlatform, Post?>().AsReadOnly();

        // Step 2 — select primary sender (widest limit) and generate base summary
        ct.ThrowIfCancellationRequested();
        var orderedSenders = _senders.OrderByDescending(s => s.MessageMaxLength).ToList();
        var primarySender = orderedSenders[0];
                _logger.LogInformation("[FeedOrchestrator] Generating base summary via text provider for primary sender {Platform} (limit {Limit}).",
                    primarySender.Platform, primarySender.MessageMaxLength);
        var rawBaseSummary = await _textProvider.GetSummaryAsync(feedContent, primarySender.MessageMaxLength, ct);
        if (string.IsNullOrWhiteSpace(rawBaseSummary))
        {
            _logger.LogError("[FeedOrchestrator] Base summary generation failed for primary sender {Platform}.", primarySender.Platform);
            _sendIt = false;
            return new Dictionary<SenderPlatform, Post?>().AsReadOnly();
        }

        // Step 3 — generate image (shared across all senders)
        ct.ThrowIfCancellationRequested();
        var imageBytes = await GenerateImageAsync(rawBaseSummary, ct);

        // Step 4 — build per-sender posts
        // previousSummary tracks the last successfully generated summary.
        // Each sender reuses it when it fits; otherwise the AI re-summarises
        // from the full feedContent to preserve maximum context.
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
                _logger.LogInformation("[FeedOrchestrator] Re-summarising via text provider for sender {Platform} (limit {Limit}).",
                    sender.Platform, sender.MessageMaxLength);
                var reSummarised = await _textProvider.GetSummaryAsync(
                    feedContent, sender.MessageMaxLength, ct);

                if (string.IsNullOrWhiteSpace(reSummarised))
                {
                    _logger.LogWarning("[FeedOrchestrator] Re-summarisation failed for sender {Platform} (limit {Limit}). Null entry added.",
                        sender.Platform, sender.MessageMaxLength);
                    result[sender.Platform] = null;
                    continue;
                }

                summaryForSender = reSummarised;
            }

            previousSummary = summaryForSender;
            var content = _tagReplacementService.Apply(summaryForSender);
            result[sender.Platform] = new Post { Content = content, Image = imageBytes };
        }

        return result.AsReadOnly();
    }

    // ---------------------------------------------------------------------------
    // Private pipeline steps
    // ---------------------------------------------------------------------------

    private async Task<string> AcquireFeedContentAsync(CancellationToken ct = default)
    {
        var feedUrls = _feedUrlProvider.GetFeedUrls();
        if (feedUrls.Count == 0)
        {
            _logger.LogWarning("[FeedOrchestrator] IFeedUrlProvider returned an empty URL list. No feeds will be fetched.");
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
            var feeds = await _feedService.GetFeedsAsync(url, start, end, replacementKeys, ct);
            if (feeds != null && feeds.Any())
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
            var prompt = await _textProvider!.GetImagePromptAsync(rawBaseSummary, ct);
            if (string.IsNullOrWhiteSpace(prompt))
                prompt = rawBaseSummary;

            _logger.LogInformation("[FeedOrchestrator] Generating image from prompt.");
            var image = await _imageProvider.GenerateImageAsync(prompt, ct);
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
}
