using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Abstraction;
using XPoster.Models;
using XPoster.SenderPlugins;

namespace XPoster.Tests.SenderPlugins;

public class XSenderTests
{
    private readonly Mock<ILogger<XSender>> _mockLogger;
    private readonly Mock<IKeyVaultService> _mockKv;

    public XSenderTests()
    {
        _mockLogger = new Mock<ILogger<XSender>>();
        _mockKv = BuildKeyVaultMock();
    }

    private static Mock<IKeyVaultService> BuildKeyVaultMock()
    {
        var kv = new Mock<IKeyVaultService>();
        kv.Setup(s => s.GetSecretAsync("XApiKey")).ReturnsAsync("fake_key");
        kv.Setup(s => s.GetSecretAsync("XApiSecret")).ReturnsAsync("fake_secret");
        kv.Setup(s => s.GetSecretAsync("XAccessToken")).ReturnsAsync("fake_token");
        kv.Setup(s => s.GetSecretAsync("XAccessTokenSecret")).ReturnsAsync("fake_token_secret");
        return kv;
    }

    #region Constructor and Properties Tests

    [Fact]
    public void Constructor_InitializesCorrectly()
    {
        var sender = new XSender(_mockKv.Object, _mockLogger.Object);
        Assert.NotNull(sender);
        Assert.Equal(250, sender.MessageMaxLenght);
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new XSender(_mockKv.Object, null!));
    }

    [Fact]
    public void XSender_ImplementsISender()
    {
        var sender = new XSender(_mockKv.Object, _mockLogger.Object);
        Assert.IsAssignableFrom<ISender>(sender);
    }

    #endregion

    #region SendAsync with Content Validation Tests

    [Fact]
    public async Task SendAsync_WithNullPost_ReturnsFalseAndLogsWarning()
    {
        var sender = new XSender(_mockKv.Object, _mockLogger.Object);
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

    #region Credential resolution Tests

    [Fact]
    public void Constructor_WithNullKeyVaultService_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new XSender(null!, _mockLogger.Object));
    }

    #endregion
}
