using System.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using XPoster.Models;
using XPoster.Services;

namespace XPoster.Tests.Services;

public class AzureFoundryServiceTests
{
    private static AzureFoundryService BuildService(HttpMessageHandler handler, out Mock<ILogger<AzureFoundryService>> loggerMock, AzureFoundryOptions? opts = null)
    {
        loggerMock = new Mock<ILogger<AzureFoundryService>>();
        var factory = new Mock<IHttpClientFactory>();
        var client = new HttpClient(handler);
        factory.Setup(f => f.CreateClient(It.IsAny<string>())).Returns(client);

        var options = Options.Create(opts ?? new AzureFoundryOptions
        {
            Endpoint = "https://myfoundry.openai.azure.com",
            ApiKey = "fake-key",
            DeploymentName = "gpt-4.1-nano",
            ImageDeploymentName = "gpt-image-1"
        });

        return new AzureFoundryService(factory.Object, options, loggerMock.Object);
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
    public async Task GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsTrimmedContent()
    {
        var handler = MakeHandlerMock(HttpStatusCode.OK, ChatCompletionJson("summary result"));
        var svc = BuildService(handler.Object, out _);

        var result = await svc.GetSummaryAsync(new string('a', 300), 100);

        Assert.Equal("summary result", result);
        handler.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Post && r.RequestUri!.AbsolutePath.Contains("/chat/completions", StringComparison.Ordinal)),
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
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.BadGateway, "{}").Object, out _);

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

    // ── GetImagePromptAsync ─────────────────────────────────────────────────

    [Fact]
    public async Task GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, ChatCompletionJson("prompt result")).Object, out _);

        var result = await svc.GetImagePromptAsync("summary");

        Assert.Equal("prompt result", result);
    }

    [Fact]
    public async Task GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{\"choices\":[]}").Object, out _);

        var result = await svc.GetImagePromptAsync("summary");

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{\"choices\":null}").Object, out _);

        var result = await svc.GetImagePromptAsync("summary");

        Assert.Equal(string.Empty, result);
    }

    // ── GenerateImageAsync ──────────────────────────────────────────────────

    [Fact]
    public async Task GenerateImageAsync_WhenApiReturnsValidResponse_ReturnsByteArray()
    {
        var imageBytes = new byte[] { 1, 2, 3, 4 };
        var base64 = Convert.ToBase64String(imageBytes);
        var json = "{\"data\":[{\"b64_json\":\"" + base64 + "\"}]}";
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, json).Object, out _);

        var result = await svc.GenerateImageAsync("image prompt");

        Assert.Equal(imageBytes, result);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenApiReturnsNonSuccess_ReturnsEmptyByteArray()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.BadRequest, "{}").Object, out _);

        var result = await svc.GenerateImageAsync("image prompt");

        Assert.Empty(result);
    }

    /// <summary>G1 — 429 on image generation must return empty, not fall through to success path.</summary>
    [Fact]
    public async Task GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyByteArray()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.TooManyRequests, "{}").Object, out _);

        var result = await svc.GenerateImageAsync("image prompt");

        Assert.Empty(result);
    }

    /// <summary>G2 — Malformed JSON on 200 must not throw; must return empty array.</summary>
    [Fact]
    public async Task GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyByteArray()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "NOT_JSON").Object, out _);

        var result = await svc.GenerateImageAsync("image prompt");

        Assert.Empty(result);
    }

    /// <summary>G3 — Empty data array on 200 must return empty array without throwing IndexOutOfRangeException.</summary>
    [Fact]
    public async Task GenerateImageAsync_WhenDataArrayIsEmpty_ReturnsEmptyByteArray()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{\"data\":[]}").Object, out _);

        var result = await svc.GenerateImageAsync("image prompt");

        Assert.Empty(result);
    }

    /// <summary>G4 — b64_json null must return empty array, not throw FormatException.</summary>
    [Fact]
    public async Task GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyByteArray()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{\"data\":[{\"b64_json\":null}]}").Object, out _);

        var result = await svc.GenerateImageAsync("image prompt");

        Assert.Empty(result);
    }

    /// <summary>
    /// G5 — When b64_json is absent but a url is present, the service downloads from the url
    /// and returns the bytes. In this test the url points to a second endpoint served by the
    /// same mock handler, which returns a fixed byte payload.
    /// </summary>
    [Fact]
    public async Task GenerateImageAsync_WhenB64JsonAbsentAndUrlPresent_DownloadsFromUrl()
    {
        // The image download call is also intercepted by the same HttpClient/handler.
        // We configure the handler to return the image bytes for any request.
        var imageBytes = new byte[] { 10, 20, 30 };
        var mock = new Mock<HttpMessageHandler>();
        mock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .Returns<HttpRequestMessage, CancellationToken>((req, _) =>
            {
                // First call is the POST to the image generation endpoint.
                // Second call is the GET for the image URL.
                if (req.Method == HttpMethod.Post)
                {
                    var json = "{\"data\":[{\"url\":\"https://myfoundry.openai.azure.com/generated/img.png\"}]}";
                    return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json")
                    });
                }

                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(imageBytes)
                });
            });

        var svc = BuildService(mock.Object, out _);

        var result = await svc.GenerateImageAsync("image prompt");

        Assert.Equal(imageBytes, result);
    }

    /// <summary>
    /// G6 — A fallback url that does not originate from the configured endpoint must emit a
    /// LogWarning. The download is still attempted (defence-in-depth, not a hard block).
    /// </summary>
    [Fact]
    public async Task GenerateImageAsync_WhenFallbackUrlIsFromDifferentOrigin_LogsWarning()
    {
        var imageBytes = new byte[] { 1 };
        var mock = new Mock<HttpMessageHandler>();
        mock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .Returns<HttpRequestMessage, CancellationToken>((req, _) =>
            {
                if (req.Method == HttpMethod.Post)
                {
                    // URL originates from a different host — should trigger LogWarning.
                    var json = "{\"data\":[{\"url\":\"https://cdn.unknown.example.com/img.png\"}]}";
                    return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json")
                    });
                }

                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(imageBytes)
                });
            });

        var svc = BuildService(mock.Object, out var loggerMock);

        await svc.GenerateImageAsync("image prompt");

        loggerMock.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("cdn.unknown.example.com")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    /// <summary>G7 — Empty prompt must return empty array immediately, without making any HTTP call.</summary>
    [Fact]
    public async Task GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyByteArrayWithoutCallingApi()
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

    /// <summary>G8 — Whitespace-only prompt must also be rejected before any HTTP call.</summary>
    [Fact]
    public async Task GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi()
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
