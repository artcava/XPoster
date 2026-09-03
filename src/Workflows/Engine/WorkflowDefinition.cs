namespace XPoster.Workflows.Engine;

/// <summary>
/// Describes a workflow: a slot-scoped DAG of nodes.
/// </summary>
/// <param name="SlotKey">The named slot this workflow is bound to.</param>
/// <param name="Nodes">The nodes that make up the workflow DAG.</param>
public record WorkflowDefinition(
    string SlotKey,
    List<WorkflowNodeDefinition> Nodes);