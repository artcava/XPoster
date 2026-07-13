using System.Collections.ObjectModel;
using Moq;
using XPoster.Contracts;
using XPoster.Services;

namespace XPoster.Tests.Services;

public sealed class TagReplacementServiceTests
{
    [Fact]
    public void Apply_Replaces_Only_First_Occurrence_For_Each_Word()
    {
        var providerMock = new Mock<ITagReplacementProvider>();
        providerMock
            .Setup(x => x.GetReplacements())
            .Returns(new ReadOnlyDictionary<string, string>(new Dictionary<string, string>
            {
                { "cloud", "#cloud" },
                { "azure", "#azure" }
            }));

        var sut = new TagReplacementService(providerMock.Object);
        var text = "cloud azure cloud Azure CLOUD";

        var result = sut.Apply(text);

        Assert.Equal("#cloud #azure cloud Azure CLOUD", result);
    }

    [Fact]
    public void Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag()
    {
        var providerMock = new Mock<ITagReplacementProvider>();
        providerMock
            .Setup(x => x.GetReplacements())
            .Returns(new ReadOnlyDictionary<string, string>(new Dictionary<string, string>
            {
                { "cloud", "#cloud" }
            }));

        var sut = new TagReplacementService(providerMock.Object);
        var text = "#cloud cloud cloud";

        var result = sut.Apply(text);

        Assert.Equal("#cloud #cloud cloud", result);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace(string text)
    {
        var providerMock = new Mock<ITagReplacementProvider>();

        var sut = new TagReplacementService(providerMock.Object);

        var result = sut.Apply(text);

        Assert.Equal(text, result);
        providerMock.Verify(x => x.GetReplacements(), Times.Never);
    }
}