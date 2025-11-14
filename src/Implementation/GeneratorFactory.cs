using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using XPoster.Abstraction;
using XPoster.SenderPlugins;

namespace XPoster.Implementation;

public class GeneratorFactory : IGeneratorFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<GeneratorFactory> _log;

    // Il costruttore ora riceve i servizi necessari tramite DI
    public GeneratorFactory(IServiceProvider serviceProvider, ILogger<GeneratorFactory> log)
    {
        _serviceProvider = serviceProvider;
        _log = log;
    }
    public BaseGenerator Generate()
    {
        var senderType = sendParameters.GetValueOrDefault(DateTimeOffset.UtcNow.Hour, MessageSender.NoSend);

        switch (senderType)
        {
            case MessageSender.XPowerLaw:
                // Risolviamo il generator dal container e gli passiamo il sender corretto
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
                // Uniformiamo: usiamo GetInstance senza sender per NoGenerator (assumendo non lo richieda)
                return GetInstance<NoGenerator>(null); // O adatta se NoGenerator non ha bisogno di sender
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
