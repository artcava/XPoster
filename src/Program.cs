using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Http.Resilience;
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

// Named HttpClients with standard Polly resilience pipeline:
// retry (3 attempts, exponential back-off + jitter), circuit-breaker, and per-attempt timeout.
// Secrets never appear here — all sender credentials are read from Azure Key Vault at runtime.
builder.Services.AddHttpClient("OpenAI")
    .AddStandardResilienceHandler(options =>
    {
        options.Retry.MaxRetryAttempts = 3;
        options.Retry.Delay = TimeSpan.FromSeconds(2);
        options.AttemptTimeout.Timeout = TimeSpan.FromSeconds(30);
        options.CircuitBreaker.BreakDuration = TimeSpan.FromSeconds(30);
    });

builder.Services.AddHttpClient("AzureFoundry")
    .AddStandardResilienceHandler(options =>
    {
        options.Retry.MaxRetryAttempts = 3;
        options.Retry.Delay = TimeSpan.FromSeconds(2);
        options.AttemptTimeout.Timeout = TimeSpan.FromSeconds(30);
        options.CircuitBreaker.BreakDuration = TimeSpan.FromSeconds(30);
    });

builder.Services.AddHttpClient("DeepSeek")
    .AddStandardResilienceHandler(options =>
    {
        options.Retry.MaxRetryAttempts = 3;
        options.Retry.Delay = TimeSpan.FromSeconds(2);
        options.AttemptTimeout.Timeout = TimeSpan.FromSeconds(30);
        options.CircuitBreaker.BreakDuration = TimeSpan.FromSeconds(30);
    });

builder.Services.AddHttpClient("FalAi")
    .AddStandardResilienceHandler(options =>
    {
        options.Retry.MaxRetryAttempts = 3;
        options.Retry.Delay = TimeSpan.FromSeconds(2);
        options.AttemptTimeout.Timeout = TimeSpan.FromSeconds(60); // image gen may be slower
        options.CircuitBreaker.BreakDuration = TimeSpan.FromSeconds(30);
    });

builder.Services.AddHttpClient("LinkedIn")
    .AddStandardResilienceHandler(options =>
    {
        options.Retry.MaxRetryAttempts = 3;
        options.Retry.Delay = TimeSpan.FromSeconds(2);
        options.AttemptTimeout.Timeout = TimeSpan.FromSeconds(30);
        options.CircuitBreaker.BreakDuration = TimeSpan.FromSeconds(30);
    });

builder.Services.AddHttpClient("Instagram")
    .AddStandardResilienceHandler(options =>
    {
        options.Retry.MaxRetryAttempts = 3;
        options.Retry.Delay = TimeSpan.FromSeconds(2);
        options.AttemptTimeout.Timeout = TimeSpan.FromSeconds(30);
        options.CircuitBreaker.BreakDuration = TimeSpan.FromSeconds(30);
    });

builder.Services.AddLogging();
builder.Services.AddMemoryCache();

// Key Vault service — Singleton; credentials are read per-call via DefaultAzureCredential.
// Works via az login locally and via Managed Identity in Azure.
builder.Services.AddSingleton<IKeyVaultService, KeyVaultService>();

builder.Services.AddTransient<XSender>();
builder.Services.AddTransient<InSender>();
builder.Services.AddTransient<IgSender>();

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
