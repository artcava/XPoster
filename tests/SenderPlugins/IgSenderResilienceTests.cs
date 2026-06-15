using System.Net;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using XPoster.Abstraction;
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
        var kv = new Mock<IKeyVaultService>();
        kv.Setup(s => s.GetSecretAsync("IgAccessToken")).ReturnsAsync("fake_ig_token");
        kv.Setup(s => s.GetSecretAsync("IgAccountId")).ReturnsAsync("9876543210");
        return new IgSender(factory, kv.Object, _loggerMock.Object);
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

    [Fact]
    public async Task SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError()
    {
        var factory = ResilienceTestHelpers.BuildFactory(
            "Instagram",
            (HttpStatusCode.OK, "{}"));

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
