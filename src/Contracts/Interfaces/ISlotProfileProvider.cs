using XPoster.Models;

namespace XPoster.Contracts;

/// <summary>
/// Provides the ordered list of <see cref="ScheduledOrchestrationProfile"/> entries
/// that <see cref="XPoster.Orchestrators.OrchestratorFactory"/> uses to resolve the
/// correct orchestrator for the current time slot.
/// </summary>
/// <remarks>
/// Decouples the schedule configuration from the factory resolution logic,
/// allowing tests to inject arbitrary profiles without relying on the production schedule.
/// </remarks>
public interface ISlotProfileProvider
{
    /// <summary>Returns the list of scheduled orchestration profiles.</summary>
    IReadOnlyList<ScheduledOrchestrationProfile> GetProfiles();
}
