using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using XPoster.Contracts;
using XPoster.Services;

namespace XPoster.Tests.Services;

/// <summary>
/// Unit tests for <see cref="AiServiceHelper.ParseChatCompletionResponseAsync"/> and
/// <see cref="AiServiceHelper.ParseImageResponseAsync"/>.
/// Verifies shared guard pipelines and provider-specific byte-extraction branches.
/// </summary>
public class AiServiceHelperTests
{
    private static readonly Mock<ILogger> _logger = new();

    // -------------------------------------------------------------------------
    // Helpers
    // -------------------------------------------------------------------------

    private static HttpResponseMessage MakeResponse(HttpStatusCode code, string body) =>
        new(code) { Content = new StringContent(body, Encoding.UTF8, "application/json") };

    private static string ChatJson(string content) =>
        $"{{\"choices\":[{{\"message\":{{\"content\":\"{content}\"}}}}]}}";

    /// <summary>Builds an HttpClient whose handler returns the given response for any request.</summary>
    private static HttpClient MakeHttpClient(HttpResponseMessage handlerResponse)
    {
        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(handlerResponse);
        return new HttpClient(handler.Object);
    }

    private static HttpClient MakeHttpClientThatThrows(HttpRequestException ex)
    {
        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(ex);
        return new HttpClient(handler.Object);
    }

    private static string OpenAiB64Json(string b64) =>
        $"{{\"data\":[{{\"b64_json\":\"{b64}\"}}]}}";

    private static string AzureFoundryB64Json(string b64) =>
        $"{{\"data\":[{{\"b64_json\":\"{b64}\"}}]}}";

    private static string AzureFoundryUrlJson(string url) =>
        $"{{\"data\":[{{\"url\":\"{url}\"}}]}}";

    private static string FalAiJson(string url) =>
        $"{{\"images\":[{{\"url\":\"{url}\"}}]}}";

    // -------------------------------------------------------------------------
    // ParseChatCompletionResponseAsync
    // -------------------------------------------------------------------------

    [Fact]
    public async Task ParseChatCompletionResponseAsync_WhenStatusIs429_ReturnsFalseAndEmpty()
    {
        var response = MakeResponse(HttpStatusCode.TooManyRequests, "{}");

        var (success, content) = await AiServiceHelper.ParseChatCompletionResponseAsync(
            response, "TestProvider", "test operation", _logger.Object, CancellationToken.None);

        Assert.False(success);
        Assert.Equal(string.Empty, content);
    }

