using XPoster.Models;

namespace XPoster.Tests.Models;

/// <summary>
/// Covers <see cref="RSSFeed"/> record properties to reach 100% line coverage.
/// RSSFeed is a record with required Title, Content, Link and optional PublishDate.
/// </summary>
public class RSSFeedMissingBranchTests
{
    [Fact]
    public void RSSFeed_CanCreateWithRequiredProperties()
    {
        var feed = new RSSFeed
        {
            Title = "Bitcoin hits new ATH",
            Content = "Bitcoin has reached a new all-time high today.",
            Link = "https://example.com/article"
        };

        Assert.Equal("Bitcoin hits new ATH", feed.Title);
        Assert.Equal("Bitcoin has reached a new all-time high today.", feed.Content);
        Assert.Equal("https://example.com/article", feed.Link);
    }

    [Fact]
    public void RSSFeed_DefaultPublishDateIsMinValue()
    {
        var feed = new RSSFeed
        {
            Title = "Title",
            Content = "Content",
            Link = "https://example.com"
        };

        Assert.Equal(default, feed.PublishDate);
    }

    [Fact]
    public void RSSFeed_CanSetPublishDate()
    {
        var date = new DateTimeOffset(2026, 1, 15, 9, 0, 0, TimeSpan.Zero);
        var feed = new RSSFeed
        {
            Title = "Title",
            Content = "Content",
            Link = "https://example.com",
            PublishDate = date
        };

        Assert.Equal(date, feed.PublishDate);
    }

    [Fact]
    public void RSSFeed_RecordEquality_SameValues_AreEqual()
    {
        var a = new RSSFeed { Title = "T", Content = "C", Link = "L" };
        var b = new RSSFeed { Title = "T", Content = "C", Link = "L" };
        Assert.Equal(a, b);
    }

    [Fact]
    public void RSSFeed_RecordEquality_DifferentValues_AreNotEqual()
    {
        var a = new RSSFeed { Title = "T1", Content = "C", Link = "L" };
        var b = new RSSFeed { Title = "T2", Content = "C", Link = "L" };
        Assert.NotEqual(a, b);
    }
}
