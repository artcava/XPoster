namespace XPoster.Abstraction;

/// <summary>
/// Provides the ordered list of RSS/Atom feed URLs to be fetched during orchestration.
/// </summary>
/// <remarks>
/// Decouples feed URL configuration from <see cref="XPoster.Implementation.FeedOrchestrator"/> and
/// <see cref="XPoster.Abstraction.IFeedService"/> internals, following the same pattern as
/// <see cref="ISlotProfileProvider"/>. Swap implementations via DI without touching orchestrator logic.
/// </remarks>
public interface IFeedUrlProvider
{
    /// <summary>Returns the ordered list of RSS/Atom feed URLs to process for the current execution slot.</summary>
    IReadOnlyList<string> GetFeedUrls();
}
