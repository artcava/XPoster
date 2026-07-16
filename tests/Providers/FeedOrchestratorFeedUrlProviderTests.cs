using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Contracts;
using XPoster.Orchestrators;
using XPoster.Models;

namespace XPoster.Tests.Providers;

/// <summary>
/// Tests focused on <see cref="FeedOrchestrator"/> interactions with feed URL resolution
/// via <see cref="FeedOrchestratorContext"/>.
/// Covers URL delegation, empty-URL guard, per-URL FeedService call verification,
/// and feed content aggregation — all using the slot-scoped context introduced in issue #223.
/// </summary>
public class FeedOrchestratorFeedUrlProviderTests
{
    private readonly Mock<ISender> _mockSender;
    private readonly Mock<ILogger<FeedOrchestrator>> _mockLogger;
    private readonly Mock<IFeedService> _mockFeedService;
    private readonly Mock<ITagReplacementProvider> _mockTagReplacementProvider;
    private readonly Mock<ITagReplacementService> _mockTagReplacementService;
    private readonly Mock<ITextToTextProvider> _mockTextProvider;
    private readonly Mock<ITextToImageProvider> _mockImageProvider;

    private static readonly FeedPromptOptions DefaultPromptOptions = new()
    {
        Steps = new List<PromptStepOptions>
        {
            new()
            {
                Role = PromptRole.Summary,
                SystemPromptTemplate = "You are a summariser.",
                UserPromptTemplate = "Summarise: {Text}"
            },
            new()
            {
                Role = PromptRole.ImagePromptDerivation,
                SystemPromptTemplate = "You derive image prompts.",
                UserPromptTemplate = "Derive a prompt from: {Summary}",
                MaxOutputLength = 500
            },
            new()
            {
                Role = PromptRole.ImageGeneration,
                SystemPromptTemplate = string.Empty,
                UserPromptTemplate = "{Text}",
                ImageQuantity = 1,
                ImageSize = "1024x1024"
            }
        }.AsReadOnly()
    };

    public FeedOrchestratorFeedUrlProviderTests()
    {
        _mockSender = new Mock<ISender>();
        _mockLogger = new Mock<ILogger<FeedOrchestrator>>();
        _mockFeedService = new Mock<IFeedService>();
        _mockTagReplacementProvider = new Mock<ITagReplacementProvider>();
        _mockTextProvider = new Mock<ITextToTextProvider>();
        _mockTagReplacementService = new Mock<ITagReplacementService>();
        _mockImageProvider = new Mock<ITextToImageProvider>();

        _mockSender.Setup(s => s.MessageMaxLength).Returns(280);
        _mockTagReplacementProvider.Setup(p => p.GetReplacements())
            .Returns(new Dictionary<string, string>());
        _mockTagReplacementService.Setup(s => s.Apply(It.IsAny<string>()))
            .Returns<string>(x => x);
    }

    private FeedOrchestratorContext BuildContext(IReadOnlyList<string> feedUrls) =>
        new()
        {
            FeedUrls = feedUrls,
            PromptOptions = DefaultPromptOptions
        };

    private FeedOrchestrator CreateOrchestrator(IReadOnlyList<string> feedUrls) =>
        new(
            new List<ISender> { _mockSender.Object }.AsReadOnly(),
            _mockLogger.Object,
            _mockFeedService.Object,
            BuildContext(feedUrls),
            _mockTagReplacementProvider.Object,
            _mockTagReplacementService.Object,
            _mockTextProvider.Object,
            _mockImageProvider.Object);

