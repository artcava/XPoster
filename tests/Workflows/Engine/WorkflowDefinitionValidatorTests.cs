using Microsoft.Extensions.DependencyInjection;
using XPoster.Workflows.Abstractions;
using XPoster.Workflows.Engine;

namespace XPoster.Tests.Workflows.Engine;

public class WorkflowDefinitionValidatorTests
{
    private static WorkflowNodeDefinition Node(string id, params string[] next) =>
        new(id, "Type" + id, new(), OutputKey: null, NextNodeIds: new List<string>(next));

    private static WorkflowDefinition Linear() =>
        new("Linear", new List<WorkflowNodeDefinition>
        {
            Node("A", "B"),
            Node("B", "C"),
            Node("C"),
        });

    private static WorkflowDefinition TwoTerminals() =>
        new("TwoTerminals", new List<WorkflowNodeDefinition>
        {
            Node("A"),
            Node("B"),
        });

    private static WorkflowDefinition MissingRef() =>
        new("Missing", new List<WorkflowNodeDefinition>
        {
            Node("A", "Nope"),
        });

    private static WorkflowDefinition Cyclic() =>
        new("Cycle", new List<WorkflowNodeDefinition>
        {
            Node("A", "B"),
            Node("B", "A"),
        });

    // ---------------------------------------------------------------------------
    // ValidateStructural
    // ---------------------------------------------------------------------------

    [Fact]
    public void ValidateStructural_ValidLinearDag_ReturnsNull()
    {
        Assert.Null(WorkflowDefinitionValidator.ValidateStructural(Linear()));
    }

    [Fact]
    public void ValidateStructural_MultipleTerminalNodes_ReturnsError()
    {
        var error = WorkflowDefinitionValidator.ValidateStructural(TwoTerminals());
        Assert.NotNull(error);
        Assert.Contains("2 terminal nodes", error);
    }

    [Fact]
    public void ValidateStructural_Cycle_ReturnsError()
    {
        var error = WorkflowDefinitionValidator.ValidateStructural(Cyclic());
        Assert.NotNull(error);
        Assert.Contains("Cycle", error);
    }

    [Fact]
    public void ValidateStructural_MissingNodeReference_ReturnsError()
    {
        var error = WorkflowDefinitionValidator.ValidateStructural(MissingRef());
        Assert.NotNull(error);
        Assert.Contains("Nope", error);
    }

    [Fact]
    public void ValidateStructural_EmptyNodes_ReturnsNull()
    {
        Assert.Null(WorkflowDefinitionValidator.ValidateStructural(
            new WorkflowDefinition("Empty", new List<WorkflowNodeDefinition>())));
    }

    // ---------------------------------------------------------------------------
    // ValidateTerminalNodeContract
    // ---------------------------------------------------------------------------

    [Fact]
    public void ValidateTerminalNodeContract_TerminalImplementsContract_ReturnsNull()
    {
        var services = new ServiceCollection();
        services.AddKeyedTransient<IWorkflowNode>("TerminalType", (_, _) => new TerminalStub());
        var provider = services.BuildServiceProvider();

        var def = new WorkflowDefinition("Ok", new List<WorkflowNodeDefinition>
        {
            new("T", "TerminalType", new(), null, new List<string>()),
        });

        Assert.Null(WorkflowDefinitionValidator.ValidateTerminalNodeContract(def, provider));
    }

    [Fact]
    public void ValidateTerminalNodeContract_TerminalDoesNotImplementContract_ReturnsError()
    {
        var services = new ServiceCollection();
        services.AddKeyedTransient<IWorkflowNode>("PlainType", (_, _) => new PlainStub());
        var provider = services.BuildServiceProvider();

        var def = new WorkflowDefinition("Bad", new List<WorkflowNodeDefinition>
        {
            new("T", "PlainType", new(), null, new List<string>()),
        });

        var error = WorkflowDefinitionValidator.ValidateTerminalNodeContract(def, provider);
        Assert.NotNull(error);
        Assert.Contains("ITerminalNode", error);
    }

    [Fact]
    public void ValidateTerminalNodeContract_UnresolvableTerminalType_ReturnsNull()
    {
        var provider = new ServiceCollection().BuildServiceProvider();
        var def = new WorkflowDefinition("Unknown", new List<WorkflowNodeDefinition>
        {
            new("T", "NoSuchType", new(), null, new List<string>()),
        });

        Assert.Null(WorkflowDefinitionValidator.ValidateTerminalNodeContract(def, provider));
    }

    private sealed class TerminalStub : ITerminalNode
    {
        public string NodeType => "TerminalType";
        public Task<WorkflowNodeResult> ExecuteAsync(WorkflowNodeInput input, CancellationToken ct)
            => Task.FromResult(new WorkflowNodeResult(true, null, null));
    }

    private sealed class PlainStub : IWorkflowNode
    {
        public string NodeType => "PlainType";
        public Task<WorkflowNodeResult> ExecuteAsync(WorkflowNodeInput input, CancellationToken ct)
            => Task.FromResult(new WorkflowNodeResult(true, null, null));
    }
}