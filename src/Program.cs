using Microsoft.Azure.Functions.Worker;
using XPoster.Abstraction;
using XPoster.Implementation;
using XPoster.SenderPlugins;
using XPoster.Services;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services => {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddHttpClient();
        services.AddLogging();
        services.AddMemoryCache();

        services.AddTransient<XSender>();
        services.AddTransient<InSender>();
        services.AddTransient<IgSender>();

        services.AddTransient<PowerLawGenerator>();
        services.AddTransient<FeedGenerator>();
        services.AddTransient<NoGenerator>();

        services.AddSingleton<ITimeProvider, XPoster.Services.TimeProvider>();
        services.AddTransient<IGeneratorFactory, GeneratorFactory>();

        services.AddTransient<ICryptoService, CryptoService>();
        services.AddTransient<IFeedService, FeedService>();
        services.AddTransient<IAiService, AiService>();
    })
    .Build();

host.Run();