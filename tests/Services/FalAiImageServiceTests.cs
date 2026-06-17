using System.Net;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using XPoster.Models;
using XPoster.Services;

namespace XPoster.Tests.Services;

public class FalAiImageServiceTests
{
    // Builds a FalAiImageService with a controllable HttpMessageHandler.
    // The same handler is reused for both the POST (image generation) and the
    // GET (image download) calls, or a dedicated download handler can be provided.
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
            ModelId = "fal-ai/flux/schnell"
        });

        return new FalAiImageService(factory.Object, options, loggerMock.Object);
    }

    // Creates a handler mock that returns the same response for every request.
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

    // Builds the fal.ai image generation response JSON with a single image URL entry.
    private static string FalImageJson(string imageUrl) =>
        $"{{\"images\":[{{\"url\":\"{imageUrl}\"}}]}}";

    // -------------------------------------------------------------------------
    // Prompt guard
    // -------------------------------------------------------------------------

    [Fact]
    public async Task GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{}").Object, out _);

        var result = await svc.GenerateImageAsync(string.Empty);

        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{}").Object, out _);

        var result = await svc.GenerateImageAsync("   ");

        Assert.Empty(result);
    }

    // -------------------------------------------------------------------------
    // HTTP error codes
    // -------------------------------------------------------------------------

    [Fact]
    public async Task GenerateImageAsync_Returns429_ReturnsEmptyArray()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.TooManyRequests, "{}").Object, out _);

        var result = await svc.GenerateImageAsync("a prompt");

        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.InternalServerError, "{}").Object, out _);

        var result = await svc.GenerateImageAsync("a prompt");

        Assert.Empty(result);
    }

    // -------------------------------------------------------------------------
    // JSON parsing
    // -------------------------------------------------------------------------

    [Fact]
    public async Task GenerateImageAsync_MalformedJson_ReturnsEmptyArray()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "NOT-JSON").Object, out _);

        var result = await svc.GenerateImageAsync("a prompt");

        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{\"images\":[]}").Object, out _);

        var result = await svc.GenerateImageAsync("a prompt");

        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{\"other\":\"value\"}").Object, out _);

        var result = await svc.GenerateImageAsync("a prompt");

        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray()
    {
        var svc = BuildService(
            MakeHandlerMock(HttpStatusCode.OK, "{\"images\":[{\"width\":512}]}").Object, out _);

        var result = await svc.GenerateImageAsync("a prompt");

        Assert.Empty(result);
    }

    [Fact]
    public async Task GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray()
    {
        var svc = BuildService(
            MakeHandlerMock(HttpStatusCode.OK, "{\"images\":[{\"url\":\"\"}]}").Object, out _);

        var result = await svc.GenerateImageAsync("a prompt");

        Assert.Empty(result);
    }

    // -------------------------------------------------------------------------
    // Happy path — successful image download
    // -------------------------------------------------------------------------

    [Fact]
    public async Task GenerateImageAsync_ValidResponse_ReturnsImageBytes()
    {
        var expectedBytes = new byte[] { 137, 80, 78, 71 }; // PNG magic bytes

        // First call: POST to fal.run/{model} — returns JSON with image URL
        // Second call: GET the image URL — returns raw bytes
        // We use a sequential setup on the same mock handler.
        var handlerMock = new Mock<HttpMessageHandler>();
        var imageUrl = "https://cdn.fal.ai/output/image.png";

        handlerMock.Protected()
            .SetupSequence<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            // First call: the POST to generate the image
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(FalImageJson(imageUrl), Encoding.UTF8, "application/json")
            })
            // Second call: the GET to download the image
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(expectedBytes)
            });

        var svc = BuildService(handlerMock.Object, out _);

        var result = await svc.GenerateImageAsync("a prompt");

        Assert.Equal(expectedBytes, result);
    }

    // -------------------------------------------------------------------------
    // Endpoint URL encoding — ModelId percent-encoding (Point 1, issue #139)
    // -------------------------------------------------------------------------

    [Fact]
    public async Task GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri()
    {
        // ModelId containing a space — should be encoded as %20 in the request URI.
        // The validator would normally block this at startup; this test verifies that
        // even if an unsafe value reaches the service, the URL construction is safe.
        var opts = new FalAiOptions { ApiKey = "key", ModelId = "fal-ai/model with space" };

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

        await svc.GenerateImageAsync("a prompt");

        Assert.NotNull(capturedRequest);
        // The path must not contain a raw space; it must be percent-encoded.
        var path = capturedRequest!.RequestUri!.AbsolutePath;
        Assert.DoesNotContain(" ", path);
        Assert.Contains("%20", path, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri()
    {
        // Default ModelId "fal-ai/flux/schnell" — slashes must remain as path separators.
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

        await svc.GenerateImageAsync("a prompt");

        Assert.NotNull(capturedRequest);
        var path = capturedRequest!.RequestUri!.AbsolutePath;
        // fal-ai, flux, schnell must all appear as distinct path segments.
        Assert.Contains("/fal-ai/flux/schnell", path, StringComparison.Ordinal);
    }
}
