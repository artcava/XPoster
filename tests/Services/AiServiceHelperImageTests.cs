using System.Net;
using System.Text;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using XPoster.Contracts;
using XPoster.Services;

namespace XPoster.Tests.Services;

/// <summary>
/// Tests for AiServiceHelper.ParseImageResponseAsync(response, AiProvider, httpClient, logger, allowedOrigin, ct).
/// </summary>
public class AiServiceHelperImageTests
{
    private static HttpClient MakeNoOpClient()
    {
        var handler = new Mock<HttpMessageHandler>();
        return new HttpClient(handler.Object);
    }

    /// <summary>
    /// Returns an HttpClient whose handler returns <paramref name="downloadBytes"/> on the first SendAsync
    /// (i.e. the image download request issued inside the extractor).
    /// </summary>
    private static HttpClient MakeDownloadClient(byte[] downloadBytes)
    {
        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(downloadBytes)
            });
        return new HttpClient(handler.Object);
    }

    /// <summary>
    /// Returns an HttpClient whose handler throws <see cref="HttpRequestException"/> on the first SendAsync.
    /// </summary>
    private static (HttpClient Client, Mock<ILogger> Logger) MakeThrowingDownloadClient()
    {
        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new HttpRequestException("download failed"));
        return (new HttpClient(handler.Object), new Mock<ILogger>());
    }

    private static HttpResponseMessage JsonResponse(string body) =>
        new(HttpStatusCode.OK)
        {
            Content = new StringContent(body, Encoding.UTF8, "application/json")
        };

    // ── HTTP guard pipeline ─────────────────────────────────────────────────

    [Theory]
    [InlineData(AiProvider.OpenAi)]
    [InlineData(AiProvider.AzureFoundry)]
    [InlineData(AiProvider.DeepSeekWithFal)]
    public async Task Parse_Returns429_ReturnsEmpty(AiProvider provider)
    {
        var logger = new Mock<ILogger>();
        var response = new HttpResponseMessage(HttpStatusCode.TooManyRequests);

        var result = await AiServiceHelper.ParseImageResponseAsync(
            response, provider, MakeNoOpClient(), logger.Object, null, CancellationToken.None);

        Assert.Empty(result);
    }

    [Theory]
    [InlineData(AiProvider.OpenAi)]
    [InlineData(AiProvider.AzureFoundry)]
    [InlineData(AiProvider.DeepSeekWithFal)]
    public async Task Parse_Returns429_LogsWarning(AiProvider provider)
    {
        var logger = new Mock<ILogger>();
        var response = new HttpResponseMessage(HttpStatusCode.TooManyRequests);

        await AiServiceHelper.ParseImageResponseAsync(
            response, provider, MakeNoOpClient(), logger.Object, null, CancellationToken.None);

        logger.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) =>
                    v.ToString()!.Contains("429") || v.ToString()!.Contains("TooManyRequests")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Theory]
    [InlineData(AiProvider.OpenAi)]
    [InlineData(AiProvider.AzureFoundry)]
    [InlineData(AiProvider.DeepSeekWithFal)]
    public async Task Parse_NonSuccessStatus_ReturnsEmpty(AiProvider provider)
    {
        var logger = new Mock<ILogger>();
        var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);

        var result = await AiServiceHelper.ParseImageResponseAsync(
            response, provider, MakeNoOpClient(), logger.Object, null, CancellationToken.None);

        Assert.Empty(result);
    }

    [Theory]
    [InlineData(AiProvider.OpenAi)]
    [InlineData(AiProvider.AzureFoundry)]
    [InlineData(AiProvider.DeepSeekWithFal)]
    public async Task Parse_MalformedJson_ReturnsEmpty(AiProvider provider)
    {
        var logger = new Mock<ILogger>();
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent("NOT-JSON", Encoding.UTF8, "application/json")
        };

        var result = await AiServiceHelper.ParseImageResponseAsync(
            response, provider, MakeNoOpClient(), logger.Object, null, CancellationToken.None);

        Assert.Empty(result);
    }

    // ── OpenAI extractor ────────────────────────────────────────────────────

    [Fact]
    public async Task Parse_OpenAi_ValidB64_ReturnsBytes()
    {
        var expected = new byte[] { 1, 2, 3, 4 };
        var b64 = Convert.ToBase64String(expected);
        var json = $"{{\"data\":[{{\"b64_json\":\"{b64}\"}}]}}";
        var logger = new Mock<ILogger>();

        var result = await AiServiceHelper.ParseImageResponseAsync(
            JsonResponse(json), AiProvider.OpenAi, MakeNoOpClient(), logger.Object, null, CancellationToken.None);

        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task Parse_OpenAi_MissingDataProperty_ReturnsEmpty()
    {
        var logger = new Mock<ILogger>();

        var result = await AiServiceHelper.ParseImageResponseAsync(
            JsonResponse("{\"other\":\"value\"}"), AiProvider.OpenAi, MakeNoOpClient(), logger.Object, null, CancellationToken.None);

        Assert.Empty(result);
    }

    [Fact]
    public async Task Parse_OpenAi_EmptyDataArray_ReturnsEmpty()
    {
        var logger = new Mock<ILogger>();

        var result = await AiServiceHelper.ParseImageResponseAsync(
            JsonResponse("{\"data\":[]}"), AiProvider.OpenAi, MakeNoOpClient(), logger.Object, null, CancellationToken.None);

        Assert.Empty(result);
    }

    [Fact]
    public async Task Parse_OpenAi_EmptyB64Value_ReturnsEmpty()
    {
        var logger = new Mock<ILogger>();

        var result = await AiServiceHelper.ParseImageResponseAsync(
            JsonResponse("{\"data\":[{\"b64_json\":\"\"}]}"), AiProvider.OpenAi, MakeNoOpClient(), logger.Object, null, CancellationToken.None);

        Assert.Empty(result);
    }

    // ── fal.ai extractor ────────────────────────────────────────────────────

    [Fact]
    public async Task Parse_FalAi_ValidUrl_ReturnsBytes()
    {
        var expected = new byte[] { 10, 20, 30 };
        var imageUrl = "https://cdn.fal.ai/img.png";
        var json = $"{{\"images\":[{{\"url\":\"{imageUrl}\"}}]}}";
        var logger = new Mock<ILogger>();

        var result = await AiServiceHelper.ParseImageResponseAsync(
            JsonResponse(json), AiProvider.DeepSeekWithFal,
            MakeDownloadClient(expected), logger.Object, null, CancellationToken.None);

        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task Parse_FalAi_MissingImagesProperty_ReturnsEmpty()
    {
        var logger = new Mock<ILogger>();

        var result = await AiServiceHelper.ParseImageResponseAsync(
            JsonResponse("{\"other\":\"value\"}"), AiProvider.DeepSeekWithFal,
            MakeNoOpClient(), logger.Object, null, CancellationToken.None);

        Assert.Empty(result);
    }

    [Fact]
    public async Task Parse_FalAi_EmptyImagesArray_ReturnsEmpty()
    {
        var logger = new Mock<ILogger>();

        var result = await AiServiceHelper.ParseImageResponseAsync(
            JsonResponse("{\"images\":[]}"), AiProvider.DeepSeekWithFal,
            MakeNoOpClient(), logger.Object, null, CancellationToken.None);

        Assert.Empty(result);
    }

    [Fact]
    public async Task Parse_FalAi_MissingUrlProperty_ReturnsEmpty()
    {
        var logger = new Mock<ILogger>();

        var result = await AiServiceHelper.ParseImageResponseAsync(
            JsonResponse("{\"images\":[{\"width\":512}]}"), AiProvider.DeepSeekWithFal,
            MakeNoOpClient(), logger.Object, null, CancellationToken.None);

        Assert.Empty(result);
    }

    [Fact]
    public async Task Parse_FalAi_EmptyUrl_ReturnsEmpty()
    {
        var logger = new Mock<ILogger>();

        var result = await AiServiceHelper.ParseImageResponseAsync(
            JsonResponse("{\"images\":[{\"url\":\"\"}]}"), AiProvider.DeepSeekWithFal,
            MakeNoOpClient(), logger.Object, null, CancellationToken.None);

        Assert.Empty(result);
    }

    [Fact]
    public async Task Parse_FalAi_DownloadThrows_ReturnsEmpty()
    {
        var imageUrl = "https://cdn.fal.ai/img.png";
        var json = $"{{\"images\":[{{\"url\":\"{imageUrl}\"}}]}}";
        var (client, _) = MakeThrowingDownloadClient();
        var logger = new Mock<ILogger>();

        var result = await AiServiceHelper.ParseImageResponseAsync(
            JsonResponse(json), AiProvider.DeepSeekWithFal,
            client, logger.Object, null, CancellationToken.None);

        Assert.Empty(result);
    }

    [Fact]
    public async Task Parse_FalAi_DownloadThrows_LogsError()
    {
        var imageUrl = "https://cdn.fal.ai/img.png";
        var json = $"{{\"images\":[{{\"url\":\"{imageUrl}\"}}]}}";
        var (client, _) = MakeThrowingDownloadClient();
        var logger = new Mock<ILogger>();

        await AiServiceHelper.ParseImageResponseAsync(
            JsonResponse(json), AiProvider.DeepSeekWithFal,
            client, logger.Object, null, CancellationToken.None);

        logger.Verify(
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

    // ── AzureFoundry extractor ──────────────────────────────────────────────

    [Fact]
    public async Task Parse_AzureFoundry_ValidB64_ReturnsBytes()
    {
        var expected = new byte[] { 5, 6, 7, 8 };
        var b64 = Convert.ToBase64String(expected);
        var json = $"{{\"data\":[{{\"b64_json\":\"{b64}\"}}]}}";
        var logger = new Mock<ILogger>();

        var result = await AiServiceHelper.ParseImageResponseAsync(
            JsonResponse(json), AiProvider.AzureFoundry,
            MakeNoOpClient(), logger.Object, null, CancellationToken.None);

        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task Parse_AzureFoundry_UrlFallback_ReturnsBytes()
    {
        var expected = new byte[] { 11, 22, 33 };
        var imageUrl = "https://foundry.azure.com/img.png";
        var json = $"{{\"data\":[{{\"url\":\"{imageUrl}\"}}]}}";
        var logger = new Mock<ILogger>();

        var result = await AiServiceHelper.ParseImageResponseAsync(
            JsonResponse(json), AiProvider.AzureFoundry,
            MakeDownloadClient(expected), logger.Object,
            allowedOrigin: "https://foundry.azure.com", CancellationToken.None);

        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task Parse_AzureFoundry_UrlFallback_WrongOrigin_LogsWarning()
    {
        var imageUrl = "https://other-cdn.net/img.png";
        var json = $"{{\"data\":[{{\"url\":\"{imageUrl}\"}}]}}";
        var expected = new byte[] { 1, 2 };
        var logger = new Mock<ILogger>();

        await AiServiceHelper.ParseImageResponseAsync(
            JsonResponse(json), AiProvider.AzureFoundry,
            MakeDownloadClient(expected), logger.Object,
            allowedOrigin: "https://foundry.azure.com", CancellationToken.None);

        logger.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) =>
                    v.ToString()!.Contains("different origin") &&
                    v.ToString()!.Contains(imageUrl)),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task Parse_AzureFoundry_MissingDataProperty_ReturnsEmpty()
    {
        var logger = new Mock<ILogger>();

        var result = await AiServiceHelper.ParseImageResponseAsync(
            JsonResponse("{\"other\":\"value\"}"), AiProvider.AzureFoundry,
            MakeNoOpClient(), logger.Object, null, CancellationToken.None);

        Assert.Empty(result);
    }

    [Fact]
    public async Task Parse_AzureFoundry_MissingBothB64AndUrl_ReturnsEmpty()
    {
        var logger = new Mock<ILogger>();

        var result = await AiServiceHelper.ParseImageResponseAsync(
            JsonResponse("{\"data\":[{\"width\":512}]}"), AiProvider.AzureFoundry,
            MakeNoOpClient(), logger.Object, null, CancellationToken.None);

        Assert.Empty(result);
    }

    [Fact]
    public async Task Parse_AzureFoundry_UrlFallback_DownloadThrows_ReturnsEmpty()
    {
        var imageUrl = "https://foundry.azure.com/img.png";
        var json = $"{{\"data\":[{{\"url\":\"{imageUrl}\"}}]}}";
        var (client, _) = MakeThrowingDownloadClient();
        var logger = new Mock<ILogger>();

        var result = await AiServiceHelper.ParseImageResponseAsync(
            JsonResponse(json), AiProvider.AzureFoundry,
            client, logger.Object,
            allowedOrigin: "https://foundry.azure.com", CancellationToken.None);

        Assert.Empty(result);
    }

    [Fact]
    public async Task Parse_AzureFoundry_UrlFallback_DownloadThrows_LogsError()
    {
        var imageUrl = "https://foundry.azure.com/img.png";
        var json = $"{{\"data\":[{{\"url\":\"{imageUrl}\"}}]}}";
        var (client, _) = MakeThrowingDownloadClient();
        var logger = new Mock<ILogger>();

        await AiServiceHelper.ParseImageResponseAsync(
            JsonResponse(json), AiProvider.AzureFoundry,
            client, logger.Object,
            allowedOrigin: "https://foundry.azure.com", CancellationToken.None);

        logger.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) =>
                    v.ToString()!.Contains("Azure Foundry") &&
                    v.ToString()!.Contains("failed to download image from fallback URL") &&
                    v.ToString()!.Contains(imageUrl)),
                It.IsAny<HttpRequestException>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    // ── Unsupported provider ─────────────────────────────────────────────────

    [Fact]
    public async Task Parse_UnsupportedProvider_ReturnsEmpty()
    {
        var logger = new Mock<ILogger>();

        var result = await AiServiceHelper.ParseImageResponseAsync(
            JsonResponse("{\"data\":[{\"b64_json\":\"dGVzdA==\"}]}"), AiProvider.Perplexity,
            MakeNoOpClient(), logger.Object, null, CancellationToken.None);

        Assert.Empty(result);
    }

    [Fact]
    public async Task Parse_UnsupportedProvider_LogsError()
    {
        var logger = new Mock<ILogger>();

        await AiServiceHelper.ParseImageResponseAsync(
            JsonResponse("{\"data\":[{\"b64_json\":\"dGVzdA==\"}]}"), AiProvider.Perplexity,
            MakeNoOpClient(), logger.Object, null, CancellationToken.None);

        logger.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) =>
                    v.ToString()!.Contains("Perplexity") &&
                    v.ToString()!.Contains("not supported")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }
}
