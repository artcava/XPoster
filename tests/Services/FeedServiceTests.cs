using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Moq;
using System.Globalization;
using System.Net;
using System.Text;
using XPoster.Models;
using XPoster.Services;

namespace XPoster.Tests.Services;

public class FeedServiceTests
{
    private static readonly DateTimeOffset Now = new DateTimeOffset(2026, 6, 22, 10, 0, 0, TimeSpan.Zero);
    private static readonly DateTimeOffset Start = Now.AddDays(-2);
    private static readonly DateTimeOffset End = Now;

    private const string FeedUrl = "https://fake-feed.example.com/rss";
    private static readonly string[] Keywords = ["bitcoin", "btc"];

    // ---------------------------------------------------------------------------
    // Helpers
    // ---------------------------------------------------------------------------

    private const string RssDateFormat = "ddd, dd MMM yyyy HH:mm:ss zzz";

    private static string BuildRssXml(IEnumerable<(string title, DateTimeOffset pubDate)> items)
    {
        var sb = new StringBuilder();
        sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
        sb.AppendLine("<rss version=\"2.0\"><channel>");
        foreach (var (title, pubDate) in items)
        {
            sb.AppendLine("<item>");
            sb.AppendLine($"  <title>{title}</title>");
            sb.AppendLine($"  <link>https://example.com/{title.Replace(" ", "-")}</link>");
            sb.AppendLine($"  <description>Description of {title}</description>");
            sb.AppendLine($"  <pubDate>{pubDate.ToString(RssDateFormat, CultureInfo.InvariantCulture)}</pubDate>");
            sb.AppendLine("</item>");
        }
        sb.AppendLine("</channel></rss>");
        return sb.ToString();
    }

    private static IHttpClientFactory BuildFactory(HttpStatusCode statusCode, string? body = null)
    {
        var handler = new FakeHttpMessageHandler(statusCode, body ?? string.Empty);
        var client = new HttpClient(handler);
        var factory = new Mock<IHttpClientFactory>();
        factory.Setup(f => f.CreateClient("Feed")).Returns(client);
        return factory.Object;
    }

    private static FeedService BuildService(
        IHttpClientFactory factory,
        IMemoryCache? cache = null,
        ILogger<FeedService>? logger = null)
    {
        cache ??= new MemoryCache(new MemoryCacheOptions());
        logger ??= new Mock<ILogger<FeedService>>().Object;
        return new FeedService(cache, logger, factory);
    }

    // ---------------------------------------------------------------------------
    // Cache hit
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task GetFeedsAsync_ReturnsFeedsFromCache_IfPresent()
    {
        var cachedFeeds = new List<RSSFeed>
        {
            new() { Title = "Test Feed", Content = "the feed test content", Link = "http://test.org", PublishDate = Now }
        };
        object? outValue = cachedFeeds;

        var mockCache = new Mock<IMemoryCache>();
        mockCache.Setup(mc => mc.TryGetValue(It.IsAny<object>(), out outValue!)).Returns(true);

        var factory = BuildFactory(HttpStatusCode.OK);
        var sut = BuildService(factory, mockCache.Object);

        var result = await sut.GetFeedsAsync(FeedUrl, Start, End, Keywords);

        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("Test Feed", result.First().Title);
        Assert.Equal("the feed test content", result.First().Content);
        Assert.Equal("http://test.org", result.First().Link);
    }

