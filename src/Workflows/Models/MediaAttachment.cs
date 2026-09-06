namespace XPoster.Workflows.Models;

/// <summary>
/// Represents a media attachment produced by a workflow node (image, video, or document).
/// Bridges the media-agnostic workflow layer to the legacy <c>Post.Media</c> byte array.
/// </summary>
/// <param name="Data">Raw binary content of the media file.</param>
/// <param name="Type">The type of media (image, video, document).</param>
/// <param name="MimeType">MIME type string (e.g., <c>image/png</c>).</param>
/// <param name="FileName">Suggested file name for the attachment.</param>
public record MediaAttachment(
    byte[] Data,
    MediaType Type,
    string MimeType,
    string FileName);
