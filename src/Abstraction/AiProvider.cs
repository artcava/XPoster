using System.ComponentModel;

namespace XPoster.Abstraction;

/// <summary>
/// Enumerates the supported AI providers for content generation.
/// </summary>
public enum AiProvider
{
    /// <summary>No provider selected.</summary>
    [Description("None")]
    None = 0,

    /// <summary>OpenAI provider.</summary>
    [Description("OpenAI")]
    OpenAi = 1,

    /// <summary>Perplexity provider.</summary>
    [Description("Perplexity")]
    Perplexity = 2,

    /// <summary>Azure AI Foundry provider.</summary>
    [Description("Azure Foundry")]
    AzureFoundry = 3,

    /// <summary>DeepSeek provider with Fal.ai integration.</summary>
    [Description("fal.ai")]
    DeepSeekWithFal = 4,
}
