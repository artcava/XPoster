using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Contracts;
using XPoster.Orchestrators;
using XPoster.Models;

namespace XPoster.Tests.Orchestrators;

public class FeedOrchestratorTests
{
    private readonly Mock<ISender>                     _mockSender;
    private readonly Mock<ILogger<FeedOrchestrator>>   _mockLogger;
    private readonly Mock<IFeedService>                _mockFeedService;
    private readonly Mock<IFeedUrlProvider>            _mockFeedUrlProvider;
    private readonly Mock<ITagReplacementProvider>     _mockTagReplacementProvider;
    private readonly Mock<ITextToTextProvider>         _mockTextProvider;
    private readonly Mock<ITextToImageProvider>        _mockImageProvider;

    private static readonly List<string> DefaultUrls =
    [
        "https://cointelegraph.com/rss/tag/bitcoin",
        "https://www.coindesk.com/arc/outboundfeeds/rss"
    ];

    private static readonly Dictionary<string, string> DefaultReplacements = new()
    {
        { "bitcoin",    "#Bitcoin"    },
        { "btc",        "#BTC"        },
        { "fed",        "#FED"        }
    };

    public FeedOrchestratorTests()
    {
        _mockSender                 = new Mock<ISender>();
        _mockLogger                 = new Mock<ILogger<FeedOrchestrator>>();
        _mockFeedService            = new Mock<IFeedService>();
        _mockFeedUrlProvider        = new Mock<IFeedUrlProvider>();
        _mockTagReplacementProvider = new Mock<ITagReplacementProvider>();
        _mockTextProvider           = new Mock<ITextToTextProvider>();
        _mockImageProvider          = new Mock<ITextToImageProvider>();

        _mockFeedUrlProvider.Setup(p => p.GetFeedUrls()).Returns(DefaultUrls);
        _mockTagReplacementProvider.Setup(p => p.GetReplacements())
            .Returns(DefaultReplacements);
    }

    /// <summary>
    /// Factory for the happy-path orchestrator.
    /// Tests that need a null dependency instantiate the constructor directly.
    /// </summary>
    private FeedOrchestrator CreateOrchestrator() =>
        new(_mockSender.Object, _mockLogger.Object, _mockFeedService.Object,
            _mockFeedUrlProvider.Object, _mockTagReplacementProvider.Object,
            _mockTextProvider.Object, _mockImageProvider.Object);

    // ---------------------------------------------------------------------------
    // Happy path
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_Should_CreateMessageWithImage_WhenFeedsAreFound()
    {
        // ARRANGE
        var fakeFeeds   = new List<RSSFeed> { new() { Title = "Il Bitcoin", Content = "Notizia su Bitcoin", Link = "https://bitcoin.org/" } };
        var fakeSummary = "Questo è un riassunto";
        var fakePrompt  = "Prompt per immagine";
        var fakeImage   = new byte[] { 1, 2, 3 };

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);
        _mockTextProvider.Setup(s => s.GetImagePromptAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakePrompt);
        _mockImageProvider.Setup(s => s.GenerateImageAsync(fakePrompt, It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeImage);

        var orchestrator = CreateOrchestrator();

        // ACT
        var message = await orchestrator.OrchestrateAsync();

        // ASSERT
        Assert.NotNull(message);
        Assert.Equal(fakeSummary, message.Content);
        Assert.Equal(fakeImage, message.Image);

        _mockFeedUrlProvider.Verify(p => p.GetFeedUrls(), Times.Once);
        _mockFeedService.Verify(s => s.GetFeedsAsync(
            It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()),
            Times.Exactly(2));
        _mockTextProvider.Verify(s => s.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Once);
        _mockTextProvider.Verify(s => s.GetImagePromptAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);
        _mockImageProvider.Verify(s => s.GenerateImageAsync(fakePrompt, It.IsAny<CancellationToken>()), Times.Once);
    }

