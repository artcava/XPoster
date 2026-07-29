using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.Tests.Models;

/// <summary>
/// Verifies that every concrete AI provider options class correctly implements
/// <see cref="IAiProviderOptions"/> and exposes the right capabilities through
/// <see cref="AiModelCatalog"/>.
/// </summary>
public class AiProviderOptionsAbstractionTests
{
    // ── OpenAiOptions ─────────────────────────────────────────────────────────

    [Fact]
    public void OpenAiOptions_ImplementsIAiProviderOptions()
    {
        Assert.IsAssignableFrom<IAiProviderOptions>(new OpenAiOptions());
    }

    [Fact]
    public void OpenAiOptions_ModelCatalog_ExposesTextAndImage()
    {
        var options = new OpenAiOptions
        {
            TextModelName = "gpt-4.1-nano",
            ImageModelName = "gpt-image-1.5"
        };

        IAiProviderOptions sut = options;

        Assert.True(sut.ModelCatalog.TryGet(AiModelClass.Text, out var text));
        Assert.Equal("gpt-4.1-nano", text);

        Assert.True(sut.ModelCatalog.TryGet(AiModelClass.Image, out var image));
        Assert.Equal("gpt-image-1.5", image);
    }

    [Fact]
    public void OpenAiOptions_ApiKeyAndEndpoint_AccessibleThroughAbstraction()
    {
        IAiProviderOptions sut = new OpenAiOptions { ApiKey = "k", Endpoint = "https://api.openai.com/v1/" };

        Assert.Equal("k", sut.ApiKey);
        Assert.Equal("https://api.openai.com/v1/", sut.Endpoint);
    }

    // ── AzureFoundryOptions ───────────────────────────────────────────────────

    [Fact]
    public void AzureFoundryOptions_ImplementsIAiProviderOptions()
    {
        Assert.IsAssignableFrom<IAiProviderOptions>(new AzureFoundryOptions());
    }

    [Fact]
    public void AzureFoundryOptions_ModelCatalog_ExposesTextAndImage()
    {
        IAiProviderOptions sut = new AzureFoundryOptions
        {
            TextModelName = "gpt-4.1-nano",
            ImageModelName = "gpt-image-1"
        };

        Assert.True(sut.ModelCatalog.Supports(AiModelClass.Text));
        Assert.True(sut.ModelCatalog.Supports(AiModelClass.Image));
    }

    // ── PerplexityOptions ─────────────────────────────────────────────────────

    [Fact]
    public void PerplexityOptions_ImplementsIAiProviderOptions()
    {
        Assert.IsAssignableFrom<IAiProviderOptions>(new PerplexityOptions());
    }

    [Fact]
    public void PerplexityOptions_ModelCatalog_ExposesTextOnly()
    {
        IAiProviderOptions sut = new PerplexityOptions { TextModelName = "sonar" };

        Assert.True(sut.ModelCatalog.Supports(AiModelClass.Text));
        Assert.False(sut.ModelCatalog.Supports(AiModelClass.Image));
    }

    // ── DeepSeekOptions ───────────────────────────────────────────────────────

    [Fact]
    public void DeepSeekOptions_ImplementsIAiProviderOptions()
    {
        Assert.IsAssignableFrom<IAiProviderOptions>(new DeepSeekOptions());
    }

    [Fact]
    public void DeepSeekOptions_ModelCatalog_ExposesTextOnly()
    {
        IAiProviderOptions sut = new DeepSeekOptions { TextModelName = "deepseek-chat" };

        Assert.True(sut.ModelCatalog.Supports(AiModelClass.Text));
        Assert.False(sut.ModelCatalog.Supports(AiModelClass.Image));
    }

    // ── FalAiOptions ──────────────────────────────────────────────────────────

    [Fact]
    public void FalAiOptions_ImplementsIAiProviderOptions()
    {
        Assert.IsAssignableFrom<IAiProviderOptions>(new FalAiOptions());
    }

    [Fact]
    public void FalAiOptions_ModelCatalog_ExposesImageOnly()
    {
        IAiProviderOptions sut = new FalAiOptions { ImageModelName = "fal-ai/flux/schnell" };

        Assert.False(sut.ModelCatalog.Supports(AiModelClass.Text));
        Assert.True(sut.ModelCatalog.Supports(AiModelClass.Image));
    }

    [Fact]
    public void FalAiOptions_NumInferenceSteps_RemainsOnConcreteClass()
    {
        // Provider-specific settings must not be erased by the shared abstraction.
        var options = new FalAiOptions { NumInferenceSteps = 8 };

        Assert.Equal(8, options.NumInferenceSteps);
    }

    // ── Capability lookup semantics ───────────────────────────────────────────

    [Fact]
    public void ModelCatalog_UnsupportedCapability_GetRequired_Throws()
    {
        IAiProviderOptions sut = new PerplexityOptions { TextModelName = "sonar" };

        Assert.Throws<InvalidOperationException>(() => sut.ModelCatalog.GetRequired(AiModelClass.Image));
    }

    [Fact]
    public void ModelCatalog_EmptyModelName_NotExposedAsSupported()
    {
        // If a concrete property holds an empty string, the catalog must not advertise it.
        IAiProviderOptions sut = new AzureFoundryOptions
        {
            TextModelName = "gpt-4.1-nano",
            ImageModelName = string.Empty    // not configured
        };

        Assert.True(sut.ModelCatalog.Supports(AiModelClass.Text));
        Assert.False(sut.ModelCatalog.Supports(AiModelClass.Image));
    }
}
