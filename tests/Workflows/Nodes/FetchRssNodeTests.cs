using Moq;
using XPoster.Contracts;
using XPoster.Models;
using XPoster.Workflows.Abstractions;
using XPoster.Workflows.Models;
using XPoster.Workflows.Nodes;

namespace XPoster.Tests.Workflows.Nodes;

public class FetchRssNodeTests
{
    private static (FetchRssNode node, Mock<IFeedService> feedMock, Mock<ITagReplacementProvider> tagMock) CreateNode()
    {
        var feedMock = new Mock<IFeedService>();
        var tagMock = new Mock<ITagReplacementProvider>();
        tagMock.Setup(t => t.GetReplacements()).Returns(new Dictionary<string, string> { { "bitcoin", "#Bitcoin" } });
        return (new FetchRssNode(feedMock.Object, tagMock.Object), feedMock, tagMock);
    }

    private static WorkflowNodeInput Input(params (string key, object value)[] kvps)
    {
        var ctx = new WorkflowContext { SlotKey = "Test" };
        foreach (var (key, value) in kvps)
            ctx.SetData(key, value);
        var parameters = kvps.ToDictionary(kv => kv.key, kv => kv.value);
        return new WorkflowNodeInput(ctx, parameters, Array.Empty<ISender>());
    }

    [Fact]
    public async Task Execute_ReturnsFailure_WhenNoUrlsProvided()
    {
        var (node, _, _) = CreateNode();
        var input = Input();
        var result = await node.ExecuteAsync(input, CancellationToken.None);
        Assert.False(result.Success);
        Assert.Contains("No URLs", result.ErrorMessage);
    }

    [Fact]
    public async Task Execute_ConcatenatesMultipleFeeds()
    {
        var (node, feedMock, _) = CreateNode();
        feedMock.Setup(f => f.GetFeedsAsync(
            It.IsAny<string>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<IEnumerable<string>>(),
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(new[]
            {
                new RSSFeed { Title = "T1", Content = "C1", Link = "http://1" },
                new RSSFeed { Title = "T2", Content = "C2", Link = "http://2" },
            });

        var input = Input(("Urls", new List<string> { "http://feed1.xml" }));
        var result = await node.ExecuteAsync(input, CancellationToken.None);

        Assert.True(result.Success);
        var text = Assert.IsType<string>(result.Output);
        Assert.Contains("T1: C1", text);
        Assert.Contains("T2: C2", text);
    }

    [Fact]
    public async Task Execute_ReturnsFailure_WhenNoContentRetrieved()
    {
        var (node, feedMock, _) = CreateNode();
        feedMock.Setup(f => f.GetFeedsAsync(
            It.IsAny<string>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<IEnumerable<string>>(),
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(Array.Empty<RSSFeed>());

        var input = Input(("Urls", new List<string> { "http://feed1.xml" }));
        var result = await node.ExecuteAsync(input, CancellationToken.None);

        Assert.False(result.Success);
        Assert.Contains("No RSS feed content", result.ErrorMessage);
    }

    [Fact]
    public async Task Execute_CallsFeedServiceForMultipleUrls()
    {
        var (node, feedMock, _) = CreateNode();
        feedMock.Setup(f => f.GetFeedsAsync(
            It.IsAny<string>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<IEnumerable<string>>(),
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(Array.Empty<RSSFeed>());

        var input = Input(("Urls", new List<string> { "http://a.xml", "http://b.xml" }));
        await node.ExecuteAsync(input, CancellationToken.None);

        feedMock.Verify(f => f.GetFeedsAsync(
            "http://a.xml",
            It.IsAny<DateTimeOffset>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<IEnumerable<string>>(),
            It.IsAny<CancellationToken>()), Times.Once);

        feedMock.Verify(f => f.GetFeedsAsync(
            "http://b.xml",
            It.IsAny<DateTimeOffset>(),
            It.IsAny<DateTimeOffset>(),
            It.IsAny<IEnumerable<string>>(),
            It.IsAny<CancellationToken>()), Times.Once);
    }
}