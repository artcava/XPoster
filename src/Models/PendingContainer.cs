namespace XPoster.Models;

/// <summary>
/// Represents a pending container with its creation ID and associated blob name.
/// </summary>
/// <param name="CreationId">The unique identifier for the container creation.</param>
/// <param name="BlobName">The name of the associated blob.</param>
public record PendingContainer(string CreationId, string BlobName);
