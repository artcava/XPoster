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
                ["Workflows:Bitcoin:Nodes:0:NextNodeIds:0"] = "fanout",
                ["Workflows:Bitcoin:Nodes:1:Id"] = "fanout",
                ["Workflows:Bitcoin:Nodes:1:Type"] = "FanOutSend",
                ["Workflows:Other:Nodes:0:Id"] = "fetch",
                ["Workflows:Other:Nodes:0:Type"] = "FetchRss",
                ["Workflows:Other:Nodes:0:NextNodeIds:0"] = "fanout",
                ["Workflows:Other:Nodes:1:Id"] = "fanout",
                ["Workflows:Other:Nodes:1:Type"] = "FanOutSend",
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
        Assert.Equal(2, other.Nodes.Count);
    }

    [Fact]
    public void AddWorkflows_ConvertsParameters_ToObjectDictionary()
    {
        var provider = BuildProvider();
        var definition = provider.GetRequiredKeyedService<WorkflowDefinition>("Bitcoin");

        Assert.True(definition.Nodes[0].Parameters.TryGetValue("Urls", out var urls));
        Assert.Equal("http://feed.xml", urls);
    }

    // ---------------------------------------------------------------------------
    // Fail-fast validation (defense A)
    // ---------------------------------------------------------------------------

    [Fact]
    public void AddWorkflows_WithNoTerminalNode_ThrowsInvalidOperationException()
    {
        var configuration = InMemory(new Dictionary<string, string?>
        {
            ["Workflows:Slot:Nodes:0:Id"] = "a",
            ["Workflows:Slot:Nodes:0:Type"] = "FetchRss",
            ["Workflows:Slot:Nodes:1:Id"] = "b",
            ["Workflows:Slot:Nodes:1:Type"] = "AiText",
            ["Workflows:Slot:Nodes:1:NextNodeIds:0"] = "b",
        });

        var services = new ServiceCollection().AddLogging();
        var ex = Assert.Throws<InvalidOperationException>(() => services.AddWorkflows(configuration));
        Assert.Contains("Cycle", ex.Message);
    }

    [Fact]
    public void AddWorkflows_WithMultipleTerminalNodes_ThrowsInvalidOperationException()
    {
        var configuration = InMemory(new Dictionary<string, string?>
        {
            ["Workflows:Slot:Nodes:0:Id"] = "a",
            ["Workflows:Slot:Nodes:0:Type"] = "AiText",
            ["Workflows:Slot:Nodes:1:Id"] = "b",
            ["Workflows:Slot:Nodes:1:Type"] = "AiText",
        });

        var services = new ServiceCollection().AddLogging();
        var ex = Assert.Throws<InvalidOperationException>(() => services.AddWorkflows(configuration));
        Assert.Contains("terminal", ex.Message);
    }

    [Fact]
    public void AddWorkflows_WithValidWorkflow_DoesNotThrow()
    {
        var configuration = InMemory(new Dictionary<string, string?>
        {
            ["Workflows:Slot:Nodes:0:Id"] = "a",
            ["Workflows:Slot:Nodes:0:Type"] = "FetchRss",
            ["Workflows:Slot:Nodes:0:NextNodeIds:0"] = "fanout",
            ["Workflows:Slot:Nodes:1:Id"] = "fanout",
            ["Workflows:Slot:Nodes:1:Type"] = "FanOutSend",
        });

        var services = new ServiceCollection().AddLogging();
        var exception = Record.Exception(() => services.AddWorkflows(configuration));
        Assert.Null(exception);
    }

    private static IConfiguration InMemory(Dictionary<string, string?> data) =>
        new ConfigurationBuilder().AddInMemoryCollection(data).Build();
}