using XPoster.Abstraction;
using XPoster.Models;

namespace XPoster.Implementation
{
    /// <summary>
    /// A no-op orchestrator used when the current time slot has no scheduled posting activity.
    /// It never sends messages and always returns <c>null</c> from <see cref="OrchestrateAsync"/>.
    /// </summary>
    public class NoOrchestrator(ILogger<NoOrchestrator> logger) : BaseOrchestrator(null, logger)
    {
        /// <inheritdoc/>
        public override string Name => typeof(NoOrchestrator).Name;

        /// <summary>Always <c>false</c>; this orchestrator never dispatches posts.</summary>
        public override bool SendIt { get => false; set => throw new System.NotImplementedException(); }

        /// <summary>Always <c>false</c>; this orchestrator never produces images.</summary>
        public override bool ProduceImage { get => false; set => throw new System.NotImplementedException(); }

        /// <summary>
        /// Returns <c>null</c> unconditionally — no content is orchestrated in a no-send slot.
        /// </summary>
        /// <returns><c>null</c></returns>
        // CS8609: return type aligned to Task<Post?> (nullable Post, not nullable Task) to match BaseOrchestrator signature
        public override Task<Post?> OrchestrateAsync()
        {
            return Task.FromResult<Post?>(null);
        }
    }
}
