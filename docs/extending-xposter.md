# Extending XPoster

XPoster is designed around three extension points: **Senders** (platform plugins), **Generators** (content strategies), and **Services** (external integrations).

## Adding a New Sender (Platform)

A sender is a class that implements `ISender` and knows how to publish a `Post` to a specific social network.

### Step 1 — Implement ISender

```csharp
// src/SenderPlugins/TikTokSender.cs
public class TikTokSender : ISender
{
    public int MessageMaxLenght => 150;

    public async Task<bool> SendAsync(Post post)
    {
        // Call TikTok API here
        return true;
    }
}
```

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

### Step 4 — Add a ScheduledGenerationProfile entry

Add the new sender to the `slotProfiles` list in `GeneratorFactory.cs`, specifying the hour, sender type, generator type, and (optionally) the AI provider for that slot:

```csharp
// src/Implementation/GeneratorFactory.cs — slotProfiles list
new ScheduledGenerationProfile(20, MessageSender.TikTokSummaryFeed, typeof(FeedGenerator), AiProvider.OpenAi),
```

Also add a matching `case` in the `GeneratorFactory.Generate()` switch so the factory can resolve `TikTokSender` from the DI container:

```csharp
case MessageSender.TikTokSummaryFeed:
    sender = _serviceProvider.GetRequiredService<TikTokSender>();
    break;
```

---

## Adding a New Generator (Content Strategy)

A generator inherits from `BaseGenerator` and overrides `GenerateAsync()` to produce a `Post`.

```csharp
// src/Implementation/QuoteGenerator.cs
public class QuoteGenerator : BaseGenerator
{
    public QuoteGenerator(ISender sender, ILogger logger, IAiService aiService)
        : base(sender, logger, aiService) { }

    public override async Task<Post>? GenerateAsync()
    {
        var quote = await _aiService.GetCompletionAsync("Generate a motivational tech quote.", 100);
        return new Post { Content = quote };
    }
}
```

Then reference the new generator type in a `ScheduledGenerationProfile` entry:

```csharp
new ScheduledGenerationProfile(10, MessageSender.XSummaryFeed, typeof(QuoteGenerator), AiProvider.Perplexity),
```

`CreateGeneratorInstance` in `GeneratorFactory` will resolve constructor parameters automatically via reflection.

---

## Adding a New Service

For external integrations (e.g., a new data source), create an interface in `src/Abstraction/Interfaces/` and implement it in `src/Implementation/Services/`.

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

- Keep senders **stateless** — do not cache auth tokens in instance fields; use the DI-injected config.
- Generators must be **idempotent** where possible — avoid side effects beyond calling `ISender.SendAsync`.
- All external HTTP calls should go through `IHttpClientFactory` to respect connection pooling.
- See [docs/architecture.md](architecture.md) for full ADRs and design pattern rationale.
