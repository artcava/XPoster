using System.Text;
using System.Text.RegularExpressions;
using XPoster.Abstraction;
using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.Orchestrators;

/// <summary>
/// Orchestrates a social-media post by aggregating Bitcoin-related RSS news from the last 24 hours,
/// summarising the content via AI, and optionally attaching an AI-generated image.
/// Implements a fan-out pattern: the base summary and image are generated once from the primary sender
/// (index 0, widest <c>MessageMaxLength</c>), then each secondary sender receives an AI re-summarisation
/// only when the base summary exceeds its limit. Hashtag substitution is applied independently per sender.
/// </summary>
public class FeedOrchestrator : BaseOrchestrator
{
    private readonly IFeedService _feedService;
    private readonly IFeedUrlProvider _feedUrlProvider;
    private readonly ITagReplacementProvider _tagReplacementProvider;
    private readonly ITextToTextProvider? _textProvider;
    private readonly ITextToImageProvider? _imageProvider;
    private bool _sendIt = true;

    /// <inheritdoc/>
    public override string Name => typeof(FeedOrchestrator).Name;

    /// <inheritdoc/>
    public override bool SendIt { get { return _sendIt; } set { _sendIt = value; } }

    /// <summary>Always <c>true</c>; this orchestrator always attempts to attach an AI-generated image.</summary>
    public override bool ProduceImage { get => true; set => throw new NotImplementedException(); }

    /// <inheritdoc/>
    /// <remarks>FeedOrchestrator supports X, LinkedIn, and Instagram. DryRun is also supported for testing.</remarks>
    public override IReadOnlyList<SenderPlatform> SupportedPlatforms { get; } =
        new List<SenderPlatform> { SenderPlatform.X, SenderPlatform.LinkedIn, SenderPlatform.Instagram, SenderPlatform.DryRun }.AsReadOnly();

    /// <summary>
    /// Initialises a new instance of <see cref="FeedOrchestrator"/>.
    /// </summary>
    /// <param name="senders">
    /// Ordered list of senders for this slot, by descending <c>MessageMaxLength</c>.
    /// Index 0 is the primary sender and drives base summary generation.
    /// </param>
    /// <param name="logger">Logger instance for diagnostic output.</param>
    /// <param name="feedService">Service used to fetch and parse RSS feeds.</param>
    /// <param name="feedUrlProvider">Provider that supplies the RSS feed URLs to aggregate.</param>
    /// <param name="tagReplacementProvider">Provider that supplies word-to-hashtag replacement rules.</param>
    /// <param name="textProvider">Optional AI provider for text generation. Null means no text capability for this slot.</param>
    /// <param name="imageProvider">Optional AI provider for image generation. Null means no image capability for this slot.</param>
    public FeedOrchestrator(
        IReadOnlyList<ISender> senders,
        ILogger<FeedOrchestrator> logger,
        IFeedService feedService,
        IFeedUrlProvider feedUrlProvider,
        ITagReplacementProvider tagReplacementProvider,
        ITextToTextProvider? textProvider,
        ITextToImageProvider? imageProvider)
        : base(senders, logger)
    {
        _feedService = feedService;
        _feedUrlProvider = feedUrlProvider;
        _tagReplacementProvider = tagReplacementProvider;
        _textProvider = textProvider;
        _imageProvider = imageProvider;
    }

    /// <summary>
    /// Executes the fan-out content production pipeline:
    /// <list type="number">
    ///   <item>Acquire feed content from the configured URLs.</item>
    ///   <item>Generate a base summary at the primary sender's <c>MessageMaxLength</c> (widest limit).</item>
    ///   <item>Derive an image prompt from <c>rawBaseSummary</c> before hashtag substitution (clean prose).</item>
    ///   <item>Generate the image once, shared across all senders.</item>
    ///   <item>For each sender: re-summarise via AI only when <c>rawBaseSummary</c> exceeds the sender's limit; otherwise reuse as-is.</item>
    ///   <item>Apply hashtag substitution independently on each sender's raw summary.</item>
    /// </list>
    /// Returns an empty list if any mandatory step fails.
    /// </summary>
    public override async Task<IReadOnlyList<Post?>> OrchestrateAsync()
    {
        if (_textProvider == null)
        {
            _logger.LogError("No ITextToTextProvider instance provided to FeedOrchestrator. Cannot orchestrate content.");
            SendIt = false;
            return Array.Empty<Post?>();
        }

        // Step 1 – Acquire feed content
        var feedContent = await AcquireFeedContentAsync();
        if (string.IsNullOrWhiteSpace(feedContent))
            return Array.Empty<Post?>();

        // Step 2 – Generate base summary at primary sender's limit (widest, index 0)
        var rawBaseSummary = await GenerateRawSummaryAsync(feedContent, _sender?.MessageMaxLenght ?? int.MaxValue);
        if (string.IsNullOrWhiteSpace(rawBaseSummary))
            return Array.Empty<Post?>();

        // Step 3 & 4 – Generate image from raw base summary (before hashtag substitution — clean prose)
        var image = await GenerateImageAsync(rawBaseSummary);

        // Step 5 & 6 – Build one Post per sender
        var posts = new List<Post?>();
        for (int i = 0; i < _senders.Count; i++)
        {
            var sender = _senders[i];

            // AI re-summarisation guard: skip AI call when base summary already fits the sender's limit.
            // Guaranteed correct when senders are ordered by descending MaxLength (convention).
            string rawSummary;
            if (i == 0 || rawBaseSummary.Length <= sender.MessageMaxLenght)
            {
                rawSummary = rawBaseSummary;
            }
            else
            {
                rawSummary = await _textProvider.GetSummaryAsync(rawBaseSummary, sender.MessageMaxLenght);
                if (string.IsNullOrWhiteSpace(rawSummary))
                {
                    _logger.LogError("Re-summarisation failed for sender {Sender}", sender.GetType().Name);
                    posts.Add(null);
                    continue;
                }
            }

            // Apply hashtag substitution independently on each sender's raw summary
            var content = ApplyTagReplacements(rawSummary);
            posts.Add(new Post { Content = content, Image = image });
        }

        return posts.AsReadOnly();
    }

