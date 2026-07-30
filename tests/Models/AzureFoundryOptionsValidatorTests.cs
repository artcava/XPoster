using XPoster.Models;

namespace XPoster.Tests.Models;

public class AzureFoundryOptionsValidatorTests
{
    private readonly AzureFoundryOptionsValidator _sut = new();

    private static AzureFoundryOptions ValidOptions() => new()
    {
        Endpoint = "https://myfoundry.openai.azure.com",
        ApiKey = "key",
        TextModelName = "gpt-4.1-nano",
        ImageModelName = "gpt-image-1"
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
        Assert.Contains(result.Failures!, f => f.Contains(nameof(AzureFoundryOptions.Endpoint)));
        Assert.Contains(result.Failures!, f => f.Contains(nameof(AzureFoundryOptions.ApiKey)));
        Assert.Contains(result.Failures!, f => f.Contains(nameof(AzureFoundryOptions.TextModelName)));
    }

}
