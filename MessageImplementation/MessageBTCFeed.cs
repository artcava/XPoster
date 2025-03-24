using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using XPoster.MessageAbstraction;
using XPoster.Utilities;

namespace XPoster.MessageImplementation;

public class MessageBTCFeed(ILogger log) : IGeneration
{
    private bool _sendIt = true;
    public string Name => typeof(MessageBTCFeed).Name;

    public bool SendIt { get { return _sendIt; } set { _sendIt = value; } }

    public bool ProduceImage { get => true; set => throw new NotImplementedException(); }

    public async Task<string> GenerateMessage()
    {
        string url = "https://cointelegraph.com/rss/tag/bitcoin";
        var end = DateTimeOffset.UtcNow;
        var start = end.AddDays(-1);
        var feeds = await FeedUtilities.GetFeeds(url, start, end);

        if (feeds == null || !feeds.Any())
        {
            log.LogInformation("No feeds found");
            SendIt = false;
            return string.Empty;
        }

        string feedContent = feeds.Select(f => f.Content).Aggregate(string.Empty, (current, next) => current + "\n" + next);

        var summary = await AIUtilities.GetSummaryFromOpenAI(log, feedContent);
        if (string.IsNullOrWhiteSpace(summary))
        {
            log.LogError("Unable to get summary from OpenAI");
            SendIt = false;
            return string.Empty;
        }

        log.LogInformation("Generated summary: {0}", summary);

        summary = ReplaceEveryFirstOccurenceOf(summary, new Dictionary<string, string> {
            { "bitcoin", "#Bitcoin" }, 
            { "btc", "#BTC" }, 
        });

        return summary;
    }

    public async Task<ImageMessage> GenerateMessageWithImage()
    {
        var summary = await GenerateMessage();
        if (summary == null) 
        {
            log.LogInformation("No summary generated");
            SendIt = false;
            return null;
        }

        var prompt4Image = await AIUtilities.GetImagePromptFromOpenAI(log, summary);
        if (string.IsNullOrWhiteSpace(prompt4Image))
        {
            log.LogError("Unable to get image prompt from OpenAI");
            prompt4Image = summary;
        }

        var image = await AIUtilities.GenerateImageWithOpenAI(log, prompt4Image);
        if (image == null) 
        {
            log.LogInformation("No image generated");
            SendIt = false;
            return null;
        }

        return new ImageMessage
        {
            Message = summary,
            Image = image
        };
    }

    private string ReplaceEveryFirstOccurenceOf(string text, Dictionary<string,string> replacements)
    {
        var sb = new StringBuilder(text);

        foreach (var entry in replacements)
        {
            string key = entry.Key;
            string value = entry.Value;

            int index = Regex.Match(sb.ToString(), Regex.Escape(key), RegexOptions.IgnoreCase).Index;

            if (index != -1)
            {
                sb.Remove(index, key.Length);
                sb.Insert(index, value);
            }
        }

        return sb.ToString();
    }
}