    private async Task<string> AcquireFeedContentAsync()
    {
        var feedUrls = _feedUrlProvider.GetFeedUrls();

        if (feedUrls.Count == 0)
        {
            _logger.LogWarning("IFeedUrlProvider returned an empty URL list. No feeds will be fetched.");
            SendIt = false;
            return string.Empty;
        }

        var end = DateTimeOffset.UtcNow;
        var start = end.AddDays(-1);
        var keywords = _tagReplacementProvider.GetReplacements().Keys;

        var allFeeds = new List<RSSFeed>();
        foreach (string url in feedUrls)
        {
            var feeds = await _feedService.GetFeedsAsync(url, start, end, keywords);
            if (feeds != null && feeds.Any())
                allFeeds.AddRange(feeds);
        }

        if (!allFeeds.Any())
        {
            _logger.LogInformation("No feeds found in the last 24 hours.");
            SendIt = false;
            return string.Empty;
        }

        return allFeeds
            .Select(f => f.Content)
            .Aggregate(string.Empty, (current, next) => current + "\n" + next);
    }

    /// <summary>
    /// Generates a raw AI summary of <paramref name="feedContent"/> within <paramref name="maxLength"/> characters,
    /// without applying hashtag substitution (returns clean prose for downstream use as image prompt source).
    /// </summary>
    /// <param name="feedContent">The aggregated RSS feed text to summarise.</param>
    /// <param name="maxLength">Maximum character length for the generated summary.</param>
    private async Task<string> GenerateRawSummaryAsync(string feedContent, int maxLength)
    {
        if (_sender == null)
        {
            _logger.LogError("No sender configured for FeedOrchestrator.");
            SendIt = false;
            return string.Empty;
        }

        var summary = await _textProvider!.GetSummaryAsync(feedContent, maxLength);
        if (string.IsNullOrWhiteSpace(summary))
        {
            _logger.LogError("Unable to get summary from text provider.");
            SendIt = false;
            return string.Empty;
        }

        _logger.LogInformation("Generated base summary: {Summary}", summary);
        return summary;
    }

    private string ApplyTagReplacements(string text)
    {
        var replacements = _tagReplacementProvider.GetReplacements();
        if (replacements.Count == 0)
            return text;

        var sb = new StringBuilder(text);
        foreach (var entry in replacements)
        {
            string pattern = @"\b" + Regex.Escape(entry.Key) + @"\b";
            Match match = Regex.Match(sb.ToString(), pattern, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                sb.Remove(match.Index, entry.Key.Length);
                sb.Insert(match.Index, entry.Value);
            }
        }
        return sb.ToString();
    }

    private async Task<byte[]?> GenerateImageAsync(string rawBaseSummary)
    {
        if (_imageProvider == null)
        {
            _logger.LogWarning("No ITextToImageProvider configured for this slot. Post will be published without image.");
            return null;
        }

        var prompt = await _textProvider!.GetImagePromptAsync(rawBaseSummary);
        if (string.IsNullOrWhiteSpace(prompt))
        {
            _logger.LogError("Unable to get image prompt from text provider. Falling back to summary as prompt.");
            prompt = rawBaseSummary;
        }

        try
        {
            var image = await _imageProvider.GenerateImageAsync(prompt);
            if (image == null || image.Length == 0)
            {
                _logger.LogWarning("Image generation returned empty result for prompt: {Prompt}. Post will be published without image.", prompt);
                return null;
            }
            return image;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception occurred while generating image with prompt: {Prompt}. Post will be published without image.", prompt);
            return null;
        }
    }
}
