using XPoster.Models;

namespace XPoster.Abstraction;

public abstract class BaseGenerator(ISender? sender, ILogger logger) : IGenerator
{
    public abstract string Name { get; }
    public abstract bool SendIt { get; set; }
    public abstract bool ProduceImage { get; set; }
    protected ISender? _sender { get; } = sender;
    protected ILogger _logger { get; } = logger;

    public abstract Task<Post>? GenerateAsync();

    public virtual async Task<bool> PostAsync(Post message)
    {
        if (!SendIt) { _logger.LogInformation($"Generator {Name} cannot generate messages to send"); return false; }

        if (ProduceImage && message.Image == null) { _logger.LogInformation($"Empty image with {Name}"); return false; }

        if (string.IsNullOrWhiteSpace(message.Content)) { _logger.LogInformation($"Empty message with {Name}"); return false; }

        if (_sender == null) { _logger.LogInformation($"No sender configured with {Name}"); return false; }

        return await _sender.SendAsync(message);
    }
}
