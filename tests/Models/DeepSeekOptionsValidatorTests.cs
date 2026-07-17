using XPoster.Models;

namespace XPoster.Tests.Models;

public class DeepSeekOptionsValidatorTests
{
    private readonly DeepSeekOptionsValidator _sut = new();

    private static DeepSeekOptions ValidOptions() => new()
    {
        Endpoint = "https://api.deepseek.com",
        ApiKey = "fake-key",
        TextModelName = "deepseek-chat"
    };

    [Fact]
    public void Validate_ValidOptions_Succeeds()
    {
        var result = _sut.Validate(null, ValidOptions());

        Assert.True(result.Succeeded);
    }

    [Fact]
    public void Validate_MissingRequiredProperties_Fails()
    {
        var options = ValidOptions();
        options.Endpoint = string.Empty;
        options.ApiKey = string.Empty;
        options.TextModelName = string.Empty;

        var result = _sut.Validate(null, options);

        Assert.True(result.Failed);
        Assert.Contains(result.Failures!, f => f.Contains(nameof(DeepSeekOptions.Endpoint)));
        Assert.Contains(result.Failures!, f => f.Contains(nameof(DeepSeekOptions.ApiKey)));
        Assert.Contains(result.Failures!, f => f.Contains(nameof(DeepSeekOptions.TextModelName)));
    }

    [Fact]
    public void Validate_AccumulatesAllFailures_WhenMultipleRulesViolated()
    {
        var options = ValidOptions();
        options.Endpoint = "  ";
        options.ApiKey = "  ";
    
        var result = _sut.Validate(null, options);

        Assert.True(result.Failed);
        Assert.True(result.Failures!.Count() >= 2);
    }
}
