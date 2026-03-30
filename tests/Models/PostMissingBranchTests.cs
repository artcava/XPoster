using XPoster.Models;

namespace XPoster.Tests.Models;

/// <summary>
/// Covers the missing branches of <see cref="Post"/> to reach 100% line coverage.
/// </summary>
public class PostMissingBranchTests
{
    [Fact]
    public void Firm_IsNotNullOrEmpty()
    {
        Assert.False(string.IsNullOrEmpty(Post.Firm));
    }

    [Fact]
    public void Post_DefaultImageIsNull()
    {
        var post = new Post { Content = "test" };
        Assert.Null(post.Image);
    }

    [Fact]
    public void Post_CanSetAndGetAllProperties()
    {
        var post = new Post
        {
            Content = "content",
            Image = new byte[] { 1, 2, 3 }
        };
        Assert.Equal("content", post.Content);
        Assert.Equal(3, post.Image.Length);
    }

    [Fact]
    public void Post_EmptyContent_IsAllowed()
    {
        var post = new Post { Content = string.Empty };
        Assert.Equal(string.Empty, post.Content);
    }
}
