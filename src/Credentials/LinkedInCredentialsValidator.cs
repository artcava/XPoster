using Microsoft.Extensions.Options;

namespace XPoster.Credentials;

/// <summary>
/// Validates <see cref="LinkedInCredentials"/> to ensure all required properties are set.
/// </summary>
public sealed class LinkedInCredentialsValidator : IValidateOptions<LinkedInCredentials>
{
    /// <summary>
    /// Validates the <see cref="LinkedInCredentials"/> options.
    /// </summary>
    /// <param name="name">The name of the options instance being validated.</param>
    /// <param name="options">The options instance to validate.</param>
    /// <returns>A <see cref="ValidateOptionsResult"/> indicating the validation result.</returns>
    public ValidateOptionsResult Validate(string? name, LinkedInCredentials options)
    {
        var failures = new List<string>();

        if (string.IsNullOrWhiteSpace(options.LinkedInAccessToken))
            failures.Add($"{nameof(LinkedInCredentials.LinkedInAccessToken)} is required.");

        var hasOrgId = !string.IsNullOrWhiteSpace(options.LinkedInOrgId);
        var hasOwnerCode = !string.IsNullOrWhiteSpace(options.LinkedInOwnerCode);

        if (!hasOrgId && !hasOwnerCode)
        {
            failures.Add(
                $"At least one of {nameof(LinkedInCredentials.LinkedInOrgId)} or {nameof(LinkedInCredentials.LinkedInOwnerCode)} must be provided.");
        }

        return failures.Count > 0
            ? ValidateOptionsResult.Fail(failures)
            : ValidateOptionsResult.Success;
    }
}