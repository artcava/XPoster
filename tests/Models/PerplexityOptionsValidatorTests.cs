using XPoster.Models;

namespace XPoster.Tests.Models;

public class PerplexityOptionsValidatorTests
{
    private static PerplexityOptions ValidOptions() => new()
    {
        Endpoint                    = "https://api.perplexity.ai",
        ApiKey                      = "my-key",
        DeploymentName              = "sonar",
        SummarySystemPromptTemplate = "Keep under {MaxChars} chars.",
        SummaryUserPromptTemplate   = "Summarize: {Text}",
        ImagePromptSystemTemplate   = "You generate image prompts.",
        ImagePromptUserTemplate     = "Image for: {Summary}"
    };

    private static readonly PerplexityOptionsValidator Validator = new();

    [Fact]
    public void Validate_WithValidOptions_ReturnsSuccess()
    {
        var result = Validator.Validate(null, ValidOptions());

        Assert.True(result.Succeeded);
    }

    [Fact]
    public void Validate_WhenEndpointIsEmpty_ReturnsFailed()
    {
        var opts = ValidOptions();
        opts.Endpoint = string.Empty;

        var result = Validator.Validate(null, opts);

        Assert.True(result.Failed);
        Assert.Contains(result.Failures!, f => f.Contains(nameof(PerplexityOptions.Endpoint)));
    }

    [Fact]
    public void Validate_WhenApiKeyIsEmpty_ReturnsFailed()
    {
        var opts = ValidOptions();
        opts.ApiKey = string.Empty;

        var result = Validator.Validate(null, opts);

        Assert.True(result.Failed);
        Assert.Contains(result.Failures!, f => f.Contains(nameof(PerplexityOptions.ApiKey)));
    }

    [Fact]
    public void Validate_WhenDeploymentNameIsEmpty_ReturnsFailed()
    {
        var opts = ValidOptions();
        opts.DeploymentName = string.Empty;

        var result = Validator.Validate(null, opts);

        Assert.True(result.Failed);
        Assert.Contains(result.Failures!, f => f.Contains(nameof(PerplexityOptions.DeploymentName)));
    }

    [Fact]
    public void Validate_WhenSummarySystemPromptMissingMaxChars_ReturnsFailed()
    {
        var opts = ValidOptions();
        opts.SummarySystemPromptTemplate = "No placeholder here.";

        var result = Validator.Validate(null, opts);

        Assert.True(result.Failed);
        Assert.Contains(result.Failures!, f => f.Contains(nameof(PerplexityOptions.SummarySystemPromptTemplate)));
    }

    [Fact]
    public void Validate_WhenSummaryUserPromptMissingText_ReturnsFailed()
    {
        var opts = ValidOptions();
        opts.SummaryUserPromptTemplate = "No placeholder here.";

        var result = Validator.Validate(null, opts);

        Assert.True(result.Failed);
        Assert.Contains(result.Failures!, f => f.Contains(nameof(PerplexityOptions.SummaryUserPromptTemplate)));
    }

    [Fact]
    public void Validate_WhenImagePromptUserTemplateMissingSummary_ReturnsFailed()
    {
        var opts = ValidOptions();
        opts.ImagePromptUserTemplate = "No placeholder here.";

        var result = Validator.Validate(null, opts);

        Assert.True(result.Failed);
        Assert.Contains(result.Failures!, f => f.Contains(nameof(PerplexityOptions.ImagePromptUserTemplate)));
    }

    [Fact]
    public void Validate_WhenImagePromptSystemTemplateHasNoPlaceholder_ReturnsSuccess()
    {
        // ImagePromptSystemTemplate has no required placeholder — intentional design.
        var opts = ValidOptions();
        opts.ImagePromptSystemTemplate = "No placeholder required here.";

        var result = Validator.Validate(null, opts);

        Assert.True(result.Succeeded);
    }

    [Fact]
    public void Validate_WithMultipleInvalidFields_ReturnsAllFailures()
    {
        var opts = ValidOptions();
        opts.Endpoint       = string.Empty;
        opts.ApiKey         = string.Empty;
        opts.DeploymentName = string.Empty;

        var result = Validator.Validate(null, opts);

        Assert.True(result.Failed);
        Assert.True(result.Failures!.Count() >= 3);
    }
}
