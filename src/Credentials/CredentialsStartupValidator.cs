using Microsoft.Extensions.Options;
using XPoster.Contracts;

namespace XPoster.Credentials;

/// <summary>
/// Validates credentials at application startup to ensure all required properties are set.
/// </summary>
public sealed class CredentialsStartupValidator : ICredentialsStartupValidator
{
    private readonly IOptions<XCredentials> _xOptions;
    private readonly IOptions<LinkedInCredentials> _linkedInOptions;
    private readonly IOptions<InstagramCredentials> _instagramOptions;
    private readonly IOptions<FacebookCredentials> _facebookOptions;

    /// <summary>
    /// Initializes a new instance of the <see cref="CredentialsStartupValidator"/> class with the specified options.
    /// </summary>
    /// <param name="xOptions">The options for XCredentials.</param>
    /// <param name="linkedInOptions">The options for LinkedInCredentials.</param>
    /// <param name="instagramOptions">The options for InstagramCredentials.</param>
    /// <param name="facebookOptions">The options for FacebookCredentials.</param>
    public CredentialsStartupValidator(
        IOptions<XCredentials> xOptions,
        IOptions<LinkedInCredentials> linkedInOptions,
        IOptions<InstagramCredentials> instagramOptions,
        IOptions<FacebookCredentials> facebookOptions)
    {
        _xOptions = xOptions;
        _linkedInOptions = linkedInOptions;
        _instagramOptions = instagramOptions;
        _facebookOptions = facebookOptions;
    }

    /// <summary>
    /// Validates the credentials at application startup.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown if any credentials are invalid.</exception>
    public void Validate()
    {
        var failures = new List<string>();

        ValidateOptions("XCredentials", () => _xOptions.Value, failures);
        ValidateOptions("LinkedInCredentials", () => _linkedInOptions.Value, failures);
        ValidateOptions("InstagramCredentials", () => _instagramOptions.Value, failures);
        ValidateOptions("FacebookCredentials", () => _facebookOptions.Value, failures);

        if (failures.Count > 0)
        {
            throw new InvalidOperationException(
                "Credentials configuration validation failed:" + Environment.NewLine +
                string.Join(Environment.NewLine, failures));
        }
    }

    private static void ValidateOptions(
        string optionsName,
        Func<object?> resolve,
        List<string> failures)
    {
        try
        {
            resolve();
        }
        catch (OptionsValidationException ex)
        {
            foreach (var failure in ex.Failures)
            {
                failures.Add($"{optionsName}: {failure}");
            }
        }
    }
}