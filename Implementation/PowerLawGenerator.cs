using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using XPoster.Abstraction;
using XPoster.Utilities;

namespace XPoster.Implementation
{
    public class PowerLawGenerator(ISender sender, ILogger logger) : BaseGenerator(sender, logger)
    {
        private bool _sendIt = true;
        public override string Name => typeof(PowerLawGenerator).Name;

        public override bool SendIt { get { return _sendIt; } set { _sendIt = value; } }
        public override bool ProduceImage { get => false; set => throw new NotImplementedException(); }

        public override async Task<Message> GenerateAsync()
        {
            DateTime gemini = new DateTime(2009, 1, 3);
            DateTime date = DateTime.Now.Date;
            if (date <= gemini)
            {
                logger.LogError("Invalid date!");
                _sendIt = false;
                return null;
            }

            var days = (date - gemini).Days;
            var value = Math.Pow(10, -17) * Math.Pow(days, 5.83d);

            var msg = new Message { Content = $"Value of #BTC for the #powerlaw today would be: {value:F2} #USD", Image = null };

            var actualValue = await CryptoUtilities.GetCryptoValue("BTC");
            if (actualValue <= 0)
            {
                logger.LogError("Unable to get Actual BTC value!");
                return msg;
            }

            msg.Content += $"\n{100.00m - (actualValue / (decimal)value * 100):+0.00;-0.00}% of actual";

            return msg;
        }
    }
}
