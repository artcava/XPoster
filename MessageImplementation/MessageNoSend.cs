using System.Threading.Tasks;
using XPoster.MessageAbstraction;

namespace XPoster.MessageImplementation;

public class MessageNoSend: IGeneration
{
    public async Task<string> GenerateMessage()
    {
        await Task.Run(() => { });
        return string.Empty;
    }
    public bool SendIt => false;
    public string Name => typeof(MessageNoSend).Name;
}
