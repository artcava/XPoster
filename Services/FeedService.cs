using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using XPoster.Abstraction;
using XPoster.Models;

namespace XPoster.Services;

public class FeedService : IFeedService
{
    // Logger può essere iniettato se necessario
    public async Task<IEnumerable<RSSFeed>> GetFeedsAsync(string url, DateTimeOffset start, DateTimeOffset end)
    {
        var feeds = new List<RSSFeed>();

        using var httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(15) };

        const string DateFormat = "ddd, dd MMM yyyy HH:mm:ss zzz";
        CultureInfo Culture = CultureInfo.InvariantCulture;

        try
        {
            /* OLD Code
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
            */
            /* NEW code */
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; ConsoleApp/1.0)");
            using var response = httpClient.GetAsync(url).GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            content = content.Trim();

            XDocument xmlDoc = XDocument.Parse(content);
            var channel = xmlDoc.Root?.Element("channel");

            if (channel == null)
            {
                Console.WriteLine("No feeds found");
                throw new Exception("Invalid RSS feed format");
            }
            feeds.AddRange(channel.Elements("item")
                .Select(item => {
                    bool success = DateTimeOffset.TryParseExact(
                        item.Element("pubDate")?.Value,
                        DateFormat,
                        Culture,
                        DateTimeStyles.AssumeUniversal,
                        out DateTimeOffset parsedDate);

                    return new
                    {
                        ItemElement = item,
                        PublishDate = success ? (DateTimeOffset?)parsedDate : null,
                        Title = item.Element("title")?.Value
                    };
                })
                .Where(x => {
                    if (!x.PublishDate.HasValue || x.PublishDate.Value < start || x.PublishDate.Value > end)
                    {
                        return false;
                    }

                    string title = x.Title ?? string.Empty;

                    return title.Contains("bitcoin", StringComparison.OrdinalIgnoreCase) ||
                           title.Contains("btc", StringComparison.OrdinalIgnoreCase);
                })
                .Select(item => new RSSFeed
                {
                    Title = item.Title,

                    Content = WebUtility.HtmlDecode(
                        Regex.Replace(item.ItemElement.Element("description")?.Value ?? string.Empty, "<[^>]+>", " ").Trim()),

                    Link = item.ItemElement.Element("link")?.Value,

                    PublishDate = (DateTimeOffset)item.PublishDate
                }));
        }
        catch (Exception) { return Enumerable.Empty<RSSFeed>(); }

        return await Task.FromResult(feeds);
    }
}