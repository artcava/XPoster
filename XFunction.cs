using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using XPoster.Abstraction;

namespace XPoster
{
    public class XFunction
    {
        private readonly IGeneratorFactory _generatorFactory;
        private readonly ILogger<XFunction> _log;

        public XFunction(IGeneratorFactory generatorFactory, ILogger<XFunction> log)
        {
            _generatorFactory = generatorFactory;
            _log = log;
        }

        [FunctionName("XPosterFunction")]
        public async Task Run([TimerTrigger("0 0 */2 * * *")]TimerInfo myTimer)
        {
            _log.LogInformation("XPoster Function started at: {0}", DateTimeOffset.UtcNow);

            try
            {
                // Create message generator
                var generator = _generatorFactory.Generate();

                // Check if generator is enabled to send
                if (!generator.SendIt) { _log.LogInformation("Generator {0} is disabled", generator.Name); return; }

                var post = await generator.GenerateAsync();

                if (post == null) { _log.LogError($"Failed to generate message with {generator.Name}"); return; }

                var result = await generator.PostAsync(post);
                if (!result)
                {
                    _log.LogError($"Failed to send Message with {generator.Name}");
                }

            }
            catch (Exception ex)
            {
                _log.LogError(ex, "XPoster Function causes an error: {0}", ex.Message);
                throw; // Throw exception for Azure monitoring
            }

            _log.LogInformation($"XPoster Function ended at: {DateTimeOffset.UtcNow}");
        }
    }
}
