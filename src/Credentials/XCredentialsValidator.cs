using Microsoft.Extensions.Options;

namespace XPoster.Credentials;

/// <summary>
/// Validates <see cref="XCredentials"/> to ensure all required properties are set.
/// </summary>
public sealed class XCredentialsValidator : IValidateOptions<XCredentials>
{
    /// <summary>
    /// Validates the specified <see cref="XCredentials"/> instance.
    /// </summary>
    /// <param name="name">The name of the options instance being validated.</param>
    /// <param name="options">The options instance to validate.</param>
    /// <returns>A <see cref="ValidateOptionsResult"/> indicating the validation result.</returns>
    public ValidateOptionsResult Validate(string? name, XCredentials options)
    {
        var failures = new List<string>();

        if (string.IsNullOrWhiteSpace(options.XAccessToken))
            failures.Add($"{nameof(XCredentials.XAccessToken)} is required.");

        if (string.IsNullOrWhiteSpace(options.XAccessTokenSecret))
            failures.Add($"{nameof(XCredentials.XAccessTokenSecret)} is required.");

        if (string.IsNullOrWhiteSpace(options.XApiKey))
            failures.Add($"{nameof(XCredentials.XApiKey)} is required.");

        if (string.IsNullOrWhiteSpace(options.XApiSecret))
            failures.Add($"{nameof(XCredentials.XApiSecret)} is required.");

        return failures.Count > 0
            ? ValidateOptionsResult.Fail(failures)
            : ValidateOptionsResult.Success;
    }
}