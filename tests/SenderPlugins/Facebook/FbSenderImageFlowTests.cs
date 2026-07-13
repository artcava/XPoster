using System.Net;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using SkiaSharp;
using XPoster.Contracts;
using XPoster.Credentials;
using XPoster.Models;
using XPoster.SenderPlugins;

namespace XPoster.Tests.SenderPlugins;

public class FbSenderImageFlowTests
{
    private readonly Mock<ILogger<FbSender>> _logger = new();
    private readonly Mock<IBlobStorageService> _blobStorage = new();

    private static IOptions<FacebookCredentials> BuildCreds() =>
        Options.Create(new FacebookCredentials
        {
            FacebookAccessToken = "test_token",
            FacebookPageId = "123456789"
        });

    private static byte[] InvalidImageBytes() => new byte[] { 0x01, 0x02, 0x03, 0x04 };

    private static byte[] CreateValidJpegBytes()
    {
        using var bitmap = new SKBitmap(10, 10);
        using var canvas = new SKCanvas(bitmap);
        canvas.Clear(SKColors.Blue);

        using var image = SKImage.FromBitmap(bitmap);
        using var data = image.Encode(SKEncodedImageFormat.Jpeg, 90);

        return data.ToArray();
    }

    private static IHttpClientFactory BuildFactory(Func<HttpRequestMessage, HttpResponseMessage> responseFactory)
    {
        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync((HttpRequestMessage req, CancellationToken _) => responseFactory(req));

        var factory = new Mock<IHttpClientFactory>();
        factory.Setup(f => f.CreateClient("Facebook"))
            .Returns(new HttpClient(handler.Object));

        return factory.Object;
    }

    [Fact]
    public async Task SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob()
    {
        _blobStorage.Setup(x => x.UploadAsync(It.IsAny<byte[]>(), "image/jpeg", It.IsAny<CancellationToken>()))
            .ReturnsAsync(new BlobUploadResult(new Uri("https://example.com/blob.jpg"), "blob-1.jpg"));

        _blobStorage.Setup(x => x.DeleteAsync("blob-1.jpg", It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var factory = BuildFactory(req =>
            new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"id\":\"photo-post-123\"}")
            });

        var sender = new FbSender(factory, BuildCreds(), _logger.Object, _blobStorage.Object);

        var result = await sender.SendAsync(new Post { Content = "Photo post", Image = CreateValidJpegBytes() });

        Assert.True(result);
        _blobStorage.Verify(x => x.UploadAsync(It.IsAny<byte[]>(), "image/jpeg", It.IsAny<CancellationToken>()), Times.Once);
        _blobStorage.Verify(x => x.DeleteAsync("blob-1.jpg", It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly()
    {
        HttpRequestMessage? capturedRequest = null;

        var factory = BuildFactory(req =>
        {
            capturedRequest = req;
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"id\":\"text-post-123\"}")
            };
        });

        var sender = new FbSender(factory, BuildCreds(), _logger.Object, _blobStorage.Object);

        var result = await sender.SendAsync(new Post { Content = "Fallback text", Image = InvalidImageBytes() });

        Assert.True(result);
        Assert.NotNull(capturedRequest);
        Assert.Contains("/feed", capturedRequest!.RequestUri!.AbsoluteUri);
        _blobStorage.Verify(x => x.UploadAsync(It.IsAny<byte[]>(), It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task SendAsync_WhenUploadThrows_FallsBackToTextOnly()
    {
        _blobStorage.Setup(x => x.UploadAsync(It.IsAny<byte[]>(), "image/jpeg", It.IsAny<CancellationToken>()))
            .ThrowsAsync(new InvalidOperationException("upload failed"));

        HttpRequestMessage? capturedRequest = null;
        var factory = BuildFactory(req =>
        {
            capturedRequest = req;
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"id\":\"text-post-123\"}")
            };
        });

        var sender = new FbSender(factory, BuildCreds(), _logger.Object, _blobStorage.Object);

        var result = await sender.SendAsync(new Post { Content = "Fallback text", Image = CreateValidJpegBytes() });

        Assert.True(result);
        Assert.NotNull(capturedRequest);
        Assert.Contains("/feed", capturedRequest!.RequestUri!.AbsoluteUri);
    }

    [Fact]
    public async Task SendAsync_WhenPhotoPublishThrows_FallsBackToTextOnly()
    {
        _blobStorage.Setup(x => x.UploadAsync(It.IsAny<byte[]>(), "image/jpeg", It.IsAny<CancellationToken>()))
            .ReturnsAsync(new BlobUploadResult(new Uri("https://example.com/blob.jpg"), "blob-1.jpg"));

        var firstCall = true;
        var factory = BuildFactory(req =>
        {
            if (firstCall && req.RequestUri!.AbsoluteUri.Contains("/photos"))
            {
                firstCall = false;
                throw new HttpRequestException("facebook failed");
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"id\":\"text-post-123\"}")
            };
        });

        var sender = new FbSender(factory, BuildCreds(), _logger.Object, _blobStorage.Object);

        var result = await sender.SendAsync(new Post { Content = "Fallback after photo failure", Image = CreateValidJpegBytes() });

        Assert.True(result);
        _blobStorage.Verify(x => x.DeleteAsync("blob-1.jpg", It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue()
    {
        _blobStorage.Setup(x => x.UploadAsync(It.IsAny<byte[]>(), "image/jpeg", It.IsAny<CancellationToken>()))
            .ReturnsAsync(new BlobUploadResult(new Uri("https://example.com/blob.jpg"), "blob-1.jpg"));

        _blobStorage.Setup(x => x.DeleteAsync("blob-1.jpg", It.IsAny<CancellationToken>()))
            .ThrowsAsync(new InvalidOperationException("delete failed"));

        var factory = BuildFactory(_ => new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent("{\"id\":\"photo-post-123\"}")
        });

        var sender = new FbSender(factory, BuildCreds(), _logger.Object, _blobStorage.Object);

        var result = await sender.SendAsync(new Post { Content = "Photo post", Image = CreateValidJpegBytes() });

        Assert.True(result);
        _blobStorage.Verify(x => x.DeleteAsync("blob-1.jpg", It.IsAny<CancellationToken>()), Times.Once);
        _logger.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.AtLeastOnce);
    }
}