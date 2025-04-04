using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using XPoster.Abstraction;

namespace XPoster
{
    public class XFunction
    {
        //[FunctionName("XPosterTest")]
        //public static async Task<IActionResult> RunTest([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, ILogger log)
        //{
        //    await ExecuteXPoster(log); // Chiama la logica del timer
        //    return new OkResult();
        //}

        [FunctionName("XPosterFunction")]
        public async Task Run([TimerTrigger("0 0 */2 * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation("XPoster Function started at: {0}", DateTimeOffset.UtcNow);

            await ExecuteXPoster(log);

            log.LogInformation($"XPoster Function ended at: {DateTimeOffset.UtcNow}");
        }
        private static async Task ExecuteXPoster(ILogger log)
        {
            try
            {
                // Create message generator
                var generator = FactoryGeneration.Generate(log);

                // Check if generator is enabled to send
                if (!generator.SendIt) { log.LogInformation("Generator {0} is disabled", generator.Name); return; }

                var message = await generator.GenerateAsync();

                if (message == null) { log.LogError($"Failed to generate {message}"); return; }

                var result = await generator.SendMessageAsync(message);
                if (!result)
                {
                    log.LogError($"Failed to send Message with {generator.Name}");
                }

            }
            catch (Exception ex)
            {
                log.LogError(ex, "XPoster Function causes an error: {0}", ex.Message);
                throw; // Throw exception for Azure monitoring
            }
        }

    }
}
