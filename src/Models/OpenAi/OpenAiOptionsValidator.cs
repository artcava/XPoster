using Microsoft.Extensions.Options;

namespace XPoster.Models;

/// <summary>
/// Validates <see cref="OpenAiOptions"/> connectivity settings.
/// </summary>
public sealed class OpenAiOptionsValidator : IValidateOptions<OpenAiOptions>
{
    /// <summary>
    /// Validates the specified <see cref="OpenAiOptions"/> instance.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public ValidateOptionsResult Validate(string? name, OpenAiOptions options)
    {
        var failures = new List<string>();

        if (string.IsNullOrWhiteSpace(options.ApiKey))
            failures.Add($"{nameof(OpenAiOptions.ApiKey)} is required.");

        if (string.IsNullOrWhiteSpace(options.Endpoint))
            failures.Add($"{nameof(OpenAiOptions.Endpoint)} must not be empty.");

        if (string.IsNullOrWhiteSpace(options.TextModelName))
            failures.Add($"{nameof(OpenAiOptions.TextModelName)} is required.");
    
        if (string.IsNullOrWhiteSpace(options.ImageModelName))
            failures.Add($"{nameof(OpenAiOptions.ImageModelName)} is required.");

        return failures.Count > 0
            ? ValidateOptionsResult.Fail(failures)
            : ValidateOptionsResult.Success;
    }
}