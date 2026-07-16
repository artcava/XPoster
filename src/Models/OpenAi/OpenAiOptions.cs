namespace XPoster.Models;

/// <summary>
/// Strongly-typed configuration for the OpenAI provider, bound from the <c>OpenAI</c> configuration section.
/// Contains only connectivity and model-capability settings.
/// Prompt data is supplied at runtime via <see cref="PromptRequest"/> / <see cref="ImagePromptRequest"/>.
/// </summary>
public sealed class OpenAiOptions
{
    /// <summary>Gets or sets the OpenAI API key used for authentication.</summary>
    public string ApiKey { get; set; } = string.Empty;

    // ── Chat / Completions ────────────────────────────────────────────────────

    /// <summary>Gets or sets the Chat Completions API endpoint.</summary>
    public string ChatEndpoint { get; set; } = "https://api.openai.com/v1/chat/completions";

    /// <summary>Gets or sets the model used for chat/completion requests.</summary>
    public string ChatModel { get; set; } = "gpt-4.1-nano";

    // ── Image Generation ──────────────────────────────────────────────────────

    /// <summary>Gets or sets the Image Generations API endpoint.</summary>
    public string ImageEndpoint { get; set; } = "https://api.openai.com/v1/images/generations";

    /// <summary>Gets or sets the model used for image generation requests.</summary>
    public string ImageModel { get; set; } = "gpt-image-1.5";
}