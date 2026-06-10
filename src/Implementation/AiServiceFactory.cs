using Microsoft.Extensions.DependencyInjection;
using XPoster.Abstraction;

namespace XPoster.Implementation;

/// <summary>
/// Resolves IAiService implementations by AiProvider enum.
/// </summary>
public class AiServiceFactory : IAiServiceFactory
{
    private readonly IServiceProvider _serviceProvider;
    private static readonly HashSet<AiProvider> _supportedProviders =
    [
        AiProvider.OpenAi,
        AiProvider.AzureFoundry,
        AiProvider.DeepSeekWithFal,
        // AiProvider.Perplexity, // Uncomment when implemented
    ];

    /// <summary>
    /// Initialises a new instance of <see cref="AiServiceFactory"/>.
    /// </summary>
    /// <param name="serviceProvider">Service provider used to resolve concrete AI services.</param>
    public AiServiceFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Resolves an <see cref="IAiService"/> implementation for the requested provider.
    /// </summary>
    /// <param name="provider">The provider to resolve.</param>
    /// <returns>The resolved AI service.</returns>
    /// <exception cref="ArgumentException">Thrown when no provider mapping exists.</exception>
    /// <exception cref="InvalidOperationException">Thrown when mapped service cannot be resolved from DI.</exception>
    public IAiService GetByProvider(AiProvider provider)
    {
        if (!_supportedProviders.Contains(provider))
            throw new ArgumentException($"No IAiService registered for provider: {provider}");

        var service = _serviceProvider.GetKeyedService<IAiService>(provider);
        if (service is null)
            throw new InvalidOperationException($"Could not resolve IAiService for provider: {provider}");

        return service;
    }
}
