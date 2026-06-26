using XPoster.Abstraction;
using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.Orchestrators
{
    /// <summary>
    /// A no-op orchestrator used when the current time slot has no scheduled posting activity.
    /// It never sends messages and always returns an empty list from <see cref="OrchestrateAsync"/>.
    /// </summary>
    public class NoOrchestrator : BaseOrchestrator
    {
        /// <inheritdoc/>
        public override string Name => typeof(NoOrchestrator).Name;

        /// <summary>Always <c>false</c>; this orchestrator never dispatches posts.</summary>
        public override bool SendIt { get => false; set => throw new System.NotImplementedException(); }

        /// <summary>Always <c>false</c>; this orchestrator never produces images.</summary>
        public override bool ProduceImage { get => false; set => throw new System.NotImplementedException(); }

        /// <inheritdoc/>
        /// <remarks>NoOrchestrator supports no platforms — it is a no-op slot.</remarks>
        public override IReadOnlyList<SenderPlatform> SupportedPlatforms { get; } =
            new List<SenderPlatform>().AsReadOnly();

        /// <summary>
        /// Initialises a new instance of <see cref="NoOrchestrator"/> with an empty sender list.
        /// </summary>
        /// <param name="logger">Logger for diagnostic output.</param>
        public NoOrchestrator(ILogger<NoOrchestrator> logger)
            : base(new List<ISender>().AsReadOnly(), logger)
        {
        }

        /// <summary>
        /// Returns an empty dictionary unconditionally — no content is orchestrated in a no-send slot.
        /// </summary>
        public override Task<IReadOnlyDictionary<SenderPlatform, Post?>> OrchestrateAsync() =>
            Task.FromResult<IReadOnlyDictionary<SenderPlatform, Post?>>(new Dictionary<SenderPlatform, Post?>());
    }
}
