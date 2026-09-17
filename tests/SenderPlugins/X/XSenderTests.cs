using System.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Moq.Protected;
using XPoster.Contracts;
using XPoster.Credentials;
using XPoster.Models;
using XPoster.SenderPlugins;
using XPoster.Tests.Helpers;

namespace XPoster.Tests.SenderPlugins;

/// <summary>
/// Tests for <see cref="XSender"/> covering platform properties, constructor guards,
/// input-validation guards, success/failure paths through <see cref="XApiClient"/>,
/// and error-log capture.
/// </summary>
public class XSenderTests
{
    private static readonly XCredentials TestCredentials = new()
    {
        XApiKey = "fake_key",
        XApiSecret = "fake_secret",
        XAccessToken = "fake_token",
        XAccessTokenSecret = "fake_token_secret"
    };

    private readonly Mock<ILogger<XSender>> _mockLogger = new();

    private XSender BuildSender(StubHttpMessageHandler? handler = null)
    {
        handler ??= new StubHttpMessageHandler(_ => new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent("{\"data\":{\"id\":\"1234567890123456789\"}}", System.Text.Encoding.UTF8, "application/json")
        });
        var apiClient = new XApiClient(
            ResilienceTestHelpers.BuildFactory("X", handler),
            Options.Create(TestCredentials),
            NullLogger<XApiClient>.Instance);
        return new XSender(apiClient, _mockLogger.Object);
    }

    #region Constructor and Properties Tests

    [Fact]
    public void Platform_ReturnsX()
    {
        Assert.Equal(SenderPlatform.X, BuildSender().Platform);
    }

    [Fact]
    public void MessageMaxLength_Returns250()
    {
        Assert.Equal(250, BuildSender().MessageMaxLength);
    }

    [Fact]
    public void Constructor_InitializesSender_ImplementsISender()
    {
        var sender = BuildSender();
        Assert.NotNull(sender);
        Assert.IsAssignableFrom<ISender>(sender);
    }

    [Fact]
    public void Constructor_WithNullApiClient_ThrowsArgumentNullException()
    {
        var ex = Assert.Throws<ArgumentNullException>(() => new XSender(null!, _mockLogger.Object));
        Assert.Equal("apiClient", ex.ParamName);
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        var handler = new StubHttpMessageHandler(_ => new HttpResponseMessage(HttpStatusCode.OK));
        var apiClient = new XApiClient(
            ResilienceTestHelpers.BuildFactory("X", handler),
            Options.Create(TestCredentials),
            NullLogger<XApiClient>.Instance);

        var ex = Assert.Throws<ArgumentNullException>(() => new XSender(apiClient, null!));
        Assert.Equal("logger", ex.ParamName);
    }

    #endregion

    #region SendAsync Guard Tests

    [Fact]
    public async Task SendAsync_NullPost_ReturnsFalse()
    {
        Assert.False(await BuildSender().SendAsync(null!));
    }

    [Fact]
    public async Task SendAsync_WithNullPost_ReturnsFalseAndLogsWarning()
    {
        await BuildSender().SendAsync(null!);

        _mockLogger.Verify(
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
    public async Task SendAsync_WithBlankContent_ReturnsFalseAndLogsWarning(string content)
    {
        var result = await BuildSender().SendAsync(new Post { Content = content });

        Assert.False(result);
        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("Post content cannot be empty")),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    #endregion

    #region SendAsync Failure Paths

    [Fact]
    public async Task SendAsync_WhenApiReturns402_ReturnsFalseAndLogsError()
    {
        const string errorBody =
            "{\"title\":\"Usage Cap Exceeded\",\"detail\":\"The usage cap was exceeded.\"," +
            "\"type\":\"https://api.twitter.com/2/problems/usage-cap-exceeded\",\"label\":\"usage_cap_exceeded\"}";
        var handler = new StubHttpMessageHandler(_ => new HttpResponseMessage(HttpStatusCode.PaymentRequired)
        {
            Content = new StringContent(errorBody, System.Text.Encoding.UTF8, "application/json")
        });

        var result = await BuildSender(handler).SendAsync(new Post { Content = "Hello" });

        Assert.False(result);
        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) =>
                    v.ToString()!.Contains("[XSender]") &&
                    v.ToString()!.Contains("402")),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.AtLeastOnce);
    }

    [Fact]
    public async Task SendAsync_WhenConnectionFails_ReturnsFalseAndLogsError()
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new HttpRequestException("Connection refused"));

        var factory = ResilienceTestHelpers.BuildFactory("X", handlerMock.Object);
        var apiClient = new XApiClient(factory, Options.Create(TestCredentials), NullLogger<XApiClient>.Instance);
        var sender = new XSender(apiClient, _mockLogger.Object);

        var result = await sender.SendAsync(new Post { Content = "Hello" });

        Assert.False(result);
        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("[XSender]")),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.AtLeastOnce);
    }

    [Fact]
    public async Task SendAsync_WithImage_WhenUploadFails_ReturnsFalseAndLogsError()
    {
        var handler = new StubHttpMessageHandler(_ =>
            new HttpResponseMessage(HttpStatusCode.Forbidden)
            {
                Content = new StringContent("{}", System.Text.Encoding.UTF8, "application/json")
            });

        var result = await BuildSender(handler).SendAsync(new Post
        {
            Content = "Hello",
            Image = ImageTestData.CreateValidJpeg()
        });

        Assert.False(result);
        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.AtLeastOnce);
    }

    #endregion

    #region SendAsync Success Paths

    [Fact]
    public async Task SendAsync_TextPost_WhenApiSucceeds_ReturnsTrueAndLogsTweetId()
    {
        var result = await BuildSender().SendAsync(new Post { Content = "Hello" });

        Assert.True(result);
        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("Published tweet")),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task SendAsync_ImagePost_WhenUploadAndTweetSucceed_ReturnsTrue()
    {
        var handler = new StubHttpMessageHandler(request =>
        {
            var query = request.RequestUri!.Query;
            if (query.Contains("command=INIT"))
            {
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(
                        "{\"media_id\":123,\"media_id_string\":\"123\"}",
                        System.Text.Encoding.UTF8,
                        "application/json")
                };
            }

            if (query.Contains("command=APPEND"))
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }

            if (query.Contains("command=FINALIZE"))
            {
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(
                        "{\"media_id\":123,\"media_id_string\":\"123\"}",
                        System.Text.Encoding.UTF8,
                        "application/json")
                };
            }

            // Tweet endpoint
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(
                    "{\"data\":{\"id\":\"12345\"}}",
                    System.Text.Encoding.UTF8,
                    "application/json")
            };
        });

        var result = await BuildSender(handler).SendAsync(new Post
        {
            Content = "Hello",
            Image = ImageTestData.CreateValidJpeg()
        });

        Assert.True(result);
        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("Published tweet")),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task SendAsync_PngImagePost_PublishesTweetWithImagePngMediaType()
    {
        var handler = new StubHttpMessageHandler(request =>
        {
            var query = request.RequestUri!.Query;
            if (query.Contains("command=INIT"))
            {
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(
                        "{\"media_id\":123,\"media_id_string\":\"123\"}",
                        System.Text.Encoding.UTF8,
                        "application/json")
                };
            }

            if (query.Contains("command=APPEND"))
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }

            if (query.Contains("command=FINALIZE"))
            {
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(
                        "{\"media_id\":123,\"media_id_string\":\"123\"}",
                        System.Text.Encoding.UTF8,
                        "application/json")
                };
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(
                    "{\"data\":{\"id\":\"12345\"}}",
                    System.Text.Encoding.UTF8,
                    "application/json")
            };
        });

        var result = await BuildSender(handler).SendAsync(new Post
        {
            Content = "Hello",
            Image = ImageTestData.CreateValidPng()
        });

        Assert.True(result);
        var initQuery = handler.Requests[0].Message.RequestUri!.Query;
        Assert.Contains("command=INIT", initQuery);
        Assert.Contains("media_type=image%2Fpng", initQuery);
    }

    [Fact]
    public async Task SendAsync_WhenImageFormatCannotBeDetected_FallsBackToTextOnly()
    {
        var handler = new StubHttpMessageHandler(request =>
        {
            if (request.RequestUri!.Query.Contains("command=INIT"))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(
                    "{\"data\":{\"id\":\"12345\"}}",
                    System.Text.Encoding.UTF8,
                    "application/json")
            };
        });

        var result = await BuildSender(handler).SendAsync(new Post
        {
            Content = "Hello",
            Image = new byte[] { 1, 2, 3 }
        });

        Assert.True(result);
        var request = Assert.Single(handler.Requests);
        Assert.EndsWith("/2/tweets", request.Message.RequestUri!.AbsoluteUri);
        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("Unable to detect image format")),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    #endregion
}