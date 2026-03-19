using Microsoft.Azure.Functions.Worker;
using XPoster.Abstraction;

namespace XPoster;

/// <summary>
/// Azure Function entry point for XPoster. Triggered on a cron schedule defined by the
/// <c>CronSchedule</c> app setting; selects the appropriate generator for the current hour
/// and publishes a post to the configured social-media platform.
/// </summary>
public class XFunction
{
    private readonly IGeneratorFactory _generatorFactory;
    private readonly ILogger<XFunction> _log;

    /// <summary>
    /// Initialises a new instance of <see cref="XFunction"/>.
    /// </summary>
    /// <param name="generatorFactory">The factory that resolves the correct generator for the current time slot.</param>
    /// <param name="log">The logger for function-level diagnostic output.</param>
    public XFunction(IGeneratorFactory generatorFactory, ILogger<XFunction> log)
    {
        _generatorFactory = generatorFactory;
        _log = log;
    }

    /// <summary>
    /// Timer-triggered function body. Resolves the generator, produces a post, and sends it.
    /// Exceptions are re-thrown to surface failures in Azure Monitor.
    /// </summary>
    /// <param name="myTimer">Timer metadata injected by the Azure Functions runtime.</param>
    [Function("XPosterFunction")]
    public async Task Run([TimerTrigger("%CronSchedule%")] TimerInfo myTimer)
    {
        _log.LogInformation("XPoster Function started at: {0}", DateTimeOffset.UtcNow);

        try
        {
            var generator = _generatorFactory.Generate();

            if (!generator.SendIt) { _log.LogInformation("Generator {0} is disabled", generator.Name); return; }

            var post = await generator.GenerateAsync();

            if (post == null) { _log.LogError($"Failed to generate message with {generator.Name}"); return; }

            var result = await generator.PostAsync(post);
            if (!result)
            {
                _log.LogError($"Failed to send Message with {generator.Name}");
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
