namespace XPoster.Models;

/// <summary>
/// Strongly-typed configuration for the Azure AI Foundry provider, bound from the <c>AzureFoundry</c> section.
/// </summary>
public sealed class AzureFoundryOptions
{
    /// <summary>Gets or sets the Foundry endpoint base URL (for example, <c>https://resource-name.openai.azure.com</c>).</summary>
    public string Endpoint { get; set; } = string.Empty;

    /// <summary>Gets or sets the API key used for Foundry authentication.</summary>
    public string ApiKey { get; set; } = string.Empty;

    /// <summary>Gets or sets the chat/completions deployment name.</summary>
    public string DeploymentName { get; set; } = string.Empty;

    /// <summary>Gets or sets the image generation deployment name.</summary>
    public string ImageDeploymentName { get; set; } = string.Empty;

    /// <summary>Gets or sets the REST API version.</summary>
    public string ApiVersion { get; set; } = "2024-02-01";

    /// <summary>Gets or sets the temperature used for summary generation.</summary>
    public double SummaryTemperature { get; set; } = 0.5;

    /// <summary>
    /// Gets or sets the divisor used to convert a character budget into a <c>max_tokens</c> value.
    /// Formula: <c>max_tokens = messageMaxLength / SummaryMaxTokensPerChar</c>.
    /// </summary>
    public int SummaryMaxTokensPerChar { get; set; } = 5;

    /// <summary>
    /// Gets or sets the safety margin (in characters) subtracted from the character budget
    /// when building the "keep under N characters" prompt.
    /// </summary>
    public int SummarySafetyMarginChars { get; set; } = 50;

    /// <summary>
    /// Gets or sets the system prompt template for summarisation.
    /// Supports placeholder <c>{MaxChars}</c>.
    /// </summary>
    public string SummarySystemPromptTemplate { get; set; } =
        "You are an assistant that summarizes text concisely. " +
        "It's very important that you keep summaries under {MaxChars} characters.";

    /// <summary>
    /// Gets or sets the user prompt template for summarisation.
    /// Supports placeholder <c>{Text}</c>.
    /// </summary>
    public string SummaryUserPromptTemplate { get; set; } =
        "Summarize this text in a few sentences. text: {Text}";

    /// <summary>
    /// Gets or sets the system prompt template for image prompt generation.
    /// </summary>
    public string ImagePromptSystemTemplate { get; set; } =
        "You are an assistant that generates image prompts for an AI image generation model based on text summaries. " +
        "Create a concise, vivid prompt in English that reflects the summary's content, includes a Bitcoin-related element (e.g., a coin), " +
        "and avoids text, signs, or words in the image. Respect content policy for generating images.";

    /// <summary>
    /// Gets or sets the user prompt template for image prompt generation.
    /// Supports placeholder <c>{Summary}</c>.
    /// </summary>
    public string ImagePromptUserTemplate { get; set; } =
        "Generate an image prompt based on this summary: {Summary}";

    /// <summary>Gets or sets max tokens for image prompt generation requests.</summary>
    public int ImagePromptMaxTokens { get; set; } = 60;

    /// <summary>Gets or sets the temperature for image prompt generation requests.</summary>
    public double ImagePromptTemperature { get; set; } = 0.7;
}
