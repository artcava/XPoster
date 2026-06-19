using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Contracts;
using XPoster.Orchestrators;
using XPoster.Models;

namespace XPoster.Tests.Orchestrators;

public class FeedOrchestratorTests
{
    private readonly Mock<ISender> _mockSender;
    private readonly Mock<ILogger<FeedOrchestrator>> _mockLogger;
    private readonly Mock<IFeedService> _mockFeedService;
    private readonly Mock<IFeedUrlProvider> _mockFeedUrlProvider;
    private readonly Mock<IAiService> _mockAiService;

    private static readonly List<string> DefaultUrls =
    [
        "https://cointelegraph.com/rss/tag/bitcoin",
        "https://www.coindesk.com/arc/outboundfeeds/rss"
    ];

    public FeedOrchestratorTests()
    {
        _mockSender = new Mock<ISender>();
        _mockLogger = new Mock<ILogger<FeedOrchestrator>>();
        _mockFeedService = new Mock<IFeedService>();
        _mockFeedUrlProvider = new Mock<IFeedUrlProvider>();
        _mockAiService = new Mock<IAiService>();

        _mockFeedUrlProvider.Setup(p => p.GetFeedUrls()).Returns(DefaultUrls);
    }

    /// <summary>
    /// Factory for the happy-path orchestrator. Tests that need a null dependency
    /// (AiServiceIsNull, SenderIsNull) instantiate the constructor directly.
    /// </summary>
    private FeedOrchestrator CreateOrchestrator() =>
        new(_mockSender.Object, _mockLogger.Object, _mockFeedService.Object, _mockFeedUrlProvider.Object, _mockAiService.Object);

