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
    LoggerFilterRule? defaultRule = options.Rules.FirstOrDefault(rule => rule.ProviderName
        == "Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider");
    if (defaultRule is not null)
    {
        options.Rules.Remove(defaultRule);
    }
});

// Azure Key Vault Configuration Provider.
// Secrets are loaded into IConfiguration and bound to typed IOptions<T> classes.
// DefaultAzureCredential is the same credential chain used by the former KeyVaultService.
//
// NOTE: FunctionsApplicationBuilder.Configuration is a ConfigurationManager.
// AddAzureKeyVault is an extension method on IConfigurationBuilder, so an explicit
// cast is required — ConfigurationManager implements IConfigurationBuilder but does
// not expose the extension methods without the cast.
var keyVaultUri = builder.Configuration["KEYVAULT_URI"]
    ?? throw new InvalidOperationException("KEYVAULT_URI app setting is not set.");

((IConfigurationBuilder)builder.Configuration).AddAzureKeyVault(
    new Uri(keyVaultUri),
    new DefaultAzureCredential());

// Typed sender credentials — bound flat from IConfiguration (secret names match property names).
// ValidateOnStart() ensures missing secrets fail at startup rather than at first invocation.
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

// ITagReplacementProvider registration — reads TagReplacementOptions:Replacements from app settings.
builder.Services.Configure<TagReplacementOptions>(builder.Configuration.GetSection(TagReplacementOptions.SectionName));
builder.Services.AddSingleton<ITagReplacementProvider, ConfigurationTagReplacementProvider>();

// AI provider options: each extension method owns its SectionName constant
// and encapsulates Configure<T> + AddSingleton<IValidateOptions<T>> in one call.
builder.Services.AddOpenAiOptions(builder.Configuration);
builder.Services.AddAzureFoundryOptions(builder.Configuration);
builder.Services.AddDeepSeekOptions(builder.Configuration);
builder.Services.AddFalAiOptions(builder.Configuration);
builder.Services.AddPerplexityOptions(builder.Configuration);

builder.Build().Run();
