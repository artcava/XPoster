using System.Threading.Tasks;

namespace XPoster.Abstraction;

public interface ICryptoService
{
    Task<decimal> GetCryptoValue(string symbol);
}
