using System;
using System.Linq;
using System.Threading.Tasks;
using XPoster.MessageAbstraction;
using XPoster.Utilities;

namespace XPoster.MessageImplementation;

public class MessageBTCFeed() : IGeneration
{
    private bool _sendIt = true;
    public string Name => typeof(MessageBTCFeed).Name;

    public bool SendIt { get { return _sendIt; } set { _sendIt = value; } }

    public async Task<string> GenerateMessage()
    {
        string url = "https://cointelegraph.com/rss/tag/bitcoin";
        var end = DateTimeOffset.UtcNow;
        var start = end.AddDays(-1);
        var feeds = await FeedUtilities.GetFeeds(url, start, end);

        if (feeds == null || !feeds.Any())
        {
            SendIt = false;
            return string.Empty;
        }

        string feedContent = feeds.Select(f => f.Content).Aggregate(string.Empty, (current, next) => current + "\n" + next);

        var summary = await AIUtilities.GetSummaryFromOpenAI(feedContent);
        if (string.IsNullOrWhiteSpace(summary))
        {
            SendIt = false;
            return string.Empty;
        }
        return summary;
    }
}
