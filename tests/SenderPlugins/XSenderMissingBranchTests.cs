using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Credentials;
using XPoster.Models;
using XPoster.SenderPlugins;

namespace XPoster.Tests.SenderPlugins;

/// <summary>
/// Additional XSender tests targeting uncovered branches.
/// TwitterContext is sealed and cannot be mocked — tests exercise the guards
/// and exception-catch paths only (no real Twitter API calls).
/// </summary>
public class XSenderMissingBranchTests
{
    private readonly Mock<ILogger<XSender>> _logger = new();
    private readonly IOptions<XCredentials> _creds = Options.Create(new XCredentials
    {
        XApiKey = "key",
        XApiSecret = "secret",
        XAccessToken = "token",
        XAccessTokenSecret = "token_secret"
    });

    private XSender BuildSender() => new(_creds, _logger.Object);

    [Fact]
    public async Task SendAsync_NullPost_ReturnsFalse()
    {
        Assert.False(await BuildSender().SendAsync(null!));
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
    public void MessageMaxLenght_Returns250()
    {
        Assert.Equal(250, BuildSender().MessageMaxLenght);
    }
}
