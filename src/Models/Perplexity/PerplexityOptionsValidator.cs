using Microsoft.Extensions.Options;

namespace XPoster.Models;

/// <summary>
/// Validates <see cref="PerplexityOptions"/> when the Perplexity provider is resolved.
/// </summary>
public sealed class PerplexityOptionsValidator : IValidateOptions<PerplexityOptions>
{
    /// <inheritdoc />
    public ValidateOptionsResult Validate(string? name, PerplexityOptions options)
    {
        var failures = new List<string>();

        if (string.IsNullOrWhiteSpace(options.Endpoint))
            failures.Add($"{nameof(PerplexityOptions.Endpoint)} is required.");

        if (string.IsNullOrWhiteSpace(options.ApiKey))
            failures.Add($"{nameof(PerplexityOptions.ApiKey)} is required.");

        if (string.IsNullOrWhiteSpace(options.DeploymentName))
            failures.Add($"{nameof(PerplexityOptions.DeploymentName)} is required.");

        if (!options.SummarySystemPromptTemplate.Contains("{MaxChars}", StringComparison.Ordinal))
            failures.Add($"{nameof(PerplexityOptions.SummarySystemPromptTemplate)} must contain the {{MaxChars}} placeholder.");

        if (!options.SummaryUserPromptTemplate.Contains("{Text}", StringComparison.Ordinal))
            failures.Add($"{nameof(PerplexityOptions.SummaryUserPromptTemplate)} must contain the {{Text}} placeholder.");

        if (!options.ImagePromptUserTemplate.Contains("{Summary}", StringComparison.Ordinal))
            failures.Add($"{nameof(PerplexityOptions.ImagePromptUserTemplate)} must contain the {{Summary}} placeholder.");

        return failures.Count > 0
            ? ValidateOptionsResult.Fail(failures)
            : ValidateOptionsResult.Success;
    }
}
