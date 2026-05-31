using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using XPoster.Abstraction;
using XPoster.Implementation;
using XPoster.Models;
using XPoster.SenderPlugins;
using XPoster.Services;

var builder = FunctionsApplication.CreateBuilder(args);

builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();

builder.Logging.Services.Configure<LoggerFilterOptions>(options =>
{
    // CS8600: FirstOrDefault can return null — annotated as nullable
    LoggerFilterRule? defaultRule = options.Rules.FirstOrDefault(rule => rule.ProviderName
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

builder.Services.AddSingleton<ITimeProvider, XPoster.Services.TimeProvider>();

// Register IAiServiceFactory and all IAiService implementations
builder.Services.AddSingleton<IAiServiceFactory, AiServiceFactory>();
builder.Services.AddTransient<IAiService, OpenAiService>();
// builder.Services.AddTransient<IAiService, PerplexityService>(); // Uncomment when implemented

builder.Services.AddTransient<IGeneratorFactory, GeneratorFactory>();

builder.Services.AddTransient<ICryptoService, CryptoService>();
builder.Services.AddTransient<IFeedService, FeedService>();
builder.Services.Configure<OpenAiOptions>(builder.Configuration.GetSection("OpenAI"));
builder.Services.AddSingleton<IValidateOptions<OpenAiOptions>, OpenAiOptionsValidator>();

builder.Build().Run();
