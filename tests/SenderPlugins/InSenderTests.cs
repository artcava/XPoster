using Microsoft.Extensions.Http;
using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Abstraction;
using XPoster.Models;
using XPoster.SenderPlugins;

namespace XPoster.Tests.SenderPlugins;

public class InSenderTests
{
    private readonly Mock<ILogger<InSender>> _mockLogger;
    private readonly Mock<IHttpClientFactory> _mockFactory;

    public InSenderTests()
    {
        _mockLogger = new Mock<ILogger<InSender>>();
        _mockFactory = new Mock<IHttpClientFactory>();
        _mockFactory.Setup(f => f.CreateClient("LinkedIn")).Returns(new HttpClient());
        Environment.SetEnvironmentVariable("IN_ACCESS_TOKEN", "test_token_12345");
        Environment.SetEnvironmentVariable("IN_OWNER", "123456789");
    }

    #region Constructor and Properties Tests

    [Fact]
    public void Constructor_InitializesCorrectly()
    {
        var sender = new InSender(_mockFactory.Object, _mockLogger.Object);
        Assert.NotNull(sender);
        Assert.Equal(800, sender.MessageMaxLenght);
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new InSender(_mockFactory.Object, null!));
    }

    [Fact]
    public void InSender_ImplementsISender()
    {
        var sender = new InSender(_mockFactory.Object, _mockLogger.Object);
        Assert.IsAssignableFrom<ISender>(sender);
    }

    #endregion

    #region SendAsync with Content Validation Tests

    [Fact]
    public async Task SendAsync_WithNullPost_ReturnsFalseAndLogsWarning()
    {
        var sender = new InSender(_mockFactory.Object, _mockLogger.Object);
        Post? post = null;

        var result = await sender.SendAsync(post!);

        Assert.False(result);
        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("null")),
                It.IsAny<Exception?>(),
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
            var sender = new InSender(_mockFactory.Object, _mockLogger.Object);
            Assert.NotNull(sender);
        }
        catch (Exception ex)
        {
            Assert.True(ex.Message.Contains("token", StringComparison.OrdinalIgnoreCase) || ex is ArgumentNullException || ex is InvalidOperationException);
        }
    }

    #endregion
}
