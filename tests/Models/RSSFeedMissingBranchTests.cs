using XPoster.Models;

namespace XPoster.Tests.Models;

/// <summary>
/// Covers missing branches of <see cref="RSSFeed"/> to reach 100% line coverage.
/// </summary>
public class RSSFeedMissingBranchTests
{
    [Fact]
    public void RSSFeed_DefaultItemsIsNull()
    {
        var feed = new RSSFeed();
        Assert.Null(feed.Items);
    }

    [Fact]
    public void RSSFeed_CanSetAndGetTitle()
    {
        var feed = new RSSFeed { Title = "My Feed" };
        Assert.Equal("My Feed", feed.Title);
    }

    [Fact]
    public void RSSFeed_CanSetItemsList()
    {
        var feed = new RSSFeed
        {
            Items = new List<RSSItem>
            {
                new RSSItem { Title = "Item 1", Link = "https://example.com" }
            }
        };
        Assert.Single(feed.Items);
        Assert.Equal("Item 1", feed.Items[0].Title);
    }

    [Fact]
    public void RSSItem_CanSetAndGetAllProperties()
    {
        var item = new RSSItem
        {
            Title = "Title",
            Link = "https://example.com",
            Description = "Desc",
            PubDate = "2026-01-01"
        };
        Assert.Equal("Title", item.Title);
        Assert.Equal("https://example.com", item.Link);
        Assert.Equal("Desc", item.Description);
        Assert.Equal("2026-01-01", item.PubDate);
    }
}
