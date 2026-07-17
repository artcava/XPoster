using XPoster.Models;

namespace XPoster.Tests.Models;

public class FalAiOptionsValidatorTests
{
    private readonly FalAiOptionsValidator _sut = new();

    private static FalAiOptions ValidOptions() => new()
    {
        ApiKey = "fake-api-key",
        ImageModelName = "fal-ai/flux/schnell"
    };

    [Fact]
    public void Validate_ValidOptions_Succeeds()
    {
        var result = _sut.Validate(null, ValidOptions());

        Assert.True(result.Succeeded);
    }

    [Fact]
    public void Validate_MissingApiKey_Fails()
    {
        var options = ValidOptions();
        options.ApiKey = string.Empty;

        var result = _sut.Validate(null, options);

        Assert.True(result.Failed);
        Assert.Contains(result.Failures!, f => f.Contains(nameof(FalAiOptions.ApiKey)));
    }

    [Fact]
    public void Validate_WhitespaceApiKey_Fails()
    {
        var options = ValidOptions();
        options.ApiKey = "   ";

        var result = _sut.Validate(null, options);

        Assert.True(result.Failed);
        Assert.Contains(result.Failures!, f => f.Contains(nameof(FalAiOptions.ApiKey)));
    }

    [Fact]
    public void Validate_MissingModelId_Fails()
    {
        var options = ValidOptions();
        options.ImageModelName = string.Empty;

        var result = _sut.Validate(null, options);

        Assert.True(result.Failed);
        Assert.Contains(result.Failures!, f => f.Contains(nameof(FalAiOptions.ImageModelName)));
    }

    [Fact]
    public void Validate_WhitespaceModelId_Fails()
    {
        var options = ValidOptions();
        options.ImageModelName = "   ";

        var result = _sut.Validate(null, options);

        Assert.True(result.Failed);
        Assert.Contains(result.Failures!, f => f.Contains(nameof(FalAiOptions.ImageModelName)));
    }

    [Theory]
    [InlineData("fal-ai/flux?version=1")]  // query string delimiter
    [InlineData("fal-ai/flux schnell")]     // space
    [InlineData("fal-ai/flux#anchor")]      // fragment delimiter
    [InlineData("fal-ai/flux[turbo]")]      // square bracket
    public void Validate_ImageModelNameWithUnsafeCharacters_Fails(string modelId)
    {
        var options = ValidOptions();
        options.ImageModelName = modelId;

        var result = _sut.Validate(null, options);

        Assert.True(result.Failed);
        Assert.Contains(result.Failures!, f => f.Contains(nameof(FalAiOptions.ImageModelName)));
    }

    [Theory]
    [InlineData("fal-ai/flux/schnell")]          // default — slashes allowed
    [InlineData("fal-ai/stable-diffusion-v3")]   // hyphens
    [InlineData("fal-ai/model_v2.0")]            // underscores and dot
    [InlineData("provider/org/model123")]         // multi-segment alphanumeric
    public void Validate_ImageModelNameWithAllowedSpecialChars_Succeeds(string modelId)
    {
        var options = ValidOptions();
        options.ImageModelName = modelId;

        var result = _sut.Validate(null, options);

        Assert.True(result.Succeeded);
    }

    [Fact]
    public void Validate_BothRequiredFieldsMissing_ReportsBothFailures()
    {
        var options = ValidOptions();
        options.ApiKey = string.Empty;
        options.ImageModelName = string.Empty;

        var result = _sut.Validate(null, options);

        Assert.True(result.Failed);
        Assert.Contains(result.Failures!, f => f.Contains(nameof(FalAiOptions.ApiKey)));
        Assert.Contains(result.Failures!, f => f.Contains(nameof(FalAiOptions.ImageModelName)));
    }
}
