using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using XPoster.Abstraction;
using XPoster.Utilities;

namespace XPoster.Implementation;

public class FeedGenerator(ISender sender, ILogger logger) : BaseGenerator(sender, logger)
{
    private bool _sendIt = true;
    public override string Name => typeof(FeedGenerator).Name;

    public override bool SendIt { get { return _sendIt; } set { _sendIt = value; } }

    public override bool ProduceImage { get => true; set => throw new NotImplementedException(); }

    public override async Task<Message> GenerateAsync()
    {
        var summary = await GenerateMessage();
        if (summary == null) 
        {
            logger.LogInformation("No summary generated");
            SendIt = false;
            return null;
        }

        var prompt4Image = await AIUtilities.GetImagePromptFromOpenAI(logger, summary);
        if (string.IsNullOrWhiteSpace(prompt4Image))
        {
            logger.LogError("Unable to get image prompt from OpenAI");
            prompt4Image = summary;
        }

        var image = await AIUtilities.GenerateImageWithOpenAI(logger, prompt4Image);
        if (image == null) 
        {
            logger.LogInformation("No image generated");
            SendIt = false;
            return null;
        }

        return new Message
        {
            Content = summary,
            Image = image
        };
    }

    private async Task<string> GenerateMessage()
    {
        string url = "https://cointelegraph.com/rss/tag/bitcoin";
        var end = DateTimeOffset.UtcNow;
        var start = end.AddDays(-1);
        var feeds = await FeedUtilities.GetFeeds(url, start, end);

        if (feeds == null || !feeds.Any())
        {
            logger.LogInformation("No feeds found");
            SendIt = false;
            return string.Empty;
        }

        string feedContent = feeds.Select(f => f.Content).Aggregate(string.Empty, (current, next) => current + "\n" + next);

        var summary = await AIUtilities.GetSummaryFromOpenAI(logger, feedContent, _sender.MessageMaxLenght);
        if (string.IsNullOrWhiteSpace(summary))
        {
            logger.LogError("Unable to get summary from OpenAI");
            SendIt = false;
            return string.Empty;
        }

        logger.LogInformation("Generated summary: {0}", summary);

        summary = ReplaceEveryFirstOccurenceOf(summary, new Dictionary<string, string> {
            { "bitcoin", "#Bitcoin" },
            { "btc", "#BTC" },
            { "fed", "#FED" },
        });

        return summary;
    }

    private string ReplaceEveryFirstOccurenceOf(string text, Dictionary<string, string> replacements)
    {
        var sb = new StringBuilder(text);

        foreach (var entry in replacements)
        {
            string key = entry.Key;
            string value = entry.Value;

            Match match = Regex.Match(sb.ToString(), Regex.Escape(key), RegexOptions.IgnoreCase);
            if (match.Success)
            {
                int index = match.Index;
                sb.Remove(index, key.Length);
                sb.Insert(index, value);
            }
        }

        return sb.ToString();
    }
}
