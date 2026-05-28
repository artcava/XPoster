using Microsoft.Extensions.Options;
using XPoster.Models;

namespace XPoster.Tests.Models;

/// <summary>
/// Unit tests for <see cref="OpenAiOptionsValidator"/>.
/// Verifies that the validator accepts well-formed options and rejects each
/// missing placeholder individually as well as all together.
/// </summary>
public class OpenAiOptionsValidatorTests
{
    private static OpenAiOptions ValidOptions() => new OpenAiOptions();

    private readonly OpenAiOptionsValidator _sut = new();

    // ── Success path ─────────────────────────────────────────────────────────

    [Fact]
    public void Validate_DefaultOptions_Succeeds()
    {
        var result = _sut.Validate(null, ValidOptions());

        Assert.True(result.Succeeded);
    }

    // ── SummarySystemPromptTemplate ───────────────────────────────────────────

    [Fact]
    public void Validate_MissingMaxCharsPlaceholder_Fails()
    {
        var options = ValidOptions();
        options.SummarySystemPromptTemplate = "You are a summariser."; // no {MaxChars}

        var result = _sut.Validate(null, options);

        Assert.True(result.Failed);
        Assert.Contains(result.Failures!, f => f.Contains("{MaxChars}"));
    }

    [Fact]
    public void Validate_MissingMaxCharsPlaceholder_ErrorNamesProperty()
    {
        var options = ValidOptions();
        options.SummarySystemPromptTemplate = "No placeholder here.";

        var result = _sut.Validate(null, options);

        Assert.Contains(result.Failures!,
            f => f.Contains(nameof(OpenAiOptions.SummarySystemPromptTemplate)));
    }

    // ── SummaryUserPromptTemplate ─────────────────────────────────────────────

    [Fact]
    public void Validate_MissingTextPlaceholder_Fails()
    {
        var options = ValidOptions();
        options.SummaryUserPromptTemplate = "Summarize this."; // no {Text}

        var result = _sut.Validate(null, options);

        Assert.True(result.Failed);
        Assert.Contains(result.Failures!, f => f.Contains("{Text}"));
    }

    [Fact]
    public void Validate_MissingTextPlaceholder_ErrorNamesProperty()
    {
        var options = ValidOptions();
        options.SummaryUserPromptTemplate = "No placeholder here.";

        var result = _sut.Validate(null, options);

        Assert.Contains(result.Failures!,
            f => f.Contains(nameof(OpenAiOptions.SummaryUserPromptTemplate)));
    }

    // ── ImagePromptUserTemplate ───────────────────────────────────────────────

    [Fact]
    public void Validate_MissingSummaryPlaceholder_Fails()
    {
        var options = ValidOptions();
        options.ImagePromptUserTemplate = "Generate an image prompt."; // no {Summary}

        var result = _sut.Validate(null, options);

        Assert.True(result.Failed);
        Assert.Contains(result.Failures!, f => f.Contains("{Summary}"));
    }

    [Fact]
    public void Validate_MissingSummaryPlaceholder_ErrorNamesProperty()
    {
        var options = ValidOptions();
        options.ImagePromptUserTemplate = "No placeholder here.";

        var result = _sut.Validate(null, options);

        Assert.Contains(result.Failures!,
            f => f.Contains(nameof(OpenAiOptions.ImagePromptUserTemplate)));
    }

    // ── Multiple failures ─────────────────────────────────────────────────────

    [Fact]
    public void Validate_AllPlaceholdersMissing_ReportsThreeFailures()
    {
        var options = ValidOptions();
        options.SummarySystemPromptTemplate = "No placeholder.";
        options.SummaryUserPromptTemplate = "No placeholder.";
        options.ImagePromptUserTemplate = "No placeholder.";

        var result = _sut.Validate(null, options);

        Assert.True(result.Failed);
        Assert.Equal(3, result.Failures!.Count());
    }
}
