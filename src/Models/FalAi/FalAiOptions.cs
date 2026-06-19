namespace XPoster.Models;

/// <summary>
/// Strongly-typed configuration for the Fal.ai provider, bound from the <c>FalAi</c> section.
/// </summary>
public sealed class FalAiOptions
{
    /// <summary>Gets or sets the API key used for authentication.</summary>
    public string ApiKey { get; set; } = string.Empty;
    /// <summary>Gets or sets the model ID to use for AI requests.</summary>
    public string ModelId { get; set; } = "fal-ai/flux/schnell"; // FLUX.1 Turbo
    /// <summary>Gets or sets the image size for generated images.</summary>
    public string ImageSize { get; set; } = "landscape_4_3";
    /// <summary>Gets or sets the number of inference steps for image generation.</summary>
    public int NumInferenceSteps { get; set; } = 4;
}
