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
    Perplexity = 2,

    /// <summary>Azure AI Foundry provider.</summary>
    AzureFoundry = 3,

    /// <summary>DeepSeek provider with Fal.ai integration.</summary>
    DeepSeekWithFal = 4,
}
