using System.ComponentModel;

namespace XPoster.Contracts;

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

    /// <summary>DeepSeek provider (text-to-text only).</summary>
    [Description("DeepSeek")]
    DeepSeek = 4,

    /// <summary>Fal.ai provider (text-to-image only).</summary>
    [Description("fal.ai")]
    FalAi = 5,
}
