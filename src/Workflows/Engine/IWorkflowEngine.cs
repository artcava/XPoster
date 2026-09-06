using XPoster.Contracts;

namespace XPoster.Workflows.Engine;

/// <summary>
/// Executes a workflow DAG, resolving each node via keyed DI.
/// </summary>
public interface IWorkflowEngine
{
    /// <summary>
    /// Executes the given workflow definition against the supplied senders.
    /// </summary>
    /// <param name="definition">The workflow DAG to execute.</param>
    /// <param name="senders">The resolved senders available to fan-out nodes.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>The execution result, including the populated context.</returns>
    Task<WorkflowExecutionResult> ExecuteAsync(
        WorkflowDefinition definition,
        IReadOnlyList<ISender> senders,
        CancellationToken ct);
}