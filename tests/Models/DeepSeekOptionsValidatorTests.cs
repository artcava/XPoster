using XPoster.Models;

namespace XPoster.Tests.Models;

public class DeepSeekOptionsValidatorTests
{
    private readonly DeepSeekOptionsValidator _sut = new();

    private static DeepSeekOptions ValidOptions() => new()
    {
        Endpoint = "https://api.deepseek.com",
        ApiKey = "fake-key",
        DeploymentName = "deepseek-chat",
        SummarySystemPromptTemplate = "Keep under {MaxChars} chars.",
        SummaryUserPromptTemplate = "Summarize: {Text}",
        ImagePromptUserTemplate = "Image prompt for: {Summary}"
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
        options.DeploymentName = string.Empty;

        var result = _sut.Validate(null, options);

        Assert.True(result.Failed);
        Assert.Contains(result.Failures!, f => f.Contains(nameof(DeepSeekOptions.Endpoint)));
        Assert.Contains(result.Failures!, f => f.Contains(nameof(DeepSeekOptions.ApiKey)));
        Assert.Contains(result.Failures!, f => f.Contains(nameof(DeepSeekOptions.DeploymentName)));
    }

    [Fact]
    public void Validate_MissingPlaceholders_Fails()
    {
        var options = ValidOptions();
        options.SummarySystemPromptTemplate = "no max chars here";
        options.SummaryUserPromptTemplate = "no text here";
        options.ImagePromptUserTemplate = "no summary here";

        var result = _sut.Validate(null, options);

        Assert.True(result.Failed);
        Assert.Contains(result.Failures!, f => f.Contains("{MaxChars}"));
        Assert.Contains(result.Failures!, f => f.Contains("{Text}"));
        Assert.Contains(result.Failures!, f => f.Contains("{Summary}"));
    }

    [Fact]
    public void Validate_AccumulatesAllFailures_WhenMultipleRulesViolated()
    {
        var options = ValidOptions();
        options.Endpoint = "  ";
        options.ApiKey = "  ";
        options.SummarySystemPromptTemplate = "no placeholder";

        var result = _sut.Validate(null, options);

        Assert.True(result.Failed);
        Assert.True(result.Failures!.Count() >= 3);
    }
}
