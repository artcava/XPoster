using System.Threading.Tasks;

namespace XPoster.MessageAbstraction;

public interface IGeneration
{
    public Task<string> GenerateMessage();
    public Task<ImageMessage> GenerateMessageWithImage();
    public bool SendIt { get; set; }
    public bool ProduceImage { get; set; }
    public string Name { get; }
}
