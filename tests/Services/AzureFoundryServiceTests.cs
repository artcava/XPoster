using System.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using XPoster.Models;
using XPoster.Services;

namespace XPoster.Tests.Services;

public class AzureFoundryServiceTests
{
    private static AzureFoundryService BuildService(HttpMessageHandler handler, out Mock<ILogger<AzureFoundryService>> loggerMock, AzureFoundryOptions? opts = null)
    {
        loggerMock = new Mock<ILogger<AzureFoundryService>>();
        var factory = new Mock<IHttpClientFactory>();
        var client = new HttpClient(handler);
        factory.Setup(f => f.CreateClient(It.IsAny<string>())).Returns(client);

        var options = Options.Create(opts ?? new AzureFoundryOptions
        {
            Endpoint = "https://myfoundry.openai.azure.com",
            ApiKey = "fake-key",
            DeploymentName = "gpt-4.1-nano",
            ImageDeploymentName = "gpt-image-1"
        });

        return new AzureFoundryService(factory.Object, options, loggerMock.Object);
    }

    private static Mock<HttpMessageHandler> MakeHandlerMock(HttpStatusCode code, string json)
    {
        var mock = new Mock<HttpMessageHandler>();
        mock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(code)
            {
                Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json")
            });

        return mock;
    }

    private static string ChatCompletionJson(string content) =>
        "{\"choices\":[{\"message\":{\"content\":\"" + content + "\"}}]}";

    [Fact]
    public async Task GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsTrimmedContent()
    {
        var handler = MakeHandlerMock(HttpStatusCode.OK, ChatCompletionJson("summary result"));
        var svc = BuildService(handler.Object, out _);

        var result = await svc.GetSummaryAsync(new string('a', 300), 100);

        Assert.Equal("summary result", result);
        handler.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Post && r.RequestUri!.AbsolutePath.Contains("/chat/completions", StringComparison.Ordinal)),
            ItExpr.IsAny<CancellationToken>());
    }

    [Fact]
    public async Task GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.TooManyRequests, "{}").Object, out _);

        var result = await svc.GetSummaryAsync(new string('a', 300), 100);

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.BadGateway, "{}").Object, out _);

        var result = await svc.GetSummaryAsync(new string('a', 300), 100);

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{\"choices\":[]}").Object, out _);

        var result = await svc.GetSummaryAsync(new string('a', 300), 100);

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{\"choices\":null}").Object, out _);

        var result = await svc.GetSummaryAsync(new string('a', 300), 100);

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, ChatCompletionJson("prompt result")).Object, out _);

        var result = await svc.GetImagePromptAsync("summary");

        Assert.Equal("prompt result", result);
    }

    [Fact]
    public async Task GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{\"choices\":[]}").Object, out _);

        var result = await svc.GetImagePromptAsync("summary");

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, "{\"choices\":null}").Object, out _);

        var result = await svc.GetImagePromptAsync("summary");

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenApiReturnsValidResponse_ReturnsByteArray()
    {
        var imageBytes = new byte[] { 1, 2, 3, 4 };
        var base64 = Convert.ToBase64String(imageBytes);
        var json = "{\"data\":[{\"b64_json\":\"" + base64 + "\"}]}";
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.OK, json).Object, out _);

        var result = await svc.GenerateImageAsync("image prompt");

        Assert.Equal(imageBytes, result);
    }

    [Fact]
    public async Task GenerateImageAsync_WhenApiReturnsNonSuccess_ReturnsEmptyByteArray()
    {
        var svc = BuildService(MakeHandlerMock(HttpStatusCode.BadRequest, "{}").Object, out _);

        var result = await svc.GenerateImageAsync("image prompt");

        Assert.Empty(result);
    }
}
