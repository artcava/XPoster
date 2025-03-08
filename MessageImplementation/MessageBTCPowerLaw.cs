using System;
using XPoster.MessageAbstraction;

namespace XPoster.MessageImplementation;

public class MessageBTCPowerLaw : IGeneration
{
    public bool SendIt => true;

    public string Name => "BTC Power Law message generator";

    public string GenerateMessage()
    {
        DateTime gemini = new DateTime(2009, 1, 3);
        DateTime date = DateTime.Now.Date;
        if (date <= gemini)
        {
            throw new Exception("Invalid date!");
        }

        var days = (date - gemini).Days;
        var value = Math.Pow(10, -17) * Math.Pow(days, 5.83d);

        return $"Value of #BTC for the #powerlaw today would be: {value:F2} #USD";
    }
}
