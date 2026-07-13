using Microsoft.Extensions.Options;
using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.Providers;

/// <summary>
/// Returns feed URLs from the static app-settings section <c>FeedOptions:Urls</c>.
/// </summary>
/// <remarks>
/// This is the default <see cref="IFeedUrlProvider"/> implementation.
/// Registered as <c>Singleton</c>; the underlying <see cref="FeedOptions"/> is bound
/// via <see cref="IOptions{TOptions}"/> at startup.
/// </remarks>
public sealed class ConfigurationFeedUrlProvider : IFeedUrlProvider
{
    private readonly IReadOnlyList<string> _urls;

    /// <summary>
    /// Initialises a new instance of <see cref="ConfigurationFeedUrlProvider"/>.
    /// </summary>
    /// <param name="options">Bound <see cref="FeedOptions"/> from app settings.</param>
    public ConfigurationFeedUrlProvider(IOptions<FeedOptions> options)
    {
        ArgumentNullException.ThrowIfNull(options);
        _urls = options.Value.Urls ?? [];
    }

    /// <inheritdoc/>
    public IReadOnlyList<string> GetFeedUrls() => _urls;
}
