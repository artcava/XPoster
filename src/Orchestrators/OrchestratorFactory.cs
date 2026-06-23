using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XPoster.Abstraction;
using XPoster.Contracts;
using XPoster.SenderPlugins;

namespace XPoster.Orchestrators;

/// <summary>
/// Resolves and instantiates the correct <see cref="BaseOrchestrator"/> for the current hour of the day
/// by consulting the <see cref="ISlotProfileProvider"/> schedule, including AI provider orchestration.
/// Sender resolution is O(senders) via <see cref="SenderPlatform"/> switch — independent of orchestrator type.
/// </summary>
public class OrchestratorFactory : IOrchestratorFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<OrchestratorFactory> _log;
    private readonly ITimeProvider _timeProvider;
    private readonly ISlotProfileProvider _slotProfileProvider;
    private readonly IConfiguration? _configuration;

    /// <summary>
    /// Initialises a new instance of <see cref="OrchestratorFactory"/>.
    /// </summary>
    /// <param name="serviceProvider">DI service provider used to resolve senders and keyed capability providers.</param>
    /// <param name="log">Factory logger.</param>
    /// <param name="timeProvider">Time provider used to determine current hour slot.</param>
    /// <param name="slotProfileProvider">Provider that supplies the scheduled orchestration profiles.</param>
    /// <param name="configuration">Optional configuration used to override the AI provider via <c>AiProvider</c> setting.</param>
    public OrchestratorFactory(
        IServiceProvider serviceProvider,
        ILogger<OrchestratorFactory> log,
        ITimeProvider timeProvider,
        ISlotProfileProvider slotProfileProvider,
        IConfiguration? configuration = null)
    {
        _serviceProvider = serviceProvider;
        _log = log;
        _timeProvider = timeProvider;
        _slotProfileProvider = slotProfileProvider;
        _configuration = configuration;
    }

    /// <summary>
    /// Creates and returns the <see cref="BaseOrchestrator"/> mapped to the current hour, including AI provider orchestration.
    /// Falls back to <see cref="NoOrchestrator"/> when no entry exists for the current hour.
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

        _log.LogInformation("Creating orchestrator {OrchestratorType} for platform {SenderPlatform} at hour {Hour} with AI provider {AiProvider}",
            profile.OrchestratorType.Name, profile.SenderPlatform, profile.Hour, profile.AiProvider);

        ISender? sender = profile.SenderPlatform switch
        {
            SenderPlatform.X         => _serviceProvider.GetService(typeof(XSender))      as ISender,
            SenderPlatform.LinkedIn  => _serviceProvider.GetService(typeof(InSender))     as ISender,
            SenderPlatform.Instagram => _serviceProvider.GetService(typeof(IgSender))     as ISender,
            SenderPlatform.DryRun    => _serviceProvider.GetService(typeof(DryRunSender)) as ISender,
            _ => null
        };

        ITextToTextProvider? textProvider = null;
        ITextToImageProvider? imageProvider = null;

        if (profile.AiProvider.HasValue)
        {
            var effectiveProvider = ResolveAiProvider(profile.AiProvider.Value);
            // Both providers are optional capabilities: not every AiProvider implements both interfaces.
            // FeedOrchestrator accepts ITextToTextProvider? and ITextToImageProvider? — null is intentional.
            // Misconfiguration (e.g. using a text-only provider for image generation) surfaces explicitly
            // inside the orchestrator at the point of use, not silently.
            textProvider  = _serviceProvider.GetKeyedService<ITextToTextProvider>(effectiveProvider);
            imageProvider = _serviceProvider.GetKeyedService<ITextToImageProvider>(effectiveProvider);
        }

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

    private AiProvider ResolveAiProvider(AiProvider defaultProvider)
    {
        if (defaultProvider != AiProvider.None)
            return defaultProvider;

        var configuredProvider = _configuration?["AiProvider"];
        if (string.IsNullOrWhiteSpace(configuredProvider))
        {
            _log.LogWarning("No AiProvider specified in profile and no global fallback configured.");
            return defaultProvider;
        }

        if (Enum.TryParse<AiProvider>(configuredProvider, ignoreCase: true, out var parsedProvider))
            return parsedProvider;

        _log.LogWarning("Invalid AiProvider value '{AiProvider}' in configuration. No fallback available.",
            configuredProvider);

        return defaultProvider;
    }
}
