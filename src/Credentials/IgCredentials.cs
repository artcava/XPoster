namespace XPoster.Credentials;

/// <summary>
/// Typed credentials for the Instagram sender.
/// Property names must match Azure Key Vault secret names exactly.
/// Bound via <c>AddAzureKeyVault</c> Configuration Provider and injected as <see cref="Microsoft.Extensions.Options.IOptions{IgCredentials}"/>.
/// </summary>
public sealed class IgCredentials
{
    /// <summary>Section name used to bind this class from configuration.</summary>
    public const string SectionName = "IgCredentials";

    /// <summary>Instagram Graph API access token.</summary>
    public string IgAccessToken { get; init; } = string.Empty;

    /// <summary>Instagram account ID.</summary>
    public string IgAccountId { get; init; } = string.Empty;
}
