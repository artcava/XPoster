using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
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
            ImageDeploymentName = "gpt-image-1.5"
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
            ItExpr.Is<HttpRequestMessage>(r =>
                r.Method == HttpMethod.Post &&
                r.RequestUri!.AbsolutePath.EndsWith("/chat/completions", StringComparison.Ordinal) &&
                !r.RequestUri.AbsolutePath.Contains("/openai/deployments/", StringComparison.Ordinal)),
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

    [Fact]
    public async Task GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyByteArray()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.TooManyRequests, "{}").Object, out _);

        var result = await svc.GenerateImageAsync("image prompt");

        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.TooManyRequests, "{}").Object, out var loggerMock);

        await svc.GenerateImageAsync("image prompt");

        loggerMock.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) =>
                    v.ToString()!.Contains("Azure Foundry") &&
                    (v.ToString()!.Contains("429") || v.ToString()!.Contains("TooManyRequests"))),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyByteArray()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "NOT_JSON").Object, out _);

        var result = await svc.GenerateImageAsync("image prompt");

        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenDataArrayIsEmpty_ReturnsEmptyByteArray()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{\"data\":[]}").Object, out _);

        var result = await svc.GenerateImageAsync("image prompt");

        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyByteArray()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{\"data\":[{\"b64_json\":null}]}").Object, out _);

        var result = await svc.GenerateImageAsync("image prompt");

        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenB64JsonAbsentAndUrlPresent_DownloadsFromUrl()
    {
        var imageBytes = new byte[] { 10, 20, 30 };
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

    [Fact]
    public async Task GenerateImageAsync_WhenHttpRequestExceptionOnPost_ReturnsEmptyByteArray()
    {
        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new HttpRequestException("network failure"));

        var svc = BuildService(handler.Object, out _);

        var result = await svc.GenerateImageAsync("image prompt");

        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenHttpRequestExceptionOnPost_LogsError()
    {
        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new HttpRequestException("network failure"));

        var svc = BuildService(handler.Object, out var loggerMock);

        await svc.GenerateImageAsync("image prompt");

        loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("Azure Foundry image generation HTTP request failed")),
                It.IsAny<HttpRequestException>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

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

    [Fact]
    public async Task GenerateImageAsync_PostsToFoundryImagesGenerationsEndpoint()
    {
        var imageBytes = new byte[] { 1, 2, 3 };
        var base64 = Convert.ToBase64String(imageBytes);
        var json = "{\"data\":[{\"b64_json\":\"" + base64 + "\"}]}";
        var handler = MakeHandlerMock(HttpStatusCode.OK, json);
        var svc = BuildService(handler.Object, out _);

        await svc.GenerateImageAsync("a polar bear");

        handler.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.Is<HttpRequestMessage>(r =>
                r.Method == HttpMethod.Post &&
                r.RequestUri!.AbsolutePath.EndsWith("/images/generations", StringComparison.Ordinal) &&
                !r.RequestUri.AbsolutePath.Contains("/openai/deployments/", StringComparison.Ordinal)),
            ItExpr.IsAny<CancellationToken>());
    }

    [Fact]
    public async Task GenerateImageAsync_RequestBodyContainsModelField()
    {
        var imageBytes = new byte[] { 5, 6, 7 };
        var base64 = Convert.ToBase64String(imageBytes);
        var json = "{\"data\":[{\"b64_json\":\"" + base64 + "\"}]}";

        string? capturedBody = null;
        var mock = new Mock<HttpMessageHandler>();
        mock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .Returns<HttpRequestMessage, CancellationToken>(async (req, _) =>
            {
                capturedBody = await req.Content!.ReadAsStringAsync();
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };
            });

        var svc = BuildService(mock.Object, out _);
        await svc.GenerateImageAsync("a polar bear");

        Assert.NotNull(capturedBody);
        using var doc = JsonDocument.Parse(capturedBody!);
        Assert.True(doc.RootElement.TryGetProperty("model", out var modelProp));
        Assert.Equal("gpt-image-1.5", modelProp.GetString());
    }

    [Fact]
    public async Task GetSummaryAsync_PostsToFoundryChatCompletionsEndpoint()
    {
        var handler = MakeHandlerMock(HttpStatusCode.OK, ChatCompletionJson("short"));
        var svc = BuildService(handler.Object, out _);

        await svc.GetSummaryAsync(new string('a', 300), 100);

        handler.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.Is<HttpRequestMessage>(r =>
                r.Method == HttpMethod.Post &&
                r.RequestUri!.AbsolutePath.EndsWith("/chat/completions", StringComparison.Ordinal) &&
                !r.RequestUri.AbsolutePath.Contains("/openai/deployments/", StringComparison.Ordinal)),
            ItExpr.IsAny<CancellationToken>());
    }

    [Fact]
    public async Task GetSummaryAsync_RequestBodyContainsModelField()
    {
        string? capturedBody = null;
        var mock = new Mock<HttpMessageHandler>();
        mock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .Returns<HttpRequestMessage, CancellationToken>(async (req, _) =>
            {
                capturedBody = await req.Content!.ReadAsStringAsync();
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(
                        ChatCompletionJson("short"),
                        Encoding.UTF8,
                        "application/json")
                };
            });

        var svc = BuildService(mock.Object, out _);
        await svc.GetSummaryAsync(new string('a', 300), 100);

        Assert.NotNull(capturedBody);
        using var doc = JsonDocument.Parse(capturedBody!);
        Assert.True(doc.RootElement.TryGetProperty("model", out var modelProp));
        Assert.Equal("gpt-4.1-nano", modelProp.GetString());
    }
}
