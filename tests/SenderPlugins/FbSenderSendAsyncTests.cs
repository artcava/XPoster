using System.Net;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using XPoster.Contracts;
using XPoster.Credentials;
using XPoster.Models;
using XPoster.SenderPlugins;

namespace XPoster.Tests.SenderPlugins;

public class FbSenderSendAsyncTests
{
    private readonly Mock<ILogger<FbSender>> _logger = new();
    private readonly Mock<IBlobStorageService> _blobStorage = new();

    private static IOptions<FacebookCredentials> BuildCreds() =>
        Options.Create(new FacebookCredentials
        {
            FacebookAccessToken = "test_token",
            FacebookPageId = "123456789"
        });

    private static IHttpClientFactory BuildFactory(HttpResponseMessage response)
    {
        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(response);

        var factory = new Mock<IHttpClientFactory>();
        factory.Setup(f => f.CreateClient("Facebook"))
            .Returns(new HttpClient(handler.Object));

        return factory.Object;
    }

    [Fact]
    public async Task SendAsync_WithNullPost_ReturnsFalseAndLogsWarning()
    {
        var sender = new FbSender(BuildFactory(new HttpResponseMessage(HttpStatusCode.OK)), BuildCreds(), _logger.Object, _blobStorage.Object);

        var result = await sender.SendAsync(null!);

        Assert.False(result);
        _logger.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task SendAsync_WithNullImage_PublishesTextOnly_ReturnsTrue()
    {
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent("{\"id\":\"post-123\"}")
        };

        var sender = new FbSender(BuildFactory(response), BuildCreds(), _logger.Object, _blobStorage.Object);

        var result = await sender.SendAsync(new Post { Content = "Hello Facebook", Image = null });

        Assert.True(result);
        _blobStorage.Verify(
            x => x.UploadAsync(It.IsAny<byte[]>(), It.IsAny<string>(), It.IsAny<CancellationToken>()),
            Times.Never);
    }

    [Fact]
    public async Task SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue()
    {
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent("{\"id\":\"post-123\"}")
        };

        var sender = new FbSender(BuildFactory(response), BuildCreds(), _logger.Object, _blobStorage.Object);

        var result = await sender.SendAsync(new Post { Content = "Hello Facebook", Image = Array.Empty<byte>() });

        Assert.True(result);
    }

    [Fact]
    public async Task SendAsync_WithCaptionLongerThanMax_StillPublishes_ReturnsTrue()
    {
        HttpRequestMessage? capturedRequest = null;

        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .Callback<HttpRequestMessage, CancellationToken>((req, _) => capturedRequest = req)
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"id\":\"post-123\"}")
            });

        var factory = new Mock<IHttpClientFactory>();
        factory.Setup(f => f.CreateClient("Facebook"))
            .Returns(new HttpClient(handler.Object));

        var sender = new FbSender(factory.Object, BuildCreds(), _logger.Object, _blobStorage.Object);

        var content = new string('a', 7000);
        var result = await sender.SendAsync(new Post { Content = content });

        Assert.True(result);
        Assert.NotNull(capturedRequest);
        Assert.Contains("/feed", capturedRequest!.RequestUri!.AbsoluteUri);
    }
}