using System.Net.Http;
using System.Threading.Tasks;

namespace XPoster.Utilities;

public static class CryptoUtilities
{
    private static readonly HttpClient _client = new();
    public static async Task<decimal> GetCryptoValue(string symbol)
    {
        var url = $"https://cryptoprices.cc/{symbol}";
        _client.DefaultRequestHeaders.Add("User-Agent", "XPoster");
        var response = await _client.GetStringAsync(url);
        var value = ExtractValue(response);
        if(value.HasValue)
        {
            return value.Value;
        }
        return 0m;
    }

    private static decimal? ExtractValue(string html)
    {
        _ = decimal.TryParse(html.Trim(), out decimal btcValue);
        if (btcValue > 0)
        {
            return btcValue;
        }
        return null;
    }
}
