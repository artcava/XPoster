using System.Text.RegularExpressions;
using XPoster.Contracts;

namespace XPoster.Services;

/// <summary>
/// Implements the <see cref="ITagReplacementService"/> interface to apply tag replacements to text using a provided <see cref="ITagReplacementProvider"/>.
/// </summary>
public sealed class TagReplacementService : ITagReplacementService
{
    private readonly ITagReplacementProvider _tagReplacementProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="TagReplacementService"/> class with the specified <see cref="ITagReplacementProvider"/>.
    /// </summary>
    /// <param name="tagReplacementProvider">The provider that supplies tag replacements.</param>
    public TagReplacementService(ITagReplacementProvider tagReplacementProvider)
    {
        _tagReplacementProvider = tagReplacementProvider;
    }

    /// <summary>
    /// Applies tag replacements to the specified text using the replacements provided by the <see cref="ITagReplacementProvider"/>.
    /// </summary>
    /// <param name="text">The text to apply tag replacements to.</param>
    /// <returns>The text with tag replacements applied.</returns>
    public string Apply(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return text;
        }

        var replacements = _tagReplacementProvider.GetReplacements();

        foreach (var (word, hashtag) in replacements)
        {
            var regex = new Regex(
                $@"(?<!#)\b{Regex.Escape(word)}\b",
                RegexOptions.IgnoreCase,
                TimeSpan.FromSeconds(1));

            text = regex.Replace(text, hashtag, 1);
        }

        return text;
    }
}