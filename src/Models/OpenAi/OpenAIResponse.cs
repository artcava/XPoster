namespace XPoster.Models;

/// <summary>
/// Root response object returned by the OpenAI Chat Completions API.
/// </summary>
public class OpenAIResponse
{
    /// <summary>Gets or sets the array of completion choices returned by the model.</summary>
    public required Choice[] choices { get; set; }
}

/// <summary>
/// Represents a single completion choice within an <see cref="OpenAIResponse"/>.
/// </summary>
public class Choice
{
    /// <summary>Gets or sets the message produced by the model for this choice.</summary>
    public required Message message { get; set; }
}

/// <summary>
/// Represents the message payload within a completion <see cref="Choice"/>.
/// </summary>
public class Message
{
    /// <summary>Gets or sets the text content of the model's response.</summary>
    public required string content { get; set; }
}

/// <summary>
/// Root response object returned by the OpenAI Image Generations API.
/// </summary>
public class OpenAIImageResponse
{
    /// <summary>Gets or sets the list of generated image data items.</summary>
    public required List<ImageData> data { get; set; }
}

/// <summary>
/// Contains the URL or base-64 payload for a single generated image.
/// </summary>
public class ImageData
{
    /// <summary>Gets or sets the URL pointing to the generated image.</summary>
    public required string url { get; set; }
}
