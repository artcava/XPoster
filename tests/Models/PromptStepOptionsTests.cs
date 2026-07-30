using XPoster.Models;

namespace XPoster.Tests.Models;

/// <summary>
/// Unit tests for <see cref="PromptStepOptions"/>.
/// Covers construction, required properties, optional properties, immutability,
/// value equality, and role-specific semantics.
/// </summary>
public class PromptStepOptionsTests
{
    // ── Construction ──────────────────────────────────────────────────────────

    [Fact]
    public void PromptStepOptions_RequiredProperties_AreSetCorrectly()
    {
        var options = new PromptStepOptions
        {
            Role = PromptRole.Summary,
            SystemPromptTemplate = "You are a helpful assistant.",
            UserPromptTemplate = "Summarise: {input}"
        };

        Assert.Equal(PromptRole.Summary, options.Role);
        Assert.Equal("You are a helpful assistant.", options.SystemPromptTemplate);
        Assert.Equal("Summarise: {input}", options.UserPromptTemplate);
    }

    [Fact]
    public void PromptStepOptions_OptionalProperties_DefaultToNull()
    {
        var options = new PromptStepOptions
        {
            Role = PromptRole.Summary,
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user"
        };

        Assert.Null(options.Temperature);
        Assert.Null(options.MaxOutputLength);
        Assert.Null(options.MaxTokenBudget);
        Assert.Null(options.InputTextLabel);
        Assert.Null(options.ImageQuantity);
        Assert.Null(options.ImageSize);
    }

    [Fact]
    public void PromptStepOptions_OptionalProperties_AreSetCorrectly()
    {
        var options = new PromptStepOptions
        {
            Role = PromptRole.ImageGeneration,
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user",
            Temperature = 0.7,
            MaxOutputLength = 512,
            MaxTokenBudget = 1024,
            InputTextLabel = "article",
            ImageQuantity = 4,
            ImageSize = "1024x1024"
        };

        Assert.Equal(0.7, options.Temperature);
        Assert.Equal(512, options.MaxOutputLength);
        Assert.Equal(1024, options.MaxTokenBudget);
        Assert.Equal("article", options.InputTextLabel);
        Assert.Equal(4, options.ImageQuantity);
        Assert.Equal("1024x1024", options.ImageSize);
    }

    // ── Immutability ──────────────────────────────────────────────────────────

    [Fact]
    public void PromptStepOptions_IsImmutable_AfterConstruction()
    {
        var options = new PromptStepOptions
        {
            Role = PromptRole.Summary,
            SystemPromptTemplate = "original-sys",
            UserPromptTemplate = "original-user"
        };

        // with-expression must produce a new instance; the original must not change.
        var modified = options with { SystemPromptTemplate = "modified-sys" };

        Assert.Equal("original-sys", options.SystemPromptTemplate);
        Assert.Equal("modified-sys", modified.SystemPromptTemplate);
    }

    [Fact]
    public void PromptStepOptions_WithExpression_PreservesUnchangedProperties()
    {
        var options = new PromptStepOptions
        {
            Role = PromptRole.ImagePromptDerivation,
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user",
            Temperature = 0.5,
            MaxTokenBudget = 800
        };

        var modified = options with { Temperature = 0.9 };

        Assert.Equal(PromptRole.ImagePromptDerivation, modified.Role);
        Assert.Equal("sys", modified.SystemPromptTemplate);
        Assert.Equal("user", modified.UserPromptTemplate);
        Assert.Equal(800, modified.MaxTokenBudget);
        Assert.Equal(0.9, modified.Temperature);
    }

    // ── Value equality ────────────────────────────────────────────────────────

    [Fact]
    public void PromptStepOptions_ValueEquality_SameValues_AreEqual()
    {
        var a = new PromptStepOptions
        {
            Role = PromptRole.Summary,
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user",
            Temperature = 0.5
        };

        var b = new PromptStepOptions
        {
            Role = PromptRole.Summary,
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user",
            Temperature = 0.5
        };

        Assert.Equal(a, b);
    }

