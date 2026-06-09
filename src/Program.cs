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
builder.Services.AddKeyedTransient<IAiService, OpenAiService>(AiProvider.OpenAi);
builder.Services.AddKeyedTransient<IAiService, AzureFoundryService>(AiProvider.AzureFoundry);
builder.Services.AddKeyedTransient<IAiService, HybridAiService>(AiProvider.DeepSeekWithFal);
builder.Services.AddTransient<IAiService, DeepSeekService>(); // Register DeepSeekService for direct injection into HybridAiService
builder.Services.AddTransient<IAiService, FalAiService>(); // Register FalAiService for direct injection into HybridAiService
// builder.Services.AddKeyedTransient<IAiService, PerplexityService>(AiProvider.Perplexity); // Uncomment when implemented

builder.Services.AddTransient<IGeneratorFactory, GeneratorFactory>();

builder.Services.AddTransient<ICryptoService, CryptoService>();
builder.Services.AddTransient<IFeedService, FeedService>();
builder.Services.Configure<OpenAiOptions>(builder.Configuration.GetSection("OpenAI"));
builder.Services.Configure<FalAiOptions>(builder.Configuration.GetSection("FalAi"));
builder.Services.AddSingleton<IValidateOptions<OpenAiOptions>, OpenAiOptionsValidator>();
builder.Services.Configure<AzureFoundryOptions>(builder.Configuration.GetSection("AzureFoundry"));
builder.Services.AddSingleton<IValidateOptions<AzureFoundryOptions>, AzureFoundryOptionsValidator>();

builder.Build().Run();
