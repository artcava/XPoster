using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using XPoster.Abstraction;

namespace XPoster.Services;

/// <summary>
/// Reads and writes secrets from Azure Key Vault using <see cref="DefaultAzureCredential"/>.
/// Works transparently via <c>az login</c> in local development and via Managed Identity in Azure.
/// The Key Vault URI is read from the <c>KEYVAULT_URI</c> environment variable.
/// </summary>
public class KeyVaultService : IKeyVaultService
{
    private readonly SecretClient _client;
    private readonly ILogger<KeyVaultService> _logger;

    /// <summary>
    /// Initialises a new instance of <see cref="KeyVaultService"/>.
    /// </summary>
    /// <param name="logger">The logger for diagnostic output.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the <c>KEYVAULT_URI</c> environment variable is not set.
    /// </exception>
    public KeyVaultService(ILogger<KeyVaultService> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        var kvUri = Environment.GetEnvironmentVariable("KEYVAULT_URI")
            ?? throw new InvalidOperationException(
                "KEYVAULT_URI environment variable is not set. "
                + "Set it to the Key Vault URI (e.g. https://kv-xposter.vault.azure.net/) "
                + "and ensure Managed Identity (Azure) or az login (local) is configured.");
        _client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
    }

    /// <inheritdoc />
    public async Task<string> GetSecretAsync(string secretName)
    {
        _logger.LogDebug("Retrieving secret {SecretName} from Key Vault.", secretName);
        var response = await _client.GetSecretAsync(secretName);
        return response.Value.Value;
    }

    /// <inheritdoc />
    public async Task SetSecretAsync(string secretName, string value)
    {
        _logger.LogDebug("Setting secret {SecretName} in Key Vault.", secretName);
        await _client.SetSecretAsync(secretName, value);
    }
}
