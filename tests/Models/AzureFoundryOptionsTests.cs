using XPoster.Models;

namespace XPoster.Tests.Models;

/// <summary>
/// Covers default values and shape of <see cref="AzureFoundryOptions"/>.
/// Also acts as a regression guard: ApiVersion must not exist on this class
/// because the Azure AI Foundry /openai/v1 endpoint does not require an api-version
/// query parameter — the model is passed as the deployment name in the request body.
/// </summary>
public class AzureFoundryOptionsTests
{
    [Fact]
    public void AzureFoundryOptions_Defaults_AreCorrect()
    {
        var options = new AzureFoundryOptions();

        Assert.Equal(string.Empty, options.Endpoint);
        Assert.Equal(string.Empty, options.ApiKey);
        Assert.Equal(string.Empty, options.TextModelName);
        Assert.Equal(string.Empty, options.ImageModelName);
    }

    /// <summary>
    /// Regression guard: ApiVersion must not exist on AzureFoundryOptions.
    /// The Azure AI Foundry /openai/v1 endpoint does not use an api-version query
    /// parameter; the deployment/model is passed in the request body instead.
    /// </summary>
    [Fact]
    public void AzureFoundryOptions_DoesNotExpose_ApiVersionProperty()
    {
        var property = typeof(AzureFoundryOptions)
            .GetProperty("ApiVersion", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

        Assert.Null(property);
    }
}
