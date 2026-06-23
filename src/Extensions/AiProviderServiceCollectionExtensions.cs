using Microsoft.Extensions.DependencyInjection;
using XPoster.Contracts;
using XPoster.Services;

namespace XPoster.Extensions;

/// <summary>
/// Extension methods that register AI capability interfaces as keyed services by <see cref="AiProvider"/>.
/// </summary>
public static class AiProviderServiceCollectionExtensions
{
    /// <summary>
    /// Registers all AI provider implementations as keyed <see cref="ITextToTextProvider"/> and
    /// <see cref="ITextToImageProvider"/> services. Each key corresponds to an <see cref="AiProvider"/>
    /// enum value and activates only the capabilities the provider actually supports.
    /// </summary>
    /// <remarks>
    /// Provider capability matrix:
    /// <list type="table">
    ///   <listheader><term>Provider</term><term>ITextToTextProvider</term><term>ITextToImageProvider</term></listheader>
    ///   <item><term>OpenAi</term><term>✓</term><term>✓</term></item>
    ///   <item><term>AzureFoundry</term><term>✓</term><term>✓</term></item>
    ///   <item><term>DeepSeek</term><term>✓</term><term>✗</term></item>
    ///   <item><term>Perplexity</term><term>✓</term><term>✗</term></item>
    ///   <item><term>FalAi</term><term>✗</term><term>✓</term></item>
    /// </list>
    /// </remarks>
    public static IServiceCollection AddXPosterAiProviders(this IServiceCollection services)
    {
        // OpenAI: text + image
        services.AddKeyedTransient<ITextToTextProvider, OpenAiService>(AiProvider.OpenAi);
        services.AddKeyedTransient<ITextToImageProvider, OpenAiService>(AiProvider.OpenAi);

        // Azure AI Foundry: text + image
        services.AddKeyedTransient<ITextToTextProvider, AzureFoundryService>(AiProvider.AzureFoundry);
        services.AddKeyedTransient<ITextToImageProvider, AzureFoundryService>(AiProvider.AzureFoundry);

        // DeepSeek: text only
        services.AddKeyedTransient<ITextToTextProvider, DeepSeekService>(AiProvider.DeepSeek);

        // Perplexity: text only
        services.AddKeyedTransient<ITextToTextProvider, PerplexityService>(AiProvider.Perplexity);

        // fal.ai: image only
        services.AddKeyedTransient<ITextToImageProvider, FalAiImageService>(AiProvider.FalAi);

        return services;
    }
}
