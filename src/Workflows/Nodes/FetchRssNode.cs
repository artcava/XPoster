using System.Text;
using XPoster.Contracts;
using XPoster.Workflows.Abstractions;
using XPoster.Workflows.Utilities;

namespace XPoster.Workflows.Nodes;

/// <summary>
/// Fetches RSS feed content from one or more URLs over a 24-hour window.
/// Adapter for <see cref="IFeedService"/> and <see cref="ITagReplacementProvider"/>.
/// </summary>
public sealed class FetchRssNode : IWorkflowNode
{
    /// <inheritdoc />
    public string NodeType => "FetchRss";

    private readonly IFeedService _feedService;
    private readonly ITagReplacementProvider _tagReplacementProvider;

    /// <summary>Initializes a new instance of the <see cref="FetchRssNode"/> class.</summary>
    public FetchRssNode(IFeedService feedService, ITagReplacementProvider tagReplacementProvider)
    {
        _feedService = feedService;
        _tagReplacementProvider = tagReplacementProvider;
    }

    /// <inheritdoc />
    public async Task<WorkflowNodeResult> ExecuteAsync(WorkflowNodeInput input, CancellationToken ct)
    {
        var urls = NodeParameterExtractor.GetParameter<List<string>>(input.Parameters, "Urls", []);
        if (urls.Count == 0)
        {
            return new WorkflowNodeResult(false, null, "No URLs provided for FetchRss node.");
        }

        var end = DateTimeOffset.UtcNow;
        var start = end.AddDays(-1);
        var keywords = _tagReplacementProvider.GetReplacements().Keys;

        var sb = new StringBuilder();
        foreach (var url in urls)
        {
            var feeds = await _feedService.GetFeedsAsync(url, start, end, keywords, ct);
            foreach (var feed in feeds)
            {
                sb.AppendLine($"{feed.Title}: {feed.Content}");
            }
        }

        var content = sb.ToString();
        if (string.IsNullOrWhiteSpace(content))
        {
            return new WorkflowNodeResult(false, null, "No RSS feed content retrieved in the last 24 hours.");
        }

        return new WorkflowNodeResult(true, content, null);
    }
}