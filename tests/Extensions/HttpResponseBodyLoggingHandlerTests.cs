using System.Net;
using System.Net.Http.Headers;
using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Services;

namespace XPoster.Tests.Extensions;

public class HttpResponseBodyLoggingHandlerTests
{
    // ---------------------------------------------------------------
    // Fixtures
    // ---------------------------------------------------------------

    private sealed record StubResponse(int Status, string Body, string MediaType, string? RetryAfter = null);

    private sealed class FixedResponseHandler : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, StubResponse> _responder;

        public FixedResponseHandler(Func<HttpRequestMessage, StubResponse> responder) => _responder = responder;

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var stub = _responder(request);
            var content = new StringContent(stub.Body, System.Text.Encoding.UTF8, stub.MediaType);
            var response = new HttpResponseMessage((HttpStatusCode)stub.Status) { Content = content };
            if (stub.RetryAfter is not null)
            {
                response.Headers.RetryAfter = System.Net.Http.Headers.RetryConditionHeaderValue.Parse(stub.RetryAfter);
            }

            response.RequestMessage = request;
            return Task.FromResult(response);
        }
    }

    private static (HttpResponseBodyLoggingHandler Handler, Mock<ILogger<HttpResponseBodyLogger>> LoggerMock) BuildHandler(
        bool enabled = true)
    {
        var loggerMock = new Mock<ILogger<HttpResponseBodyLogger>>();
        loggerMock.Setup(l => l.IsEnabled(It.IsAny<LogLevel>())).Returns(enabled);
        var bodyLogger = new HttpResponseBodyLogger(loggerMock.Object, new HttpResponseBodySanitizer());
        return (new HttpResponseBodyLoggingHandler(bodyLogger), loggerMock);
    }

    private static HttpClient BuildClient(
        HttpResponseBodyLoggingHandler handler,
        Func<HttpRequestMessage, StubResponse> responder)
    {
        handler.InnerHandler = new FixedResponseHandler(responder);
        return new HttpClient(handler);
    }

    private static (LogLevel Level, string Message) GetLog(
        Mock<ILogger<HttpResponseBodyLogger>> loggerMock)
    {
        var invocation = loggerMock.Invocations.Last(i => i.Method.Name == "Log");
        var level = (LogLevel)invocation.Arguments[0];
        var state = invocation.Arguments[2];
        var exception = invocation.Arguments[3] as Exception;
        var formatter = (Delegate)invocation.Arguments[4];
        return (level, (string)formatter.DynamicInvoke(state, exception));
    }

    private static bool LogWasCalled(Mock<ILogger<HttpResponseBodyLogger>> loggerMock) =>
        loggerMock.Invocations.Any(i => i.Method.Name == "Log");

    // ---------------------------------------------------------------
    // Severity mapping
    // ---------------------------------------------------------------

    [Theory]
    [InlineData(200)]
    [InlineData(201)]
    [InlineData(204)]
    public async Task SendAsync_2xx_LogsAtDebugLevel(int status)
    {
        var (handler, loggerMock) = BuildHandler();
        var client = BuildClient(handler, _ => new StubResponse(status, "{\"ok\":true}", "application/json"));

        await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, "https://api.example.com/v1/things"));

        Assert.Equal(LogLevel.Debug, GetLog(loggerMock).Level);
    }

    [Theory]
    [InlineData(400)]
    [InlineData(402)]
    [InlineData(429)]
    [InlineData(500)]
    [InlineData(503)]
    public async Task SendAsync_4xx5xx_LogsAtErrorLevel(int status)
    {
        var (handler, loggerMock) = BuildHandler();
        var client = BuildClient(handler, _ => new StubResponse(status, "{}", "application/json"));

        await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, "https://api.example.com/v1/things"));

        Assert.Equal(LogLevel.Error, GetLog(loggerMock).Level);
    }

    // ---------------------------------------------------------------
    // Body / URL sanitization
    // ---------------------------------------------------------------

    [Fact]
    public async Task SendAsync_SanitizesSecretInBody()
    {
        var (handler, loggerMock) = BuildHandler();
        var client = BuildClient(
            handler,
            _ => new StubResponse(500, "{\"error\":{\"message\":\"Authorization: Bearer b1a2s3.h4t5\"}}", "application/json"));

        await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, "https://api.example.com/v1/things"));

        var log = GetLog(loggerMock);
        Assert.DoesNotContain("b1a2s3.h4t5", log.Message);
        Assert.Contains("Bearer ***", log.Message);
        Assert.Contains("500", log.Message);
    }

    [Fact]
    public async Task SendAsync_SanitizesAccessTokenInUrl()
    {
        var (handler, loggerMock) = BuildHandler();
        var client = BuildClient(handler, _ => new StubResponse(500, "{}", "application/json"));

        await client.SendAsync(new HttpRequestMessage(
            HttpMethod.Get,
            "https://graph.facebook.com/v23.0/me/photos?access_token=abcToken123"));

        var log = GetLog(loggerMock);
        Assert.DoesNotContain("abcToken123", log.Message);
        Assert.Contains("access_token=***", log.Message);
        Assert.Contains("500", log.Message);
    }

    [Fact]
    public async Task SendAsync_4xx_LogsResponseHeaders()
    {
        var (handler, loggerMock) = BuildHandler();
        var client = BuildClient(
            handler,
            _ => new StubResponse(429, "{}", "application/json", RetryAfter: "5"));

        await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, "https://api.example.com/v1/things"));

        var log = GetLog(loggerMock);
        Assert.Contains("Retry-After", log.Message);
        Assert.Contains("Content-Type", log.Message);
    }

    // ---------------------------------------------------------------
    // Truncation
    // ---------------------------------------------------------------

    [Fact]
    public async Task SendAsync_BodyLargerThanCap_LogsSummaryOnly()
    {
        var (handler, loggerMock) = BuildHandler();
        var hugeBody = new string('a', 10_000);
        var client = BuildClient(handler, _ => new StubResponse(500, hugeBody, "application/json"));

        await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, "https://api.example.com/v1/things"));

        var log = GetLog(loggerMock);
        Assert.Contains("(no body)", log.Message);
        Assert.DoesNotContain("aaaaaaaaaa", log.Message);
    }

    // ---------------------------------------------------------------
    // Binary / streamed payloads
    // ---------------------------------------------------------------

    [Fact]
    public async Task SendAsync_ImageResponse_LogsSummaryWithoutBody()
    {
        var (handler, loggerMock) = BuildHandler();
        handler.InnerHandler = new BinaryResponseHandler("image/png", [0x89, 0x50, 0x4E, 0x47]);
        var client = new HttpClient(handler);

        await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, "https://api.example.com/v1/image"));

        var log = GetLog(loggerMock);
        Assert.Contains("(no body)", log.Message);
        Assert.DoesNotContain("PNG", log.Message);
    }

    [Fact]
    public async Task SendAsync_OctetStreamResponse_LogsSummaryWithoutBody()
    {
        var (handler, loggerMock) = BuildHandler();
        handler.InnerHandler = new BinaryResponseHandler("application/octet-stream", [1, 2, 3, 4, 5]);
        var client = new HttpClient(handler);

        await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, "https://api.example.com/v1/blob"));

        var log = GetLog(loggerMock);
        Assert.Contains("(no body)", log.Message);
    }

    private sealed class BinaryResponseHandler : HttpMessageHandler
    {
        private readonly string _mediaType;
        private readonly byte[] _payload;

        public BinaryResponseHandler(string mediaType, byte[] payload)
        {
            _mediaType = mediaType;
            _payload = payload;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(_payload)
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(_mediaType);
            response.RequestMessage = request;
            return Task.FromResult(response);
        }
    }

    // ---------------------------------------------------------------
    // Opt-out header
    // ---------------------------------------------------------------

    [Fact]
    public async Task SendAsync_OptOutHeader_LogsNothing()
    {
        var (handler, loggerMock) = BuildHandler();
        var client = BuildClient(handler, _ => new StubResponse(500, "{\"error\":\"boom\"}", "application/json"));
        var request = new HttpRequestMessage(HttpMethod.Get, "https://api.example.com/v1/things");
        request.Headers.TryAddWithoutValidation(HttpResponseBodyLoggingHandler.LoggingOptOutHeader, "true");

        await client.SendAsync(request);

        Assert.False(LogWasCalled(loggerMock));
    }

    // ---------------------------------------------------------------
    // Caller still reads the body after logging
    // ---------------------------------------------------------------

    [Fact]
    public async Task SendAsync_CallerStillReadsBodyAfterLogging()
    {
        var (handler, _) = BuildHandler();
        var client = BuildClient(handler, _ => new StubResponse(200, "{\"ok\":true}", "application/json"));

        var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, "https://api.example.com/v1/things"));

        Assert.Equal("{\"ok\":true}", await response.Content.ReadAsStringAsync());
    }

    // ---------------------------------------------------------------
    // Not enabled → nothing read, nothing logged
    // ---------------------------------------------------------------

    [Fact]
    public async Task SendAsync_NotEnabled_SuccessNotLogged()
    {
        var (handler, loggerMock) = BuildHandler(enabled: false);
        var client = BuildClient(handler, _ => new StubResponse(200, "{\"ok\":true}", "application/json"));

        await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, "https://api.example.com/v1/things"));

        Assert.False(LogWasCalled(loggerMock));
    }
}