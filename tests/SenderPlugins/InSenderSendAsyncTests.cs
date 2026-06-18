using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Contracts;
using XPoster.Models;
using XPoster.SenderPlugins;

namespace XPoster.Tests.SenderPlugins;

/// <summary>
/// Tests for InSender.SendAsync input-validation branches and generatePayLoad paths.
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
        var kv = new Mock<IKeyVaultService>();
        kv.Setup(s => s.GetSecretAsync("LinkedInAccessToken")).ReturnsAsync("fake_token");
        kv.Setup(s => s.GetSecretAsync("LinkedInOwnerCode")).ReturnsAsync("fake_owner");
        kv.Setup(s => s.GetSecretAsync("LinkedInOrgId"))
            .ThrowsAsync(new Azure.RequestFailedException("not found"));
        _sender = new InSender(_mockFactory.Object, kv.Object, _mockLogger.Object);
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
    public async Task SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse()
    {
        var post = new Post { Content = "Valid content" };
        var result = await _sender.SendAsync(post);
        Assert.False(result);
    }
}
