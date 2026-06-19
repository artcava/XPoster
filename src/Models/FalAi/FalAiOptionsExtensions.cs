using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace XPoster.Models;

/// <summary>
/// Extension methods for registering <see cref="FalAiOptions"/> binding and validation.
/// </summary>
public static class FalAiOptionsExtensions
{
    /// <summary>App-settings section name: <c>FalAi</c>.</summary>
    public const string SectionName = "FalAi";

    /// <summary>
    /// Binds the <c>FalAi</c> configuration section to <see cref="FalAiOptions"/>
    /// and registers <see cref="FalAiOptionsValidator"/> for startup validation.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <param name="configuration">The application configuration.</param>
    /// <returns>The same <see cref="IServiceCollection"/> for chaining.</returns>
    public static IServiceCollection AddFalAiOptions(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<FalAiOptions>(configuration.GetSection(SectionName));
        services.AddSingleton<IValidateOptions<FalAiOptions>, FalAiOptionsValidator>();
        return services;
    }
}
