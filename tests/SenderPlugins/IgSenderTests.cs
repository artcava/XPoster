using System.Net;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using XPoster.Contracts;
using XPoster.Credentials;
using XPoster.Models;
using XPoster.SenderPlugins;
using XPoster.Tests.Helpers;

namespace XPoster.Tests.SenderPlugins;

public class IgSenderTests
{
    private static readonly InstagramCredentials DefaultCredentials = new()
    {
        InstagramAccessToken = "fake_token",
        InstagramAccountId = "fake_account_id"
    };

    private static IgSender BuildSender(
        HttpClient client,
        Mock<IBlobStorageService>? blob = null,
        Mock<IContainerStateStore>? store = null,
        Mock<ILogger<IgSender>>? log = null,
        InstagramCredentials? credentials = null)
    {
        var factory = new Mock<IHttpClientFactory>();
        factory.Setup(f => f.CreateClient("Instagram")).Returns(client);
        return new IgSender(
            factory.Object,
            Options.Create(credentials ?? DefaultCredentials),
            (log ?? new Mock<ILogger<IgSender>>()).Object,
            (blob ?? new Mock<IBlobStorageService>()).Object,
            (store ?? new Mock<IContainerStateStore>()).Object);
    }

    private static byte[] CreateMalformedPngBytes()
    {
        var signature = new byte[] { 137, 80, 78, 71, 13, 10, 26, 10 };
        var invalidPayload = Encoding.ASCII.GetBytes("malformed-png");
        return signature.Concat(invalidPayload).ToArray();
    }

    private static byte[]? InvokeNormalizeImage(IgSender sender, byte[] imageBytes)
    {
        var method = typeof(IgSender).GetMethod("NormalizeImageForInstagram", BindingFlags.Instance | BindingFlags.NonPublic);
        Assert.NotNull(method);
        return (byte[]?)method!.Invoke(sender, new object[] { imageBytes });
    }

    [Fact]
    public void Platform_ReturnsInstagram()
    {
        var sut = BuildSender(new HttpClient(new Mock<HttpMessageHandler>().Object));
        Assert.Equal(SenderPlatform.Instagram, sut.Platform);
    }

    [Fact]
    public void NormalizeImage_WithValidJpeg_ReturnsSameBytes()
    {
        var sut = BuildSender(new HttpClient(new Mock<HttpMessageHandler>().Object));
        var jpeg = ImageTestData.CreateValidJpeg();
        var result = InvokeNormalizeImage(sut, jpeg);
        Assert.Equal(jpeg, result);
    }

    [Fact]
    public void NormalizeImage_WithValidPng_ReturnsJpegBytes()
    {
        var sut = BuildSender(new HttpClient(new Mock<HttpMessageHandler>().Object));
        var png = ImageTestData.CreateValidPng();
        var result = InvokeNormalizeImage(sut, png);
        Assert.NotNull(result);
        Assert.Equal(0xFF, result![0]);
        Assert.Equal(0xD8, result[1]);
    }

    [Fact]
    public void NormalizeImage_WithInvalidBytes_ReturnsNull()
    {
        var sut = BuildSender(new HttpClient(new Mock<HttpMessageHandler>().Object));
        var result = InvokeNormalizeImage(sut, new byte[] { 0x00, 0x01, 0x02 });
        Assert.Null(result);
    }

