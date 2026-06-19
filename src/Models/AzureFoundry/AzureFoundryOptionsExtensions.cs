using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace XPoster.Models;

/// <summary>
/// Extension methods for registering <see cref="AzureFoundryOptions"/> binding and validation.
/// </summary>
public static class AzureFoundryOptionsExtensions
{
    /// <summary>App-settings section name: <c>AzureFoundry</c>.</summary>
    public const string SectionName = "AzureFoundry";

    /// <summary>
    /// Binds the <c>AzureFoundry</c> configuration section to <see cref="AzureFoundryOptions"/>
    /// and registers <see cref="AzureFoundryOptionsValidator"/> for startup validation.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <param name="configuration">The application configuration.</param>
    /// <returns>The same <see cref="IServiceCollection"/> for chaining.</returns>
    public static IServiceCollection AddAzureFoundryOptions(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<AzureFoundryOptions>(configuration.GetSection(SectionName));
        services.AddSingleton<IValidateOptions<AzureFoundryOptions>, AzureFoundryOptionsValidator>();
        return services;
    }
}
