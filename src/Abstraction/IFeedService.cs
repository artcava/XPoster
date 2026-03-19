using XPoster.Models;

namespace XPoster.Abstraction;

/// <summary>
/// Fetches and filters RSS feed items from a remote source.
/// </summary>
public interface IFeedService
{
    /// <summary>
    /// Retrieves RSS feed entries published within the specified time window that match at least one of the given keywords.
    /// </summary>
    /// <param name="url">The URL of the RSS feed to fetch.</param>
    /// <param name="start">The inclusive start of the publication date range.</param>
    /// <param name="end">The inclusive end of the publication date range.</param>
    /// <param name="keywords">A collection of keywords; only items whose title contains at least one are returned.</param>
    /// <returns>A collection of <see cref="RSSFeed"/> entries matching the filter criteria.</returns>
    Task<IEnumerable<RSSFeed>> GetFeedsAsync(string url, DateTimeOffset start, DateTimeOffset end, IEnumerable<string> keywords);
}
