using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Contracts;
using XPoster.Models;
using XPoster.SenderPlugins;

namespace XPoster.Tests.SenderPlugins;

public class DryRunSenderTests
{
    private readonly Mock<ILogger<DryRunSender>> _mockLogger;
    private readonly Mock<IKeyVaultService> _mockKv;

    public DryRunSenderTests()
    {
        _mockLogger = new Mock<ILogger<DryRunSender>>();
        _mockKv = new Mock<IKeyVaultService>();
    }

    private DryRunSender BuildSender() => new(_mockKv.Object, _mockLogger.Object);

    private static Post ValidPost(string content = "Test dry-run content") =>
        new() { Content = content };

    #region Constructor Tests

    [Fact]
    public void Constructor_WithNullKeyVaultService_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new DryRunSender(null!, _mockLogger.Object));
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new DryRunSender(_mockKv.Object, null!));
    }

    [Fact]
    public void DryRunSender_ImplementsISender()
    {
        Assert.IsAssignableFrom<ISender>(BuildSender());
    }

    [Fact]
    public void MessageMaxLenght_ReturnsIntMaxValue()
    {
        Assert.Equal(int.MaxValue, BuildSender().MessageMaxLenght);
    }

    #endregion

    #region SendAsync – null post guard

    [Fact]
    public async Task SendAsync_WithNullPost_ReturnsFalse()
    {
        var sender = BuildSender();

        var result = await sender.SendAsync(null!);

        Assert.False(result);
        _mockKv.Verify(k => k.GetSecretAsync(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public async Task SendAsync_WithNullPost_LogsWarning()
    {
        var sender = BuildSender();

        await sender.SendAsync(null!);

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

    #region SendAsync – successful dry run

    [Fact]
    public async Task SendAsync_WhenKeyVaultProbeSucceeds_ReturnsTrue()
    {
        _mockKv.Setup(k => k.GetSecretAsync("XApiKey")).ReturnsAsync("fake-api-key");
        var sender = BuildSender();

        var result = await sender.SendAsync(ValidPost());

        Assert.True(result);
    }

    [Fact]
    public async Task SendAsync_WhenKeyVaultProbeSucceeds_ProbesXApiKey()
    {
        _mockKv.Setup(k => k.GetSecretAsync("XApiKey")).ReturnsAsync("fake-api-key");
        var sender = BuildSender();

        await sender.SendAsync(ValidPost());

        _mockKv.Verify(k => k.GetSecretAsync("XApiKey"), Times.Once);
    }

    [Fact]
    public async Task SendAsync_WhenKeyVaultProbeSucceeds_LogsPostContent()
    {
        _mockKv.Setup(k => k.GetSecretAsync("XApiKey")).ReturnsAsync("fake-api-key");
        var sender = BuildSender();
        var post = ValidPost("Hello dry-run world");

        await sender.SendAsync(post);

        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("Hello dry-run world")),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()
            ), Times.AtLeastOnce);
    }

    [Fact]
    public async Task SendAsync_WithImageBytes_LogsImagePresence()
    {
        _mockKv.Setup(k => k.GetSecretAsync("XApiKey")).ReturnsAsync("fake-api-key");
        var sender = BuildSender();
        var post = ValidPost();
        post.Image = new byte[] { 0x01, 0x02, 0x03 };

        var result = await sender.SendAsync(post);

        Assert.True(result);
        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("True")),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()
            ), Times.AtLeastOnce);
    }

    [Fact]
    public async Task SendAsync_DoesNotCallAnyOutboundSocialApi()
    {
        _mockKv.Setup(k => k.GetSecretAsync("XApiKey")).ReturnsAsync("fake-api-key");
        var sender = BuildSender();

        // Only one KV call (the probe) must happen — no additional calls for social credentials
        await sender.SendAsync(ValidPost());

        _mockKv.Verify(k => k.GetSecretAsync(It.IsAny<string>()), Times.Once);
    }

    #endregion

    #region SendAsync – Key Vault failure path

    [Fact]
    public async Task SendAsync_WhenKeyVaultProbeThrows_ReturnsFalse()
    {
        _mockKv.Setup(k => k.GetSecretAsync("XApiKey"))
               .ThrowsAsync(new InvalidOperationException("vault unreachable"));
        var sender = BuildSender();

        var result = await sender.SendAsync(ValidPost());

        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WhenKeyVaultProbeThrows_LogsError()
    {
        _mockKv.Setup(k => k.GetSecretAsync("XApiKey"))
               .ThrowsAsync(new InvalidOperationException("vault unreachable"));
        var sender = BuildSender();

        await sender.SendAsync(ValidPost());

        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("XApiKey")),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()
            ), Times.Once);
    }

    #endregion
}
