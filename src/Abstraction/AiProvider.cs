namespace XPoster.Abstraction;

/// <summary>
/// Enumerates the supported AI providers for content generation.
/// </summary>
public enum AiProvider
{
    /// <summary>No provider selected.</summary>
    None = 0,

    /// <summary>OpenAI provider.</summary>
    OpenAi = 1,

    /// <summary>Perplexity provider.</summary>
    Perplexity = 2
    // Extend here for future providers (e.g., Foundry)
}
