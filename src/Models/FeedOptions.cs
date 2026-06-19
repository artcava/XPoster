namespace XPoster.Models;

/// <summary>
/// Configuration model for RSS/Atom feed URLs consumed by <see cref="XPoster.Orchestrators.ConfigurationFeedUrlProvider"/>.
/// Bind from the <c>FeedOptions</c> section in app settings.
/// </summary>
public sealed class FeedOptions
{
    /// <summary>App-settings section name: <c>FeedOptions</c>.</summary>
    public const string SectionName = "FeedOptions";

    /// <summary>
    /// The ordered list of RSS/Atom feed URLs to fetch during orchestration.
    /// Defaults to an empty list when the section is absent or <c>Urls</c> is null.
    /// </summary>
    public List<string> Urls { get; set; } = [];
}
