using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Models;
using XPoster.Services;

namespace XPoster.Tests.Services;

public class FeedServiceTests
{
    private readonly Mock<IMemoryCache> _mockCache;
    private readonly IMemoryCache _memoryCache;
    private readonly Mock<ILogger<FeedService>> _mockLogger;
    private readonly FeedService _feedService;
    private readonly FeedService _feedServiceWithMockedCache;
    private readonly Mock<ICacheEntry> _mockCacheEntry;

    public FeedServiceTests()
    {
        _mockCache = new Mock<IMemoryCache>();
        _memoryCache = new MemoryCache(new MemoryCacheOptions());
        _mockLogger = new Mock<ILogger<FeedService>>();
        _mockCacheEntry = new Mock<ICacheEntry>();
        _feedService = new FeedService(_memoryCache, _mockLogger.Object);
        _feedServiceWithMockedCache = new FeedService(_mockCache.Object, _mockLogger.Object);
    }

    [Fact]
    public async Task GetFeedsAsync_ReturnsFeedsFromCache_IfPresent()
    {
        // Arrange
        var cachedFeeds = new List<RSSFeed> { new RSSFeed { Title = "Test Feed", Content = "the feed test content", Link = "http://test.org" } };
        // CS8600: out param in TryGetValue is object? — cast via object is required by Moq API
        object? outValue = cachedFeeds;

        _mockCache.Setup(mc => mc.TryGetValue(It.IsAny<object>(), out outValue!)).Returns(true);

        var result = await _feedServiceWithMockedCache.GetFeedsAsync("http://fakeurl.com", DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow, new[] { "bitcoin" });

        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("Test Feed", result.First().Title);
        Assert.Equal("the feed test content", result.First().Content);
        Assert.Equal("http://test.org", result.First().Link);
    }

    [Fact]
    public async Task GetFeedsAsync_ReturnsEmpty_WhenInvalidFeed()
    {
        // CS8600: null intentional — simulating cache miss
        object? outValue = null;
        _mockCache.Setup(mc => mc.TryGetValue(It.IsAny<object>(), out outValue!)).Returns(false);

        var result = await _feedServiceWithMockedCache.GetFeedsAsync("http://invalidurl", DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow, new[] { "bitcoin" });

        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetFeedsAsync_FiltersByKeyword_AndDate()
    {
        var feeds = await _feedService.GetFeedsAsync("https://cointelegraph.com/rss/tag/bitcoin", DateTimeOffset.UtcNow.AddDays(-2), DateTimeOffset.UtcNow, new[] { "bitcoin", "btc" });

        Assert.NotNull(feeds);
        Assert.All(feeds, f => Assert.True(f.PublishDate >= DateTimeOffset.UtcNow.AddDays(-2) && f.PublishDate <= DateTimeOffset.UtcNow));
        Assert.All(feeds, f => Assert.True(System.Text.RegularExpressions.Regex.IsMatch(f.Title ?? string.Empty, "(bitcoin|btc)", System.Text.RegularExpressions.RegexOptions.IgnoreCase)));
    }

    [Fact]
    public async Task GetFeedsAsync_SetsCache_WhenFeedsFetched()
    {
        object? outValue = null;
        bool cacheSetCalled = false;

        _mockCache.Setup(mc => mc.TryGetValue(It.IsAny<object>(), out outValue!)).Returns(false);
        _mockCache.Setup(mc => mc.CreateEntry(It.IsAny<object>())).Returns(_mockCacheEntry.Object).Callback(() => cacheSetCalled = true);
        _mockCacheEntry.SetupAllProperties();

        var result = await _feedServiceWithMockedCache.GetFeedsAsync("https://cointelegraph.com/rss/tag/bitcoin", DateTimeOffset.UtcNow.AddDays(-2), DateTimeOffset.UtcNow, new[] { "bitcoin" });

        Assert.True(cacheSetCalled);
    }
}
