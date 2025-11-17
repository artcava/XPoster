namespace XPoster.Models;

public record Post
{
    internal static string Firm => "\n\n#XPoster #AI";
    public required string Content { get; set; }
    public byte[]? Image { get; set; }
}
