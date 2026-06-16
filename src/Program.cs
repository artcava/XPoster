using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using XPoster.Abstraction;
using XPoster.Extensions;
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
    LoggerFilterRule? defaultRule = options.Rules.FirstOrDefault(rule => rule.ProviderName
        == "Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider");
    if (defaultRule is not null)
    {
        options.Rules.Remove(defaultRule);
    }
});

builder.Services.AddHttpClients();

builder.Services.AddLogging();
builder.Services.AddMemoryCache();

// Key Vault service — Singleton; credentials are read per-call via DefaultAzureCredential.
// Works via az login locally and via Managed Identity in Azure.
builder.Services.AddSingleton<IKeyVaultService, KeyVaultService>();

builder.Services.AddTransient<XSender>();
builder.Services.AddTransient<InSender>();
builder.Services.AddTransient<IgSender>();
builder.Services.AddTransient<DryRunSender>();

// ITimeProvider registration:
//   Development + ForceHour set  → LocalOverrideTimeProvider (pins clock to the configured UTC hour)
//   All other environments        → TimeProvider (returns DateTime.UtcNow)
// To restore production behaviour locally, remove or empty 'ForceHour' in local.settings.json.
var isDevelopment = builder.Environment.IsDevelopment();
var forceHour = builder.Configuration["ForceHour"];

if (isDevelopment && !string.IsNullOrWhiteSpace(forceHour))
    builder.Services.AddSingleton<ITimeProvider, LocalOverrideTimeProvider>();
else
    builder.Services.AddSingleton<ITimeProvider, XPoster.Services.TimeProvider>();

// Register IAiServiceFactory and all IAiService implementations
builder.Services.AddSingleton<IAiServiceFactory, AiServiceFactory>();
builder.Services.AddKeyedTransient<IAiService, OpenAiService>(AiProvider.OpenAi);
builder.Services.AddKeyedTransient<IAiService, AzureFoundryService>(AiProvider.AzureFoundry);
builder.Services.AddKeyedTransient<IAiService, HybridAiService>(AiProvider.DeepSeekWithFal);
builder.Services.AddTransient<DeepSeekService>(); // Concrete type for direct injection into HybridAiService
builder.Services.AddTransient<FalAiImageService>(); // Concrete type for direct injection into HybridAiService
// builder.Services.AddKeyedTransient<IAiService, PerplexityService>(AiProvider.Perplexity); // Uncomment when implemented

builder.Services.AddTransient<IOrchestratorFactory, OrchestratorFactory>();

builder.Services.AddTransient<ICryptoService, CryptoService>();
builder.Services.AddTransient<IFeedService, FeedService>();
builder.Services.Configure<OpenAiOptions>(builder.Configuration.GetSection("OpenAI"));
builder.Services.AddSingleton<IValidateOptions<OpenAiOptions>, OpenAiOptionsValidator>();
builder.Services.Configure<AzureFoundryOptions>(builder.Configuration.GetSection("AzureFoundry"));
builder.Services.AddSingleton<IValidateOptions<AzureFoundryOptions>, AzureFoundryOptionsValidator>();
builder.Services.Configure<DeepSeekOptions>(builder.Configuration.GetSection("DeepSeek"));
builder.Services.AddSingleton<IValidateOptions<DeepSeekOptions>, DeepSeekOptionsValidator>();
builder.Services.Configure<FalAiOptions>(builder.Configuration.GetSection("FalAi"));
builder.Services.AddSingleton<IValidateOptions<FalAiOptions>, FalAiOptionsValidator>();

builder.Build().Run();
