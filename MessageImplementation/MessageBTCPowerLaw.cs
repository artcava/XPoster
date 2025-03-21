using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using XPoster.MessageAbstraction;
using XPoster.Utilities;

namespace XPoster.MessageImplementation;

public class MessageBTCPowerLaw(ILogger log) : IGeneration
{
    private bool _sendIt = true;
    public bool SendIt { get { return _sendIt; } set { _sendIt = value; } }

    public string Name => "BTC Power Law message generator";

    public bool ProduceImage { get => false; set => throw new NotImplementedException(); }

    public async Task<string> GenerateMessage()
    {
        DateTime gemini = new DateTime(2009, 1, 3);
        DateTime date = DateTime.Now.Date;
        if (date <= gemini)
        {
            log.LogError("Invalid date!");
            _sendIt = false;
            return string.Empty;
        }

        var days = (date - gemini).Days;
        var value = Math.Pow(10, -17) * Math.Pow(days, 5.83d);

        var msg = $"Value of #BTC for the #powerlaw today would be: {value:F2} #USD";

        var actualValue = await CryptoUtilities.GetCryptoValue("BTC");
        if (actualValue <= 0)
        {
            log.LogError("Unable to get Actual BTC value!");
            return msg;
        }

        msg += $"\n{100.00m - (actualValue / (decimal)value * 100):+0.00;-0.00}% of actual";

        return msg;
    }

    public Task<ImageMessage> GenerateMessageWithImage()
    {
        throw new NotImplementedException();
    }
}
