using XPoster.Models;

namespace XPoster.Contracts;

/// <summary>
/// Capability contract for text-to-text AI operations.
/// Providers that support text generation implement this interface.
/// Prompt intent is owned by the orchestrator and transported via <see cref="PromptRequest"/>.
/// </summary>
public interface ITextToTextProvider
{
    /// <summary>
    /// Executes a text-to-text prompt step and returns the generated text.
    /// </summary>
    /// <param name="request">The prompt request carrying all prompt data for this step.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The generated text, or <see cref="string.Empty"/> on failure.</returns>
    Task<string> GenerateTextAsync(PromptRequest request, CancellationToken cancellationToken = default);
}