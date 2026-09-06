using XPoster.Contracts;

namespace XPoster.Models;

/// <summary>
/// Describes the full execution profile for a scheduled posting slot.
/// </summary>
public sealed class ScheduledOrchestrationProfile
{
    /// <summary>Orchestrator context key for this slot.</summary>
    public string? OrchestratorContextKey { get; init; }

    /// <summary>Hour of day (0-23) when this slot is active.</summary>
    public int Hour { get; init; }

    /// <summary>
    /// Ordered list of target platforms for this slot, by descending MessageMaxLength.
    /// The first platform's sender MaxLength drives the base summary generation.
    /// Subsequent senders receive AI re-summarisation only when rawBaseSummary exceeds their limit.
    /// </summary>
    public IReadOnlyList<SenderPlatform> SenderPlatforms { get; init; }

    /// <summary>Orchestrator type to instantiate for this slot.</summary>
    public Type OrchestratorType { get; init; }

    /// <summary>
    /// Initialises a new instance of <see cref="ScheduledOrchestrationProfile"/> with an ordered
    /// list of target platforms and independent text and image provider selections.
    /// </summary>
    /// <param name="orchestratorContextKey"></param>
    /// <param name="hour">Hour of day (0-23) when this slot is active.</param>
    /// <param name="senderPlatforms">
    /// Ordered list of target platforms for this slot, by descending MessageMaxLength.
    /// The first entry drives base summary generation. Must contain at least one platform.
    /// </param>
    /// <param name="orchestratorType">Orchestrator type to instantiate for this slot.</param>
    public ScheduledOrchestrationProfile(
        string? orchestratorContextKey,
        int hour,
        IReadOnlyList<SenderPlatform> senderPlatforms,
        Type orchestratorType)
    {
        OrchestratorContextKey = orchestratorContextKey;
        Hour = hour;
        SenderPlatforms = senderPlatforms;
        OrchestratorType = orchestratorType;
    }
}
