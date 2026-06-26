using Microsoft.Azure.Functions.Worker;
using XPoster.Contracts;

namespace XPoster;

/// <summary>
/// Azure Function entry point for XPoster. Triggered on a cron schedule defined by the
/// <c>CronSchedule</c> app setting; selects the appropriate orchestrator for the current hour
/// and publishes posts to all configured social-media platforms.
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
    /// Timer-triggered function body. Resolves the orchestrator, produces a list of posts (one per sender),
    /// and dispatches each post to its aligned sender in parallel.
    /// Exceptions are re-thrown to surface failures in Azure Monitor.
    /// </summary>
    /// <param name="myTimer">Timer metadata injected by the Azure Functions runtime.</param>
    /// <param name="cancellationToken">Cancellation token to signal function cancellation.</param>
    [Function("XPosterFunction")]
    public async Task Run([TimerTrigger("%CronSchedule%")] TimerInfo myTimer, CancellationToken cancellationToken)
    {
        _log.LogInformation("XPoster Function started at: {Time}", DateTimeOffset.UtcNow);

        try
        {
            var orchestrator = _orchestratorFactory.Resolve();

            if (!orchestrator.SendIt)
            {
                _log.LogInformation("Orchestrator {Name} is disabled", orchestrator.Name);
                return;
            }

            var posts = await orchestrator.OrchestrateAsync(cancellationToken);

            if (posts == null || posts.Count == 0)
            {
                _log.LogError("Failed to orchestrate messages with {Name}", orchestrator.Name);
                return;
            }

            var result = await orchestrator.PostAsync(posts);
            if (!result)
            {
                _log.LogError("One or more senders failed with {Name}", orchestrator.Name);
            }
        }
        catch (Exception ex)
        {
            _log.LogError(ex, "XPoster Function causes an error: {Message}", ex.Message);
            throw;
        }

        _log.LogInformation("XPoster Function ended at: {Time}", DateTimeOffset.UtcNow);
    }
}