    private void SetupHappyPathProviders()
    {
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(It.IsAny<PromptRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("GeneratedText");

        _mockImageProvider
            .Setup(s => s.GenerateImageAsync(It.IsAny<ImagePromptRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });
    }

    // -------------------------------------------------------------------------
    // Feed URL resolution
    // -------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url()
    {
        var urls = new List<string>
        {
            "https://feed1.com/rss",
            "https://feed2.com/rss",
            "https://feed3.com/rss"
        }.AsReadOnly();

        var fakeFeeds = new List<RSSFeed> { new() { Title = "T", Content = "C", Link = "https://l.com" } };
        _mockFeedService
            .Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);
        SetupHappyPathProviders();

        await CreateOrchestrator(urls).OrchestrateAsync();

        _mockFeedService.Verify(
            s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()),
            Times.Exactly(urls.Count));
    }

    [Fact]
    public async Task OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls()
    {
        var url1 = "https://feed1.com/rss";
        var url2 = "https://feed2.com/rss";
        var urls = new List<string> { url1, url2 }.AsReadOnly();

        var fakeFeeds = new List<RSSFeed> { new() { Title = "T", Content = "C", Link = "https://l.com" } };
        _mockFeedService
            .Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);
        SetupHappyPathProviders();

        await CreateOrchestrator(urls).OrchestrateAsync();

        _mockFeedService.Verify(
            s => s.GetFeedsAsync(url1, It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()),
            Times.Once);
        _mockFeedService.Verify(
            s => s.GetFeedsAsync(url2, It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()),
            Times.Once);
    }

    // -------------------------------------------------------------------------
    // Empty-URL guard
    // -------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ContextHasNoFeedUrls()
    {
        var orchestrator = CreateOrchestrator(new List<string>().AsReadOnly());

        var result = await orchestrator.OrchestrateAsync();

        Assert.Empty(result);
        Assert.False(orchestrator.SendIt);
        _mockFeedService.Verify(
            s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()),
            Times.Never);
        _mockTextProvider.Verify(
            s => s.GenerateTextAsync(It.IsAny<PromptRequest>(), It.IsAny<CancellationToken>()),
            Times.Never);
    }

    // -------------------------------------------------------------------------
    // Feed content aggregation
    // -------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_Should_AggregateFeeds_From_All_Urls()
    {
        var url1 = "https://feed1.com/rss";
        var url2 = "https://feed2.com/rss";
        var urls = new List<string> { url1, url2 }.AsReadOnly();

        var feedsFromUrl1 = new List<RSSFeed> { new() { Title = "Feed1 Item", Content = "Content1", Link = "https://l1.com" } };
        var feedsFromUrl2 = new List<RSSFeed> { new() { Title = "Feed2 Item", Content = "Content2", Link = "https://l2.com" } };

        _mockFeedService
            .Setup(s => s.GetFeedsAsync(url1, It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(feedsFromUrl1);
        _mockFeedService
            .Setup(s => s.GetFeedsAsync(url2, It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(feedsFromUrl2);

        string? capturedInputText = null;
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(It.IsAny<PromptRequest>(), It.IsAny<CancellationToken>()))
            .Callback<PromptRequest, CancellationToken>((req, _) =>
            {
                // Capture the first call (Summary step) which receives the aggregated feed content
                capturedInputText ??= req.InputText;
            })
            .ReturnsAsync("AggregatedSummary");
        _mockImageProvider
            .Setup(s => s.GenerateImageAsync(It.IsAny<ImagePromptRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        var result = await CreateOrchestrator(urls).OrchestrateAsync();

        Assert.NotEmpty(result);
        Assert.NotNull(capturedInputText);
        Assert.Contains("Content1", capturedInputText);
        Assert.Contains("Content2", capturedInputText);
    }

    // -------------------------------------------------------------------------
    // PromptRequest construction — Summary step uses sender MessageMaxLength
    // -------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_Should_PassSenderMessageMaxLength_As_MaxOutputLength_In_SummaryRequest()
    {
        const int expectedLimit = 280;
        var urls = new List<string> { "https://feed1.com/rss" }.AsReadOnly();

        var fakeFeeds = new List<RSSFeed> { new() { Title = "T", Content = "C", Link = "https://l.com" } };
        _mockFeedService
            .Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);

        PromptRequest? capturedSummaryRequest = null;
        _mockTextProvider
            .Setup(s => s.GenerateTextAsync(It.IsAny<PromptRequest>(), It.IsAny<CancellationToken>()))
            .Callback<PromptRequest, CancellationToken>((req, _) =>
            {
                capturedSummaryRequest ??= req;
            })
            .ReturnsAsync("Summary");
        _mockImageProvider
            .Setup(s => s.GenerateImageAsync(It.IsAny<ImagePromptRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        await CreateOrchestrator(urls).OrchestrateAsync();

        Assert.NotNull(capturedSummaryRequest);
        Assert.Equal(expectedLimit, capturedSummaryRequest!.MaxOutputLength);
    }

    // -------------------------------------------------------------------------
    // Per-slot context isolation — two slots with independent feed URLs
    // -------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_TwoSlots_Should_UseDifferentFeedUrls_Independently()
    {
        var urlsSlot1 = new List<string> { "https://slot1-feed.com/rss" }.AsReadOnly();
        var urlsSlot2 = new List<string> { "https://slot2-feed.com/rss" }.AsReadOnly();

        var fakeFeeds = new List<RSSFeed> { new() { Title = "T", Content = "C", Link = "https://l.com" } };
        _mockFeedService
            .Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(),
                It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeFeeds);
        SetupHappyPathProviders();

        // Simulate two independent orchestrator instances, one per slot
        await CreateOrchestrator(urlsSlot1).OrchestrateAsync();
        await CreateOrchestrator(urlsSlot2).OrchestrateAsync();

        _mockFeedService.Verify(
            s => s.GetFeedsAsync("https://slot1-feed.com/rss", It.IsAny<DateTimeOffset>(),
                It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()),
            Times.Once);
        _mockFeedService.Verify(
            s => s.GetFeedsAsync("https://slot2-feed.com/rss", It.IsAny<DateTimeOffset>(),
                It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>(), It.IsAny<CancellationToken>()),
            Times.Once);
    }
}
