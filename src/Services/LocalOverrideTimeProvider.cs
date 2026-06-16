using Microsoft.Extensions.Configuration;
using XPoster.Abstraction;

namespace XPoster.Services;

/// <summary>
/// Development-only <see cref="ITimeProvider"/> that returns a fixed UTC hour
/// read from the <c>ForceHour</c> app setting.
/// Allows targeting a specific orchestrator slot locally without touching
/// production code or the active schedule.
/// Falls back to <see cref="DateTime.UtcNow"/> when <c>ForceHour</c> is absent
/// or non-numeric.
/// </summary>
/// <remarks>
/// This implementation is registered in the DI container <b>only</b> when
/// <c>IHostEnvironment.IsDevelopment()</c> is <c>true</c> <b>and</b> the
/// <c>ForceHour</c> setting is present and non-empty.
/// No production code path can reach this class.
/// </remarks>
public sealed class LocalOverrideTimeProvider : ITimeProvider
{
    private readonly int _forcedHour;
    private readonly ILogger<LocalOverrideTimeProvider> _log;

    /// <summary>
    /// Initialises a new instance of <see cref="LocalOverrideTimeProvider"/>.
    /// </summary>
    /// <param name="config">Application configuration from which <c>ForceHour</c> is read.</param>
    /// <param name="log">Logger for the dev-override warning.</param>
    public LocalOverrideTimeProvider(IConfiguration config, ILogger<LocalOverrideTimeProvider> log)
    {
        _log = log;
        var raw = config["ForceHour"];
        _forcedHour = int.TryParse(raw, out var h) ? h : DateTime.UtcNow.Hour;
        _log.LogWarning(
            "[DEV OVERRIDE] LocalOverrideTimeProvider active — forcing slot hour to {Hour}. "
            + "Remove 'ForceHour' from local.settings.json to restore production behaviour.",
            _forcedHour);
    }

    /// <summary>
    /// Returns today's UTC date with the hour forced to <c>ForceHour</c>.
    /// Minutes, seconds and milliseconds are zeroed so the value aligns cleanly
    /// with the top-of-hour slot matching in <see cref="XPoster.Implementation.OrchestratorFactory"/>.
    /// </summary>
    /// <returns>A <see cref="DateTime"/> with <see cref="DateTimeKind.Utc"/> and the configured forced hour.</returns>
    public DateTime GetCurrentTime() =>
        DateTime.UtcNow.Date.AddHours(_forcedHour);
}
