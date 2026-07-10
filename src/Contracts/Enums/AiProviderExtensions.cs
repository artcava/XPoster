using System.ComponentModel;
using System.Reflection;

namespace XPoster.Contracts;

/// <summary>
/// Extension methods for <see cref="AiProvider"/>.
/// </summary>
public static class AiProviderExtensions
{
    /// <summary>
    /// Returns the human-readable label for the provider, sourced from
    /// <see cref="DescriptionAttribute"/> when present; falls back to
    /// <see cref="Enum.ToString()"/> otherwise.
    /// </summary>
    public static string GetLabel(this AiProvider provider)
    {
        var field = typeof(AiProvider).GetField(provider.ToString());
        var attr = field?.GetCustomAttribute<DescriptionAttribute>();
        return attr?.Description ?? provider.ToString();
    }
}
