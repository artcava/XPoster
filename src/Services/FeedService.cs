using Microsoft.Extensions.Caching.Memory;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.Services;

/// <summary>
/// Fetches, parses, and caches RSS feed items from remote sources,
/// filtering by publication date range and keyword match on the item title.
/// Results are cached for 24 hours to avoid redundant network calls.
/// Uses the named <c>"Feed"</c> <see cref="System.Net.Http.HttpClient"/> registered in
/// <c>HttpClientExtensions</c> with a Polly standard resilience pipeline.
/// </summary>
public class FeedService : IFeedService
{
    private readonly IMemoryCache _cache;
    private readonly ILogger<FeedService> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    /// <summary>
    /// Initialises a new instance of <see cref="FeedService"/>.
    /// </summary>
    /// <param name="cache">The in-memory cache used to store fetched feed results.</param>
    /// <param name="logger">The logger for diagnostic output.</param>
    /// <param name="httpClientFactory">The factory used to create the named <c>"Feed"</c> HTTP client.</param>
    public FeedService(IMemoryCache cache, ILogger<FeedService> logger, IHttpClientFactory httpClientFactory)
    {
        _cache = cache;
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    /// <summary>
    /// Retrieves RSS items from <paramref name="url"/> published between <paramref name="start"/> and <paramref name="end"/>
    /// whose title contains at least one of the supplied <paramref name="keywords"/>.
    /// Results are served from an in-memory cache when available.
    /// </summary>
    /// <param name="url">The URL of the RSS feed to fetch.</param>
    /// <param name="start">The inclusive lower bound of the publication date range.</param>
    /// <param name="end">The inclusive upper bound of the publication date range.</param>
    /// <param name="keywords">Keywords to match against item titles (case-insensitive).</param>
    /// <param name="ct">A cancellation token to cancel the operation.</param>
    /// <returns>
    /// A collection of matching <see cref="RSSFeed"/> entries, or an empty enumerable
    /// if the feed cannot be fetched or no items match the criteria.
    /// </returns>
    public async Task<IEnumerable<RSSFeed>> GetFeedsAsync(string url, DateTimeOffset start, DateTimeOffset end, IEnumerable<string> keywords, CancellationToken ct = default)
    {
        var cacheKey = $"feeds_{url}_{start:yyyyMMdd}_{end:yyyyMMdd}";

        if (_cache.TryGetValue(cacheKey, out IEnumerable<RSSFeed>? cachedFeeds) && cachedFeeds != null)
        {
            _logger.LogInformation("[FeedService] Feed served from cache for {Url}", url);
            return cachedFeeds;
        }

        var feeds = new List<RSSFeed>();

        var httpClient = _httpClientFactory.CreateClient("Feed");

        const string DateFormat = "ddd, dd MMM yyyy HH:mm:ss zzz";
        CultureInfo Culture = CultureInfo.InvariantCulture;

        try
        {
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; XPoster/1.0)");
            using var response = await httpClient.GetAsync(url, ct);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync(ct);
            content = content.Trim();

            XDocument xmlDoc = XDocument.Parse(content);
            var channel = xmlDoc.Root?.Element("channel");

            if (channel == null)
            {
                _logger.LogWarning("[FeedService] RSS feed channel element not found for URL {Url}. Possible invalid feed format.", url);
                throw new Exception("Invalid RSS feed format");
            }

            feeds.AddRange(channel.Elements("item")
                .Select(item =>
                {
                    bool success = DateTimeOffset.TryParseExact(
                        item.Element("pubDate")?.Value,
                        DateFormat,
                        Culture,
                        DateTimeStyles.AssumeUniversal,
                        out DateTimeOffset parsedDate);

                    return new
                    {
                        ItemElement = item,
                        PublishDate = success ? (DateTimeOffset?)parsedDate : null,
                        Title = item.Element("title")?.Value
                    };
                })
                .Where(x =>
                {
                    if (!x.PublishDate.HasValue || x.PublishDate.Value < start || x.PublishDate.Value > end)
                        return false;

                    string title = x.Title ?? string.Empty;
                    return keywords.Any(keyword => title.Contains(keyword, StringComparison.OrdinalIgnoreCase));
                })
                .Select(item => new RSSFeed
                {
                    // CS8601: Title and Link from XML are string? — fallback to empty string to satisfy required string
                    Title = item.Title ?? string.Empty,
                    Content = WebUtility.HtmlDecode(
                        Regex.Replace(item.ItemElement.Element("description")?.Value ?? string.Empty, "<[^>]+>", " ").Trim()),
                    Link = item.ItemElement.Element("link")?.Value ?? string.Empty,
                    // CS8629: .Value is safe here — guarded by HasValue in .Where above
                    PublishDate = item.PublishDate!.Value
                }));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "[FeedService] Failed to fetch or parse RSS feed from {Url}", url);
            return Enumerable.Empty<RSSFeed>();
        }

        _cache.Set(cacheKey, feeds, TimeSpan.FromHours(24));
        return feeds;
    }
}
