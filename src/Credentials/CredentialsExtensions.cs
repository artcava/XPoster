using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using XPoster.Contracts;

namespace XPoster.Credentials;

/// <summary>
/// Extension methods for registering <see cref="InstagramCredentials"/> and its validator in the DI container.
/// </summary>
public static class CredentialsExtensions
{

    /// <summary>
    /// Registers <see cref="InstagramCredentials"/> and its validator in the DI container.
    /// </summary>
    /// <param name="services">The service collection to add the credentials to.</param>
    /// <param name="configuration">The configuration containing the Instagram credentials section.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddCredentials(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddOptions<XCredentials>()
            .Bind(configuration.GetSection(XCredentials.SectionName));

        services.AddSingleton<IValidateOptions<XCredentials>, XCredentialsValidator>();

        services
            .AddOptions<LinkedInCredentials>()
            .Bind(configuration.GetSection(LinkedInCredentials.SectionName));

        services.AddSingleton<IValidateOptions<LinkedInCredentials>, LinkedInCredentialsValidator>();

        services
            .AddOptions<InstagramCredentials>()
            .Bind(configuration.GetSection(InstagramCredentials.SectionName));

        services.AddSingleton<IValidateOptions<InstagramCredentials>, InstagramCredentialsValidator>();

        services.AddSingleton<ICredentialsStartupValidator, CredentialsStartupValidator>();
        
        return services;
    }
}