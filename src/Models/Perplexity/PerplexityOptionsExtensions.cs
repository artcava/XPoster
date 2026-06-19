using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace XPoster.Models;

/// <summary>
/// Extension methods for registering <see cref="PerplexityOptions"/> binding and validation.
/// </summary>
public static class PerplexityOptionsExtensions
{
    /// <summary>App-settings section name: <c>Perplexity</c>.</summary>
    public const string SectionName = "Perplexity";

    /// <summary>
    /// Binds the <c>Perplexity</c> configuration section to <see cref="PerplexityOptions"/>
    /// and registers <see cref="PerplexityOptionsValidator"/> for startup validation.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <param name="configuration">The application configuration.</param>
    /// <returns>The same <see cref="IServiceCollection"/> for chaining.</returns>
    public static IServiceCollection AddPerplexityOptions(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<PerplexityOptions>(configuration.GetSection(SectionName));
        services.AddSingleton<IValidateOptions<PerplexityOptions>, PerplexityOptionsValidator>();
        return services;
    }
}
