using XPoster.Contracts;

namespace XPoster.Services;

/// <summary>
/// Concrete implementation of <see cref="ITimeProvider"/> that delegates to the system clock.
/// Returns UTC time so that slot matching in <see cref="XPoster.Orchestrator.OrchestratorFactory"/>
/// is deterministic regardless of host timezone or <c>WEBSITE_TIME_ZONE</c> configuration.
/// </summary>
public class TimeProvider : ITimeProvider
{
    /// <summary>
    /// Returns the current UTC date and time from the system clock.
    /// </summary>
    /// <returns>A <see cref="DateTime"/> with <see cref="DateTimeKind.Utc"/> representing the current moment.</returns>
    public DateTime GetCurrentTime() => DateTime.UtcNow;
}
