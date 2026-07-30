using XPoster.Models;

namespace XPoster.Tests.Models;

/// <summary>
/// Covers <see cref="PromptRole"/> enum definition, integer backing values,
/// string parsing behaviour, and usage as a dictionary discriminator key.
/// </summary>
public class PromptRoleTests
{
    // ------------------------------------------------------------------ //
    //  Member existence                                                    //
    // ------------------------------------------------------------------ //

    [Fact]
    public void PromptRole_HasExactlyThreeMembers()
    {
        var values = Enum.GetValues<PromptRole>();
        Assert.Equal(3, values.Length);
    }

    [Theory]
    [InlineData(PromptRole.Summary)]
    [InlineData(PromptRole.ImagePromptDerivation)]
    [InlineData(PromptRole.ImageGeneration)]
    public void PromptRole_DefinedMember_IsDefined(PromptRole role)
    {
        Assert.True(Enum.IsDefined(role));
    }

    // ------------------------------------------------------------------ //
    //  Backing integer values (contract stability)                         //
    // ------------------------------------------------------------------ //

    [Theory]
    [InlineData(PromptRole.Summary,               0)]
    [InlineData(PromptRole.ImagePromptDerivation, 1)]
    [InlineData(PromptRole.ImageGeneration,       2)]
    public void PromptRole_BackingValue_IsStable(PromptRole role, int expected)
    {
        Assert.Equal(expected, (int)role);
    }

    // ------------------------------------------------------------------ //
    //  String round-trip                                                   //
    // ------------------------------------------------------------------ //

    [Theory]
    [InlineData("Summary",               PromptRole.Summary)]
    [InlineData("ImagePromptDerivation", PromptRole.ImagePromptDerivation)]
    [InlineData("ImageGeneration",       PromptRole.ImageGeneration)]
    public void PromptRole_ParseFromString_ReturnsCorrectMember(string name, PromptRole expected)
    {
        var parsed = Enum.Parse<PromptRole>(name);
        Assert.Equal(expected, parsed);
    }

    [Theory]
    [InlineData("summary",               PromptRole.Summary)]
    [InlineData("imagepromptderivation", PromptRole.ImagePromptDerivation)]
    [InlineData("imagegeneration",       PromptRole.ImageGeneration)]
    public void PromptRole_ParseFromStringIgnoreCase_ReturnsCorrectMember(string name, PromptRole expected)
    {
        var parsed = Enum.Parse<PromptRole>(name, ignoreCase: true);
        Assert.Equal(expected, parsed);
    }

    [Fact]
    public void PromptRole_ParseInvalidName_Throws()
    {
        Assert.Throws<ArgumentException>(() => Enum.Parse<PromptRole>("Unknown"));
    }

    [Fact]
    public void PromptRole_TryParse_ValidName_ReturnsTrue()
    {
        var success = Enum.TryParse<PromptRole>("Summary", out var result);
        Assert.True(success);
        Assert.Equal(PromptRole.Summary, result);
    }

    [Fact]
    public void PromptRole_TryParse_InvalidName_ReturnsFalse()
    {
        var success = Enum.TryParse<PromptRole>("NotARole", out _);
        Assert.False(success);
    }

    // ------------------------------------------------------------------ //
    //  ToString                                                            //
    // ------------------------------------------------------------------ //

    [Theory]
    [InlineData(PromptRole.Summary,               "Summary")]
    [InlineData(PromptRole.ImagePromptDerivation, "ImagePromptDerivation")]
    [InlineData(PromptRole.ImageGeneration,       "ImageGeneration")]
    public void PromptRole_ToString_ReturnsName(PromptRole role, string expected)
    {
        Assert.Equal(expected, role.ToString());
    }

    // ------------------------------------------------------------------ //
    //  Dictionary discriminator (mirrors FeedPromptOptions usage)         //
    // ------------------------------------------------------------------ //

    [Fact]
    public void PromptRole_UsedAsDictionaryKey_LookupSucceeds()
    {
        var map = new Dictionary<PromptRole, string>
        {
            [PromptRole.Summary]               = "summarise",
            [PromptRole.ImagePromptDerivation] = "derive",
            [PromptRole.ImageGeneration]       = "generate",
        };

        Assert.Equal("summarise", map[PromptRole.Summary]);
        Assert.Equal("derive",    map[PromptRole.ImagePromptDerivation]);
        Assert.Equal("generate",  map[PromptRole.ImageGeneration]);
    }

    [Fact]
    public void PromptRole_UndefinedValueNotPresentInMap_ThrowsKeyNotFound()
    {
        var map = new Dictionary<PromptRole, string>
        {
            [PromptRole.Summary] = "summarise",
        };

        Assert.Throws<KeyNotFoundException>(() => _ = map[(PromptRole)99]);
    }
}
