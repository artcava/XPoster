using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Abstraction;
using XPoster.Implementation;
using XPoster.Models;

namespace XPoster.Tests;

public class FeedGeneratorTests
{
    private readonly Mock<ISender> _mockSender;
    private readonly Mock<ILogger<FeedGenerator>> _mockLogger;
    private readonly Mock<IFeedService> _mockFeedService;
    private readonly Mock<IAiService> _mockAiService;

    public FeedGeneratorTests()
    {
        _mockSender = new Mock<ISender>();
        _mockLogger = new Mock<ILogger<FeedGenerator>>();
        _mockFeedService = new Mock<IFeedService>();
        _mockAiService = new Mock<IAiService>();
    }

    [Fact]
    public async Task GenerateAsync_Should_CreateMessageWithImage_WhenFeedsAreFound()
    {
        // ARRANGE
        var fakeFeeds = new List<RSSFeed> { new() { Content = "Notizia su Bitcoin" } };
        var fakeSummary = "Questo è un riassunto";
        var fakePrompt = "Prompt per immagine";
        var fakeImage = new byte[] { 1, 2, 3 };

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockAiService.Setup(s => s.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>()))
            .ReturnsAsync(fakeSummary);
        _mockAiService.Setup(s => s.GetImagePromptAsync(fakeSummary))
            .ReturnsAsync(fakePrompt);
        _mockAiService.Setup(s => s.GenerateImageAsync(fakePrompt))
            .ReturnsAsync(fakeImage);

        var generator = new FeedGenerator(_mockSender.Object, _mockLogger.Object, _mockFeedService.Object, _mockAiService.Object);

        // ACT
        var message = await generator.GenerateAsync();

        // ASSERT
        Assert.NotNull(message);
        Assert.Equal(fakeSummary, message.Content);
        Assert.Equal(fakeImage, message.Image);

        _mockFeedService.Verify(s => s.GetFeedsAsync(It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IEnumerable<string>>()), Times.Exactly(2));
        _mockAiService.Verify(s => s.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>()), Times.Once);
        _mockAiService.Verify(s => s.GetImagePromptAsync(fakeSummary), Times.Once);
        _mockAiService.Verify(s => s.GenerateImageAsync(fakePrompt), Times.Once);
    }
    [Fact]
    public async Task GenerateAsync_Should_ReturnNull_When_NoFeedsFound()
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

        var generator = new FeedGenerator(
            _mockSender.Object,
            _mockLogger.Object,
            _mockFeedService.Object,
            _mockAiService.Object);

        // ACT
        var result = await generator.GenerateAsync();

        // ASSERT
        Assert.Null(result);
        Assert.False(generator.SendIt);
        _mockAiService.Verify(s => s.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>()), Times.Never);
    }

    [Fact]
    public async Task GenerateAsync_Should_ReturnNull_When_SummaryGenerationFails()
    {
        // ARRANGE
        var fakeFeeds = new List<RSSFeed> { new() { Content = "Test content" } };

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
            It.IsAny<string>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockAiService.Setup(s => s.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>()))
            .ReturnsAsync(string.Empty); // Simula fallimento

        var generator = new FeedGenerator(
            _mockSender.Object,
            _mockLogger.Object,
            _mockFeedService.Object,
            _mockAiService.Object);

        // ACT
        var result = await generator.GenerateAsync();

        // ASSERT
        Assert.Null(result);
        Assert.False(generator.SendIt);
        _mockAiService.Verify(s => s.GenerateImageAsync(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public async Task GenerateAsync_Should_ReturnNull_When_ImageGenerationFails()
    {
        // ARRANGE
        var fakeFeeds = new List<RSSFeed> { new() { Content = "Test" } };
        var fakeSummary = "Summary";
        var fakePrompt = "Prompt";

        _mockSender.Setup(s => s.MessageMaxLenght).Returns(280);
        _mockFeedService.Setup(s => s.GetFeedsAsync(
            It.IsAny<string>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(fakeFeeds);
        _mockAiService.Setup(s => s.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>()))
            .ReturnsAsync(fakeSummary);
        _mockAiService.Setup(s => s.GetImagePromptAsync(fakeSummary))
            .ReturnsAsync(fakePrompt);
        _mockAiService.Setup(s => s.GenerateImageAsync(fakePrompt))
            .ReturnsAsync((byte[])null); // Simula fallimento generazione immagine

        var generator = new FeedGenerator(
            _mockSender.Object,
            _mockLogger.Object,
            _mockFeedService.Object,
            _mockAiService.Object);

        // ACT
        var result = await generator.GenerateAsync();

        // ASSERT
        Assert.Null(result);
        Assert.False(generator.SendIt);
    }

    [Fact]
    public async Task GenerateAsync_Should_ApplyHashtagsCorrectly()
    {
        // ARRANGE
        var fakeFeeds = new List<RSSFeed> { new() { Content = "News about bitcoin and BTC and fed policy" } };
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
        _mockAiService.Setup(s => s.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>()))
            .ReturnsAsync(fakeSummary);
        _mockAiService.Setup(s => s.GetImagePromptAsync(It.IsAny<string>()))
            .ReturnsAsync(fakePrompt);
        _mockAiService.Setup(s => s.GenerateImageAsync(It.IsAny<string>()))
            .ReturnsAsync(fakeImage);

        var generator = new FeedGenerator(
            _mockSender.Object,
            _mockLogger.Object,
            _mockFeedService.Object,
            _mockAiService.Object);

        // ACT
        var result = await generator.GenerateAsync();

        // ASSERT
        Assert.NotNull(result);
        // Verifica che solo la PRIMA occorrenza sia trasformata in hashtag
        Assert.Contains("#Bitcoin", result.Content);
        Assert.Contains("#BTC", result.Content);
        Assert.Contains("#FED", result.Content);
        // Verifica che ci sia solo una occorrenza degli hashtag (non tutte)
        Assert.Equal(1, System.Text.RegularExpressions.Regex.Matches(result.Content, "#Bitcoin").Count);
    }
}