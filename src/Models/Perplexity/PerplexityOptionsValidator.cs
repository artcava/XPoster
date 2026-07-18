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

        if (string.IsNullOrWhiteSpace(options.TextModelName))
            failures.Add($"{nameof(PerplexityOptions.TextModelName)} is required.");

        return failures.Count > 0
            ? ValidateOptionsResult.Fail(failures)
            : ValidateOptionsResult.Success;
    }
}
