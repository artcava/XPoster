using XPoster.Models;

namespace XPoster.Abstraction
{
    public interface ISender
    {
        public int MessageMaxLenght {  get; }
        Task<bool> SendAsync(Post post);
    }
}
