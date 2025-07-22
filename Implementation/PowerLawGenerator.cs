using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using XPoster.Abstraction;

namespace XPoster.Implementation
{
    public class PowerLawGenerator : BaseGenerator
    {
        private bool _sendIt = true;
        private readonly ICryptoService _cryptoService;
        private readonly ITimeProvider _timeProvider;
        private readonly ILogger _logger;
        public override string Name => typeof(PowerLawGenerator).Name;

        public override bool SendIt { get { return _sendIt; } set { _sendIt = value; } }
        public override bool ProduceImage { get => false; set => throw new NotImplementedException(); }

        public PowerLawGenerator(ISender sender, ILogger<PowerLawGenerator> logger, ICryptoService cryptoService, ITimeProvider timeProvider)
        : base(sender, logger)
        {
            _logger = logger;
            _cryptoService = cryptoService;
            _timeProvider = timeProvider;
        }

        public override async Task<Message> GenerateAsync()
        {
            DateTime gemini = new DateTime(2009, 1, 3);
            DateTime date = _timeProvider.GetCurrentTime().Date;
            if (date <= gemini)
            {
                _logger.LogError("Invalid date!");
                _sendIt = false;
                return null;
            }

            var days = (date - gemini).Days;
            var value = Math.Pow(10, -17) * Math.Pow(days, 5.83d);

            var msg = new Message { Content = $"Value of #BTC for the #powerlaw today would be: {value:F2} #USD", Image = null };

            var actualValue = await _cryptoService.GetCryptoValue("BTC");
            if (actualValue <= 0)
            {
                _logger.LogError("Unable to get Actual BTC value!");
                return msg;
            }

            msg.Content += $"\n{100.00m - (actualValue / (decimal)value * 100):+0.00;-0.00}% of actual";

            return msg;
        }
    }
}
