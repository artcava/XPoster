using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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
        services.Configure<OpenAiOptions>(configuration.GetSection(OpenAiOptions.SectionName));
        services.AddSingleton<IValidateOptions<OpenAiOptions>, OpenAiOptionsValidator>();

        services.Configure<AzureFoundryOptions>(configuration.GetSection(AzureFoundryOptions.SectionName));
        services.AddSingleton<IValidateOptions<AzureFoundryOptions>, AzureFoundryOptionsValidator>();

        services.Configure<DeepSeekOptions>(configuration.GetSection(DeepSeekOptions.SectionName));
        services.AddSingleton<IValidateOptions<DeepSeekOptions>, DeepSeekOptionsValidator>();

        services.Configure<FalAiOptions>(configuration.GetSection(FalAiOptions.SectionName));
        services.AddSingleton<IValidateOptions<FalAiOptions>, FalAiOptionsValidator>();

        services.Configure<PerplexityOptions>(configuration.GetSection(PerplexityOptions.SectionName));
        services.AddSingleton<IValidateOptions<PerplexityOptions>, PerplexityOptionsValidator>();

        return services;
    }
}
