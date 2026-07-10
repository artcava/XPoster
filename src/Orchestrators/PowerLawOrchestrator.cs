using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.Orchestrators
{
    /// <summary>
    /// Orchestrates a social-media post that reports the Bitcoin Power Law fair-value estimate
    /// for the current date and compares it with the live market price.
    /// </summary>
    /// <remarks>
    /// The Power Law model estimates BTC fair value as:
    /// <c>value = 10^(-17) * days^5.83</c>
    /// where <c>days</c> is the number of days elapsed since the Bitcoin genesis block (2009-01-03).
    /// Content is fully deterministic (no AI text), so the same <see cref="Post"/> is broadcast
    /// to all configured senders unchanged.
    /// </remarks>
    public class PowerLawOrchestrator : BaseOrchestrator
    {
        private bool _sendIt = true;
        private readonly ICryptoService _cryptoService;
        private readonly ITimeProvider _timeProvider;

        /// <inheritdoc/>
        public override string Name => typeof(PowerLawOrchestrator).Name;

        /// <inheritdoc/>
        public override bool SendIt { get { return _sendIt; } set { _sendIt = value; } }

        /// <summary>Always <c>false</c>; this orchestrator does not attach images to its posts.</summary>
        public override bool ProduceImage { get => false; set => throw new NotImplementedException(); }

        /// <inheritdoc/>
        /// <remarks>PowerLawOrchestrator supports X and LinkedIn. DryRun is also supported for testing.</remarks>
        public override IReadOnlyList<SenderPlatform> SupportedPlatforms { get; } =
            new List<SenderPlatform> { SenderPlatform.X, SenderPlatform.LinkedIn, SenderPlatform.DryRun }.AsReadOnly();

        /// <summary>
        /// Initialises a new instance of <see cref="PowerLawOrchestrator"/>.
        /// </summary>
        /// <param name="senders">
        /// Ordered list of senders for this slot, by descending <c>MessageMaxLength</c>.
        /// The same post is broadcast to all senders unchanged.
        /// </param>
        /// <param name="logger">The logger for diagnostic output.</param>
        /// <param name="cryptoService">The service used to fetch the current BTC market price.</param>
        /// <param name="timeProvider">The time provider used to obtain the current date.</param>
        public PowerLawOrchestrator(
            IReadOnlyList<ISender> senders,
            ILogger<PowerLawOrchestrator> logger,
            ICryptoService cryptoService,
            ITimeProvider timeProvider)
            : base(senders, logger)
        {
            _cryptoService = cryptoService;
            _timeProvider = timeProvider;
        }

        /// <summary>
        /// Computes the Power Law BTC fair-value for today, fetches the live price,
        /// and returns an <see cref="IReadOnlyDictionary{SenderPlatform, Post}"/> where the same
        /// <see cref="Post"/> is broadcast to every configured sender unchanged (deterministic content, no AI).
        /// </summary>
        /// <returns>
        /// A dictionary with one entry per sender, all mapping to the same <see cref="Post"/> instance.
        /// Returns an empty dictionary if the current date precedes the Bitcoin genesis block.
        /// </returns>
        public override async Task<IReadOnlyDictionary<SenderPlatform, Post?>> OrchestrateAsync(CancellationToken ct = default)
        {
            DateTime gemini = new DateTime(2009, 1, 3);
            DateTime date = _timeProvider.GetCurrentTime().Date;
            if (date <= gemini)
            {
                _logger.LogError("[PowerLawOrchestrator] Invalid date!");
                _sendIt = false;
                return new Dictionary<SenderPlatform, Post?>().AsReadOnly();
            }

            var days = (date - gemini).Days;
            var value = Math.Pow(10, -17) * Math.Pow(days, 5.83d);

            var post = new Post { Content = $"Value of #BTC for the #powerlaw today would be: {value:F2} #USD", Image = null };

            var actualValue = await _cryptoService.GetCryptoValue("BTC");
            if (actualValue <= 0)
            {
                _logger.LogError("[PowerLawOrchestrator] Unable to get Actual BTC value!");
            }
            else
            {
                post.Content += $"\n{100.00m - (actualValue / (decimal)value * 100):+0.00;-0.00}%";
            }

            // Broadcast: same post instance to every configured sender
            return _senders
                .ToDictionary(s => s.Platform, _ => (Post?)post)
                .AsReadOnly();
        }
    }
}
