using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using XPoster.Contracts;
using XPoster.Credentials;
using XPoster.Extensions;
using XPoster.Models;
using XPoster.Orchestrators;
using XPoster.SenderPlugins;
using XPoster.Services;

var builder = FunctionsApplication.CreateBuilder(args);

builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();

builder.Logging.Services.Configure<LoggerFilterOptions>(options =>
{
    LoggerFilterOptions? defaultRule = options.Rules.FirstOrDefault(rule => rule.ProviderName
        == "Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider") as LoggerFilterOptions;
    LoggerFilterRule? rule = options.Rules.FirstOrDefault(r => r.ProviderName
        == "Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider");
    if (rule is not null)
    {
        options.Rules.Remove(rule);
    }
});

// Azure Key Vault Configuration Provider.
var keyVaultUri = builder.Configuration["KEYVAULT_URI"]
    ?? throw new InvalidOperationException("KEYVAULT_URI app setting is not set.");

((IConfigurationBuilder)builder.Configuration).AddAzureKeyVault(
    new Uri(keyVaultUri),
    new DefaultAzureCredential());

// Typed sender credentials.
builder.Services
    .AddOptions<XCredentials>()
    .BindConfiguration(string.Empty)
    .ValidateOnStart();

builder.Services
    .AddOptions<LinkedInCredentials>()
    .BindConfiguration(string.Empty)
    .ValidateOnStart();

builder.Services
    .AddOptions<IgCredentials>()
    .BindConfiguration(string.Empty)
    .ValidateOnStart();

builder.Services.AddHttpClients();

builder.Services.AddLogging();
builder.Services.AddMemoryCache();

builder.Services.AddTransient<XSender>();
builder.Services.AddTransient<InSender>();
builder.Services.AddTransient<IgSender>();
builder.Services.AddTransient<DryRunSender>();

// ITimeProvider registration:
//   Development + ForceHour set  → LocalOverrideTimeProvider (pins clock to the configured UTC hour)
//   All other environments        → TimeProvider (returns DateTime.UtcNow)
var isDevelopment = builder.Environment.IsDevelopment();
var forceHour = builder.Configuration["ForceHour"];

if (isDevelopment && !string.IsNullOrWhiteSpace(forceHour))
    builder.Services.AddSingleton<ITimeProvider, LocalOverrideTimeProvider>();
else
    builder.Services.AddSingleton<ITimeProvider, XPoster.Services.TimeProvider>();

// Register AI capability interfaces as keyed services by AiProvider.
// Each key activates only the capabilities the provider actually supports.
// Attempting to resolve an unsupported capability returns null via GetKeyedService —
// this surfaces explicitly at the point of use inside FeedOrchestrator, not silently.
builder.Services.AddXPosterAiProviders();

// ISlotProfileProvider registration:
//   EnableDryRunSlot = true   → DryRunSlotProfileProvider
//   All other environments     → DefaultSlotProfileProvider
var enableDryRunRaw = builder.Configuration["EnableDryRunSlot"];
var enableDryRun = bool.TryParse(enableDryRunRaw, out var parsed) && parsed;

if (enableDryRun)
    builder.Services.AddSingleton<ISlotProfileProvider>(sp =>
        new DryRunSlotProfileProvider(new DefaultSlotProfileProvider()));
else
    builder.Services.AddSingleton<ISlotProfileProvider, DefaultSlotProfileProvider>();

builder.Services.AddTransient<IOrchestratorFactory, OrchestratorFactory>();

builder.Services.AddTransient<ICryptoService, CryptoService>();
builder.Services.AddTransient<IFeedService, FeedService>();

// IFeedUrlProvider registration — reads FeedOptions:Urls from app settings.
builder.Services.Configure<FeedOptions>(builder.Configuration.GetSection(FeedOptions.SectionName));
builder.Services.AddSingleton<IFeedUrlProvider, ConfigurationFeedUrlProvider>();

// AI provider options: each extension method owns its SectionName constant
// and encapsulates Configure<T> + AddSingleton<IValidateOptions<T>> in one call.
builder.Services.AddOpenAiOptions(builder.Configuration);
builder.Services.AddAzureFoundryOptions(builder.Configuration);
builder.Services.AddDeepSeekOptions(builder.Configuration);
builder.Services.AddFalAiOptions(builder.Configuration);
builder.Services.AddPerplexityOptions(builder.Configuration);

builder.Build().Run();
