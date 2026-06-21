using System.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using XPoster.Models;
using XPoster.Options;
using XPoster.SenderPlugins;
using XPoster.Tests.Helpers;

namespace XPoster.Tests.SenderPlugins;

/// <summary>
/// Resilience tests for <see cref="InSender"/> verifying behaviour when the LinkedIn API
/// returns transient errors (429, 503) or when the connection fails entirely.
/// </summary>
public class InSenderResilienceTests
{
    private readonly Mock<ILogger<InSender>> _loggerMock = new();

    private InSender BuildSender(IHttpClientFactory factory)
    {
        var creds = Options.Create(new LinkedInCredentials
        {
            LinkedInAccessToken = "fake_token",
            LinkedInOwnerCode = "12345",
            LinkedInOrgId = string.Empty
        });
        return new InSender(factory, creds, _loggerMock.Object);
    }

    private static Post ValidPost() => new() { Content = "A valid LinkedIn post" };

    [Fact]
    public async Task SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue()
    {
        var successBody = "{\"id\":\"urn:li:ugcPost:123\"}";
        var factory = ResilienceTestHelpers.BuildFactory(
            "LinkedIn",
            (HttpStatusCode.TooManyRequests, "{}"),
            (HttpStatusCode.TooManyRequests, "{}"),
            (HttpStatusCode.OK, successBody));

        Assert.False(await BuildSender(factory).SendAsync(ValidPost()));
    }

    [Fact]
    public async Task SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError()
    {
        var factory = ResilienceTestHelpers.BuildFactory(
            "LinkedIn",
            (HttpStatusCode.ServiceUnavailable, "{\"message\":\"Service Unavailable\"}"));

        var result = await BuildSender(factory).SendAsync(ValidPost());

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
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new HttpRequestException("Connection refused"));

        var factoryMock = new Mock<IHttpClientFactory>();
        factoryMock.Setup(f => f.CreateClient("LinkedIn")).Returns(new HttpClient(handlerMock.Object));

        Assert.False(await BuildSender(factoryMock.Object).SendAsync(ValidPost()));
    }

    [Fact]
    public async Task SendAsync_WhenLinkedInReturns200_ReturnsTrue()
    {
        var successBody = "{\"id\":\"urn:li:ugcPost:456\"}";
        var factory = ResilienceTestHelpers.BuildFactory(
            "LinkedIn",
            (HttpStatusCode.OK, successBody));

        Assert.True(await BuildSender(factory).SendAsync(ValidPost()));
    }
}
