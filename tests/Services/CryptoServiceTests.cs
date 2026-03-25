using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using System.Net;
using XPoster.Services;

namespace XPoster.Tests.Services;

public class CryptoServiceTests
{
    private static CryptoService MakeService(out Mock<HttpMessageHandler> handlerMock, out Mock<ILogger<CryptoService>> loggerMock)
    {
        handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        loggerMock = new Mock<ILogger<CryptoService>>();

        var client = new HttpClient(handlerMock.Object);
        var httpClientFactoryMock = new Mock<IHttpClientFactory>();
        httpClientFactoryMock.Setup(f => f.CreateClient(It.IsAny<string>())).Returns(client);

        return new CryptoService(httpClientFactoryMock.Object, loggerMock.Object);
    }

    [Fact]
    public async Task GetCryptoValue_ReturnsParsedValue_WhenNumericString()
    {
        var expectedValue = 39750.55m;
        var responseString = expectedValue.ToString();

        var service = MakeService(out var handlerMock, out _);

        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                // CS8602: RequestUri can be null; use null-forgiving only in test setup where URL is always set
                ItExpr.Is<HttpRequestMessage>(req => req.RequestUri!.ToString().Contains("BTC")),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(responseString),
            })
            .Verifiable();

        var value = await service.GetCryptoValue("BTC");
        Assert.Equal(expectedValue, value);
    }

    [Fact]
    public async Task GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric()
    {
        var service = MakeService(out var handlerMock, out _);

        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("N/A"),
            });

        var value = await service.GetCryptoValue("BTC");
        Assert.Equal(0m, value);
    }

    [Fact]
    public async Task GetCryptoValue_ReturnsZero_AndLogsError_OnException()
    {
        var service = MakeService(out var handlerMock, out var loggerMock);

        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ThrowsAsync(new HttpRequestException("Timeout"));

        var value = await service.GetCryptoValue("BTC");
        Assert.Equal(0m, value);

        loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("Failed to get crypto value")),
                It.IsAny<Exception?>(),
                // CS8620: formatter aligned to Func<..., Exception?, string>
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()
            ), Times.Once);
    }
}
