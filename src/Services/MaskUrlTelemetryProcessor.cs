using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;

/// <summary>
/// Custom <see cref="ITelemetryProcessor"/> that masks access tokens in outbound HTTP dependency
/// telemetry targeting the Facebook Graph API.
/// </summary>
public class MaskUrlTelemetryProcessor : ITelemetryProcessor
{
    private ITelemetryProcessor Next { get; set; }
    /// <summary>
    /// Initializes a new instance of the <see cref="MaskUrlTelemetryProcessor"/> class.
    /// This constructor is called by the Application Insights SDK when the processor is registered.
    /// </summary>
    /// <param name="next">The next telemetry processor in the chain.</param>
    public MaskUrlTelemetryProcessor(ITelemetryProcessor next)
    {
        this.Next = next;
    }
    /// <summary>
    /// Processes the telemetry item, masking sensitive query string parameters
    /// for calls directed at the Facebook Graph API.
    /// </summary>
    /// <param name="telemetry">The telemetry item to process.</param>
    public void Process(ITelemetry telemetry)
    {
        // Check if the telemetry item is a DependencyTelemetry (outbound HTTP call)
        if (telemetry is DependencyTelemetry dependency)
        {
            // ... process only if the target is the Facebook Graph API
            if (dependency.Target.Contains("graph.facebook.com", StringComparison.OrdinalIgnoreCase))
            {
                // Mask the access token in the URL
                var uri = new Uri(dependency.Data);
                var queryParams = System.Web.HttpUtility.ParseQueryString(uri.Query);
                if (queryParams["access_token"] != null)
                {
                    queryParams["access_token"] = "MASKED";
                    var maskedUri = new UriBuilder(uri)
                    {
                        Query = queryParams.ToString()
                    }.Uri;
                    dependency.Data = maskedUri.ToString();
                }
            }
        }
        
        // Important: pass the telemetry item to the next processor in the chain.
        this.Next.Process(telemetry);
    }
}