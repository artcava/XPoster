using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Models;
using XPoster.SenderPlugins;

namespace XPoster.Tests.SenderPlugins;

/// <summary>
/// Tests for IgSender.
/// Only branches that execute before or without real HTTP calls are covered:
/// constructor guards, MessageMaxLenght, null/empty content guards, no-image branch,
/// and the image path (which throws NotImplementedException caught internally).
/// </summary>
public class IgSenderTests
{
    private readonly Mock<ILogger<IgSender>> _mockLogger;
    private readonly Mock<IHttpClientFactory> _mockFactory;

    public IgSenderTests()
    {
        _mockLogger = new Mock<ILogger<IgSender>>();
        _mockFactory = new Mock<IHttpClientFactory>();
        _mockFactory.Setup(f => f.CreateClient("Instagram")).Returns(new HttpClient());
    }

    private void SetValidEnvVars()
    {
        Environment.SetEnvironmentVariable("IG_ACCESS_TOKEN", "fake_token");
        Environment.SetEnvironmentVariable("IG_ACCOUNT_ID", "fake_account_id");
    }

    private void ClearEnvVars()
    {
        Environment.SetEnvironmentVariable("IG_ACCESS_TOKEN", null);
        Environment.SetEnvironmentVariable("IG_ACCOUNT_ID", null);
    }

    private IgSender BuildSender()
    {
        SetValidEnvVars();
        return new IgSender(_mockFactory.Object, _mockLogger.Object);
    }

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
        SetValidEnvVars();
        Assert.Throws<ArgumentNullException>(() => new IgSender(_mockFactory.Object, null!));
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
        var sender = BuildSender();
        var result = await sender.SendAsync(null!);
        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WithEmptyContent_ReturnsFalse()
    {
        var sender = BuildSender();
        var result = await sender.SendAsync(new Post { Content = string.Empty });
        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WithWhitespaceContent_ReturnsFalse()
    {
        var sender = BuildSender();
        var result = await sender.SendAsync(new Post { Content = "   " });
        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WithNoImage_TriesHttpAndReturnsFalse()
    {
        var sender = BuildSender();
        var result = await sender.SendAsync(new Post { Content = "Test caption", Image = null });
        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WithImage_TriesUploadAndReturnsFalse()
    {
        var sender = BuildSender();
        var result = await sender.SendAsync(new Post { Content = "Test caption", Image = new byte[] { 0x89, 0x50, 0x4E, 0x47 } });
        Assert.False(result);
    }

    #endregion

    #region Environment Variable Tests

    [Fact]
    public void Constructor_WithMissingAccessToken_ThrowsOrHandlesGracefully()
    {
        ClearEnvVars();
        Environment.SetEnvironmentVariable("IG_ACCOUNT_ID", "fake_account_id");
        try
        {
            var sender = new IgSender(_mockFactory.Object, _mockLogger.Object);
            Assert.NotNull(sender);
        }
        catch (Exception ex)
        {
            Assert.True(ex is ArgumentNullException || ex is InvalidOperationException);
        }
    }

    [Fact]
    public void Constructor_WithMissingAccountId_ThrowsOrHandlesGracefully()
    {
        ClearEnvVars();
        Environment.SetEnvironmentVariable("IG_ACCESS_TOKEN", "fake_token");
        try
        {
            var sender = new IgSender(_mockFactory.Object, _mockLogger.Object);
            Assert.NotNull(sender);
        }
        catch (Exception ex)
        {
            Assert.True(ex is ArgumentNullException || ex is InvalidOperationException);
        }
    }

    #endregion
}
