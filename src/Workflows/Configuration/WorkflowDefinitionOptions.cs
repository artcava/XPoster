using XPoster.Workflows.Engine;

namespace XPoster.Workflows.Configuration;

/// <summary>
/// Configuration-bound shape of a workflow slot's node DAG, used to produce an immutable
/// <see cref="WorkflowDefinition"/> at service-registration time.
/// </summary>
public sealed class WorkflowDefinitionOptions
{
    /// <summary>The nodes that make up the workflow DAG.</summary>
    public List<WorkflowNodeOptions> Nodes { get; set; } = new();

    /// <summary>
    /// Converts this bindable options object into an immutable <see cref="WorkflowDefinition"/>.
    /// </summary>
    /// <param name="slotKey">The named slot this workflow is bound to.</param>
    /// <returns>A <see cref="WorkflowDefinition"/> describing the same node DAG.</returns>
    public WorkflowDefinition ToDefinition(string slotKey)
    {
        var nodes = Nodes
            .Select(n => new WorkflowNodeDefinition(
                n.Id,
                n.Type,
                n.Parameters.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value!),
                n.OutputKey,
                n.NextNodeIds))
            .ToList();

        return new WorkflowDefinition(slotKey, nodes);
    }
}

/// <summary>
/// Configuration-bound shape of a single workflow node.
/// </summary>
public sealed class WorkflowNodeOptions
{
    /// <summary>Unique node identifier within the workflow.</summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>The node type key used to resolve the <c>IWorkflowNode</c> from DI.</summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>Node-specific parameters (provider names, input/output keys, step ids).</summary>
    public Dictionary<string, string?> Parameters { get; set; } = new();

    /// <summary>Context key under which the node's output is stored, or <c>null</c>.</summary>
    public string? OutputKey { get; set; }

    /// <summary>Identifiers of dependent (next) nodes in the DAG.</summary>
    public List<string> NextNodeIds { get; set; } = new();
}