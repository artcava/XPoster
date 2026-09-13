using System.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Moq.Protected;
using XPoster.Credentials;
using XPoster.Models;
using XPoster.SenderPlugins;
using XPoster.Tests.Helpers;

namespace XPoster.Tests.SenderPlugins;

/// <summary>
/// Resilience tests for <see cref="XSender"/> failure handling.
/// These tests verify that the sender degrades gracefully when the X API rejects calls
/// (e.g. HTTP 402 credit exhaustion) or when the connection fails entirely.
/// </summary>
public class XSenderResilienceTests
{
    private readonly Mock<ILogger<XSender>> _loggerMock = new();

    private static readonly XCredentials TestCredentials = new()
    {
        XApiKey = "fake_key",
        XApiSecret = "fake_secret",
        XAccessToken = "fake_token",
        XAccessTokenSecret = "fake_token_secret"
    };

    private XSender BuildSender(IHttpClientFactory factory)
        => new(new XApiClient(factory, Options.Create(TestCredentials), NullLogger<XApiClient>.Instance), _loggerMock.Object);

    [Fact]
    public async Task SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning()
    {
        var sender = BuildSender(ResilienceTestHelpers.BuildFactory("X", HttpStatusCode.OK, "{}"));

        var result = await sender.SendAsync(null!);

        Assert.False(result);
        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("Post is null")),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("\t\n")]
    public async Task SendAsync_WhenContentIsBlank_ReturnsFalseAndLogsWarning(string content)
    {
        var sender = BuildSender(ResilienceTestHelpers.BuildFactory("X", HttpStatusCode.OK, "{}"));

        var result = await sender.SendAsync(new Post { Content = content });

        Assert.False(result);
        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("Post content cannot be empty")),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task SendAsync_WhenTextTweetReturns402_ReturnsFalseAndLogsError()
    {
        const string errorBody =
            "{\"title\":\"Usage Cap Exceeded\",\"detail\":\"The usage cap was exceeded.\"," +
            "\"type\":\"https://api.twitter.com/2/problems/usage-cap-exceeded\",\"label\":\"usage_cap_exceeded\"}";
        var sender = BuildSender(ResilienceTestHelpers.BuildFactory(
            "X",
            (HttpStatusCode.PaymentRequired, errorBody)));

        var result = await sender.SendAsync(new Post { Content = "Valid content" });

        Assert.False(result);
        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) =>
                    v.ToString()!.Contains("[XSender]") &&
                    v.ToString()!.Contains("usage_cap_exceeded")),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalseAndLogsError()
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new HttpRequestException("Connection refused"));
        var sender = BuildSender(ResilienceTestHelpers.BuildFactory("X", handlerMock.Object));

        var result = await sender.SendAsync(new Post { Content = "Valid content" });

        Assert.False(result);
        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("[XSender]")),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.AtLeastOnce);
    }
}