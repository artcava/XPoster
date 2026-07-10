namespace XPoster.Contracts;

/// <summary>
/// Defines a contract for validating credentials at application startup.
/// </summary>
public interface ICredentialsStartupValidator
{
    /// <summary>
    /// Validates the credentials at application startup.
    /// </summary>
    void Validate();
}