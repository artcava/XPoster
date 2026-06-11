using XPoster.Models;

namespace XPoster.Tests.Models;

/// <summary>
/// Covers default values and shape of <see cref="DeepSeekOptions"/>.
/// Also acts as a regression test for issue #126: ApiVersion must not exist.
/// </summary>
public class DeepSeekOptionsTests
{
    [Fact]
    public void DeepSeekOptions_Defaults_AreCorrect()
    {
        var options = new DeepSeekOptions();

        Assert.Equal("https://api.deepseek.com", options.Endpoint);
        Assert.Equal("deepseek-chat", options.DeploymentName);
        Assert.Equal(string.Empty, options.ApiKey);
        Assert.Equal(0.5, options.SummaryTemperature);
        Assert.Equal(5, options.SummaryMaxTokensPerChar);
        Assert.Equal(50, options.SummarySafetyMarginChars);
        Assert.Equal(60, options.ImagePromptMaxTokens);
        Assert.Equal(0.7, options.ImagePromptTemperature);
    }

    [Fact]
    public void DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder()
    {
        var options = new DeepSeekOptions();
        Assert.Contains("{MaxChars}", options.SummarySystemPromptTemplate);
    }

    [Fact]
    public void DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder()
    {
        var options = new DeepSeekOptions();
        Assert.Contains("{Text}", options.SummaryUserPromptTemplate);
    }

    [Fact]
    public void DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder()
    {
        var options = new DeepSeekOptions();
        Assert.Contains("{Summary}", options.ImagePromptUserTemplate);
    }

    /// <summary>
    /// Regression test for issue #126: ApiVersion was copied from AzureFoundryOptions
    /// but is not needed by the DeepSeek API and must not exist on this class.
    /// </summary>
    [Fact]
    public void DeepSeekOptions_DoesNotExpose_ApiVersionProperty()
    {
        var property = typeof(DeepSeekOptions)
            .GetProperty("ApiVersion", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

        Assert.Null(property);
    }
}
