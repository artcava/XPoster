namespace XPoster.Models;

/// <summary>
/// Represents the result of a blob upload operation.
/// </summary>
/// <param name="SasUri">The time-limited SAS URI suitable for use as a public media URL.</param>
/// <param name="BlobName">The name of the uploaded blob, used for subsequent delete operations.</param>
public record BlobUploadResult(Uri SasUri, string BlobName);
