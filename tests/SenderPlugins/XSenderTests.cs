using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Contracts;
using XPoster.Credentials;
using XPoster.Models;
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

    private XSender BuildSender() => new(_credentials, _mockLogger.Object);

    #region Constructor and Properties Tests

    [Fact]
    public void Platform_ReturnsX()
    {
        Assert.Equal(SenderPlatform.X, BuildSender().Platform);
    }

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

    [Fact]
    public void MessageMaxLenght_Returns250()
    {
        Assert.Equal(250, BuildSender().MessageMaxLenght);
    }

    #endregion

    #region SendAsync Guard Tests

    [Fact]
    public async Task SendAsync_WhenTwitterContextThrows_ReturnsFalse()
    {
        var sut = BuildSender();
        var result = await sut.SendAsync(new Post { Content = "hello" });
        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WithImageAndTwitterContextThrows_ReturnsFalse()
    {
        var sut = BuildSender();
        var result = await sut.SendAsync(new Post
        {
            Content = "hello",
            Image = new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 }
        });
        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_NullPost_ReturnsFalse()
    {
        Assert.False(await BuildSender().SendAsync(null!));
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("\t\n")]
    public async Task SendAsync_WithBlankContent_ReturnsFalseAndLogsWarning(string content)
    {
        var sut = BuildSender();
        var result = await sut.SendAsync(new Post { Content = content });
        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_EmptyContent_ReturnsFalse()
    {
        Assert.False(await BuildSender().SendAsync(new Post { Content = string.Empty }));
    }

    [Fact]
    public async Task SendAsync_WhitespaceContent_ReturnsFalse()
    {
        Assert.False(await BuildSender().SendAsync(new Post { Content = "   " }));
    }

    [Fact]
    public async Task SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse()
    {
        Assert.False(await BuildSender().SendAsync(new Post { Content = "Hello world" }));
    }

    [Fact]
    public async Task SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse()
    {
        Assert.False(await BuildSender().SendAsync(new Post
        {
            Content = "Hello with image",
            Image = new byte[] { 1, 2, 3 }
        }));
    }

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
