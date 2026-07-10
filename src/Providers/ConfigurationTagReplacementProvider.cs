using Microsoft.Extensions.Options;
using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.Providers;

/// <summary>
/// Returns the word-to-hashtag replacement map from the static app-settings
/// section <c>TagReplacementOptions:Replacements</c>.
/// </summary>
/// <remarks>
/// This is the default <see cref="ITagReplacementProvider"/> implementation.
/// Registered as <c>Singleton</c>; the underlying <see cref="TagReplacementOptions"/> is bound
/// via <see cref="IOptions{TOptions}"/> at startup.
/// </remarks>
public sealed class ConfigurationTagReplacementProvider : ITagReplacementProvider
{
    private readonly IReadOnlyDictionary<string, string> _replacements;

    /// <summary>
    /// Initialises a new instance of <see cref="ConfigurationTagReplacementProvider"/>.
    /// </summary>
    /// <param name="options">Bound <see cref="TagReplacementOptions"/> from app settings.</param>
    public ConfigurationTagReplacementProvider(IOptions<TagReplacementOptions> options)
    {
        ArgumentNullException.ThrowIfNull(options);
        _replacements = options.Value.Replacements ?? new Dictionary<string, string>();
    }

    /// <inheritdoc/>
    public IReadOnlyDictionary<string, string> GetReplacements() => _replacements;
}
