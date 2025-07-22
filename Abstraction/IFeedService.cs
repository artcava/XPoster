using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XPoster.Models;

namespace XPoster.Abstraction;

public interface IFeedService
{
    Task<IEnumerable<RSSFeed>> GetFeedsAsync(string url, DateTimeOffset start, DateTimeOffset end);
}