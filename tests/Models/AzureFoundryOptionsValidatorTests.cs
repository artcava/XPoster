using XPoster.Models;

namespace XPoster.Tests.Models;

public class AzureFoundryOptionsValidatorTests
{
    private readonly AzureFoundryOptionsValidator _sut = new();

    private static AzureFoundryOptions ValidOptions() => new()
    {
        Endpoint = "https://myfoundry.openai.azure.com",
        ApiKey = "key",
        DeploymentName = "gpt-4.1-nano",
        ImageDeploymentName = "gpt-image-1"
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
        Assert.Contains(result.Failures!, f => f.Contains(nameof(AzureFoundryOptions.Endpoint)));
        Assert.Contains(result.Failures!, f => f.Contains(nameof(AzureFoundryOptions.ApiKey)));
        Assert.Contains(result.Failures!, f => f.Contains(nameof(AzureFoundryOptions.DeploymentName)));
    }

    [Fact]
    public void Validate_MissingPlaceholders_Fails()
    {
        var options = ValidOptions();
        options.SummarySystemPromptTemplate = "no max chars";
        options.SummaryUserPromptTemplate = "no text";
        options.ImagePromptUserTemplate = "no summary";

        var result = _sut.Validate(null, options);

        Assert.True(result.Failed);
        Assert.Contains(result.Failures!, f => f.Contains("{MaxChars}"));
        Assert.Contains(result.Failures!, f => f.Contains("{Text}"));
        Assert.Contains(result.Failures!, f => f.Contains("{Summary}"));
    }
}
