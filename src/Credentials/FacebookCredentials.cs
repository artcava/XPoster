namespace XPoster.Credentials;

/// <summary>
/// Typed credentials for the Facebook sender.
/// Property names must match Azure Key Vault secret names exactly.
/// Bound via <c>AddAzureKeyVault</c> Configuration Provider and injected as <see cref="Microsoft.Extensions.Options.IOptions{FacebookCredentials}"/>.
/// </summary>
public sealed class FacebookCredentials
{
    /// <summary>Section name used to bind this class from configuration.</summary>
    public const string SectionName = "FacebookCredentials";

    /// <summary>Facebook Graph API access token.</summary>
    public string FacebookAccessToken { get; init; } = string.Empty;

    /// <summary>Facebook page ID.</summary>
    public string FacebookPageId { get; init; } = string.Empty;
}
