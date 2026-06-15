using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Abstraction;
using XPoster.Models;
using XPoster.SenderPlugins;

namespace XPoster.Tests.SenderPlugins;

/// <summary>
/// Tests for IgSender.
/// Only branches that execute before or without real HTTP calls are covered:
/// constructor guards, MessageMaxLenght, null/empty content guards, no-image branch,
/// and the image path (which throws on the Instagram API — caught internally).
/// </summary>
public class IgSenderTests
{
    private readonly Mock<ILogger<IgSender>> _mockLogger;
    private readonly Mock<IHttpClientFactory> _mockFactory;
    private readonly Mock<IKeyVaultService> _mockKv;

    public IgSenderTests()
    {
        _mockLogger = new Mock<ILogger<IgSender>>();
        _mockFactory = new Mock<IHttpClientFactory>();
        _mockFactory.Setup(f => f.CreateClient("Instagram")).Returns(new HttpClient());
        _mockKv = new Mock<IKeyVaultService>();
        _mockKv.Setup(s => s.GetSecretAsync("IgAccessToken")).ReturnsAsync("fake_token");
        _mockKv.Setup(s => s.GetSecretAsync("IgAccountId")).ReturnsAsync("fake_account_id");
    }

    private IgSender BuildSender() =>
        new(_mockFactory.Object, _mockKv.Object, _mockLogger.Object);

    #region Constructor Tests

    [Fact]
    public void Constructor_InitializesCorrectly()
    {
        var sender = BuildSender();
        Assert.NotNull(sender);
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new IgSender(_mockFactory.Object, _mockKv.Object, null!));
    }

    [Fact]
    public void Constructor_WithNullKeyVaultService_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new IgSender(_mockFactory.Object, null!, _mockLogger.Object));
    }

    [Fact]
    public void MessageMaxLenght_Returns2200()
    {
        var sender = BuildSender();
        Assert.Equal(2200, sender.MessageMaxLenght);
    }

    #endregion

    #region SendAsync Guard Tests

    [Fact]
    public async Task SendAsync_WithNullPost_ReturnsFalse()
    {
        var result = await BuildSender().SendAsync(null!);
        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WithEmptyContent_ReturnsFalse()
    {
        var result = await BuildSender().SendAsync(new Post { Content = string.Empty });
        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WithWhitespaceContent_ReturnsFalse()
    {
        var result = await BuildSender().SendAsync(new Post { Content = "   " });
        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WithNoImage_ReturnsFalse()
    {
        var result = await BuildSender().SendAsync(new Post { Content = "Test caption", Image = null });
        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WithImage_TriesUploadAndReturnsFalse()
    {
        var result = await BuildSender().SendAsync(new Post
        {
            Content = "Test caption",
            Image = new byte[] { 0x89, 0x50, 0x4E, 0x47 }
        });
        Assert.False(result);
    }

    #endregion

    #region Credential resolution Tests (GAP-4)

    /// <summary>
    /// GAP-4: verifies that IgAccessToken is read from KV by its canonical name
    /// when a post with an image is submitted (the only path that reaches KV in IgSender).
    /// </summary>
    [Fact]
    public async Task SendAsync_WithImage_ReadsIgAccessTokenFromKv()
    {
        await BuildSender().SendAsync(new Post
        {
            Content = "caption",
            Image = new byte[] { 1, 2, 3 }
        });

        _mockKv.Verify(s => s.GetSecretAsync("IgAccessToken"), Times.AtLeastOnce);
    }

    /// <summary>
    /// GAP-4: verifies that IgAccountId is read from KV by its canonical name.
    /// </summary>
    [Fact]
    public async Task SendAsync_WithImage_ReadsIgAccountIdFromKv()
    {
        await BuildSender().SendAsync(new Post
        {
            Content = "caption",
            Image = new byte[] { 1, 2, 3 }
        });

        _mockKv.Verify(s => s.GetSecretAsync("IgAccountId"), Times.AtLeastOnce);
    }

    /// <summary>
    /// GAP-4 (inverse): when no image is present, IgSender returns false early
    /// and must NOT query Key Vault at all.
    /// </summary>
    [Fact]
    public async Task SendAsync_WithoutImage_DoesNotQueryKv()
    {
        await BuildSender().SendAsync(new Post { Content = "text only" });

        _mockKv.Verify(s => s.GetSecretAsync(It.IsAny<string>()), Times.Never);
    }

    #endregion
}
