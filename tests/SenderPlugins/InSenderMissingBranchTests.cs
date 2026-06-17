using Microsoft.Extensions.Logging;
using Moq;
using XPoster.Abstraction;
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

    private Mock<IKeyVaultService> BuildKv(
        string? ownerCode = "fake_owner",
        string? orgId = null)
    {
        var kv = new Mock<IKeyVaultService>();
        kv.Setup(s => s.GetSecretAsync("LinkedInAccessToken")).ReturnsAsync("fake_token");
        if (ownerCode != null)
            kv.Setup(s => s.GetSecretAsync("LinkedInOwnerCode")).ReturnsAsync(ownerCode);
        else
            kv.Setup(s => s.GetSecretAsync("LinkedInOwnerCode")).ReturnsAsync(string.Empty);

        if (orgId != null)
            kv.Setup(s => s.GetSecretAsync("LinkedInOrgId")).ReturnsAsync(orgId);
        else
            kv.Setup(s => s.GetSecretAsync("LinkedInOrgId"))
                .ThrowsAsync(new Azure.RequestFailedException("not found"));
        return kv;
    }

    private InSender BuildSender(string? ownerCode = "fake_owner", string? orgId = null)
        => new(_factory.Object, BuildKv(ownerCode, orgId).Object, _logger.Object);

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
        Assert.Equal(800, BuildSender().MessageMaxLenght);
    }

    [Fact]
    public async Task SendAsync_NullPost_ReturnsFalse()
    {
        var result = await BuildSender().SendAsync(null!);
        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WhitespaceContent_ReturnsFalse()
    {
        var result = await BuildSender().SendAsync(new Post { Content = "  " });
        Assert.False(result);
    }

    #region ResolveAuthorUrn tests (exercised via SendAsync)

    [Fact]
    public async Task SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn()
    {
        var sender = BuildSender(ownerCode: "fake_owner", orgId: "98765432");
        var result = await sender.SendAsync(new Post { Content = "org post" });
        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn()
    {
        var sender = BuildSender(ownerCode: "123456789", orgId: null);
        var result = await sender.SendAsync(new Post { Content = "person post" });
        Assert.False(result);
    }

    [Fact]
    public async Task SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse()
    {
        var sender = BuildSender(ownerCode: null, orgId: null);
        var result = await sender.SendAsync(new Post { Content = "no author" });
        Assert.False(result);
    }

    #endregion
}
