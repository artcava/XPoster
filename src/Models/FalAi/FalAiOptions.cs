using XPoster.Contracts;

namespace XPoster.Models;

/// <summary>
/// Strongly-typed configuration for the Fal.ai provider, bound from the <c>FalAi</c> section.
/// </summary>
public sealed class FalAiOptions : IAiProviderOptions
{
    /// <summary>Gets or sets the endpoint URL for the Fal.ai API.</summary>
    public string Endpoint { get; set; } = "https://fal.run";
    /// <summary>Gets or sets the API key used for authentication.</summary>
    public string ApiKey { get; set; } = string.Empty;
    /// <summary>Gets or sets the model ID to use for AI requests.</summary>
    public string ImageModelName { get; set; } = "fal-ai/flux/schnell"; // FLUX.1 Turbo
    /// <summary>Gets or sets the number of inference steps for image generation.</summary>
    public int NumInferenceSteps { get; set; } = 4;

    /// <inheritdoc/>
    public AiModelCatalog ModelCatalog => new(new Dictionary<AiModelClass, string>
    {
        [AiModelClass.Image] = ImageModelName
    });
}
