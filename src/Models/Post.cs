namespace XPoster.Models;

/// <summary>
/// Represents a social-media post composed of textual content and an optional image attachment.
/// </summary>
public record Post
{
    /// <summary>Gets the standard hashtag footer appended to every published post.</summary>
    internal static string Firm => "\n\n#XPoster #AI";

    /// <summary>Gets or sets the main text body of the post.</summary>
    public required string Content { get; set; }

    /// <summary>Gets or sets the raw bytes of the image to attach, or <c>null</c> if no image is included.</summary>
    public byte[]? Image { get; set; }
}
