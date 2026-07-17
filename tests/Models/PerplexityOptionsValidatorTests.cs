using XPoster.Models;

namespace XPoster.Tests.Models;

public class PerplexityOptionsValidatorTests
{
    private static PerplexityOptions ValidOptions() => new()
    {
        Endpoint = "https://api.perplexity.ai",
        ApiKey = "my-key",
        TextModelName = "sonar",
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
    public void Validate_WhenTextModelNameIsEmpty_ReturnsFailed()
    {
        var opts = ValidOptions();
        opts.TextModelName = string.Empty;

        var result = Validator.Validate(null, opts);

        Assert.True(result.Failed);
        Assert.Contains(result.Failures!, f => f.Contains(nameof(PerplexityOptions.TextModelName)));
    }

    [Fact]
    public void Validate_WithMultipleInvalidFields_ReturnsAllFailures()
    {
        var opts = ValidOptions();
        opts.Endpoint = string.Empty;
        opts.ApiKey = string.Empty;
        opts.TextModelName = string.Empty;

        var result = Validator.Validate(null, opts);

        Assert.True(result.Failed);
        Assert.True(result.Failures!.Count() >= 3);
    }
}
