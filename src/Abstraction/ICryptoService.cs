namespace XPoster.Abstraction;

public interface ICryptoService
{
    Task<decimal> GetCryptoValue(string symbol);
}
