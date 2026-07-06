using XPoster.Orchestrators;
using XPoster.Models;

namespace XPoster.Tests.Orchestrators;

public class ConfigurationFeedUrlProviderTests
{
    // --- Happy path ---

    [Fact]
    public void GetFeedUrls_Should_ReturnConfiguredUrls_When_OptionsContainsUrls()
    {
        // ARRANGE
        var expectedUrls = new List<string>
        {
            "https://cointelegraph.com/rss/tag/bitcoin",
            "https://www.coindesk.com/arc/outboundfeeds/rss"
        };
        var options = Options.Create(new FeedOptions { Urls = expectedUrls });
        var provider = new ConfigurationFeedUrlProvider(options);

        // ACT
        var result = provider.GetFeedUrls();

        // ASSERT
        Assert.Equal(2, result.Count);
        Assert.Equal(expectedUrls[0], result[0]);
        Assert.Equal(expectedUrls[1], result[1]);
    }

    [Fact]
    public void GetFeedUrls_Should_ReturnUrlsInOrder_When_MultipleUrlsConfigured()
    {
        var orderedUrls = new List<string> { "https://first.com/feed", "https://second.com/feed", "https://third.com/feed" };
        var options = Options.Create(new FeedOptions { Urls = orderedUrls });
        var provider = new ConfigurationFeedUrlProvider(options);

        var result = provider.GetFeedUrls();

        Assert.Equal(orderedUrls, result);
    }

    [Fact]
    public void GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull()
    {
        var options = Options.Create(new FeedOptions { Urls = null! });
        var provider = new ConfigurationFeedUrlProvider(options);

        var result = provider.GetFeedUrls();

        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty()
    {
        var options = Options.Create(new FeedOptions { Urls = [] });
        var provider = new ConfigurationFeedUrlProvider(options);

        var result = provider.GetFeedUrls();

        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Constructor_Should_Throw_When_OptionsIsNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new ConfigurationFeedUrlProvider(null!));
    }

    [Fact]
    public void GetFeedUrls_Should_ReturnReadOnlyList()
    {
        var options = Options.Create(new FeedOptions { Urls = ["https://example.com/feed"] });
        var provider = new ConfigurationFeedUrlProvider(options);

        var result = provider.GetFeedUrls();

        Assert.IsAssignableFrom<IReadOnlyList<string>>(result);
    }
}
