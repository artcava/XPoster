using System.Net;
using System.Text;
using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Services;

namespace XPoster.Tests.Services;

/// <summary>
/// Unit tests for <see cref="AiServiceHelper.ParseChatCompletionResponseAsync"/>.
/// Verifies the five-step guard pipeline in isolation.
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

    // --- 429 guard ---

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
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("MyProvider") && v.ToString()!.Contains("429")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    // --- non-2xx guard ---

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

    // --- null/empty choices guard ---

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

    // --- happy path ---

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

    // --- provider name appears in log messages ---

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
}
