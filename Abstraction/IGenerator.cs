using System.Threading.Tasks;
namespace XPoster.Abstraction;
public interface IGenerator
{
    public string Name { get; }
    public bool SendIt { get; set; }
    public bool ProduceImage { get; set; }
    public Task<Message> GenerateAsync();
    public Task<bool> SendMessageAsync(Message message);
}
