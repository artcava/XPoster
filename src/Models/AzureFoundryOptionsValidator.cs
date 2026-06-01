using Microsoft.Extensions.Options;

namespace XPoster.Models;

/// <summary>
/// Validates <see cref="AzureFoundryOptions"/> when the Azure Foundry provider is resolved.
/// </summary>
public sealed class AzureFoundryOptionsValidator : IValidateOptions<AzureFoundryOptions>
{
    /// <inheritdoc />
    public ValidateOptionsResult Validate(string? name, AzureFoundryOptions options)
    {
        var failures = new List<string>();

        if (string.IsNullOrWhiteSpace(options.Endpoint))
        {
            failures.Add($"{nameof(AzureFoundryOptions.Endpoint)} is required.");
        }

        if (string.IsNullOrWhiteSpace(options.ApiKey))
        {
            failures.Add($"{nameof(AzureFoundryOptions.ApiKey)} is required.");
        }

        if (string.IsNullOrWhiteSpace(options.DeploymentName))
        {
            failures.Add($"{nameof(AzureFoundryOptions.DeploymentName)} is required.");
        }

        if (!options.SummarySystemPromptTemplate.Contains("{MaxChars}", StringComparison.Ordinal))
        {
            failures.Add(
                $"{nameof(AzureFoundryOptions.SummarySystemPromptTemplate)} must contain the {{MaxChars}} placeholder.");
        }

        if (!options.SummaryUserPromptTemplate.Contains("{Text}", StringComparison.Ordinal))
        {
            failures.Add(
                $"{nameof(AzureFoundryOptions.SummaryUserPromptTemplate)} must contain the {{Text}} placeholder.");
        }

        if (!options.ImagePromptUserTemplate.Contains("{Summary}", StringComparison.Ordinal))
        {
            failures.Add(
                $"{nameof(AzureFoundryOptions.ImagePromptUserTemplate)} must contain the {{Summary}} placeholder.");
        }

        return failures.Count > 0
            ? ValidateOptionsResult.Fail(failures)
            : ValidateOptionsResult.Success;
    }
}
