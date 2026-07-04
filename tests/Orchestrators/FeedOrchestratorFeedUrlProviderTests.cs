using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Contracts;
using XPoster.Orchestrators;
using XPoster.Models;

namespace XPoster.Tests.Orchestrators;

/// <summary>
/// Tests focused on <see cref="FeedOrchestrator"/> interactions with <see cref="IFeedUrlProvider"/>.
/// Covers URL delegation, empty-URL guard, and per-URL FeedService call verification.
/// </summary>
public class FeedOrchestratorFeedUrlProviderTests
{
    private readonly Mock<ISender>                     _mockSender;
    private readonly Mock<ILogger<FeedOrchestrator>>   _mockLogger;
    private readonly Mock<IFeedService>                _mockFeedService;
    private readonly Mock<IFeedUrlProvider>            _mockFeedUrlProvider;
    private readonly Mock<ITagReplacementProvider>     _mockTagReplacementProvider;
    private readonly Mock<ITagReplacementService>      _mockTagReplacementService;
    private readonly Mock<ITextToTextProvider>         _mockTextProvider;
    private readonly Mock<ITextToImageProvider>        _mockImageProvider;

    public FeedOrchestratorFeedUrlProviderTests()
    {
        _mockSender                 = new Mock<ISender>();
        _mockLogger                 = new Mock<ILogger<FeedOrchestrator>>();
        _mockFeedService            = new Mock<IFeedService>();
        _mockFeedUrlProvider        = new Mock<IFeedUrlProvider>();
        _mockTagReplacementProvider = new Mock<ITagReplacementProvider>();
        _mockTextProvider           = new Mock<ITextToTextProvider>();
        _mockTagReplacementService  = new Mock<ITagReplacementService>();
        _mockImageProvider          = new Mock<ITextToImageProvider>();

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockTagReplacementProvider.Setup(p => p.GetReplacements())
            .Returns(new Dictionary<string, string>());
    }

    private FeedOrchestrator CreateOrchestrator() =>
        new(
            new List<ISender> { _mockSender.Object }.AsReadOnly(),
            _mockLogger.Object, _mockFeedService.Object,
            _mockFeedUrlProvider.Object, _mockTagReplacementProvider.Object,
            _mockTagReplacementService.Object, _mockTextProvider.Object, _mockImageProvider.Object);

    [Fact]
    public async Task OrchestrateAsync_Should_CallGetFeedUrls_Once()
    {
        _mockFeedUrlProvider.Setup(p => p.GetFeedUrls()).Returns(["https://feed1.com/rss"]);
        var fakeFeeds = new List<RSSFeed> { new() { Title = "T", Content = "C", Link = "https://l.com" } };
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(
                It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("Summary");
        _mockTextProvider.Setup(s => s.GetImagePromptAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("Prompt");
        _mockImageProvider.Setup(s => s.GenerateImageAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        await CreateOrchestrator().OrchestrateAsync();

        _mockFeedUrlProvider.Verify(p => p.GetFeedUrls(), Times.Once);
    }

    [Fact]
    public async Task OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url()
    {
        var urls = new List<string>
        {
            "https://feed1.com/rss",
            "https://feed2.com/rss",
            "https://feed3.com/rss"
        };
        _mockFeedUrlProvider.Setup(p => p.GetFeedUrls()).Returns(urls);

        var fakeFeeds = new List<RSSFeed> { new() { Title = "T", Content = "C", Link = "https://l.com" } };
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(
                It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("Summary");
        _mockTextProvider.Setup(s => s.GetImagePromptAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("Prompt");
        _mockImageProvider.Setup(s => s.GenerateImageAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        await CreateOrchestrator().OrchestrateAsync();

        _mockFeedService.Verify(
            s => s.GetFeedsAsync(It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()),
            Times.Exactly(urls.Count));
    }

    [Fact]
    public async Task OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls()
    {
        var url1 = "https://feed1.com/rss";
        var url2 = "https://feed2.com/rss";
        _mockFeedUrlProvider.Setup(p => p.GetFeedUrls()).Returns(new List<string> { url1, url2 }.AsReadOnly());

        var fakeFeeds = new List<RSSFeed> { new() { Title = "T", Content = "C", Link = "https://l.com" } };
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(
                It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("Summary");
        _mockTextProvider.Setup(s => s.GetImagePromptAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("Prompt");
        _mockImageProvider.Setup(s => s.GenerateImageAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        await CreateOrchestrator().OrchestrateAsync();

        _mockFeedService.Verify(
            s => s.GetFeedsAsync(url1, It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()),
            Times.Once);
        _mockFeedService.Verify(
            s => s.GetFeedsAsync(url2, It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ProviderReturnsEmptyList()
    {
        _mockFeedUrlProvider.Setup(p => p.GetFeedUrls()).Returns(new List<string>().AsReadOnly());

        var orchestrator = CreateOrchestrator();
        var result = await orchestrator.OrchestrateAsync();

        Assert.Empty(result);
        Assert.False(orchestrator.SendIt);
        _mockFeedService.Verify(
            s => s.GetFeedsAsync(It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()),
            Times.Never);
        _mockTextProvider.Verify(
            s => s.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()),
            Times.Never);
    }

    [Fact]
    public async Task OrchestrateAsync_Should_AggregateFeeds_From_All_Urls()
    {
        var url1 = "https://feed1.com/rss";
        var url2 = "https://feed2.com/rss";
        _mockFeedUrlProvider.Setup(p => p.GetFeedUrls()).Returns(new List<string> { url1, url2 }.AsReadOnly());

        var feedsFromUrl1 = new List<RSSFeed> { new() { Title = "Feed1 Item", Content = "Content1", Link = "https://l1.com" } };
        var feedsFromUrl2 = new List<RSSFeed> { new() { Title = "Feed2 Item", Content = "Content2", Link = "https://l2.com" } };

        _mockFeedService
            .Setup(s => s.GetFeedsAsync(url1, It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(feedsFromUrl1);
        _mockFeedService
            .Setup(s => s.GetFeedsAsync(url2, It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(feedsFromUrl2);

        string? capturedFeedContent = null;
        _mockTextProvider
            .Setup(s => s.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .Callback<string, int, CancellationToken>((content, _, _) => capturedFeedContent = content)
            .ReturnsAsync("AggregatedSummary");
        _mockTextProvider.Setup(s => s.GetImagePromptAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("Prompt");
        _mockImageProvider.Setup(s => s.GenerateImageAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        var result = await CreateOrchestrator().OrchestrateAsync();

        Assert.NotEmpty(result);
        Assert.NotNull(capturedFeedContent);
        Assert.Contains("Content1", capturedFeedContent);
        Assert.Contains("Content2", capturedFeedContent);
    }
}