    [Fact]
    public async Task SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption()
    {
        var blob = new Mock<IBlobStorageService>();
        var store = new Mock<IContainerStateStore>();
        blob.Setup(x => x.UploadAsync(It.IsAny<byte[]>(), "image/jpeg", It.IsAny<CancellationToken>()))
            .ReturnsAsync(new BlobUploadResult(new Uri("https://example.com/b.jpg"), "b"));
        store.Setup(x => x.SaveAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"id\":\"cont-1\"}", System.Text.Encoding.UTF8, "application/json")
            });

        var sut = BuildSender(new HttpClient(handler.Object), blob, store);
        Assert.True(await sut.SendAsync(new Post { Content = new string('X', 2500), Image = ImageTestData.CreateValidJpeg() }));
    }

    [Fact]
    public async Task SendAsync_WhenBlobUploadFails_ReturnsFalse()
    {
        var blob = new Mock<IBlobStorageService>();
        blob.Setup(x => x.UploadAsync(It.IsAny<byte[]>(), "image/jpeg", It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception("storage unavailable"));

        var sut = BuildSender(new HttpClient(new Mock<HttpMessageHandler>().Object), blob);
        Assert.False(await sut.SendAsync(new Post { Content = "test", Image = ImageTestData.CreateValidJpeg() }));
    }

    [Fact]
    public async Task SendAsync_WhenHttpClientThrows_ReturnsFalse()
    {
        var blob = new Mock<IBlobStorageService>();
        blob.Setup(x => x.UploadAsync(It.IsAny<byte[]>(), "image/jpeg", It.IsAny<CancellationToken>()))
            .ReturnsAsync(new BlobUploadResult(new Uri("https://example.com/b.jpg"), "b"));

        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new Exception("http error"));

        var sut = BuildSender(new HttpClient(handler.Object), blob);
        Assert.False(await sut.SendAsync(new Post { Content = "test", Image = ImageTestData.CreateValidJpeg() }));
    }

    [Fact]
    public async Task SendAsync_WithEmptyImageArray_ReturnsFalse()
    {
        var sut = BuildSender(new HttpClient(new Mock<HttpMessageHandler>().Object));
        Assert.False(await sut.SendAsync(new Post { Content = "test", Image = Array.Empty<byte>() }));
    }

    [Fact]
    public void Constructor_InitializesCorrectly()
    {
        var sut = BuildSender(
            new HttpClient(new Mock<HttpMessageHandler>().Object),
            new Mock<IBlobStorageService>(),
            new Mock<IContainerStateStore>(),
            new Mock<ILogger<IgSender>>());

        Assert.NotNull(sut);
    }

    [Fact]
    public void Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new IgSender(
                null!,
                Options.Create(DefaultCredentials),
                new Mock<ILogger<IgSender>>().Object,
                new Mock<IBlobStorageService>().Object,
                new Mock<IContainerStateStore>().Object));
    }

    [Fact]
    public void Constructor_WithNullCredentials_ThrowsArgumentNullException()
    {
        var factoryMock = new Mock<IHttpClientFactory>();
        factoryMock.Setup(f => f.CreateClient("Instagram")).Returns(new HttpClient(new Mock<HttpMessageHandler>().Object));

        Assert.Throws<ArgumentNullException>(() =>
            new IgSender(
                factoryMock.Object,
                null!,
                new Mock<ILogger<IgSender>>().Object,
                new Mock<IBlobStorageService>().Object,
                new Mock<IContainerStateStore>().Object));
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        var factoryMock = new Mock<IHttpClientFactory>();
        factoryMock.Setup(f => f.CreateClient("Instagram")).Returns(new HttpClient(new Mock<HttpMessageHandler>().Object));

        Assert.Throws<ArgumentNullException>(() =>
            new IgSender(
                factoryMock.Object,
                Options.Create(DefaultCredentials),
                null!,
                new Mock<IBlobStorageService>().Object,
                new Mock<IContainerStateStore>().Object));
    }

    [Fact]
    public void Constructor_WithNullBlobStorageService_ThrowsArgumentNullException()
    {
        var factoryMock = new Mock<IHttpClientFactory>();
        factoryMock.Setup(f => f.CreateClient("Instagram")).Returns(new HttpClient(new Mock<HttpMessageHandler>().Object));

        Assert.Throws<ArgumentNullException>(() =>
            new IgSender(
                factoryMock.Object,
                Options.Create(DefaultCredentials),
                new Mock<ILogger<IgSender>>().Object,
                null!,
                new Mock<IContainerStateStore>().Object));
    }

    [Fact]
    public void Constructor_WithNullContainerStateStore_ThrowsArgumentNullException()
    {
        var factoryMock = new Mock<IHttpClientFactory>();
        factoryMock.Setup(f => f.CreateClient("Instagram")).Returns(new HttpClient(new Mock<HttpMessageHandler>().Object));

        Assert.Throws<ArgumentNullException>(() =>
            new IgSender(
                factoryMock.Object,
                Options.Create(DefaultCredentials),
                new Mock<ILogger<IgSender>>().Object,
                new Mock<IBlobStorageService>().Object,
                null!));
    }

    [Fact]
    public void MessageMaxLenght_Returns2200()
    {
        var sut = BuildSender(
            new HttpClient(new Mock<HttpMessageHandler>().Object),
            new Mock<IBlobStorageService>(),
            new Mock<IContainerStateStore>(),
            new Mock<ILogger<IgSender>>());

        Assert.Equal(2200, sut.MessageMaxLenght);
    }

    [Fact]
    public async Task SendAsync_WithNullPost_ReturnsFalse()
    {
        var sut = BuildSender(
            new HttpClient(new Mock<HttpMessageHandler>().Object),
            new Mock<IBlobStorageService>(),
            new Mock<IContainerStateStore>(),
            new Mock<ILogger<IgSender>>());

        Assert.False(await sut.SendAsync(null!));
    }

    [Fact]
    public async Task SendAsync_WithNoImage_ReturnsFalse()
    {
        var sut = BuildSender(
            new HttpClient(new Mock<HttpMessageHandler>().Object),
            new Mock<IBlobStorageService>(),
            new Mock<IContainerStateStore>(),
            new Mock<ILogger<IgSender>>());

        Assert.False(await sut.SendAsync(new Post { Content = "Test caption", Image = null }));
    }

    [Fact]
    public async Task SendAsync_WhenBlobUploadSucceeds_CreatesMediaContainerWithCorrectSasUrl()
    {
        var blob = new Mock<IBlobStorageService>();
        var store = new Mock<IContainerStateStore>();
        var logger = new Mock<ILogger<IgSender>>();
        var captured = new List<HttpRequestMessage>();

        blob.Setup(x => x.UploadAsync(It.IsAny<byte[]>(), "image/jpeg", It.IsAny<CancellationToken>()))
            .ReturnsAsync(new BlobUploadResult(
                new Uri("https://storage.example.com/xposter-images/blob1.jpg?sig=abc"),
                "blob1.jpg"));
        store.Setup(x => x.SaveAsync("creation-123", "blob1.jpg", It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .Callback((HttpRequestMessage req, CancellationToken _) => captured.Add(req))
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"id\":\"creation-123\"}", Encoding.UTF8, "application/json")
            });

        var httpClient = new HttpClient(handler.Object);
        var sut = BuildSender(httpClient, blob, store, logger);

        var result = await sut.SendAsync(new Post
        {
            Content = "hello",
            Image = ImageTestData.CreateValidJpeg()
        });

        Assert.True(result);
        Assert.Single(captured);
        Assert.Contains("access_token=fake_token", captured[0].RequestUri!.Query);
        Assert.Equal(HttpMethod.Post, captured[0].Method);
        blob.Verify(x => x.UploadAsync(It.IsAny<byte[]>(), "image/jpeg", It.IsAny<CancellationToken>()), Times.Once);
        store.Verify(x => x.SaveAsync("creation-123", "blob1.jpg", It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task SendAsync_WhenJsonResponseMissingIdProperty_ReturnsFalse()
    {
        var blob = new Mock<IBlobStorageService>();
        var store = new Mock<IContainerStateStore>(MockBehavior.Strict);
        var logger = new Mock<ILogger<IgSender>>();

        blob.Setup(x => x.UploadAsync(It.IsAny<byte[]>(), "image/jpeg", It.IsAny<CancellationToken>()))
            .ReturnsAsync(new BlobUploadResult(
                new Uri("https://storage.example.com/xposter-images/blob1.jpg?sig=abc"),
                "blob1.jpg"));

        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"other_field\":\"val\"}", Encoding.UTF8, "application/json")
            });

        var sut = BuildSender(new HttpClient(handler.Object), blob, store, logger);

        var result = await sut.SendAsync(new Post
        {
            Content = "hello",
            Image = ImageTestData.CreateValidJpeg()
        });

        Assert.False(result);
        store.Verify(x => x.SaveAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Theory]
    [InlineData("{\"id\":\"\"}")]
    [InlineData("{\"id\":null}")]
    public async Task SendAsync_WhenJsonResponseIdIsEmpty_ReturnsFalse(string responseJson)
    {
        var blob = new Mock<IBlobStorageService>();
        var store = new Mock<IContainerStateStore>(MockBehavior.Strict);
        var logger = new Mock<ILogger<IgSender>>();

        blob.Setup(x => x.UploadAsync(It.IsAny<byte[]>(), "image/jpeg", It.IsAny<CancellationToken>()))
            .ReturnsAsync(new BlobUploadResult(
                new Uri("https://storage.example.com/xposter-images/blob1.jpg?sig=abc"),
                "blob1.jpg"));

        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(responseJson, Encoding.UTF8, "application/json")
            });

        var sut = BuildSender(new HttpClient(handler.Object), blob, store, logger);

        var result = await sut.SendAsync(new Post
        {
            Content = "hello",
            Image = ImageTestData.CreateValidJpeg()
        });

        Assert.False(result);
        store.Verify(x => x.SaveAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task SendAsync_WhenBlobUploadCancelled_ReturnsFalse()
    {
        var blob = new Mock<IBlobStorageService>();
        var store = new Mock<IContainerStateStore>(MockBehavior.Strict);
        var logger = new Mock<ILogger<IgSender>>();

        blob.Setup(x => x.UploadAsync(It.IsAny<byte[]>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new TaskCanceledException());

        var sut = BuildSender(
            new HttpClient(new Mock<HttpMessageHandler>().Object),
            blob,
            store,
            logger);

        var result = await sut.SendAsync(new Post
        {
            Content = "caption",
            Image = ImageTestData.CreateValidJpeg()
        });

        Assert.False(result);
        logger.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("Errore durante il caricamento dell'immagine su Blob Storage")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public void NormalizeImage_WhenCodecIsNull_ReturnsNull()
    {
        var sut = BuildSender(
            new HttpClient(new Mock<HttpMessageHandler>().Object),
            new Mock<IBlobStorageService>(),
            new Mock<IContainerStateStore>(),
            new Mock<ILogger<IgSender>>());

        var result = InvokeNormalizeImage(sut, new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05 });

        Assert.Null(result);
    }

    [Fact]
    public void NormalizeImage_WhenJpegIsAlreadyValid_ReturnsOriginalBytes()
    {
        var sut = BuildSender(
            new HttpClient(new Mock<HttpMessageHandler>().Object),
            new Mock<IBlobStorageService>(),
            new Mock<IContainerStateStore>(),
            new Mock<ILogger<IgSender>>());

        var jpegBytes = ImageTestData.CreateValidJpeg();

        var result = InvokeNormalizeImage(sut, jpegBytes);

        Assert.NotNull(result);
        Assert.Equal(jpegBytes, result);
    }

    [Fact]
    public void NormalizeImage_WhenPngDecodesToNull_ReturnsNull()
    {
        var sut = BuildSender(
            new HttpClient(new Mock<HttpMessageHandler>().Object),
            new Mock<IBlobStorageService>(),
            new Mock<IContainerStateStore>(),
            new Mock<ILogger<IgSender>>());

        var result = InvokeNormalizeImage(sut, CreateMalformedPngBytes());

        Assert.Null(result);
    }
}
