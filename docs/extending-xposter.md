# Extending XPoster

XPoster is designed around three extension points: **Senders** (platform plugins), **Generators** (content strategies), and **AI Providers** (model integrations). Each maps to a dedicated abstraction and can be implemented without modifying any existing component.

> For the architectural rationale behind each extension point, see [architecture.md §5](architecture.md#5-extension-points).

---

## Adding a New Sender (Platform)

A sender is a class that implements `ISender` and knows how to publish a `Post` to a specific social network. It owns all platform-specific concerns: authentication, payload serialisation, rate-limit handling, and error mapping.

### Step 1 — Implement ISender

```csharp
// src/SenderPlugins/TikTokSender.cs
public class TikTokSender : ISender
{
    public int MessageMaxLength => 150;

    public async Task<bool> SendAsync(Post post)
    {
        // Call TikTok API here.
        // Return false (do not throw) on non-fatal platform errors.
        return true;
    }
}
```

> `MessageMaxLength` must reflect the platform's actual character limit. Generators use this value to truncate content before calling `SendAsync`.

### Step 2 — Register in DI

```csharp
// src/Program.cs
builder.Services.AddTransient<TikTokSender>();
```

### Step 3 — Add Enum Value

```csharp
// src/Abstraction/Enums.cs
public enum MessageSender
{
    // existing values...
    TikTokSummaryFeed,
    TikTokPowerLaw,
}
```

### Step 4 — Wire in GeneratorFactory

`GeneratorFactory.Generate()` resolves the concrete sender through a **switch expression** that maps each `MessageSender` enum value to a specific class retrieved from the DI container. The result is cast to `ISender` because `GetService` returns `object?`; the factory then passes the interface reference to `CreateGeneratorInstance`, keeping generators fully decoupled from sender implementations.

Add two arms to the existing switch expression inside `Generate()`:

```csharp
// src/Implementation/GeneratorFactory.cs — sender switch expression
ISender? sender = profile.SenderType switch
{
    // existing arms ...
    MessageSender.XPowerLaw     => _serviceProvider.GetService(typeof(XSender))    as ISender,
    MessageSender.XSummaryFeed  => _serviceProvider.GetService(typeof(XSender))    as ISender,
    MessageSender.InSummaryFeed => _serviceProvider.GetService(typeof(InSender))   as ISender,
    MessageSender.InPowerLaw    => _serviceProvider.GetService(typeof(InSender))   as ISender,
    MessageSender.IgSummaryFeed => _serviceProvider.GetService(typeof(IgSender))   as ISender,
    MessageSender.IgPowerLaw    => _serviceProvider.GetService(typeof(IgSender))   as ISender,
    // new arms
    MessageSender.TikTokSummaryFeed => _serviceProvider.GetService(typeof(TikTokSender)) as ISender,
    MessageSender.TikTokPowerLaw    => _serviceProvider.GetService(typeof(TikTokSender)) as ISender,
    _ => null
};
```

> Both `TikTokSummaryFeed` and `TikTokPowerLaw` resolve to the same `TikTokSender` class. The two enum values express *what is being posted* (content strategy + platform), not *how* — `TikTokSender` owns the how. This mirrors the existing pattern for `XSender` and `InSender`.

### Step 5 — Add a ScheduledGenerationProfile entry

Add the new sender to the `slotProfiles` list in `GeneratorFactory.cs`, specifying the hour, sender type, generator type, and (optionally) the AI provider for that slot:

```csharp
// src/Implementation/GeneratorFactory.cs — slotProfiles list
new ScheduledGenerationProfile(20, MessageSender.TikTokSummaryFeed, typeof(FeedGenerator), AiProvider.OpenAi),
```

**Validation**: Write a unit test for the new sender using a mock `Post` to verify serialisation and error-return behaviour before integration.

---

## Adding a New Generator (Content Strategy)

A generator inherits from `BaseGenerator` and overrides `GenerateAsync()` to produce a `Post`. It receives its dependencies — sender, AI service, and any data services — via constructor injection; `GeneratorFactory` resolves them automatically through reflection.

### Step 1 — Extend BaseGenerator

```csharp
// src/Implementation/QuoteGenerator.cs
public class QuoteGenerator : BaseGenerator
{
    public QuoteGenerator(ISender sender, ILogger<QuoteGenerator> logger, IAiService aiService)
        : base(sender, logger, aiService) { }

    public override async Task<Post>? GenerateAsync()
    {
        // Return null (do not throw) when no content can be produced.
        // The orchestrator will skip posting gracefully.
        var quote = await _aiService.GetCompletionAsync("Generate a motivational tech quote.", 100);
        if (string.IsNullOrWhiteSpace(quote)) return null;
        return new Post { Content = quote };
    }
}
```

> **Invariant**: `GenerateAsync()` must return `null` — not throw — when content cannot be produced. The orchestrator uses a `null` return as the signal to skip the current posting slot.

### Step 2 — Add a ScheduledGenerationProfile entry

Reference the new generator type in the `slotProfiles` list. `CreateGeneratorInstance` in `GeneratorFactory` resolves constructor parameters automatically via reflection:

```csharp
// src/Implementation/GeneratorFactory.cs — slotProfiles list
new ScheduledGenerationProfile(10, MessageSender.XSummaryFeed, typeof(QuoteGenerator), AiProvider.Perplexity),
```

No other change to `GeneratorFactory` is required.

---

## Adding a New AI Provider

The AI layer is abstracted behind `IAiService`. `AiServiceFactory` resolves implementations using the .NET **keyed services** mechanism: each `IAiService` is registered against its `AiProvider` enum value as the key, and `AiServiceFactory.GetByProvider()` calls `GetKeyedService<IAiService>(provider)` to retrieve it. There is no switch inside the factory — adding a new provider requires only registering the implementation under the correct key and declaring that key as supported.

### Step 1 — Add the Enum Value

Append a new value to `AiProvider`. Assign an explicit integer to avoid accidental renumbering of existing values:

```csharp
// src/Abstraction/AiProvider.cs
public enum AiProvider
{
    None         = 0,
    OpenAi       = 1,
    Perplexity   = 2,
    AzureFoundry = 3,
    Anthropic    = 4,  // new
}
```

### Step 2 — Implement IAiService

```csharp
// src/Services/AnthropicAiService.cs
public class AnthropicAiService : IAiService
{
    // Model names, SDK dependencies, and API keys are internal to this class.
    public async Task<string> GetCompletionAsync(string prompt, int maxTokens)
    {
        // Call Anthropic Messages API
    }

    public async Task<byte[]> GenerateImageAsync(string prompt)
    {
        // Anthropic does not offer a native image model;
        // delegate to a compatible image provider or throw NotSupportedException.
    }
}
```

### Step 3 — Register as a Keyed Service and Declare as Supported

`AiServiceFactory` resolves providers via `GetKeyedService<IAiService>(provider)`, so the implementation must be registered as a **keyed transient** against its `AiProvider` enum value — not as a plain `AddTransient`. A plain registration would be invisible to the factory.

```csharp
// src/Program.cs
builder.Services.AddKeyedTransient<IAiService, AnthropicAiService>(AiProvider.Anthropic);
```

Then add the new value to the `_supportedProviders` set in `AiServiceFactory`. This guard is what `GetByProvider` checks before attempting resolution; without it the factory throws `ArgumentException` even if the service is correctly registered:

```csharp
// src/Implementation/AiServiceFactory.cs
private static readonly HashSet<AiProvider> _supportedProviders =
[
    AiProvider.OpenAi,
    AiProvider.AzureFoundry,
    AiProvider.Anthropic,  // new
];
```

No further change to `AiServiceFactory` is needed. The new provider is immediately available for assignment in any `ScheduledGenerationProfile` and via the global `AiProvider` configuration key.

---

## Adding a New Service (Data Source)

For new external data integrations (e.g., a news API, a stock ticker, a weather feed), define an interface in `src/Abstraction/Interfaces/` and implement it in `src/Implementation/Services/`. Inject the new service into the generator that needs it — `CreateGeneratorInstance` will resolve it automatically.

```csharp
// src/Abstraction/Interfaces/INewsService.cs
public interface INewsService
{
    Task<IEnumerable<string>> GetHeadlinesAsync(int count);
}

// src/Implementation/Services/NewsService.cs
public class NewsService : INewsService
{
    public async Task<IEnumerable<string>> GetHeadlinesAsync(int count)
    {
        // Call a news API
    }
}
```

Register in `Program.cs`:

```csharp
builder.Services.AddTransient<INewsService, NewsService>();
```

---

## Design Constraints

All extensions must respect the following invariants to integrate correctly with the pipeline:

- **Senders must be stateless.** Do not cache authentication tokens in instance fields; use the DI-injected configuration or a token-provider service. The DI container manages lifetime.
- **`SendAsync` must return `false`, not throw, on non-fatal platform errors.** Throwing from a sender propagates the exception to the orchestrator and prevents App Insights from recording a clean skip.
- **`MessageMaxLength` must be accurate.** Generators rely on this value to truncate content before calling `SendAsync`. An incorrect value causes silent data loss at the platform layer.
- **`GenerateAsync` must return `null`, not throw, when no content can be produced.** The orchestrator treats a `null` return as a graceful skip; an exception is treated as a pipeline failure.
- **Generators must be idempotent where possible.** Avoid side effects beyond returning a `Post`. In particular, do not call `ISender.SendAsync` from inside a generator — that responsibility belongs to the orchestrator.
- **All external HTTP calls must go through `IHttpClientFactory`.** This ensures connection pooling, retry policies, and timeout configuration are applied consistently.
- See [architecture.md](architecture.md) for full ADRs and design pattern rationale.
