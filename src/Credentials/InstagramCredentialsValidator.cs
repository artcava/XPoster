using Microsoft.Extensions.Options;

namespace XPoster.Credentials;

/// <summary>
/// Validates <see cref="InstagramCredentials"/> to ensure required properties are set.
/// </summary>
public class InstagramCredentialsValidator : IValidateOptions<InstagramCredentials>
{
    /// <summary>
    /// Validates the specified <see cref="InstagramCredentials"/> instance.
    /// Returns <see cref="ValidateOptionsResult.Fail(string)"/> if any required property is missing or empty; otherwise returns <see cref="ValidateOptionsResult.Success"/>.
    /// </summary>
    /// <param name="name">The name of the options instance being validated.</param>
    /// <param name="options">The options instance to validate.</param>
    /// <returns>A <see cref="ValidateOptionsResult"/> indicating the validation result.</returns>
    public ValidateOptionsResult Validate(string? name, InstagramCredentials options)
    {
        var failures = new List<string>();

        if (string.IsNullOrWhiteSpace(options.InstagramAccountId))
            failures.Add($"{nameof(InstagramCredentials.InstagramAccountId)} is required.");

        if (string.IsNullOrWhiteSpace(options.InstagramAccessToken))
            failures.Add($"{nameof(InstagramCredentials.InstagramAccessToken)} is required.");
            
        return failures.Count > 0
            ? ValidateOptionsResult.Fail(failures)
            : ValidateOptionsResult.Success;
    }
}