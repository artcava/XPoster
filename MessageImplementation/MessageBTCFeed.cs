using System;
using XPoster.MessageAbstraction;

namespace XPoster.MessageImplementation;

public class MessageBTCFeed : IGeneration
{
    public bool SendIt => true;

    public string Name => typeof(MessageBTCFeed).Name;

    public string GenerateMessage()
    {
        throw new NotImplementedException();
    }
}
