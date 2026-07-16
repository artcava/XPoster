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

        if (string.IsNullOrWhiteSpace(options.ChatEndpoint))
            failures.Add($"{nameof(OpenAiOptions.ChatEndpoint)} must not be empty.");

        if (string.IsNullOrWhiteSpace(options.ImageEndpoint))
            failures.Add($"{nameof(OpenAiOptions.ImageEndpoint)} must not be empty.");

        return failures.Count > 0
            ? ValidateOptionsResult.Fail(failures)
            : ValidateOptionsResult.Success;
    }
}