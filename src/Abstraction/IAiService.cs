namespace XPoster.Abstraction;

/// <summary>
/// Provides AI-powered text summarisation and image generation capabilities via an external model provider.
/// </summary>
public interface IAiService
{
    /// <summary>
    /// Generates a concise summary of the provided text, ensuring the result fits within the given character limit.
    /// </summary>
    /// <param name="text">The source text to summarise.</param>
    /// <param name="messageMaxLength">The maximum number of characters allowed in the returned summary.</param>
    /// <returns>A summary string no longer than <paramref name="messageMaxLength"/> characters, or an empty string on failure.</returns>
    Task<string> GetSummaryAsync(string text, int messageMaxLength);

    /// <summary>
    /// Derives a concise image-generation prompt from the given text summary.
    /// </summary>
    /// <param name="text">The text summary to base the prompt on.</param>
    /// <returns>An image prompt string, or an empty string if the request fails.</returns>
    Task<string> GetImagePromptAsync(string text);

    /// <summary>
    /// Generates an image from the provided prompt using an AI image model.
    /// </summary>
    /// <param name="prompt">The text prompt describing the desired image.</param>
    /// <returns>A byte array containing the generated image data, or an empty array on failure.</returns>
    Task<byte[]> GenerateImageAsync(string prompt);
}
