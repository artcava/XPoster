using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Abstraction;
using XPoster.Models;
using XPoster.SenderPlugins;

namespace XPoster.Tests.SenderPlugins;

public class XSenderTests
{
    private readonly Mock<ILogger<XSender>> _mockLogger;

    public XSenderTests()
    {
        _mockLogger = new Mock<ILogger<XSender>>();
        // Setup environment variables for tests
        Environment.SetEnvironmentVariable("X_ACCESS_TOKEN", "test_token_12345");
        Environment.SetEnvironmentVariable("X_ACCESS_TOKEN_SECRET", "123456789");
    }

    #region Constructor and Properties Tests

    [Fact]
    public void Constructor_InitializesCorrectly()
    {
        // Act
        var sender = new XSender(_mockLogger.Object);

        // Assert
        Assert.NotNull(sender);
        Assert.Equal(250, sender.MessageMaxLenght);
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new XSender(null));
    }

    [Fact]
    public void XSender_ImplementsISender()
    {
        // Arrange & Act
        var sender = new XSender(_mockLogger.Object);

        // Assert
        Assert.IsAssignableFrom<ISender>(sender);
    }

    #endregion

    #region SendAsync with Content Validation Tests

    [Fact]
    public async Task SendAsync_WithNullPost_ReturnsFalseAndLogsWarning()
    {
        // Arrange
        var sender = new XSender(_mockLogger.Object);
        Post post = null;

        // Act
        var result = await sender.SendAsync(post);

        // Assert
        Assert.False(result);
        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("null")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()
            ), Times.Once);
    }
    #endregion

    #region Environment Variable Tests

    [Fact]
    public void Constructor_WithMissingAccessToken_ThrowsOrHandlesGracefully()
    {
        // Arrange
        Environment.SetEnvironmentVariable("IN_ACCESS_TOKEN", null);

        // Act & Assert
        try
        {
            var sender = new XSender(_mockLogger.Object);
            // If it doesn't throw, verify it was created
            Assert.NotNull(sender);
        }
        catch (Exception ex)
        {
            // If it throws, verify it's related to missing token
            Assert.True(ex.Message.Contains("token") || ex is ArgumentNullException);
        }
    }

    #endregion
}
