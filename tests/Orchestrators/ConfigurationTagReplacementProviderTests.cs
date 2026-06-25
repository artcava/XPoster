using Microsoft.Extensions.Options;
using XPoster.Orchestrators;
using XPoster.Models;

namespace XPoster.Tests.Orchestrators;

public class ConfigurationTagReplacementProviderTests
{
    // --- Happy path ---

    [Fact]
    public void GetReplacements_Should_ReturnConfiguredReplacements_When_OptionsContainsEntries()
    {
        // ARRANGE
        var expected = new Dictionary<string, string>
        {
            { "bitcoin", "#Bitcoin" },
            { "btc",     "#BTC" }
        };
        var options  = Options.Create(new TagReplacementOptions { Replacements = expected });
        var provider = new ConfigurationTagReplacementProvider(options);

        // ACT
        var result = provider.GetReplacements();

        // ASSERT
        Assert.Equal(2, result.Count);
        Assert.Equal("#Bitcoin", result["bitcoin"]);
        Assert.Equal("#BTC",     result["btc"]);
    }

    [Fact]
    public void GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured()
    {
        // ARRANGE
        var replacements = new Dictionary<string, string>
        {
            { "bitcoin",    "#Bitcoin"    },
            { "btc",        "#BTC"        },
            { "blockchain", "#Blockchain" },
            { "fed",        "#FED"        }
        };
        var options  = Options.Create(new TagReplacementOptions { Replacements = replacements });
        var provider = new ConfigurationTagReplacementProvider(options);

        // ACT
        var result = provider.GetReplacements();

        // ASSERT
        Assert.Equal(4, result.Count);
        foreach (var (key, value) in replacements)
            Assert.Equal(value, result[key]);
    }

    // --- Edge cases ---

    [Fact]
    public void GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull()
    {
        // ARRANGE
        var options  = Options.Create(new TagReplacementOptions { Replacements = null! });
        var provider = new ConfigurationTagReplacementProvider(options);

        // ACT
        var result = provider.GetReplacements();

        // ASSERT
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty()
    {
        // ARRANGE
        var options  = Options.Create(new TagReplacementOptions { Replacements = new Dictionary<string, string>() });
        var provider = new ConfigurationTagReplacementProvider(options);

        // ACT
        var result = provider.GetReplacements();

        // ASSERT
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Constructor_Should_Throw_When_OptionsIsNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new ConfigurationTagReplacementProvider(null!));
    }

    [Fact]
    public void GetReplacements_Should_ReturnReadOnlyDictionary()
    {
        // ARRANGE
        var options  = Options.Create(new TagReplacementOptions { Replacements = new Dictionary<string, string> { { "bitcoin", "#Bitcoin" } } });
        var provider = new ConfigurationTagReplacementProvider(options);

        // ACT
        var result = provider.GetReplacements();

        // ASSERT
        Assert.IsAssignableFrom<IReadOnlyDictionary<string, string>>(result);
    }
}
