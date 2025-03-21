using System;
using System.Threading.Tasks;
using XPoster.MessageAbstraction;

namespace XPoster.MessageImplementation;

public class MessageNoSend: IGeneration
{
    private bool _sendIt = false;
    public bool SendIt { get { return _sendIt; } set { _sendIt = value; } }
    public async Task<string> GenerateMessage()
    {
        await Task.Run(() => { });
        return string.Empty;
    }

    public Task<ImageMessage> GenerateMessageWithImage()
    {
        throw new System.NotImplementedException();
    }

    public string Name => typeof(MessageNoSend).Name;

    public bool ProduceImage { get => false; set => throw new NotImplementedException(); }
}
