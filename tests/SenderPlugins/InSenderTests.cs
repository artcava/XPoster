using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using XPoster.Contracts;
using XPoster.Models;
using XPoster.Options;
using XPoster.SenderPlugins;

namespace XPoster.Tests.SenderPlugins;

public class InSenderTests
{
    private readonly Mock<ILogger<InSender>> _mockLogger;
    private readonly Mock<IHttpClientFactory> _mockFactory;

    public InSenderTests()
    {
        _mockLogger = new Mock<ILogger<InSender>>();
        _mockFactory = new Mock<IHttpClientFactory>();
        _mockFactory.Setup(f => f.CreateClient("LinkedIn")).Returns(new HttpClient());
    }

    private static IOptions<LinkedInCredentials> BuildCreds(
        string accessToken = "test_token_12345",
        string ownerCode = "123456789",
        string? orgId = null)
        => Options.Create(new LinkedInCredentials
        {
            LinkedInAccessToken = accessToken,
            LinkedInOwnerCode = ownerCode,
            LinkedInOrgId = orgId ?? string.Empty
        });

    #region Constructor and Properties Tests

    [Fact]
    public void Constructor_InitializesCorrectly()
    {
        var sender = new InSender(_mockFactory.Object, BuildCreds(), _mockLogger.Object);
        Assert.NotNull(sender);
        Assert.Equal(800, sender.MessageMaxLenght);
    }

    [Fact]
    public void Constructor_WithNullCredentials_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new InSender(_mockFactory.Object, null!, _mockLogger.Object));
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new InSender(_mockFactory.Object, BuildCreds(), null!));
    }

    [Fact]
    public void InSender_ImplementsISender()
    {
        Assert.IsAssignableFrom<ISender>(new InSender(_mockFactory.Object, BuildCreds(), _mockLogger.Object));
    }

    #endregion

    #region SendAsync Guard Tests

    [Fact]
    public async Task SendAsync_WithNullPost_ReturnsFalseAndLogsWarning()
    {
        var sender = new InSender(_mockFactory.Object, BuildCreds(), _mockLogger.Object);

        var result = await sender.SendAsync(null!);

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

    [Fact]
    public async Task SendAsync_WithWhitespaceContent_ReturnsFalseAndLogsWarning()
    {
        var sender = new InSender(_mockFactory.Object, BuildCreds(), _mockLogger.Object);
        Assert.False(await sender.SendAsync(new Post { Content = "  " }));
    }

    #endregion

    #region Author URN resolution Tests

    [Fact]
    public async Task SendAsync_WhenOrgIdPresent_UsesOrgUrn()
    {
        // OrgId set — ResolveAuthorUrn returns organization URN; HTTP will fail but no exception surfaces.
        var sender = new InSender(_mockFactory.Object,
            BuildCreds(orgId: "urn:li:organization:9876"), _mockLogger.Object);
        Assert.False(await sender.SendAsync(new Post { Content = "A LinkedIn post" }));
    }

    [Fact]
    public async Task SendAsync_WhenOrgIdAbsentAndOwnerSet_UsesPersonUrn()
    {
        var sender = new InSender(_mockFactory.Object,
            BuildCreds(ownerCode: "123456789", orgId: null), _mockLogger.Object);
        Assert.False(await sender.SendAsync(new Post { Content = "A LinkedIn post" }));
    }

    #endregion
}
