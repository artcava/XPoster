namespace XPoster.Contracts;
/// <summary>
/// Defines a contract for a service that applies tag replacements to text.
/// </summary>
public interface ITagReplacementService
{
    /// <summary>
    /// Applies tag replacements to the specified text.
    /// </summary>
    /// <param name="text">The text to apply tag replacements to.</param>
    /// <returns>The text with tag replacements applied.</returns>
    string Apply(string text);
}