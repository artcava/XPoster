using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace XPoster.Models;

/// <summary>
/// Extension methods for registering <see cref="DeepSeekOptions"/> binding and validation.
/// </summary>
public static class DeepSeekOptionsExtensions
{
    /// <summary>App-settings section name: <c>DeepSeek</c>.</summary>
    public const string SectionName = "DeepSeek";

    /// <summary>
    /// Binds the <c>DeepSeek</c> configuration section to <see cref="DeepSeekOptions"/>
    /// and registers <see cref="DeepSeekOptionsValidator"/> for startup validation.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <param name="configuration">The application configuration.</param>
    /// <returns>The same <see cref="IServiceCollection"/> for chaining.</returns>
    public static IServiceCollection AddDeepSeekOptions(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<DeepSeekOptions>(configuration.GetSection(SectionName));
        services.AddSingleton<IValidateOptions<DeepSeekOptions>, DeepSeekOptionsValidator>();
        return services;
    }
}
