using Microsoft.Extensions.Options;

namespace XPoster.Models;

/// <summary>
/// Validates that <see cref="OpenAiOptions"/> prompt templates contain their required runtime placeholders.
/// Registered as <see cref="IValidateOptions{TOptions}"/> so the Azure Functions host fails fast at startup
/// rather than silently producing degraded output at runtime.
/// </summary>
public sealed class OpenAiOptionsValidator : IValidateOptions<OpenAiOptions>
{
    /// <inheritdoc />
    public ValidateOptionsResult Validate(string? name, OpenAiOptions options)
    {
        var failures = new List<string>();

        if (!options.SummarySystemPromptTemplate.Contains("{MaxChars}", StringComparison.Ordinal))
        {
            failures.Add(
                $"{nameof(OpenAiOptions.SummarySystemPromptTemplate)} must contain the {{MaxChars}} placeholder.");
        }

        if (!options.SummaryUserPromptTemplate.Contains("{Text}", StringComparison.Ordinal))
        {
            failures.Add(
                $"{nameof(OpenAiOptions.SummaryUserPromptTemplate)} must contain the {{Text}} placeholder.");
        }

        if (!options.ImagePromptUserTemplate.Contains("{Summary}", StringComparison.Ordinal))
        {
            failures.Add(
                $"{nameof(OpenAiOptions.ImagePromptUserTemplate)} must contain the {{Summary}} placeholder.");
        }

        return failures.Count > 0
            ? ValidateOptionsResult.Fail(failures)
            : ValidateOptionsResult.Success;
    }
}
