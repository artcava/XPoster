namespace XPoster.Abstraction;

/// <summary>
/// Abstracts the system clock to allow deterministic time injection in tests and production code.
/// Implementations must return UTC time so that orchestrator slot matching is timezone-agnostic.
/// </summary>
public interface ITimeProvider
{
    /// <summary>
    /// Returns the current UTC date and time.
    /// </summary>
    /// <returns>A <see cref="DateTime"/> with <see cref="DateTimeKind.Utc"/> representing the current moment.</returns>
    DateTime GetCurrentTime();
}
