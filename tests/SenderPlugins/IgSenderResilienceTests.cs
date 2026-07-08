using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using XPoster.Contracts;
using XPoster.Credentials;
using XPoster.Models;
using XPoster.SenderPlugins;
using XPoster.Tests.Helpers;

namespace XPoster.Tests.SenderPlugins;

/// <summary>
/// Resilience tests for verifying error handling when the Instagram Graph API returns transient failures.
/// </summary>
public class IgSenderResilienceTests
{
    private readonly Mock<ILogger<IgSender>> _loggerMock = new();
    private readonly Mock<IBlobStorageService> _blobStorageMock = new();
    private readonly Mock<IContainerStateStore> _containerStateMock = new();

    private IgSender BuildSender(IHttpClientFactory factory)
    {
        var creds = Options.Create(new InstagramCredentials
        {
            InstagramAccessToken = "fake_ig_token",
            InstagramAccountId = "9876543210"
        });

        return new IgSender(factory, creds, _loggerMock.Object, _blobStorageMock.Object, _containerStateMock.Object);
    }

    private static Post PostWithImage() =>
        new() { Content = "Caption", Image = ImageTestData.CreateValidJpeg() };

    private static Post PostWithoutImage() =>
        new() { Content = "Caption text only" };

    [Fact]
    public async Task SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi()
    {
        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new Exception("Should not be called"));

        var factoryMock = new Mock<IHttpClientFactory>();
        factoryMock.Setup(f => f.CreateClient("Instagram")).Returns(new HttpClient(handler.Object));

        Assert.False(await BuildSender(factoryMock.Object).SendAsync(PostWithoutImage()));
        handler.Protected().Verify(
            "SendAsync",
            Times.Never(),
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>());
    }

    [Fact]
    public async Task SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError()
    {
        var factory = new Mock<IHttpClientFactory>();
        factory.Setup(f => f.CreateClient("Instagram")).Returns(new HttpClient(new Mock<HttpMessageHandler>().Object));

        _blobStorageMock
            .Setup(x => x.UploadAsync(It.IsAny<byte[]>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new NotImplementedException());

        Assert.False(await BuildSender(factory.Object).SendAsync(PostWithImage()));
        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("Errore durante il caricamento dell'immagine su Blob Storage")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse()
    {
        var mock = new Mock<HttpMessageHandler>();
        mock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new HttpRequestException("Network error"));

        var factoryMock = new Mock<IHttpClientFactory>();
        factoryMock.Setup(f => f.CreateClient("Instagram")).Returns(new HttpClient(mock.Object));

        _blobStorageMock
            .Setup(x => x.UploadAsync(It.IsAny<byte[]>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(new BlobUploadResult(
                new Uri("https://storage.example.com/xposter-images/blob1.jpg?sig=abc"), "blob1.jpg")));

        Assert.False(await BuildSender(factoryMock.Object).SendAsync(PostWithImage()));
    }
}
