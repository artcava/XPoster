using XPoster.Contracts;
using XPoster.Workflows.Models;

namespace XPoster.Workflows.Abstractions;

/// <summary>
/// Input passed to every workflow node during DAG execution.
/// </summary>
/// <param name="Context">The shared, thread-safe workflow context for reading/writing state.</param>
/// <param name="Parameters">Node-specific parameters deserialized from the workflow definition.</param>
/// <param name="Senders">The resolved senders available for this workflow execution.</param>
public record WorkflowNodeInput(
    IWorkflowContext Context,
    IReadOnlyDictionary<string, object> Parameters,
    IReadOnlyList<ISender> Senders);
