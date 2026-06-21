namespace XPoster.Options;

/// <summary>
/// Typed credentials for the LinkedIn sender.
/// Property names must match Azure Key Vault secret names exactly.
/// Bound via <c>AddAzureKeyVault</c> Configuration Provider and injected as <see cref="Microsoft.Extensions.Options.IOptions{LinkedInCredentials}"/>.
/// </summary>
public sealed class LinkedInCredentials
{
    /// <summary>Section name used to bind this class from configuration.</summary>
    public const string SectionName = "LinkedInCredentials";

    /// <summary>LinkedIn Bearer access token.</summary>
    public string LinkedInAccessToken { get; init; } = string.Empty;

    /// <summary>LinkedIn organization ID (optional; used for org posts).</summary>
    public string LinkedInOrgId { get; init; } = string.Empty;

    /// <summary>LinkedIn person/owner ID (used when <see cref="LinkedInOrgId"/> is not set).</summary>
    public string LinkedInOwnerCode { get; init; } = string.Empty;
}
