using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Contracts;
using XPoster.Credentials;
using XPoster.SenderPlugins;
using XPoster.Tests.Helpers;

namespace XPoster.Tests.SenderPlugins;

public class IgSenderTests
{
    private readonly Mock<ILogger<IgSender>> _logger = new();
    private readonly Mock<IHttpClientFactory> _factory = new();
    private readonly Mock<IBlobStorageService> _blobStorage = new();
    private readonly Mock<IContainerStateStore> _containerState = new();

    private static readonly IOptions<InstagramCredentials> DefaultCreds = Options.Create(new InstagramCredentials
    {
        InstagramAccessToken = "fake_token",
        InstagramAccountId = "fake_account_id"
    });

    public IgSenderTests()
    {
        _factory.Setup(f => f.CreateClient("Instagram")).Returns(new HttpClient());
    }

    private IgSender BuildSender() =>
        new(_factory.Object, DefaultCreds, _logger.Object, _blobStorage.Object, _containerState.Object);

    private static IOptions<InstagramCredentials> BuildCreds() =>
        Options.Create(new InstagramCredentials
        {
            InstagramAccessToken = "test_token",
            InstagramAccountId = "123456789"
        });

    [Fact]
    public void Platform_ReturnsInstagram()
    {
        var sut = BuildSender();
        Assert.Equal(SenderPlatform.Instagram, sut.Platform);
    }

    [Fact]
    public void MessageMaxLength_Returns2200()
    {
        var sut = BuildSender();
        Assert.Equal(2200, sut.MessageMaxLength);
    }

    [Fact]
    public void Constructor_InitializesCorrectly()
    {
        var sender = new IgSender(_factory.Object, BuildCreds(), _logger.Object, _blobStorage.Object, _containerState.Object);

        Assert.NotNull(sender);
        Assert.Equal(SenderPlatform.Instagram, sender.Platform);
        Assert.Equal(2200, sender.MessageMaxLength);
    }

    [Fact]
    public void Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new IgSender(null!, BuildCreds(), _logger.Object, _blobStorage.Object, _containerState.Object));
    }

    [Fact]
    public void Constructor_WithNullCredentials_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new IgSender(_factory.Object, null!, _logger.Object, _blobStorage.Object, _containerState.Object));
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new IgSender(_factory.Object, BuildCreds(), null!, _blobStorage.Object, _containerState.Object));
    }

    [Fact]
    public void Constructor_WithNullBlobStorageService_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new IgSender(_factory.Object, BuildCreds(), _logger.Object, null!, _containerState.Object));
    }

    [Fact]
    public void Constructor_WithNullContainerStateStore_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new IgSender(_factory.Object, BuildCreds(), _logger.Object, _blobStorage.Object, null!));
    }

    [Fact]
    public void IgSender_ImplementsISender()
    {
        Assert.IsAssignableFrom<ISender>(
            new IgSender(_factory.Object, BuildCreds(), _logger.Object, _blobStorage.Object, _containerState.Object));
    }
}
