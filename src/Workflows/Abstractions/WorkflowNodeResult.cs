namespace XPoster.Workflows.Abstractions;

/// <summary>
/// Result returned by a workflow node after execution.
/// </summary>
/// <param name="Success">Whether the node completed successfully.</param>
/// <param name="Output">The output value to store in the context (if OutputKey is set on the node definition).</param>
/// <param name="ErrorMessage">Error description when <paramref name="Success"/> is <c>false</c>.</param>
public record WorkflowNodeResult(
    bool Success,
    object? Output,
    string? ErrorMessage);
