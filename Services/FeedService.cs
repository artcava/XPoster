using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using XPoster.Abstraction;
using XPoster.Models;

namespace XPoster.Services;

public class FeedService : IFeedService
{
    // Logger può essere iniettato se necessario
    public async Task<IEnumerable<RSSFeed>> GetFeedsAsync(string url, DateTimeOffset start, DateTimeOffset end)
    {
        var feeds = new List<RSSFeed>();
        try
        {
            using var reader = XmlReader.Create(url, new XmlReaderSettings { Async = true });
            var feed = SyndicationFeed.Load(reader);
            if (feed == null) return Enumerable.Empty<RSSFeed>();

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
        catch (Exception) { return Enumerable.Empty<RSSFeed>(); }

        return await Task.FromResult(feeds);
    }
}