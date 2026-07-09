using System.Net;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using XPoster.Contracts;
using XPoster.Credentials;
using XPoster.Models;
using XPoster.SenderPlugins;

namespace XPoster.Tests.SenderPlugins;

public class FbSenderResilienceTests
{
    private readonly Mock<ILogger<FbSender>> _logger = new();
    private readonly Mock<IBlobStorageService> _blobStorage = new();

    private static IOptions<FacebookCredentials> BuildCreds() =>
        Options.Create(new FacebookCredentials
        {
            FacebookAccessToken = "test_token",
            FacebookPageId = "123456789"
        });

    private static IHttpClientFactory BuildFactory(params (HttpStatusCode status, string body)[] responses)
    {
        var queue = new Queue<(HttpStatusCode status, string body)>(responses);

        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(() =>
            {
                var next = queue.Dequeue();
                return new HttpResponseMessage(next.status)
                {
                    Content = new StringContent(next.body)
                };
            });

        var factory = new Mock<IHttpClientFactory>();
        factory.Setup(f => f.CreateClient("Facebook"))
            .Returns(new HttpClient(handler.Object));

        return factory.Object;
    }

    [Fact]
    public async Task SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue()
    {
        var sender = new FbSender(
            BuildFactory((HttpStatusCode.OK, "{\"id\":\"text-post-1\"}")),
            BuildCreds(),
            _logger.Object,
            _blobStorage.Object);

        var result = await sender.SendAsync(new Post { Content = "Text post" });

        Assert.True(result);
    }

    [Fact]
    public async Task SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse()
    {
        var sender = new FbSender(
            BuildFactory((HttpStatusCode.OK, "{\"status\":\"ok\"}")),
            BuildCreds(),
            _logger.Object,
            _blobStorage.Object);

        var result = await sender.SendAsync(new Post { Content = "Text post" });

        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse()
    {
        var sender = new FbSender(
            BuildFactory((HttpStatusCode.OK, "{\"id\":\"\"}")),
            BuildCreds(),
            _logger.Object,
            _blobStorage.Object);

        var result = await sender.SendAsync(new Post { Content = "Text post" });

        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WhenFacebookReturns503_ReturnsFalseAndLogsError()
    {
        var sender = new FbSender(
            BuildFactory((HttpStatusCode.ServiceUnavailable, "{\"message\":\"Service Unavailable\"}")),
            BuildCreds(),
            _logger.Object,
            _blobStorage.Object);

        var result = await sender.SendAsync(new Post { Content = "Text post" });

        Assert.False(result);
        _logger.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.AtLeastOnce);
    }

    [Fact]
    public async Task SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse()
    {
        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new HttpRequestException("Connection refused"));

        var factory = new Mock<IHttpClientFactory>();
        factory.Setup(f => f.CreateClient("Facebook"))
            .Returns(new HttpClient(handler.Object));

        var sender = new FbSender(factory.Object, BuildCreds(), _logger.Object, _blobStorage.Object);

        var result = await sender.SendAsync(new Post { Content = "Text post" });

        Assert.False(result);
    }
}