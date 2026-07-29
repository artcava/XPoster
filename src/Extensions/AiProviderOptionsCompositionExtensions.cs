using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XPoster.Models;

namespace XPoster.Extensions;

/// <summary>
/// Registers all AI provider option bindings and validators in a single startup call.
/// </summary>
public static class AiProviderOptionsCompositionExtensions
{
    /// <summary>
    /// Binds and validates all AI provider option sections
    /// (<c>OpenAI</c>, <c>AzureFoundry</c>, <c>DeepSeek</c>, <c>FalAi</c>, <c>Perplexity</c>)
    /// in one call.  This is the only entrypoint <c>Program.cs</c> needs for AI option wiring.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <param name="configuration">The application configuration.</param>
    /// <returns>The same <see cref="IServiceCollection"/> for chaining.</returns>
    public static IServiceCollection AddAiProviderOptions(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddOpenAiOptions(configuration);
        services.AddAzureFoundryOptions(configuration);
        services.AddDeepSeekOptions(configuration);
        services.AddFalAiOptions(configuration);
        services.AddPerplexityOptions(configuration);
        return services;
    }
}
