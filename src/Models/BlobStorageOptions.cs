using Microsoft.Extensions.Configuration;

namespace XPoster.Models;

/// <summary>
/// Configuration model for Azure Blob Storage used by <see cref="XPoster.Services.BlobStorageService"/>.
/// Properties are bound flat from <see cref="IConfiguration"/> (no section prefix),
/// matching the Azure Functions app-settings convention for connection strings.
/// </summary>
public sealed class BlobStorageOptions
{
    /// <summary>
    /// App-settings key used to bind this class from configuration.
    /// Empty string means flat binding directly from the root configuration.
    /// </summary>
    public const string SectionName = "";

    /// <summary>
    /// Azure Storage connection string.
    /// Maps to the <c>AZURE_STORAGE_CONNECTION_STRING</c> app setting.
    /// </summary>
    public string AzureStorageConnectionString { get; init; } = string.Empty;

    /// <summary>
    /// Name of the blob container used to store images before Meta ingestion.
    /// Maps to the <c>AZURE_STORAGE_CONTAINER_NAME</c> app setting.
    /// Defaults to <c>xposter-images</c> when not set.
    /// </summary>
    public string AzureStorageContainerName { get; init; } = "xposter-images";
}
