using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using XPoster.Contracts;
using XPoster.Workflows.Abstractions;
using XPoster.Workflows.Configuration;
using XPoster.Workflows.Engine;
using XPoster.Workflows.Nodes;
using XPoster.Workflows.Services;

namespace XPoster.Tests.Workflows.Configuration;

public class WorkflowServiceCollectionExtensionsTests
{
    private static IConfiguration MakeConfiguration()
    {
        return new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Workflows:Bitcoin:Nodes:0:Id"] = "fetch",
                ["Workflows:Bitcoin:Nodes:0:Type"] = "FetchRss",
                ["Workflows:Bitcoin:Nodes:0:Parameters:Urls"] = "http://feed.xml",
                ["Workflows:Bitcoin:Nodes:0:OutputKey"] = "source",
                ["Workflows:Bitcoin:Nodes:1:Id"] = "fanout",
                ["Workflows:Bitcoin:Nodes:1:Type"] = "FanOutSend",
                ["Workflows:Bitcoin:Nodes:1:NextNodeIds:0"] = "",
                ["Workflows:Other:Nodes:0:Id"] = "fetch",
                ["Workflows:Other:Nodes:0:Type"] = "FetchRss",
            })
            .Build();
    }

    private static IServiceProvider BuildProvider()
    {
        var configuration = MakeConfiguration();
        return new ServiceCollection()
            .AddLogging()
            .AddSingleton<IConfiguration>(configuration)
            .AddSingleton<IFeedService>(new Mock<IFeedService>().Object)
            .AddSingleton<ITagReplacementProvider>(new Mock<ITagReplacementProvider>().Object)
            .AddSingleton<ITagReplacementService>(new Mock<ITagReplacementService>().Object)
            .AddWorkflows(configuration)
            .BuildServiceProvider();
    }

    [Fact]
    public void AddWorkflows_Registers_StepOptionsResolver()
    {
        var provider = BuildProvider();
        Assert.IsType<ConfigurationStepOptionsResolver>(provider.GetRequiredService<IStepOptionsResolver>());
    }

    [Fact]
    public void AddWorkflows_Registers_WorkflowEngine()
    {
        var provider = BuildProvider();
        Assert.IsType<WorkflowExecutionEngine>(provider.GetRequiredService<IWorkflowEngine>());
    }

    [Theory]
    [InlineData("FetchRss", typeof(FetchRssNode))]
    [InlineData("AiText", typeof(AiTextNode))]
    [InlineData("AiImage", typeof(AiImageNode))]
    [InlineData("FanOutSend", typeof(FanOutSendNode))]
    public void AddWorkflows_Registers_KeyedNodes(string key, Type nodeType)
    {
        var provider = BuildProvider();
        var node = provider.GetRequiredKeyedService<IWorkflowNode>(key);
        Assert.IsType(nodeType, node);
    }

    [Fact]
    public void AddWorkflows_Registers_WorkflowDefinitions_AsKeyedSingletons()
    {
        var provider = BuildProvider();

        var bitcoin = provider.GetRequiredKeyedService<WorkflowDefinition>("Bitcoin");
        Assert.Equal("Bitcoin", bitcoin.SlotKey);
        Assert.Equal(2, bitcoin.Nodes.Count);
        Assert.Equal("FetchRss", bitcoin.Nodes[0].Type);
        Assert.Equal("fanout", bitcoin.Nodes[1].Id);

        var other = provider.GetRequiredKeyedService<WorkflowDefinition>("Other");
        Assert.Equal("Other", other.SlotKey);
        Assert.Single(other.Nodes);
    }

    [Fact]
    public void AddWorkflows_ConvertsParameters_ToObjectDictionary()
    {
        var provider = BuildProvider();
        var definition = provider.GetRequiredKeyedService<WorkflowDefinition>("Bitcoin");

        Assert.True(definition.Nodes[0].Parameters.TryGetValue("Urls", out var urls));
        Assert.Equal("http://feed.xml", urls);
    }
}