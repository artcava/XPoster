using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Contracts;
using XPoster.Credentials;
using XPoster.SenderPlugins;

namespace XPoster.Tests.SenderPlugins;

public class FbSenderTests
{
    private readonly Mock<ILogger<FbSender>> _logger = new();
    private readonly Mock<IHttpClientFactory> _factory = new();
    private readonly Mock<IBlobStorageService> _blobStorage = new();

    public FbSenderTests()
    {
        _factory.Setup(f => f.CreateClient("Facebook")).Returns(new HttpClient());
    }

    private static IOptions<FacebookCredentials> BuildCreds() =>
        Options.Create(new FacebookCredentials
        {
            FacebookAccessToken = "test_token",
            FacebookPageId = "123456789"
        });

    [Fact]
    public void Constructor_InitializesCorrectly()
    {
        var sender = new FbSender(_factory.Object, BuildCreds(), _logger.Object, _blobStorage.Object);

        Assert.NotNull(sender);
        Assert.Equal(SenderPlatform.Facebook, sender.Platform);
        Assert.Equal(6000, sender.MessageMaxLenght);
    }

    [Fact]
    public void Constructor_WithNullFactory_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new FbSender(null!, BuildCreds(), _logger.Object, _blobStorage.Object));
    }

    [Fact]
    public void Constructor_WithNullCredentials_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new FbSender(_factory.Object, null!, _logger.Object, _blobStorage.Object));
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new FbSender(_factory.Object, BuildCreds(), null!, _blobStorage.Object));
    }

    [Fact]
    public void Constructor_WithNullBlobStorage_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new FbSender(_factory.Object, BuildCreds(), _logger.Object, null!));
    }

    [Fact]
    public void FbSender_ImplementsISender()
    {
        Assert.IsAssignableFrom<ISender>(
            new FbSender(_factory.Object, BuildCreds(), _logger.Object, _blobStorage.Object));
    }
}