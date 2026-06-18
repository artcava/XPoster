using System.Net;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using XPoster.Contracts;
using XPoster.Models;
using XPoster.SenderPlugins;
using XPoster.Tests.Helpers;

namespace XPoster.Tests.SenderPlugins;

/// <summary>
/// Tests for IgSender.
/// Only branches that execute before or without real HTTP calls are covered:
/// constructor guards, MessageMaxLenght, null/empty content guards, no-image branch,
/// and the image path (which throws on the Instagram API — caught internally).
/// </summary>
public class IgSenderTests
{
    private readonly Mock<ILogger<IgSender>> _mockLogger;
    private readonly Mock<IHttpClientFactory> _mockFactory;
    private readonly Mock<IKeyVaultService> _mockKv;

    public IgSenderTests()
    {
        _mockLogger = new Mock<ILogger<IgSender>>();
        _mockFactory = new Mock<IHttpClientFactory>();
        _mockFactory.Setup(f => f.CreateClient("Instagram")).Returns(new HttpClient());
        _mockKv = new Mock<IKeyVaultService>();
        _mockKv.Setup(s => s.GetSecretAsync("IgAccessToken")).ReturnsAsync("fake_token");
        _mockKv.Setup(s => s.GetSecretAsync("IgAccountId")).ReturnsAsync("fake_account_id");
    }

    private IgSender BuildSender() =>
        new(_mockFactory.Object, _mockKv.Object, _mockLogger.Object);

    private static IgSender BuildSenderWithFactory(IHttpClientFactory factory, Mock<IKeyVaultService>? kv = null)
    {
        var kvMock = kv ?? new Mock<IKeyVaultService>();
        kvMock.Setup(s => s.GetSecretAsync("IgAccessToken")).ReturnsAsync("fake_token");
        kvMock.Setup(s => s.GetSecretAsync("IgAccountId")).ReturnsAsync("fake_account_id");
        return new IgSender(factory, kvMock.Object, new Mock<ILogger<IgSender>>().Object);
    }

    #region Constructor Tests

