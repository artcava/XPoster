namespace XPoster.Models;

/// <summary>
/// Strongly-typed configuration for the Azure AI Foundry provider, bound from the <c>AzureFoundry</c> section.
/// </summary>
public sealed class AzureFoundryOptions
{
    /// <summary>Gets or sets the Foundry endpoint base URL (for example, <c>https://resource-name.services.ai.azure.com/openai/v1</c>).</summary>
    public string Endpoint { get; set; } = string.Empty;

    /// <summary>Gets or sets the API key used for Foundry authentication.</summary>
    public string ApiKey { get; set; } = string.Empty;

    /// <summary>Gets or sets the chat/completions deployment name.</summary>
    public string TextModelName { get; set; } = string.Empty;

    /// <summary>Gets or sets the image generation deployment name.</summary>
    public string ImageModelName { get; set; } = string.Empty;
}
