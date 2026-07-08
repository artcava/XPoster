using System.Net;
using System.Text;
using System.Text.Json;
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
        Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> sendAsync,
        Mock<ILogger<MetaPublishingService>>? loggerMock = null)
    {
        var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .Returns(sendAsync);

        var httpClient = new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri("https://graph.facebook.com/")
        };

        var httpClientFactory = new Mock<IHttpClientFactory>(MockBehavior.Strict);
        httpClientFactory.Setup(x => x.CreateClient("Instagram")).Returns(httpClient);

        return new MetaPublishingService(
            httpClientFactory.Object,
            Options.Create(Credentials),
            (loggerMock ?? new Mock<ILogger<MetaPublishingService>>()).Object);
    }

    [Fact]
    public async Task GetContainerStatusAsync_WhenOk_ReturnsStatusCode()
    {
        HttpRequestMessage? captured = null;
        var sut = CreateSut((req, _) =>
        {
            captured = req;
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("""{"status_code":"FINISHED","id":"17889615691921648"}""", Encoding.UTF8, "application/json")
            });
        });

        var result = await sut.GetContainerStatusAsync("creation-id-1", CancellationToken.None);

        Assert.Equal("FINISHED", result);
        Assert.NotNull(captured);
        Assert.Equal(HttpMethod.Get, captured!.Method);
        Assert.Contains("fields=status_code", captured.RequestUri!.AbsoluteUri, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task GetContainerStatusAsync_WhenStatusInNestedField_ReturnsCode()
    {
        var sut = CreateSut((_, _) =>
            Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("""{"status":{"code":"IN_PROGRESS"}}""", Encoding.UTF8, "application/json")
            }));

        var result = await sut.GetContainerStatusAsync("creation-id-1", CancellationToken.None);

        Assert.Equal("IN_PROGRESS", result);
    }

    [Fact]
    public async Task GetContainerStatusAsync_WhenNotFound_ThrowsHttpRequestException()
    {
        var sut = CreateSut((_, _) =>
            Task.FromResult(new HttpResponseMessage(HttpStatusCode.NotFound)));

        var ex = await Assert.ThrowsAsync<HttpRequestException>(() =>
            sut.GetContainerStatusAsync("creation-id-1", CancellationToken.None));

        Assert.Equal(HttpStatusCode.NotFound, ex.StatusCode);
    }

    [Fact]
    public async Task GetContainerStatusAsync_WhenCancelled_ThrowsTaskCanceledException()
    {
        var cts = new CancellationTokenSource();
        cts.Cancel();

        var sut = CreateSut((_, ct) => Task.FromCanceled<HttpResponseMessage>(ct));

        await Assert.ThrowsAsync<TaskCanceledException>(() =>
            sut.GetContainerStatusAsync("creation-id-1", cts.Token));
    }

    [Fact]
    public async Task GetContainerStatusAsync_WhenResponseBodyIsEmpty_ThrowsJsonException()
    {
        var sut = CreateSut((_, _) =>
            Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Empty, Encoding.UTF8, "application/json")
            }));

        await Assert.ThrowsAsync<JsonException>(() =>
            sut.GetContainerStatusAsync("creation-id-1", CancellationToken.None));
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public async Task GetContainerStatusAsync_WithEmptyCreationId_ThrowsArgumentException(string creationId)
    {
        var sut = CreateSut((_, _) =>
            Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("""{"status_code":"FINISHED"}""", Encoding.UTF8, "application/json")
            }));

        await Assert.ThrowsAsync<ArgumentException>(() =>
            sut.GetContainerStatusAsync(creationId, CancellationToken.None));
    }

    [Fact]
    public async Task PublishContainerAsync_WhenOk_ReturnsPublishId()
    {
        HttpRequestMessage? captured = null;
        var sut = CreateSut((req, _) =>
        {
            captured = req;
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("""{"id":"publish-id-1"}""", Encoding.UTF8, "application/json")
            });
        });

        var result = await sut.PublishContainerAsync("creation-id-1", CancellationToken.None);

        Assert.Equal("publish-id-1", result);
        Assert.NotNull(captured);
        Assert.Equal(HttpMethod.Post, captured!.Method);
        Assert.Contains("media_publish", captured.RequestUri!.AbsoluteUri, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("access_token=test-access-token", captured.RequestUri.Query);
        Assert.True(captured.Content == null);
    }

    [Fact]
    public async Task PublishContainerAsync_WhenRateLimited_Throws()
    {
        var sut = CreateSut((_, _) =>
            Task.FromResult(new HttpResponseMessage((HttpStatusCode)429)));

        var ex = await Assert.ThrowsAsync<HttpRequestException>(() =>
            sut.PublishContainerAsync("creation-id-1", CancellationToken.None));

        Assert.Equal((HttpStatusCode)429, ex.StatusCode);
    }

    [Fact]
    public async Task PublishContainerAsync_WhenCancelled_ThrowsTaskCanceledException()
    {
        var cts = new CancellationTokenSource();
        cts.Cancel();

        var sut = CreateSut((_, ct) => Task.FromCanceled<HttpResponseMessage>(ct));

        await Assert.ThrowsAsync<TaskCanceledException>(() =>
            sut.PublishContainerAsync("creation-id-1", cts.Token));
    }

    [Fact]
    public async Task PublishContainerAsync_WhenResponseBodyIsNull_ThrowsJsonException()
    {
        var sut = CreateSut((_, _) =>
            Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Empty, Encoding.UTF8, "application/json")
            }));

        await Assert.ThrowsAsync<JsonException>(() =>
            sut.PublishContainerAsync("creation-id-1", CancellationToken.None));
    }

    [Fact]
    public async Task PublishContainerAsync_WhenIdIsNull_ReturnsEmptyString()
    {
        var sut = CreateSut((_, _) =>
            Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{}", Encoding.UTF8, "application/json")
            }));

        var result = await sut.PublishContainerAsync("creation-id-1", CancellationToken.None);

        Assert.Equal(string.Empty, result);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public async Task PublishContainerAsync_WithWhitespaceCreationId_ThrowsArgumentException(string creationId)
    {
        var sut = CreateSut((_, _) =>
            Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("""{"id":"publish-id-1"}""", Encoding.UTF8, "application/json")
            }));

        await Assert.ThrowsAsync<ArgumentException>(() =>
            sut.PublishContainerAsync(creationId, CancellationToken.None));
    }
}
