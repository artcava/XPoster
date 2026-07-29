using System.Diagnostics.CodeAnalysis;
using XPoster.Contracts;

namespace XPoster.Models;

/// <summary>
/// Holds the model names that an AI provider exposes, keyed by <see cref="AiModelClass"/>.
/// Provides safe capability lookup without exposing raw dictionary semantics to consumers.
/// </summary>
public sealed class AiModelCatalog
{
    /// <summary>An empty catalog representing a provider with no registered models.</summary>
    public static readonly AiModelCatalog Empty = new(new Dictionary<AiModelClass, string>());

    private readonly IReadOnlyDictionary<AiModelClass, string> _models;

    /// <summary>
    /// Initialises a new <see cref="AiModelCatalog"/> from the given model name map.
    /// Entries with null or whitespace model names are silently excluded.
    /// </summary>
    public AiModelCatalog(IReadOnlyDictionary<AiModelClass, string> models)
    {
        ArgumentNullException.ThrowIfNull(models);
        _models = models
            .Where(kv => !string.IsNullOrWhiteSpace(kv.Value))
            .ToDictionary(kv => kv.Key, kv => kv.Value);
    }

    /// <summary>
    /// Returns <see langword="true"/> if the provider has a model configured for the given
    /// <paramref name="modelClass"/> and populates <paramref name="modelName"/>.
    /// </summary>
    public bool TryGet(AiModelClass modelClass, [NotNullWhen(true)] out string? modelName)
        => _models.TryGetValue(modelClass, out modelName);

    /// <summary>
    /// Returns <see langword="true"/> if the provider has a model configured for the given
    /// <paramref name="modelClass"/>.
    /// </summary>
    public bool Supports(AiModelClass modelClass) => _models.ContainsKey(modelClass);

    /// <summary>
    /// Returns the model name for the given <paramref name="modelClass"/>.
    /// Throws <see cref="InvalidOperationException"/> if the capability is not supported.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the provider does not support <paramref name="modelClass"/>.
    /// </exception>
    public string GetRequired(AiModelClass modelClass)
    {
        if (!_models.TryGetValue(modelClass, out var name))
            throw new InvalidOperationException(
                $"This provider does not support the '{modelClass}' model class.");
        return name;
    }
}
