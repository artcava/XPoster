using System.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using XPoster.Models;
using XPoster.Services;

namespace XPoster.Tests.Services;

/// <summary>
/// Unit tests for <see cref="OpenAiService"/> using a mocked <see cref="HttpMessageHandler"/>.
/// No real HTTP calls are made.
/// </summary>
public class OpenAiServiceTests
{
    private static OpenAiService BuildService(HttpMessageHandler handler, out Mock<ILogger<OpenAiService>> loggerMock, OpenAiOptions? opts = null)
    {
        loggerMock = new Mock<ILogger<OpenAiService>>();
        var factory = new Mock<IHttpClientFactory>();
        var client = new HttpClient(handler);
        factory.Setup(f => f.CreateClient(It.IsAny<string>())).Returns(client);
        var options = Options.Create(opts ?? new OpenAiOptions { ApiKey = "fake-key" });
        return new OpenAiService(factory.Object, options, loggerMock.Object);
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

    private static Mock<HttpMessageHandler> MakeHandlerMock(HttpStatusCode code, string json)
    {
        var mock = new Mock<HttpMessageHandler>();
        mock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .Returns(() => Task.FromResult(new HttpResponseMessage(code)
            {
                Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json")
            }));
        return mock;
    }

    private static string ChatCompletionJson(string content) =>
        "{\"choices\":[{\"message\":{\"content\":\"" + content + "\"}}]}";

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

    [Fact]
    public async Task GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmpty()
    {
        var svc = BuildService(MakeHandler(HttpStatusCode.OK, "{\"choices\":[]}"), out _);
        var result = await svc.GetSummaryAsync(new string('a', 300), 100);
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GetSummaryAsync_WhenChoicesIsNull_ReturnsEmpty()
    {
        var svc = BuildService(MakeHandler(HttpStatusCode.OK, "{\"choices\":null}"), out _);
        var result = await svc.GetSummaryAsync(new string('a', 300), 100);
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GetSummaryAsync_WhenSummaryAlwaysTooLong_StopsAfterThreeAttempts()
    {
        var longResponse = new string('b', 200);
        var handler = MakeHandlerMock(HttpStatusCode.OK, ChatCompletionJson(longResponse));
        var svc = BuildService(handler.Object, out _);

        var result = await svc.GetSummaryAsync(new string('a', 300), 100);

        handler.Protected().Verify(
            "SendAsync",
            Times.Exactly(3),
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>());
        Assert.Equal(longResponse, result);
    }

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
    public async Task GetImagePromptAsync_WhenApiReturnsTooManyRequests_LogsInformation()
    {
        var svc = BuildService(MakeHandler(HttpStatusCode.TooManyRequests, "{}"), out var loggerMock);
        await svc.GetImagePromptAsync("some summary");

        loggerMock.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("429") || v.ToString()!.Contains("TooManyRequests")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task GetImagePromptAsync_WhenApiReturnsError_ReturnsEmpty()
    {
        var svc = BuildService(MakeHandler(HttpStatusCode.BadRequest, "{}"), out _);
        var result = await svc.GetImagePromptAsync("some summary");
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmpty()
    {
        var svc = BuildService(MakeHandler(HttpStatusCode.OK, "{\"choices\":[]}"), out _);
        var result = await svc.GetImagePromptAsync("some summary");
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmpty()
    {
        var svc = BuildService(MakeHandler(HttpStatusCode.OK, "{\"choices\":null}"), out _);
        var result = await svc.GetImagePromptAsync("some summary");
        Assert.Equal(string.Empty, result);
    }

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

    [Fact]
    public async Task GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyArray()
    {
        var svc = BuildService(MakeHandler(HttpStatusCode.TooManyRequests, "{}"), out _);
        var result = await svc.GenerateImageAsync("a prompt");
        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning()
    {
        var svc = BuildService(MakeHandler(HttpStatusCode.TooManyRequests, "{}"), out var loggerMock);

        await svc.GenerateImageAsync("a prompt");

        loggerMock.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) =>
                    v.ToString()!.Contains("OpenAI") &&
                    (v.ToString()!.Contains("429") || v.ToString()!.Contains("TooManyRequests"))),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyArray()
    {
        var svc = BuildService(MakeHandler(HttpStatusCode.OK, "NOT_JSON"), out _);
        var result = await svc.GenerateImageAsync("a prompt");
        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenDataArrayIsEmpty_ReturnsEmptyArray()
    {
        var svc = BuildService(MakeHandler(HttpStatusCode.OK, "{\"data\":[]}"), out _);
        var result = await svc.GenerateImageAsync("a prompt");
        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyArray()
    {
        var svc = BuildService(MakeHandler(HttpStatusCode.OK, "{\"data\":[{\"b64_json\":null}]}"), out _);
        var result = await svc.GenerateImageAsync("a prompt");
        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenHttpRequestExceptionThrown_ReturnsEmptyArray()
    {
        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new HttpRequestException("network failure"));

        var svc = BuildService(handler.Object, out _);

        var result = await svc.GenerateImageAsync("a prompt");

        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenHttpRequestExceptionThrown_LogsError()
    {
        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new HttpRequestException("network failure"));

        var svc = BuildService(handler.Object, out var loggerMock);

        await svc.GenerateImageAsync("a prompt");

        loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("OpenAI image generation HTTP request failed")),
                It.IsAny<HttpRequestException>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyArrayWithoutCallingApi()
    {
        var handler = MakeHandlerMock(HttpStatusCode.OK, "{}");
        var svc = BuildService(handler.Object, out _);

        var result = await svc.GenerateImageAsync(string.Empty);

        Assert.Empty(result);
        handler.Protected().Verify(
            "SendAsync",
            Times.Never(),
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>());
    }

    [Fact]
    public async Task GenerateImageAsync_WhenPromptIsEmpty_LogsWarning()
    {
        var handler = MakeHandlerMock(HttpStatusCode.OK, "{}");
        var svc = BuildService(handler.Object, out var loggerMock);

        await svc.GenerateImageAsync(string.Empty);

        loggerMock.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("empty or whitespace prompt")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyArrayWithoutCallingApi()
    {
        var handler = MakeHandlerMock(HttpStatusCode.OK, "{}");
        var svc = BuildService(handler.Object, out _);

        var result = await svc.GenerateImageAsync("   ");

        Assert.Empty(result);
        handler.Protected().Verify(
            "SendAsync",
            Times.Never(),
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>());
    }
}
