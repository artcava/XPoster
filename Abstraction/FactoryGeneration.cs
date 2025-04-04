using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using XPoster.Implementation;
using XPoster.SenderPlugins;

namespace XPoster.Abstraction;

public static class FactoryGeneration
{
    public static BaseGenerator Generate(ILogger log)
    {
        switch (sendParameters[DateTimeOffset.UtcNow.Hour])
        {
            case MessageSender.XPowerLaw:
                return new PowerLawGenerator(new XSender(log), log);
            case MessageSender.XSummaryFeed:
                return new FeedGenerator(new XSender(log), log);
            case MessageSender.InSummaryFeed:
                return new FeedGenerator(new InSender(log), log);
            case MessageSender.InPowerLaw:
                return new PowerLawGenerator(new InSender(log), log);
            case MessageSender.NoSend:
            default:
                return new NoGenerator(null, log);
        }
    }

    private static readonly Dictionary<int, MessageSender> sendParameters = new()
    {
        { 0, MessageSender.NoSend },
        { 2, MessageSender.NoSend },
        { 4, MessageSender.NoSend },
        { 6, MessageSender.NoSend },
        { 8, MessageSender.XSummaryFeed },
        { 10, MessageSender.NoSend },
        { 12, MessageSender.NoSend },
        { 14, MessageSender.InPowerLaw },
        { 16, MessageSender.XPowerLaw },
        { 18, MessageSender.InSummaryFeed },
        { 20, MessageSender.NoSend },
        { 22, MessageSender.NoSend },
    };
}
