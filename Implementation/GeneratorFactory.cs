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
                return _serviceProvider.GetService(typeof(NoGenerator)) as NoGenerator;
        }
    }
    private T GetInstance<T>(ISender sender) where T : BaseGenerator
    {
        // Per creare i generator, abbiamo bisogno del sender e del logger.
        // Usiamo ActivatorUtilities per creare un'istanza passando le dipendenze che il container non può risolvere automaticamente in questo contesto (sender).
        return (T)ActivatorUtilities.CreateInstance(this._serviceProvider, typeof(T), sender);
    }
    private static readonly Dictionary<int, MessageSender> sendParameters = new()
        {
            { 0, MessageSender.NoSend },
            { 2, MessageSender.NoSend },
            { 4, MessageSender.NoSend },
            { 6, MessageSender.InSummaryFeed },
            { 8, MessageSender.XSummaryFeed },
            { 10, MessageSender.NoSend },
            //{ 10, MessageSender.IgSummaryFeed },
            { 12, MessageSender.NoSend },
            { 14, MessageSender.InPowerLaw },
            { 16, MessageSender.XPowerLaw },
            { 18, MessageSender.NoSend},
            //{ 18, MessageSender.IgPowerLow },
            { 20, MessageSender.NoSend },
            { 22, MessageSender.NoSend },
        };
}
