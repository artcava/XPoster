using System.Web; // Richiede .NET Core / .NET 5+ (incluso nativamente)
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;

/// <summary>
/// Un <see cref="ITelemetryInitializer"/> personalizzato per mascherare o rimuovere i token di accesso dalle chiamate HTTP verso l'API Graph di Facebook.
/// Questo aiuta a proteggere le informazioni sensibili nei log di telemetria.
/// </summary>
public class MaskUrlTelemetryInitializer : ITelemetryInitializer
{
    /// <summary>
    /// Inizializza la telemetria, mascherando o rimuovendo i token di accesso dalle chiamate HTTP verso l'API Graph di Facebook.
    /// </summary>
    /// <param name="telemetry">L'oggetto di telemetria da inizializzare.</param>
    public void Initialize(ITelemetry telemetry)
    {
        // 1. Intercettiamo solo le chiamate HttpClient (Dependency) di tipo Http
        if (telemetry is DependencyTelemetry dependency && dependency.Type == "Http")
        {
            if (string.IsNullOrEmpty(dependency.Data)) return;

            // 2. Filtriamo in modo mirato solo per le chiamate verso Graph API di Facebook
            if (dependency.Data.Contains("graph.facebook.com"))
            {
                try
                {
                    if (Uri.TryCreate(dependency.Data, UriKind.Absolute, out var uri))
                    {
                        // 3. Verifichiamo se la query string contiene parametri
                        if (!string.IsNullOrEmpty(uri.Query))
                        {
                            // Effettua il parsing dei parametri (es. ?limit=10&access_token=xyz)
                            var queryParameters = HttpUtility.ParseQueryString(uri.Query);

                            // 4. Se il parametro access_token è presente, lo mascheriamo o rimuoviamo
                            if (queryParameters["access_token"] != null)
                            {
                                // Sostituisci con un valore segnaposto (scelta consigliata per sapere che c'era)
                                queryParameters["access_token"] = "[MASKED]"; 
                                
                                // Oppure usa: queryParameters.Remove("access_token"); se vuoi eliminarlo del tutto

                                // 5. Ricostruiamo l'URL pulito mantenendo gli altri parametri
                                string cleanQuery = queryParameters.ToString() ?? string.Empty; // Genera "limit=10&access_token=%5bMASKED%5d"
                                string cleanUrl = $"{uri.Scheme}://{uri.Authority}{uri.AbsolutePath}?{cleanQuery}";

                                // Aggiorna la telemetria
                                dependency.Data = cleanUrl;
                            }
                        }
                    }
                }
                catch
                {
                    dependency.Data = "https://graph.facebook.com"; // In caso di errore, mantieni l'URL originale per evitare di perdere informazioni critiche
                }
            }
        }
    }
}