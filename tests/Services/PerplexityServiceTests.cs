using System.Net;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using XPoster.Models;
using XPoster.Services;

namespace XPoster.Tests.Services;

public class PerplexityServiceTests
{
    private static PerplexityService BuildService(
        HttpMessageHandler handler,
        out Mock<ILogger<PerplexityService>> loggerMock,
        PerplexityOptions? opts = null)
    {
        loggerMock = new Mock<ILogger<PerplexityService>>();
        var factory = new Mock<IHttpClientFactory>();
        factory.Setup(f => f.CreateClient(It.IsAny<string>()))
               .Returns(new HttpClient(handler));

        var options = Options.Create(opts ?? new PerplexityOptions
        {
            Endpoint                     = "https://api.perplexity.ai",
            ApiKey                       = "fake-key",
            DeploymentName               = "sonar",
            SummarySystemPromptTemplate  = "Keep under {MaxChars} chars.",
            SummaryUserPromptTemplate    = "Summarize: {Text}",
            ImagePromptSystemTemplate    = "You generate image prompts.",
            ImagePromptUserTemplate      = "Image for: {Summary}"
        });

        return new PerplexityService(factory.Object, options, loggerMock.Object);
    }

    private static Mock<HttpMessageHandler> MakeHandlerMock(HttpStatusCode code, string json)
    {
        var mock = new Mock<HttpMessageHandler>();
        mock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(code)
            {
                Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json")
            });
        return mock;
    }

    /// <summary>
    /// Returns a handler mock that replies with <paramref name="responses"/> in sequence,
    /// one per SendAsync call. Useful to exercise the retry loop in GetSummaryAsync.
    /// </summary>
    private static Mock<HttpMessageHandler> MakeSequentialHandlerMock(
        IEnumerable<(HttpStatusCode code, string json)> responses)
    {
        var mock    = new Mock<HttpMessageHandler>();
        var setup   = mock.Protected()
            .SetupSequence<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>());

        foreach (var (code, json) in responses)
        {
            setup.ReturnsAsync(new HttpResponseMessage(code)
            {
                Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json")
            });
        }

        return mock;
    }

    private static string ChatCompletionJson(string content) =>
        "{\"choices\":[{\"message\":{\"content\":\"" + content + "\"}}]}";

    // ── GetSummaryAsync ──────────────────────────────────────────────────────

    [Fact]
    public async Task GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsContent()
    {
        var handler = MakeHandlerMock(HttpStatusCode.OK, ChatCompletionJson("short summary"));
        var svc = BuildService(handler.Object, out _);

        var result = await svc.GetSummaryAsync(new string('a', 300), 100);

        Assert.Equal("short summary", result);
        handler.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.Is<HttpRequestMessage>(r =>
                r.Method == HttpMethod.Post &&
                r.RequestUri!.AbsolutePath.Contains("/chat/completions", StringComparison.Ordinal)),
            ItExpr.IsAny<CancellationToken>());
    }

    [Fact]
    public async Task GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi()
    {
        var handler = MakeHandlerMock(HttpStatusCode.OK, ChatCompletionJson("never returned"));
        var svc = BuildService(handler.Object, out _);

        var result = await svc.GetSummaryAsync("short", 100);

        Assert.Equal("short", result);
        handler.Protected().Verify(
            "SendAsync",
            Times.Never(),
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>());
    }

    [Fact]
    public async Task GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.TooManyRequests, "{}").Object, out _);

        var result = await svc.GetSummaryAsync(new string('a', 300), 100);

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.InternalServerError, "{}").Object, out _);

        var result = await svc.GetSummaryAsync(new string('a', 300), 100);

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{\"choices\":[]}").Object, out _);

        var result = await svc.GetSummaryAsync(new string('a', 300), 100);

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{\"choices\":null}").Object, out _);

        var result = await svc.GetSummaryAsync(new string('a', 300), 100);

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GetSummaryAsync_WhenFirstResponseStillTooLong_RetriesAndReturnsSecondResponse()
    {
        // Arrange: first call returns a string still longer than the limit (200 chars),
        // second call returns a short string that satisfies the while condition.
        const int limit       = 100;
        var firstResponse     = new string('b', 200);  // still > 100 → triggers second iteration
        var secondResponse    = "final short summary";  // < 100 → loop exits

        var handler = MakeSequentialHandlerMock(new[]
        {
            (HttpStatusCode.OK, ChatCompletionJson(firstResponse)),
            (HttpStatusCode.OK, ChatCompletionJson(secondResponse))
        });
        var svc = BuildService(handler.Object, out _);

        // Act
        var result = await svc.GetSummaryAsync(new string('a', 300), limit);

        // Assert: two HTTP calls were made and the last returned content is propagated
        Assert.Equal(secondResponse, result);
        handler.Protected().Verify(
            "SendAsync",
            Times.Exactly(2),
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>());
    }

    [Fact]
    public async Task GetSummaryAsync_WhenTextRemainsLongAfterMaxRetries_ReturnsLastApiContent()
    {
        // Arrange: all three API responses return text that is still longer than the limit.
        // After tries > 2 the while exits and the last assigned value of `text` is returned.
        const int limit    = 10;
        var longResponse   = new string('c', 50); // always > 10

        var handler = MakeSequentialHandlerMock(new[]
        {
            (HttpStatusCode.OK, ChatCompletionJson(longResponse)),
            (HttpStatusCode.OK, ChatCompletionJson(longResponse)),
            (HttpStatusCode.OK, ChatCompletionJson(longResponse))
        });
        var svc = BuildService(handler.Object, out _);

        // Act
        var result = await svc.GetSummaryAsync(new string('a', 100), limit);

        // Assert: the loop ran exactly 3 times (tries 1, 2, 3 where tries <= 2 means max index 2)
        // and the last content from the API is returned as-is.
        Assert.Equal(longResponse, result);
        handler.Protected().Verify(
            "SendAsync",
            Times.Exactly(3),
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>());
    }

    // ── GetImagePromptAsync ──────────────────────────────────────────────────

    [Fact]
    public async Task GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, ChatCompletionJson("a vivid prompt")).Object, out _);

        var result = await svc.GetImagePromptAsync("summary text");

        Assert.Equal("a vivid prompt", result);
    }

    [Fact]
    public async Task GetImagePromptAsync_WhenApiReturns429_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.TooManyRequests, "{}").Object, out _);

        var result = await svc.GetImagePromptAsync("summary");

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GetImagePromptAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.BadGateway, "{}").Object, out _);

        var result = await svc.GetImagePromptAsync("summary");

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{\"choices\":[]}").Object, out _);

        var result = await svc.GetImagePromptAsync("summary text");

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{\"choices\":null}").Object, out _);

        var result = await svc.GetImagePromptAsync("summary text");

        Assert.Equal(string.Empty, result);
    }
}
