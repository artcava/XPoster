using System.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using XPoster.Credentials;
using XPoster.Models;
using XPoster.SenderPlugins;
using XPoster.Tests.Helpers;

namespace XPoster.Tests.SenderPlugins;

/// <summary>
/// Resilience tests for <see cref="IgSender"/> verifying error handling when the Instagram
/// Graph API returns transient failures.
/// </summary>
public class IgSenderResilienceTests
{
    private readonly Mock<ILogger<IgSender>> _loggerMock = new();

    private IgSender BuildSender(IHttpClientFactory factory)
    {
        var creds = Options.Create(new InstagramCredentials
        {
            InstagramAccessToken = "fake_ig_token",
            InstagramAccountId = "9876543210"
        });
        return new IgSender(factory, creds, _loggerMock.Object);
    }

    private static Post PostWithImage() =>
        new() { Content = "Caption", Image = new byte[] { 0xFF, 0xD8, 0xFF } };

    private static Post PostWithoutImage() =>
        new() { Content = "Caption text only" };

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

        var factoryMock = new Mock<IHttpClientFactory>();
        factoryMock.Setup(f => f.CreateClient("Instagram")).Returns(new HttpClient(handler.Object));

        Assert.False(await BuildSender(factoryMock.Object).SendAsync(PostWithoutImage()));
        handler.Protected().Verify(
            "SendAsync",
            Times.Never(),
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>());
    }

    [Fact]
    public async Task SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError()
    {
        var factory = ResilienceTestHelpers.BuildFactory(
            "Instagram",
            (HttpStatusCode.OK, "{}"));

        Assert.False(await BuildSender(factory).SendAsync(PostWithImage()));
        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.AtLeastOnce);
    }

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

        var factoryMock = new Mock<IHttpClientFactory>();
        factoryMock.Setup(f => f.CreateClient("Instagram")).Returns(new HttpClient(mock.Object));

        Assert.False(await BuildSender(factoryMock.Object).SendAsync(PostWithImage()));
    }
}
