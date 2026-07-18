using Microsoft.Extensions.Options;

namespace XPoster.Models;

/// <summary>
/// Validates <see cref="DeepSeekOptions"/> when the DeepSeek provider is resolved.
/// </summary>
public sealed class DeepSeekOptionsValidator : IValidateOptions<DeepSeekOptions>
{
    /// <inheritdoc />
    public ValidateOptionsResult Validate(string? name, DeepSeekOptions options)
    {
        var failures = new List<string>();

        if (string.IsNullOrWhiteSpace(options.Endpoint))
            failures.Add($"{nameof(DeepSeekOptions.Endpoint)} is required.");

        if (string.IsNullOrWhiteSpace(options.ApiKey))
            failures.Add($"{nameof(DeepSeekOptions.ApiKey)} is required.");

        if (string.IsNullOrWhiteSpace(options.TextModelName))
            failures.Add($"{nameof(DeepSeekOptions.TextModelName)} is required.");

        return failures.Count > 0
            ? ValidateOptionsResult.Fail(failures)
            : ValidateOptionsResult.Success;
    }
}
