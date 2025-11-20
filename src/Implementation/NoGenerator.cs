using XPoster.Abstraction;
using XPoster.Models;

namespace XPoster.Implementation
{
    public class NoGenerator(ILogger<NoGenerator> logger) : BaseGenerator(null, logger)
    {
        public override string Name => typeof(NoGenerator).Name;

        public override bool SendIt { get => false; set => throw new System.NotImplementedException(); }
        public override bool ProduceImage { get => false; set => throw new System.NotImplementedException(); }

        public override Task<Post>? GenerateAsync()
        {
            return null;
        }
    }
}