    [Fact]
    public async Task OrchestrateAsync_Should_CreateMessageWithImage_WhenFeedsAreFound()
    {
        // ARRANGE
        var fakeFeeds = new List<RSSFeed> { new() { Title = "Il Bitcoin", Content = "Notizia su Bitcoin", Link = "https://bitcoin.org/" } };
        var fakeSummary = "Questo è un riassunto";
        var fakePrompt = "Prompt per immagine";
        var fakeImage = new byte[] { 1, 2, 3 };

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockAiService.Setup(s => s.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);
        _mockAiService.Setup(s => s.GetImagePromptAsync(fakeSummary, It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakePrompt);
        _mockAiService.Setup(s => s.GenerateImageAsync(fakePrompt, It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeImage);

        var orchestrator = CreateOrchestrator();

        // ACT
        var message = await orchestrator.OrchestrateAsync();

        // ASSERT
        Assert.NotNull(message);
        Assert.Equal(fakeSummary, message.Content);
        Assert.Equal(fakeImage, message.Image);

        _mockFeedUrlProvider.Verify(p => p.GetFeedUrls(), Times.Once);
        _mockFeedService.Verify(s => s.GetFeedsAsync(It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()), Times.Exactly(2));
        _mockAiService.Verify(s => s.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Once);
        _mockAiService.Verify(s => s.GetImagePromptAsync(fakeSummary, It.IsAny<CancellationToken>()), Times.Once);
        _mockAiService.Verify(s => s.GenerateImageAsync(fakePrompt, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnNull_When_NoFeedsFound()
    {
        // ARRANGE
        var emptyFeeds = new List<RSSFeed>();

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
            It.IsAny<string>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(emptyFeeds);

        var orchestrator = CreateOrchestrator();

        // ACT
        var result = await orchestrator.OrchestrateAsync();

        // ASSERT
        Assert.Null(result);
        Assert.False(orchestrator.SendIt);
        _mockAiService.Verify(s => s.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnNull_When_SummaryGenerationFails()
    {
        // ARRANGE
        var fakeFeeds = new List<RSSFeed> { new() { Title = "Il Bitcoin", Content = "Test content", Link = "https://bitcoin.org/" } };

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
            It.IsAny<string>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockAiService.Setup(s => s.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(string.Empty);

        var orchestrator = CreateOrchestrator();

        // ACT
        var result = await orchestrator.OrchestrateAsync();

        // ASSERT
        Assert.Null(result);
        Assert.False(orchestrator.SendIt);
        _mockAiService.Verify(s => s.GenerateImageAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationReturnsNull()
    {
        // ARRANGE
        var fakeFeeds = new List<RSSFeed> { new() { Title = "Il Bitcoin", Content = "Test", Link = "https://bitcoin.org/" } };
        var fakeSummary = "Summary";
        var fakePrompt = "Prompt";

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
            It.IsAny<string>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockAiService.Setup(s => s.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);
        _mockAiService.Setup(s => s.GetImagePromptAsync(fakeSummary, It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakePrompt);
        _mockAiService.Setup(s => s.GenerateImageAsync(fakePrompt, It.IsAny<CancellationToken>()))
            .ReturnsAsync((byte[]?)null!);

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
        var fakeFeeds = new List<RSSFeed> { new() { Title = "Il Bitcoin", Content = "Test", Link = "https://bitcoin.org/" } };
        var fakeSummary = "Summary";
        var fakePrompt = "Prompt";

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
            It.IsAny<string>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockAiService.Setup(s => s.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);
        _mockAiService.Setup(s => s.GetImagePromptAsync(fakeSummary, It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakePrompt);
        _mockAiService.Setup(s => s.GenerateImageAsync(fakePrompt, It.IsAny<CancellationToken>()))
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
    public async Task OrchestrateAsync_Should_ApplyHashtagsCorrectly()
    {
        // ARRANGE
        var fakeFeeds = new List<RSSFeed> { new() { Title = "Il Bitcoin", Content = "News about bitcoin and BTC and fed policy", Link = "https://bitcoin.org/" } };
        var fakeSummary = "News about bitcoin and btc. The fed decided...";
        var fakePrompt = "Image prompt";
        var fakeImage = new byte[] { 1, 2, 3 };

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
            It.IsAny<string>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockAiService.Setup(s => s.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeSummary);
        _mockAiService.Setup(s => s.GetImagePromptAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakePrompt);
        _mockAiService.Setup(s => s.GenerateImageAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeImage);

        var orchestrator = CreateOrchestrator();

        // ACT
        var result = await orchestrator.OrchestrateAsync();

        // ASSERT
        Assert.NotNull(result);
        Assert.Contains("#Bitcoin", result.Content);
        Assert.Contains("#BTC", result.Content);
        Assert.Contains("#FED", result.Content);
        Assert.Single(System.Text.RegularExpressions.Regex.Matches(result.Content, "#Bitcoin"));
    }

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnNull_When_AiServiceIsNull()
    {
        var orchestrator = new FeedOrchestrator(
            _mockSender.Object,
            _mockLogger.Object,
            _mockFeedService.Object,
            _mockFeedUrlProvider.Object,
            null);

        var result = await orchestrator.OrchestrateAsync();

        Assert.Null(result);
        Assert.False(orchestrator.SendIt);
        _mockFeedService.Verify(s => s.GetFeedsAsync(
            It.IsAny<string>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<IEnumerable<string>>()), Times.Never);
    }

    [Fact]
    public async Task OrchestrateAsync_Should_ReturnNull_When_SenderIsNull()
    {
        var fakeFeeds = new List<RSSFeed> { new() { Title = "Bitcoin", Content = "Test content", Link = "https://bitcoin.org/" } };

        _mockFeedService.Setup(s => s.GetFeedsAsync(
            It.IsAny<string>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);

        var orchestrator = new FeedOrchestrator(
            null!,
            _mockLogger.Object,
            _mockFeedService.Object,
            _mockFeedUrlProvider.Object,
            _mockAiService.Object);

        var result = await orchestrator.OrchestrateAsync();

        Assert.Null(result);
        Assert.False(orchestrator.SendIt);
        _mockAiService.Verify(s => s.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
    }
}
