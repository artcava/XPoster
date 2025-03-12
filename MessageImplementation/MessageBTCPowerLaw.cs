using System;
using System.Threading.Tasks;
using XPoster.MessageAbstraction;
using XPoster.Utilities;

namespace XPoster.MessageImplementation;

public class MessageBTCPowerLaw : IGeneration
{
    private bool _sendIt = true;
    public bool SendIt { get { return _sendIt; } set { _sendIt = value; } }

    public string Name => "BTC Power Law message generator";

    public async Task<string> GenerateMessage()
    {
        DateTime gemini = new DateTime(2009, 1, 3);
        DateTime date = DateTime.Now.Date;
        if (date <= gemini)
        {
            throw new Exception("Invalid date!");
        }

        var days = (date - gemini).Days;
        var value = Math.Pow(10, -17) * Math.Pow(days, 5.83d);

        var msg = $"Value of #BTC for the #powerlaw today would be: {value:F2} #USD";

        var actualValue = await CryptoUtilities.GetCryptoValue("BTC");
        if (actualValue > 0)
        {
            msg += $"\n{100.00m - (actualValue / (decimal)value * 100):+0.00;-0.00}% of actual";
        }

        return msg;
    }
}
