namespace XPoster.Contracts;

/// <summary>
/// Provides the word-to-hashtag replacement map applied to generated summaries.
/// </summary>
/// <remarks>
/// Decouples tag-replacement configuration from <see cref="XPoster.Orchestrators.FeedOrchestrator"/>,
/// following the same pattern as <see cref="IFeedUrlProvider"/>.
/// Swap implementations via DI without touching orchestrator logic.
/// </remarks>
public interface ITagReplacementProvider
{
    /// <summary>
    /// Returns the replacement dictionary mapping plain words to their hashtag equivalents
    /// (e.g. <c>"bitcoin"</c> → <c>"#Bitcoin"</c>).
    /// </summary>
    IReadOnlyDictionary<string, string> GetReplacements();
}
