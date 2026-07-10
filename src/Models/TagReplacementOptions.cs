namespace XPoster.Models;

/// <summary>
/// Configuration model for the word-to-hashtag replacement map consumed by
/// <see cref="XPoster.Providers.ConfigurationTagReplacementProvider"/>.
/// Bind from the <c>TagReplacementOptions</c> section in app settings.
/// </summary>
public sealed class TagReplacementOptions
{
    /// <summary>App-settings section name: <c>TagReplacementOptions</c>.</summary>
    public const string SectionName = "TagReplacementOptions";

    /// <summary>
    /// Dictionary mapping plain words to their hashtag replacements
    /// (e.g. <c>"bitcoin"</c> → <c>"#Bitcoin"</c>).
    /// Matching is case-insensitive at application time.
    /// Defaults to an empty dictionary when the section is absent.
    /// </summary>
    public Dictionary<string, string> Replacements { get; set; } = new();
}
