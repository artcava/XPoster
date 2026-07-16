using System.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using XPoster.Models;
using XPoster.Services;

namespace XPoster.Tests.Services;

public class DeepSeekServiceTests
{
    // ── Helpers ──────────────────────────────────────────────────────────────

    private static DeepSeekService BuildService(
        HttpMessageHandler handler,
        out Mock<ILogger<DeepSeekService>> loggerMock,
        DeepSeekOptions? opts = null)
    {
        loggerMock = new Mock<ILogger<DeepSeekService>>();
        var factory = new Mock<IHttpClientFactory>();
        factory.Setup(f => f.CreateClient(It.IsAny<string>()))
               .Returns(new HttpClient(handler));

        // Only connectivity fields remain in DeepSeekOptions after issue-223.
        // Prompt templates are now transported via PromptRequest value objects.
        var options = Options.Create(opts ?? new DeepSeekOptions
        {
            Endpoint = "https://api.deepseek.com",
            ApiKey = "fake-key",
            DeploymentName = "deepseek-chat"
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

    /// <summary>
    /// Builds a minimal valid PromptRequest for summary-style calls.
    /// </summary>
    private static PromptRequest SummaryRequest(
        string inputText,
        int? maxOutputLength = null,
        string? inputTextLabel = null) =>
        new()
        {
            InputText = inputText,
            SystemPromptTemplate = "You summarize text.",
            UserPromptTemplate = "Summarize: {Text}",
            InputTextLabel = inputTextLabel ?? "{Text}",
            MaxOutputLength = maxOutputLength,
            Temperature = 0.5,
            MaxTokenBudget = 600
        };

    /// <summary>
    /// Builds a minimal valid PromptRequest for image-prompt derivation calls.
    /// </summary>
    private static PromptRequest ImagePromptDerivationRequest(string inputText) =>
        new()
        {
            InputText = inputText,
            SystemPromptTemplate = "You generate image prompts.",
            UserPromptTemplate = "Image for: {Summary}",
            InputTextLabel = "{Summary}",
            Temperature = 0.7,
            MaxTokenBudget = 300
        };

    // ── GenerateTextAsync — happy path ────────────────────────────────────────

    [Fact]
    public async Task GenerateTextAsync_WhenApiReturnsValidResponse_ReturnsContent()
    {
        var handler = MakeHandlerMock(HttpStatusCode.OK, ChatCompletionJson("short summary"));
        var svc = BuildService(handler.Object, out _);

        var result = await svc.GenerateTextAsync(SummaryRequest(new string('a', 300)));

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
    public async Task GenerateTextAsync_WhenResponseFitsWithinMaxOutputLength_ReturnsSingleCallResult()
    {
        // API returns text that already satisfies the MaxOutputLength constraint.
        var handler = MakeHandlerMock(HttpStatusCode.OK, ChatCompletionJson("ok"));
        var svc = BuildService(handler.Object, out _);
        var request = SummaryRequest(new string('a', 300), maxOutputLength: 100);

        var result = await svc.GenerateTextAsync(request);

        Assert.Equal("ok", result);
        // Exactly one HTTP call: no retry needed because "ok".Length <= 100.
        handler.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>());
    }

    [Fact]
    public async Task GenerateTextAsync_WhenNoMaxOutputLength_DoesNotRetryRegardlessOfLength()
    {
        var longText = new string('z', 500);
        var handler = MakeHandlerMock(HttpStatusCode.OK, ChatCompletionJson(longText));
        var svc = BuildService(handler.Object, out _);
        // MaxOutputLength not set → no retry loop.
        var request = SummaryRequest("input");

        var result = await svc.GenerateTextAsync(request);

        Assert.Equal(longText, result);
        handler.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>());
    }

    // ── GenerateTextAsync — image prompt derivation role ─────────────────────

    [Fact]
    public async Task GenerateTextAsync_WhenUsedForImagePromptDerivation_ReturnsPrompt()
    {
        var svc = BuildService(
            MakeHandlerMock(HttpStatusCode.OK, ChatCompletionJson("a vivid prompt")).Object,
            out _);

        var result = await svc.GenerateTextAsync(ImagePromptDerivationRequest("summary text"));

        Assert.Equal("a vivid prompt", result);
    }

    // ── GenerateTextAsync — error responses ───────────────────────────────────

    [Fact]
    public async Task GenerateTextAsync_WhenApiReturns429_ReturnsEmptyString()
    {
        var svc = BuildService(
            MakeHandlerMock(HttpStatusCode.TooManyRequests, "{}").Object, out _);

        var result = await svc.GenerateTextAsync(SummaryRequest(new string('a', 300)));

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GenerateTextAsync_WhenApiReturnsInternalServerError_ReturnsEmptyString()
    {
        var svc = BuildService(
            MakeHandlerMock(HttpStatusCode.InternalServerError, "{}").Object, out _);

        var result = await svc.GenerateTextAsync(SummaryRequest(new string('a', 300)));

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GenerateTextAsync_WhenApiReturnsBadGateway_ReturnsEmptyString()
    {
        var svc = BuildService(
            MakeHandlerMock(HttpStatusCode.BadGateway, "{}").Object, out _);

        var result = await svc.GenerateTextAsync(ImagePromptDerivationRequest("summary"));

        Assert.Equal(string.Empty, result);
    }

    // ── GenerateTextAsync — malformed / empty choices ─────────────────────────

    [Fact]
    public async Task GenerateTextAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString()
    {
        var svc = BuildService(
            MakeHandlerMock(HttpStatusCode.OK, "{\"choices\":[]}").Object, out _);

        var result = await svc.GenerateTextAsync(SummaryRequest(new string('a', 300)));

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GenerateTextAsync_WhenChoicesIsNull_ReturnsEmptyString()
    {
        var svc = BuildService(
            MakeHandlerMock(HttpStatusCode.OK, "{\"choices\":null}").Object, out _);

        var result = await svc.GenerateTextAsync(SummaryRequest(new string('a', 300)));

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GenerateTextAsync_WhenChoicesIsNull_ForImagePromptRole_ReturnsEmptyString()
    {
        var svc = BuildService(
            MakeHandlerMock(HttpStatusCode.OK, "{\"choices\":null}").Object, out _);

        var result = await svc.GenerateTextAsync(ImagePromptDerivationRequest("summary text"));

        Assert.Equal(string.Empty, result);
    }

    // ── GenerateTextAsync — prompt field sourcing from PromptRequest ──────────

    [Fact]
    public async Task GenerateTextAsync_UsesSystemAndUserTemplatesFromRequest_NotFromOptions()
    {
        // Arrange: capture the outbound HTTP body to verify templates came from PromptRequest.
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
                        ChatCompletionJson("result"),
                        System.Text.Encoding.UTF8,
                        "application/json")
                };
            });

        var svc = BuildService(handlerMock.Object, out _);
        var request = new PromptRequest
        {
            InputText = "my input",
            SystemPromptTemplate = "CUSTOM_SYSTEM_PROMPT",
            UserPromptTemplate = "CUSTOM_USER: {Text}",
            InputTextLabel = "{Text}"
        };

        await svc.GenerateTextAsync(request);

        Assert.NotNull(capturedBody);
        Assert.Contains("CUSTOM_SYSTEM_PROMPT", capturedBody, StringComparison.Ordinal);
        Assert.Contains("CUSTOM_USER: my input", capturedBody, StringComparison.Ordinal);
    }

    [Fact]
    public async Task GenerateTextAsync_AppliesCustomInputTextLabel_InUserTemplate()
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
            InputText = "summary content",
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "Derive image prompt for: {Summary}",
            InputTextLabel = "{Summary}"
        };

        await svc.GenerateTextAsync(request);

        Assert.NotNull(capturedBody);
        // The label {Summary} must be replaced with the actual input text.
        Assert.Contains("summary content", capturedBody, StringComparison.Ordinal);
        Assert.DoesNotContain("{Summary}", capturedBody, StringComparison.Ordinal);
    }

    // ── GenerateTextAsync — CancellationToken propagation ────────────────────

    [Fact]
    public async Task GenerateTextAsync_WhenCancellationRequested_ThrowsOperationCanceledException()
    {
        var cts = new CancellationTokenSource();
        await cts.CancelAsync();

        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new OperationCanceledException());

        var svc = BuildService(handlerMock.Object, out _);

        await Assert.ThrowsAnyAsync<OperationCanceledException>(() =>
            svc.GenerateTextAsync(SummaryRequest("text"), cts.Token));
    }
}
