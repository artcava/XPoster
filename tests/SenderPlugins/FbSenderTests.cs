using System.Net;
using System.Reflection;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using XPoster.Contracts;
using XPoster.Credentials;
using XPoster.Models;
using XPoster.SenderPlugins;
using XPoster.Tests.Helpers;

namespace XPoster.Tests.SenderPlugins;

public class FbSenderTests
{
    private readonly Mock<ILogger<FbSender>> _logger = new();
    private readonly Mock<IHttpClientFactory> _factory = new();
    private readonly Mock<IBlobStorageService> _blobStorage = new();

    private static readonly IOptions<FacebookCredentials> DefaultCreds = Options.Create(new FacebookCredentials
    {
        FacebookAccessToken = "tok",
        FacebookPageId = "99"
    });

    public FbSenderTests()
    {
        _factory.Setup(f => f.CreateClient("Facebook")).Returns(new HttpClient());
    }

    private FbSender BuildSender(IHttpClientFactory factory, Mock<IBlobStorageService>? blobMock = null, Mock<ILogger<FbSender>>? logMock = null)
    {
        blobMock ??= new Mock<IBlobStorageService>();
        logMock ??= new Mock<ILogger<FbSender>>();
        return new FbSender(factory, DefaultCreds, logMock.Object, blobMock.Object);
    }

    private static IHttpClientFactory BuildFactory(HttpStatusCode code, string body)
        => ResilienceTestHelpers.BuildFactory("Facebook", code, body);

    private static byte[]? InvokeNormalize(FbSender sender, byte[] bytes)
    {
        var method = typeof(FbSender).GetMethod("NormalizeImageForFacebook", BindingFlags.Instance | BindingFlags.NonPublic);
        Assert.NotNull(method);
        return (byte[]?)method!.Invoke(sender, new object[] { bytes });
    }

    private static IOptions<FacebookCredentials> BuildCreds() =>
        Options.Create(new FacebookCredentials
        {
            FacebookAccessToken = "test_token",
            FacebookPageId = "123456789"
        });

    [Fact]
    public void Platform_ReturnsFacebook()
    {
        var sut = BuildSender(BuildFactory(HttpStatusCode.OK, "{}"));
        Assert.Equal(SenderPlatform.Facebook, sut.Platform);
    }

    [Fact]
    public void MessageMaxLength_Returns3000()
    {
        var sut = BuildSender(BuildFactory(HttpStatusCode.OK, "{}"));
        Assert.Equal(3000, sut.MessageMaxLength);
    }

    [Fact]
    public void NormalizeImage_WithValidJpeg_ReturnsSameBytes()
    {
        var sut = BuildSender(BuildFactory(HttpStatusCode.OK, "{}"));
        var jpeg = ImageTestData.CreateValidJpeg();
        var result = InvokeNormalize(sut, jpeg);
        Assert.NotNull(result);
        Assert.Equal(jpeg, result);
    }

    [Fact]
    public void NormalizeImage_WithValidPng_ReturnsOriginalBytes()
    {
        var sut = BuildSender(BuildFactory(HttpStatusCode.OK, "{}"));
        var png = ImageTestData.CreateValidPng();

        var result = InvokeNormalize(sut, png);

        Assert.NotNull(result);
        Assert.Equal(png, result);
        Assert.Equal(0x89, result![0]); // PNG signature
        Assert.Equal(0x50, result[1]);
        Assert.Equal(0x4E, result[2]);
        Assert.Equal(0x47, result[3]);
    }

    [Fact]
    public void NormalizeImage_WithInvalidBytes_ReturnsNull()
    {
        var sut = BuildSender(BuildFactory(HttpStatusCode.OK, "{}"));
        var result = InvokeNormalize(sut, new byte[] { 0x00, 0x01, 0x02, 0x03 });
        Assert.Null(result);
    }

