using XPoster.Abstraction;
using XPoster.SenderPlugins;

namespace XPoster.Implementation;

/// <summary>
/// Resolves and instantiates the correct <see cref="BaseGenerator"/> for the current hour of the day
/// by consulting the static <see cref="sendParameters"/> schedule.
/// </summary>
public class GeneratorFactory : IGeneratorFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<GeneratorFactory> _log;
    private readonly ITimeProvider _timeProvider;

    /// <summary>
    /// Initialises a new instance of <see cref="GeneratorFactory"/>.
    /// </summary>
    /// <param name="serviceProvider">The DI service provider used to resolve generator dependencies.</param>
    /// <param name="log">The logger for factory-level diagnostic output.</param>
    /// <param name="timeProvider">The time provider used to determine the current hour.</param>
    public GeneratorFactory(IServiceProvider serviceProvider, ILogger<GeneratorFactory> log, ITimeProvider timeProvider)
    {
        _serviceProvider = serviceProvider;
        _log = log;
        _timeProvider = timeProvider;
    }

    /// <summary>
    /// Creates and returns the <see cref="BaseGenerator"/> mapped to the current hour.
    /// Falls back to <see cref="NoGenerator"/> when no entry exists for the current hour.
    /// </summary>
    /// <returns>A fully initialised <see cref="BaseGenerator"/> instance.</returns>
    public BaseGenerator Generate()
    {
        var currentHour = _timeProvider.GetCurrentTime().Hour;
        var senderType = sendParameters.GetValueOrDefault(currentHour, MessageSender.NoSend);

        _log.LogInformation("Creating {senderType} at hour {Hour}", senderType, currentHour);

        switch (senderType)
        {
            case MessageSender.XPowerLaw:
                return GetInstance<PowerLawGenerator>(_serviceProvider.GetService(typeof(XSender)) as ISender);

            case MessageSender.XSummaryFeed:
                return GetInstance<FeedGenerator>(_serviceProvider.GetService(typeof(XSender)) as ISender);

            case MessageSender.InSummaryFeed:
                return GetInstance<FeedGenerator>(_serviceProvider.GetService(typeof(InSender)) as ISender);

            case MessageSender.InPowerLaw:
                return GetInstance<PowerLawGenerator>(_serviceProvider.GetService(typeof(InSender)) as ISender);

            case MessageSender.IgSummaryFeed:
                return GetInstance<FeedGenerator>(_serviceProvider.GetService(typeof(IgSender)) as ISender);

            case MessageSender.IgPowerLow:
                return GetInstance<PowerLawGenerator>(_serviceProvider.GetService(typeof(IgSender)) as ISender);

            case MessageSender.NoSend:
            default:
                return GetInstance<NoGenerator>(null);
        }
    }

    /// <summary>
    /// Resolves an instance of <typeparamref name="T"/> from the DI container,
    /// injecting the provided <paramref name="sender"/> as a manual dependency alongside
    /// any other services resolved automatically.
    /// </summary>
    /// <typeparam name="T">The concrete generator type to instantiate.</typeparam>
    /// <param name="sender">The sender to inject, or <c>null</c> for no-op generators.</param>
    /// <returns>A fully constructed instance of <typeparamref name="T"/>.</returns>
    private T GetInstance<T>(ISender? sender) where T : BaseGenerator
    {
        var logger = _serviceProvider.GetRequiredService<ILogger<T>>();

        if (sender == null)
        {
            return (T)ActivatorUtilities.CreateInstance(_serviceProvider, typeof(T), logger);
        }
        else
        {
            return (T)ActivatorUtilities.CreateInstance(_serviceProvider, typeof(T), sender, logger);
        }
    }

    /// <summary>
    /// Maps each hour of the day (0–23) to the <see cref="MessageSender"/> strategy to apply.
    /// Hours not present in this dictionary default to <see cref="MessageSender.NoSend"/>.
    /// </summary>
    private static readonly Dictionary<int, MessageSender> sendParameters = new()
    {
        { 6, MessageSender.InSummaryFeed },
        { 8, MessageSender.XSummaryFeed },
        //{ 10, MessageSender.IgSummaryFeed },
        { 14, MessageSender.InPowerLaw },
        { 16, MessageSender.XPowerLaw },
        //{ 18, MessageSender.IgPowerLow },
    };
}
