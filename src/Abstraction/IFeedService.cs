using XPoster.Models;

namespace XPoster.Abstraction;

public interface IFeedService
{
    Task<IEnumerable<RSSFeed>> GetFeedsAsync(string url, DateTimeOffset start, DateTimeOffset end, IEnumerable<string> keywords);
}