using XPoster.Models;

namespace XPoster.Contracts;

/// <summary>
/// Shared abstraction for all AI provider option classes.
/// Exposes the connectivity settings common to every provider and a normalized
/// model catalog for capability discovery.
/// </summary>
public interface IAiProviderOptions
{
    /// <summary>Gets the API key used for authentication.</summary>
    string ApiKey { get; }

    /// <summary>Gets the provider endpoint base URL.</summary>
    string Endpoint { get; }

    /// <summary>
    /// Gets the normalized model catalog for this provider.
    /// Use <see cref="AiModelCatalog.Supports"/> or <see cref="AiModelCatalog.TryGet"/>
    /// to check which model classes are available before accessing a model name.
    /// </summary>
    AiModelCatalog ModelCatalog { get; }
}

/// <summary>
/// Shared abstraction for all AI provider option classes that are bound from a configuration section.
/// </summary>
public interface IAiProviderSection
{
    /// <summary>App-settings section name: <c>IAiProviderSection</c>.</summary>
    static abstract string SectionName { get; }
}