using XPoster.Models;

namespace XPoster.Tests.Models;

/// <summary>
/// Unit tests for <see cref="PromptRequest"/> and <see cref="ImagePromptRequest"/>.
/// Covers construction, required properties, optional properties, immutability, and inheritance.
/// </summary>
public class PromptRequestTests
{
    // ── PromptRequest ──────────────────────────────────────────────────────────

    [Fact]
    public void PromptRequest_RequiredProperties_AreSetCorrectly()
    {
        var request = new PromptRequest
        {
            InputText = "hello world",
            SystemPromptTemplate = "You are a helpful assistant.",
            UserPromptTemplate = "Summarise: {input}"
        };

        Assert.Equal("hello world", request.InputText);
        Assert.Equal("You are a helpful assistant.", request.SystemPromptTemplate);
        Assert.Equal("Summarise: {input}", request.UserPromptTemplate);
    }

    [Fact]
    public void PromptRequest_OptionalProperties_DefaultToNull()
    {
        var request = new PromptRequest
        {
            InputText = "text",
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user"
        };

        Assert.Null(request.Temperature);
        Assert.Null(request.MaxOutputLength);
        Assert.Null(request.MaxTokenBudget);
        Assert.Null(request.InputTextLabel);
    }

    [Fact]
    public void PromptRequest_OptionalProperties_AreSetCorrectly()
    {
        var request = new PromptRequest
        {
            InputText = "text",
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user",
            Temperature = 0.7,
            MaxOutputLength = 512,
            MaxTokenBudget = 1024,
            InputTextLabel = "article"
        };

        Assert.Equal(0.7, request.Temperature);
        Assert.Equal(512, request.MaxOutputLength);
        Assert.Equal(1024, request.MaxTokenBudget);
        Assert.Equal("article", request.InputTextLabel);
    }

    [Fact]
    public void PromptRequest_IsImmutable_AfterConstruction()
    {
        var request = new PromptRequest
        {
            InputText = "original",
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user"
        };

        // Records expose init-only setters; the with-expression creates a new instance.
        var modified = request with { InputText = "modified" };

        Assert.Equal("original", request.InputText);
        Assert.Equal("modified", modified.InputText);
    }

    [Fact]
    public void PromptRequest_ValueEquality_SameValues_AreEqual()
    {
        var a = new PromptRequest
        {
            InputText = "text",
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user",
            Temperature = 0.5
        };

        var b = new PromptRequest
        {
            InputText = "text",
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user",
            Temperature = 0.5
        };

        Assert.Equal(a, b);
    }

    [Fact]
    public void PromptRequest_ValueEquality_DifferentValues_AreNotEqual()
    {
        var a = new PromptRequest
        {
            InputText = "text A",
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user"
        };

        var b = new PromptRequest
        {
            InputText = "text B",
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user"
        };

        Assert.NotEqual(a, b);
    }

    [Fact]
    public void PromptRequest_Temperature_AcceptsZeroAndOne()
    {
        var atZero = new PromptRequest
        {
            InputText = "t",
            SystemPromptTemplate = "s",
            UserPromptTemplate = "u",
            Temperature = 0.0
        };

        var atOne = new PromptRequest
        {
            InputText = "t",
            SystemPromptTemplate = "s",
            UserPromptTemplate = "u",
            Temperature = 1.0
        };

        Assert.Equal(0.0, atZero.Temperature);
        Assert.Equal(1.0, atOne.Temperature);
    }

    // ── ImagePromptRequest ────────────────────────────────────────────────────

    [Fact]
    public void ImagePromptRequest_InheritsFrom_PromptRequest()
    {
        var request = new ImagePromptRequest
        {
            InputText = "describe an image",
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user"
        };

        Assert.IsAssignableFrom<PromptRequest>(request);
    }

    [Fact]
    public void ImagePromptRequest_ImageProperties_DefaultToNull()
    {
        var request = new ImagePromptRequest
        {
            InputText = "text",
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user"
        };

        Assert.Null(request.ImageQuantity);
        Assert.Null(request.ImageSize);
    }

    [Fact]
    public void ImagePromptRequest_ImageProperties_AreSetCorrectly()
    {
        var request = new ImagePromptRequest
        {
            InputText = "text",
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user",
            ImageQuantity = 4,
            ImageSize = "1024x1024"
        };

        Assert.Equal(4, request.ImageQuantity);
        Assert.Equal("1024x1024", request.ImageSize);
    }

    [Fact]
    public void ImagePromptRequest_IsImmutable_AfterConstruction()
    {
        var request = new ImagePromptRequest
        {
            InputText = "original",
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user",
            ImageQuantity = 1,
            ImageSize = "512x512"
        };

        var modified = request with { ImageQuantity = 2, ImageSize = "1024x1024" };

        Assert.Equal(1, request.ImageQuantity);
        Assert.Equal("512x512", request.ImageSize);
        Assert.Equal(2, modified.ImageQuantity);
        Assert.Equal("1024x1024", modified.ImageSize);
    }

    [Fact]
    public void ImagePromptRequest_ValueEquality_SameValues_AreEqual()
    {
        var a = new ImagePromptRequest
        {
            InputText = "text",
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user",
            ImageQuantity = 2,
            ImageSize = "512x512"
        };

        var b = new ImagePromptRequest
        {
            InputText = "text",
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user",
            ImageQuantity = 2,
            ImageSize = "512x512"
        };

        Assert.Equal(a, b);
    }

    [Fact]
    public void ImagePromptRequest_BaseProperties_AreAccessible()
    {
        var request = new ImagePromptRequest
        {
            InputText = "base text",
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user",
            Temperature = 0.8,
            MaxOutputLength = 256,
            MaxTokenBudget = 512,
            InputTextLabel = "label",
            ImageQuantity = 1,
            ImageSize = "256x256"
        };

        Assert.Equal("base text", request.InputText);
        Assert.Equal("sys", request.SystemPromptTemplate);
        Assert.Equal("user", request.UserPromptTemplate);
        Assert.Equal(0.8, request.Temperature);
        Assert.Equal(256, request.MaxOutputLength);
        Assert.Equal(512, request.MaxTokenBudget);
        Assert.Equal("label", request.InputTextLabel);
    }
}
