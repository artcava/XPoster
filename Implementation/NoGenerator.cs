using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using XPoster.Abstraction;

namespace XPoster.Implementation
{
    public class NoGenerator(ILogger logger) : BaseGenerator(null, logger)
    {
        public override string Name => typeof(NoGenerator).Name;

        public override bool SendIt { get => false; set => throw new System.NotImplementedException(); }
        public override bool ProduceImage { get => false; set => throw new System.NotImplementedException(); }

        public override Task<Message> GenerateAsync()
        {
            return null;
        }
    }
}
