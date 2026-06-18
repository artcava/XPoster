using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Services;

namespace XPoster.Tests.Services;

/// <summary>
/// Unit tests for <see cref="AiServiceHelper.ParseChatCompletionResponseAsync"/> and
/// <see cref="AiServiceHelper.ParseImageResponseAsync"/>.
/// Verifies shared guard pipelines in isolation.
/// </summary>
public class AiServiceHelperTests
{
    private static readonly Mock<ILogger> _logger = new();

    private static HttpResponseMessage MakeResponse(HttpStatusCode code, string json) =>
        new(code)
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };

    private static string ChatJson(string content) =>
        $"{{\"choices\":[{{\"message\":{{\"content\":\"{content}\"}}}}]}}";

    private static string ImageJson(string propertyName, string propertyValue) =>
        $"{{\"data\":[{{\"{propertyName}\":\"{propertyValue}\"}}]}}";

    // --- chat completion helper ---

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

    // --- image helper ---

    [Fact]
    public async Task ParseImageResponseAsync_WhenStatusIs429_ReturnsFalseAndNull()
    {
        var response = MakeResponse(HttpStatusCode.TooManyRequests, "{}");

        var (success, content) = await AiServiceHelper.ParseImageResponseAsync(
            response, "TestProvider", _logger.Object, CancellationToken.None);

        Assert.False(success);
        Assert.Null(content);
    }

    [Fact]
    public async Task ParseImageResponseAsync_WhenStatusIs429_LogsWarning()
    {
        var loggerMock = new Mock<ILogger>();
        var response = MakeResponse(HttpStatusCode.TooManyRequests, "{}");

        await AiServiceHelper.ParseImageResponseAsync(
            response, "MyProvider", loggerMock.Object, CancellationToken.None);

        loggerMock.Verify(
            l => l.Log(
                LogLevel.Warning,
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
    public async Task ParseImageResponseAsync_WhenStatusIsNonSuccess_ReturnsFalseAndNull(HttpStatusCode code)
    {
        var response = MakeResponse(code, "{}");

        var (success, content) = await AiServiceHelper.ParseImageResponseAsync(
            response, "TestProvider", _logger.Object, CancellationToken.None);

        Assert.False(success);
        Assert.Null(content);
    }

    [Fact]
    public async Task ParseImageResponseAsync_WhenStatusIsNonSuccess_LogsError()
    {
        var loggerMock = new Mock<ILogger>();
        var response = MakeResponse(HttpStatusCode.InternalServerError, "{}");

        await AiServiceHelper.ParseImageResponseAsync(
            response, "OpenAI", loggerMock.Object, CancellationToken.None);

        loggerMock.Verify(
            l => l.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) =>
                    v.ToString()!.Contains("OpenAI") &&
                    v.ToString()!.Contains("InternalServerError")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task ParseImageResponseAsync_WhenResponseBodyIsMalformedJson_ReturnsFalseAndNull()
    {
        var response = MakeResponse(HttpStatusCode.OK, "NOT_JSON");

        var (success, content) = await AiServiceHelper.ParseImageResponseAsync(
            response, "TestProvider", _logger.Object, CancellationToken.None);

        Assert.False(success);
        Assert.Null(content);
    }

    [Fact]
    public async Task ParseImageResponseAsync_WhenResponseBodyIsMalformedJson_LogsError()
    {
        var loggerMock = new Mock<ILogger>();
        var response = MakeResponse(HttpStatusCode.OK, "NOT_JSON");

        await AiServiceHelper.ParseImageResponseAsync(
            response, "Azure Foundry", loggerMock.Object, CancellationToken.None);

        loggerMock.Verify(
            l => l.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("Azure Foundry")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task ParseImageResponseAsync_WhenResponseIs200WithValidJson_ReturnsTrueAndContent()
    {
        var response = MakeResponse(HttpStatusCode.OK, ImageJson("b64_json", "YWJj"));

        var (success, content) = await AiServiceHelper.ParseImageResponseAsync(
            response, "OpenAI", _logger.Object, CancellationToken.None);

        Assert.True(success);
        Assert.NotNull(content);
        Assert.True(content.Value.TryGetProperty("data", out var data));
        Assert.Equal(JsonValueKind.Array, data.ValueKind);
    }

    [Fact]
    public async Task ParseImageResponseAsync_WhenProviderNameAppearsInAllLogs()
    {
        var loggerMock = new Mock<ILogger>();

        await AiServiceHelper.ParseImageResponseAsync(
            MakeResponse(HttpStatusCode.TooManyRequests, "{}"), "fal.ai", loggerMock.Object, CancellationToken.None);
        await AiServiceHelper.ParseImageResponseAsync(
            MakeResponse(HttpStatusCode.InternalServerError, "{}"), "fal.ai", loggerMock.Object, CancellationToken.None);
        await AiServiceHelper.ParseImageResponseAsync(
            MakeResponse(HttpStatusCode.OK, "NOT_JSON"), "fal.ai", loggerMock.Object, CancellationToken.None);

        loggerMock.Verify(
            l => l.Log(
                It.IsAny<LogLevel>(),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("fal.ai")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Exactly(3));
    }
}
