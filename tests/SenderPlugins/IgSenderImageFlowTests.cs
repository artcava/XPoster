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

public class IgSenderImageFlowTests
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
    public void NormalizeImage_WhenCodecIsNull_ReturnsNull()
    {
        var sut = BuildSender(new HttpClient(new Mock<HttpMessageHandler>().Object));
        var result = InvokeNormalizeImage(sut, new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05 });
        Assert.Null(result);
    }

    [Fact]
    public void NormalizeImage_WhenJpegIsAlreadyValid_ReturnsOriginalBytes()
    {
        var sut = BuildSender(new HttpClient(new Mock<HttpMessageHandler>().Object));
        var jpegBytes = ImageTestData.CreateValidJpeg();
        var result = InvokeNormalizeImage(sut, jpegBytes);
        Assert.NotNull(result);
        Assert.Equal(jpegBytes, result);
    }

    [Fact]
    public void NormalizeImage_WhenPngDecodesToNull_ReturnsNull()
    {
        var sut = BuildSender(new HttpClient(new Mock<HttpMessageHandler>().Object));
        var result = InvokeNormalizeImage(sut, CreateMalformedPngBytes());
        Assert.Null(result);
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

        var sut = BuildSender(new HttpClient(handler.Object), blob, store, logger);

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

        var sut = BuildSender(new HttpClient(handler.Object), blob, store);

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

        var sut = BuildSender(new HttpClient(handler.Object), blob, store);

        var result = await sut.SendAsync(new Post
        {
            Content = "hello",
            Image = ImageTestData.CreateValidJpeg()
        });

        Assert.False(result);
        store.Verify(x => x.SaveAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
    }
}
