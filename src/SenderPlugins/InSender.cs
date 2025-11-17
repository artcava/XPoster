using System.Text;
using System.Text.Json;
using XPoster.Abstraction;
using XPoster.Models;

namespace XPoster.SenderPlugins;

public class InSender : ISender
{
    private static readonly HttpClient httpClient = new();
    private readonly ILogger<InSender> _logger;
    public int MessageMaxLenght => 800;
    public InSender(ILogger<InSender> logger)
    {
        httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Environment.GetEnvironmentVariable("IN_ACCESS_TOKEN"));
        _logger = logger;

    }
    public async Task<bool> SendAsync(Post post)
    {
        try
        {
            var inOwner = Environment.GetEnvironmentVariable("IN_OWNER");
            var postText = post.Content + Post.Firm;
            dynamic postPayload;

            if (post.Image != null && post.Image.Length > 0)
            {
                // Step 1: Initialize image upload
                var initPayload = new
                {
                    registerUploadRequest = new
                    {
                        recipes = new[] { "urn:li:digitalmediaRecipe:feedshare-image" },
                        owner = $"urn:li:person:{inOwner}",
                        serviceRelationships = new[]
                        {
                            new { relationshipType = "OWNER", identifier = "urn:li:userGeneratedContent" }
                        }
                    }
                };

                var initJson = JsonSerializer.Serialize(initPayload);
                var initContent = new StringContent(initJson, Encoding.UTF8, "application/json");
                var initResponse = await httpClient.PostAsync("https://api.linkedin.com/v2/assets?action=registerUpload", initContent);

                if (!initResponse.IsSuccessStatusCode)
                {
                    _logger.LogError($"Failed to initialize image upload: {await initResponse.Content.ReadAsStringAsync()}");
                    return false;
                }

                var initData = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(await initResponse.Content.ReadAsStringAsync());
                var valueElement = initData["value"] as JsonElement? ?? throw new InvalidOperationException("Value element missing");

                var uploadMechanism = valueElement.GetProperty("uploadMechanism");
                var mediaUploadRequest = uploadMechanism.GetProperty("com.linkedin.digitalmedia.uploading.MediaUploadHttpRequest");
                string uploadUrl = mediaUploadRequest.GetProperty("uploadUrl").GetString();
                string asset = valueElement.GetProperty("asset").GetString();

                // Step 2: Upload image
                using (var memoryStream = new MemoryStream(post.Image))
                {
                    var imageContent = new StreamContent(memoryStream);
                    imageContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg"); // Modifica se è PNG o altro
                    var uploadResponse = await httpClient.PostAsync(uploadUrl, imageContent);

                    if (!uploadResponse.IsSuccessStatusCode)
                    {
                        _logger.LogError($"Failed to upload image: {await uploadResponse.Content.ReadAsStringAsync()}");
                        return false;
                    }
                }
                // Step 3: Prepare PayLoad
                postPayload = generatePayLoad(asset, inOwner, postText);
            }
            else
            {
                // Step 3: Prepare PayLoad
                postPayload = generatePayLoad(null, inOwner, postText);
            }

            var json = JsonSerializer.Serialize(postPayload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://api.linkedin.com/v2/ugcPosts", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Failed to post to LinkedIn: {await response.Content.ReadAsStringAsync()}");

            _logger.LogInformation($"Post published: {await response.Content.ReadAsStringAsync()}.");

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return false;
        }
    }

    private dynamic generatePayLoad(string? asset, string owner, string summary)
    {
        Dictionary<string, object> specificContent;
        if (string.IsNullOrEmpty(asset))
        {
            specificContent = new Dictionary<string, object>
            {
                {
                    "com.linkedin.ugc.ShareContent",
                    new
                    {
                        shareCommentary = new { text = summary },
                        shareMediaCategory = "NONE"
                    }
                }
            };
        }
        else
        {
            specificContent = new Dictionary<string, object>
            {
                {
                    "com.linkedin.ugc.ShareContent",
                    new
                    {
                        shareCommentary = new { text = summary },
                        shareMediaCategory = "IMAGE",
                        media = new[]
                        {
                            new
                            {
                                status = "READY",
                                media = asset
                            }
                        }
                    }
                }
            };
        }

        var visibility = new Dictionary<string, string>
        {
            { "com.linkedin.ugc.MemberNetworkVisibility", "PUBLIC" }
        };

        var postPayload = new
        {
            author = $"urn:li:person:{owner}",
            lifecycleState = "PUBLISHED",
            specificContent,
            visibility
        };
        return postPayload;
    }
}
