using XPoster.Abstraction;

namespace XPoster.Services;

/// <summary>
/// Concrete implementation of <see cref="ITimeProvider"/> that delegates to the system clock.
/// </summary>
public class TimeProvider : ITimeProvider
{
    /// <summary>
    /// Returns the current local date and time from the system clock.
    /// </summary>
    /// <returns>A <see cref="DateTime"/> representing the current moment.</returns>
    public DateTime GetCurrentTime() => DateTime.Now;
}
