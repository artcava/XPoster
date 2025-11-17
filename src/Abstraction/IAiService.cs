namespace XPoster.Abstraction;

public interface IAiService
{
    Task<string> GetSummaryAsync(string text, int messageMaxLength);
    Task<string> GetImagePromptAsync(string text);
    Task<byte[]> GenerateImageAsync(string prompt);
}