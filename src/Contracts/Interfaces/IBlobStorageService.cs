using XPoster.Models;

namespace XPoster.Contracts;

/// <summary>
/// Defines a contract for a blob storage service that can upload and delete blobs.
/// </summary>
public interface IBlobStorageService
{
    /// <summary>
    /// Uploads raw bytes to blob storage and returns a <see cref="BlobUploadResult"/> containing
    /// the time-limited SAS URI and the blob name.
    /// The SAS URI is suitable for use as Meta media_url (direct GET, no auth headers, no redirects).
    /// </summary>
    /// <param name="data">The raw bytes to upload.</param>
    /// <param name="contentType">The MIME type of the data.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a <see cref="BlobUploadResult"/> with the SAS URI and blob name.
    /// </returns>
    Task<BlobUploadResult> UploadAsync(byte[] data, string contentType, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a blob from storage.
    /// </summary>
    /// <param name="blobName">The name of the blob to delete.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task DeleteAsync(string blobName, CancellationToken cancellationToken = default);
}
