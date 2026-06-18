namespace XPoster.Contracts;

/// <summary>
/// Abstracts Azure Key Vault secret read/write operations.
/// Currently only <see cref="GetSecretAsync"/> has an active caller.
/// <see cref="SetSecretAsync"/> is defined for future automated token rotation scenarios (see #114).
/// </summary>
public interface IKeyVaultService
{
    /// <summary>
    /// Retrieves the value of the named secret from Azure Key Vault.
    /// </summary>
    /// <param name="secretName">The canonical Key Vault secret name (e.g. "LinkedInAccessToken").</param>
    /// <returns>The secret value as a plain string.</returns>
    /// <exception cref="Azure.RequestFailedException">
    /// Thrown when the secret does not exist or access is denied.
    /// </exception>
    Task<string> GetSecretAsync(string secretName);

    /// <summary>
    /// Stores or updates the named secret in Azure Key Vault.
    /// Not used in this release — defined as a contract for automated token rotation (#114).
    /// </summary>
    /// <param name="secretName">The canonical Key Vault secret name.</param>
    /// <param name="value">The new secret value.</param>
    Task SetSecretAsync(string secretName, string value);
}
