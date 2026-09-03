using Microsoft.Extensions.Configuration;
using XPoster.Workflows.Services;

namespace XPoster.Tests.Workflows.Services;

public class ConfigurationStepOptionsResolverTests
{
    private static IConfiguration BuildConfig(string stepKey, Dictionary<string, string?>? extra = null)
    {
        var values = new Dictionary<string, string?>
        {
            [$"PromptSteps:{stepKey}:SystemPromptTemplate"] = "System {Template}",
            [$"PromptSteps:{stepKey}:UserPromptTemplate"] = "User {Text}",
            [$"PromptSteps:{stepKey}:Temperature"] = "0.5",
            [$"PromptSteps:{stepKey}:MaxTokenBudget"] = "600",
            [$"PromptSteps:{stepKey}:InputTextLabel"] = "{Text}",
        };

        if (extra != null)
        {
            foreach (var kv in extra)
                values[kv.Key] = kv.Value;
        }

        var builder = new ConfigurationBuilder();
        builder.AddInMemoryCollection(values);
        return builder.Build();
    }

    [Fact]
    public void Resolve_ReturnsStepOptions_WhenSectionExists()
    {
        var config = BuildConfig("Feed.Summary");
        var resolver = new ConfigurationStepOptionsResolver(config);

        var result = resolver.Resolve("Feed.Summary");

        Assert.NotNull(result);
        Assert.Equal("System {Template}", result.SystemPromptTemplate);
        Assert.Equal("User {Text}", result.UserPromptTemplate);
        Assert.Equal(0.5, result.Temperature);
        Assert.Equal(600, result.MaxTokenBudget);
        Assert.Equal("{Text}", result.InputTextLabel);
        Assert.Null(result.MaxOutputLength);
        Assert.Null(result.ImageQuantity);
        Assert.Null(result.ImageSize);
    }

    [Fact]
    public void Resolve_BindsImageProperties_WhenPresent()
    {
        var values = new Dictionary<string, string?>
        {
            [$"PromptSteps:Feed.ImageGeneration:ImageQuantity"] = "1",
            [$"PromptSteps:Feed.ImageGeneration:ImageSize"] = "1024x1024",
        };
        var config = BuildConfig("Feed.ImageGeneration", values);
        var resolver = new ConfigurationStepOptionsResolver(config);

        var result = resolver.Resolve("Feed.ImageGeneration");

        Assert.Equal(1, result.ImageQuantity);
        Assert.Equal("1024x1024", result.ImageSize);
    }

    [Fact]
    public void Resolve_Throws_WhenStepMissing()
    {
        var config = BuildConfig("Existing");
        var resolver = new ConfigurationStepOptionsResolver(config);

        var ex = Assert.Throws<InvalidOperationException>(() => resolver.Resolve("NonExistent"));
        Assert.Contains("NonExistent", ex.Message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Resolve_Throws_OnNullOrWhitespaceStepId(string? stepId)
    {
        var config = BuildConfig("Any");
        var resolver = new ConfigurationStepOptionsResolver(config);

        Assert.ThrowsAny<ArgumentException>(() => resolver.Resolve(stepId!));
    }

    [Fact]
    public void Resolve_BindsMaxOutputLength_WhenPresent()
    {
        var values = new Dictionary<string, string?>
        {
            [$"PromptSteps:S.Output:MaxOutputLength"] = "250",
        };
        var config = BuildConfig("S.Output", values);
        var resolver = new ConfigurationStepOptionsResolver(config);

        var result = resolver.Resolve("S.Output");

        Assert.Equal(250, result.MaxOutputLength);
    }
}