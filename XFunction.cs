using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LinqToTwitter;
using LinqToTwitter.OAuth;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using XPoster.MessageAbstraction;
using XPoster.Models;

namespace XPoster
{
    public class XFunction
    {
        [FunctionName("XPosterFunction")]
        public async Task Run([TimerTrigger("0 0 */4 * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation("Twitter Function started at: {0}", DateTimeOffset.UtcNow);

            const string firm = "\n\n#XPoster generated #AI powered";

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
                var generator = FactoryGeneration.Generate(log);

                // Check if generator is enabled to send
                if (!generator.SendIt) { log.LogInformation("Generator {0} is disabled", generator.Name); return; }

                var tweetId = string.Empty;

                if (generator.ProduceImage)
                {
                    var image = await generator.GenerateMessageWithImage();

                    if (!generator.SendIt) { log.LogInformation($"Generator {generator.Name} cannot generate messages to send"); return; }

                    if (image == null) { log.LogInformation($"Empty image with {generator.Name}"); return; }

                    if (string.IsNullOrWhiteSpace(image.Message)) { log.LogInformation($"Empty message with {generator.Name}"); return; }

                    if (image.Message.Length > 280) throw new Exception($"Message too long: {image.Message.Length}");

                    log.LogInformation("Generated message: {0}", image.Message);

                    var media = await twitterContext.UploadMediaAsync(image.Image, "image/jpeg", "tweet_image");

                    if (media == null) throw new Exception("Error uploading media");

                    var imageTweet = await twitterContext.TweetMediaAsync(
                                    text: image.Message + firm,
                                    mediaIds: new List<string> { media.MediaID.ToString() }
                                );
                    if (imageTweet == null) throw new Exception("Error tweeting");

                    tweetId = imageTweet.ID;
                }
                else
                {
                    var message = await generator.GenerateMessage();

                    if (!generator.SendIt) { log.LogInformation($"Generator {generator.Name} cannot generate messages to send"); return; }

                    if (string.IsNullOrWhiteSpace(message)) { log.LogInformation($"Empty message with {generator.Name}"); return; }

                    message += firm;

                    if (message.Length > 280) throw new Exception($"Message too long: {message.Length}");

                    log.LogInformation("Generated message: {0}", message);

                    var tweet = await twitterContext.TweetAsync(message);

                    if (tweet == null) throw new Exception("Error tweeting");

                    tweetId = tweet.ID;
                }

                log.LogInformation("Published tweet: (ID: {0})", tweetId);
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
