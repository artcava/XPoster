using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPoster.MessageAbstraction;

namespace XPoster.MessageImplementation;

public class MessageNoSend: IGeneration
{
    public string GenerateMessage()
    {
        return string.Empty;
    }
    public bool SendIt => false;
    public string Name => typeof(MessageNoSend).Name;
}
