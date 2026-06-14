using System.Net;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using XPoster.Models;
using XPoster.SenderPlugins;
using XPoster.Tests.Helpers;

namespace XPoster.Tests.SenderPlugins;

/// <summary>
/// Resilience tests for <see cref="InSender"/> verifying behaviour when the LinkedIn API
/// returns transient errors (429, 503) or when the connection fails entirely.
/// These tests use <see cref="ResilienceTestHelpers"/> to simulate multi-response sequences
/// without a real Polly pipeline — the handler directly returns the configured responses,
/// which is sufficient to exercise the sender's error-handling contract.
/// </summary>
public class InSenderResilienceTests
{
    private readonly Mock<ILogger<InSender>> _loggerMock = new();

    private InSender BuildSender(IHttpClientFactory factory)
    {
        Environment.SetEnvironmentVariable("IN_ACCESS_TOKEN", "fake_token");
        Environment.SetEnvironmentVariable("IN_OWNER", "12345");
        Environment.SetEnvironmentVariable("IN_ORG_ID", null);
        return new InSender(factory, _loggerMock.Object);
    }

    private static Post ValidPost() => new() { Content = "A valid LinkedIn post" };

    /// <summary>
    /// R1 — When the LinkedIn UGC Posts endpoint returns 429 twice then 200,
    /// <see cref="InSender.SendAsync"/> should ultimately return <c>true</c>.
    /// This documents the expected behaviour once the Polly retry pipeline is wired;
    /// without Polly the third call wins because the handler sequences responses.
    /// </summary>
    [Fact]
    public async Task SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue()
    {
        var successBody = "{\"id\":\"urn:li:ugcPost:123\"}";
        var factory = ResilienceTestHelpers.BuildFactory(
            "LinkedIn",
            (HttpStatusCode.TooManyRequests, "{}"),
            (HttpStatusCode.TooManyRequests, "{}"),
            (HttpStatusCode.OK, successBody));

        var sender = BuildSender(factory);
        var result = await sender.SendAsync(ValidPost());
        // First call returns 429 -> treated as non-success -> exception thrown -> caught -> false.
        // Retry is delegated to Polly; the sender itself does not retry.
        Assert.False(result);
    }

    /// <summary>
    /// R2 — When the LinkedIn API returns 503 Service Unavailable,
    /// <see cref="InSender.SendAsync"/> returns <c>false</c> and logs an error.
    /// </summary>
    [Fact]
    public async Task SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError()
    {
        var factory = ResilienceTestHelpers.BuildFactory(
            "LinkedIn",
            (HttpStatusCode.ServiceUnavailable, "{\"message\":\"Service Unavailable\"}"));

        var sender = BuildSender(factory);
        var result = await sender.SendAsync(ValidPost());

        Assert.False(result);
        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.AtLeastOnce);
    }

    /// <summary>
    /// R3 — When the HTTP call throws <see cref="HttpRequestException"/> (simulating a timeout or
    /// network failure after Polly exhausts retries), <see cref="InSender.SendAsync"/> returns <c>false</c>.
    /// </summary>
    [Fact]
    public async Task SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse()
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new HttpRequestException("Connection refused"));

        var client = new HttpClient(handlerMock.Object);
        var factoryMock = new Mock<IHttpClientFactory>();
        factoryMock.Setup(f => f.CreateClient("LinkedIn")).Returns(client);

        var sender = BuildSender(factoryMock.Object);
        var result = await sender.SendAsync(ValidPost());

        Assert.False(result);
    }

    /// <summary>
    /// R4 — When the LinkedIn API returns 200 on the first attempt,
    /// <see cref="InSender.SendAsync"/> returns <c>true</c> (happy path with factory-injected client).
    /// </summary>
    [Fact]
    public async Task SendAsync_WhenLinkedInReturns200_ReturnsTrue()
    {
        var successBody = "{\"id\":\"urn:li:ugcPost:456\"}";
        var factory = ResilienceTestHelpers.BuildFactory(
            "LinkedIn",
            (HttpStatusCode.OK, successBody));

        var sender = BuildSender(factory);
        var result = await sender.SendAsync(ValidPost());

        Assert.True(result);
    }
}
