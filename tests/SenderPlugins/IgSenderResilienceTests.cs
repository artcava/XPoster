using System.Net;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using XPoster.Models;
using XPoster.SenderPlugins;
using XPoster.Tests.Helpers;

namespace XPoster.Tests.SenderPlugins;

/// <summary>
/// Resilience tests for <see cref="IgSender"/> verifying error handling when the Instagram
/// Graph API returns transient failures. Since <c>UploadImageToPublicUrl</c> is not yet
/// implemented (throws <see cref="NotImplementedException"/>), tests with images exercise
/// only the catch path. Tests without images cover the guard branch.
/// </summary>
public class IgSenderResilienceTests
{
    private readonly Mock<ILogger<IgSender>> _loggerMock = new();

    private IgSender BuildSender(IHttpClientFactory factory)
    {
        Environment.SetEnvironmentVariable("IG_ACCESS_TOKEN", "fake_ig_token");
        Environment.SetEnvironmentVariable("IG_ACCOUNT_ID", "9876543210");
        return new IgSender(factory, _loggerMock.Object);
    }

    private static Post PostWithImage() =>
        new() { Content = "Caption", Image = new byte[] { 0xFF, 0xD8, 0xFF } };

    private static Post PostWithoutImage() =>
        new() { Content = "Caption text only" };

    /// <summary>
    /// R1 — A post without image returns <c>false</c> immediately with a warning log,
    /// regardless of the HTTP client's behaviour (no HTTP call is made).
    /// </summary>
    [Fact]
    public async Task SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi()
    {
        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new Exception("Should not be called"));

        var client = new HttpClient(handler.Object);
        var factoryMock = new Mock<IHttpClientFactory>();
        factoryMock.Setup(f => f.CreateClient("Instagram")).Returns(client);

        var sender = BuildSender(factoryMock.Object);
        var result = await sender.SendAsync(PostWithoutImage());

        Assert.False(result);
        handler.Protected().Verify(
            "SendAsync",
            Times.Never(),
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>());
    }

    /// <summary>
    /// R2 — A post with an image hits <c>UploadImageToPublicUrl</c> which throws
    /// <see cref="NotImplementedException"/>; the outer catch should return <c>false</c>
    /// and log the error, not propagate the exception.
    /// </summary>
    [Fact]
    public async Task SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError()
    {
        var factory = ResilienceTestHelpers.BuildFactory(
            "Instagram",
            HttpStatusCode.OK, "{}");

        var sender = BuildSender(factory);
        var result = await sender.SendAsync(PostWithImage());

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
    /// R3 — When the factory's client raises <see cref="HttpRequestException"/>
    /// (simulating post-retry exhaustion), <see cref="IgSender.SendAsync"/> returns <c>false</c>.
    /// </summary>
    [Fact]
    public async Task SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse()
    {
        var mock = new Mock<HttpMessageHandler>();
        mock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new HttpRequestException("Network error"));

        var client = new HttpClient(mock.Object);
        var factoryMock = new Mock<IHttpClientFactory>();
        factoryMock.Setup(f => f.CreateClient("Instagram")).Returns(client);

        var sender = BuildSender(factoryMock.Object);
        var result = await sender.SendAsync(PostWithImage());

        Assert.False(result);
    }
}
