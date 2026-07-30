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
        Assert.Equal("deepseek-chat", options.TextModelName);
        Assert.Equal(string.Empty, options.ApiKey);
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
