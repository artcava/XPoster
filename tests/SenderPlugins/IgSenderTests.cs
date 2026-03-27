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

    public IgSenderTests()
    {
        _mockLogger = new Mock<ILogger<IgSender>>();
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

    // ── Constructor ─────────────────────────────────────────────────────────

    [Fact]
    public void Constructor_WithValidEnvVars_Succeeds()
    {
        SetValidEnvVars();
        var sender = new IgSender(_mockLogger.Object);
        Assert.NotNull(sender);
        Assert.Equal(2200, sender.MessageMaxLenght);
    }

    [Fact]
    public void Constructor_WithMissingAccessToken_ThrowsInvalidOperationException()
    {
        ClearEnvVars();
        Assert.Throws<InvalidOperationException>(() => new IgSender(_mockLogger.Object));
    }

    [Fact]
    public void Constructor_WithMissingAccountId_ThrowsInvalidOperationException()
    {
        Environment.SetEnvironmentVariable("IG_ACCESS_TOKEN", "fake_token");
        Environment.SetEnvironmentVariable("IG_ACCOUNT_ID", null);
        Assert.Throws<InvalidOperationException>(() => new IgSender(_mockLogger.Object));
    }

    // ── SendAsync ──────────────────────────────────────────────────────────

    [Fact]
    public async Task SendAsync_WithNoImage_ReturnsFalse()
    {
        SetValidEnvVars();
        var sender = new IgSender(_mockLogger.Object);
        var post = new Post { Content = "Text only post" };

        var result = await sender.SendAsync(post);

        // Instagram requires an image — the else branch logs warning and returns false
        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WithEmptyImageArray_ReturnsFalse()
    {
        SetValidEnvVars();
        var sender = new IgSender(_mockLogger.Object);
        var post = new Post { Content = "Text only", Image = Array.Empty<byte>() };

        var result = await sender.SendAsync(post);

        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WithImage_CatchesNotImplementedException_ReturnsFalse()
    {
        SetValidEnvVars();
        var sender = new IgSender(_mockLogger.Object);
        // UploadImageToPublicUrl throws NotImplementedException — caught by outer try/catch → false
        var post = new Post { Content = "Post with image", Image = new byte[] { 1, 2, 3 } };

        var result = await sender.SendAsync(post);

        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WithOversizedCaption_StillExecutes()
    {
        SetValidEnvVars();
        var sender = new IgSender(_mockLogger.Object);
        // Caption longer than 2200 chars — exercises the truncation branch before the image check
        var post = new Post
        {
            Content = new string('A', 2300),
            Image = new byte[] { 1, 2, 3 }
        };

        // Will still hit UploadImageToPublicUrl → NotImplementedException → catch → false
        var result = await sender.SendAsync(post);
        Assert.False(result);
    }
}
