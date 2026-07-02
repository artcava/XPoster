using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace XPoster.Credentials;

/// <summary>
/// Extension methods for registering <see cref="InstagramCredentials"/> and its validator in the DI container.
/// </summary>
public static class InstagramCredentialsExtensions
{

    /// <summary>
    /// Registers <see cref="InstagramCredentials"/> and its validator in the DI container.
    /// </summary>
    /// <param name="services">The service collection to add the credentials to.</param>
    /// <param name="configuration">The configuration containing the Instagram credentials section.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddInstagramCredentials(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<InstagramCredentials>(configuration.GetSection(InstagramCredentials.SectionName));
        services.AddSingleton<IValidateOptions<InstagramCredentials>, InstagramCredentialsValidator>();
        return services;
    }
}