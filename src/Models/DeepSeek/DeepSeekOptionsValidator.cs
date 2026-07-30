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

        AiProviderValidationHelper.ValidateConnectivity(
            options.ApiKey,
            options.Endpoint,
            failures,
            nameof(DeepSeekOptions.ApiKey),
            nameof(DeepSeekOptions.Endpoint));

        if (string.IsNullOrWhiteSpace(options.TextModelName))
            failures.Add($"{nameof(DeepSeekOptions.TextModelName)} is required.");

        return failures.Count > 0
            ? ValidateOptionsResult.Fail(failures)
            : ValidateOptionsResult.Success;
    }
}