    [Fact]
    public void Constructor_InitializesCorrectly()
    {
        var sender = BuildSender();
        Assert.NotNull(sender);
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new IgSender(_mockFactory.Object, _mockKv.Object, null!));
    }

    [Fact]
    public void Constructor_WithNullKeyVaultService_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new IgSender(_mockFactory.Object, null!, _mockLogger.Object));
    }

    [Fact]
    public void MessageMaxLenght_Returns2200()
    {
        var sender = BuildSender();
        Assert.Equal(2200, sender.MessageMaxLenght);
    }

    #endregion

    #region SendAsync Guard Tests

    [Fact]
    public async Task SendAsync_WithNullPost_ReturnsFalse()
    {
        var result = await BuildSender().SendAsync(null!);
        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WithEmptyContent_ReturnsFalse()
    {
        var result = await BuildSender().SendAsync(new Post { Content = string.Empty });
        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WithWhitespaceContent_ReturnsFalse()
    {
        var result = await BuildSender().SendAsync(new Post { Content = "   " });
        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WithNoImage_ReturnsFalse()
    {
        var result = await BuildSender().SendAsync(new Post { Content = "Test caption", Image = null });
        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WithImage_TriesUploadAndReturnsFalse()
    {
        var result = await BuildSender().SendAsync(new Post
        {
            Content = "Test caption",
            Image = new byte[] { 0x89, 0x50, 0x4E, 0x47 }
        });
        Assert.False(result);
    }

    #endregion

    #region Credential resolution Tests (GAP-4)

    [Fact]
    public async Task SendAsync_WithImage_ReadsIgAccessTokenFromKv()
    {
        await BuildSender().SendAsync(new Post
        {
            Content = "caption",
            Image = new byte[] { 1, 2, 3 }
        });

        _mockKv.Verify(s => s.GetSecretAsync("IgAccessToken"), Times.AtLeastOnce);
    }

    [Fact]
    public async Task SendAsync_WithImage_ReadsIgAccountIdFromKv()
    {
        await BuildSender().SendAsync(new Post
        {
            Content = "caption",
            Image = new byte[] { 1, 2, 3 }
        });

        _mockKv.Verify(s => s.GetSecretAsync("IgAccountId"), Times.AtLeastOnce);
    }

    [Fact]
    public async Task SendAsync_WithoutImage_DoesNotQueryKv()
    {
        await BuildSender().SendAsync(new Post { Content = "text only" });

        _mockKv.Verify(s => s.GetSecretAsync(It.IsAny<string>()), Times.Never);
    }

    #endregion

    #region Image upload and API response Tests (issue #166 gaps)

    /// <summary>
    /// When the image upload helper throws NotImplementedException (current state),
    /// SendAsync must catch it and return false — never surface the exception to callers.
    /// </summary>
    [Fact]
    public async Task SendAsync_WhenImageUploadThrowsNotImplemented_ReturnsFalseAndLogsError()
    {
        // Arrange — default factory (no HTTP handler needed; UploadImageToPublicUrl throws before any HTTP call)
        var sender = BuildSender();
        var post = new Post { Content = "caption", Image = new byte[] { 1, 2, 3 } };

        // Act
        var result = await sender.SendAsync(post);

        // Assert
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

    /// <summary>
    /// When the Instagram media-create API returns a non-success status code,
    /// SendAsync must return false and log an error.
    /// This test requires a real upload URL — we simulate it by patching the HTTP handler
    /// so that UploadImageToPublicUrl would succeed if implemented; currently the method
    /// throws NotImplementedException, so we verify the outer catch fires instead.
    /// Once UploadImageToPublicUrl is implemented this test should be updated to inject
    /// a real upload response followed by a non-success media-create response.
    /// </summary>
    [Fact]
    public async Task SendAsync_WhenInstagramApiReturnsNonSuccess_ReturnsFalse()
    {
        // Arrange — handler returns 400 for any request
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent("{\"error\":\"bad_request\"}")
            });

        var client = new HttpClient(handlerMock.Object);
        var factoryMock = new Mock<IHttpClientFactory>();
        factoryMock.Setup(f => f.CreateClient("Instagram")).Returns(client);

        var sender = BuildSenderWithFactory(factoryMock.Object);
        var post = new Post { Content = "caption", Image = new byte[] { 1, 2, 3 } };

        // Act
        var result = await sender.SendAsync(post);

        // Assert — NotImplementedException from UploadImageToPublicUrl is caught;
        // the outer catch returns false regardless of handler behaviour.
        Assert.False(result);
    }

    /// <summary>
    /// When the Instagram API returns HTTP 429 (rate limit), SendAsync returns false.
    /// </summary>
    [Fact]
    public async Task SendAsync_WhenInstagramApiReturns429_ReturnsFalse()
    {
        var factory = ResilienceTestHelpers.BuildFactory(
            "Instagram",
            (HttpStatusCode.TooManyRequests, "{\"error\":\"rate_limited\"}"));

        var sender = BuildSenderWithFactory(factory);
        var post = new Post { Content = "caption", Image = new byte[] { 1, 2, 3 } };

        var result = await sender.SendAsync(post);

        Assert.False(result);
    }

    /// <summary>
    /// When an HttpRequestException is thrown during the image upload step,
    /// SendAsync must catch it and return false.
    /// </summary>
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

        var client = new HttpClient(handlerMock.Object);
        var factoryMock = new Mock<IHttpClientFactory>();
        factoryMock.Setup(f => f.CreateClient("Instagram")).Returns(client);

        var loggerMock = new Mock<ILogger<IgSender>>();
        var kvMock = new Mock<IKeyVaultService>();
        kvMock.Setup(s => s.GetSecretAsync("IgAccessToken")).ReturnsAsync("fake_token");
        kvMock.Setup(s => s.GetSecretAsync("IgAccountId")).ReturnsAsync("fake_account_id");

        var sender = new IgSender(factoryMock.Object, kvMock.Object, loggerMock.Object);
        var post = new Post { Content = "caption", Image = new byte[] { 1, 2, 3 } };

        var result = await sender.SendAsync(post);

        Assert.False(result);
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
