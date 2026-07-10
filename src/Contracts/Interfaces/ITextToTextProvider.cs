namespace XPoster.Contracts;

/// <summary>
/// Capability contract for text-to-text AI operations.
/// Providers that support text summarisation and image prompt generation implement this interface.
/// </summary>
public interface ITextToTextProvider
{
    /// <summary>
    /// Generates a summary of the supplied text within the specified maximum length.
    /// </summary>
    /// <param name="text">The source text to summarise.</param>
    /// <param name="maxLength">Maximum character length of the returned summary.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>A summarised version of the input text.</returns>
    Task<string> GetSummaryAsync(string text, int maxLength, CancellationToken ct = default);

    /// <summary>
    /// Generates an image-generation prompt derived from the supplied text.
    /// </summary>
    /// <param name="text">The source text from which the prompt is derived.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>A prompt string suitable for an image-generation model.</returns>
    Task<string> GetImagePromptAsync(string text, CancellationToken ct = default);
}
