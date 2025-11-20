using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using XPoster.Abstraction;
using XPoster.Implementation;
using XPoster.SenderPlugins;
using XPoster.Services;

var builder = FunctionsApplication.CreateBuilder(args);

builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();

builder.Logging.Services.Configure<LoggerFilterOptions>(options =>
{
    LoggerFilterRule defaultRule = options.Rules.FirstOrDefault(rule => rule.ProviderName
        == "Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider");
    if (defaultRule is not null)
    {
        options.Rules.Remove(defaultRule);
    }
});

builder.Services.AddHttpClient();
builder.Services.AddLogging();
builder.Services.AddMemoryCache();

builder.Services.AddTransient<XSender>();
builder.Services.AddTransient<InSender>();
builder.Services.AddTransient<IgSender>();

//builder.Services.AddTransient<PowerLawGenerator>();
//builder.Services.AddTransient<FeedGenerator>();
//builder.Services.AddTransient<NoGenerator>();

builder.Services.AddSingleton<ITimeProvider, XPoster.Services.TimeProvider>();
builder.Services.AddTransient<IGeneratorFactory, GeneratorFactory>();

builder.Services.AddTransient<ICryptoService, CryptoService>();
builder.Services.AddTransient<IFeedService, FeedService>();
builder.Services.AddTransient<IAiService, AiService>();

builder.Build().Run();

//var host = new HostBuilder()
//    .ConfigureFunctionsWorkerDefaults()
//    .ConfigureServices(services =>
//    {
//        services.AddApplicationInsightsTelemetryWorkerService();
//        services.ConfigureFunctionsApplicationInsights();
//        services.Configure<LoggerFilterOptions>(options =>
//        {
//            LoggerFilterRule defaultRule = options.Rules.FirstOrDefault(rule => rule.ProviderName
//                == "Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider");
//            if (defaultRule is not null)
//            {
//                options.Rules.Remove(defaultRule);
//            }
//        });
//        services.AddHttpClient();
//        //services.AddLogging();
//        services.AddMemoryCache();

//        services.AddTransient<XSender>();
//        services.AddTransient<InSender>();
//        services.AddTransient<IgSender>();

//        services.AddTransient<PowerLawGenerator>();
//        services.AddTransient<FeedGenerator>();
//        services.AddTransient<NoGenerator>();

//        services.AddSingleton<ITimeProvider, XPoster.Services.TimeProvider>();
//        services.AddTransient<IGeneratorFactory, GeneratorFactory>();

//        services.AddTransient<ICryptoService, CryptoService>();
//        services.AddTransient<IFeedService, FeedService>();
//        services.AddTransient<IAiService, AiService>();
//    })
//    .Build();

//host.Run();