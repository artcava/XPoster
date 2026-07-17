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
            TextModelName = "gpt-4.1-nano",
            ImageModelName = "gpt-image-1.5"
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

    private static PromptRequest BuildPromptRequest(string inputText, int? maxOutputLength = null) =>
        new PromptRequest
        {
            InputText = inputText,
            SystemPromptTemplate = "You are a helpful assistant.",
            UserPromptTemplate = "Summarise: {Text}",
            InputTextLabel = "{Text}",
            Temperature = 0.7,
            MaxOutputLength = maxOutputLength,
            MaxTokenBudget = 600
        };

    private static ImagePromptRequest BuildImagePromptRequest(string inputText) =>
        new ImagePromptRequest
        {
            InputText = inputText,
            SystemPromptTemplate = "You are an image prompt generator.",
            UserPromptTemplate = "Generate image: {Text}",
            InputTextLabel = "{Text}",
            ImageQuantity = 1,
            ImageSize = "1024x1024"
        };

    // ---------------------------------------------------------------------------
    // GenerateTextAsync — success paths
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task GenerateTextAsync_WhenApiReturnsValidResponse_ReturnsContent()
    {
        var handler = MakeHandlerMock(HttpStatusCode.OK, ChatCompletionJson("summary result"));
        var svc = BuildService(handler.Object, out _);

        var result = await svc.GenerateTextAsync(BuildPromptRequest(new string('a', 300), 100));

        Assert.Equal("summary result", result);
    }

    [Fact]
    public async Task GenerateTextAsync_PostsToChatCompletionsEndpoint()
    {
        var handler = MakeHandlerMock(HttpStatusCode.OK, ChatCompletionJson("short"));
        var svc = BuildService(handler.Object, out _);

        await svc.GenerateTextAsync(BuildPromptRequest(new string('a', 300), 100));

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
    public async Task GenerateTextAsync_RequestBodyContainsModelFromOptions()
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
                    Content = new StringContent(ChatCompletionJson("short"), Encoding.UTF8, "application/json")
                };
            });

        var svc = BuildService(mock.Object, out _);
        await svc.GenerateTextAsync(BuildPromptRequest(new string('a', 300), 100));

        Assert.NotNull(capturedBody);
        using var doc = JsonDocument.Parse(capturedBody!);
        Assert.True(doc.RootElement.TryGetProperty("model", out var modelProp));
        Assert.Equal("gpt-4.1-nano", modelProp.GetString());
    }

    [Fact]
    public async Task GenerateTextAsync_RequestBodyContainsSystemAndUserMessagesFromRequest()
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
                    Content = new StringContent(ChatCompletionJson("ok"), Encoding.UTF8, "application/json")
                };
            });

        var svc = BuildService(mock.Object, out _);
        var request = new PromptRequest
        {
            InputText = "hello world",
            SystemPromptTemplate = "Custom system prompt",
            UserPromptTemplate = "Custom user: {Text}",
            InputTextLabel = "{Text}"
        };

        await svc.GenerateTextAsync(request);

        Assert.NotNull(capturedBody);
        using var doc = JsonDocument.Parse(capturedBody!);
        var messages = doc.RootElement.GetProperty("messages");
        var system = messages.EnumerateArray().First(m => m.GetProperty("role").GetString() == "system");
        var user = messages.EnumerateArray().First(m => m.GetProperty("role").GetString() == "user");

        Assert.Equal("Custom system prompt", system.GetProperty("content").GetString());
        Assert.Contains("hello world", user.GetProperty("content").GetString());
    }

    [Fact]
    public async Task GenerateTextAsync_RequestBodyContainsTemperatureAndMaxTokensFromRequest()
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
                    Content = new StringContent(ChatCompletionJson("ok"), Encoding.UTF8, "application/json")
                };
            });

        var svc = BuildService(mock.Object, out _);
        var request = new PromptRequest
        {
            InputText = "text",
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user: {Text}",
            InputTextLabel = "{Text}",
            Temperature = 0.42,
            MaxTokenBudget = 123
        };

        await svc.GenerateTextAsync(request);

        Assert.NotNull(capturedBody);
        using var doc = JsonDocument.Parse(capturedBody!);
        Assert.True(doc.RootElement.TryGetProperty("temperature", out var tempProp));
        Assert.Equal(0.42, tempProp.GetDouble(), 5);
        Assert.True(doc.RootElement.TryGetProperty("max_tokens", out var maxProp));
        Assert.Equal(123, maxProp.GetInt32());
    }

    // ---------------------------------------------------------------------------
    // GenerateTextAsync — failure / edge cases
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task GenerateTextAsync_WhenApiReturns429_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.TooManyRequests, "{}").Object, out _);

        var result = await svc.GenerateTextAsync(BuildPromptRequest(new string('a', 300), 100));

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GenerateTextAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.BadGateway, "{}").Object, out _);

        var result = await svc.GenerateTextAsync(BuildPromptRequest(new string('a', 300), 100));

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GenerateTextAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{\"choices\":[]}").Object, out _);

        var result = await svc.GenerateTextAsync(BuildPromptRequest(new string('a', 300), 100));

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GenerateTextAsync_WhenChoicesIsNull_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{\"choices\":null}").Object, out _);

        var result = await svc.GenerateTextAsync(BuildPromptRequest(new string('a', 300), 100));

        Assert.Equal(string.Empty, result);
    }

    // ---------------------------------------------------------------------------
    // GenerateTextAsync — used as image-prompt derivation step (no MaxOutputLength)
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task GenerateTextAsync_WhenUsedAsImagePromptDerivationStep_ReturnsContent()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, ChatCompletionJson("prompt result")).Object, out _);
        var request = new PromptRequest
        {
            InputText = "summary text",
            SystemPromptTemplate = "Derive an image generation prompt.",
            UserPromptTemplate = "Summary: {Summary}",
            InputTextLabel = "{Summary}"
        };

        var result = await svc.GenerateTextAsync(request);

        Assert.Equal("prompt result", result);
    }

    [Fact]
    public async Task GenerateTextAsync_WhenUsedAsImagePromptDerivationStep_AndChoicesEmpty_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{\"choices\":[]}").Object, out _);
        var request = new PromptRequest
        {
            InputText = "summary text",
            SystemPromptTemplate = "Derive an image generation prompt.",
            UserPromptTemplate = "Summary: {Summary}",
            InputTextLabel = "{Summary}"
        };

        var result = await svc.GenerateTextAsync(request);

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GenerateTextAsync_WhenUsedAsImagePromptDerivationStep_AndChoicesNull_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{\"choices\":null}").Object, out _);
        var request = new PromptRequest
        {
            InputText = "summary text",
            SystemPromptTemplate = "Derive an image generation prompt.",
            UserPromptTemplate = "Summary: {Summary}",
            InputTextLabel = "{Summary}"
        };

        var result = await svc.GenerateTextAsync(request);

        Assert.Equal(string.Empty, result);
    }

    // ---------------------------------------------------------------------------
    // GenerateImageAsync — success paths
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task GenerateImageAsync_WhenApiReturnsValidResponse_ReturnsByteArray()
    {
        var imageBytes = new byte[] { 1, 2, 3, 4 };
        var base64 = Convert.ToBase64String(imageBytes);
        var json = "{\"data\":[{\"b64_json\":\"" + base64 + "\"}]}";
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, json).Object, out _);

        var result = await svc.GenerateImageAsync(BuildImagePromptRequest("image prompt"));

        Assert.Equal(imageBytes, result);
    }

    [Fact]
    public async Task GenerateImageAsync_PostsToFoundryImagesGenerationsEndpoint()
    {
        var imageBytes = new byte[] { 1, 2, 3 };
        var base64 = Convert.ToBase64String(imageBytes);
        var json = "{\"data\":[{\"b64_json\":\"" + base64 + "\"}]}";
        var handler = MakeHandlerMock(HttpStatusCode.OK, json);
        var svc = BuildService(handler.Object, out _);

        await svc.GenerateImageAsync(BuildImagePromptRequest("a polar bear"));

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
    public async Task GenerateImageAsync_RequestBodyContainsModelFromOptions()
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
        await svc.GenerateImageAsync(BuildImagePromptRequest("a polar bear"));

        Assert.NotNull(capturedBody);
        using var doc = JsonDocument.Parse(capturedBody!);
        Assert.True(doc.RootElement.TryGetProperty("model", out var modelProp));
        Assert.Equal("gpt-image-1.5", modelProp.GetString());
    }

    [Fact]
    public async Task GenerateImageAsync_RequestBodyContainsSizeAndQuantityFromRequest()
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
                var imageBytes = new byte[] { 1 };
                var b64 = Convert.ToBase64String(imageBytes);
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(
                        "{\"data\":[{\"b64_json\":\"" + b64 + "\"}]}", Encoding.UTF8, "application/json")
                };
            });

        var svc = BuildService(mock.Object, out _);
        var request = new ImagePromptRequest
        {
            InputText = "polar bear",
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "prompt: {Text}",
            InputTextLabel = "{Text}",
            ImageQuantity = 2,
            ImageSize = "512x512"
        };
        await svc.GenerateImageAsync(request);

        Assert.NotNull(capturedBody);
        using var doc = JsonDocument.Parse(capturedBody!);
        Assert.Equal("512x512", doc.RootElement.GetProperty("size").GetString());
        Assert.Equal(2, doc.RootElement.GetProperty("n").GetInt32());
    }

    // ---------------------------------------------------------------------------
    // GenerateImageAsync — failure / edge cases
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task GenerateImageAsync_WhenApiReturnsNonSuccess_ReturnsEmptyByteArray()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.BadRequest, "{}").Object, out _);

        var result = await svc.GenerateImageAsync(BuildImagePromptRequest("image prompt"));

        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyByteArray()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.TooManyRequests, "{}").Object, out _);

        var result = await svc.GenerateImageAsync(BuildImagePromptRequest("image prompt"));

        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.TooManyRequests, "{}").Object, out var loggerMock);

        await svc.GenerateImageAsync(BuildImagePromptRequest("image prompt"));

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

        var result = await svc.GenerateImageAsync(BuildImagePromptRequest("image prompt"));

        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenDataArrayIsEmpty_ReturnsEmptyByteArray()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{\"data\":[]}").Object, out _);

        var result = await svc.GenerateImageAsync(BuildImagePromptRequest("image prompt"));

        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyByteArray()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{\"data\":[{\"b64_json\":null}]}").Object, out _);

        var result = await svc.GenerateImageAsync(BuildImagePromptRequest("image prompt"));

        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenInputTextIsEmpty_ReturnsEmptyByteArrayWithoutCallingApi()
    {
        var handler = MakeHandlerMock(HttpStatusCode.OK, "{}");
        var svc = BuildService(handler.Object, out _);
        var request = new ImagePromptRequest
        {
            InputText = string.Empty,
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user: {Text}",
            InputTextLabel = "{Text}"
        };

        var result = await svc.GenerateImageAsync(request);

        Assert.Empty(result);
        handler.Protected().Verify(
            "SendAsync",
            Times.Never(),
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>());
    }

    [Fact]
    public async Task GenerateImageAsync_WhenInputTextIsEmpty_LogsWarning()
    {
        var handler = MakeHandlerMock(HttpStatusCode.OK, "{}");
        var svc = BuildService(handler.Object, out var loggerMock);
        var request = new ImagePromptRequest
        {
            InputText = string.Empty,
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user: {Text}",
            InputTextLabel = "{Text}"
        };

        await svc.GenerateImageAsync(request);

        loggerMock.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("empty") || v.ToString()!.Contains("whitespace") || v.ToString()!.Contains("prompt")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenInputTextIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi()
    {
        var handler = MakeHandlerMock(HttpStatusCode.OK, "{}");
        var svc = BuildService(handler.Object, out _);
        var request = new ImagePromptRequest
        {
            InputText = "   ",
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user: {Text}",
            InputTextLabel = "{Text}"
        };

        var result = await svc.GenerateImageAsync(request);

        Assert.Empty(result);
        handler.Protected().Verify(
            "SendAsync",
            Times.Never(),
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>());
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

        var result = await svc.GenerateImageAsync(BuildImagePromptRequest("image prompt"));

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

        await svc.GenerateImageAsync(BuildImagePromptRequest("image prompt"));

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

        var result = await svc.GenerateImageAsync(BuildImagePromptRequest("image prompt"));

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

        await svc.GenerateImageAsync(BuildImagePromptRequest("image prompt"));

        loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("Azure Foundry image generation HTTP request failed")),
                It.IsAny<HttpRequestException>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }
}
