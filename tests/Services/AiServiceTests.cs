using System.Net;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using XPoster.Services;

namespace XPoster.Tests.Services;

/// <summary>
/// Unit tests for <see cref="AiService"/> using a mocked <see cref="HttpMessageHandler"/>.
/// No real HTTP calls are made.
/// </summary>
public class AiServiceTests
{
    private static AiService BuildService(HttpMessageHandler handler, out Mock<ILogger<AiService>> loggerMock)
    {
        loggerMock = new Mock<ILogger<AiService>>();
        var factory = new Mock<IHttpClientFactory>();
        var client = new HttpClient(handler);
        factory.Setup(f => f.CreateClient(It.IsAny<string>())).Returns(client);
        Environment.SetEnvironmentVariable("OPENAI_API_KEY", "fake-key");
        return new AiService(factory.Object, loggerMock.Object);
    }

    private static HttpMessageHandler MakeHandler(HttpStatusCode code, string json)
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
        return mock.Object;
    }

    private static string ChatCompletionJson(string content) =>
        "{\"choices\":[{\"message\":{\"content\":\"" + content + "\"}}]}";

    // ── GetSummaryAsync ──────────────────────────────────────────────────────

    [Fact]
    public async Task GetSummaryAsync_WhenTextAlreadyShort_ReturnsTextUnchanged()
    {
        var svc = BuildService(MakeHandler(HttpStatusCode.OK, ChatCompletionJson("short")), out _);
        var result = await svc.GetSummaryAsync("short text", 500);
        Assert.Equal("short text", result);
    }

    [Fact]
    public async Task GetSummaryAsync_WhenApiReturns200_ReturnsTrimmedContent()
    {
        var svc = BuildService(MakeHandler(HttpStatusCode.OK, ChatCompletionJson("summary result")), out _);
        var longText = new string('a', 300);
        var result = await svc.GetSummaryAsync(longText, 100);
        Assert.Equal("summary result", result);
    }

    [Fact]
    public async Task GetSummaryAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty()
    {
        var svc = BuildService(MakeHandler(HttpStatusCode.TooManyRequests, "{}"), out _);
        var result = await svc.GetSummaryAsync(new string('a', 300), 100);
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GetSummaryAsync_WhenApiReturnsError_ReturnsEmpty()
    {
        var svc = BuildService(MakeHandler(HttpStatusCode.InternalServerError, "{}"), out _);
        var result = await svc.GetSummaryAsync(new string('a', 300), 100);
        Assert.Equal(string.Empty, result);
    }

    // ── GetImagePromptAsync ──────────────────────────────────────────────────

    [Fact]
    public async Task GetImagePromptAsync_WhenApiReturns200_ReturnsTrimmedContent()
    {
        var svc = BuildService(MakeHandler(HttpStatusCode.OK, ChatCompletionJson("image prompt")), out _);
        var result = await svc.GetImagePromptAsync("some summary");
        Assert.Equal("image prompt", result);
    }

    [Fact]
    public async Task GetImagePromptAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty()
    {
        var svc = BuildService(MakeHandler(HttpStatusCode.TooManyRequests, "{}"), out _);
        var result = await svc.GetImagePromptAsync("some summary");
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GetImagePromptAsync_WhenApiReturnsError_ReturnsEmpty()
    {
        var svc = BuildService(MakeHandler(HttpStatusCode.BadRequest, "{}"), out _);
        var result = await svc.GetImagePromptAsync("some summary");
        Assert.Equal(string.Empty, result);
    }

    // ── GenerateImageAsync ───────────────────────────────────────────────────

    [Fact]
    public async Task GenerateImageAsync_WhenApiReturns200_ReturnsDecodedBytes()
    {
        var imageBytes = new byte[] { 1, 2, 3, 4 };
        var base64 = Convert.ToBase64String(imageBytes);
        var json = "{\"data\":[{\"b64_json\":\"" + base64 + "\"}]}";
        var svc = BuildService(MakeHandler(HttpStatusCode.OK, json), out _);
        var result = await svc.GenerateImageAsync("a prompt");
        Assert.Equal(imageBytes, result);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenApiReturnsError_ReturnsEmptyArray()
    {
        var svc = BuildService(MakeHandler(HttpStatusCode.BadRequest, "{}"), out _);
        var result = await svc.GenerateImageAsync("a prompt");
        Assert.Empty(result);
    }
}
