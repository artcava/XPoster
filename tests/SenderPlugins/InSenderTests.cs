using Microsoft.Extensions.Http;
using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Abstraction;
using XPoster.Models;
using XPoster.SenderPlugins;

namespace XPoster.Tests.SenderPlugins;

public class InSenderTests
{
    private readonly Mock<ILogger<InSender>> _mockLogger;
    private readonly Mock<IHttpClientFactory> _mockFactory;
    private readonly Mock<IKeyVaultService> _mockKv;

    public InSenderTests()
    {
        _mockLogger = new Mock<ILogger<InSender>>();
        _mockFactory = new Mock<IHttpClientFactory>();
        _mockFactory.Setup(f => f.CreateClient("LinkedIn")).Returns(new HttpClient());
        _mockKv = BuildKeyVaultMock();
    }

    private static Mock<IKeyVaultService> BuildKeyVaultMock()
    {
        var kv = new Mock<IKeyVaultService>();
        kv.Setup(s => s.GetSecretAsync("LinkedInAccessToken")).ReturnsAsync("test_token_12345");
        kv.Setup(s => s.GetSecretAsync("LinkedInOwnerCode")).ReturnsAsync("123456789");
        kv.Setup(s => s.GetSecretAsync("LinkedInOrgId"))
            .ThrowsAsync(new Azure.RequestFailedException("not found"));
        return kv;
    }

    private static Mock<IKeyVaultService> BuildKeyVaultMockWithOrg()
    {
        var kv = new Mock<IKeyVaultService>();
        kv.Setup(s => s.GetSecretAsync("LinkedInAccessToken")).ReturnsAsync("test_token_12345");
        kv.Setup(s => s.GetSecretAsync("LinkedInOwnerCode")).ReturnsAsync("123456789");
        kv.Setup(s => s.GetSecretAsync("LinkedInOrgId")).ReturnsAsync("urn:li:organization:9876");
        return kv;
    }

    #region Constructor and Properties Tests

    [Fact]
    public void Constructor_InitializesCorrectly()
    {
        var sender = new InSender(_mockFactory.Object, _mockKv.Object, _mockLogger.Object);
        Assert.NotNull(sender);
        Assert.Equal(800, sender.MessageMaxLenght);
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new InSender(_mockFactory.Object, _mockKv.Object, null!));
    }

    [Fact]
    public void InSender_ImplementsISender()
    {
        var sender = new InSender(_mockFactory.Object, _mockKv.Object, _mockLogger.Object);
        Assert.IsAssignableFrom<ISender>(sender);
    }

    #endregion

    #region SendAsync with Content Validation Tests

    [Fact]
    public async Task SendAsync_WithNullPost_ReturnsFalseAndLogsWarning()
    {
        var sender = new InSender(_mockFactory.Object, _mockKv.Object, _mockLogger.Object);
        Post? post = null;

        var result = await sender.SendAsync(post!);

        Assert.False(result);
        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("null")),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()
            ), Times.Once);
    }

    #endregion

    #region Credential resolution Tests

    [Fact]
    public void Constructor_WithNullKeyVaultService_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new InSender(_mockFactory.Object, null!, _mockLogger.Object));
    }

    /// <summary>
    /// GAP-2: verifies that Key Vault is queried on EVERY SendAsync invocation.
    /// HttpClient will fail (no real LinkedIn API), but KV reads happen before the first HTTP call.
    /// </summary>
    [Fact]
    public async Task SendAsync_CalledTwice_QueriesKvAccessTokenOnEachCall()
    {
        var sender = new InSender(_mockFactory.Object, _mockKv.Object, _mockLogger.Object);
        var post = new Post { Content = "A LinkedIn post" };

        await sender.SendAsync(post);
        await sender.SendAsync(post);

        _mockKv.Verify(s => s.GetSecretAsync("LinkedInAccessToken"), Times.Exactly(2));
    }

    /// <summary>
    /// GAP-2 (variant): when LinkedInOrgId IS present in KV, ResolveAuthorUrnAsync
    /// uses it directly as author URN and does NOT fall back to LinkedInOwnerCode.
    /// Verified against actual InSender behaviour observed at runtime.
    /// </summary>
    [Fact]
    public async Task SendAsync_WhenLinkedInOrgIdPresent_UsesOrgIdAndSkipsOwnerCode()
    {
        var kvWithOrg = BuildKeyVaultMockWithOrg();
        var sender = new InSender(_mockFactory.Object, kvWithOrg.Object, _mockLogger.Object);
        var post = new Post { Content = "A LinkedIn post" };

        await sender.SendAsync(post);

        // OrgId must be queried — it is the author URN when present
        kvWithOrg.Verify(s => s.GetSecretAsync("LinkedInOrgId"), Times.AtLeastOnce);

        // OwnerCode must NOT be queried when OrgId resolves successfully
        kvWithOrg.Verify(s => s.GetSecretAsync("LinkedInOwnerCode"), Times.Never);
    }

    #endregion
}
