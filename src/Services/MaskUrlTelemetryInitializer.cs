using System.Web;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;

/// <summary>
/// Custom <see cref="ITelemetryInitializer"/> that masks access tokens in outbound HTTP dependency
/// telemetry targeting the Facebook Graph API.
/// </summary>
public class MaskUrlTelemetryInitializer : ITelemetryInitializer
{
    private const string FacebookGraphHost = "graph.facebook.com";
    private const string AccessTokenParam   = "access_token";
    private const string MaskedValue        = "[MASKED]";
    /// <summary>
    /// Initializes the telemetry item, masking sensitive query string parameters
    /// for calls directed at the Facebook Graph API.
    /// </summary>
    /// <param name="telemetry">The telemetry item to initialize.</param>
    public void Initialize(ITelemetry telemetry)
    {
        // 1. Intercept only Http dependency calls (case-insensitive to handle "HTTP", "http", "Http", …)
        if (telemetry is not DependencyTelemetry dependency ||
            !string.Equals(dependency.Type, "Http", StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        // 2. Filter by Target (populated by the SDK as the remote host).
        //    Target is a stable, host-only field: "graph.facebook.com" or "graph.facebook.com:443".
        if (string.IsNullOrEmpty(dependency.Target) ||
            !dependency.Target.Contains(FacebookGraphHost, StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        if (string.IsNullOrEmpty(dependency.Data))
        {
            return;
        }

        try
        {
            if (!Uri.TryCreate(dependency.Data, UriKind.Absolute, out var uri))
            {
                return;
            }

            // 3. Nothing to sanitize when there is no query string.
            if (string.IsNullOrEmpty(uri.Query))
            {
                return;
            }

            // 4. Parse and inspect query parameters.
            var queryParameters = HttpUtility.ParseQueryString(uri.Query);

            if (queryParameters[AccessTokenParam] is null)
            {
                return;
            }

            // 5. Replace the sensitive parameter value.
            queryParameters[AccessTokenParam] = MaskedValue;

            // 6. Rebuild the URL.
            //    UrlEncode round-trips through HttpUtility, which encodes brackets as %5B%5D.
            //    We decode them back so the stored URL stays human-readable while still being valid.
            string cleanQuery = Uri.UnescapeDataString(queryParameters.ToString() ?? string.Empty);
            string cleanUrl   = $"{uri.Scheme}://{uri.Authority}{uri.AbsolutePath}?{cleanQuery}";

            dependency.Data = cleanUrl;
        }
        catch
        {
            // On any parsing failure fall back to the bare host URL so we never
            // accidentally persist a token-bearing URL in telemetry.
            dependency.Data = $"https://{FacebookGraphHost}";
        }
    }
}