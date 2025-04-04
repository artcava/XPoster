using System.Threading.Tasks;

namespace XPoster.Abstraction
{
    public interface ISender
    {
        public int MessageMaxLenght {  get; }
        Task<bool> SendAsync(Message message);
    }
}
