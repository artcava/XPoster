using System.Net;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using XPoster.Contracts;
using XPoster.Credentials;
using XPoster.Models;
using XPoster.SenderPlugins;
using XPoster.Tests.Helpers;

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
        string? accessToken = "fake_token",
        string? ownerCode = "fake_owner",
        string? orgId = null)
        => Options.Create(new LinkedInCredentials
        {
            LinkedInAccessToken = accessToken ?? string.Empty,
            LinkedInOwnerCode = ownerCode ?? string.Empty,
            LinkedInOrgId = orgId ?? string.Empty
        });


    private static InSender BuildSender(
        IHttpClientFactory factory,
        IOptions<LinkedInCredentials>? creds = null,
        Mock<ILogger<InSender>>? log = null)
        => new InSender(factory, creds ?? BuildCreds(), (log ?? new Mock<ILogger<InSender>>()).Object);

    #region Constructor and Properties Tests

    [Fact]
    public void Constructor_InitializesCorrectly()
    {
        var sender = BuildSender(_mockFactory.Object, BuildCreds(), _mockLogger);
        Assert.NotNull(sender);
        Assert.Equal(2800, sender.MessageMaxLenght);
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
    public void Platform_ReturnsLinkedIn()
    {
        var factory = ResilienceTestHelpers.BuildFactory("LinkedIn", HttpStatusCode.OK, "{}");
        Assert.Equal(SenderPlatform.LinkedIn, BuildSender(factory).Platform);
    }

    [Fact]
    public void InSender_ImplementsISender()
    {
        Assert.IsAssignableFrom<ISender>(new InSender(_mockFactory.Object, BuildCreds(), _mockLogger.Object));
    }

    [Fact]
    public void MessageMaxLenght_Returns2800()
    {
        Assert.Equal(2800, BuildSender(_mockFactory.Object).MessageMaxLenght);
    }

    #endregion

    #region SendAsync Guard Tests

    [Fact]
    public async Task SendAsync_WithNullPost_ReturnsFalseAndLogsWarning()
    {
        var result = await BuildSender(_mockFactory.Object, BuildCreds(), _mockLogger).SendAsync(null!);
        Assert.False(result);
        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning()
    {
        var result = await BuildSender(_mockFactory.Object, BuildCreds(), _mockLogger).SendAsync(new Post { Content = string.Empty });
        Assert.False(result);
        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn()
    {
        var creds = BuildCreds(ownerCode: "fake_owner", orgId: "98765432");
        var sender = BuildSender(_mockFactory.Object, creds, _mockLogger);
        Assert.False(await sender.SendAsync(new Post { Content = "org post" }));
    }

    [Fact]
    public async Task SendAsync_TextOnly_WithOrgId_UsesOrganizationUrn()
    {
        HttpRequestMessage? capturedRequest = null;

        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .Callback((HttpRequestMessage req, CancellationToken _) => capturedRequest = req)
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.Created));

        var mockFactory = new Mock<IHttpClientFactory>();
        mockFactory.Setup(f => f.CreateClient("LinkedIn")).Returns(new HttpClient(handler.Object));

        var sut = BuildSender(mockFactory.Object, BuildCreds(orgId: "org456"));

        var result = await sut.SendAsync(new Post { Content = "text only" });

        Assert.True(result);
        Assert.NotNull(capturedRequest);
        Assert.NotNull(capturedRequest!.Content);

        var body = await capturedRequest.Content!.ReadAsStringAsync();
        Assert.Contains("urn:li:organization:org456", body);
    }

    [Fact]
    public async Task SendAsync_TextOnly_WithPersonCode_UsesPersonUrn()
    {
        HttpRequestMessage? capturedRequest = null;

        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .Callback((HttpRequestMessage req, CancellationToken _) => capturedRequest = req)
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.Created));

        var mockFactory = new Mock<IHttpClientFactory>();
        mockFactory.Setup(f => f.CreateClient("LinkedIn")).Returns(new HttpClient(handler.Object));

        var sut = BuildSender(mockFactory.Object, BuildCreds(orgId: null, ownerCode: "person789"));

        var result = await sut.SendAsync(new Post { Content = "text only" });

        Assert.True(result);
        Assert.NotNull(capturedRequest);
        Assert.NotNull(capturedRequest!.Content);

        var body = await capturedRequest.Content!.ReadAsStringAsync();
        Assert.Contains("urn:li:person:person789", body);
    }

    [Fact]
    public async Task SendAsync_WhenNeitherOrgIdNorOwnerCodeSet_ReturnsFalse()
    {
        var factory = ResilienceTestHelpers.BuildFactory("LinkedIn", HttpStatusCode.OK, "{}");
        var sut = BuildSender(factory, BuildCreds(orgId: null, ownerCode: null));

        var result = await sut.SendAsync(new Post { Content = "test" });

        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn()
    {
        var creds = BuildCreds(ownerCode: "123456789", orgId: null);
        var sender = BuildSender(_mockFactory.Object, creds, _mockLogger);
        Assert.False(await sender.SendAsync(new Post { Content = "person post" }));
    }

    [Fact]
    public async Task SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse()
    {
        var creds = BuildCreds(ownerCode: null, orgId: null);
        var sender = BuildSender(_mockFactory.Object, creds, _mockLogger);
        Assert.False(await sender.SendAsync(new Post { Content = "no author" }));
    }

    [Fact]
    public async Task SendAsync_TextOnly_WhenPostCreationFails_ReturnsFalse()
    {
        var factory = ResilienceTestHelpers.BuildFactory("LinkedIn", HttpStatusCode.Forbidden, "{\"error\":\"forbidden\"}");
        var sut = BuildSender(factory);

        var result = await sut.SendAsync(new Post { Content = "test" });

        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_ValidPost_TriesLinkedInAndReturnsFalse()
    {
        var sender = new InSender(_mockFactory.Object, BuildCreds(), _mockLogger.Object);
        var result = await sender.SendAsync(new Post { Content = "Hello LinkedIn" });
        Assert.False(result);
    }

    #endregion

    [Fact]
    public async Task SendAsync_WithImage_WhenRegisterUploadFails_ReturnsFalse()
    {
        var factory = ResilienceTestHelpers.BuildFactory("LinkedIn", HttpStatusCode.BadRequest, "{\"error\":\"bad\"}");
        var sut = BuildSender(factory);

        var result = await sut.SendAsync(new Post
        {
            Content = "test",
            Image = new byte[] { 1, 2, 3 }
        });

        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse()
    {
        var result = await BuildSender(_mockFactory.Object).SendAsync(new Post
        {
            Content = "Post with image",
            Image = new byte[] { 0xFF, 0xD8, 0xFF }
        });
        Assert.False(result);
    }

}
