using Microsoft.Extensions.Options;

namespace XPoster.Models;

/// <summary>
/// Validates <see cref="DeepSeekOptions"/> when the DeepSeek provider is resolved.
/// Registered as <see cref="IValidateOptions{TOptions}"/> so the Azure Functions host fails fast at startup
/// rather than silently producing degraded output at runtime.
/// </summary>
public sealed class DeepSeekOptionsValidator : IValidateOptions<DeepSeekOptions>
{
    /// <inheritdoc />
    public ValidateOptionsResult Validate(string? name, DeepSeekOptions options)
    {
        var failures = new List<string>();

        if (string.IsNullOrWhiteSpace(options.Endpoint))
        {
            failures.Add($"{nameof(DeepSeekOptions.Endpoint)} is required.");
        }

        if (string.IsNullOrWhiteSpace(options.ApiKey))
        {
            failures.Add($"{nameof(DeepSeekOptions.ApiKey)} is required.");
        }

        if (string.IsNullOrWhiteSpace(options.DeploymentName))
        {
            failures.Add($"{nameof(DeepSeekOptions.DeploymentName)} is required.");
        }

        if (!options.SummarySystemPromptTemplate.Contains("{MaxChars}", StringComparison.Ordinal))
        {
            failures.Add(
                $"{nameof(DeepSeekOptions.SummarySystemPromptTemplate)} must contain the {{MaxChars}} placeholder.");
        }

        if (!options.SummaryUserPromptTemplate.Contains("{Text}", StringComparison.Ordinal))
        {
            failures.Add(
                $"{nameof(DeepSeekOptions.SummaryUserPromptTemplate)} must contain the {{Text}} placeholder.");
        }

        if (!options.ImagePromptUserTemplate.Contains("{Summary}", StringComparison.Ordinal))
        {
            failures.Add(
                $"{nameof(DeepSeekOptions.ImagePromptUserTemplate)} must contain the {{Summary}} placeholder.");
        }

        return failures.Count > 0
            ? ValidateOptionsResult.Fail(failures)
            : ValidateOptionsResult.Success;
    }
}
