using XPoster.Contracts;

namespace XPoster.Models;

/// <summary>
/// Strongly-typed configuration for the Perplexity provider, bound from the <c>Perplexity</c> section.
/// </summary>
public sealed class PerplexityOptions : IAiProviderOptions
{
    /// <summary>Gets or sets the Perplexity endpoint base URL (for example, <c>https://api.perplexity.ai</c>).</summary>
    public string Endpoint { get; set; } = "https://api.perplexity.ai";

    /// <summary>Gets or sets the API key used for Perplexity authentication.</summary>
    public string ApiKey { get; set; } = string.Empty;

    /// <summary>Gets or sets the chat/completions model name (e.g. <c>sonar</c>).</summary>
    public string TextModelName { get; set; } = "sonar";

    /// <inheritdoc/>
    public AiModelCatalog ModelCatalog => new(new Dictionary<AiModelClass, string>
    {
        [AiModelClass.Text] = TextModelName
    });
}
