using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using XPoster.Extensions;
using XPoster.Models;

namespace XPoster.Tests.Extensions;

/// <summary>
/// Verifies the centralized <see cref="AiProviderOptionsCompositionExtensions.AddAiProviderOptions"/>
/// entrypoint registers all AI provider option bindings and validators in a single call.
/// </summary>
public class AddAiProviderOptionsTests
{
    // ── Helpers ───────────────────────────────────────────────────────────────

    private static IConfiguration BuildAllProvidersConfig() =>
        new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["OpenAI:ApiKey"] = "openai-key",
                ["OpenAI:Endpoint"] = "https://api.openai.com/v1/",
                ["OpenAI:TextModelName"] = "gpt-4.1-nano",
                ["OpenAI:ImageModelName"] = "gpt-image-1.5",

                ["AzureFoundry:ApiKey"] = "az-key",
                ["AzureFoundry:Endpoint"] = "https://foundry.example.com",
                ["AzureFoundry:TextModelName"] = "gpt-4.1-nano",
                ["AzureFoundry:ImageModelName"] = "gpt-image-1",

                ["DeepSeek:ApiKey"] = "ds-key",
                ["DeepSeek:Endpoint"] = "https://api.deepseek.com",
                ["DeepSeek:TextModelName"] = "deepseek-chat",

                ["FalAi:ApiKey"] = "fal-key",
                ["FalAi:Endpoint"] = "https://fal.run",
                ["FalAi:ImageModelName"] = "fal-ai/flux/schnell",

                ["Perplexity:ApiKey"] = "pplx-key",
                ["Perplexity:Endpoint"] = "https://api.perplexity.ai",
                ["Perplexity:TextModelName"] = "sonar",
            })
            .Build();

    // ── Registration ──────────────────────────────────────────────────────────

    [Fact]
    public void AddAiProviderOptions_RegistersAllFiveOptionTypes()
    {
        var services = new ServiceCollection();
        services.AddAiProviderOptions(BuildAllProvidersConfig());
        using var provider = services.BuildServiceProvider();

        Assert.NotNull(provider.GetService<IOptions<OpenAiOptions>>());
        Assert.NotNull(provider.GetService<IOptions<AzureFoundryOptions>>());
        Assert.NotNull(provider.GetService<IOptions<DeepSeekOptions>>());
        Assert.NotNull(provider.GetService<IOptions<FalAiOptions>>());
        Assert.NotNull(provider.GetService<IOptions<PerplexityOptions>>());
    }

    [Fact]
    public void AddAiProviderOptions_RegistersAllFiveValidators()
    {
        var services = new ServiceCollection();
        services.AddAiProviderOptions(BuildAllProvidersConfig());
        using var provider = services.BuildServiceProvider();

        Assert.NotNull(provider.GetService<IValidateOptions<OpenAiOptions>>());
        Assert.NotNull(provider.GetService<IValidateOptions<AzureFoundryOptions>>());
        Assert.NotNull(provider.GetService<IValidateOptions<DeepSeekOptions>>());
        Assert.NotNull(provider.GetService<IValidateOptions<FalAiOptions>>());
        Assert.NotNull(provider.GetService<IValidateOptions<PerplexityOptions>>());
    }

    [Fact]
    public void AddAiProviderOptions_ReturnsSameServiceCollection()
    {
        var services = new ServiceCollection();

        var returned = services.AddAiProviderOptions(BuildAllProvidersConfig());

        Assert.Same(services, returned);
    }

    // ── Binding ───────────────────────────────────────────────────────────────

    [Fact]
    public void AddAiProviderOptions_BindsOpenAiOptions_FromCorrectSection()
    {
        var services = new ServiceCollection();
        services.AddAiProviderOptions(BuildAllProvidersConfig());
        using var provider = services.BuildServiceProvider();

        var options = provider.GetRequiredService<IOptions<OpenAiOptions>>().Value;

        Assert.Equal("openai-key", options.ApiKey);
        Assert.Equal("gpt-4.1-nano", options.TextModelName);
        Assert.Equal("gpt-image-1.5", options.ImageModelName);
    }

    [Fact]
    public void AddAiProviderOptions_BindsAzureFoundryOptions_FromCorrectSection()
    {
        var services = new ServiceCollection();
        services.AddAiProviderOptions(BuildAllProvidersConfig());
        using var provider = services.BuildServiceProvider();

        var options = provider.GetRequiredService<IOptions<AzureFoundryOptions>>().Value;

        Assert.Equal("az-key", options.ApiKey);
        Assert.Equal("https://foundry.example.com", options.Endpoint);
    }

    [Fact]
    public void AddAiProviderOptions_BindsDeepSeekOptions_FromCorrectSection()
    {
        var services = new ServiceCollection();
        services.AddAiProviderOptions(BuildAllProvidersConfig());
        using var provider = services.BuildServiceProvider();

        var options = provider.GetRequiredService<IOptions<DeepSeekOptions>>().Value;

        Assert.Equal("ds-key", options.ApiKey);
        Assert.Equal("deepseek-chat", options.TextModelName);
    }

    [Fact]
    public void AddAiProviderOptions_BindsFalAiOptions_FromCorrectSection()
    {
        var services = new ServiceCollection();
        services.AddAiProviderOptions(BuildAllProvidersConfig());
        using var provider = services.BuildServiceProvider();

        var options = provider.GetRequiredService<IOptions<FalAiOptions>>().Value;

        Assert.Equal("fal-key", options.ApiKey);
        Assert.Equal("fal-ai/flux/schnell", options.ImageModelName);
    }

    [Fact]
    public void AddAiProviderOptions_BindsPerplexityOptions_FromCorrectSection()
    {
        var services = new ServiceCollection();
        services.AddAiProviderOptions(BuildAllProvidersConfig());
        using var provider = services.BuildServiceProvider();

        var options = provider.GetRequiredService<IOptions<PerplexityOptions>>().Value;

        Assert.Equal("pplx-key", options.ApiKey);
        Assert.Equal("sonar", options.TextModelName);
    }

    // ── No duplicate registrations ────────────────────────────────────────────

    [Fact]
    public void AddAiProviderOptions_DoesNotDuplicateValidatorRegistrations_WhenCalledOnce()
    {
        var services = new ServiceCollection();
        services.AddAiProviderOptions(BuildAllProvidersConfig());

        var openAiValidators = services
            .Count(sd => sd.ServiceType == typeof(IValidateOptions<OpenAiOptions>));

        Assert.Equal(1, openAiValidators);
    }
}
