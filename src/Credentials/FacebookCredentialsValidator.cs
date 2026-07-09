using Microsoft.Extensions.Options;

namespace XPoster.Credentials;

/// <summary>
/// Validates <see cref="FacebookCredentials"/> to ensure required properties are set.
/// </summary>
public class FacebookCredentialsValidator : IValidateOptions<FacebookCredentials>
{
    /// <summary>
    /// Validates the specified <see cref="FacebookCredentials"/> instance.
    /// Returns <see cref="ValidateOptionsResult.Fail(string)"/> if any required property is missing or empty; otherwise returns <see cref="ValidateOptionsResult.Success"/>.
    /// </summary>
    /// <param name="name">The name of the options instance being validated.</param>
    /// <param name="options">The options instance to validate.</param>
    /// <returns>A <see cref="ValidateOptionsResult"/> indicating the validation result.</returns>
    public ValidateOptionsResult Validate(string? name, FacebookCredentials options)
    {
        var failures = new List<string>();

        if (string.IsNullOrWhiteSpace(options.FacebookPageId))
            failures.Add($"{nameof(FacebookCredentials.FacebookPageId)} is required.");

        if (string.IsNullOrWhiteSpace(options.FacebookAccessToken))
            failures.Add($"{nameof(FacebookCredentials.FacebookAccessToken)} is required.");

        return failures.Count > 0
            ? ValidateOptionsResult.Fail(failures)
            : ValidateOptionsResult.Success;
    }
}