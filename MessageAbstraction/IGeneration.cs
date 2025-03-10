using System.Threading.Tasks;

namespace XPoster.MessageAbstraction;

public interface IGeneration
{
    public Task<string> GenerateMessage();
    public bool SendIt { get; }
    public string Name { get; }
}
