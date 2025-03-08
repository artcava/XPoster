using System;
using System.Threading.Tasks;
using LinqToTwitter;
using LinqToTwitter.OAuth;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using XPoster.MessageAbstraction;

namespace XPoster
{
    public class XFunction
    {
        [FunctionName("XPosterFunction")]
        public async Task Run([TimerTrigger("0 0 */4 * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation("Twitter Function started at: {0}", DateTimeOffset.UtcNow);

            try
            {
                // Configure credentials
                var auth = new SingleUserAuthorizer
                {
                    CredentialStore = new SingleUserInMemoryCredentialStore
                    {
                        ConsumerKey = Environment.GetEnvironmentVariable("X_API_KEY"),
                        ConsumerSecret = Environment.GetEnvironmentVariable("X_API_SECRET"),
                        AccessToken = Environment.GetEnvironmentVariable("X_ACCESS_TOKEN"),
                        AccessTokenSecret = Environment.GetEnvironmentVariable("X_ACCESS_TOKEN_SECRET")
                    }
                };

                // Create context
                var twitterContext = new TwitterContext(auth);

                // Create message generator
                var generator = FactoryGeneration.Generate();

                // Check if there are messages to send
                if (!generator.SendIt)
                {
                    log.LogInformation("No messages to send");
                    return;
                }

                // Generate message
                var message = generator.GenerateMessage();

                // Check if the message is empty or null
                if (string.IsNullOrWhiteSpace(message))
                {
                    log.LogInformation($"Empty message with {generator.Name}");
                    return;
                }

                // Append a firm
                message += "\n\n#XPoster generated";

                // Publsh tweet
                var tweet = await twitterContext.TweetAsync(message);
                log.LogInformation("Published tweet: {0} (ID: {1})", message, tweet?.ID);
            }
            catch (Exception ex)
            {
                log.LogError("Twitter Function causes an error: {0}", ex.Message);
                throw; // Throw exception for Azure monitoring
            }

            log.LogInformation($"Twitter Function ended at: {DateTimeOffset.UtcNow}");
        }
    }
}
