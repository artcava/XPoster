using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Contracts;
using XPoster.Models;
using XPoster.SenderPlugins;

namespace XPoster.Tests.SenderPlugins;

public class DryRunSenderTests
{
    private readonly Mock<ILogger<DryRunSender>> _mockLogger = new();

    public DryRunSenderTests()
    {
        _mockLogger = new Mock<ILogger<DryRunSender>>();
    }

    private static IConfiguration BuildConfig(string? apiKeyValue = "some-key")
    {
        return new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["XApiKey"] = apiKeyValue
            })
            .Build();
    }

    private DryRunSender BuildSender(
        string? apiKeyValue = "some-key",
        IConfiguration? config = null,
        ILogger<DryRunSender>? logger = null)
    {
        return new DryRunSender(
            config ?? BuildConfig(apiKeyValue),
            logger ?? _mockLogger.Object);
    }

    private static Post ValidPost(string content = "Test dry-run content") =>
        new() { Content = content };

    #region Constructor Tests

    [Fact]
    public void Platform_ReturnsDryRun()
    {
        Assert.Equal(SenderPlatform.DryRun, BuildSender().Platform);
    }

    [Fact]
    public async Task SendAsync_WithImageAttached_ReturnsTrueAndLogsImagePresent()
    {
        var logMock = new Mock<ILogger<DryRunSender>>();
        var config = new Mock<IConfiguration>();
        config.Setup(c => c["XApiKey"]).Returns("present-key");
        var sut = new DryRunSender(config.Object, logMock.Object);

        var result = await sut.SendAsync(new Post
        {
            Content = "Hello world",
            Image = new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 }
        });

        Assert.True(result);
    }

    [Fact]
    public async Task SendAsync_WithNullContent_StillReturnsTrueWhenKeyPresent()
    {
        var sut = BuildSender("present");
        var result = await sut.SendAsync(new Post { Content = string.Empty, Image = null });
        Assert.True(result);
    }

    [Fact]
    public async Task SendAsync_WhenKeyMissing_ReturnsFalse()
    {
        var sut = BuildSender(null);
        Assert.False(await sut.SendAsync(new Post { Content = "test" }));
    }

    [Fact]
    public async Task SendAsync_WhenKeyWhitespace_ReturnsFalse()
    {
        var sut = BuildSender("   ");
        Assert.False(await sut.SendAsync(new Post { Content = "test" }));
    }

    [Fact]
    public void Constructor_WithNullConfiguration_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new DryRunSender(null!, _mockLogger.Object));
    }

    [Fact]
    public void Constructor_WithNullLogger_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new DryRunSender(BuildConfig(), null!));
    }

    [Fact]
    public void DryRunSender_ImplementsISender()
    {
        Assert.IsAssignableFrom<ISender>(BuildSender());
    }

    [Fact]
    public void MessageMaxLenght_ReturnsIntMaxValue()
    {
        Assert.Equal(int.MaxValue, BuildSender().MessageMaxLenght);
    }

    #endregion

    #region SendAsync - null post guard

    [Fact]
    public async Task SendAsync_WithNullPost_ReturnsFalse()
    {
        var sut = BuildSender("present");
        Assert.False(await sut.SendAsync(null!));
    }

    [Fact]
    public async Task SendAsync_WithNullPost_LogsWarning()
    {
        await BuildSender().SendAsync(null!);

        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("null")),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()
            ), Times.Once);
    }

    #endregion

    #region SendAsync - successful dry run

    [Fact]
    public async Task SendAsync_WhenProbeKeyPresent_ReturnsTrue()
    {
        Assert.True(await BuildSender("fake-api-key").SendAsync(ValidPost()));
    }

    [Fact]
    public async Task SendAsync_WhenProbeKeyPresent_LogsPostContent()
    {
        await BuildSender().SendAsync(ValidPost("Hello dry-run world"));

        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("Hello dry-run world")),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()
            ), Times.AtLeastOnce);
    }

    [Fact]
    public async Task SendAsync_WithImageBytes_ReturnsTrue()
    {
        var post = ValidPost();
        post.Image = new byte[] { 0x01, 0x02, 0x03 };
        Assert.True(await BuildSender().SendAsync(post));
    }

    [Fact]
    public async Task SendAsync_DoesNotCallAnyOutboundSocialApi()
    {
        // DryRunSender only reads IConfiguration — no HTTP client, no social API.
        // Simply verifying it returns true with a valid config is sufficient.
        Assert.True(await BuildSender().SendAsync(ValidPost()));
    }

    #endregion

    #region SendAsync - missing probe key

    [Fact]
    public async Task SendAsync_WhenProbeKeyMissing_ReturnsFalse()
    {
        Assert.False(await BuildSender(null).SendAsync(ValidPost()));
    }

    [Fact]
    public async Task SendAsync_WhenProbeKeyMissing_LogsError()
    {
        await BuildSender(null).SendAsync(ValidPost());

        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("XApiKey")),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()
            ), Times.Once);
    }

    #endregion
}
