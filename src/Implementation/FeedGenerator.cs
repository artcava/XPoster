using System.Text;
using System.Text.RegularExpressions;
using XPoster.Abstraction;
using XPoster.Models;

namespace XPoster.Implementation;

/// <summary>
/// Generates a social-media post by aggregating Bitcoin-related RSS news from the last 24 hours,
/// summarising the content via AI, and optionally attaching an AI-generated image.
/// </summary>
public class FeedGenerator : BaseGenerator
{
    private readonly IFeedService _feedService;
    private readonly IAiService _aiService;
    private bool _sendIt = true;

    /// <summary>Default RSS feed URLs polled for Bitcoin news.</summary>
    private List<string> _feedUrls = new List<string> { "https://cointelegraph.com/rss/tag/bitcoin", "https://www.coindesk.com/arc/outboundfeeds/rss" };

    /// <summary>Word-to-hashtag replacement map applied to the generated summary.</summary>
    private Dictionary<string, string> _replacements = new Dictionary<string, string> { { "bitcoin", "#Bitcoin" }, { "btc", "#BTC" }, { "blockchain", "#Blockchain" }, { "fed", "#FED" } };

    /// <inheritdoc/>
    public override string Name => typeof(FeedGenerator).Name;

    /// <inheritdoc/>
    public override bool SendIt { get { return _sendIt; } set { _sendIt = value; } }

    /// <summary>Always <c>true</c>; this generator always attempts to attach an AI-generated image.</summary>
    public override bool ProduceImage { get => true; set => throw new NotImplementedException(); }

    /// <summary>
    /// Initialises a new instance of <see cref="FeedGenerator"/>.
    /// </summary>
    /// <param name="sender">The sender used to publish the post to the target platform.</param>
    /// <param name="logger">The logger for diagnostic output.</param>
    /// <param name="feedService">The service used to fetch RSS feed items.</param>
    /// <param name="aiService">The service used to summarise text and generate images.</param>
    public FeedGenerator(ISender sender, ILogger<FeedGenerator> logger, IFeedService feedService, IAiService aiService)
        : base(sender, logger)
    {
        _feedService = feedService;
        _aiService = aiService;
    }

    /// <summary>
    /// Fetches recent RSS items, generates an AI summary, derives an image prompt,
    /// and returns a <see cref="Post"/> ready for publishing.
    /// Posting is disabled and <c>null</c> is returned if no relevant news is found or summarisation fails.
    /// </summary>
    /// <returns>A <see cref="Post"/> with text content and an optional image, or <c>null</c> on failure.</returns>
    public override async Task<Post>? GenerateAsync()
    {
        var summary = await GenerateMessage();
        if (string.IsNullOrWhiteSpace(summary))
        {
            _logger.LogInformation("No summary generated");
            SendIt = false;
            return null;
        }

        var prompt4Image = await _aiService.GetImagePromptAsync(summary);
        if (string.IsNullOrWhiteSpace(prompt4Image))
        {
            _logger.LogError("Unable to get image prompt from OpenAI");
            prompt4Image = summary;
        }

        byte[]? image = null;
        try
        {
            image = await _aiService.GenerateImageAsync(prompt4Image);

            if (image == null)
            {
                _logger.LogWarning("Image generation returned null for prompt: {Prompt}. Message will be posted without image.", prompt4Image);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception occurred while generating image with prompt: {Prompt}. Message will be posted without image.", prompt4Image);
        }

        return new Post
        {
            Content = summary,
            Image = image
        };
    }

    /// <summary>
    /// Aggregates RSS items from all configured feed URLs published in the last 24 hours,
    /// concatenates their content, and requests an AI-generated summary.
    /// </summary>
    /// <returns>The summarised text with hashtag replacements applied, or an empty string if no feeds or summary are available.</returns>
    private async Task<string> GenerateMessage()
    {
        var end = DateTimeOffset.UtcNow;
        var start = end.AddDays(-1);

        var allFeeds = new List<RSSFeed>();
        foreach (string url in _feedUrls)
        {
            var feeds = await _feedService.GetFeedsAsync(url, start, end, _replacements.Keys);
            if (feeds != null && feeds.Any())
            {
                allFeeds.AddRange(feeds);
            }
        }

        if (!allFeeds.Any())
        {
            _logger.LogInformation("No feeds found");
            SendIt = false;
            return string.Empty;
        }

        string feedContent = allFeeds.Select(f => f.Content).Aggregate(string.Empty, (current, next) => current + "\n" + next);

        var summary = await _aiService.GetSummaryAsync(feedContent, _sender.MessageMaxLenght);
        if (string.IsNullOrWhiteSpace(summary))
        {
            _logger.LogError("Unable to get summary from OpenAI");
            SendIt = false;
            return string.Empty;
        }

        _logger.LogInformation("Generated summary: {0}", summary);

        summary = ReplaceEveryFirstOccurenceOf(summary, _replacements);

        return summary;
    }

    /// <summary>
    /// Replaces the first case-insensitive occurrence of each key in <paramref name="replacements"/>
    /// with its corresponding value, preserving the original casing of surrounding text.
    /// </summary>
    /// <param name="text">The text in which replacements should be applied.</param>
    /// <param name="replacements">A map of plain words to their hashtag equivalents.</param>
    /// <returns>The modified text with all first occurrences replaced.</returns>
    private string ReplaceEveryFirstOccurenceOf(string text, Dictionary<string, string> replacements)
    {
        var sb = new StringBuilder(text);

        foreach (var entry in replacements)
        {
            string key = entry.Key;
            string value = entry.Value;
            string pattern = @"\b" + Regex.Escape(key) + @"\b";

            Match match = Regex.Match(sb.ToString(), pattern, RegexOptions.IgnoreCase);

            if (match.Success)
            {
                int index = match.Index;
                sb.Remove(index, key.Length);
                sb.Insert(index, value);
            }
        }

        return sb.ToString();
    }
}
