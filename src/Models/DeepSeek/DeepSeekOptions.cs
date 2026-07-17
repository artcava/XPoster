namespace XPoster.Models;

/// <summary>
/// Strongly-typed configuration for the DeepSeek provider, bound from the <c>DeepSeek</c> section.
/// </summary>
public sealed class DeepSeekOptions
{
    /// <summary>Gets or sets the DeepSeek endpoint base URL (for example, <c>https://api.deepseek.com</c>).</summary>
    public string Endpoint { get; set; } = "https://api.deepseek.com";

    /// <summary>Gets or sets the API key used for DeepSeek authentication.</summary>
    public string ApiKey { get; set; } = string.Empty;

    /// <summary>Gets or sets the chat/completions model name (e.g. <c>deepseek-chat</c>).</summary>
    public string TextModelName { get; set; } = "deepseek-chat";
}
