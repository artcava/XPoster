using Microsoft.Azure.Functions.Worker;
using XPoster.Abstraction;

namespace XPoster;

/// <summary>
/// Azure Function entry point for XPoster. Triggered on a cron schedule defined by the
/// <c>CronSchedule</c> app setting; selects the appropriate orchestrator for the current hour
/// and publishes a post to the configured social-media platform.
/// </summary>
public class XFunction
{
    private readonly IOrchestratorFactory _orchestratorFactory;
    private readonly ILogger<XFunction> _log;

    /// <summary>
    /// Initialises a new instance of <see cref="XFunction"/>.
    /// </summary>
    /// <param name="orchestratorFactory">The factory that resolves the correct orchestrator for the current time slot.</param>
    /// <param name="log">The logger for function-level diagnostic output.</param>
    public XFunction(IOrchestratorFactory orchestratorFactory, ILogger<XFunction> log)
    {
        _orchestratorFactory = orchestratorFactory;
        _log = log;
    }

    /// <summary>
    /// Timer-triggered function body. Resolves the orchestrator, produces a post, and sends it.
    /// Exceptions are re-thrown to surface failures in Azure Monitor.
    /// </summary>
    /// <param name="myTimer">Timer metadata injected by the Azure Functions runtime.</param>
    [Function("XPosterFunction")]
    public async Task Run([TimerTrigger("%CronSchedule%")] TimerInfo myTimer)
    {
        _log.LogInformation("XPoster Function started at: {0}", DateTimeOffset.UtcNow);

        try
        {
            var orchestrator = _orchestratorFactory.Orchestrate();

            if (!orchestrator.SendIt) { _log.LogInformation("Orchestrator {0} is disabled", orchestrator.Name); return; }

            var post = await orchestrator.OrchestrateAsync();

            // CS8602: post can be null — guard before use
            if (post == null) { _log.LogError($"Failed to orchestrate message with {orchestrator.Name}"); return; }

            var result = await orchestrator.PostAsync(post);
            if (!result)
            {
                _log.LogError($"Failed to send message with {orchestrator.Name}");
            }
        }
        catch (Exception ex)
        {
            _log.LogError(ex, "XPoster Function causes an error: {0}", ex.Message);
            throw;
        }

        _log.LogInformation($"XPoster Function ended at: {DateTimeOffset.UtcNow}");
    }
}