    [Fact]
    public void PromptStepOptions_ValueEquality_DifferentRole_AreNotEqual()
    {
        var a = new PromptStepOptions
        {
            Role = PromptRole.Summary,
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user"
        };

        var b = new PromptStepOptions
        {
            Role = PromptRole.ImageGeneration,
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user"
        };

        Assert.NotEqual(a, b);
    }

    [Fact]
    public void PromptStepOptions_ValueEquality_DifferentOptionals_AreNotEqual()
    {
        var a = new PromptStepOptions
        {
            Role = PromptRole.Summary,
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user",
            Temperature = 0.3
        };

        var b = new PromptStepOptions
        {
            Role = PromptRole.Summary,
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user",
            Temperature = 0.9
        };

        Assert.NotEqual(a, b);
    }

    // ── Temperature boundary ──────────────────────────────────────────────────

    [Fact]
    public void PromptStepOptions_Temperature_AcceptsZeroAndOne()
    {
        var atZero = new PromptStepOptions
        {
            Role = PromptRole.Summary,
            SystemPromptTemplate = "s",
            UserPromptTemplate = "u",
            Temperature = 0.0
        };

        var atOne = new PromptStepOptions
        {
            Role = PromptRole.Summary,
            SystemPromptTemplate = "s",
            UserPromptTemplate = "u",
            Temperature = 1.0
        };

        Assert.Equal(0.0, atZero.Temperature);
        Assert.Equal(1.0, atOne.Temperature);
    }

    // ── Role-specific semantics ───────────────────────────────────────────────

    /// <summary>
    /// For the Summary step, MaxOutputLength is intentionally left null in
    /// configuration and resolved at runtime from ISender.MessageMaxLength.
    /// This test documents that expectation explicitly.
    /// </summary>
    [Fact]
    public void PromptStepOptions_SummaryStep_MaxOutputLength_IsNullByConvention()
    {
        // Arrange: simulate how configuration typically populates a Summary step.
        var options = new PromptStepOptions
        {
            Role = PromptRole.Summary,
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user",
            Temperature = 0.7,
            MaxTokenBudget = 2048
            // MaxOutputLength deliberately omitted — resolved from sender at runtime.
        };

        Assert.Null(options.MaxOutputLength);
    }

    /// <summary>
    /// ImageQuantity and ImageSize are only meaningful for the ImageGeneration step.
    /// This test verifies they can be set independently of each other.
    /// </summary>
    [Fact]
    public void PromptStepOptions_ImageGenerationStep_ImageProperties_AreIndependent()
    {
        var withQuantityOnly = new PromptStepOptions
        {
            Role = PromptRole.ImageGeneration,
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user",
            ImageQuantity = 2
        };

        var withSizeOnly = new PromptStepOptions
        {
            Role = PromptRole.ImageGeneration,
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user",
            ImageSize = "512x512"
        };

        Assert.Equal(2, withQuantityOnly.ImageQuantity);
        Assert.Null(withQuantityOnly.ImageSize);

        Assert.Null(withSizeOnly.ImageQuantity);
        Assert.Equal("512x512", withSizeOnly.ImageSize);
    }

    /// <summary>
    /// Non-ImageGeneration steps should carry null image properties.
    /// </summary>
    [Theory]
    [InlineData(PromptRole.Summary)]
    [InlineData(PromptRole.ImagePromptDerivation)]
    public void PromptStepOptions_NonImageSteps_ImageProperties_AreNull(PromptRole role)
    {
        var options = new PromptStepOptions
        {
            Role = role,
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user"
        };

        Assert.Null(options.ImageQuantity);
        Assert.Null(options.ImageSize);
    }

    // ── All roles constructable ───────────────────────────────────────────────

    [Theory]
    [InlineData(PromptRole.Summary)]
    [InlineData(PromptRole.ImagePromptDerivation)]
    [InlineData(PromptRole.ImageGeneration)]
    public void PromptStepOptions_AllRoles_CanBeConstructed(PromptRole role)
    {
        var options = new PromptStepOptions
        {
            Role = role,
            SystemPromptTemplate = "sys",
            UserPromptTemplate = "user"
        };

        Assert.Equal(role, options.Role);
    }
}
