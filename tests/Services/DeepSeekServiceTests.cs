using System.Net;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using XPoster.Models;
using XPoster.Services;

namespace XPoster.Tests.Services;

public class DeepSeekServiceTests
{
    private static DeepSeekService BuildService(
        HttpMessageHandler handler,
        out Mock<ILogger<DeepSeekService>> loggerMock,
        DeepSeekOptions? opts = null)
    {
        loggerMock = new Mock<ILogger<DeepSeekService>>();
        var factory = new Mock<IHttpClientFactory>();
        factory.Setup(f => f.CreateClient(It.IsAny<string>()))
               .Returns(new HttpClient(handler));

        var options = Options.Create(opts ?? new DeepSeekOptions
        {
            Endpoint       = "https://api.deepseek.com",
            ApiKey         = "fake-key",
            DeploymentName = "deepseek-chat",
            SummarySystemPromptTemplate  = "Keep under {MaxChars} chars.",
            SummaryUserPromptTemplate    = "Summarize: {Text}",
            ImagePromptSystemTemplate    = "You generate image prompts.",
            ImagePromptUserTemplate      = "Image for: {Summary}"
        });

        return new DeepSeekService(factory.Object, options, loggerMock.Object);
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
