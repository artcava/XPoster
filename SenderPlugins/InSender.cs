using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using XPoster.Abstraction;

namespace XPoster.SenderPlugins;

public class InSender : ISender
{
    private static readonly HttpClient httpClient = new();
    public int MessageMaxLenght => 800;
    private readonly ILogger _log;

    public InSender(ILogger log)
    {
        httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Environment.GetEnvironmentVariable("IN_ACCESS_TOKEN"));
        _log = log;

    }
    public async Task<bool> SendAsync(Message message)
    {
        try
        {
            var postText = message.Content + message.Firm;
            var inOwner = Environment.GetEnvironmentVariable("IN_OWNER");
            dynamic postPayload;

            if (message.Image.Length > 0) 
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
                    _log.LogError($"Failed to initialize image upload: {await initResponse.Content.ReadAsStringAsync()}");
                    return false;
                }

                var initData = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(await initResponse.Content.ReadAsStringAsync());
                var valueElement = initData["value"] as JsonElement? ?? throw new InvalidOperationException("Value element missing");

                var uploadMechanism = valueElement.GetProperty("uploadMechanism");
                var mediaUploadRequest = uploadMechanism.GetProperty("com.linkedin.digitalmedia.uploading.MediaUploadHttpRequest");
                string uploadUrl = mediaUploadRequest.GetProperty("uploadUrl").GetString();
                string asset = valueElement.GetProperty("asset").GetString();

                // Step 2: Upload image
                using (var memoryStream = new MemoryStream(message.Image))
                {
                    var imageContent = new StreamContent(memoryStream);
                    imageContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg"); // Modifica se è PNG o altro
                    var uploadResponse = await httpClient.PostAsync(uploadUrl, imageContent);

                    if (!uploadResponse.IsSuccessStatusCode)
                    {
                        _log.LogError($"Failed to upload image: {await uploadResponse.Content.ReadAsStringAsync()}");
                        return false;
                    }
                }
                // Step 3: Prepare PayLoad
                postPayload = generatePayLoad(asset, inOwner, message.Content);
            }
            else
            {
                // Step 3: Prepare PayLoad
                postPayload = generatePayLoad(null, inOwner, message.Content);
            }

            var json = JsonSerializer.Serialize(postPayload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://api.linkedin.com/v2/ugcPosts", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Failed to post to LinkedIn: {await response.Content.ReadAsStringAsync()}");
            return true;
        }
        catch (Exception ex)
        {
            _log.LogError(ex, ex.Message);
            return false;
        }
    }
    private async Task PublishToLinkedInWithImage(string accessToken, string urn, string text, byte[] imageBytes, ILogger log)
    {
        httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

        // Step 1: Initialize image upload
        var initPayload = new
        {
            registerUploadRequest = new
            {
                recipes = new[] { "urn:li:digitalmediaRecipe:feedshare-image" },
                owner = urn,
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
            log.LogError($"Failed to initialize image upload: {await initResponse.Content.ReadAsStringAsync()}");
            return;
        }

        var initData = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(await initResponse.Content.ReadAsStringAsync());
        string uploadUrl = initData["value"]["uploadMechanism"]["com.linkedin.digitalmedia.uploading.MediaUploadHttpRequest"]["uploadUrl"];
        string asset = initData["value"]["asset"];

        // Step 2: Upload image
        using (var memoryStream = new MemoryStream(imageBytes))
        {
            var imageContent = new StreamContent(memoryStream);
            imageContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg"); // Modifica se è PNG o altro
            var uploadResponse = await httpClient.PostAsync(uploadUrl, imageContent);

            if (!uploadResponse.IsSuccessStatusCode)
            {
                log.LogError($"Failed to upload image: {await uploadResponse.Content.ReadAsStringAsync()}");
                return;
            }
        }

        // Step 3: Publish image post
        var postPayload = new
        {
            author = urn,
            lifecycleState = "PUBLISHED",
            specificContent = new
            {
                shareContent = new
                {
                    shareCommentary = new { text = text },
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
            },
            visibility = new { visibility = "PUBLIC" }
        };

        var postJson = JsonSerializer.Serialize(postPayload);
        var postContent = new StringContent(postJson, Encoding.UTF8, "application/json");
        var postResponse = await httpClient.PostAsync("https://api.linkedin.com/v2/ugcPosts", postContent);

        if (postResponse.IsSuccessStatusCode)
        {
            log.LogInformation("Successfully posted to LinkedIn with image.");
        }
        else
        {
            log.LogError($"Failed to post to LinkedIn: {await postResponse.Content.ReadAsStringAsync()}");
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
