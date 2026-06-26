using XPoster.Models;

namespace XPoster.Contracts
{
    /// <summary>
    /// Represents a social-media platform sender capable of publishing a <see cref="Post"/>.
    /// </summary>
    public interface ISender
    {
        /// <summary>Gets the platform this sender targets. Used as the routing key in the post dispatch map.</summary>
        SenderPlatform Platform { get; }

        /// <summary>Gets the maximum number of characters allowed in a single post on this platform.</summary>
        int MessageMaxLenght { get; }

        /// <summary>
        /// Asynchronously sends the given <see cref="Post"/> to the target social-media platform.
        /// </summary>
        /// <param name="post">The post to publish, including text content and an optional image.</param>
        /// <param name="ct">Cancellation token to signal operation cancellation.</param>
        /// <returns><c>true</c> if the post was published successfully; otherwise <c>false</c>.</returns>
        Task<bool> SendAsync(Post post, CancellationToken ct = default);
    }
}
