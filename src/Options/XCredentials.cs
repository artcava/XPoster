namespace XPoster.Options;

/// <summary>
/// Typed credentials for the X (Twitter) sender.
/// Property names must match Azure Key Vault secret names exactly.
/// Bound via <c>AddAzureKeyVault</c> Configuration Provider and injected as <see cref="Microsoft.Extensions.Options.IOptions{XCredentials}"/>.
/// </summary>
public sealed class XCredentials
{
    /// <summary>Section name used to bind this class from configuration.</summary>
    public const string SectionName = "XCredentials";

    /// <summary>X (Twitter) API key.</summary>
    public string XApiKey { get; init; } = string.Empty;

    /// <summary>X (Twitter) API secret.</summary>
    public string XApiSecret { get; init; } = string.Empty;

    /// <summary>X (Twitter) access token.</summary>
    public string XAccessToken { get; init; } = string.Empty;

    /// <summary>X (Twitter) access token secret.</summary>
    public string XAccessTokenSecret { get; init; } = string.Empty;
}
