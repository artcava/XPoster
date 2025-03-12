using System;
using System.Collections.Generic;
using XPoster.MessageImplementation;

namespace XPoster.MessageAbstraction;

public static class FactoryGeneration
{
    public static IGeneration Generate()
    {
        switch (sendParameters[DateTimeOffset.UtcNow.Hour])
        {
            case MessageSender.PowerLaw:
                return new MessageBTCPowerLaw();
            case MessageSender.SummaryFeed:
                return new MessageBTCFeed();
            case MessageSender.NoSend:
            default:
                return new MessageNoSend();
        }
    }

    private static readonly Dictionary<int, MessageSender> sendParameters = new()
    {
        { 0, MessageSender.NoSend },
        { 4, MessageSender.NoSend },
        { 8, MessageSender.SummaryFeed },
        { 12, MessageSender.NoSend },
        { 16, MessageSender.PowerLaw },
        { 20, MessageSender.NoSend },
    };
}
