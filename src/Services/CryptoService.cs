using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using XPoster.Abstraction;

namespace XPoster.Services;

public class CryptoService : ICryptoService
{
    private readonly HttpClient _client;
    private readonly ILogger<CryptoService> _logger;
    public CryptoService(IHttpClientFactory httpClientFactory, ILogger<CryptoService> logger)
    {
        _client = httpClientFactory.CreateClient();
        _logger = logger;
    }
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

    private decimal? ExtractValue(string html)
    {
        if (decimal.TryParse(html.Trim(), out decimal btcValue) && btcValue > 0)
        {
            return btcValue;
        }
        return null;
    }
}
