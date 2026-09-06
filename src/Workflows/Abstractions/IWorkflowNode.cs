namespace XPoster.Workflows.Abstractions;

/// <summary>
/// Represents a single node in a workflow DAG. Each node type acts as an adapter
/// bridging the workflow context to an underlying infrastructure service.
/// </summary>
public interface IWorkflowNode
{
    /// <summary>
    /// The unique type key used to resolve this node from DI (e.g., <c>"FetchRss"</c>, <c>"AiText"</c>).
    /// Must match the <c>Type</c> field in the workflow definition JSON.
    /// </summary>
    string NodeType { get; }

    /// <summary>
    /// Executes the node logic within the given input context.
    /// </summary>
    /// <param name="input">The node input containing context, parameters, and senders.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>A result indicating success/failure and an optional output value.</returns>
    Task<WorkflowNodeResult> ExecuteAsync(WorkflowNodeInput input, CancellationToken ct);
}
