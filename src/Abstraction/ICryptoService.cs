namespace XPoster.Abstraction;

/// <summary>
/// Provides real-time cryptocurrency price data from an external price feed.
/// </summary>
public interface ICryptoService
{
    /// <summary>
    /// Retrieves the current market price for the specified cryptocurrency symbol.
    /// </summary>
    /// <param name="symbol">The ticker symbol of the cryptocurrency (e.g. <c>"BTC"</c>).</param>
    /// <returns>
    /// The current price as a <see cref="decimal"/>, or <c>0</c> if the value cannot be retrieved.
    /// </returns>
    Task<decimal> GetCryptoValue(string symbol);
}
