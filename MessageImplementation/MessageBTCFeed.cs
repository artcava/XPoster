using System;
using System.Threading.Tasks;
using XPoster.MessageAbstraction;

namespace XPoster.MessageImplementation;

public class MessageBTCFeed : IGeneration
{
    public bool SendIt => true;

    public string Name => typeof(MessageBTCFeed).Name;

    public async Task<string> GenerateMessage()
    {
        await Task.Run(() => { });
        throw new NotImplementedException();
    }
}
