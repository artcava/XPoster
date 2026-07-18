using System.Net;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using XPoster.Models;
using XPoster.Services;

namespace XPoster.Tests.Services;

/// <summary>
/// Unit tests for <see cref="OpenAiService"/> using a mocked <see cref="HttpMessageHandler"/>.
/// No real HTTP calls are made.
/// All prompt data is supplied via <see cref="PromptRequest"/> / <see cref="ImagePromptRequest"/>;
/// no prompt fields are read from <see cref="OpenAiOptions"/>.
/// </summary>
public class OpenAiServiceTests
{
    // ---------------------------------------------------------------------------
    // Helpers
    // ---------------------------------------------------------------------------

    private static OpenAiService BuildService(
        HttpMessageHandler handler,
        out Mock<ILogger<OpenAiService>> loggerMock,
        OpenAiOptions? opts = null)
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

    /// <summary>Builds a minimal <see cref="PromptRequest"/> suitable for text generation tests.</summary>
    private static PromptRequest BuildPromptRequest(
        string inputText = "some input",
        int? maxOutputLength = null) =>
        new()
        {
            InputText = inputText,
            SystemPromptTemplate = "You are a helpful assistant.",
            UserPromptTemplate = "Summarise: {Text}",
            InputTextLabel = "{Text}",
            MaxOutputLength = maxOutputLength,
            Temperature = 0.7,
            MaxTokenBudget = 500
        };

    /// <summary>Builds a minimal <see cref="ImagePromptRequest"/> suitable for image generation tests.</summary>
    private static ImagePromptRequest BuildImagePromptRequest(
        string inputText = "a vivid scene") =>
        new()
        {
            InputText = inputText,
            SystemPromptTemplate = "Generate an image.",
            UserPromptTemplate = "{Text}",
            InputTextLabel = "{Text}",
            ImageQuantity = 1,
            ImageSize = "1024x1024"
        };

    // ---------------------------------------------------------------------------
    // GenerateTextAsync — success paths
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task GenerateTextAsync_WhenApiReturns200_ReturnsTrimmedContent()
    {
        var svc = BuildService(MakeHandler(HttpStatusCode.OK, ChatCompletionJson("summary result")), out _);
        var request = BuildPromptRequest(inputText: new string('a', 300));

        var result = await svc.GenerateTextAsync(request);

        Assert.Equal("summary result", result);
    }

