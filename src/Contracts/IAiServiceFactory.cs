namespace XPoster.Contracts;

/// <summary>
/// Resolves the correct IAiService implementation for a given provider.
/// </summary>
public interface IAiServiceFactory
{
    /// <summary>
    /// Resolves an <see cref="IAiService"/> implementation for the specified provider.
    /// </summary>
    /// <param name="provider">The AI provider to resolve.</param>
    /// <returns>The resolved AI service implementation.</returns>
    IAiService GetByProvider(AiProvider provider);
}
