namespace XPoster.Abstraction;

/// <summary>
/// Creates the appropriate <see cref="BaseOrchestrator"/> instance for the current time slot
/// according to the configured posting schedule.
/// </summary>
public interface IOrchestratorFactory
{
    /// <summary>
    /// Resolves and returns the orchestrator that matches the current hour of the day.
    /// </summary>
    /// <returns>A fully initialised <see cref="BaseOrchestrator"/> ready to orchestrate and send a post.</returns>
    BaseOrchestrator Orchestrate();
}
