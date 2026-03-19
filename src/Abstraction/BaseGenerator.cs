using XPoster.Models;

namespace XPoster.Abstraction;

/// <summary>
/// Provides the shared scaffolding for all content generators: sender reference, logger,
/// and a default <see cref="PostAsync"/> implementation with pre-condition guards.
/// Concrete generators inherit from this class and implement <see cref="GenerateAsync"/>.
/// </summary>
public abstract class BaseGenerator(ISender? sender, ILogger logger) : IGenerator
{
    /// <inheritdoc/>
    public abstract string Name { get; }

    /// <inheritdoc/>
    public abstract bool SendIt { get; set; }

    /// <inheritdoc/>
    public abstract bool ProduceImage { get; set; }

    /// <summary>The sender used to publish posts to the target social-media platform. May be <c>null</c> for no-op generators.</summary>
    protected ISender? _sender { get; } = sender;

    /// <summary>The logger instance used by this generator for diagnostic output.</summary>
    protected ILogger _logger { get; } = logger;

    /// <inheritdoc/>
    public abstract Task<Post>? GenerateAsync();

    /// <summary>
    /// Validates pre-conditions and, if all pass, delegates publishing to <see cref="_sender"/>.
    /// Guards against: sending disabled, null/empty content, missing sender, and missing image when required.
    /// </summary>
    /// <param name="message">The post to publish.</param>
    /// <returns><c>true</c> if the post was dispatched successfully; otherwise <c>false</c>.</returns>
    public virtual async Task<bool> PostAsync(Post message)
    {
        if (!SendIt) 
        { 
            _logger.LogInformation($"Generator {Name} cannot generate messages to send"); 
            return false; 
        }

        // If ProduceImage is true but image is null, log warning but continue
        if (ProduceImage && message.Image == null) 
        { 
            _logger.LogWarning($"Generator {Name} is configured to produce images, but no image was generated. Proceeding to post without image."); 
            // Don't return false - allow posting to continue
        }

        if (string.IsNullOrWhiteSpace(message.Content)) 
        { 
            _logger.LogInformation($"Empty message with {Name}"); 
            return false; 
        }

        if (_sender == null) 
        { 
            _logger.LogInformation($"No sender configured with {Name}"); 
            return false; 
        }

        return await _sender.SendAsync(message);
    }
}
