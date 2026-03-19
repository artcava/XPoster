namespace XPoster.Abstraction;

/// <summary>
/// Abstracts the system clock to allow deterministic time injection in tests and production code.
/// </summary>
public interface ITimeProvider
{
    /// <summary>
    /// Returns the current local date and time.
    /// </summary>
    /// <returns>A <see cref="DateTime"/> representing the current moment.</returns>
    DateTime GetCurrentTime();
}