    // ---------------------------------------------------------------------------
    // Step 1 — AcquireFeedContentAsync failure paths
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnNull_When_NoFeedsFound()
    {
        // ARRANGE
        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(new List<RSSFeed>());

        var orchestrator = CreateOrchestrator();

        // ACT
        var result = await orchestrator.OrchestrateAsync();

        // ASSERT
        Assert.Null(result);
        Assert.False(orchestrator.SendIt);
        _mockTextProvider.Verify(s => s.GetSummaryAsync(
            It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnNull_When_FeedUrlProviderReturnsEmptyList()
    {
        // ARRANGE
        _mockFeedUrlProvider.Setup(p => p.GetFeedUrls()).Returns(new List<string>());

        var orchestrator = CreateOrchestrator();

        // ACT
        var result = await orchestrator.OrchestrateAsync();

        // ASSERT
        Assert.Null(result);
        Assert.False(orchestrator.SendIt);
        _mockFeedService.Verify(s => s.GetFeedsAsync(
            It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()),
            Times.Never);
    }

    // ---------------------------------------------------------------------------
    // Step 2 — GenerateSummaryAsync failure paths
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnNull_When_SummaryGenerationFails()
    {
        // ARRANGE
        var fakeFeeds = new List<RSSFeed> { new() { Title = "Il Bitcoin", Content = "Test content", Link = "https://bitcoin.org/" } };

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(
                It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(string.Empty);

        var orchestrator = CreateOrchestrator();

        // ACT
        var result = await orchestrator.OrchestrateAsync();

        // ASSERT
        Assert.Null(result);
        Assert.False(orchestrator.SendIt);
        _mockImageProvider.Verify(s => s.GenerateImageAsync(
            It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    // ---------------------------------------------------------------------------
    // Step 3 — ApplyTagReplacements
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_Should_CallTagReplacementProvider_ExactlyOnce_WhenOrchestrationSucceeds()
    {
        // ARRANGE
        var fakeFeeds   = new List<RSSFeed> { new() { Title = "Bitcoin", Content = "Test", Link = "https://bitcoin.org/" } };
        var fakeSummary = "Summary text";

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(
                It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);
        _mockTextProvider.Setup(s => s.GetImagePromptAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("prompt");
        _mockImageProvider.Setup(s => s.GenerateImageAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        var orchestrator = CreateOrchestrator();

        // ACT
        await orchestrator.OrchestrateAsync();

        // ASSERT — GetReplacements called once in AcquireFeedContentAsync (for keywords)
        //          and once in ApplyTagReplacements — total: 2
        _mockTagReplacementProvider.Verify(p => p.GetReplacements(), Times.Exactly(2));
    }

    [Fact]
    public async Task OrchestrateAsync_Should_ApplyHashtagsCorrectly()
    {
        // ARRANGE — provider returns standard replacement map
        var fakeFeeds   = new List<RSSFeed> { new() { Title = "Il Bitcoin", Content = "News about bitcoin and BTC and fed policy", Link = "https://bitcoin.org/" } };
        var fakeSummary = "News about bitcoin and btc. The fed decided...";
        var fakePrompt  = "Image prompt";
        var fakeImage   = new byte[] { 1, 2, 3 };

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(
                It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);
        _mockTextProvider.Setup(s => s.GetImagePromptAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakePrompt);
        _mockImageProvider.Setup(s => s.GenerateImageAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeImage);

        var orchestrator = CreateOrchestrator();

        // ACT
        var result = await orchestrator.OrchestrateAsync();

        // ASSERT
        Assert.NotNull(result);
        Assert.Contains("#Bitcoin", result.Content);
        Assert.Contains("#BTC",     result.Content);
        Assert.Contains("#FED",     result.Content);
        Assert.Single(System.Text.RegularExpressions.Regex.Matches(result.Content, "#Bitcoin"));
    }

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnPostWithUnmodifiedContent_When_ProviderReturnsEmptyReplacements()
    {
        // ARRANGE — provider returns no replacements: content must pass through unchanged
        _mockTagReplacementProvider.Setup(p => p.GetReplacements())
            .Returns(new Dictionary<string, string>());

        var fakeFeeds   = new List<RSSFeed> { new() { Title = "Bitcoin", Content = "bitcoin news", Link = "https://bitcoin.org/" } };
        var fakeSummary = "bitcoin summary";

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(
                It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);
        _mockTextProvider.Setup(s => s.GetImagePromptAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("prompt");
        _mockImageProvider.Setup(s => s.GenerateImageAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new byte[] { 1 });

        var orchestrator = CreateOrchestrator();

        // ACT
        var result = await orchestrator.OrchestrateAsync();

        // ASSERT
        Assert.NotNull(result);
        Assert.Equal(fakeSummary, result.Content);
    }

    // ---------------------------------------------------------------------------
    // Steps 4+5 — GenerateImageAsync paths
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationReturnsEmpty()
    {
        // ARRANGE
        var fakeFeeds   = new List<RSSFeed> { new() { Title = "Il Bitcoin", Content = "Test", Link = "https://bitcoin.org/" } };
        var fakeSummary = "Summary";
        var fakePrompt  = "Prompt";

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(
                It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);
        _mockTextProvider.Setup(s => s.GetImagePromptAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakePrompt);
        _mockImageProvider.Setup(s => s.GenerateImageAsync(fakePrompt, It.IsAny<CancellationToken>()))
            .ReturnsAsync(Array.Empty<byte>());

        var orchestrator = CreateOrchestrator();

        // ACT
        var result = await orchestrator.OrchestrateAsync();

        // ASSERT
        Assert.NotNull(result);
        Assert.Equal(fakeSummary, result.Content);
        Assert.Null(result.Image);
        Assert.True(orchestrator.SendIt);
    }

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationThrowsException()
    {
        // ARRANGE
        var fakeFeeds   = new List<RSSFeed> { new() { Title = "Il Bitcoin", Content = "Test", Link = "https://bitcoin.org/" } };
        var fakeSummary = "Summary";
        var fakePrompt  = "Prompt";

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(
                It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);
        _mockTextProvider.Setup(s => s.GetImagePromptAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakePrompt);
        _mockImageProvider.Setup(s => s.GenerateImageAsync(fakePrompt, It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception("Image generation failed"));

        var orchestrator = CreateOrchestrator();

        // ACT
        var result = await orchestrator.OrchestrateAsync();

        // ASSERT
        Assert.NotNull(result);
        Assert.Equal(fakeSummary, result.Content);
        Assert.Null(result.Image);
        Assert.True(orchestrator.SendIt);
    }

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageProviderIsNull()
    {
        // ARRANGE — slot uses a text-only provider (e.g. DeepSeek or Perplexity)
        var fakeFeeds   = new List<RSSFeed> { new() { Title = "Il Bitcoin", Content = "Test", Link = "https://bitcoin.org/" } };
        var fakeSummary = "Summary";

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(
                It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);

        var orchestrator = new FeedOrchestrator(
            _mockSender.Object, _mockLogger.Object, _mockFeedService.Object,
            _mockFeedUrlProvider.Object, _mockTagReplacementProvider.Object,
            _mockTextProvider.Object, imageProvider: null);

        // ACT
        var result = await orchestrator.OrchestrateAsync();

        // ASSERT
        Assert.NotNull(result);
        Assert.Equal(fakeSummary, result.Content);
        Assert.Null(result.Image);
        Assert.True(orchestrator.SendIt);
        _mockTextProvider.Verify(s => s.GetImagePromptAsync(
            It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    // ---------------------------------------------------------------------------
    // Guard paths — null providers
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnNull_When_TextProviderIsNull()
    {
        var orchestrator = new FeedOrchestrator(
            _mockSender.Object, _mockLogger.Object, _mockFeedService.Object,
            _mockFeedUrlProvider.Object, _mockTagReplacementProvider.Object,
            textProvider: null, imageProvider: null);

        var result = await orchestrator.OrchestrateAsync();

        Assert.Null(result);
        Assert.False(orchestrator.SendIt);
        _mockFeedService.Verify(s => s.GetFeedsAsync(
            It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()),
            Times.Never);
    }

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnNull_When_SenderIsNull()
    {
        // ARRANGE
        var fakeFeeds = new List<RSSFeed> { new() { Title = "Bitcoin", Content = "Test content", Link = "https://bitcoin.org/" } };

        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);

        var orchestrator = new FeedOrchestrator(
            null!, _mockLogger.Object, _mockFeedService.Object,
            _mockFeedUrlProvider.Object, _mockTagReplacementProvider.Object,
            _mockTextProvider.Object, _mockImageProvider.Object);

        // ACT
        var result = await orchestrator.OrchestrateAsync();

        // ASSERT
        Assert.Null(result);
        Assert.False(orchestrator.SendIt);
        _mockTextProvider.Verify(s => s.GetSummaryAsync(
            It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    // ---------------------------------------------------------------------------
    // Image prompt fallback — GetImagePromptAsync returns empty → summary used as prompt
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task OrchestrateAsync_Should_UseSummaryAsPrompt_When_GetImagePromptAsyncReturnsEmpty()
    {
        // ARRANGE
        var fakeFeeds   = new List<RSSFeed> { new() { Title = "Bitcoin", Content = "Test content", Link = "https://bitcoin.org/" } };
        var fakeSummary = "Fallback summary used as prompt";
        var fakeImage   = new byte[] { 9, 8, 7 };

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(
                It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);
        _mockTextProvider.Setup(s => s.GetImagePromptAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(string.Empty);
        _mockImageProvider.Setup(s => s.GenerateImageAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeImage);

        var orchestrator = CreateOrchestrator();

        // ACT
        var result = await orchestrator.OrchestrateAsync();

        // ASSERT — post published with image; summary used as fallback prompt
        Assert.NotNull(result);
        Assert.Equal(fakeImage, result.Image);
        Assert.True(orchestrator.SendIt);
        _mockImageProvider.Verify(
            s => s.GenerateImageAsync(fakeSummary, It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task OrchestrateAsync_Should_UseSummaryAsPrompt_When_GetImagePromptAsyncReturnsWhitespace()
    {
        // ARRANGE
        var fakeFeeds   = new List<RSSFeed> { new() { Title = "Bitcoin", Content = "Test content", Link = "https://bitcoin.org/" } };
        var fakeSummary = "Fallback summary";
        var fakeImage   = new byte[] { 1 };

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
                It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockTextProvider.Setup(s => s.GetSummaryAsync(
                It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);
        _mockTextProvider.Setup(s => s.GetImagePromptAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("   ");
        _mockImageProvider.Setup(s => s.GenerateImageAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeImage);

        var orchestrator = CreateOrchestrator();

        // ACT
        var result = await orchestrator.OrchestrateAsync();

        // ASSERT
        Assert.NotNull(result);
        Assert.Equal(fakeImage, result.Image);
        _mockImageProvider.Verify(
            s => s.GenerateImageAsync(fakeSummary, It.IsAny<CancellationToken>()),
            Times.Once);
    }
}
