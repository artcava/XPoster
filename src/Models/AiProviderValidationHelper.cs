namespace XPoster.Models;

/// <summary>
/// Shared validation building blocks for AI provider options validators.
/// Centralises repeated connectivity checks so each validator only adds
/// its provider-specific rules on top.
/// </summary>
internal static class AiProviderValidationHelper
{
    /// <summary>
    /// Appends failure messages for missing <paramref name="apiKey"/> or
    /// <paramref name="endpoint"/> values. Property names appear in each message
    /// so failures remain identifiable across providers.
    /// </summary>
    internal static void ValidateConnectivity(
        string apiKey,
        string endpoint,
        List<string> failures,
        string apiKeyPropertyName,
        string endpointPropertyName)
    {
        if (string.IsNullOrWhiteSpace(apiKey))
            failures.Add($"{apiKeyPropertyName} is required.");

        if (string.IsNullOrWhiteSpace(endpoint))
            failures.Add($"{endpointPropertyName} must not be empty.");
    }
}
