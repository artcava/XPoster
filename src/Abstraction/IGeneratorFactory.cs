namespace XPoster.Abstraction;

/// <summary>
/// Creates the appropriate <see cref="BaseGenerator"/> instance for the current time slot
/// according to the configured posting schedule.
/// </summary>
public interface IGeneratorFactory
{
    /// <summary>
    /// Resolves and returns the generator that matches the current hour of the day.
    /// </summary>
    /// <returns>A fully initialised <see cref="BaseGenerator"/> ready to generate and send a post.</returns>
    BaseGenerator Generate();
}
