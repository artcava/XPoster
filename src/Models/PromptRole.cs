namespace XPoster.Models;

/// <summary>
/// Identifies the role of a prompt step within the orchestration flow.
/// Used as a discriminator key in <see cref="FeedPromptOptions"/> to look up
/// the correct <see cref="PromptStepOptions"/> for each provider call.
/// </summary>
public enum PromptRole
{
    /// <summary>Generates the primary text summary from raw feed content.</summary>
    Summary,

    /// <summary>Derives the image-generation prompt from the summary text.</summary>
    ImagePromptDerivation,

    /// <summary>Generates the image from the derived prompt.</summary>
    ImageGeneration
}
