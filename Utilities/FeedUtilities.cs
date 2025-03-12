using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using XPoster.Models;

namespace XPoster.Utilities;

public static class FeedUtilities
{
    public static async Task<IEnumerable<RSSFeed>> GetFeeds(string url, DateTimeOffset start, DateTimeOffset end)
    {
        var feeds = new List<RSSFeed>();
        try
        {
            using var reader = XmlReader.Create(url);
            var feed = SyndicationFeed.Load(reader);
            if (feed == null)
            {
                return null;
            }

            feeds.AddRange(feed.Items.Where(x =>
                            x.PublishDate >= start &&
                            x.PublishDate <= end &&
                            (x.Title.Text.Contains("bitcoin", StringComparison.OrdinalIgnoreCase) || x.Title.Text.Contains("btc", StringComparison.OrdinalIgnoreCase)))
                .Select(item => new RSSFeed
                {
                    Title = item.Title.Text,
                    Content = System.Net.WebUtility.HtmlDecode(Regex.Replace(item.Summary.Text, "<[^>]+>", " ").Trim()),
                    Link = item.Links.FirstOrDefault()?.Uri.ToString() ?? string.Empty,
                    PublishDate = item.PublishDate
                }));
        }
        catch (Exception)
        {
            return null;
        }
        await Task.Run(() => { });

        return feeds;
    }
}
