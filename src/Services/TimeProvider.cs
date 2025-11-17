using XPoster.Abstraction;

namespace XPoster.Services;

public class TimeProvider : ITimeProvider
{
    public DateTime GetCurrentTime() => DateTime.Now;
}
