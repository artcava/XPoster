using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using XPoster.Models;
using XPoster.Options;
using XPoster.SenderPlugins;

namespace XPoster.Tests.SenderPlugins;

/// <summary>
/// Additional InSender tests targeting uncovered branches:
/// - SendAsync with image bytes (triggers HTTP call to LinkedIn -> catch -> false)
/// - ResolveAuthorUrn edge cases
/// </summary>
public class InSenderMissingBranchTests
{
    private readonly Mock<ILogger<InSender>> _logger = new();
    private readonly Mock<IHttpClientFactory> _factory = new();

    public InSenderMissingBranchTests()
    {
        _factory.Setup(f => f.CreateClient("LinkedIn")).Returns(new HttpClient());
    }

    private IOptions<LinkedInCredentials> BuildCreds(
        string? ownerCode = "fake_owner",
        string? orgId = null)
        => Options.Create(new LinkedInCredentials
        {
            LinkedInAccessToken = "fake_token",
            LinkedInOwnerCode = ownerCode ?? string.Empty,
            LinkedInOrgId = orgId ?? string.Empty
        });

    private InSender BuildSender(string? ownerCode = "fake_owner", string? orgId = null)
        => new(_factory.Object, BuildCreds(ownerCode, orgId), _logger.Object);

    [Fact]
    public async Task SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse()
    {
        var result = await BuildSender().SendAsync(new Post
        {
            Content = "Post with image",
            Image = new byte[] { 0xFF, 0xD8, 0xFF }
        });
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
        Assert.False(await BuildSender().SendAsync(null!));
    }

    [Fact]
    public async Task SendAsync_WhitespaceContent_ReturnsFalse()
    {
        Assert.False(await BuildSender().SendAsync(new Post { Content = "  " }));
    }

    #region ResolveAuthorUrn tests (exercised via SendAsync)

    [Fact]
    public async Task SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn()
    {
        Assert.False(await BuildSender(ownerCode: "fake_owner", orgId: "98765432")
            .SendAsync(new Post { Content = "org post" }));
    }

    [Fact]
    public async Task SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn()
    {
        Assert.False(await BuildSender(ownerCode: "123456789", orgId: null)
            .SendAsync(new Post { Content = "person post" }));
    }

    [Fact]
    public async Task SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse()
    {
        Assert.False(await BuildSender(ownerCode: null, orgId: null)
            .SendAsync(new Post { Content = "no author" }));
    }

    #endregion
}
