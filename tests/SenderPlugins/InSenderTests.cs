using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Abstraction;
using XPoster.Models;
using XPoster.SenderPlugins;

namespace XPoster.Tests.SenderPlugins;

public class InSenderTests
{
    private readonly Mock<ILogger<InSender>> _mockLogger;

    public InSenderTests()
    {
        _mockLogger = new Mock<ILogger<InSender>>();
        Environment.SetEnvironmentVariable("IN_ACCESS_TOKEN", "test_token_12345");
        Environment.SetEnvironmentVariable("IN_OWNER", "123456789");
    }

    #region Constructor and Properties Tests

    [Fact]
    public void Constructor_InitializesCorrectly()
    {
        var sender = new InSender(_mockLogger.Object);
        Assert.NotNull(sender);
        Assert.Equal(800, sender.MessageMaxLenght);
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        // CS8625: passing null intentionally to test null-guard — suppress with null!
        Assert.Throws<ArgumentNullException>(() => new InSender(null!));
    }

    [Fact]
    public void InSender_ImplementsISender()
    {
        var sender = new InSender(_mockLogger.Object);
        Assert.IsAssignableFrom<ISender>(sender);
    }

    #endregion

    #region SendAsync with Content Validation Tests

    [Fact]
    public async Task SendAsync_WithNullPost_ReturnsFalseAndLogsWarning()
    {
        // Arrange
        var sender = new InSender(_mockLogger.Object);
        // CS8600: null intentional — testing null guard in SendAsync
        Post? post = null;

        // Act
        // CS8604: passing null! intentionally to test null-guard behaviour
        var result = await sender.SendAsync(post!);

        // Assert
        Assert.False(result);
        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("null")),
                It.IsAny<Exception?>(),
                // CS8620: formatter param is Func<..., Exception?, string> — aligned
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()
            ), Times.Once);
    }

    #endregion

    #region Environment Variable Tests

    [Fact]
    public void Constructor_WithMissingAccessToken_ThrowsOrHandlesGracefully()
    {
        Environment.SetEnvironmentVariable("IN_ACCESS_TOKEN", null);
        try
        {
            var sender = new InSender(_mockLogger.Object);
            Assert.NotNull(sender);
        }
        catch (Exception ex)
        {
            Assert.True(ex.Message.Contains("token", StringComparison.OrdinalIgnoreCase) || ex is ArgumentNullException || ex is InvalidOperationException);
        }
    }

    #endregion
}
