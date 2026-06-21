using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using XPoster.Contracts;
using XPoster.Models;
using XPoster.Options;
using XPoster.SenderPlugins;

namespace XPoster.Tests.SenderPlugins;

public class XSenderTests
{
    private readonly Mock<ILogger<XSender>> _mockLogger;
    private readonly IOptions<XCredentials> _credentials;

    public XSenderTests()
    {
        _mockLogger = new Mock<ILogger<XSender>>();
        _credentials = Options.Create(new XCredentials
        {
            XApiKey = "fake_key",
            XApiSecret = "fake_secret",
            XAccessToken = "fake_token",
            XAccessTokenSecret = "fake_token_secret"
        });
    }

    #region Constructor and Properties Tests

    [Fact]
    public void Constructor_InitializesCorrectly()
    {
        var sender = new XSender(_credentials, _mockLogger.Object);
        Assert.NotNull(sender);
        Assert.Equal(250, sender.MessageMaxLenght);
    }

    [Fact]
    public void Constructor_WithNullCredentials_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new XSender(null!, _mockLogger.Object));
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new XSender(_credentials, null!));
    }

    [Fact]
    public void XSender_ImplementsISender()
    {
        Assert.IsAssignableFrom<ISender>(new XSender(_credentials, _mockLogger.Object));
    }

    #endregion

    #region SendAsync Guard Tests

    [Fact]
    public async Task SendAsync_WithNullPost_ReturnsFalseAndLogsWarning()
    {
        var sender = new XSender(_credentials, _mockLogger.Object);

        var result = await sender.SendAsync(null!);

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

    [Fact]
    public async Task SendAsync_ValidPost_TriesTwitterAndReturnsFalse()
    {
        // Fake credentials cause TwitterContext to throw — caught internally.
        var sender = new XSender(_credentials, _mockLogger.Object);
        var result = await sender.SendAsync(new Post { Content = "Hello world" });
        Assert.False(result);
    }

    #endregion
}