    [Fact]
    public async Task GenerateTextAsync_WhenOutputFitsWithinMaxOutputLength_ReturnsSingleCallResult()
    {
        var handler = MakeHandlerMock(HttpStatusCode.OK, ChatCompletionJson("short"));
        var svc = BuildService(handler.Object, out _);
        var request = BuildPromptRequest(maxOutputLength: 100);

        var result = await svc.GenerateTextAsync(request);

        // Response is 5 chars < 100: only one HTTP call expected
        handler.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>());
        Assert.Equal("short", result);
    }

    // ---------------------------------------------------------------------------
    // GenerateTextAsync — retry loop
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task GenerateTextAsync_WhenResponseAlwaysExceedsMaxOutputLength_StopsAfterThreeAttempts()
    {
        var longResponse = new string('b', 200);
        var handler = MakeHandlerMock(HttpStatusCode.OK, ChatCompletionJson(longResponse));
        var svc = BuildService(handler.Object, out _);
        var request = BuildPromptRequest(inputText: new string('a', 300), maxOutputLength: 100);

        var result = await svc.GenerateTextAsync(request);

        handler.Protected().Verify(
            "SendAsync",
            Times.Exactly(3),
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>());
        Assert.Equal(longResponse, result);
    }

    [Fact]
    public async Task GenerateTextAsync_WhenNoMaxOutputLength_DoesNotRetry()
    {
        var handler = MakeHandlerMock(HttpStatusCode.OK, ChatCompletionJson(new string('b', 500)));
        var svc = BuildService(handler.Object, out _);
        var request = BuildPromptRequest(maxOutputLength: null);

        await svc.GenerateTextAsync(request);

        // Without MaxOutputLength there is no length constraint; no retry expected
        handler.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>());
    }

    // ---------------------------------------------------------------------------
    // GenerateTextAsync — error / edge cases
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task GenerateTextAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty()
    {
        var svc = BuildService(MakeHandler(HttpStatusCode.TooManyRequests, "{}"), out _);
        var result = await svc.GenerateTextAsync(BuildPromptRequest());
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GenerateTextAsync_WhenApiReturnsInternalServerError_ReturnsEmpty()
    {
        var svc = BuildService(MakeHandler(HttpStatusCode.InternalServerError, "{}"), out _);
        var result = await svc.GenerateTextAsync(BuildPromptRequest());
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GenerateTextAsync_WhenChoicesArrayIsEmpty_ReturnsEmpty()
    {
        var svc = BuildService(MakeHandler(HttpStatusCode.OK, "{\"choices\":[]}"), out _);
        var result = await svc.GenerateTextAsync(BuildPromptRequest());
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GenerateTextAsync_WhenChoicesIsNull_ReturnsEmpty()
    {
        var svc = BuildService(MakeHandler(HttpStatusCode.OK, "{\"choices\":null}"), out _);
        var result = await svc.GenerateTextAsync(BuildPromptRequest());
        Assert.Equal(string.Empty, result);
    }

    // ---------------------------------------------------------------------------
    // GenerateTextAsync — prompt fields come from request, not from options
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task GenerateTextAsync_UsesSystemPromptTemplateFromRequest()
    {
        // Verifies that the payload sent to the API uses the system prompt from the request.
        // The handler captures the request body for inspection.
        string? capturedBody = null;
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .Returns(async (HttpRequestMessage req, CancellationToken _) =>
            {
                capturedBody = await req.Content!.ReadAsStringAsync();
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(
                        ChatCompletionJson("ok"),
                        System.Text.Encoding.UTF8,
                        "application/json")
                };
            });

        var svc = BuildService(handlerMock.Object, out _);
        var request = new PromptRequest
        {
            InputText = "hello",
            SystemPromptTemplate = "UNIQUE_SYSTEM_PROMPT_MARKER",
            UserPromptTemplate = "{Text}",
            InputTextLabel = "{Text}"
        };

        await svc.GenerateTextAsync(request);

        Assert.NotNull(capturedBody);
        Assert.Contains("UNIQUE_SYSTEM_PROMPT_MARKER", capturedBody);
    }

    [Fact]
    public async Task GenerateTextAsync_ReplacesInputTextLabelInUserPromptTemplate()
    {
        string? capturedBody = null;
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .Returns(async (HttpRequestMessage req, CancellationToken _) =>
            {
                capturedBody = await req.Content!.ReadAsStringAsync();
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(
                        ChatCompletionJson("ok"),
                        System.Text.Encoding.UTF8,
                        "application/json")
                };
            });

        var svc = BuildService(handlerMock.Object, out _);
        var request = new PromptRequest
        {
            InputText = "ACTUAL_CONTENT",
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "Summarise: {InputText}",
            InputTextLabel = "{InputText}"
        };

        await svc.GenerateTextAsync(request);

        Assert.NotNull(capturedBody);
        Assert.Contains("ACTUAL_CONTENT", capturedBody);
        Assert.DoesNotContain("{InputText}", capturedBody);
    }

    // ---------------------------------------------------------------------------
    // GenerateImageAsync — success paths
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task GenerateImageAsync_WhenApiReturns200_ReturnsDecodedBytes()
    {
        var imageBytes = new byte[] { 1, 2, 3, 4 };
        var base64 = Convert.ToBase64String(imageBytes);
        var json = "{\"data\":[{\"b64_json\":\"" + base64 + "\"}]}";
        var svc = BuildService(MakeHandler(HttpStatusCode.OK, json), out _);

        var result = await svc.GenerateImageAsync(BuildImagePromptRequest());

        Assert.Equal(imageBytes, result);
    }

    // ---------------------------------------------------------------------------
    // GenerateImageAsync — guard: empty / whitespace prompt
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyArrayWithoutCallingApi()
    {
        var handler = MakeHandlerMock(HttpStatusCode.OK, "{}");
        var svc = BuildService(handler.Object, out _);

        var result = await svc.GenerateImageAsync(BuildImagePromptRequest(inputText: string.Empty));

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

        await svc.GenerateImageAsync(BuildImagePromptRequest(inputText: string.Empty));

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

        var result = await svc.GenerateImageAsync(BuildImagePromptRequest(inputText: "   "));

        Assert.Empty(result);
        handler.Protected().Verify(
            "SendAsync",
            Times.Never(),
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>());
    }

    // ---------------------------------------------------------------------------
    // GenerateImageAsync — error / edge cases
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task GenerateImageAsync_WhenApiReturnsError_ReturnsEmptyArray()
    {
        var svc = BuildService(MakeHandler(HttpStatusCode.BadRequest, "{}"), out _);
        var result = await svc.GenerateImageAsync(BuildImagePromptRequest());
        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyArray()
    {
        var svc = BuildService(MakeHandler(HttpStatusCode.TooManyRequests, "{}"), out _);
        var result = await svc.GenerateImageAsync(BuildImagePromptRequest());
        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning()
    {
        var svc = BuildService(MakeHandler(HttpStatusCode.TooManyRequests, "{}"), out var loggerMock);

        await svc.GenerateImageAsync(BuildImagePromptRequest());

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
        var result = await svc.GenerateImageAsync(BuildImagePromptRequest());
        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenDataArrayIsEmpty_ReturnsEmptyArray()
    {
        var svc = BuildService(MakeHandler(HttpStatusCode.OK, "{\"data\":[]}"), out _);
        var result = await svc.GenerateImageAsync(BuildImagePromptRequest());
        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyArray()
    {
        var svc = BuildService(
            MakeHandler(HttpStatusCode.OK, "{\"data\":[{\"b64_json\":null}]}"),
            out _);
        var result = await svc.GenerateImageAsync(BuildImagePromptRequest());
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

        var result = await svc.GenerateImageAsync(BuildImagePromptRequest());

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

        await svc.GenerateImageAsync(BuildImagePromptRequest());

        loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("OpenAI image generation HTTP request failed")),
                It.IsAny<HttpRequestException>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    // ---------------------------------------------------------------------------
    // GenerateImageAsync — ImagePromptRequest fields forwarded to payload
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task GenerateImageAsync_UsesQuantityAndSizeFromRequest()
    {
        string? capturedBody = null;
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .Returns(async (HttpRequestMessage req, CancellationToken _) =>
            {
                capturedBody = await req.Content!.ReadAsStringAsync();
                var imageBytes = new byte[] { 9, 8, 7 };
                var json = "{\"data\":[{\"b64_json\":\"" + Convert.ToBase64String(imageBytes) + "\"}]}";
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json")
                };
            });

        var svc = BuildService(handlerMock.Object, out _);
        var request = new ImagePromptRequest
        {
            InputText = "a scene",
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "{Text}",
            InputTextLabel = "{Text}",
            ImageQuantity = 2,
            ImageSize = "512x512"
        };

        await svc.GenerateImageAsync(request);

        Assert.NotNull(capturedBody);
        Assert.Contains("512x512", capturedBody);
    }
}
