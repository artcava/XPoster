using System.Net;
using System.Text;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using XPoster.Credentials;
using XPoster.Services;

namespace XPoster.Tests.Services;

public sealed class MetaPublishingServiceTests
{
    private static readonly InstagramCredentials Credentials = new()
    {
        InstagramAccountId = "17841400000000000",
        InstagramAccessToken = "test-access-token"
    };

    private static MetaPublishingService CreateSut(
        HttpResponseMessage responseMessage,
        HttpMethod expectedMethod,
        Action<HttpRequestMessage>? requestAssertion = null,
        Func<HttpRequestMessage, bool>? requestPredicate = null)
    {
        var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.Method == expectedMethod && (requestPredicate == null || requestPredicate(req))),
                ItExpr.IsAny<CancellationToken>())
            .Callback<HttpRequestMessage, CancellationToken>((req, _) => requestAssertion?.Invoke(req))
            .ReturnsAsync(responseMessage);

        var httpClient = new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri("https://graph.facebook.com/")
        };

        var httpClientFactory = new Mock<IHttpClientFactory>(MockBehavior.Strict);
        httpClientFactory.Setup(x => x.CreateClient("Instagram")).Returns(httpClient);

        return new MetaPublishingService(httpClientFactory.Object, Options.Create(Credentials), Mock.Of<ILogger<MetaPublishingService>>());
    }

    [Fact]
    public async Task GetContainerStatusAsync_WhenOk_ReturnsStatusCode()
    {
        var sut = CreateSut(
            new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("""{\"status_code\":\"FINISHED\",\"id\":\"17889615691921648\"}""", Encoding.UTF8, "application/json")
            },
            HttpMethod.Get,
            requestPredicate: req => req.RequestUri!.AbsoluteUri.Contains("fields=status_code", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public async Task PublishContainerAsync_WhenOk_ReturnsPublishId()
    {
        var sut = CreateSut(
            new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("""{"id":"publish-id-1"}""", Encoding.UTF8, "application/json")
            },
            HttpMethod.Post,
            requestPredicate: req => req.RequestUri!.AbsoluteUri.Contains("media_publish", StringComparison.OrdinalIgnoreCase));

        var result = await sut.PublishContainerAsync("creation-id-1", CancellationToken.None);

        Assert.Equal("publish-id-1", result);
    }

    [Fact]
    public async Task GetContainerStatusAsync_WhenHttpFails_Throws()
    {
        var sut = CreateSut(
            new HttpResponseMessage(HttpStatusCode.BadRequest),
            HttpMethod.Get);

        await Assert.ThrowsAsync<HttpRequestException>(() => sut.GetContainerStatusAsync("creation-id-1", CancellationToken.None));
    }

    [Fact]
    public async Task PublishContainerAsync_WhenRateLimited_Throws()
    {
        var sut = CreateSut(
            new HttpResponseMessage((HttpStatusCode)429),
            HttpMethod.Post,
            requestPredicate: req => req.RequestUri!.AbsoluteUri.Contains("media_publish", StringComparison.OrdinalIgnoreCase));

        await Assert.ThrowsAsync<HttpRequestException>(() => sut.PublishContainerAsync("creation-id-1", CancellationToken.None));
    }

    [Fact]
    public async Task PublishContainerAsync_WhenTokenIsUsed_AsQueryParameter()
    {
        HttpRequestMessage? captured = null;

        var sut = CreateSut(
            new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("""{"id":"publish-id-1"}""", Encoding.UTF8, "application/json")
            },
            HttpMethod.Post,
            requestAssertion: req => captured = req,
            requestPredicate: req => req.RequestUri!.Query.Contains("access_token=test-access-token", StringComparison.Ordinal));

        await sut.PublishContainerAsync("creation-id-1", CancellationToken.None);

        Assert.NotNull(captured);
        Assert.Contains("access_token=test-access-token", captured!.RequestUri!.Query);
        Assert.True(captured.Content == null);
    }
}
