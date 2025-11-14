using XPoster.Abstraction;
using XPoster.SenderPlugins;

namespace XPoster.Implementation;

public class GeneratorFactory : IGeneratorFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<GeneratorFactory> _log;
    private readonly ITimeProvider _timeProvider;

    public GeneratorFactory(IServiceProvider serviceProvider, ILogger<GeneratorFactory> log, ITimeProvider timeProvider)
    {
        _serviceProvider = serviceProvider;
        _log = log;
        _timeProvider = timeProvider;
    }
    public BaseGenerator Generate()
    {
        var currentHour = _timeProvider.GetCurrentTime().Hour;
        var senderType = sendParameters.GetValueOrDefault(currentHour, MessageSender.NoSend);

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
    private T GetInstance<T>(ISender sender) where T : BaseGenerator
    {
        // Risolvi il logger specifico per il tipo T
        var logger = _serviceProvider.GetRequiredService<ILogger<T>>();

        // Per creare i generator, usiamo ActivatorUtilities per passare le dipendenze manuali (sender) e resolvibili (logger)
        if (sender == null)
        {
            // Caso speciale per NoGenerator o simili senza sender
            return (T)ActivatorUtilities.CreateInstance(_serviceProvider, typeof(T), logger);
        }
        else
        {
            return (T)ActivatorUtilities.CreateInstance(_serviceProvider, typeof(T), sender, logger);
        }
    }
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
