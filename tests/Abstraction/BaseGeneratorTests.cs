using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Abstraction;
using XPoster.Models;

namespace XPoster.Tests.Abstraction;

/// <summary>
/// Tests for the shared PostAsync logic in BaseGenerator.
/// Uses a minimal concrete subclass (TestGenerator) to exercise all guard branches.
/// </summary>
public class BaseGeneratorTests
{
    // Minimal concrete subclass — lets us control SendIt and ProduceImage per test
    private class TestGenerator(ISender? sender, ILogger logger, bool sendIt = true, bool produceImage = false)
        : BaseGenerator(sender, logger)
    {
        private bool _sendIt = sendIt;
        public override string Name => "TestGenerator";
        public override bool SendIt { get => _sendIt; set => _sendIt = value; }
        public override bool ProduceImage { get; set; } = produceImage;
        public override Task<Post?> GenerateAsync() => Task.FromResult<Post?>(null);
    }

    private readonly Mock<ISender> _mockSender;
    private readonly Mock<ILogger> _mockLogger;

    public BaseGeneratorTests()
    {
        _mockSender = new Mock<ISender>();
        _mockLogger = new Mock<ILogger>();
    }

    [Fact]
    public async Task PostAsync_ReturnsFalse_When_SendIt_IsFalse()
    {
        var generator = new TestGenerator(null, _mockLogger.Object, sendIt: false);
        var post = new Post { Content = "Hello" };

        var result = await generator.PostAsync(post);

        Assert.False(result);
    }

    [Fact]
    public async Task PostAsync_ReturnsFalse_When_Content_IsEmpty()
    {
        var generator = new TestGenerator(_mockSender.Object, _mockLogger.Object, sendIt: true);
        var post = new Post { Content = string.Empty };

        var result = await generator.PostAsync(post);

        Assert.False(result);
        _mockSender.Verify(s => s.SendAsync(It.IsAny<Post>()), Times.Never);
    }

    [Fact]
    public async Task PostAsync_ReturnsFalse_When_Content_IsWhiteSpace()
    {
        var generator = new TestGenerator(_mockSender.Object, _mockLogger.Object, sendIt: true);
        var post = new Post { Content = "   " };

        var result = await generator.PostAsync(post);

        Assert.False(result);
        _mockSender.Verify(s => s.SendAsync(It.IsAny<Post>()), Times.Never);
    }

    [Fact]
    public async Task PostAsync_ReturnsFalse_When_Sender_IsNull()
    {
        var generator = new TestGenerator(null, _mockLogger.Object, sendIt: true);
        var post = new Post { Content = "Hello" };

        var result = await generator.PostAsync(post);

        Assert.False(result);
    }

    [Fact]
    public async Task PostAsync_ReturnsTrue_When_AllConditionsMet()
    {
        _mockSender.Setup(s => s.SendAsync(It.IsAny<Post>())).ReturnsAsync(true);
        var generator = new TestGenerator(_mockSender.Object, _mockLogger.Object, sendIt: true);
        var post = new Post { Content = "Hello" };

        var result = await generator.PostAsync(post);

        Assert.True(result);
        _mockSender.Verify(s => s.SendAsync(post), Times.Once);
    }

    [Fact]
    public async Task PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull()
    {
        _mockSender.Setup(s => s.SendAsync(It.IsAny<Post>())).ReturnsAsync(true);
        var generator = new TestGenerator(_mockSender.Object, _mockLogger.Object, sendIt: true, produceImage: true);
        var post = new Post { Content = "Hello", Image = null };

        var result = await generator.PostAsync(post);

        // Should still send (warning does not block posting)
        Assert.True(result);
        _mockLogger.Verify(
            l => l.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("no image was generated")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent()
    {
        _mockSender.Setup(s => s.SendAsync(It.IsAny<Post>())).ReturnsAsync(true);
        var generator = new TestGenerator(_mockSender.Object, _mockLogger.Object, sendIt: true, produceImage: true);
        var post = new Post { Content = "Hello", Image = new byte[] { 1, 2, 3 } };

        var result = await generator.PostAsync(post);

        Assert.True(result);
        _mockLogger.Verify(
            l => l.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Never);
    }

    [Fact]
    public async Task PostAsync_ReturnsFalse_When_Sender_ReturnsFalse()
    {
        _mockSender.Setup(s => s.SendAsync(It.IsAny<Post>())).ReturnsAsync(false);
        var generator = new TestGenerator(_mockSender.Object, _mockLogger.Object, sendIt: true);
        var post = new Post { Content = "Hello" };

        var result = await generator.PostAsync(post);

        Assert.False(result);
    }
}
