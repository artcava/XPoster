using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XPoster.Extensions;
using XPoster.Models;

namespace XPoster.Tests.Models;

/// <summary>
/// Verifies the per-provider *OptionsExtensions classes introduced in issue #189.
/// Each test class checks:
/// <list type="bullet">
///   <item><description><c>SectionName</c> holds the expected configuration key.</description></item>
///   <item><description><c>Add*Options()</c> binds <typeparamref name="T"/> from the correct section.</description></item>
///   <item><description><c>Add*Options()</c> registers <see cref="IValidateOptions{T}"/> for startup validation.</description></item>
/// </list>
/// </summary>
public class OptionsExtensionsTests
{
    // ── Helpers ───────────────────────────────────────────────────────────────

    private static IConfiguration BuildConfig(string section, Dictionary<string, string?> values)
    {
        var prefixed = values.ToDictionary(kv => $"{section}:{kv.Key}", kv => kv.Value);
        return new ConfigurationBuilder()
            .AddInMemoryCollection(prefixed)
            .Build();
    }

    private static ServiceProvider BuildProvider(
        IConfiguration config,
        Action<IServiceCollection, IConfiguration> register)
    {
        var services = new ServiceCollection();
        register(services, config);
        return services.BuildServiceProvider();
    }

    // ── OpenAI ────────────────────────────────────────────────────────────────

    public class OpenAiOptionsExtensionsTests
    {
        [Fact]
        public void SectionName_IsOpenAI()
        {
            Assert.Equal("OpenAI", OpenAiOptions.SectionName);
        }

        [Fact]
        public void AddOpenAiOptions_BindsOptionsFromCorrectSection()
        {
            // OpenAiOptionsValidator does not enforce ApiKey as required;
            // all prompt templates already ship with valid placeholder defaults.
            var config = BuildConfig(OpenAiOptions.SectionName,
                new() { ["ApiKey"] = "test-key" });

            using var provider = BuildProvider(config,
                (svc, cfg) => svc.AddAiProviderOptions(cfg));

            var options = provider.GetRequiredService<IOptions<OpenAiOptions>>().Value;
            Assert.Equal("test-key", options.ApiKey);
        }

        [Fact]
        public void AddOpenAiOptions_RegistersValidator()
        {
            var config = BuildConfig(OpenAiOptions.SectionName, new());

            using var provider = BuildProvider(config,
                (svc, cfg) => svc.AddAiProviderOptions(cfg));

            var validator = provider.GetService<IValidateOptions<OpenAiOptions>>();
            Assert.NotNull(validator);
            Assert.IsType<OpenAiOptionsValidator>(validator);
        }
    }

    // ── AzureFoundry ──────────────────────────────────────────────────────────

    public class AzureFoundryOptionsExtensionsTests
    {
        [Fact]
        public void SectionName_IsAzureFoundry()
        {
            Assert.Equal("AzureFoundry", AzureFoundryOptions.SectionName);
        }

        [Fact]
        public void AddAzureFoundryOptions_BindsOptionsFromCorrectSection()
        {
            // Validator requires Endpoint, ApiKey and DeploymentName to be non-empty.
            var config = BuildConfig(AzureFoundryOptions.SectionName, new()
            {
                ["Endpoint"] = "https://myfoundry.openai.azure.com",
                ["ApiKey"] = "az-key",
                ["TextModelName"] = "gpt-4.1-nano",
                ["ImageModelName"] = "gpt-image-1",
            });

            using var provider = BuildProvider(config,
                (svc, cfg) => svc.AddAiProviderOptions(cfg));

            var options = provider.GetRequiredService<IOptions<AzureFoundryOptions>>().Value;
            Assert.Equal("az-key", options.ApiKey);
            Assert.Equal("https://myfoundry.openai.azure.com", options.Endpoint);
        }

        [Fact]
        public void AddAzureFoundryOptions_RegistersValidator()
        {
            var config = BuildConfig(AzureFoundryOptions.SectionName, new());

            using var provider = BuildProvider(config,
                (svc, cfg) => svc.AddAiProviderOptions(cfg));

            var validator = provider.GetService<IValidateOptions<AzureFoundryOptions>>();
            Assert.NotNull(validator);
            Assert.IsType<AzureFoundryOptionsValidator>(validator);
        }
    }

    // ── DeepSeek ──────────────────────────────────────────────────────────────

