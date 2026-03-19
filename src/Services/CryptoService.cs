using XPoster.Abstraction;

namespace XPoster.Services;

/// <summary>
/// Retrieves live cryptocurrency prices by calling the <c>cryptoprices.cc</c> public API.
/// </summary>
public class CryptoService : ICryptoService
{
    private readonly HttpClient _client;
    private readonly ILogger<CryptoService> _logger;

    /// <summary>
    /// Initialises a new instance of <see cref="CryptoService"/>.
    /// </summary>
    /// <param name="httpClientFactory">The factory used to create the underlying <see cref="HttpClient"/>.</param>
    /// <param name="logger">The logger for diagnostic output.</param>
    public CryptoService(IHttpClientFactory httpClientFactory, ILogger<CryptoService> logger)
    {
        _client = httpClientFactory.CreateClient();
        _logger = logger;
    }

    /// <summary>
    /// Fetches the current price of the cryptocurrency identified by <paramref name="symbol"/>
    /// from <c>https://cryptoprices.cc/{symbol}</c>.
    /// </summary>
    /// <param name="symbol">The ticker symbol of the cryptocurrency (e.g. <c>"BTC"</c>).</param>
    /// <returns>
    /// The current price as a positive <see cref="decimal"/>, or <c>0</c> if the request fails
    /// or the response cannot be parsed.
    /// </returns>
    public async Task<decimal> GetCryptoValue(string symbol)
    {
        var url = $"https://cryptoprices.cc/{symbol}";
        _client.DefaultRequestHeaders.Add("User-Agent", "XPoster");
        try
        {
            var response = await _client.GetStringAsync(url);
            var value = ExtractValue(response);
            if (value.HasValue)
            {
                return value.Value;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get crypto value for {Symbol}", symbol);
        }
        return 0m;
    }

    /// <summary>
    /// Attempts to parse a decimal price value from the raw HTML/text response body.
    /// </summary>
    /// <param name="html">The raw response string returned by the price endpoint.</param>
    /// <returns>The parsed price if valid and positive; otherwise <c>null</c>.</returns>
    private decimal? ExtractValue(string html)
    {
        if (decimal.TryParse(html.Trim(), out decimal btcValue) && btcValue > 0)
        {
            return btcValue;
        }
        return null;
    }
}
