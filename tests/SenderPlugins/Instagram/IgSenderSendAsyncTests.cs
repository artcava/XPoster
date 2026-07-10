using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using XPoster.Contracts;
using XPoster.Credentials;
using XPoster.Models;
using XPoster.SenderPlugins;
using XPoster.Tests.Helpers;

namespace XPoster.Tests.SenderPlugins;

public class IgSenderSendAsyncTests
{
    private static readonly InstagramCredentials DefaultCredentials = new()
    {
        InstagramAccessToken = "fake_token",
        InstagramAccountId = "fake_account_id"
    };

    private static IgSender BuildSender(
        HttpClient client,
        Mock<IBlobStorageService>? blob = null,
        Mock<IContainerStateStore>? store = null,
        Mock<ILogger<IgSender>>? log = null)
    {
        var factory = new Mock<IHttpClientFactory>();
        factory.Setup(f => f.CreateClient("Instagram")).Returns(client);
        return new IgSender(
            factory.Object,
            Options.Create(DefaultCredentials),
            (log ?? new Mock<ILogger<IgSender>>()).Object,
            (blob ?? new Mock<IBlobStorageService>()).Object,
            (store ?? new Mock<IContainerStateStore>()).Object);
    }

    [Fact]
    public async Task SendAsync_WithNullPost_ReturnsFalse()
    {
        var sut = BuildSender(new HttpClient(new Mock<HttpMessageHandler>().Object));
        Assert.False(await sut.SendAsync(null!));
    }

    [Fact]
    public async Task SendAsync_WithNoImage_ReturnsFalse()
    {
        var sut = BuildSender(new HttpClient(new Mock<HttpMessageHandler>().Object));
        Assert.False(await sut.SendAsync(new Post { Content = "Test caption", Image = null }));
    }

    [Fact]
    public async Task SendAsync_WithEmptyImageArray_ReturnsFalse()
    {
        var sut = BuildSender(new HttpClient(new Mock<HttpMessageHandler>().Object));
        Assert.False(await sut.SendAsync(new Post { Content = "test", Image = Array.Empty<byte>() }));
    }

    [Fact]
    public async Task SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption()
    {
        var blob = new Mock<IBlobStorageService>();
        var store = new Mock<IContainerStateStore>();
        blob.Setup(x => x.UploadAsync(It.IsAny<byte[]>(), "image/jpeg", It.IsAny<CancellationToken>()))
            .ReturnsAsync(new BlobUploadResult(new Uri("https://example.com/b.jpg"), "b"));
        store.Setup(x => x.SaveAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new System.Net.Http.StringContent("{\"id\":\"cont-1\"}", System.Text.Encoding.UTF8, "application/json")
            });

        var sut = BuildSender(new HttpClient(handler.Object), blob, store);
        Assert.True(await sut.SendAsync(new Post { Content = new string('X', 2500), Image = ImageTestData.CreateValidJpeg() }));
    }
}
