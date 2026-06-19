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
        Assert.Equal(string.Empty, options.DeploymentName);
        Assert.Equal(string.Empty, options.ImageDeploymentName);
        Assert.Equal(0.5, options.SummaryTemperature);
        Assert.Equal(5, options.SummaryMaxTokensPerChar);
        Assert.Equal(50, options.SummarySafetyMarginChars);
        Assert.Equal(60, options.ImagePromptMaxTokens);
        Assert.Equal(0.7, options.ImagePromptTemperature);
    }

    [Fact]
    public void AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder()
    {
        var options = new AzureFoundryOptions();
        Assert.Contains("{MaxChars}", options.SummarySystemPromptTemplate);
    }

    [Fact]
    public void AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder()
    {
        var options = new AzureFoundryOptions();
        Assert.Contains("{Text}", options.SummaryUserPromptTemplate);
    }

    [Fact]
    public void AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder()
    {
        var options = new AzureFoundryOptions();
        Assert.Contains("{Summary}", options.ImagePromptUserTemplate);
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
