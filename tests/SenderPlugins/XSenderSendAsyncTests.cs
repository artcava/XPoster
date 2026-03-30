using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Models;
using XPoster.SenderPlugins;

namespace XPoster.Tests.SenderPlugins;

/// <summary>
/// Tests for XSender.SendAsync input-validation branches.
/// Network calls (Twitter API) are not exercised — only the guards
/// that execute before any I/O are tested here.
/// </summary>
public class XSenderSendAsyncTests
{
    private readonly Mock<ILogger<XSender>> _mockLogger;
    private readonly XSender _sender;

    public XSenderSendAsyncTests()
    {
        _mockLogger = new Mock<ILogger<XSender>>();
        Environment.SetEnvironmentVariable("X_API_KEY", "fake_key");
        Environment.SetEnvironmentVariable("X_API_SECRET", "fake_secret");
        Environment.SetEnvironmentVariable("X_ACCESS_TOKEN", "fake_token");
        Environment.SetEnvironmentVariable("X_ACCESS_TOKEN_SECRET", "fake_token_secret");
        _sender = new XSender(_mockLogger.Object);
    }

    [Fact]
    public async Task SendAsync_WithNullPost_ReturnsFalse()
    {
        var result = await _sender.SendAsync(null!);
        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WithEmptyContent_ReturnsFalse()
    {
        var post = new Post { Content = string.Empty };
        var result = await _sender.SendAsync(post);
        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WithWhiteSpaceContent_ReturnsFalse()
    {
        var post = new Post { Content = "   " };
        var result = await _sender.SendAsync(post);
        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse()
    {
        // Twitter API will throw because credentials are fake — the catch block returns false
        var post = new Post { Content = "Valid content" };
        var result = await _sender.SendAsync(post);
        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse()
    {
        var post = new Post { Content = "Valid content", Image = new byte[] { 1, 2, 3 } };
        var result = await _sender.SendAsync(post);
        Assert.False(result);
    }
}
