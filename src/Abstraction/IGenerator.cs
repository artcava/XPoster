using XPoster.Models;

namespace XPoster.Abstraction;
public interface IGenerator
{
    public string Name { get; }
    public bool SendIt { get; set; }
    public bool ProduceImage { get; set; }
    public Task<Post>? GenerateAsync();
    public Task<bool> PostAsync(Post message);
}
