namespace XPoster.Workflows.Models;

/// <summary>
/// Well-known context keys used by the workflow engine.
/// </summary>
public static class WorkflowContextKeys
{
    /// <summary>Key under which the final post dispatch map is stored after FanOutSend execution.</summary>
    public const string SendResults = "Workflow.SendResults";
}