    public class DeepSeekOptionsExtensionsTests
    {
        [Fact]
        public void SectionName_IsDeepSeek()
        {
            Assert.Equal("DeepSeek", DeepSeekOptions.SectionName);
        }

        [Fact]
        public void AddDeepSeekOptions_BindsOptionsFromCorrectSection()
        {
            // Validator requires Endpoint, ApiKey and DeploymentName to be non-empty.
            var config = BuildConfig(DeepSeekOptions.SectionName, new()
            {
                ["Endpoint"] = "https://api.deepseek.com",
                ["ApiKey"] = "ds-key",
                ["DeploymentName"] = "deepseek-chat",
            });

            using var provider = BuildProvider(config,
                (svc, cfg) => svc.AddAiProviderOptions(cfg));

            var options = provider.GetRequiredService<IOptions<DeepSeekOptions>>().Value;
            Assert.Equal("ds-key", options.ApiKey);
            Assert.Equal("https://api.deepseek.com", options.Endpoint);
        }

        [Fact]
        public void AddDeepSeekOptions_RegistersValidator()
        {
            var config = BuildConfig(DeepSeekOptions.SectionName, new());

            using var provider = BuildProvider(config,
                (svc, cfg) => svc.AddAiProviderOptions(cfg));

            var validator = provider.GetService<IValidateOptions<DeepSeekOptions>>();
            Assert.NotNull(validator);
            Assert.IsType<DeepSeekOptionsValidator>(validator);
        }
    }

    // ── FalAi ─────────────────────────────────────────────────────────────────

    public class FalAiOptionsExtensionsTests
    {
        [Fact]
        public void SectionName_IsFalAi()
        {
            Assert.Equal("FalAi", FalAiOptions.SectionName);
        }

        [Fact]
        public void AddFalAiOptions_BindsOptionsFromCorrectSection()
        {
            // Validator requires ApiKey and ModelId to be non-empty.
            var config = BuildConfig(FalAiOptions.SectionName, new()
            {
                ["ApiKey"] = "fal-key",
                ["ImageModelName"] = "fal-ai/flux/schnell",
            });

            using var provider = BuildProvider(config,
                (svc, cfg) => svc.AddAiProviderOptions(cfg));

            var options = provider.GetRequiredService<IOptions<FalAiOptions>>().Value;
            Assert.Equal("fal-key", options.ApiKey);
            Assert.Equal("fal-ai/flux/schnell", options.ImageModelName);
        }

        [Fact]
        public void AddFalAiOptions_RegistersValidator()
        {
            var config = BuildConfig(FalAiOptions.SectionName, new());

            using var provider = BuildProvider(config,
                (svc, cfg) => svc.AddAiProviderOptions(cfg));

            var validator = provider.GetService<IValidateOptions<FalAiOptions>>();
            Assert.NotNull(validator);
            Assert.IsType<FalAiOptionsValidator>(validator);
        }
    }

    // ── Perplexity ────────────────────────────────────────────────────────────

    public class PerplexityOptionsExtensionsTests
    {
        [Fact]
        public void SectionName_IsPerplexity()
        {
            Assert.Equal("Perplexity", PerplexityOptions.SectionName);
        }

        [Fact]
        public void AddPerplexityOptions_BindsOptionsFromCorrectSection()
        {
            // Validator requires Endpoint, ApiKey and DeploymentName to be non-empty.
            var config = BuildConfig(PerplexityOptions.SectionName, new()
            {
                ["Endpoint"] = "https://api.perplexity.ai",
                ["ApiKey"] = "px-key",
                ["DeploymentName"] = "sonar",
            });

            using var provider = BuildProvider(config,
                (svc, cfg) => svc.AddAiProviderOptions(cfg));

            var options = provider.GetRequiredService<IOptions<PerplexityOptions>>().Value;
            Assert.Equal("px-key", options.ApiKey);
            Assert.Equal("https://api.perplexity.ai", options.Endpoint);
        }

        [Fact]
        public void AddPerplexityOptions_RegistersValidator()
        {
            var config = BuildConfig(PerplexityOptions.SectionName, new());

            using var provider = BuildProvider(config,
                (svc, cfg) => svc.AddAiProviderOptions(cfg));

            var validator = provider.GetService<IValidateOptions<PerplexityOptions>>();
            Assert.NotNull(validator);
            Assert.IsType<PerplexityOptionsValidator>(validator);
        }
    }
}
