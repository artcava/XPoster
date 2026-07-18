using XPoster.Models;

namespace XPoster.Tests.Models;

/// <summary>
/// Unit tests for <see cref="FeedPromptOptions"/>.
/// Covers construction, Steps collection contract, GetStep lookup,
/// GetStep error paths, immutability, and value equality.
/// </summary>
public class FeedPromptOptionsTests
{
    // ── Helpers ───────────────────────────────────────────────────────────────

    private static PromptStepOptions MakeStep(PromptRole role) => new()
    {
        Role = role,
        SystemPromptTemplate = $"sys-{role}",
        UserPromptTemplate = $"user-{role}"
    };

    private static FeedPromptOptions MakeFullOptions() => new()
    {
        Steps =
        [
            MakeStep(PromptRole.Summary),
            MakeStep(PromptRole.ImagePromptDerivation),
            MakeStep(PromptRole.ImageGeneration)
        ]
    };

    // ── Construction ──────────────────────────────────────────────────────────

    [Fact]
    public void FeedPromptOptions_Steps_AreSetCorrectly()
    {
        var options = MakeFullOptions();

        Assert.NotNull(options.Steps);
        Assert.Equal(3, options.Steps.Count);
    }

    [Fact]
    public void FeedPromptOptions_Steps_PreservesOrder()
    {
        var options = MakeFullOptions();

        Assert.Equal(PromptRole.Summary, options.Steps[0].Role);
        Assert.Equal(PromptRole.ImagePromptDerivation, options.Steps[1].Role);
        Assert.Equal(PromptRole.ImageGeneration, options.Steps[2].Role);
    }

    [Fact]
    public void FeedPromptOptions_Steps_CanBeASingleStep()
    {
        var options = new FeedPromptOptions
        {
            Steps = [MakeStep(PromptRole.Summary)]
        };

        Assert.Single(options.Steps);
        Assert.Equal(PromptRole.Summary, options.Steps[0].Role);
    }

    // ── GetStep – happy path ──────────────────────────────────────────────────

    [Theory]
    [InlineData(PromptRole.Summary)]
    [InlineData(PromptRole.ImagePromptDerivation)]
    [InlineData(PromptRole.ImageGeneration)]
    public void GetStep_ExistingRole_ReturnsCorrectStep(PromptRole role)
    {
        var options = MakeFullOptions();

        var step = options.GetStep(role);

        Assert.Equal(role, step.Role);
    }

    [Fact]
    public void GetStep_ReturnsStepWithExpectedTemplates()
    {
        var options = MakeFullOptions();

        var step = options.GetStep(PromptRole.Summary);

        Assert.Equal("sys-Summary", step.SystemPromptTemplate);
        Assert.Equal("user-Summary", step.UserPromptTemplate);
    }

    // ── GetStep – error paths ─────────────────────────────────────────────────

    [Fact]
    public void GetStep_MissingRole_ThrowsInvalidOperationException()
    {
        var options = new FeedPromptOptions
        {
            Steps = [MakeStep(PromptRole.Summary)]
        };

        Assert.Throws<InvalidOperationException>(
            () => options.GetStep(PromptRole.ImageGeneration));
    }

    [Fact]
    public void GetStep_EmptySteps_ThrowsInvalidOperationException()
    {
        var options = new FeedPromptOptions { Steps = [] };

        Assert.Throws<InvalidOperationException>(
            () => options.GetStep(PromptRole.Summary));
    }

    [Fact]
    public void GetStep_DuplicateRole_ThrowsInvalidOperationException()
    {
        var options = new FeedPromptOptions
        {
            Steps =
            [
                MakeStep(PromptRole.Summary),
                MakeStep(PromptRole.Summary)
            ]
        };

        Assert.Throws<InvalidOperationException>(
            () => options.GetStep(PromptRole.Summary));
    }

    // ── Immutability ──────────────────────────────────────────────────────────

    [Fact]
    public void FeedPromptOptions_IsImmutable_AfterConstruction()
    {
        var original = MakeFullOptions();
        var newSteps = new[] { MakeStep(PromptRole.Summary) };

        var modified = original with { Steps = newSteps };

        Assert.Equal(3, original.Steps.Count);
        Assert.Single(modified.Steps);
    }

    [Fact]
    public void FeedPromptOptions_WithExpression_PreservesStepsReference()
    {
        var options = MakeFullOptions();

        // with-expression that changes nothing still yields a new instance
        // but the Steps list identity is preserved.
        var copy = options with { };

        Assert.Equal(options.Steps, copy.Steps);
    }

    // ── Value equality ────────────────────────────────────────────────────────

    [Fact]
    public void FeedPromptOptions_ValueEquality_SameSteps_AreEqual()
    {
        var a = MakeFullOptions();
        var b = MakeFullOptions();

        Assert.Equal(a, b);
    }

    [Fact]
    public void FeedPromptOptions_ValueEquality_DifferentSteps_AreNotEqual()
    {
        var a = new FeedPromptOptions { Steps = [MakeStep(PromptRole.Summary)] };
        var b = new FeedPromptOptions { Steps = [MakeStep(PromptRole.ImageGeneration)] };

        Assert.NotEqual(a, b);
    }

    [Fact]
    public void FeedPromptOptions_ValueEquality_DifferentStepCount_AreNotEqual()
    {
        var a = MakeFullOptions();
        var b = new FeedPromptOptions { Steps = [MakeStep(PromptRole.Summary)] };

        Assert.NotEqual(a, b);
    }
}
