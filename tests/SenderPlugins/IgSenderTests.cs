using System.Net;
using System.Text;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using XPoster.Contracts;
using XPoster.Credentials;
using XPoster.Models;
using XPoster.SenderPlugins;
using XPoster.Tests.Helpers;

namespace XPoster.Tests.SenderPlugins;

/// <summary>
/// Tests for IgSender.
/// Only branches that execute before or without real HTTP calls are covered:
/// constructor guards, MessageMaxLength, null/empty content guards, no-image branch,
/// and the image path (which throws on the Instagram API — caught internally).
/// </summary>
public class IgSenderTests
{

    private static readonly InstagramCredentials DefaultCredentials = new()
    {
        InstagramAccessToken = "fake_token",
        InstagramAccountId = "fake_account_id"
    };

    private static IgSender BuildSender(
        HttpClient httpClient,
        Mock<IBlobStorageService> blobStorageServiceMock,
        Mock<IContainerStateStore> containerStateStoreMock,
        Mock<ILogger<IgSender>> loggerMock,
        InstagramCredentials? credentials = null)
    {
        var factoryMock = new Mock<IHttpClientFactory>();
        factoryMock.Setup(f => f.CreateClient("Instagram")).Returns(httpClient);

        return new IgSender(
            factoryMock.Object,
            Options.Create(credentials ?? DefaultCredentials),
            loggerMock.Object,
            blobStorageServiceMock.Object,
            containerStateStoreMock.Object
            );
    }

    #region Constructor Tests

    [Fact]
    public void Constructor_InitializesCorrectly()
    {
        var sut = BuildSender(
            new HttpClient(new Mock<HttpMessageHandler>().Object),
            new Mock<IBlobStorageService>(),
            new Mock<IContainerStateStore>(),
            new Mock<ILogger<IgSender>>());

        Assert.NotNull(sut);
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        var factoryMock = new Mock<IHttpClientFactory>();
        factoryMock.Setup(f => f.CreateClient("Instagram")).Returns(new HttpClient(new Mock<HttpMessageHandler>().Object));

        Assert.Throws<ArgumentNullException>(() =>
            new IgSender(
                factoryMock.Object,
                Options.Create(DefaultCredentials),
                null!,
                new Mock<IBlobStorageService>().Object,
                new Mock<IContainerStateStore>().Object
                ));
    }

    [Fact]
    public void Constructor_WithNullCredentials_ThrowsArgumentNullException()
    {
        var factoryMock = new Mock<IHttpClientFactory>();
        factoryMock.Setup(f => f.CreateClient("Instagram")).Returns(new HttpClient(new Mock<HttpMessageHandler>().Object));

        Assert.Throws<ArgumentNullException>(() =>
            new IgSender(
                factoryMock.Object,
                null!,
                new Mock<ILogger<IgSender>>().Object,
                new Mock<IBlobStorageService>().Object,
                new Mock<IContainerStateStore>().Object
                ));
    }

    [Fact]
    public void MessageMaxLenght_Returns2200()
    {
        var sut = BuildSender(
            new HttpClient(new Mock<HttpMessageHandler>().Object),
            new Mock<IBlobStorageService>(),
            new Mock<IContainerStateStore>(),
            new Mock<ILogger<IgSender>>()
            );

        Assert.Equal(2200, sut.MessageMaxLenght);
    }

    #endregion

    #region SendAsync Guard Tests

    [Fact]
    public async Task SendAsync_WithNullPost_ReturnsFalse()
    {
        var sut = BuildSender(
            new HttpClient(new Mock<HttpMessageHandler>().Object),
            new Mock<IBlobStorageService>(),
            new Mock<IContainerStateStore>(),
            new Mock<ILogger<IgSender>>());

        Assert.False(await sut.SendAsync(null!));
    }

    [Fact]
    public async Task SendAsync_WithNoImage_ReturnsFalse()
    {
        var sut = BuildSender(
            new HttpClient(new Mock<HttpMessageHandler>().Object),
            new Mock<IBlobStorageService>(),
            new Mock<IContainerStateStore>(),
            new Mock<ILogger<IgSender>>());

        Assert.False(await sut.SendAsync(new Post { Content = "Test caption", Image = null }));
    }

