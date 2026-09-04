namespace XPoster.Workflows.Models;

/// <summary>
/// Identifies the type of media attached to a workflow-generated post.
/// </summary>
public enum MediaType
{
    /// <summary>Raster or vector image.</summary>
    Image,
    /// <summary>Video file.</summary>
    Video,
    /// <summary>Document (PDF, etc.).</summary>
    Document
}
