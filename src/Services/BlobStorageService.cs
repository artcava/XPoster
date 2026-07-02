using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using Microsoft.Extensions.Options;
using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.Services;

/// <summary>
/// Uploads image bytes to Azure Blob Storage and returns a time-limited SAS URL
/// suitable for use as the <c>image_url</c> parameter of the Instagram Graph API
/// (direct GET, no auth headers, no redirects).
/// </summary>
/// <remarks>
/// The SAS URL is read-only, starts 5 minutes in the past to absorb clock skew between
/// Azure and Meta servers, and expires 30 minutes from the time of upload.
/// The blob container is created automatically on first use if it does not exist.
/// </remarks>
public class BlobStorageService : IBlobStorageService
{
    private readonly BlobServiceClient _blobServiceClient;
    private readonly string _containerName;
    private readonly ILogger<BlobStorageService> _logger;

    /// <summary>
    /// Initialises a new instance of <see cref="BlobStorageService"/>.
    /// </summary>
    /// <param name="blobServiceClient">The singleton <see cref="BlobServiceClient"/> registered in DI.</param>
    /// <param name="options">Blob storage configuration bound from app settings.</param>
    /// <param name="logger">The logger for diagnostic output.</param>
    public BlobStorageService(
        BlobServiceClient blobServiceClient,
        IOptions<BlobStorageOptions> options,
        ILogger<BlobStorageService> logger)
    {
        ArgumentNullException.ThrowIfNull(blobServiceClient);
        ArgumentNullException.ThrowIfNull(options);
        ArgumentNullException.ThrowIfNull(logger);

        _blobServiceClient = blobServiceClient;
        _containerName = string.IsNullOrWhiteSpace(options.Value.AzureStorageContainerName)
            ? "xposter-images"
            : options.Value.AzureStorageContainerName;
        _logger = logger;
    }

    /// <inheritdoc />
    /// <remarks>
    /// The blob name is a GUID-based unique identifier with a <c>.jpg</c> extension.
    /// The returned <see cref="Uri"/> is a SAS URL with <see cref="BlobSasPermissions.Read"/> permission
    /// valid for 30 minutes, with start time set 5 minutes in the past to absorb clock skew.
    /// </remarks>
    public async Task<Uri> UploadAsync(byte[] data, string contentType, CancellationToken cancellationToken = default)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
        await containerClient.CreateIfNotExistsAsync(PublicAccessType.None, cancellationToken: cancellationToken);

        var blobName = $"{Guid.NewGuid()}.jpg";
        var blobClient = containerClient.GetBlobClient(blobName);

        using var stream = new MemoryStream(data);
        await blobClient.UploadAsync(stream, new BlobHttpHeaders { ContentType = contentType }, cancellationToken: cancellationToken);

        _logger.LogInformation("Blob uploaded: {BlobName} ({Container})", blobName, _containerName);

        var sasBuilder = new BlobSasBuilder
        {
            BlobContainerName = _containerName,
            BlobName = blobName,
            Resource = "b",
            StartsOn = DateTimeOffset.UtcNow.AddMinutes(-5),
            ExpiresOn = DateTimeOffset.UtcNow.AddMinutes(30)
        };
        sasBuilder.SetPermissions(BlobSasPermissions.Read);

        var sasUri = blobClient.GenerateSasUri(sasBuilder);
        return sasUri;
    }

    /// <inheritdoc />
    /// <remarks>
    /// If the blob does not exist the operation completes silently without throwing.
    /// </remarks>
    public async Task DeleteAsync(string blobName, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(blobName);

        var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
        var blobClient = containerClient.GetBlobClient(blobName);

        var deleted = await blobClient.DeleteIfExistsAsync(cancellationToken: cancellationToken);

        if (deleted)
            _logger.LogInformation("Blob deleted: {BlobName} ({Container})", blobName, _containerName);
        else
            _logger.LogDebug("Blob not found during delete (already removed?): {BlobName} ({Container})", blobName, _containerName);
    }
}
