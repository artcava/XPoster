using XPoster.Abstraction;
using XPoster.Models;

namespace XPoster.Implementation
{
    /// <summary>
    /// Generates a social-media post that reports the Bitcoin Power Law fair-value estimate
    /// for the current date and compares it with the live market price.
    /// </summary>
    /// <remarks>
    /// The Power Law model estimates BTC fair value as:
    /// <c>value = 10^(-17) * days^5.83</c>
    /// where <c>days</c> is the number of days elapsed since the Bitcoin genesis block (2009-01-03).
    /// </remarks>
    public class PowerLawGenerator : BaseGenerator
    {
        private bool _sendIt = true;
        private readonly ICryptoService _cryptoService;
        private readonly ITimeProvider _timeProvider;

        /// <inheritdoc/>
        public override string Name => typeof(PowerLawGenerator).Name;

        /// <inheritdoc/>
        public override bool SendIt { get { return _sendIt; } set { _sendIt = value; } }

        /// <summary>Always <c>false</c>; this generator does not attach images to its posts.</summary>
        public override bool ProduceImage { get => false; set => throw new NotImplementedException(); }

        /// <summary>
        /// Initialises a new instance of <see cref="PowerLawGenerator"/>.
        /// </summary>
        /// <param name="sender">The sender used to publish the post to the target platform.</param>
        /// <param name="logger">The logger for diagnostic output.</param>
        /// <param name="cryptoService">The service used to fetch the current BTC market price.</param>
        /// <param name="timeProvider">The time provider used to obtain the current date.</param>
        public PowerLawGenerator(ISender sender, ILogger<PowerLawGenerator> logger, ICryptoService cryptoService, ITimeProvider timeProvider)
        : base(sender, logger)
        {
            _cryptoService = cryptoService;
            _timeProvider = timeProvider;
        }

        /// <summary>
        /// Computes the Power Law BTC fair-value for today, fetches the live price,
        /// and returns a <see cref="Post"/> containing both values with their percentage deviation.
        /// </summary>
        /// <returns>
        /// A <see cref="Post"/> with the Power Law value and live price deviation,
        /// or a partial post (without deviation) if the live price cannot be retrieved.
        /// Returns <c>null</c> if the current date precedes the Bitcoin genesis block.
        /// </returns>
        // CS8603: return type is Post? because null is a valid sentinel when date <= genesis
        public override async Task<Post?> GenerateAsync()
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

            var post = new Post { Content = $"Value of #BTC for the #powerlaw today would be: {value:F2} #USD", Image = null };

            var actualValue = await _cryptoService.GetCryptoValue("BTC");
            if (actualValue <= 0)
            {
                _logger.LogError("Unable to get Actual BTC value!");
                return post;
            }

            post.Content += $"\n{100.00m - (actualValue / (decimal)value * 100):+0.00;-0.00}% of actual";

            return post;
        }
    }
}
