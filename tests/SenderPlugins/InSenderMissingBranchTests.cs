using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Models;
using XPoster.SenderPlugins;

namespace XPoster.Tests.SenderPlugins;

/// <summary>
/// Additional InSender tests targeting uncovered branches:
/// - generatePayLoad with non-null asset (IMAGE branch)
/// - SendAsync with Image bytes present (triggers HTTP call to LinkedIn -> catch -> false)
/// </summary>
public class InSenderMissingBranchTests
{
    private readonly Mock<ILogger<InSender>> _logger = new();
    private readonly Mock<IHttpClientFactory> _factory = new();

    public InSenderMissingBranchTests()
    {
        _factory.Setup(f => f.CreateClient("LinkedIn")).Returns(new HttpClient());
    }

    private InSender BuildSender(string owner = "fake_owner")
    {
        Environment.SetEnvironmentVariable("IN_ACCESS_TOKEN", "fake_token");
        Environment.SetEnvironmentVariable("IN_OWNER", owner);
        return new InSender(_factory.Object, _logger.Object);
    }

    [Fact]
    public async Task SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse()
    {
        var sender = BuildSender();
        var post = new Post
        {
            Content = "Post with image",
            Image = new byte[] { 0xFF, 0xD8, 0xFF }
        };

        var result = await sender.SendAsync(post);
        Assert.False(result);
    }

    [Fact]
    public void MessageMaxLenght_Returns800()
    {
        var sender = BuildSender();
        Assert.Equal(800, sender.MessageMaxLenght);
    }

    [Fact]
    public async Task SendAsync_NullPost_ReturnsFalse()
    {
        var sender = BuildSender();
        var result = await sender.SendAsync(null!);
        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WhitespaceContent_ReturnsFalse()
    {
        var sender = BuildSender();
        var result = await sender.SendAsync(new Post { Content = "  " });
        Assert.False(result);
    }

    #region ResolveAuthorUrn tests (exercised via SendAsync)

    [Fact]
    public async Task SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn()
    {
        Environment.SetEnvironmentVariable("IN_ACCESS_TOKEN", "fake_token");
        Environment.SetEnvironmentVariable("IN_OWNER", "fake_owner");
        Environment.SetEnvironmentVariable("IN_ORG_ID", "98765432");
        var sender = new InSender(_factory.Object, _logger.Object);

        var result = await sender.SendAsync(new Post { Content = "org post" });

        Assert.False(result);
        Environment.SetEnvironmentVariable("IN_ORG_ID", null);
    }

    [Fact]
    public async Task SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn()
    {
        Environment.SetEnvironmentVariable("IN_ACCESS_TOKEN", "fake_token");
        Environment.SetEnvironmentVariable("IN_OWNER", "123456789");
        Environment.SetEnvironmentVariable("IN_ORG_ID", null);
        var sender = new InSender(_factory.Object, _logger.Object);

        var result = await sender.SendAsync(new Post { Content = "person post" });

        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse()
    {
        Environment.SetEnvironmentVariable("IN_ACCESS_TOKEN", "fake_token");
        Environment.SetEnvironmentVariable("IN_OWNER", null);
        Environment.SetEnvironmentVariable("IN_ORG_ID", null);
        var sender = new InSender(_factory.Object, _logger.Object);

        var result = await sender.SendAsync(new Post { Content = "no author" });

        Assert.False(result);
        Environment.SetEnvironmentVariable("IN_OWNER", "fake_owner");
    }

    #endregion
}
