using XPoster.Models;

namespace XPoster.Abstraction
{
    /// <summary>
    /// Represents a social-media platform sender capable of publishing a <see cref="Post"/>.
    /// </summary>
    public interface ISender
    {
        /// <summary>Gets the maximum number of characters allowed in a single post on this platform.</summary>
        public int MessageMaxLenght { get; }

        /// <summary>
        /// Asynchronously sends the given <see cref="Post"/> to the target social-media platform.
        /// </summary>
        /// <param name="post">The post to publish, including text content and an optional image.</param>
        /// <returns><c>true</c> if the post was published successfully; otherwise <c>false</c>.</returns>
        Task<bool> SendAsync(Post post);
    }
}
