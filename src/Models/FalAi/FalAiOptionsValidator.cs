using Microsoft.Extensions.Options;

namespace XPoster.Models;

/// <summary>
/// Validates <see cref="FalAiOptions"/> when the fal.ai provider is resolved.
/// </summary>
public sealed class FalAiOptionsValidator : IValidateOptions<FalAiOptions>
{
    private static readonly char[] AllowedSpecialChars = ['/', '-', '_', '.'];

    /// <inheritdoc />
    public ValidateOptionsResult Validate(string? name, FalAiOptions options)
    {
        var failures = new List<string>();

        if (string.IsNullOrWhiteSpace(options.ApiKey))
            failures.Add($"{nameof(FalAiOptions.ApiKey)} is required.");

        if (string.IsNullOrWhiteSpace(options.ModelId))
        {
            failures.Add($"{nameof(FalAiOptions.ModelId)} is required.");
        }
        else
        {
            foreach (var ch in options.ModelId)
            {
                if (!char.IsLetterOrDigit(ch) && !AllowedSpecialChars.Contains(ch))
                {
                    failures.Add(
                        $"{nameof(FalAiOptions.ModelId)} contains an invalid character '{ch}'. " +
                        "Only alphanumeric characters, hyphens, underscores, dots, and forward slashes are allowed.");
                    break;
                }
            }
        }

        return failures.Count > 0
            ? ValidateOptionsResult.Fail(failures)
            : ValidateOptionsResult.Success;
    }
}
