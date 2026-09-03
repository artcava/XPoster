using System.Text.Json;
using XPoster.Workflows.Utilities;

namespace XPoster.Tests.Workflows.Utilities;

public class NodeParameterExtractorTests
{
    [Fact]
    public void GetParameter_ReturnsDefault_WhenKeyMissing()
    {
        var params_ = new Dictionary<string, object>();
        var result = NodeParameterExtractor.GetParameter<string>(params_, "missing", "fallback");
        Assert.Equal("fallback", result);
    }

    [Fact]
    public void GetParameter_ReturnsDefault_WhenValueIsNull()
    {
        var params_ = new Dictionary<string, object> { { "k", null! } };
        var result = NodeParameterExtractor.GetParameter<string>(params_, "k", "fb");
        Assert.Equal("fb", result);
    }

    [Fact]
    public void GetParameter_DirectCast_String()
    {
        var params_ = new Dictionary<string, object> { { "k", "hello" } };
        Assert.Equal("hello", NodeParameterExtractor.GetParameter<string>(params_, "k"));
    }

    [Fact]
    public void GetParameter_DirectCast_Int()
    {
        var params_ = new Dictionary<string, object> { { "k", 42 } };
        Assert.Equal(42, NodeParameterExtractor.GetParameter<int>(params_, "k"));
    }

    [Fact]
    public void GetParameter_ConvertChangeType_IntFromString()
    {
        var params_ = new Dictionary<string, object> { { "k", "123" } };
        Assert.Equal(123, NodeParameterExtractor.GetParameter<int>(params_, "k"));
    }

    [Fact]
    public void GetParameter_JsonElement_ToString()
    {
        var json = JsonSerializer.SerializeToElement("test_value");
        var params_ = new Dictionary<string, object> { { "k", json } };
        Assert.Equal("test_value", NodeParameterExtractor.GetParameter<string>(params_, "k"));
    }

    [Fact]
    public void GetParameter_JsonElement_ToInt()
    {
        var json = JsonSerializer.SerializeToElement(99);
        var params_ = new Dictionary<string, object> { { "k", json } };
        Assert.Equal(99, NodeParameterExtractor.GetParameter<int>(params_, "k"));
    }

    [Fact]
    public void GetParameter_JsonElement_ToList()
    {
        var json = JsonSerializer.SerializeToElement(new[] { "a", "b", "c" });
        var params_ = new Dictionary<string, object> { { "k", json } };
        var result = NodeParameterExtractor.GetParameter<List<string>>(params_, "k");
        Assert.NotNull(result);
        Assert.Equal(3, result!.Count);
        Assert.Equal("b", result[1]);
    }

    [Fact]
    public void GetParameter_JsonElement_ToBool()
    {
        var json = JsonSerializer.SerializeToElement(true);
        var params_ = new Dictionary<string, object> { { "k", json } };
        Assert.True(NodeParameterExtractor.GetParameter<bool>(params_, "k"));
    }

    [Fact]
    public void GetParameter_JsonArrayString_ToList()
    {
        var params_ = new Dictionary<string, object>
        {
            { "k", "[\"https://a.xml\",\"https://b.xml\"]" }
        };
        var result = NodeParameterExtractor.GetParameter<List<string>>(params_, "k");
        Assert.NotNull(result);
        Assert.Equal(2, result!.Count);
        Assert.Equal("https://b.xml", result[1]);
    }

    [Fact]
    public void GetParameter_JsonObjectString_ToDictionary()
    {
        var params_ = new Dictionary<string, object> { { "k", "{\"a\":\"1\"}" } };
        var result = NodeParameterExtractor.GetParameter<Dictionary<string, string>>(params_, "k");
        Assert.NotNull(result);
        Assert.Equal("1", result!["a"]);
    }

    [Fact]
    public void GetParameter_PlainString_StillConverts()
    {
        var params_ = new Dictionary<string, object> { { "k", "hello" } };
        Assert.Equal("hello", NodeParameterExtractor.GetParameter<string>(params_, "k"));
    }

    [Fact]
    public void GetParameter_MalformedJson_ForList_ReturnsEmptyOrNull()
    {
        var params_ = new Dictionary<string, object> { { "k", "[broken" } };
        var result = NodeParameterExtractor.GetParameter<List<string>>(params_, "k");
        Assert.True(result == null || result.Count == 0);
    }

    [Fact]
    public void GetParameter_MalformedJsonArrayString_FallsBackToString()
    {
        var params_ = new Dictionary<string, object> { { "k", "[broken" } };
        Assert.Equal("[broken", NodeParameterExtractor.GetParameter<string>(params_, "k"));
    }

    [Fact]
    public void GetParameter_ConversionFailure_ReturnsDefault()
    {
        var params_ = new Dictionary<string, object> { { "k", "not_a_number" } };
        var result = NodeParameterExtractor.GetParameter<int>(params_, "k", -1);
        Assert.Equal(-1, result);
    }

    [Fact]
    public void GetParameter_DefaultValue_UsedWhenMissing()
    {
        var params_ = new Dictionary<string, object>();
        var result = NodeParameterExtractor.GetParameter<int>(params_, "k", 77);
        Assert.Equal(77, result);
    }
}
