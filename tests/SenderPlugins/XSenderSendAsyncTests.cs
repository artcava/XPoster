using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Credentials;
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
        var creds = Options.Create(new XCredentials
        {
            XApiKey = "fake_key",
            XApiSecret = "fake_secret",
            XAccessToken = "fake_token",
            XAccessTokenSecret = "fake_token_secret"
        });
        _sender = new XSender(creds, _mockLogger.Object);
    }

    [Fact]
    public async Task SendAsync_WithNullPost_ReturnsFalse()
    {
        Assert.False(await _sender.SendAsync(null!));
    }

    [Fact]
    public async Task SendAsync_WithEmptyContent_ReturnsFalse()
    {
        Assert.False(await _sender.SendAsync(new Post { Content = string.Empty }));
    }

    [Fact]
    public async Task SendAsync_WithWhiteSpaceContent_ReturnsFalse()
    {
        Assert.False(await _sender.SendAsync(new Post { Content = "   " }));
    }

    [Fact]
    public async Task SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse()
    {
        Assert.False(await _sender.SendAsync(new Post { Content = "Valid content" }));
    }

    [Fact]
    public async Task SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse()
    {
        Assert.False(await _sender.SendAsync(new Post { Content = "Valid content", Image = new byte[] { 1, 2, 3 } }));
    }
}
