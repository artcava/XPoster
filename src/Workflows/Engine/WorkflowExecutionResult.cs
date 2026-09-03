using XPoster.Workflows.Models;

namespace XPoster.Workflows.Engine;

/// <summary>
/// The outcome of a workflow execution.
/// </summary>
/// <param name="Success"><c>true</c> when the entire DAG executed successfully.</param>
/// <param name="Context">The workflow context holding all execution state (readable after completion).</param>
/// <param name="ErrorMessage">Error description when <paramref name="Success"/> is <c>false</c>.</param>
public record WorkflowExecutionResult(
    bool Success,
    IWorkflowContext Context,
    string? ErrorMessage);