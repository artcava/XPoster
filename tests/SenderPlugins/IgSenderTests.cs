using System.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using XPoster.Contracts;
using XPoster.Credentials;
using XPoster.Models;
using XPoster.SenderPlugins;
using XPoster.Tests.Helpers;

namespace XPoster.Tests.SenderPlugins;

/// <summary>
/// Tests for IgSender.
/// Only branches that execute before or without real HTTP calls are covered:
/// constructor guards, MessageMaxLength, null/empty content guards, no-image branch,
/// and the image path (which throws on the Instagram API — caught internally).
/// </summary>
public class IgSenderTests
{
    private readonly Mock<ILogger<IgSender>> _mockLogger;
    private readonly Mock<IHttpClientFactory> _mockFactory;
    private readonly IOptions<InstagramCredentials> _credentials;
    private readonly Mock<IBlobStorageService> _mockStorage;
    private readonly Mock<IContainerStateStore> _mockContainerState;

    public IgSenderTests()
    {
        _mockLogger = new Mock<ILogger<IgSender>>();
        _mockFactory = new Mock<IHttpClientFactory>();
        _mockFactory.Setup(f => f.CreateClient("Instagram")).Returns(new HttpClient());
        _credentials = Options.Create(new InstagramCredentials
        {
            InstagramAccessToken = "fake_token",
            InstagramAccountId = "fake_account_id"
        });
        _mockStorage = new Mock<IBlobStorageService>();
        _mockContainerState = new Mock<IContainerStateStore>();

    }

    private IgSender BuildSender() =>
        new(_mockFactory.Object, _credentials, _mockLogger.Object, _mockStorage.Object, _mockContainerState.Object);

    private static IgSender BuildSenderWithFactory(
        IHttpClientFactory factory,
        IOptions<InstagramCredentials>? creds = null)
    {
        var c = creds ?? Options.Create(new InstagramCredentials
        {
            InstagramAccessToken = "fake_token",
            InstagramAccountId = "fake_account_id"
        });
        return new IgSender(factory, c, new Mock<ILogger<IgSender>>().Object, new Mock<IBlobStorageService>().Object, new Mock<IContainerStateStore>().Object);
    }

    #region Constructor Tests

    [Fact]
    public void Constructor_InitializesCorrectly()
    {
        Assert.NotNull(BuildSender());
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new IgSender(_mockFactory.Object, _credentials, null!, _mockStorage.Object, _mockContainerState.Object));
    }

    [Fact]
    public void Constructor_WithNullCredentials_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new IgSender(_mockFactory.Object, null!, _mockLogger.Object, _mockStorage.Object, _mockContainerState.Object));
    }

    [Fact]
    public void MessageMaxLenght_Returns2200()
    {
        Assert.Equal(2200, BuildSender().MessageMaxLenght);
    }

    #endregion

    #region SendAsync Guard Tests

    [Fact]
    public async Task SendAsync_WithNullPost_ReturnsFalse()
    {
        Assert.False(await BuildSender().SendAsync(null!));
    }

    [Fact]
    public async Task SendAsync_WithEmptyContent_ReturnsFalse()
    {
        Assert.False(await BuildSender().SendAsync(new Post { Content = string.Empty }));
    }

    [Fact]
    public async Task SendAsync_WithWhitespaceContent_ReturnsFalse()
    {
        // IgSender does not have an explicit whitespace guard but the outer try/catch
        // will return false for any unhandled exception or when Image is null.
        Assert.False(await BuildSender().SendAsync(new Post { Content = "   " }));
    }

    [Fact]
    public async Task SendAsync_WithNoImage_ReturnsFalse()
    {
        Assert.False(await BuildSender().SendAsync(new Post { Content = "Test caption", Image = null }));
    }

    [Fact]
    public async Task SendAsync_WithImage_TriesUploadAndReturnsFalse()
    {
        // UploadImageToPublicUrl throws NotImplementedException — caught internally.
        Assert.False(await BuildSender().SendAsync(new Post
        {
            Content = "Test caption",
            Image = new byte[] { 0x89, 0x50, 0x4E, 0x47 }
        }));
    }

    #endregion

    #region Image upload and API response Tests

    [Fact]
    public async Task SendAsync_WhenImageUploadThrowsNotImplemented_ReturnsFalseAndLogsError()
    {
        var result = await BuildSender().SendAsync(
            new Post { Content = "caption", Image = new byte[] { 1, 2, 3 } });

        Assert.False(result);
        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.AtLeastOnce);
    }

    [Fact]
    public async Task SendAsync_WhenInstagramApiReturnsNonSuccess_ReturnsFalse()
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
            {
                Content = new StringContent("{\"error\":\"bad_request\"}")
            });

        var factoryMock = new Mock<IHttpClientFactory>();
        factoryMock.Setup(f => f.CreateClient("Instagram"))
            .Returns(new HttpClient(handlerMock.Object));

        Assert.False(await BuildSenderWithFactory(factoryMock.Object).SendAsync(
            new Post { Content = "caption", Image = new byte[] { 1, 2, 3 } }));
    }

    [Fact]
    public async Task SendAsync_WhenInstagramApiReturns429_ReturnsFalse()
    {
        var factory = ResilienceTestHelpers.BuildFactory(
            "Instagram",
            (System.Net.HttpStatusCode.TooManyRequests, "{\"error\":\"rate_limited\"}"));

        Assert.False(await BuildSenderWithFactory(factory).SendAsync(
            new Post { Content = "caption", Image = new byte[] { 1, 2, 3 } }));
    }

    [Fact]
    public async Task SendAsync_WhenImageUploadThrowsHttpRequestException_ReturnsFalseAndLogsError()
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new HttpRequestException("Connection refused"));

        var factoryMock = new Mock<IHttpClientFactory>();
        factoryMock.Setup(f => f.CreateClient("Instagram"))
            .Returns(new HttpClient(handlerMock.Object));

        var loggerMock = new Mock<ILogger<IgSender>>();
        var sender = new IgSender(
            factoryMock.Object,
            Options.Create(new InstagramCredentials { InstagramAccessToken = "fake_token", InstagramAccountId = "fake_account_id" }),
            loggerMock.Object,
            _mockStorage.Object,
            _mockContainerState.Object);

        Assert.False(await sender.SendAsync(
            new Post { Content = "caption", Image = new byte[] { 1, 2, 3 } }));

        loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.AtLeastOnce);
    }

    #endregion
}