    [Fact]
    public async Task SendAsync_WithCaptionExceedingMaxLength_TruncatesAndPublishes()
    {
        var factory = BuildFactory(HttpStatusCode.OK, "{\"id\":\"123\"}");
        var sut = BuildSender(factory);
        var result = await sut.SendAsync(new Post { Content = new string('A', 6100), Image = null });
        Assert.True(result);
    }

    [Fact]
    public async Task SendAsync_TextOnly_WhenResponseMissingId_ReturnsFalse()
    {
        var factory = BuildFactory(HttpStatusCode.OK, "{\"other\":\"val\"}");
        var sut = BuildSender(factory);
        Assert.False(await sut.SendAsync(new Post { Content = "test", Image = null }));
    }

    [Fact]
    public async Task SendAsync_TextOnly_WhenResponseHasEmptyId_ReturnsFalse()
    {
        var factory = BuildFactory(HttpStatusCode.OK, "{\"id\":\"\"}");
        var sut = BuildSender(factory);
        Assert.False(await sut.SendAsync(new Post { Content = "test", Image = null }));
    }

    [Fact]
    public async Task SendAsync_TextOnly_WhenResponseHasNullId_ReturnsFalse()
    {
        var factory = BuildFactory(HttpStatusCode.OK, "{\"id\":null}");
        var sut = BuildSender(factory);
        Assert.False(await sut.SendAsync(new Post { Content = "test", Image = null }));
    }

    [Fact]
    public async Task SendAsync_WhenPhotoEndpointReturns503_ReturnsFalseAndDeletesBlob()
    {
        var blob = new Mock<IBlobStorageService>();
        blob.Setup(x => x.UploadAsync(It.IsAny<byte[]>(), "image/jpeg", It.IsAny<CancellationToken>()))
            .ReturnsAsync(new BlobUploadResult(new Uri("https://example.com/b.jpg"), "b"));
        blob.Setup(x => x.DeleteAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var factory = ResilienceTestHelpers.BuildFactory(
            "Facebook",
            (HttpStatusCode.ServiceUnavailable, "{\"error\":\"down\"}"));

        var sut = BuildSender(factory, blob);

        var result = await sut.SendAsync(new Post
        {
            Content = "test",
            Image = ImageTestData.CreateValidJpeg()
        });

        Assert.False(result);
        blob.Verify(x => x.DeleteAsync("b", It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task SendAsync_WhenHttpClientThrows_ReturnsFalse()
    {
        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new Exception("network failure"));

        var mockFactory = new Mock<IHttpClientFactory>();
        mockFactory.Setup(f => f.CreateClient("Facebook")).Returns(new HttpClient(handler.Object));

        var sut = BuildSender(mockFactory.Object);
        Assert.False(await sut.SendAsync(new Post { Content = "test", Image = null }));
    }

    [Fact]
    public void Constructor_InitializesCorrectly()
    {
        var sender = new FbSender(_factory.Object, BuildCreds(), _logger.Object, _blobStorage.Object);

        Assert.NotNull(sender);
        Assert.Equal(SenderPlatform.Facebook, sender.Platform);
        Assert.Equal(3000, sender.MessageMaxLength);
    }

    [Fact]
    public void Constructor_WithNullFactory_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new FbSender(null!, BuildCreds(), _logger.Object, _blobStorage.Object));
    }

    [Fact]
    public void Constructor_WithNullCredentials_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new FbSender(_factory.Object, null!, _logger.Object, _blobStorage.Object));
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new FbSender(_factory.Object, BuildCreds(), null!, _blobStorage.Object));
    }

    [Fact]
    public void Constructor_WithNullBlobStorage_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new FbSender(_factory.Object, BuildCreds(), _logger.Object, null!));
    }

    [Fact]
    public void FbSender_ImplementsISender()
    {
        Assert.IsAssignableFrom<ISender>(
            new FbSender(_factory.Object, BuildCreds(), _logger.Object, _blobStorage.Object));
    }
}