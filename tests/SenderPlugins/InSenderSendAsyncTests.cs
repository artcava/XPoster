using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Credentials;
using XPoster.Models;
using XPoster.SenderPlugins;

namespace XPoster.Tests.SenderPlugins;

/// <summary>
/// Tests for InSender.SendAsync input-validation branches.
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
        var creds = Options.Create(new LinkedInCredentials
        {
            LinkedInAccessToken = "fake_token",
            LinkedInOwnerCode = "fake_owner",
            LinkedInOrgId = string.Empty
        });
        _sender = new InSender(_mockFactory.Object, creds, _mockLogger.Object);
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
    public async Task SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse()
    {
        Assert.False(await _sender.SendAsync(new Post { Content = "Valid content" }));
    }
}