    [Fact]
    public async Task ParseChatCompletionResponseAsync_WhenStatusIs429_LogsInformation()
    {
        var loggerMock = new Mock<ILogger>();
        var response = MakeResponse(HttpStatusCode.TooManyRequests, "{}");

        await AiServiceHelper.ParseChatCompletionResponseAsync(
            response, "MyProvider", "summary generation", loggerMock.Object, CancellationToken.None);

        loggerMock.Verify(
            l => l.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) =>
                    v.ToString()!.Contains("MyProvider") &&
                    (v.ToString()!.Contains("429") || v.ToString()!.Contains("TooManyRequests"))),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Theory]
    [InlineData(HttpStatusCode.BadRequest)]
    [InlineData(HttpStatusCode.InternalServerError)]
    [InlineData(HttpStatusCode.BadGateway)]
    [InlineData(HttpStatusCode.ServiceUnavailable)]
    public async Task ParseChatCompletionResponseAsync_WhenStatusIsNonSuccess_ReturnsFalseAndEmpty(HttpStatusCode code)
    {
        var response = MakeResponse(code, "{}");

        var (success, content) = await AiServiceHelper.ParseChatCompletionResponseAsync(
            response, "TestProvider", "test operation", _logger.Object, CancellationToken.None);

        Assert.False(success);
        Assert.Equal(string.Empty, content);
    }

    [Fact]
    public async Task ParseChatCompletionResponseAsync_WhenChoicesIsNull_ReturnsFalseAndEmpty()
    {
        var response = MakeResponse(HttpStatusCode.OK, "{\"choices\":null}");

        var (success, content) = await AiServiceHelper.ParseChatCompletionResponseAsync(
            response, "TestProvider", "test operation", _logger.Object, CancellationToken.None);

        Assert.False(success);
        Assert.Equal(string.Empty, content);
    }

    [Fact]
    public async Task ParseChatCompletionResponseAsync_WhenChoicesIsEmpty_ReturnsFalseAndEmpty()
    {
        var response = MakeResponse(HttpStatusCode.OK, "{\"choices\":[]}");

        var (success, content) = await AiServiceHelper.ParseChatCompletionResponseAsync(
            response, "TestProvider", "test operation", _logger.Object, CancellationToken.None);

        Assert.False(success);
        Assert.Equal(string.Empty, content);
    }

    [Fact]
    public async Task ParseChatCompletionResponseAsync_WhenResponseBodyIsEmpty_ReturnsFalseAndEmpty()
    {
        var response = MakeResponse(HttpStatusCode.OK, "{}");

        var (success, content) = await AiServiceHelper.ParseChatCompletionResponseAsync(
            response, "TestProvider", "test operation", _logger.Object, CancellationToken.None);

        Assert.False(success);
        Assert.Equal(string.Empty, content);
    }

    [Fact]
    public async Task ParseChatCompletionResponseAsync_WhenValidResponse_ReturnsTrueAndTrimmedContent()
    {
        var response = MakeResponse(HttpStatusCode.OK, ChatJson("  hello world  "));

        var (success, content) = await AiServiceHelper.ParseChatCompletionResponseAsync(
            response, "TestProvider", "test operation", _logger.Object, CancellationToken.None);

        Assert.True(success);
        Assert.Equal("hello world", content);
    }

    [Fact]
    public async Task ParseChatCompletionResponseAsync_WhenContentIsWhitespaceOnly_ReturnsTrueAndEmpty()
    {
        var response = MakeResponse(HttpStatusCode.OK, ChatJson("   "));

        var (success, content) = await AiServiceHelper.ParseChatCompletionResponseAsync(
            response, "TestProvider", "test operation", _logger.Object, CancellationToken.None);

        Assert.True(success);
        Assert.Equal(string.Empty, content);
    }

    [Fact]
    public async Task ParseChatCompletionResponseAsync_WhenNonSuccess_LogsProviderNameAndStatusCode()
    {
        var loggerMock = new Mock<ILogger>();
        var response = MakeResponse(HttpStatusCode.InternalServerError, "{}");

        await AiServiceHelper.ParseChatCompletionResponseAsync(
            response, "DeepSeek", "image prompt generation", loggerMock.Object, CancellationToken.None);

        loggerMock.Verify(
            l => l.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) =>
                    v.ToString()!.Contains("DeepSeek") &&
                    v.ToString()!.Contains("InternalServerError")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task ParseChatCompletionResponseAsync_WhenEmptyChoices_LogsWarningWithProviderName()
    {
        var loggerMock = new Mock<ILogger>();
        var response = MakeResponse(HttpStatusCode.OK, "{\"choices\":[]}");

        await AiServiceHelper.ParseChatCompletionResponseAsync(
            response, "AzureFoundry", "summary generation", loggerMock.Object, CancellationToken.None);

        loggerMock.Verify(
            l => l.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("AzureFoundry")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    // -------------------------------------------------------------------------
    // ParseImageResponseAsync — HTTP guard pipeline (provider-agnostic)
    // -------------------------------------------------------------------------

    [Fact]
    public async Task ParseImageResponseAsync_WhenStatusIs429_ReturnsEmptyArray()
    {
        var response = MakeResponse(HttpStatusCode.TooManyRequests, "{}");
        var httpClient = MakeHttpClient(MakeResponse(HttpStatusCode.OK, "{}"));

        var result = await AiServiceHelper.ParseImageResponseAsync(
            response, AiProvider.OpenAi, httpClient, _logger.Object, null, CancellationToken.None);

        Assert.Empty(result);
    }

    [Fact]
    public async Task ParseImageResponseAsync_WhenStatusIs429_LogsWarning()
    {
        var loggerMock = new Mock<ILogger>();
        var response = MakeResponse(HttpStatusCode.TooManyRequests, "{}");
        var httpClient = MakeHttpClient(MakeResponse(HttpStatusCode.OK, "{}"));

        await AiServiceHelper.ParseImageResponseAsync(
            response, AiProvider.OpenAi, httpClient, loggerMock.Object, null, CancellationToken.None);

        loggerMock.Verify(
            l => l.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) =>
                    v.ToString()!.Contains("429") || v.ToString()!.Contains("TooManyRequests")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Theory]
    [InlineData(HttpStatusCode.BadRequest)]
    [InlineData(HttpStatusCode.InternalServerError)]
    [InlineData(HttpStatusCode.BadGateway)]
    [InlineData(HttpStatusCode.ServiceUnavailable)]
    public async Task ParseImageResponseAsync_WhenStatusIsNonSuccess_ReturnsEmptyArray(HttpStatusCode code)
    {
        var response = MakeResponse(code, "{}");
        var httpClient = MakeHttpClient(MakeResponse(HttpStatusCode.OK, "{}"));

        var result = await AiServiceHelper.ParseImageResponseAsync(
            response, AiProvider.OpenAi, httpClient, _logger.Object, null, CancellationToken.None);

        Assert.Empty(result);
    }

    [Fact]
    public async Task ParseImageResponseAsync_WhenStatusIsNonSuccess_LogsError()
    {
        var loggerMock = new Mock<ILogger>();
        var response = MakeResponse(HttpStatusCode.InternalServerError, "{}");
        var httpClient = MakeHttpClient(MakeResponse(HttpStatusCode.OK, "{}"));

        await AiServiceHelper.ParseImageResponseAsync(
            response, AiProvider.OpenAi, httpClient, loggerMock.Object, null, CancellationToken.None);

        loggerMock.Verify(
            l => l.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("InternalServerError")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task ParseImageResponseAsync_WhenMalformedJson_ReturnsEmptyArray()
    {
        var response = MakeResponse(HttpStatusCode.OK, "NOT_JSON");
        var httpClient = MakeHttpClient(MakeResponse(HttpStatusCode.OK, "{}"));

        var result = await AiServiceHelper.ParseImageResponseAsync(
            response, AiProvider.OpenAi, httpClient, _logger.Object, null, CancellationToken.None);

        Assert.Empty(result);
    }

    [Fact]
    public async Task ParseImageResponseAsync_WhenMalformedJson_LogsError()
    {
        var loggerMock = new Mock<ILogger>();
        var response = MakeResponse(HttpStatusCode.OK, "NOT_JSON");
        var httpClient = MakeHttpClient(MakeResponse(HttpStatusCode.OK, "{}"));

        await AiServiceHelper.ParseImageResponseAsync(
            response, AiProvider.OpenAi, httpClient, loggerMock.Object, null, CancellationToken.None);

        loggerMock.Verify(
            l => l.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("malformed")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    // -------------------------------------------------------------------------
    // ParseImageResponseAsync — OpenAi branch
    // -------------------------------------------------------------------------

    [Fact]
    public async Task ParseImageResponseAsync_OpenAi_ValidB64Json_ReturnsDecodedBytes()
    {
        var expected = new byte[] { 1, 2, 3 };
        var b64 = Convert.ToBase64String(expected);
        var response = MakeResponse(HttpStatusCode.OK, OpenAiB64Json(b64));
        var httpClient = MakeHttpClient(MakeResponse(HttpStatusCode.OK, "{}"));

        var result = await AiServiceHelper.ParseImageResponseAsync(
            response, AiProvider.OpenAi, httpClient, _logger.Object, null, CancellationToken.None);

        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task ParseImageResponseAsync_OpenAi_MissingDataArray_ReturnsEmptyArray()
    {
        var response = MakeResponse(HttpStatusCode.OK, "{}");
        var httpClient = MakeHttpClient(MakeResponse(HttpStatusCode.OK, "{}"));

        var result = await AiServiceHelper.ParseImageResponseAsync(
            response, AiProvider.OpenAi, httpClient, _logger.Object, null, CancellationToken.None);

        Assert.Empty(result);
    }

    [Fact]
    public async Task ParseImageResponseAsync_OpenAi_EmptyDataArray_ReturnsEmptyArray()
    {
        var response = MakeResponse(HttpStatusCode.OK, "{\"data\":[]}");
        var httpClient = MakeHttpClient(MakeResponse(HttpStatusCode.OK, "{}"));

        var result = await AiServiceHelper.ParseImageResponseAsync(
            response, AiProvider.OpenAi, httpClient, _logger.Object, null, CancellationToken.None);

        Assert.Empty(result);
    }

    [Fact]
    public async Task ParseImageResponseAsync_OpenAi_MissingB64JsonProperty_ReturnsEmptyArray()
    {
        var response = MakeResponse(HttpStatusCode.OK, "{\"data\":[{\"url\":\"http://example.com/img.png\"}]}");
        var httpClient = MakeHttpClient(MakeResponse(HttpStatusCode.OK, "{}"));

        var result = await AiServiceHelper.ParseImageResponseAsync(
            response, AiProvider.OpenAi, httpClient, _logger.Object, null, CancellationToken.None);

        Assert.Empty(result);
    }

    [Fact]
    public async Task ParseImageResponseAsync_OpenAi_EmptyB64JsonValue_ReturnsEmptyArray()
    {
        var response = MakeResponse(HttpStatusCode.OK, "{\"data\":[{\"b64_json\":\"\"}]}");
        var httpClient = MakeHttpClient(MakeResponse(HttpStatusCode.OK, "{}"));

        var result = await AiServiceHelper.ParseImageResponseAsync(
            response, AiProvider.OpenAi, httpClient, _logger.Object, null, CancellationToken.None);

        Assert.Empty(result);
    }

    // -------------------------------------------------------------------------
    // ParseImageResponseAsync — AzureFoundry branch
    // -------------------------------------------------------------------------

    [Fact]
    public async Task ParseImageResponseAsync_AzureFoundry_ValidB64Json_ReturnsDecodedBytes()
    {
        var expected = new byte[] { 10, 20, 30 };
        var b64 = Convert.ToBase64String(expected);
        var response = MakeResponse(HttpStatusCode.OK, AzureFoundryB64Json(b64));
        var httpClient = MakeHttpClient(MakeResponse(HttpStatusCode.OK, "{}"));

        var result = await AiServiceHelper.ParseImageResponseAsync(
            response, AiProvider.AzureFoundry, httpClient, _logger.Object, null, CancellationToken.None);

        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task ParseImageResponseAsync_AzureFoundry_UrlFallback_AllowedOrigin_ReturnsDownloadedBytes()
    {
        var expected = new byte[] { 7, 8, 9 };
        var imageUrl = "https://allowed.origin.com/image.png";
        var response = MakeResponse(HttpStatusCode.OK, AzureFoundryUrlJson(imageUrl));

        var imageResponse = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new ByteArrayContent(expected)
        };
        var httpClient = MakeHttpClient(imageResponse);

        var result = await AiServiceHelper.ParseImageResponseAsync(
            response, AiProvider.AzureFoundry, httpClient, _logger.Object,
            "https://allowed.origin.com", CancellationToken.None);

        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task ParseImageResponseAsync_AzureFoundry_UrlFallback_WrongOrigin_ReturnsEmptyArray()
    {
        var imageUrl = "https://evil.com/image.png";
        var response = MakeResponse(HttpStatusCode.OK, AzureFoundryUrlJson(imageUrl));
        var httpClient = MakeHttpClient(MakeResponse(HttpStatusCode.OK, "{}"));

        var result = await AiServiceHelper.ParseImageResponseAsync(
            response, AiProvider.AzureFoundry, httpClient, _logger.Object,
            "https://allowed.origin.com", CancellationToken.None);

        Assert.Empty(result);
    }

    [Fact]
    public async Task ParseImageResponseAsync_AzureFoundry_UrlFallback_WrongOrigin_LogsWarning()
    {
        var loggerMock = new Mock<ILogger>();
        var imageUrl = "https://evil.com/image.png";
        var response = MakeResponse(HttpStatusCode.OK, AzureFoundryUrlJson(imageUrl));
        var httpClient = MakeHttpClient(MakeResponse(HttpStatusCode.OK, "{}"));

        await AiServiceHelper.ParseImageResponseAsync(
            response, AiProvider.AzureFoundry, httpClient, loggerMock.Object,
            "https://allowed.origin.com", CancellationToken.None);

        loggerMock.Verify(
            l => l.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("origin")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task ParseImageResponseAsync_AzureFoundry_UrlFallback_DownloadFails_ReturnsEmptyArray()
    {
        var imageUrl = "https://allowed.origin.com/image.png";
        var response = MakeResponse(HttpStatusCode.OK, AzureFoundryUrlJson(imageUrl));
        var httpClient = MakeHttpClientThatThrows(new HttpRequestException("network error"));

        var result = await AiServiceHelper.ParseImageResponseAsync(
            response, AiProvider.AzureFoundry, httpClient, _logger.Object,
            "https://allowed.origin.com", CancellationToken.None);

        Assert.Empty(result);
    }

    [Fact]
    public async Task ParseImageResponseAsync_AzureFoundry_MissingDataArray_ReturnsEmptyArray()
    {
        var response = MakeResponse(HttpStatusCode.OK, "{}");
        var httpClient = MakeHttpClient(MakeResponse(HttpStatusCode.OK, "{}"));

        var result = await AiServiceHelper.ParseImageResponseAsync(
            response, AiProvider.AzureFoundry, httpClient, _logger.Object, null, CancellationToken.None);

        Assert.Empty(result);
    }

    // -------------------------------------------------------------------------
    // ParseImageResponseAsync — DeepSeekWithFal branch
    // -------------------------------------------------------------------------

    [Fact]
    public async Task ParseImageResponseAsync_FalAi_ValidUrl_ReturnsDownloadedBytes()
    {
        var expected = new byte[] { 50, 60, 70 };
        var imageUrl = "https://fal.ai/image.png";
        var response = MakeResponse(HttpStatusCode.OK, FalAiJson(imageUrl));

        var imageResponse = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new ByteArrayContent(expected)
        };
        var httpClient = MakeHttpClient(imageResponse);

        var result = await AiServiceHelper.ParseImageResponseAsync(
            response, AiProvider.DeepSeekWithFal, httpClient, _logger.Object, null, CancellationToken.None);

        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task ParseImageResponseAsync_FalAi_MissingImagesArray_ReturnsEmptyArray()
    {
        var response = MakeResponse(HttpStatusCode.OK, "{}");
        var httpClient = MakeHttpClient(MakeResponse(HttpStatusCode.OK, "{}"));

        var result = await AiServiceHelper.ParseImageResponseAsync(
            response, AiProvider.DeepSeekWithFal, httpClient, _logger.Object, null, CancellationToken.None);

        Assert.Empty(result);
    }

    [Fact]
    public async Task ParseImageResponseAsync_FalAi_EmptyImagesArray_ReturnsEmptyArray()
    {
        var response = MakeResponse(HttpStatusCode.OK, "{\"images\":[]}");
        var httpClient = MakeHttpClient(MakeResponse(HttpStatusCode.OK, "{}"));

        var result = await AiServiceHelper.ParseImageResponseAsync(
            response, AiProvider.DeepSeekWithFal, httpClient, _logger.Object, null, CancellationToken.None);

        Assert.Empty(result);
    }

    [Fact]
    public async Task ParseImageResponseAsync_FalAi_MissingUrlProperty_ReturnsEmptyArray()
    {
        var response = MakeResponse(HttpStatusCode.OK, "{\"images\":[{\"b64_json\":\"abc\"}]}");
        var httpClient = MakeHttpClient(MakeResponse(HttpStatusCode.OK, "{}"));

        var result = await AiServiceHelper.ParseImageResponseAsync(
            response, AiProvider.DeepSeekWithFal, httpClient, _logger.Object, null, CancellationToken.None);

        Assert.Empty(result);
    }

    [Fact]
    public async Task ParseImageResponseAsync_FalAi_DownloadFails_ReturnsEmptyArray()
    {
        var response = MakeResponse(HttpStatusCode.OK, FalAiJson("https://fal.ai/image.png"));
        var httpClient = MakeHttpClientThatThrows(new HttpRequestException("timeout"));

        var result = await AiServiceHelper.ParseImageResponseAsync(
            response, AiProvider.DeepSeekWithFal, httpClient, _logger.Object, null, CancellationToken.None);

        Assert.Empty(result);
    }

    // -------------------------------------------------------------------------
    // ParseImageResponseAsync — unsupported provider
    // -------------------------------------------------------------------------

    [Fact]
    public async Task ParseImageResponseAsync_UnsupportedProvider_ReturnsEmptyArray()
    {
        var response = MakeResponse(HttpStatusCode.OK, "{\"data\":[{\"b64_json\":\"YWJj\"}]}");
        var httpClient = MakeHttpClient(MakeResponse(HttpStatusCode.OK, "{}"));

        // AiProvider.None is not handled by the switch expression
        var result = await AiServiceHelper.ParseImageResponseAsync(
            response, AiProvider.None, httpClient, _logger.Object, null, CancellationToken.None);

        Assert.Empty(result);
    }

    [Fact]
    public async Task ParseImageResponseAsync_UnsupportedProvider_LogsError()
    {
        var loggerMock = new Mock<ILogger>();
        var response = MakeResponse(HttpStatusCode.OK, "{\"data\":[{\"b64_json\":\"YWJj\"}]}");
        var httpClient = MakeHttpClient(MakeResponse(HttpStatusCode.OK, "{}"));

        await AiServiceHelper.ParseImageResponseAsync(
            response, AiProvider.None, httpClient, loggerMock.Object, null, CancellationToken.None);

        loggerMock.Verify(
            l => l.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }
}
