namespace XPoster.Models;

/// <summary>
/// Configuration-bound shape of a single scheduled orchestration slot.
/// Bound from the flat <c>Schedule__N__*</c> configuration section so the
/// schedule can be replicated easily across Azure Environment settings.
/// </summary>
public sealed class SlotScheduleOptions
{
    /// <summary>Workflow key (maps to <c>WorkflowDefinition</c> / <see cref="ScheduledOrchestrationProfile.OrchestratorContextKey"/>).</summary>
    public string? Workflow { get; init; }

    /// <summary>Hour of day (0-23) when this slot is active.</summary>
    public int Hour { get; init; }

    /// <summary>Target sender platforms, by name (e.g. <c>"LinkedIn"</c>, <c>"X"</c>).</summary>
    public List<string> Senders { get; init; } = new();
}
