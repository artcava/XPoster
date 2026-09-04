namespace XPoster.Workflows.Abstractions;

/// <summary>
/// Marker interface applied to workflow nodes that act as the terminal node in a DAG.
/// A terminal node is responsible for writing <c>WorkflowContextKeys.SendResults</c>
/// into the workflow context, enabling the orchestrator bridge to dispatch posts.
/// Each workflow must contain exactly one terminal node.
/// </summary>
public interface ITerminalNode : IWorkflowNode
{
}