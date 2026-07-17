using System.Net;
using System.Text;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using XPoster.Models;
using XPoster.Services;

namespace XPoster.Tests.Services;

public class FalAiImageServiceTests
{
    private static FalAiImageService BuildService(
        HttpMessageHandler handler,
        out Mock<ILogger<FalAiImageService>> loggerMock,
        FalAiOptions? opts = null)
    {
        loggerMock = new Mock<ILogger<FalAiImageService>>();
        var factory = new Mock<IHttpClientFactory>();
        var client = new HttpClient(handler);
        factory.Setup(f => f.CreateClient(It.IsAny<string>())).Returns(client);

        var options = Options.Create(opts ?? new FalAiOptions
        {
            ApiKey = "fake-api-key",
            ImageModelName = "fal-ai/flux/schnell"
        });

        return new FalAiImageService(factory.Object, options, loggerMock.Object);
    }

    private static Mock<HttpMessageHandler> MakeHandlerMock(HttpStatusCode code, string body)
    {
        var mock = new Mock<HttpMessageHandler>();
        mock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(code)
            {
                Content = new StringContent(body, Encoding.UTF8, "application/json")
            });
        return mock;
    }

    private static string FalImageJson(string imageUrl) =>
        $"{{\"images\":[{{\"url\":\"{imageUrl}\"}}]}}";

    private static ImagePromptRequest MakeRequest(string inputText) => new()
    {
        InputText = inputText,
        SystemPromptTemplate = "You are an image generation assistant.",
        UserPromptTemplate = "{Text}"
    };

    [Fact]
    public async Task GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{}").Object, out _);

        var result = await svc.GenerateImageAsync(MakeRequest(string.Empty));

        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{}").Object, out _);

        var result = await svc.GenerateImageAsync(MakeRequest("   "));

        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_Returns429_ReturnsEmptyArray()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.TooManyRequests, "{}").Object, out _);

        var result = await svc.GenerateImageAsync(MakeRequest("a prompt"));

        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_Returns429_LogsWarning()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.TooManyRequests, "{}").Object, out var loggerMock);

        await svc.GenerateImageAsync(MakeRequest("a prompt"));

        loggerMock.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) =>
                    v.ToString()!.Contains("fal.ai") &&
                    (v.ToString()!.Contains("429") || v.ToString()!.Contains("TooManyRequests"))),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.InternalServerError, "{}").Object, out _);

        var result = await svc.GenerateImageAsync(MakeRequest("a prompt"));

        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_MalformedJson_ReturnsEmptyArray()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "NOT-JSON").Object, out _);

        var result = await svc.GenerateImageAsync(MakeRequest("a prompt"));

        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{\"images\":[]}").Object, out _);

        var result = await svc.GenerateImageAsync(MakeRequest("a prompt"));

        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{\"other\":\"value\"}").Object, out _);

        var result = await svc.GenerateImageAsync(MakeRequest("a prompt"));

        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray()
    {
        var svc = BuildService(
            MakeHandlerMock(HttpStatusCode.OK, "{\"images\":[{\"width\":512}]}").Object, out _);

        var result = await svc.GenerateImageAsync(MakeRequest("a prompt"));

        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray()
    {
        var svc = BuildService(
            MakeHandlerMock(HttpStatusCode.OK, "{\"images\":[{\"url\":\"\"}]}").Object, out _);

        var result = await svc.GenerateImageAsync(MakeRequest("a prompt"));

        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_ValidResponse_ReturnsImageBytes()
    {
        var expectedBytes = new byte[] { 137, 80, 78, 71 };
        var handlerMock = new Mock<HttpMessageHandler>();
        var imageUrl = "https://cdn.fal.ai/output/image.png";

        handlerMock.Protected()
            .SetupSequence<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(FalImageJson(imageUrl), Encoding.UTF8, "application/json")
            })
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(expectedBytes)
            });

        var svc = BuildService(handlerMock.Object, out _);

        var result = await svc.GenerateImageAsync(MakeRequest("a prompt"));

        Assert.Equal(expectedBytes, result);
    }

    [Fact]
    public async Task GenerateImageAsync_RequestUsesImageQuantityFromRequest()
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        HttpRequestMessage? capturedRequest = null;
        string? capturedBody = null;

        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .Callback<HttpRequestMessage, CancellationToken>(async (req, _) =>
            {
                capturedRequest = req;
                capturedBody = await req.Content!.ReadAsStringAsync();
            })
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.TooManyRequests));

        var svc = BuildService(handlerMock.Object, out _);
        var request = new ImagePromptRequest
        {
            InputText = "a prompt",
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "{Text}",
            ImageQuantity = 3,
            ImageSize = "512x512"
        };

        await svc.GenerateImageAsync(request);

        Assert.NotNull(capturedBody);
        Assert.Contains("\"num_images\":3", capturedBody);
        Assert.Contains("\"image_size\":\"512x512\"", capturedBody);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray()
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        var imageUrl = "https://cdn.fal.ai/output/image.png";

        handlerMock.Protected()
            .SetupSequence<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(FalImageJson(imageUrl), Encoding.UTF8, "application/json")
            })
            .ThrowsAsync(new HttpRequestException("download failed"));

        var svc = BuildService(handlerMock.Object, out _);

        var result = await svc.GenerateImageAsync(MakeRequest("a prompt"));

        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError()
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        var imageUrl = "https://cdn.fal.ai/output/image.png";

        handlerMock.Protected()
            .SetupSequence<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(FalImageJson(imageUrl), Encoding.UTF8, "application/json")
            })
            .ThrowsAsync(new HttpRequestException("download failed"));

        var svc = BuildService(handlerMock.Object, out var loggerMock);

        await svc.GenerateImageAsync(MakeRequest("a prompt"));

        // Message is now emitted by AiServiceHelper.ExtractFalAiBytesAsync
        loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) =>
                    v.ToString()!.Contains("fal.ai") &&
                    v.ToString()!.Contains("failed to download generated image from URL") &&
                    v.ToString()!.Contains(imageUrl)),
                It.IsAny<HttpRequestException>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri()
    {
        var opts = new FalAiOptions { ApiKey = "key", ImageModelName = "fal-ai/model with space" };

        HttpRequestMessage? capturedRequest = null;
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .Callback<HttpRequestMessage, CancellationToken>((req, _) => capturedRequest = req)
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.TooManyRequests));

        var svc = BuildService(handlerMock.Object, out _, opts);

        await svc.GenerateImageAsync(MakeRequest("a prompt"));

        Assert.NotNull(capturedRequest);
        var path = capturedRequest!.RequestUri!.AbsolutePath;
        Assert.DoesNotContain(" ", path);
        Assert.Contains("%20", path, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri()
    {
        HttpRequestMessage? capturedRequest = null;
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .Callback<HttpRequestMessage, CancellationToken>((req, _) => capturedRequest = req)
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.TooManyRequests));

        var svc = BuildService(handlerMock.Object, out _);

        await svc.GenerateImageAsync(MakeRequest("a prompt"));

        Assert.NotNull(capturedRequest);
        var path = capturedRequest!.RequestUri!.AbsolutePath;
        Assert.Contains("/fal-ai/flux/schnell", path, StringComparison.Ordinal);
    }
}
