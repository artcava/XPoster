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
}