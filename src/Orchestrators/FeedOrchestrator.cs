using System.Text;
using System.Text.RegularExpressions;
using XPoster.Abstraction;
using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.Orchestrators;

/// <summary>
/// Orchestrates a social-media post by aggregating Bitcoin-related RSS news from the last 24 hours,
/// summarising the content via AI, and optionally attaching an AI-generated image.
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
    public FeedOrchestrator(
        ISender sender,
        ILogger<FeedOrchestrator> logger,
        IFeedService feedService,
        IFeedUrlProvider feedUrlProvider,
        ITagReplacementProvider tagReplacementProvider,
        ITextToTextProvider? textProvider,
        ITextToImageProvider? imageProvider)
        : base(sender, logger)
    {
        _feedService = feedService;
        _feedUrlProvider = feedUrlProvider;
        _tagReplacementProvider = tagReplacementProvider;
        _textProvider = textProvider;
        _imageProvider = imageProvider;
    }

    /// <summary>
    /// Executes the five-step content production pipeline:
    /// <list type="number">
    ///   <item>Acquire feed content from the configured URLs.</item>
    ///   <item>Generate a summary via the text provider.</item>
    ///   <item>Apply word-to-hashtag tag replacements via the tag replacement provider.</item>
    ///   <item>Generate an image prompt via the text provider.</item>
    ///   <item>Generate the image via the image provider.</item>
    /// </list>
    /// Posting is disabled and <c>null</c> is returned if any mandatory step fails.
    /// </summary>
    public override async Task<Post?> OrchestrateAsync()
    {
        if (_textProvider == null)
        {
            _logger.LogError("No ITextToTextProvider instance provided to FeedOrchestrator. Cannot orchestrate content.");
            SendIt = false;
            return null;
        }

        // Step 1 – Acquire feed content
        var feedContent = await AcquireFeedContentAsync();
        if (string.IsNullOrWhiteSpace(feedContent))
        {
            return null;
        }

        // Step 2 – Generate summary
        var summary = await GenerateSummaryAsync(feedContent);
        if (string.IsNullOrWhiteSpace(summary))
        {
            return null;
        }

        // Step 3 – Apply tag replacements
        summary = ApplyTagReplacements(summary);

        // Step 4 – Generate image prompt
        // Step 5 – Generate image
        var image = await GenerateImageAsync(summary);

        return new Post
        {
            Content = summary,
            Image = image
        };
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
            {
                allFeeds.AddRange(feeds);
            }
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

    private async Task<string> GenerateSummaryAsync(string feedContent)
    {
        if (_sender == null)
        {
            _logger.LogError("No sender configured for FeedOrchestrator.");
            SendIt = false;
            return string.Empty;
        }

        var summary = await _textProvider!.GetSummaryAsync(feedContent, _sender.MessageMaxLenght);
        if (string.IsNullOrWhiteSpace(summary))
        {
            _logger.LogError("Unable to get summary from text provider.");
            SendIt = false;
            return string.Empty;
        }

        _logger.LogInformation("Generated summary: {Summary}", summary);
        return summary;
    }

    private string ApplyTagReplacements(string text)
    {
        var replacements = _tagReplacementProvider.GetReplacements();
        if (replacements.Count == 0)
        {
            return text;
        }

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

    private async Task<byte[]?> GenerateImageAsync(string summary)
    {
        if (_imageProvider == null)
        {
            _logger.LogWarning("No ITextToImageProvider configured for this slot. Post will be published without image.");
            return null;
        }

        var prompt = await _textProvider!.GetImagePromptAsync(summary);
        if (string.IsNullOrWhiteSpace(prompt))
        {
            _logger.LogError("Unable to get image prompt from text provider. Falling back to summary as prompt.");
            prompt = summary;
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
