using Microsoft.Extensions.Options;

namespace XPoster.Models;

/// <summary>
/// Validates <see cref="OpenAiOptions"/> connectivity settings.
/// </summary>
public sealed class OpenAiOptionsValidator : IValidateOptions<OpenAiOptions>
{
    /// <inheritdoc />
    public ValidateOptionsResult Validate(string? name, OpenAiOptions options)
    {
        var failures = new List<string>();

        AiProviderValidationHelper.ValidateConnectivity(
            options.ApiKey,
            options.Endpoint,
            failures,
            nameof(OpenAiOptions.ApiKey),
            nameof(OpenAiOptions.Endpoint));

        if (string.IsNullOrWhiteSpace(options.TextModelName))
            failures.Add($"{nameof(OpenAiOptions.TextModelName)} is required.");

        if (string.IsNullOrWhiteSpace(options.ImageModelName))
            failures.Add($"{nameof(OpenAiOptions.ImageModelName)} is required.");

        return failures.Count > 0
            ? ValidateOptionsResult.Fail(failures)
            : ValidateOptionsResult.Success;
    }
}