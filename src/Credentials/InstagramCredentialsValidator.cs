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
    /// <param name="name"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public ValidateOptionsResult Validate(string? name, InstagramCredentials options)
    {
        if (string.IsNullOrWhiteSpace(options.InstagramAccountId))
            return ValidateOptionsResult.Fail("InstagramCredentials:InstagramAccountId is required.");
        if (string.IsNullOrWhiteSpace(options.InstagramAccessToken))
            return ValidateOptionsResult.Fail("InstagramCredentials:InstagramAccessToken is required.");
        return ValidateOptionsResult.Success;
    }
}