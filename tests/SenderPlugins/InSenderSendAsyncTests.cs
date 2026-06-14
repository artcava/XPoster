using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Models;
using XPoster.SenderPlugins;

namespace XPoster.Tests.SenderPlugins;

/// <summary>
/// Tests for InSender.SendAsync input-validation branches and generatePayLoad paths.
/// HTTP calls to LinkedIn API are not exercised — only guards and the text-only
/// payload branch (which falls through to a network call that returns false via catch)
/// are tested here.
/// </summary>
public class InSenderSendAsyncTests
{
    private readonly Mock<ILogger<InSender>> _mockLogger;
    private readonly Mock<IHttpClientFactory> _mockFactory;
    private readonly InSender _sender;

    public InSenderSendAsyncTests()
    {
        _mockLogger = new Mock<ILogger<InSender>>();
        _mockFactory = new Mock<IHttpClientFactory>();
        _mockFactory.Setup(f => f.CreateClient("LinkedIn")).Returns(new HttpClient());
        Environment.SetEnvironmentVariable("IN_ACCESS_TOKEN", "fake_token");
        Environment.SetEnvironmentVariable("IN_OWNER", "fake_owner");
        _sender = new InSender(_mockFactory.Object, _mockLogger.Object);
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
    public async Task SendAsync_WithValidTextOnlyPost_CatchesNetworkException_ReturnsFalse()
    {
        var post = new Post { Content = "Valid LinkedIn post" };
        var result = await _sender.SendAsync(post);
        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WithMissingOwner_ReturnsFalse()
    {
        Environment.SetEnvironmentVariable("IN_OWNER", null);
        var post = new Post { Content = "Valid post" };
        var result = await _sender.SendAsync(post);
        Assert.False(result);
    }
}
