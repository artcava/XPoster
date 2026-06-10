using System.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using XPoster.Models;
using XPoster.Services;

namespace XPoster.Tests.Services;

/// <summary>
/// Verifies that <see cref="HybridAiService"/> correctly delegates:
/// - text operations (summary, image prompt) to <see cref="DeepSeekService"/>
/// - image generation to <see cref="FalAiImageService"/>
/// </summary>
public class HybridAiServiceTests
{
    // ── Builders ─────────────────────────────────────────────────────────────

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

    private static DeepSeekService BuildDeepSeekService(HttpMessageHandler handler)
    {
        var factory = new Mock<IHttpClientFactory>();
        factory.Setup(f => f.CreateClient(It.IsAny<string>()))
               .Returns(new HttpClient(handler));

        var options = Options.Create(new DeepSeekOptions
        {
            Endpoint       = "https://api.deepseek.com",
            ApiKey         = "fake-key",
            DeploymentName = "deepseek-chat",
            SummarySystemPromptTemplate  = "Keep under {MaxChars} chars.",
            SummaryUserPromptTemplate    = "Summarize: {Text}",
            ImagePromptSystemTemplate    = "You generate image prompts.",
            ImagePromptUserTemplate      = "Image for: {Summary}"
        });

        return new DeepSeekService(factory.Object, options, new Mock<ILogger<DeepSeekService>>().Object);
    }

    private static FalAiImageService BuildFalService(HttpMessageHandler handler)
    {
        var factory = new Mock<IHttpClientFactory>();
        factory.Setup(f => f.CreateClient(It.IsAny<string>()))
               .Returns(new HttpClient(handler));

        var options = Options.Create(new FalAiOptions
        {
            ApiKey            = "fake-fal-key",
            ModelId           = "fal-ai/flux/schnell",
            ImageSize         = "landscape_4_3",
            NumInferenceSteps = 4
        });

        return new FalAiImageService(factory.Object, options, new Mock<ILogger<FalAiImageService>>().Object);
    }

    private static HybridAiService BuildHybrid(
        HttpMessageHandler deepSeekHandler,
        HttpMessageHandler falHandler)
    {
        return new HybridAiService(
            BuildDeepSeekService(deepSeekHandler),
            BuildFalService(falHandler),
            new Mock<ILogger<HybridAiService>>().Object);
    }

    private static string ChatCompletionJson(string content) =>
        "{\"choices\":[{\"message\":{\"content\":\"" + content + "\"}}]}";

    // ── Delegation tests ─────────────────────────────────────────────────────

    [Fact]
    public async Task GetSummaryAsync_DelegatesToDeepSeek_ReturnsContent()
    {
        var deepSeekHandler = MakeHandlerMock(HttpStatusCode.OK, ChatCompletionJson("summary from deepseek"));
        var svc = BuildHybrid(deepSeekHandler.Object, MakeHandlerMock(HttpStatusCode.OK, "{}").Object);

        var result = await svc.GetSummaryAsync(new string('a', 300), 100);

        Assert.Equal("summary from deepseek", result);
        deepSeekHandler.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.Is<HttpRequestMessage>(r =>
                r.RequestUri!.AbsolutePath.Contains("/chat/completions", StringComparison.Ordinal)),
            ItExpr.IsAny<CancellationToken>());
    }

    [Fact]
    public async Task GetImagePromptAsync_DelegatesToDeepSeek_ReturnsPrompt()
    {
        var deepSeekHandler = MakeHandlerMock(HttpStatusCode.OK, ChatCompletionJson("vivid image prompt"));
        var svc = BuildHybrid(deepSeekHandler.Object, MakeHandlerMock(HttpStatusCode.OK, "{}").Object);

        var result = await svc.GetImagePromptAsync("some summary");

        Assert.Equal("vivid image prompt", result);
        deepSeekHandler.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.Is<HttpRequestMessage>(r =>
                r.RequestUri!.AbsolutePath.Contains("/chat/completions", StringComparison.Ordinal)),
            ItExpr.IsAny<CancellationToken>());
    }

    [Fact]
    public async Task GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek()
    {
        // fal.ai returns a valid image URL that we then download
        var imageBytes = new byte[] { 1, 2, 3 };
        var falJson = "{\"images\":[{\"url\":\"https://fal.ai/fake-image.png\"}]}";

        // The fal handler serves both the submission POST and the image download GET
        var falHandlerMock = new Mock<HttpMessageHandler>();
        falHandlerMock.Protected()
            .SetupSequence<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(falJson, System.Text.Encoding.UTF8, "application/json")
            })
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(imageBytes)
            });

        var deepSeekHandlerMock = MakeHandlerMock(HttpStatusCode.OK, "{}");
        var svc = BuildHybrid(deepSeekHandlerMock.Object, falHandlerMock.Object);

        var result = await svc.GenerateImageAsync("a prompt");

        // DeepSeek must never be called for image generation
        deepSeekHandlerMock.Protected().Verify(
            "SendAsync",
            Times.Never(),
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>());

        Assert.Equal(imageBytes, result);
    }

    // ── Null guard tests ─────────────────────────────────────────────────────

    [Fact]
    public void Constructor_NullDeepSeekService_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new HybridAiService(
                null!,
                BuildFalService(MakeHandlerMock(HttpStatusCode.OK, "{}").Object),
                new Mock<ILogger<HybridAiService>>().Object));
    }

    [Fact]
    public void Constructor_NullFalAiService_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new HybridAiService(
                BuildDeepSeekService(MakeHandlerMock(HttpStatusCode.OK, "{}").Object),
                null!,
                new Mock<ILogger<HybridAiService>>().Object));
    }
}
