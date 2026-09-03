using System.Text.Json;
using XPoster.Contracts;

namespace XPoster.Workflows.Utilities;

/// <summary>
/// Extracts strongly-typed parameters from the untyped dictionary provided to workflow nodes.
/// Handles <see cref="JsonElement"/> deserialization (from IConfiguration bindings),
/// direct casts, and <c>Convert.ChangeType</c> fallbacks.
/// </summary>
public static class NodeParameterExtractor
{
    /// <summary>
    /// Retrieves a parameter value by key and converts it to the requested type.
    /// </summary>
    /// <typeparam name="T">The desired return type.</typeparam>
    /// <param name="parameters">The node parameter dictionary.</param>
    /// <param name="key">The parameter key to look up.</param>
    /// <param name="defaultValue">Value returned when the key is missing or conversion fails.</param>
    /// <returns>The converted value, or <paramref name="defaultValue"/>.</returns>
    public static T GetParameter<T>(IReadOnlyDictionary<string, object> parameters, string key, T defaultValue = default!)
    {
        if (!parameters.TryGetValue(key, out var val) || val == null)
            return defaultValue;

        if (val is T typedVal)
            return typedVal;

        if (val is JsonElement jsonElement)
        {
            var rawText = jsonElement.GetRawText();
            var deserialized = JsonSerializer.Deserialize<T>(rawText);
            return deserialized ?? defaultValue;
        }

        if (val is string str && IsJsonLike(str))
        {
            try
            {
                var deserializedJson = JsonSerializer.Deserialize<T>(str);
                return deserializedJson ?? defaultValue;
            }
            catch (JsonException)
            {
                // Fall through to ChangeType for plain string values.
            }
        }

        try
        {
            return (T)Convert.ChangeType(val, typeof(T));
        }
        catch
        {
            return defaultValue;
        }
    }

    /// <summary>
    /// Retrieves the <c>Provider</c> parameter and parses it into an <see cref="AiProvider"/>.
    /// </summary>
    /// <param name="parameters">The node parameter dictionary.</param>
    /// <param name="defaultProvider">Provider used when the key is missing.</param>
    /// <returns>The resolved provider, or <paramref name="defaultProvider"/> when the key is absent.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the provider name is empty or not a known <see cref="AiProvider"/>.</exception>
    public static AiProvider GetProvider(
        IReadOnlyDictionary<string, object> parameters,
        AiProvider defaultProvider = AiProvider.OpenAi)
    {
        var providerName = GetParameter<string>(parameters, "Provider", defaultProvider.ToString());
        if (string.IsNullOrWhiteSpace(providerName))
            throw new InvalidOperationException("Provider name is required to resolve an AI provider.");

        if (!Enum.TryParse<AiProvider>(providerName, ignoreCase: true, out var provider))
            throw new InvalidOperationException($"Unknown AI provider '{providerName}'.");

        return provider;
    }

    private static bool IsJsonLike(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;
        var trimmed = value.AsSpan().TrimStart();
        return trimmed.Length > 0 &&
            (trimmed[0] == '[' || trimmed[0] == '{' || trimmed[0] == '"' || trimmed[0] == 't' || trimmed[0] == 'f' || trimmed[0] == 'n');
    }
}
