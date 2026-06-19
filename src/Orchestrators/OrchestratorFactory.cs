using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XPoster.Abstraction;
using XPoster.Contracts;
using XPoster.SenderPlugins;

namespace XPoster.Orchestrators;

/// <summary>
/// Resolves and instantiates the correct <see cref="BaseOrchestrator"/> for the current hour of the day
/// by consulting the <see cref="ISlotProfileProvider"/> schedule, including AI provider orchestration.
/// </summary>
public class OrchestratorFactory : IOrchestratorFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<OrchestratorFactory> _log;
    private readonly ITimeProvider _timeProvider;
    private readonly IAiServiceFactory _aiServiceFactory;
    private readonly ISlotProfileProvider _slotProfileProvider;
    private readonly IConfiguration? _configuration;

    /// <summary>
    /// Initialises a new instance of <see cref="OrchestratorFactory"/>.
    /// </summary>
    /// <param name="serviceProvider">DI service provider used to resolve senders and dependencies.</param>
    /// <param name="log">Factory logger.</param>
    /// <param name="timeProvider">Time provider used to determine current hour slot.</param>
    /// <param name="aiServiceFactory">Factory used to resolve the AI service by provider.</param>
    /// <param name="slotProfileProvider">Provider that supplies the scheduled orchestration profiles.</param>
    /// <param name="configuration">Optional configuration used to override the AI provider via <c>AiProvider</c> setting.</param>
    public OrchestratorFactory(
        IServiceProvider serviceProvider,
        ILogger<OrchestratorFactory> log,
        ITimeProvider timeProvider,
        IAiServiceFactory aiServiceFactory,
        ISlotProfileProvider slotProfileProvider,
        IConfiguration? configuration = null)
    {
        _serviceProvider = serviceProvider;
        _log = log;
        _timeProvider = timeProvider;
        _aiServiceFactory = aiServiceFactory;
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
            return CreateOrchestratorInstance(typeof(NoOrchestrator), null, null);
        }

        _log.LogInformation("Creating orchestrator {OrchestratorType} for sender {SenderType} at hour {Hour} with AI provider {AiProvider}",
            profile.OrchestratorType.Name, profile.SenderType, profile.Hour, profile.AiProvider);

        ISender? sender = profile.SenderType switch
        {
            MessageSender.XPowerLaw     => _serviceProvider.GetService(typeof(XSender))     as ISender,
            MessageSender.XSummaryFeed  => _serviceProvider.GetService(typeof(XSender))     as ISender,
            MessageSender.InSummaryFeed => _serviceProvider.GetService(typeof(InSender))    as ISender,
            MessageSender.InPowerLaw    => _serviceProvider.GetService(typeof(InSender))    as ISender,
            MessageSender.IgSummaryFeed => _serviceProvider.GetService(typeof(IgSender))    as ISender,
            MessageSender.IgPowerLaw    => _serviceProvider.GetService(typeof(IgSender))    as ISender,
            MessageSender.DryRunSend    => _serviceProvider.GetService(typeof(DryRunSender)) as ISender,
            _ => null
        };

        IAiService? aiService = null;
        if (profile.AiProvider.HasValue)
        {
            var effectiveProvider = ResolveAiProvider(profile.AiProvider.Value);
            aiService = _aiServiceFactory.GetByProvider(effectiveProvider);
        }

        return CreateOrchestratorInstance(profile.OrchestratorType, sender, aiService);
    }

    private BaseOrchestrator CreateOrchestratorInstance(Type orchestratorType, ISender? sender, IAiService? aiService)
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
                else if (typeof(IAiService).IsAssignableFrom(param.ParameterType))
                    args.Add(aiService);
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
