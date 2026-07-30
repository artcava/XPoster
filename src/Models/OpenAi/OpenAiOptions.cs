using XPoster.Contracts;

namespace XPoster.Models;

/// <summary>
/// Strongly-typed configuration for the OpenAI provider, bound from the <c>OpenAI</c> configuration section.
/// Contains only connectivity and model-capability settings.
/// Prompt data is supplied at runtime via <see cref="PromptRequest"/> / <see cref="ImagePromptRequest"/>.
/// </summary>
public sealed class OpenAiOptions : IAiProviderOptions, IAiProviderSection
{
    /// <summary>App-settings section name: <c>OpenAI</c>.</summary>
    public static string SectionName => "OpenAI";

    /// <summary>Gets or sets the OpenAI API key used for authentication.</summary>
    public string ApiKey { get; set; } = string.Empty;

    /// <summary>Gets or sets the Chat Completions API endpoint.</summary>
    public string Endpoint { get; set; } = "https://api.openai.com/v1/";

    /// <summary>Gets or sets the model used for chat/completion requests.</summary>
    public string TextModelName { get; set; } = "gpt-4.1-nano";

    /// <summary>Gets or sets the model used for image generation requests.</summary>
    public string ImageModelName { get; set; } = "gpt-image-1.5";

    /// <inheritdoc/>
    public AiModelCatalog ModelCatalog => new(new Dictionary<AiModelClass, string>
    {
        [AiModelClass.Text] = TextModelName,
        [AiModelClass.Image] = ImageModelName
    });
}