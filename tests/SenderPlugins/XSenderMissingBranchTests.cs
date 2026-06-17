using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Abstraction;
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
    private readonly Mock<IKeyVaultService> _kv = new();

    public XSenderMissingBranchTests()
    {
        _kv.Setup(s => s.GetSecretAsync("XApiKey")).ReturnsAsync("key");
        _kv.Setup(s => s.GetSecretAsync("XApiSecret")).ReturnsAsync("secret");
        _kv.Setup(s => s.GetSecretAsync("XAccessToken")).ReturnsAsync("token");
        _kv.Setup(s => s.GetSecretAsync("XAccessTokenSecret")).ReturnsAsync("token_secret");
    }

    private XSender BuildSender() => new(_kv.Object, _logger.Object);

    [Fact]
    public async Task SendAsync_NullPost_ReturnsFalse()
    {
        var result = await BuildSender().SendAsync(null!);
        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_EmptyContent_ReturnsFalse()
    {
        var result = await BuildSender().SendAsync(new Post { Content = string.Empty });
        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WhitespaceContent_ReturnsFalse()
    {
        var result = await BuildSender().SendAsync(new Post { Content = "   " });
        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse()
    {
        // No real Twitter credentials — TwitterContext.TweetAsync throws -> catch -> false
        var result = await BuildSender().SendAsync(new Post { Content = "Hello world" });
        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse()
    {
        var result = await BuildSender().SendAsync(new Post
        {
            Content = "Hello with image",
            Image = new byte[] { 1, 2, 3 }
        });
        Assert.False(result);
    }

    [Fact]
    public void MessageMaxLenght_Returns250()
    {
        Assert.Equal(250, BuildSender().MessageMaxLenght);
    }
}
