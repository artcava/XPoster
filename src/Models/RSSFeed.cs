namespace XPoster.Models;

/// <summary>
/// Represents a single item retrieved from an RSS feed, capturing the essential fields
/// needed to compose a social-media post.
/// </summary>
public record RSSFeed
{
    /// <summary>Gets the headline title of the RSS item.</summary>
    public required string Title { get; init; }

    /// <summary>Gets the plain-text body or description of the RSS item, stripped of HTML markup.</summary>
    public required string Content { get; init; }

    /// <summary>Gets the canonical URL linking back to the original article.</summary>
    public required string Link { get; init; }

    /// <summary>Gets the date and time at which the item was published.</summary>
    public DateTimeOffset PublishDate { get; init; }
}
