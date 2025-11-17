namespace XPoster.Models;

public record RSSFeed
{
    public required string Title { get; init; }
    public required string Content { get; init; }
    public required string Link { get; init; }
    public DateTimeOffset PublishDate { get; init; }
}
