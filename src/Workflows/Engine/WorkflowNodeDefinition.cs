namespace XPoster.Workflows.Engine;

/// <summary>
/// Describes a single node within a workflow definition.
/// </summary>
/// <param name="Id">Unique node identifier within the workflow.</param>
/// <param name="Type">The node type key used to resolve the <c>IWorkflowNode</c> from DI.</param>
/// <param name="Parameters">Node-specific parameters (provider names, input/output keys, step ids).</param>
/// <param name="OutputKey">Context key under which the node's output is stored, or <c>null</c>.</param>
/// <param name="NextNodeIds">Identifiers of dependent (next) nodes in the DAG.</param>
public record WorkflowNodeDefinition(
    string Id,
    string Type,
    Dictionary<string, object> Parameters,
    string? OutputKey,
    List<string> NextNodeIds);