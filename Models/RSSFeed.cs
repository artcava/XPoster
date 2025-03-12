using System;

namespace XPoster.Models;

public record RSSFeed
{
    public string Title { get; init; }
    public string Content { get; init; }
    public string Link { get; init; }
    public DateTimeOffset PublishDate { get; init; }
}
