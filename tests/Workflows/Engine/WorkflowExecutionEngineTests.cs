using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using XPoster.Contracts;
using XPoster.Workflows.Abstractions;
using XPoster.Workflows.Engine;
using XPoster.Workflows.Models;

namespace XPoster.Tests.Workflows.Engine;

public class WorkflowExecutionEngineTests
{
    private sealed class StubNode : ITerminalNode
    {
        public string NodeType { get; }
        public Func<IWorkflowContext, WorkflowNodeResult> Logic { get; }
        private readonly Action<string> _onExecute;

        public StubNode(string nodeType, Action<string> onExecute, Func<IWorkflowContext, WorkflowNodeResult>? logic = null)
        {
            NodeType = nodeType;
            _onExecute = onExecute;
            Logic = logic ?? (_ => new WorkflowNodeResult(true, null, null));
        }

        public Task<WorkflowNodeResult> ExecuteAsync(WorkflowNodeInput input, CancellationToken ct)
        {
            _onExecute(NodeType);
            var result = Logic(input.Context);
            ct.ThrowIfCancellationRequested();
            return Task.FromResult(result);
        }
    }

    private static (WorkflowExecutionEngine engine, List<string> executionOrder) CreateEngine(
        Dictionary<string, Func<IWorkflowContext, WorkflowNodeResult>> nodeLogics,
        List<string>? executionOrder = null)
    {
        var order = executionOrder ?? new List<string>();
        var services = new ServiceCollection();

        foreach (var (type, logic) in nodeLogics)
        {
            var capturedType = type;
            var capturedLogic = logic;
            services.AddKeyedTransient<IWorkflowNode>(capturedType, (_, _) =>
                new StubNode(capturedType, t => { lock (order) order.Add(t); }, capturedLogic));
        }

        var provider = services.BuildServiceProvider();
        var engine = new WorkflowExecutionEngine(provider, new NullLogger<WorkflowExecutionEngine>());
        return (engine, order);
    }

    private static WorkflowDefinition LinearChain()
        => new("Linear", new List<WorkflowNodeDefinition>
        {
            new("A", "nodeA", new(), OutputKey: "a", NextNodeIds: new() { "B" }),
            new("B", "nodeB", new(), OutputKey: "b", NextNodeIds: new() { "C" }),
            new("C", "nodeC", new(), OutputKey: "c", NextNodeIds: new()),
        });

    private static WorkflowDefinition Diamond()
        => new("Diamond", new List<WorkflowNodeDefinition>
        {
            new("A", "nodeA", new(), OutputKey: "a", NextNodeIds: new() { "B", "C" }),
            new("B", "nodeB", new(), OutputKey: "b", NextNodeIds: new() { "D" }),
            new("C", "nodeC", new(), OutputKey: "c", NextNodeIds: new() { "D" }),
            new("D", "nodeD", new(), OutputKey: "d", NextNodeIds: new()),
        });

    private static WorkflowDefinition Cyclic()
        => new("Cycle", new List<WorkflowNodeDefinition>
        {
            new("A", "nodeA", new(), OutputKey: null, NextNodeIds: new() { "B" }),
            new("B", "nodeB", new(), OutputKey: null, NextNodeIds: new() { "A" }),
        });

    private static WorkflowDefinition MissingRef()
        => new("Missing", new List<WorkflowNodeDefinition>
        {
            new("A", "nodeA", new(), OutputKey: null, NextNodeIds: new() { "Nope" }),
        });

    private static IReadOnlyList<ISender> EmptySenders() => Array.Empty<ISender>();

    [Fact]
    public async Task Execute_LinearChain_ExecutesInOrder_AndStoresOutputs()
    {
        var (engine, order) = CreateEngine(new()
        {
            ["nodeA"] = ctx => new(true, "va", null),
            ["nodeB"] = ctx => new(true, "vb", null),
            ["nodeC"] = ctx => new(true, "vc", null),
        });

        var result = await engine.ExecuteAsync(LinearChain(), EmptySenders(), CancellationToken.None);

        Assert.True(result.Success);
        Assert.Equal(new[] { "nodeA", "nodeB", "nodeC" }, order);
        Assert.Equal("va", result.Context.GetData<string>("a"));
        Assert.Equal("vb", result.Context.GetData<string>("b"));
        Assert.Equal("vc", result.Context.GetData<string>("c"));
    }

    [Fact]
    public async Task Execute_Diamond_ExecutesAllNodes_AndResolvesDependencies()
    {
        var (engine, order) = CreateEngine(new()
        {
            ["nodeA"] = ctx => new(true, "va", null),
            ["nodeB"] = ctx => new(true, "vb", null),
            ["nodeC"] = ctx => new(true, "vc", null),
            ["nodeD"] = ctx => new(true, "vd", null),
        });

        var result = await engine.ExecuteAsync(Diamond(), EmptySenders(), CancellationToken.None);

        Assert.True(result.Success);
        Assert.Equal(4, order.Count);
        Assert.Equal("nodeA", order[0]);
        // B and C both run before D
        Assert.Contains("nodeD", order);
        Assert.True(order.IndexOf("nodeB") < order.IndexOf("nodeD"));
        Assert.True(order.IndexOf("nodeC") < order.IndexOf("nodeD"));
    }

    [Fact]
    public async Task Execute_Cycle_ReturnsFailure_WithDescriptiveError()
    {
        var (engine, _) = CreateEngine(new());
        var result = await engine.ExecuteAsync(Cyclic(), EmptySenders(), CancellationToken.None);

        Assert.False(result.Success);
        Assert.Contains("Cycle", result.ErrorMessage);
    }

    [Fact]
    public async Task Execute_MissingRef_ReturnsFailure_WithDescriptiveError()
    {
        var (engine, _) = CreateEngine(new());
        var result = await engine.ExecuteAsync(MissingRef(), EmptySenders(), CancellationToken.None);

        Assert.False(result.Success);
        Assert.Contains("non-existent", result.ErrorMessage);
        Assert.Contains("Nope", result.ErrorMessage);
    }

    [Fact]
    public async Task Execute_UnregisteredNodeType_ReturnsFailure()
    {
        var (engine, _) = CreateEngine(new());
        var def = new WorkflowDefinition("MissingType", new List<WorkflowNodeDefinition>
        {
            new("X", "NoSuchNode", new(), OutputKey: null, NextNodeIds: new()),
        });

        var result = await engine.ExecuteAsync(def, EmptySenders(), CancellationToken.None);

        Assert.False(result.Success);
        Assert.Contains("NoSuchNode", result.ErrorMessage);
        Assert.Contains("registered", result.ErrorMessage);
    }

    [Fact]
    public async Task Execute_NodeFailure_StopsExecution_AndReturnsError()
    {
        var (engine, order) = CreateEngine(new()
        {
            ["nodeA"] = ctx => new(true, "va", null),
            ["nodeB"] = ctx => new(false, null, "boom"),
            ["nodeC"] = ctx => new(true, "vc", null),
        });

        var result = await engine.ExecuteAsync(LinearChain(), EmptySenders(), CancellationToken.None);

        Assert.False(result.Success);
        Assert.Equal("boom", result.ErrorMessage);
        Assert.Equal(2, order.Count); // C never ran
        Assert.DoesNotContain("nodeC", order);
    }

    [Fact]
    public async Task Execute_EmptyNodesDefinition_Succeeds()
    {
        var (engine, _) = CreateEngine(new());
        var def = new WorkflowDefinition("Empty", new List<WorkflowNodeDefinition>());

        var result = await engine.ExecuteAsync(def, EmptySenders(), CancellationToken.None);

        Assert.True(result.Success);
    }
}