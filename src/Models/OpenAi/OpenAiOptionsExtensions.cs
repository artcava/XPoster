using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace XPoster.Models;

/// <summary>
/// Extension methods for registering <see cref="OpenAiOptions"/> binding and validation.
/// </summary>
public static class OpenAiOptionsExtensions
{
    /// <summary>App-settings section name: <c>OpenAI</c>.</summary>
    public const string SectionName = "OpenAI";

    /// <summary>
    /// Binds the <c>OpenAI</c> configuration section to <see cref="OpenAiOptions"/>
    /// and registers <see cref="OpenAiOptionsValidator"/> for startup validation.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <param name="configuration">The application configuration.</param>
    /// <returns>The same <see cref="IServiceCollection"/> for chaining.</returns>
    public static IServiceCollection AddOpenAiOptions(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<OpenAiOptions>(configuration.GetSection(SectionName));
        services.AddSingleton<IValidateOptions<OpenAiOptions>, OpenAiOptionsValidator>();
        return services;
    }
}
