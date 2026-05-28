namespace XPoster.Models;

/// <summary>
/// Strongly-typed configuration for the OpenAI provider, bound from the <c>OpenAI</c> configuration section.
/// All properties have sensible defaults so the application works without explicit configuration.
/// </summary>
public sealed class OpenAiOptions
{
    /// <summary>Gets or sets the OpenAI API key used for authentication.</summary>
    public string ApiKey { get; set; } = string.Empty;

    // ── Chat / Completions ────────────────────────────────────────────────────

    /// <summary>Gets or sets the Chat Completions API endpoint.</summary>
    public string ChatEndpoint { get; set; } = "https://api.openai.com/v1/chat/completions";

    /// <summary>Gets or sets the model used for chat/completion requests.</summary>
    public string ChatModel { get; set; } = "gpt-4.1-nano";

    /// <summary>Gets or sets the temperature used when generating summaries.</summary>
    public double SummaryTemperature { get; set; } = 0.5;

    /// <summary>
    /// Gets or sets the divisor used to convert a character budget into a <c>max_tokens</c> value.
    /// Formula: <c>max_tokens = messageMaxLength / SummaryMaxTokensPerChar</c>.
    /// </summary>
    public int SummaryMaxTokensPerChar { get; set; } = 5;

    /// <summary>
    /// Gets or sets the safety margin (in characters) subtracted from the character budget
    /// when building the "keep under N characters" system prompt.
    /// </summary>
    public int SummarySafetyMarginChars { get; set; } = 50;

    // ── Image Generation ──────────────────────────────────────────────────────

    /// <summary>Gets or sets the Image Generations API endpoint.</summary>
    public string ImageEndpoint { get; set; } = "https://api.openai.com/v1/images/generations";

    /// <summary>Gets or sets the model used for image generation requests.</summary>
    public string ImageModel { get; set; } = "gpt-image-1.5";

    /// <summary>Gets or sets the output image size (e.g. <c>1024x1024</c>).</summary>
    public string ImageSize { get; set; } = "1024x1024";

    /// <summary>Gets or sets the number of images to generate per request.</summary>
    public int ImageCount { get; set; } = 1;

    // ── Prompt Templates ──────────────────────────────────────────────────────

    /// <summary>
    /// Gets or sets the system prompt template for text summarisation.
    /// Supports placeholder <c>{MaxChars}</c>, replaced at runtime with the effective character limit.
    /// </summary>
    public string SummarySystemPromptTemplate { get; set; } =
        "You are an assistant that summarizes text concisely. " +
        "It's very important that you keep summaries under {MaxChars} characters.";

    /// <summary>
    /// Gets or sets the user prompt template for text summarisation.
    /// Supports placeholder <c>{Text}</c>, replaced at runtime with the input text.
    /// </summary>
    public string SummaryUserPromptTemplate { get; set; } =
        "Summarize this text in a few sentences. text: {Text}";

    /// <summary>
    /// Gets or sets the system prompt template for image prompt generation.
    /// No runtime placeholders — the full instruction is used as-is.
    /// </summary>
    public string ImagePromptSystemTemplate { get; set; } =
        "You are an assistant that generates image prompts for an AI image generation model based on text summaries. " +
        "Create a concise, vivid prompt in English that reflects the summary's content, includes a Bitcoin-related element (e.g., a coin), " +
        "and avoids text, signs, or words in the image. Respect content policy for generating images.";

    /// <summary>
    /// Gets or sets the user prompt template for image prompt generation.
    /// Supports placeholder <c>{Summary}</c>, replaced at runtime with the input summary.
    /// </summary>
    public string ImagePromptUserTemplate { get; set; } =
        "Generate an image prompt based on this summary: {Summary}";

    /// <summary>Gets or sets the max tokens for image prompt generation requests.</summary>
    public int ImagePromptMaxTokens { get; set; } = 60;

    /// <summary>Gets or sets the temperature for image prompt generation requests.</summary>
    public double ImagePromptTemperature { get; set; } = 0.7;
}
