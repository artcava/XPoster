using XPoster.Models;

namespace XPoster.Tests.Models;

/// <summary>
/// Instantiation and property tests for all model classes.
/// These cover lines that Cobertura reports at 0% (OpenAIResponse, Choice, Message,
/// OpenAIImageResponse, ImageData) and bump Post and RSSFeed to 100%.
/// </summary>
public class ModelsTests
{
    // ── Post ────────────────────────────────────────────────────────────────

    [Fact]
    public void Post_CanBeCreated_WithRequiredContent()
    {
        var post = new Post { Content = "Hello world" };
        Assert.Equal("Hello world", post.Content);
        Assert.Null(post.Image);
    }

    [Fact]
    public void Post_CanHold_ImageBytes()
    {
        var bytes = new byte[] { 1, 2, 3 };
        var post = new Post { Content = "With image", Image = bytes };
        Assert.Equal(bytes, post.Image);
    }

    [Fact]
    public void Post_Firm_ContainsExpectedHashtags()
    {
        // Firm is internal static — access via reflection to keep coverage on that getter
        var firm = typeof(Post)
            .GetProperty("Firm",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Static)!
            .GetValue(null) as string;

        Assert.NotNull(firm);
        Assert.Contains("#XPoster", firm);
        Assert.Contains("#AI", firm);
    }

    // ── RSSFeed ──────────────────────────────────────────────────────────────

    [Fact]
    public void RSSFeed_CanBeCreated_WithAllProperties()
    {
        var now = DateTimeOffset.UtcNow;
        var feed = new RSSFeed
        {
            Title = "Bitcoin rallies",
            Content = "BTC hit 100k",
            Link = "https://example.com/btc",
            PublishDate = now
        };

        Assert.Equal("Bitcoin rallies", feed.Title);
        Assert.Equal("BTC hit 100k", feed.Content);
        Assert.Equal("https://example.com/btc", feed.Link);
        Assert.Equal(now, feed.PublishDate);
    }

    [Fact]
    public void RSSFeed_DefaultValues_AreNull()
    {
        var feed = new RSSFeed();
        Assert.Null(feed.Title);
        Assert.Null(feed.Content);
        Assert.Null(feed.Link);
    }

    // ── OpenAIResponse / Choice / Message ────────────────────────────────────

    [Fact]
    public void OpenAIResponse_CanBeCreated_WithChoices()
    {
        var response = new OpenAIResponse
        {
            choices = new[]
            {
                new Choice { message = new Message { content = "Hello" } }
            }
        };

        Assert.Single(response.choices);
        Assert.Equal("Hello", response.choices[0].message.content);
    }

    [Fact]
    public void Choice_CanBeCreated_WithMessage()
    {
        var choice = new Choice { message = new Message { content = "Test" } };
        Assert.NotNull(choice.message);
        Assert.Equal("Test", choice.message.content);
    }

    [Fact]
    public void Message_CanBeCreated_WithContent()
    {
        var msg = new Message { content = "Some text" };
        Assert.Equal("Some text", msg.content);
    }

    // ── OpenAIImageResponse / ImageData ──────────────────────────────────────

    [Fact]
    public void OpenAIImageResponse_CanBeCreated_WithData()
    {
        var response = new OpenAIImageResponse
        {
            data = new List<ImageData>
            {
                new ImageData { url = "https://cdn.openai.com/image.png" }
            }
        };

        Assert.Single(response.data);
        Assert.Equal("https://cdn.openai.com/image.png", response.data[0].url);
    }

    [Fact]
    public void ImageData_CanBeCreated_WithUrl()
    {
        var img = new ImageData { url = "https://example.com/img.jpg" };
        Assert.Equal("https://example.com/img.jpg", img.url);
    }
}