    // ---------------------------------------------------------------------------
    // Cache miss + successful HTTP fetch
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task GetFeedsAsync_FetchesAndCachesFeeds_WhenCacheMissAndHttpSucceeds()
    {
        var rss = BuildRssXml(
        [
            ("Bitcoin hits new ATH",    Now.AddHours(-1)),
            ("Ethereum upgrade today",  Now.AddHours(-2)),  // no keyword match — excluded
            ("BTC dominance rises",     Now.AddDays(-1))
        ]);

        var realCache = new MemoryCache(new MemoryCacheOptions());
        var factory = BuildFactory(HttpStatusCode.OK, rss);
        var sut = BuildService(factory, realCache);

        var result = (await sut.GetFeedsAsync(FeedUrl, Start, End, Keywords)).ToList();

        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Contains(result, f => f.Title == "Bitcoin hits new ATH");
        Assert.Contains(result, f => f.Title == "BTC dominance rises");

        // Second call must be served from cache (handler would return empty on retry)
        var cachedResult = (await sut.GetFeedsAsync(FeedUrl, Start, End, Keywords)).ToList();
        Assert.Equal(2, cachedResult.Count);
    }

    // ---------------------------------------------------------------------------
    // Cache miss + HTTP failure
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task GetFeedsAsync_ReturnsEmpty_WhenHttpFails()
    {
        object? outValue = null;
        var mockCache = new Mock<IMemoryCache>();
        mockCache.Setup(mc => mc.TryGetValue(It.IsAny<object>(), out outValue!)).Returns(false);

        var factory = BuildFactory(HttpStatusCode.ServiceUnavailable);
        var sut = BuildService(factory, mockCache.Object);

        var result = await sut.GetFeedsAsync(FeedUrl, Start, End, Keywords);

        Assert.NotNull(result);
        Assert.Empty(result);
    }

    // ---------------------------------------------------------------------------
    // Cache miss + invalid RSS
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task GetFeedsAsync_ReturnsEmpty_WhenFeedIsInvalidXml()
    {
        object? outValue = null;
        var mockCache = new Mock<IMemoryCache>();
        mockCache.Setup(mc => mc.TryGetValue(It.IsAny<object>(), out outValue!)).Returns(false);

        var factory = BuildFactory(HttpStatusCode.OK, "<not-valid-rss>broken</not-valid-rss>");
        var sut = BuildService(factory, mockCache.Object);

        var result = await sut.GetFeedsAsync(FeedUrl, Start, End, Keywords);

        Assert.NotNull(result);
        Assert.Empty(result);
    }

    // ---------------------------------------------------------------------------
    // Date and keyword filtering
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task GetFeedsAsync_FiltersOutItemsOutsideDateRange()
    {
        var rss = BuildRssXml(
        [
            ("Bitcoin news today",  Now.AddHours(-1)),          // in range
            ("Old Bitcoin article", Now.AddDays(-10))           // out of range
        ]);

        var factory = BuildFactory(HttpStatusCode.OK, rss);
        var sut = BuildService(factory);

        var result = (await sut.GetFeedsAsync(FeedUrl, Start, End, Keywords)).ToList();

        Assert.Single(result);
        Assert.Equal("Bitcoin news today", result.First().Title);
    }

    [Fact]
    public async Task GetFeedsAsync_FiltersOutItemsWithNoKeywordMatch()
    {
        var rss = BuildRssXml(
        [
            ("Ethereum price update", Now.AddHours(-1)),   // no match
            ("BTC on the rise",       Now.AddHours(-2))    // match
        ]);

        var factory = BuildFactory(HttpStatusCode.OK, rss);
        var sut = BuildService(factory);

        var result = (await sut.GetFeedsAsync(FeedUrl, Start, End, Keywords)).ToList();

        Assert.Single(result);
        Assert.Equal("BTC on the rise", result.First().Title);
    }
}

// ---------------------------------------------------------------------------
// Test infrastructure
// ---------------------------------------------------------------------------

internal sealed class FakeHttpMessageHandler : HttpMessageHandler
{
    private readonly HttpStatusCode _statusCode;
    private readonly string _body;

    public FakeHttpMessageHandler(HttpStatusCode statusCode, string body)
    {
        _statusCode = statusCode;
        _body = body;
    }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var response = new HttpResponseMessage(_statusCode)
        {
            Content = new StringContent(_body, Encoding.UTF8, "application/rss+xml")
        };
        return Task.FromResult(response);
    }
}
