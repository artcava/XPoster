using Microsoft.Extensions.Options;
using Moq;
using XPoster.Implementation;
using XPoster.Models;

namespace XPoster.Tests.Implementation;

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
        // ARRANGE
        var orderedUrls = new List<string> { "https://first.com/feed", "https://second.com/feed", "https://third.com/feed" };
        var options = Options.Create(new FeedOptions { Urls = orderedUrls });
        var provider = new ConfigurationFeedUrlProvider(options);

        // ACT
        var result = provider.GetFeedUrls();

        // ASSERT
        Assert.Equal(orderedUrls, result);
    }

    // --- Edge: absent / null Urls ---

    [Fact]
    public void GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull()
    {
        // ARRANGE
        var options = Options.Create(new FeedOptions { Urls = null! });
        var provider = new ConfigurationFeedUrlProvider(options);

        // ACT
        var result = provider.GetFeedUrls();

        // ASSERT
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty()
    {
        // ARRANGE
        var options = Options.Create(new FeedOptions { Urls = [] });
        var provider = new ConfigurationFeedUrlProvider(options);

        // ACT
        var result = provider.GetFeedUrls();

        // ASSERT
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    // --- Guard: null options ---

    [Fact]
    public void Constructor_Should_Throw_When_OptionsIsNull()
    {
        // ARRANGE + ACT + ASSERT
        Assert.Throws<ArgumentNullException>(() =>
            new ConfigurationFeedUrlProvider(null!));
    }

    // --- Return type is IReadOnlyList ---

    [Fact]
    public void GetFeedUrls_Should_ReturnReadOnlyList()
    {
        // ARRANGE
        var options = Options.Create(new FeedOptions { Urls = ["https://example.com/feed"] });
        var provider = new ConfigurationFeedUrlProvider(options);

        // ACT
        var result = provider.GetFeedUrls();

        // ASSERT
        Assert.IsAssignableFrom<IReadOnlyList<string>>(result);
    }
}
