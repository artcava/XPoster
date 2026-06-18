using XPoster.Abstraction;

namespace XPoster.Tests.Abstraction;

public class AiProviderExtensionsTests
{
    [Theory]
    [InlineData(AiProvider.None, "None")]
    [InlineData(AiProvider.OpenAi, "OpenAI")]
    [InlineData(AiProvider.Perplexity, "Perplexity")]
    [InlineData(AiProvider.AzureFoundry, "Azure Foundry")]
    [InlineData(AiProvider.DeepSeekWithFal, "fal.ai")]
    public void GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(AiProvider provider, string expected)
    {
        Assert.Equal(expected, provider.GetLabel());
    }

    [Fact]
    public void GetLabel_UnknownProvider_ReturnsFallbackToString()
    {
        var unknown = (AiProvider)999;

        Assert.Equal("999", unknown.GetLabel());
    }

    [Theory]
    [InlineData(AiProvider.OpenAi, "OpenAI")]
    [InlineData(AiProvider.AzureFoundry, "Azure Foundry")]
    [InlineData(AiProvider.DeepSeekWithFal, "fal.ai")]
    public void GetLabel_DescriptionDiffersFromEnumName(AiProvider provider, string label)
    {
        // Ensures Description attribute is read, not Enum.ToString()
        Assert.NotEqual(provider.ToString(), label);
        Assert.Equal(label, provider.GetLabel());
    }
}
