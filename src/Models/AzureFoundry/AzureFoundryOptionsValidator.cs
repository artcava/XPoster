using Microsoft.Extensions.Options;

namespace XPoster.Models;

/// <summary>
/// Validates <see cref="AzureFoundryOptions"/> when the Azure AI Foundry provider is resolved.
/// </summary>
public sealed class AzureFoundryOptionsValidator : IValidateOptions<AzureFoundryOptions>
{
    /// <inheritdoc />
    public ValidateOptionsResult Validate(string? name, AzureFoundryOptions options)
    {
        var failures = new List<string>();

        AiProviderValidationHelper.ValidateConnectivity(
            options.ApiKey,
            options.Endpoint,
            failures,
            nameof(AzureFoundryOptions.ApiKey),
            nameof(AzureFoundryOptions.Endpoint));

        if (string.IsNullOrWhiteSpace(options.TextModelName))
            failures.Add($"{nameof(AzureFoundryOptions.TextModelName)} is required.");

        if (string.IsNullOrWhiteSpace(options.ImageModelName))
            failures.Add($"{nameof(AzureFoundryOptions.ImageModelName)} is required.");

        return failures.Count > 0
            ? ValidateOptionsResult.Fail(failures)
            : ValidateOptionsResult.Success;
    }
}
