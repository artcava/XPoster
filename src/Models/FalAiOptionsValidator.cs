using Microsoft.Extensions.Options;

namespace XPoster.Models;

/// <summary>
/// Validates <see cref="FalAiOptions"/> when the fal.ai provider is resolved.
/// Ensures required fields are present and that <see cref="FalAiOptions.ModelId"/> does
/// not contain characters that would require percent-encoding when used as a URL path
/// segment (defence-in-depth alongside the per-segment encoding in FalAiImageService).
/// </summary>
public sealed class FalAiOptionsValidator : IValidateOptions<FalAiOptions>
{
    // Characters that are valid inside a URL path segment without percent-encoding
    // (RFC 3986 unreserved + sub-delimiters + ':' + '@' + '/') but that *could* appear
    // in a model id string.  We intentionally allow '/' because ModelId is a multi-segment
    // path such as "fal-ai/flux/schnell" and each segment is encoded individually.
    private static readonly char[] AllowedSpecialChars = ['/', '-', '_', '.'];

    /// <inheritdoc />
    public ValidateOptionsResult Validate(string? name, FalAiOptions options)
    {
        var failures = new List<string>();

        if (string.IsNullOrWhiteSpace(options.ApiKey))
        {
            failures.Add($"{nameof(FalAiOptions.ApiKey)} is required.");
        }

        if (string.IsNullOrWhiteSpace(options.ModelId))
        {
            failures.Add($"{nameof(FalAiOptions.ModelId)} is required.");
        }
        else
        {
            // Validate that every character in ModelId is alphanumeric or in the allowed set.
            // This prevents URL-injection at configuration time and provides a clear startup
            // error rather than a silent malformed-request failure at runtime.
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
