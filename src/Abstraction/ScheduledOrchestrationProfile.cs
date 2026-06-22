using XPoster.Contracts;

namespace XPoster.Abstraction;

/// <summary>
/// Describes the full execution profile for a scheduled posting slot.
/// </summary>
public sealed class ScheduledOrchestrationProfile
{
    /// <summary>Hour of day (0-23) when this slot is active.</summary>
    public int Hour { get; init; }

    /// <summary>Target platform for this slot. Drives sender resolution in <see cref="XPoster.Orchestrators.OrchestratorFactory"/>.</summary>
    public SenderPlatform SenderPlatform { get; init; }

    /// <summary>Orchestrator type to instantiate for this slot.</summary>
    public Type OrchestratorType { get; init; }

    /// <summary>Optional AI provider used by this slot when the orchestrator requires it.</summary>
    public AiProvider? AiProvider { get; init; }

    /// <summary>
    /// Initialises a new instance of <see cref="ScheduledOrchestrationProfile"/>.
    /// </summary>
    /// <param name="hour">Hour of day (0-23) when this slot is active.</param>
    /// <param name="senderPlatform">Target platform for this slot.</param>
    /// <param name="orchestratorType">Orchestrator type to instantiate for this slot.</param>
    /// <param name="aiProvider">Optional AI provider for orchestrators that require AI services.</param>
    public ScheduledOrchestrationProfile(int hour, SenderPlatform senderPlatform, Type orchestratorType, AiProvider? aiProvider = null)
    {
        Hour = hour;
        SenderPlatform = senderPlatform;
        OrchestratorType = orchestratorType;
        AiProvider = aiProvider;
    }
}