    [Fact]
    public async Task SendAsync_WithNonJpegImage_ReturnsFalse()
    {
        var sut = BuildSender(
            new HttpClient(new Mock<HttpMessageHandler>().Object),
            new Mock<IBlobStorageService>(),
            new Mock<IContainerStateStore>(),
            new Mock<ILogger<IgSender>>());

        Assert.False(await sut.SendAsync(new Post
        {
            Content = "Test caption",
            Image = Encoding.UTF8.GetBytes("not-jpeg")
        }));
    }

    [Fact]
    public async Task SendAsync_WhenBlobUploadSucceeds_CreatesMediaContainerWithCorrectSasUrl()
    {
        var blob = new Mock<IBlobStorageService>();
        var store = new Mock<IContainerStateStore>();
        var logger = new Mock<ILogger<IgSender>>();
        var captured = new List<HttpRequestMessage>();

        blob.Setup(x => x.UploadAsync(It.IsAny<byte[]>(), "image/jpeg", It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Uri("https://storage.example.com/xposter-images/blob1.jpg?sig=abc"));
        store.Setup(x => x.SaveAsync("creation-123", "blob1.jpg", It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .Callback<HttpRequestMessage, CancellationToken>((req, _) => captured.Add(req))
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"id\":\"creation-123\"}", Encoding.UTF8, "application/json")
            });

        var httpClient = new HttpClient(handler.Object);
        var sut = BuildSender(httpClient, blob, store, logger);

        var result = await sut.SendAsync(new Post
        {
            Content = "hello",
            Image = new byte[] { 0xFF, 0xD8, 0x00 }
        });

        Assert.True(result);
        Assert.Single(captured);
        Assert.Contains("access_token=fake_token", captured[0].RequestUri!.Query);
        Assert.Equal(HttpMethod.Post, captured[0].Method);
        blob.Verify(x => x.UploadAsync(It.IsAny<byte[]>(), "image/jpeg", It.IsAny<CancellationToken>()), Times.Once);
        store.Verify(x => x.SaveAsync("creation-123", "blob1.jpg", It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task SendAsync_WhenAccessTokenIsSet_RequestBodyDoesNotContainIt()
    {
        var blob = new Mock<IBlobStorageService>();
        var store = new Mock<IContainerStateStore>();
        var logger = new Mock<ILogger<IgSender>>();
        string? body = null;

        blob.Setup(x => x.UploadAsync(It.IsAny<byte[]>(), "image/jpeg", It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Uri("https://storage.example.com/xposter-images/blob1.jpg?sig=abc"));
        store.Setup(x => x.SaveAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .Returns(async (HttpRequestMessage req, CancellationToken _) =>
            {
                body = await req.Content!.ReadAsStringAsync();
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("{\"id\":\"creation-123\"}", Encoding.UTF8, "application/json")
                };
            });

        var sut = BuildSender(new HttpClient(handler.Object), blob, store, logger);

        var result = await sut.SendAsync(new Post
        {
            Content = "hello",
            Image = new byte[] { 0xFF, 0xD8, 0x00 }
        });

        Assert.True(result);
        Assert.NotNull(body);
        Assert.DoesNotContain("access_token", body, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task SendAsync_WhenBlobUploadSucceeds_SavesCreationIdToStateStore()
    {
        var blob = new Mock<IBlobStorageService>();
        var store = new Mock<IContainerStateStore>();
        var logger = new Mock<ILogger<IgSender>>();

        blob.Setup(x => x.UploadAsync(It.IsAny<byte[]>(), "image/jpeg", It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Uri("https://storage.example.com/xposter-images/blob1.jpg?sig=abc"));
        store.Setup(x => x.SaveAsync("creation-123", "blob1.jpg", It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask)
            .Verifiable();

        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"id\":\"creation-123\"}", Encoding.UTF8, "application/json")
            });

        var sut = BuildSender(new HttpClient(handler.Object), blob, store, logger);

        var result = await sut.SendAsync(new Post
        {
            Content = "hello",
            Image = new byte[] { 0xFF, 0xD8, 0x00 }
        });

        Assert.True(result);
        store.Verify();
    }

    [Fact]
    public async Task SendAsync_WhenMediaContainerFails_ReturnsFalse()
    {
        var blob = new Mock<IBlobStorageService>();
        var store = new Mock<IContainerStateStore>();
        var logger = new Mock<ILogger<IgSender>>();

        blob.Setup(x => x.UploadAsync(It.IsAny<byte[]>(), "image/jpeg", It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Uri("https://storage.example.com/xposter-images/blob1.jpg?sig=abc"));

        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.BadRequest));

        var sut = BuildSender(new HttpClient(handler.Object), blob, store, logger);

        var result = await sut.SendAsync(new Post
        {
            Content = "hello",
            Image = new byte[] { 0xFF, 0xD8, 0x00 }
        });

        Assert.False(result);
        store.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task SendAsync_WhenCaptionExceedsLimit_TruncatesCaption()
    {
        var blob = new Mock<IBlobStorageService>();
        var store = new Mock<IContainerStateStore>();
        var logger = new Mock<ILogger<IgSender>>();
        string? body = null;

        blob.Setup(x => x.UploadAsync(It.IsAny<byte[]>(), "image/jpeg", It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Uri("https://storage.example.com/xposter-images/blob1.jpg?sig=abc"));
        store.Setup(x => x.SaveAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .Returns(async (HttpRequestMessage req, CancellationToken _) =>
            {
                body = await req.Content!.ReadAsStringAsync();
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("{\"id\":\"creation-123\"}", Encoding.UTF8, "application/json")
                };
            });

        var sut = BuildSender(new HttpClient(handler.Object), blob, store, logger);

        var result = await sut.SendAsync(new Post
        {
            Content = new string('a', 5000),
            Image = new byte[] { 0xFF, 0xD8, 0x00 }
        });

        Assert.True(result);
        Assert.NotNull(body);
        Assert.Contains("caption", body!);
    }

    [Fact]
    public async Task SendAsync_WhenApiReturns429_ReturnsFalse()
    {
        var blob = new Mock<IBlobStorageService>();
        var store = new Mock<IContainerStateStore>();
        var logger = new Mock<ILogger<IgSender>>();

        blob.Setup(x => x.UploadAsync(It.IsAny<byte[]>(), "image/jpeg", It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Uri("https://storage.example.com/xposter-images/blob1.jpg?sig=abc"));

        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage((HttpStatusCode)429));

        var sut = BuildSender(new HttpClient(handler.Object), blob, store, logger);

        var result = await sut.SendAsync(new Post
        {
            Content = "hello",
            Image = new byte[] { 0xFF, 0xD8, 0x00 }
        });

        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_DoesNotPollContainerStatus_DelegatesStateToStore()
    {
        var blob = new Mock<IBlobStorageService>();
        var store = new Mock<IContainerStateStore>();
        var logger = new Mock<ILogger<IgSender>>();

        blob.Setup(x => x.UploadAsync(It.IsAny<byte[]>(), "image/jpeg", It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Uri("https://storage.example.com/xposter-images/blob1.jpg?sig=abc"));
        store.Setup(x => x.SaveAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"id\":\"creation-123\"}", Encoding.UTF8, "application/json")
            });

        var sut = BuildSender(new HttpClient(handler.Object), blob, store, logger);

        var result = await sut.SendAsync(new Post
        {
            Content = "hello",
            Image = new byte[] { 0xFF, 0xD8, 0x00 }
        });

        Assert.True(result);
        store.Verify(x => x.SaveAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);
        store.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task SendAsync_WithEmptyContent_ReturnsFalse()
    {
        var sut = BuildSender(
            new HttpClient(new Mock<HttpMessageHandler>().Object),
            new Mock<IBlobStorageService>(),
            new Mock<IContainerStateStore>(),
            new Mock<ILogger<IgSender>>());

        Assert.False(await sut.SendAsync(new Post { Content = string.Empty }));
    }

    [Fact]
    public async Task SendAsync_WithWhitespaceContent_ReturnsFalse()
    {
        var sut = BuildSender(
            new HttpClient(new Mock<HttpMessageHandler>().Object),
            new Mock<IBlobStorageService>(),
            new Mock<IContainerStateStore>(),
            new Mock<ILogger<IgSender>>());

        Assert.False(await sut.SendAsync(new Post { Content = "   " }));
    }

    [Fact]
    public async Task SendAsync_WithImage_TriesUploadAndReturnsFalse()
    {
        var blob = new Mock<IBlobStorageService>();
        var store = new Mock<IContainerStateStore>();
        var logger = new Mock<ILogger<IgSender>>();
        var sut = BuildSender(
            new HttpClient(new Mock<HttpMessageHandler>().Object),
            blob,
            store,
            logger);

        Assert.False(await sut.SendAsync(new Post
        {
            Content = "Test caption",
            Image = new byte[] { 0x89, 0x50, 0x4E, 0x47 }
        }));
    }

    #endregion

    #region Image upload and API response Tests

    [Fact]
    public async Task SendAsync_WhenImageUploadThrowsNotImplemented_ReturnsFalseAndLogsError()
    {
        var blob = new Mock<IBlobStorageService>();
        var store = new Mock<IContainerStateStore>();
        var logger = new Mock<ILogger<IgSender>>();
        var httpClient = new HttpClient(new Mock<HttpMessageHandler>().Object);

        blob.Setup(x => x.UploadAsync(It.IsAny<byte[]>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new NotImplementedException());

        var sut = BuildSender(httpClient, blob, store, logger);

        var result = await sut.SendAsync(new Post
        {
            Content = "caption",
            Image = new byte[] { 0xFF, 0xD8, 0xFF }
        });

        Assert.False(result);
        logger.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("Errore durante il caricamento dell'immagine su Blob Storage")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task SendAsync_WhenInstagramApiReturnsNonSuccess_ReturnsFalse()
    {
        var blob = new Mock<IBlobStorageService>();
        var store = new Mock<IContainerStateStore>();
        var logger = new Mock<ILogger<IgSender>>();
        blob.Setup(x => x.UploadAsync(It.IsAny<byte[]>(), "image/jpeg", It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Uri("https://storage.example.com/xposter-images/blob1.jpg?sig=abc"));

        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent("{\"error\":\"bad_request\"}")
            });

        var factoryMock = new Mock<IHttpClientFactory>();
        factoryMock.Setup(f => f.CreateClient("Instagram"))
            .Returns(new HttpClient(handlerMock.Object));

        var sender = new IgSender(
            factoryMock.Object,
            Options.Create(DefaultCredentials),
            logger.Object,
            blob.Object,
            store.Object);

        Assert.False(await sender.SendAsync(
            new Post { Content = "caption", Image = new byte[] { 0xFF, 0xD8, 0x00 } }));
    }

    [Fact]
    public async Task SendAsync_WhenInstagramApiReturns429_ReturnsFalse()
    {
        var blob = new Mock<IBlobStorageService>();
        var store = new Mock<IContainerStateStore>();
        var logger = new Mock<ILogger<IgSender>>();
        blob.Setup(x => x.UploadAsync(It.IsAny<byte[]>(), "image/jpeg", It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Uri("https://storage.example.com/xposter-images/blob1.jpg?sig=abc"));

        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.TooManyRequests)
            {
                Content = new StringContent("{\"error\":\"rate_limited\"}")
            });

        var factoryMock = new Mock<IHttpClientFactory>();
        factoryMock.Setup(f => f.CreateClient("Instagram"))
            .Returns(new HttpClient(handlerMock.Object));

        var sender = new IgSender(
            factoryMock.Object,
            Options.Create(DefaultCredentials),
            logger.Object,
            blob.Object,
            store.Object);

        Assert.False(await sender.SendAsync(
            new Post { Content = "caption", Image = new byte[] { 0xFF, 0xD8, 0x00 } }));
    }

    [Fact]
    public async Task SendAsync_WhenImageUploadThrowsHttpRequestException_ReturnsFalseAndLogsError()
    {
        var blob = new Mock<IBlobStorageService>();
        var store = new Mock<IContainerStateStore>();
        var loggerMock = new Mock<ILogger<IgSender>>();
        var factoryMock = new Mock<IHttpClientFactory>();
        factoryMock.Setup(f => f.CreateClient("Instagram"))
            .Returns(new HttpClient(new Mock<HttpMessageHandler>().Object));

        blob.Setup(x => x.UploadAsync(It.IsAny<byte[]>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new HttpRequestException("Connection refused"));

        var sender = new IgSender(
            factoryMock.Object,
            Options.Create(DefaultCredentials),
            loggerMock.Object,
            blob.Object,
            store.Object);

        Assert.False(await sender.SendAsync(
            new Post { Content = "caption", Image = new byte[] { 0xFF, 0xD8, 0x00 } }));

        loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains("Errore durante il caricamento dell'immagine su Blob Storage")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    #endregion
}
