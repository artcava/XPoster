namespace XPoster.Models;

public record Post
{
    internal string Firm => "\n\n#XPoster #AI";
    public string Content { get; set; }
    public byte[] Image { get; set; }
}
