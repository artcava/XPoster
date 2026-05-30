using XPoster.Abstraction;
using XPoster.SenderPlugins;

namespace XPoster.Implementation;

/// <summary>
/// Resolves and instantiates the correct <see cref="BaseGenerator"/> for the current hour of the day
/// by consulting the static <see cref="slotProfiles"/> schedule, including AI provider orchestration.
/// </summary>
public class GeneratorFactory : IGeneratorFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<GeneratorFactory> _log;
    private readonly ITimeProvider _timeProvider;
    private readonly IAiServiceFactory _aiServiceFactory;

    /// <summary>
    /// Initialises a new instance of <see cref="GeneratorFactory"/>.
    /// </summary>
    /// <param name="serviceProvider">DI service provider used to resolve senders and dependencies.</param>
    /// <param name="log">Factory logger.</param>
    /// <param name="timeProvider">Time provider used to determine current hour slot.</param>
    /// <param name="aiServiceFactory">Factory used to resolve the AI service by provider.</param>
    public GeneratorFactory(
        IServiceProvider serviceProvider,
        ILogger<GeneratorFactory> log,
        ITimeProvider timeProvider,
        IAiServiceFactory aiServiceFactory)
    {
        _serviceProvider = serviceProvider;
        _log = log;
        _timeProvider = timeProvider;
        _aiServiceFactory = aiServiceFactory;
    }

    /// <summary>
    /// Creates and returns the <see cref="BaseGenerator"/> mapped to the current hour, including AI provider orchestration.
    /// Falls back to <see cref="NoGenerator"/> when no entry exists for the current hour.
    /// </summary>
    /// <returns>A fully initialised <see cref="BaseGenerator"/> instance.</returns>
    public BaseGenerator Generate()
    {
        var currentHour = _timeProvider.GetCurrentTime().Hour;
        var profile = slotProfiles.FirstOrDefault(p => p.Hour == currentHour);

        if (profile == null)
        {
            _log.LogInformation("No slot profile for hour {Hour}, using NoGenerator", currentHour);
            return CreateGeneratorInstance(typeof(NoGenerator), null, null);
        }

        _log.LogInformation("Creating generator {GeneratorType} for sender {SenderType} at hour {Hour} with AI provider {AiProvider}",
            profile.GeneratorType.Name, profile.SenderType, profile.Hour, profile.AiProvider);

        ISender? sender = profile.SenderType switch
        {
            MessageSender.XPowerLaw => _serviceProvider.GetService(typeof(XSender)) as ISender,
            MessageSender.XSummaryFeed => _serviceProvider.GetService(typeof(XSender)) as ISender,
            MessageSender.InSummaryFeed => _serviceProvider.GetService(typeof(InSender)) as ISender,
            MessageSender.InPowerLaw => _serviceProvider.GetService(typeof(InSender)) as ISender,
            MessageSender.IgSummaryFeed => _serviceProvider.GetService(typeof(IgSender)) as ISender,
            MessageSender.IgPowerLow => _serviceProvider.GetService(typeof(IgSender)) as ISender,
            _ => null
        };

        IAiService? aiService = null;
        if (profile.AiProvider.HasValue)
        {
            aiService = _aiServiceFactory.GetByProvider(profile.AiProvider.Value);
        }

        // Dynamically instantiate the generator with sender and aiService if required
        return CreateGeneratorInstance(profile.GeneratorType, sender, aiService);
    }

    private BaseGenerator CreateGeneratorInstance(Type generatorType, ISender? sender, IAiService? aiService)
    {
        var loggerType = typeof(ILogger<>).MakeGenericType(generatorType);
        var logger = _serviceProvider.GetRequiredService(loggerType);

        // Try to match constructor: (ISender, IAiService, ILogger<T>) or fallback
        var ctor = generatorType.GetConstructors()
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
        return (BaseGenerator)Activator.CreateInstance(generatorType, args.ToArray())!;
    }

    /// <summary>
    /// Example slot profile mapping. Extend as needed.
    /// </summary>
    private static readonly List<ScheduledGenerationProfile> slotProfiles = new()
    {
        new ScheduledGenerationProfile(6, MessageSender.InSummaryFeed, typeof(FeedGenerator), AiProvider.OpenAi),
        new ScheduledGenerationProfile(8, MessageSender.XSummaryFeed, typeof(FeedGenerator), AiProvider.OpenAi),
        //new ScheduledGenerationProfile(10, MessageSender.IgSummaryFeed, typeof(FeedGenerator), AiProvider.OpenAi),
        new ScheduledGenerationProfile(14, MessageSender.InPowerLaw, typeof(PowerLawGenerator), AiProvider.OpenAi),
        new ScheduledGenerationProfile(16, MessageSender.XPowerLaw, typeof(PowerLawGenerator), AiProvider.OpenAi),
        //new ScheduledGenerationProfile(18, MessageSender.IgPowerLow, typeof(PowerLawGenerator), AiProvider.OpenAi),
    };
}
