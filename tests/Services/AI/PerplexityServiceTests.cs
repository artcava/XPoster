using System.Net;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using XPoster.Models;
using XPoster.Services;

namespace XPoster.Tests.Services;

public class PerplexityServiceTests
{
    // ── Helpers ──────────────────────────────────────────────────────────────

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
            Endpoint = "https://api.perplexity.ai",
            ApiKey = "fake-key",
            DeploymentName = "sonar"
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
    /// one per SendAsync call. Useful to exercise the retry loop in GenerateTextAsync.
    /// </summary>
    private static Mock<HttpMessageHandler> MakeSequentialHandlerMock(
        IEnumerable<(HttpStatusCode code, string json)> responses)
    {
        var mock = new Mock<HttpMessageHandler>();
        var setup = mock.Protected()
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

    /// <summary>
    /// Builds a minimal <see cref="PromptRequest"/> for summary-style calls.
    /// </summary>
    private static PromptRequest BuildSummaryRequest(
        string inputText,
        int? maxOutputLength = null) =>
        new()
        {
            InputText = inputText,
            SystemPromptTemplate = "Keep under {MaxChars} chars.",
            UserPromptTemplate = "Summarize: {Text}",
            InputTextLabel = "{Text}",
            MaxOutputLength = maxOutputLength
        };

    /// <summary>
    /// Builds a minimal <see cref="PromptRequest"/> for image-prompt-derivation calls.
    /// </summary>
    private static PromptRequest BuildImagePromptRequest(string inputText) =>
        new()
        {
            InputText = inputText,
            SystemPromptTemplate = "You generate image prompts.",
            UserPromptTemplate = "Image for: {Summary}",
            InputTextLabel = "{Summary}"
        };

    // ── GenerateTextAsync — summary role ─────────────────────────────────────

    [Fact]
    public async Task GenerateTextAsync_WhenTextExceedsMaxOutputLength_CallsApiAndReturnsContent()
    {
        var handler = MakeHandlerMock(HttpStatusCode.OK, ChatCompletionJson("short summary"));
        var svc = BuildService(handler.Object, out _);
        var request = BuildSummaryRequest(new string('a', 300), maxOutputLength: 100);

        var result = await svc.GenerateTextAsync(request);

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
    public async Task GenerateTextAsync_WhenMaxOutputLengthIsNull_CallsApiOnce()
    {
        // No retry loop when MaxOutputLength is not specified.
        var handler = MakeHandlerMock(HttpStatusCode.OK, ChatCompletionJson("any content"));
        var svc = BuildService(handler.Object, out _);
        var request = BuildSummaryRequest(new string('a', 300), maxOutputLength: null);

        var result = await svc.GenerateTextAsync(request);

        Assert.Equal("any content", result);
        handler.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>());
    }

    [Fact]
    public async Task GenerateTextAsync_WhenApiReturns429_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.TooManyRequests, "{}").Object, out _);
        var request = BuildSummaryRequest(new string('a', 300), maxOutputLength: 100);

        var result = await svc.GenerateTextAsync(request);

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GenerateTextAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.InternalServerError, "{}").Object, out _);
        var request = BuildSummaryRequest(new string('a', 300), maxOutputLength: 100);

        var result = await svc.GenerateTextAsync(request);

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GenerateTextAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{\"choices\":[]}").Object, out _);
        var request = BuildSummaryRequest(new string('a', 300), maxOutputLength: 100);

        var result = await svc.GenerateTextAsync(request);

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GenerateTextAsync_WhenChoicesIsNull_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{\"choices\":null}").Object, out _);
        var request = BuildSummaryRequest(new string('a', 300), maxOutputLength: 100);

        var result = await svc.GenerateTextAsync(request);

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GenerateTextAsync_WhenFirstResponseStillTooLong_RetriesAndReturnsSecondResponse()
    {
        // Arrange: first call returns text still longer than MaxOutputLength (200 chars),
        // second call returns a short string that satisfies the while condition.
        const int limit = 100;
        var firstResponse = new string('b', 200);   // still > 100 → triggers second iteration
        var secondResponse = "final short summary";  // < 100 → loop exits

        var handler = MakeSequentialHandlerMock(new[]
        {
            (HttpStatusCode.OK, ChatCompletionJson(firstResponse)),
            (HttpStatusCode.OK, ChatCompletionJson(secondResponse))
        });
        var svc = BuildService(handler.Object, out _);
        var request = BuildSummaryRequest(new string('a', 300), maxOutputLength: limit);

        var result = await svc.GenerateTextAsync(request);

        Assert.Equal(secondResponse, result);
        handler.Protected().Verify(
            "SendAsync",
            Times.Exactly(2),
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>());
    }

    [Fact]
    public async Task GenerateTextAsync_WhenTextRemainsLongAfterMaxRetries_ReturnsLastApiContent()
    {
        // Arrange: all three API responses return text still longer than MaxOutputLength.
        // After tries > 2 the while exits and the last assigned value of `text` is returned.
        const int limit = 10;
        var longResponse = new string('c', 50); // always > 10

        var handler = MakeSequentialHandlerMock(new[]
        {
            (HttpStatusCode.OK, ChatCompletionJson(longResponse)),
            (HttpStatusCode.OK, ChatCompletionJson(longResponse)),
            (HttpStatusCode.OK, ChatCompletionJson(longResponse))
        });
        var svc = BuildService(handler.Object, out _);
        var request = BuildSummaryRequest(new string('a', 100), maxOutputLength: limit);

        var result = await svc.GenerateTextAsync(request);

        // The loop ran exactly 3 times (tries 1, 2, 3 where tries <= 2 exits the loop after the third)
        // and the last content from the API is returned as-is.
        Assert.Equal(longResponse, result);
        handler.Protected().Verify(
            "SendAsync",
            Times.Exactly(3),
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>());
    }

    // ── GenerateTextAsync — image prompt derivation role ─────────────────────

    [Fact]
    public async Task GenerateTextAsync_ImagePromptRole_WhenApiReturnsValidResponse_ReturnsPrompt()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, ChatCompletionJson("a vivid prompt")).Object, out _);
        var request = BuildImagePromptRequest("summary text");

        var result = await svc.GenerateTextAsync(request);

        Assert.Equal("a vivid prompt", result);
    }

    [Fact]
    public async Task GenerateTextAsync_ImagePromptRole_WhenApiReturns429_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.TooManyRequests, "{}").Object, out _);
        var request = BuildImagePromptRequest("summary");

        var result = await svc.GenerateTextAsync(request);

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GenerateTextAsync_ImagePromptRole_WhenApiReturnsNonSuccess_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.BadGateway, "{}").Object, out _);
        var request = BuildImagePromptRequest("summary");

        var result = await svc.GenerateTextAsync(request);

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GenerateTextAsync_ImagePromptRole_WhenChoicesArrayIsEmpty_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{\"choices\":[]}").Object, out _);
        var request = BuildImagePromptRequest("summary text");

        var result = await svc.GenerateTextAsync(request);

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GenerateTextAsync_ImagePromptRole_WhenChoicesIsNull_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{\"choices\":null}").Object, out _);
        var request = BuildImagePromptRequest("summary text");

        var result = await svc.GenerateTextAsync(request);

        Assert.Equal(string.Empty, result);
    }

    // ── PromptRequest field mapping ───────────────────────────────────────────

    [Fact]
    public async Task GenerateTextAsync_UsesCustomInputTextLabel_InUserPromptSubstitution()
    {
        // Arrange: verify that InputTextLabel controls the substitution token.
        var handler = MakeHandlerMock(HttpStatusCode.OK, ChatCompletionJson("result"));
        var svc = BuildService(handler.Object, out _);
        var request = new PromptRequest
        {
            InputText = "my input",
            SystemPromptTemplate = "system",
            UserPromptTemplate = "Summarize: [INPUT]",
            InputTextLabel = "[INPUT]"
        };

        var result = await svc.GenerateTextAsync(request);

        Assert.Equal("result", result);
    }

    [Fact]
    public async Task GenerateTextAsync_WhenInputTextLabelIsNull_FallsBackToDefaultLabel()
    {
        // Arrange: InputTextLabel not set → implementation falls back to "{Text}".
        var handler = MakeHandlerMock(HttpStatusCode.OK, ChatCompletionJson("result"));
        var svc = BuildService(handler.Object, out _);
        var request = new PromptRequest
        {
            InputText = "my input",
            SystemPromptTemplate = "system",
            UserPromptTemplate = "Summarize: {Text}",
            InputTextLabel = null
        };

        var result = await svc.GenerateTextAsync(request);

        Assert.Equal("result", result);
    }
}
