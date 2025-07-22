using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using XPoster.Abstraction;
using XPoster.Implementation;
using XPoster.SenderPlugins;
using XPoster.Services;

[assembly: FunctionsStartup(typeof(XPoster.Startup))]

namespace XPoster;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        // Registra HttpClient come singleton per riutilizzare l'istanza
        builder.Services.AddHttpClient();

        // Registra i tuoi Sender. Saranno creati quando necessari.
        builder.Services.AddTransient<XSender>();
        builder.Services.AddTransient<InSender>();
        builder.Services.AddTransient<IgSender>();

        // Registra i Generator
        builder.Services.AddTransient<PowerLawGenerator>();
        builder.Services.AddTransient<FeedGenerator>();
        builder.Services.AddTransient<NoGenerator>();

        // Registriamo la nuova factory come servizio
        builder.Services.AddTransient<IGeneratorFactory, GeneratorFactory>();

        // Registriamo i servizi necessari
        builder.Services.AddTransient<ICryptoService, CryptoService>();
        builder.Services.AddSingleton<ITimeProvider, TimeProvider>();
    }
}