using Microsoft.Extensions.DependencyInjection;
using XPoster.Abstraction;
using XPoster.Contracts;
using XPoster.SenderPlugins;

namespace XPoster.Orchestrators;

/// <summary>
/// Resolves and instantiates the correct <see cref="BaseOrchestrator"/> for the current hour of the day
/// by consulting the <see cref="ISlotProfileProvider"/> schedule.
/// Sender resolution is O(senders) via <see cref="SenderPlatform"/> switch.
/// Text and image capabilities are resolved independently via keyed DI, allowing a slot to mix
/// different providers for each capability (e.g. DeepSeek for text, FalAi for image).
/// </summary>
public class OrchestratorFactory : IOrchestratorFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<OrchestratorFactory> _log;
    private readonly ITimeProvider _timeProvider;
    private readonly ISlotProfileProvider _slotProfileProvider;

    /// <summary>
    /// Initialises a new instance of <see cref="OrchestratorFactory"/>.
    /// </summary>
    /// <param name="serviceProvider">DI service provider used to resolve senders and keyed capability providers.</param>
    /// <param name="log">Factory logger.</param>
    /// <param name="timeProvider">Time provider used to determine current hour slot.</param>
    /// <param name="slotProfileProvider">Provider that supplies the scheduled orchestration profiles.</param>
    public OrchestratorFactory(
        IServiceProvider serviceProvider,
        ILogger<OrchestratorFactory> log,
        ITimeProvider timeProvider,
        ISlotProfileProvider slotProfileProvider)
    {
        _serviceProvider = serviceProvider;
        _log = log;
        _timeProvider = timeProvider;
        _slotProfileProvider = slotProfileProvider;
    }

    /// <summary>
    /// Creates and returns the <see cref="BaseOrchestrator"/> mapped to the current hour.
    /// Falls back to <see cref="NoOrchestrator"/> when no entry exists for the current hour.
    /// Text and image capability providers are resolved independently:
    /// a null result for either interface means the capability is unavailable for this slot,
    /// and the orchestrator is expected to degrade gracefully.
    /// </summary>
    /// <returns>A fully initialised <see cref="BaseOrchestrator"/> instance.</returns>
    public BaseOrchestrator Resolve()
    {
        var currentHour = _timeProvider.GetCurrentTime().Hour;
        var profile = _slotProfileProvider.GetProfiles().FirstOrDefault(p => p.Hour == currentHour);

        if (profile == null)
        {
            _log.LogInformation("No slot profile for hour {Hour}, using NoOrchestrator", currentHour);
            return CreateOrchestratorInstance(typeof(NoOrchestrator), null, null, null);
        }

        _log.LogInformation(
            "Creating orchestrator {OrchestratorType} for platform {SenderPlatform} at hour {Hour} " +
            "with TextProvider={TextProvider} ImageProvider={ImageProvider}",
            profile.OrchestratorType.Name,
            profile.SenderPlatform,
            profile.Hour,
            profile.TextProvider?.ToString() ?? "none",
            profile.ImageProvider?.ToString() ?? "none");

        ISender? sender = profile.SenderPlatform switch
        {
            SenderPlatform.X         => _serviceProvider.GetService(typeof(XSender))      as ISender,
            SenderPlatform.LinkedIn  => _serviceProvider.GetService(typeof(InSender))     as ISender,
            SenderPlatform.Instagram => _serviceProvider.GetService(typeof(IgSender))     as ISender,
            SenderPlatform.DryRun    => _serviceProvider.GetService(typeof(DryRunSender)) as ISender,
            _ => null
        };

        // Text and image capabilities are resolved independently from their respective provider keys.
        // A null result is intentional: not every AiProvider implements both interfaces.
        // Misconfiguration surfaces explicitly inside the orchestrator at the point of use, not silently.
        ITextToTextProvider?  textProvider  = profile.TextProvider.HasValue
            ? _serviceProvider.GetKeyedService<ITextToTextProvider>(profile.TextProvider.Value)
            : null;

        ITextToImageProvider? imageProvider = profile.ImageProvider.HasValue
            ? _serviceProvider.GetKeyedService<ITextToImageProvider>(profile.ImageProvider.Value)
            : null;

        return CreateOrchestratorInstance(profile.OrchestratorType, sender, textProvider, imageProvider);
    }

    private BaseOrchestrator CreateOrchestratorInstance(
        Type orchestratorType,
        ISender? sender,
        ITextToTextProvider? textProvider,
        ITextToImageProvider? imageProvider)
    {
        var loggerType = typeof(ILogger<>).MakeGenericType(orchestratorType);
        var logger = _serviceProvider.GetRequiredService(loggerType);

        var ctor = orchestratorType.GetConstructors()
            .OrderByDescending(c => c.GetParameters().Length)
            .FirstOrDefault();
        var parameters = ctor?.GetParameters();

        var args = new List<object?>();
        if (parameters != null)
        {
            foreach (var param in parameters)
            {
                if (param.ParameterType == typeof(ISender))
                    args.Add(sender);
                else if (param.ParameterType == typeof(ITextToTextProvider))
                    args.Add(textProvider);
                else if (param.ParameterType == typeof(ITextToImageProvider))
                    args.Add(imageProvider);
                else if (param.ParameterType.IsGenericType && param.ParameterType.GetGenericTypeDefinition() == typeof(ILogger<>))
                    args.Add(logger);
                else
                    args.Add(_serviceProvider.GetService(param.ParameterType));
            }
        }
        return (BaseOrchestrator)Activator.CreateInstance(orchestratorType, args.ToArray())!;
    }
}
