# XPoster 🚀

[![Azure Functions](https://img.shields.io/badge/Azure%20Functions-v4-0062AD?logo=azurefunctions&logoColor=white)](https://azure.microsoft.com/en-us/services/functions/)
[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12.0-239120?logo=csharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![OpenAI](https://img.shields.io/badge/OpenAI-Powered-412991?logo=openai&logoColor=white)](https://openai.com/)
[![License](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![Deployment](https://img.shields.io/badge/Deployed-Azure-blue)](https://xposterfunction.azurewebsites.net/)

> **AI-Powered Social Media Automation Platform**
> 
> XPoster è una Azure Function che automatizza la pubblicazione di contenuti su multiple piattaforme social (Twitter/X, LinkedIn, Instagram) utilizzando intelligenza artificiale per la generazione e curation dei contenuti.

---

## 📋 Indice

- [Features](#-features)
- [Architettura](#-architettura)
- [Tecnologie](#-tecnologie)
- [Getting Started](#-getting-started)
- [Configurazione](#-configurazione)
- [Deployment](#-deployment)
- [Utilizzo](#-utilizzo)
- [Schedulazione](#-schedulazione)
- [Estensibilità](#-estensibilità)
- [Testing](#-testing)
- [Monitoring](#-monitoring)
- [Roadmap](#-roadmap)
- [Contributing](#-contributing)
- [License](#-license)

---

## ✨ Features

### 🤖 Content Generation
- **AI-Powered Summarization**: Riassunti intelligenti di feed RSS utilizzando GPT-4
- **Image Generation**: Creazione automatica di immagini contestuali con DALL-E 3
- **Smart Hashtags**: Conversione automatica di keyword in hashtag ottimizzati
- **Multi-Strategy**: Supporto per diversi algoritmi di generazione contenuti

### 🌐 Multi-Platform Publishing
- **Twitter/X**: Pubblicazione automatica con supporto immagini
- **LinkedIn**: Post su profili personali e pagine aziendali
- **Instagram**: Publishing via Graph API (in sviluppo)

### ⚙️ Automation & Scheduling
- **Timer-Based Execution**: Esecuzione automatica ogni 2 ore
- **Smart Scheduling**: Diverse strategie di posting basate sull'orario
- **Conditional Logic**: Pubblicazione solo quando appropriato

### 📊 Enterprise Features
- **Application Insights**: Monitoring completo e telemetria
- **Structured Logging**: Log dettagliati per debugging e audit
- **Error Handling**: Gestione robusta degli errori con retry logic
- **Dependency Injection**: Architettura modulare e testabile

---

## 🏗️ Architettura

### High-Level Overview

```
┌─────────────────────────┐
│   Azure Timer Trigger   │
│   (ogni 2h alle :05)    │
└───────────┬─────────────┘
            │
            ▼
┌─────────────────────────┐
│   Generator Factory     │ ◄─── Strategy Pattern
│   (Selettore Orario)    │
└───────────┬─────────────┘
            │
    ┌───────┴────────┬──────────────┐
    ▼                ▼              ▼
┌──────────┐   ┌──────────┐   ┌──────────┐
│   Feed   │   │ PowerLaw │   │    No    │
│Generator │   │Generator │   │Generator │
└─────┬────┘   └─────┬────┘   └──────────┘
      │              │
      └──────┬───────┘
             │
             ▼
    ┌────────────────┐
    │   Services     │
    ├────────────────┤
    │ • AI Service   │ ◄─── OpenAI Integration
    │ • Feed Service │ ◄─── RSS Parser
    │ • Crypto Svc   │ ◄─── Security Utils
    └────────┬───────┘
             │
             ▼
    ┌────────────────┐
    │ Sender Plugins │
    ├────────────────┤
    │ • XSender      │ ◄─── Twitter/X API
    │ • InSender     │ ◄─── LinkedIn API
    │ • IgSender     │ ◄─── Instagram API
    └────────────────┘
```

### Componenti Principali

#### 1. **XFunction** (Entry Point)
Azure Function timer-triggered che orchestra l'intero flusso di pubblicazione.

**Cron Expression**: `0 5 */2 * * *` (ogni 2 ore al minuto 05)

#### 2. **GeneratorFactory** (Factory + Strategy Pattern)
Seleziona dinamicamente il generatore appropriato basandosi sull'orario corrente.

| Ora | Piattaforma | Strategia |
|-----|-------------|-----------|
| 06:00 | LinkedIn | Feed Summary |
| 08:00 | Twitter/X | Feed Summary |
| 14:00 | LinkedIn | Power Law |
| 16:00 | Twitter/X | Power Law |

#### 3. **Generators** (Content Strategy)
- **FeedGenerator**: Analizza feed RSS crypto, genera riassunti AI, crea immagini
- **PowerLawGenerator**: Genera contenuti basati su distribuzione statistica
- **NoGenerator**: Placeholder per slot orari senza pubblicazione

#### 4. **Services Layer**
- **AiService**: Interfaccia con Azure OpenAI (GPT-4, DALL-E 3)
- **FeedService**: Parser RSS con caching e filtraggio intelligente
- **CryptoService**: Utility crittografiche per sicurezza

#### 5. **Sender Plugins** (Platform Abstraction)
- **XSender**: Twitter/X via LinqToTwitter
- **InSender**: LinkedIn via HTTP API
- **IgSender**: Instagram via Graph API (in sviluppo)

---

## 🛠️ Tecnologie

### Core Framework
- **.NET 8.0** - Framework principale
- **Azure Functions v4** - Serverless compute
- **C# 12** - Linguaggio

### AI & ML
- **Azure OpenAI** - GPT-4 per summarization
- **DALL-E 3** - Generazione immagini

### Social Media APIs
- **LinqToTwitter 6.15.0** - Twitter/X integration
- **LinkedIn REST API v2** - LinkedIn publishing
- **Instagram Graph API** - Instagram (in sviluppo)

### Monitoring & Logging
- **Application Insights** - Telemetria e monitoring
- **ILogger** - Structured logging

### Utilities
- **System.ServiceModel.Syndication** - RSS parsing
- **Microsoft.Extensions.Http** - HTTP client factory

---

## 🚀 Getting Started

### Prerequisiti

- **.NET 8.0 SDK** ([Download](https://dotnet.microsoft.com/download/dotnet/8.0))
- **Azure Functions Core Tools** ([Install](https://docs.microsoft.com/azure/azure-functions/functions-run-local))
- **Visual Studio 2022** o **Visual Studio Code**
- **Account Azure** (con sottoscrizione attiva)
- **Azure OpenAI Service** (con deployment GPT-4 e DALL-E 3)

### Clona il Repository

```bash
git clone https://github.com/artcava/XPoster.git
cd XPoster
```

### Ripristina Dipendenze

```bash
dotnet restore
```

### Build del Progetto

```bash
dotnet build
```

### Esegui i Test

```bash
dotnet test
```

---

## ⚙️ Configurazione

### 1. Local Development

Crea un file `local.settings.json` nella directory `src/`:

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    
    "X_API_KEY": "your_twitter_api_key",
    "X_API_SECRET": "your_twitter_api_secret",
    "X_ACCESS_TOKEN": "your_twitter_access_token",
    "X_ACCESS_TOKEN_SECRET": "your_twitter_access_token_secret",
    
    "LINKEDIN_ACCESS_TOKEN": "your_linkedin_token",
    "LINKEDIN_ORGANIZATION_ID": "your_linkedin_org_id",
    
    "INSTAGRAM_ACCESS_TOKEN": "your_instagram_token",
    "INSTAGRAM_BUSINESS_ACCOUNT_ID": "your_instagram_account_id",
    
    "AZURE_OPENAI_ENDPOINT": "https://your-resource.openai.azure.com/",
    "AZURE_OPENAI_KEY": "your_openai_key",
    "AZURE_OPENAI_DEPLOYMENT_NAME": "gpt-4"
  }
}
```

### 2. Azure Configuration

#### App Settings (Azure Portal)

Naviga su **Azure Portal** → **Function App** → **Configuration** → **Application Settings**

Aggiungi le stesse variabili di `local.settings.json`.

#### Managed Identity (Recommended)

Per sicurezza avanzata, usa Azure Managed Identity:

1. Abilita **System Assigned Managed Identity** sulla Function App
2. Assegna ruoli appropriati su:
   - Azure OpenAI Service
   - Azure Key Vault (per secrets)
3. Modifica `Program.cs` per usare `DefaultAzureCredential`

```csharp
builder.Services.AddSingleton<OpenAIClient>(sp =>
{
    var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT"));
    return new OpenAIClient(endpoint, new DefaultAzureCredential());
});
```

---

## 📦 Deployment

### Opzione 1: GitHub Actions (CI/CD Automatizzato)

Il repository include già una workflow GitHub Actions (`.github/workflows/master_xposterfunction.yml`).

**Setup**:
1. Crea una Function App su Azure Portal
2. Scarica il **Publish Profile** dalla Function App
3. Aggiungi il contenuto come **Secret** su GitHub:
   - Nome: `AZURE_FUNCTIONAPP_PUBLISH_PROFILE`
4. Ogni push su `master` triggera il deployment automatico

### Opzione 2: Azure CLI

```bash
# Login
az login

# Crea Resource Group
az group create --name XPosterRG --location westeurope

# Crea Storage Account
az storage account create \
  --name xposterstorage \
  --resource-group XPosterRG \
  --location westeurope \
  --sku Standard_LRS

# Crea Function App
az functionapp create \
  --name xposterfunction \
  --resource-group XPosterRG \
  --consumption-plan-location westeurope \
  --runtime dotnet-isolated \
  --runtime-version 8 \
  --functions-version 4 \
  --storage-account xposterstorage

# Deploy
cd src
func azure functionapp publish xposterfunction
```

### Opzione 3: Visual Studio

1. Right-click sul progetto `XPoster`
2. Select **Publish**
3. Choose **Azure** → **Azure Function App (Windows)**
4. Seleziona o crea una Function App
5. Click **Publish**

---

## 🎯 Utilizzo

### Esecuzione Locale

```bash
cd src
func start
```

La function sarà disponibile localmente e eseguirà secondo la cron expression configurata.

### Trigger Manuale (Azure Portal)

1. Vai su **Azure Portal** → **Function App** → **Functions**
2. Seleziona `XPosterFunction`
3. Click su **Test/Run**
4. Click su **Run**

### Trigger via HTTP (opzionale)

Aggiungi un HTTP trigger per testing:

```csharp
[Function("XPosterHttpTrigger")]
public async Task<HttpResponseData> RunHttp(
    [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
{
    await Run(null);
    var response = req.CreateResponse(HttpStatusCode.OK);
    await response.WriteStringAsync("XPoster executed successfully");
    return response;
}
```

---

## ⏰ Schedulazione

### Configurazione Oraria

Modifica `GeneratorFactory.cs` per personalizzare la schedulazione:

```csharp
private static readonly Dictionary<int, MessageSender> sendParameters = new()
{
    { 6, MessageSender.InSummaryFeed },   // LinkedIn Feed
    { 8, MessageSender.XSummaryFeed },    // Twitter Feed
    { 10, MessageSender.IgSummaryFeed },  // Instagram Feed (attiva se pronto)
    { 14, MessageSender.InPowerLaw },     // LinkedIn Power Law
    { 16, MessageSender.XPowerLaw },      // Twitter Power Law
    { 18, MessageSender.IgPowerLow },     // Instagram Power Law
};
```

### Modifica Cron Expression

Cambia la frequenza di esecuzione in `XFunction.cs`:

```csharp
// Ogni 2 ore (default)
[TimerTrigger("0 5 */2 * * *")]

// Ogni ora
[TimerTrigger("0 5 * * * *")]

// Ogni 4 ore
[TimerTrigger("0 5 */4 * * *")]

// Giorni feriali alle 9:00 e 17:00
[TimerTrigger("0 0 9,17 * * 1-5")]
```

---

## 🔌 Estensibilità

### Aggiungere una Nuova Piattaforma

**1. Crea il Sender Plugin**

```csharp
// src/SenderPlugins/TikTokSender.cs
public class TikTokSender : ISender
{
    public int MessageMaxLenght => 150;

    public async Task<bool> SendAsync(Post post)
    {
        // Implementa logica TikTok API
        return true;
    }
}
```

**2. Registra nel DI Container**

```csharp
// src/Program.cs
builder.Services.AddTransient<TikTokSender>();
```

**3. Aggiungi Enum**

```csharp
// src/Abstraction/Enums.cs
public enum MessageSender
{
    // ...
    TikTokSummaryFeed,
}
```

**4. Configura Factory**

```csharp
// src/Implementation/GeneratorFactory.cs
case MessageSender.TikTokSummaryFeed:
    return GetInstance<FeedGenerator>(
        _serviceProvider.GetService(typeof(TikTokSender)) as ISender
    );
```

### Aggiungere un Nuovo Generatore

```csharp
// src/Implementation/QuoteGenerator.cs
public class QuoteGenerator : BaseGenerator
{
    public override async Task<Post>? GenerateAsync()
    {
        // Logica per generare quote motivazionali
        var quote = await _aiService.GetQuoteAsync();
        return new Post { Content = quote };
    }
}
```

---

## 🧪 Testing

### Struttura Test

```
tests/
├── XPoster.Tests/
│   ├── Generators/
│   │   ├── FeedGeneratorTests.cs
│   │   └── PowerLawGeneratorTests.cs
│   ├── Services/
│   │   ├── AiServiceTests.cs
│   │   └── FeedServiceTests.cs
│   └── SenderPlugins/
│       ├── XSenderTests.cs
│       └── InSenderTests.cs
```

### Eseguire i Test

```bash
# Tutti i test
dotnet test

# Test specifici
dotnet test --filter "FullyQualifiedName~FeedGenerator"

# Con coverage
dotnet test --collect:"XPlat Code Coverage"
```

### Mock di Servizi Esterni

```csharp
[Fact]
public async Task FeedGenerator_ShouldGenerateSummary()
{
    // Arrange
    var mockAiService = new Mock<IAiService>();
    mockAiService
        .Setup(x => x.GetSummaryAsync(It.IsAny<string>(), It.IsAny<int>()))
        .ReturnsAsync("Test summary");
    
    var generator = new FeedGenerator(
        mockSender.Object,
        mockLogger.Object,
        mockFeedService.Object,
        mockAiService.Object
    );

    // Act
    var result = await generator.GenerateAsync();

    // Assert
    Assert.NotNull(result);
    Assert.Contains("Test summary", result.Content);
}
```

---

## 📊 Monitoring

### Application Insights

**Metriche Chiave**:
- **Execution Count**: Numero di esecuzioni funzione
- **Success Rate**: % esecuzioni riuscite
- **Average Duration**: Tempo medio esecuzione
- **AI Token Usage**: Consumo token OpenAI

**Query KQL Utili**:

```kql
// Esecuzioni ultime 24h
requests
| where timestamp > ago(24h)
| where name == "XPosterFunction"
| summarize count() by bin(timestamp, 1h)
| render timechart

// Error rate
traces
| where timestamp > ago(7d)
| where severityLevel >= 3
| summarize errorCount = count() by bin(timestamp, 1d)
| render barchart

// AI Cost Tracking
dependencies
| where timestamp > ago(30d)
| where target contains "openai"
| extend tokenUsage = toint(customDimensions.tokenCount)
| summarize totalTokens = sum(tokenUsage), totalCost = sum(tokenUsage) * 0.00006
```

### Alerting

Configura alert su:
- **Errori consecutivi** (> 3 in 1 ora)
- **Token usage** (> budget mensile)
- **Latency** (> 60 secondi)
- **Function downtime**

---

## 🗺️ Roadmap

### ✅ Fase 1: Foundation (Completato)
- [x] Azure Function setup
- [x] Multi-platform sender architecture
- [x] AI integration (GPT-4, DALL-E)
- [x] Twitter/X publishing
- [x] LinkedIn publishing
- [x] RSS feed parsing
- [x] CI/CD pipeline

### 🚧 Fase 2: Stabilization (In Corso)
- [ ] Instagram publishing (completare setup)
- [ ] Retry logic con Polly
- [ ] Duplicate detection
- [ ] Configuration externalization
- [ ] Enhanced error handling
- [ ] Comprehensive testing (80%+ coverage)

### 📅 Fase 3: Intelligence (Q1 2026)
- [ ] Post-publication analytics
- [ ] ML-based optimal timing
- [ ] Sentiment analysis
- [ ] A/B testing framework
- [ ] Trending hashtag detection
- [ ] Multi-language support

### 🎨 Fase 4: Admin Dashboard (Q2 2026)
- [ ] Blazor WebAssembly UI
- [ ] Real-time analytics
- [ ] Manual post scheduling
- [ ] Content calendar
- [ ] Performance metrics
- [ ] Mobile app (MAUI)

### 🌍 Fase 5: Expansion (Q3 2026)
- [ ] Threads (Meta) integration
- [ ] Mastodon support
- [ ] BlueSky protocol
- [ ] YouTube Shorts
- [ ] Podcast automation

---

## 🤝 Contributing

Contributi, issue e feature request sono benvenuti!

### Come Contribuire

1. **Fork** il progetto
2. **Crea** il tuo feature branch (`git checkout -b feature/AmazingFeature`)
3. **Commit** le modifiche (`git commit -m 'Add some AmazingFeature'`)
4. **Push** al branch (`git push origin feature/AmazingFeature`)
5. **Apri** una Pull Request

### Guidelines

- Segui le convenzioni di codice C# (.NET)
- Aggiungi test unitari per nuove feature
- Aggiorna la documentazione
- Mantieni i commit atomici e descrittivi
- Rispetta i design pattern esistenti

### Coding Standards

```csharp
// ✅ Buono
public async Task<Post> GenerateAsync()
{
    var summary = await _aiService.GetSummaryAsync(content, maxLength);
    if (string.IsNullOrWhiteSpace(summary))
    {
        _logger.LogWarning("Empty summary generated");
        return null;
    }
    return new Post { Content = summary };
}

// ❌ Evitare
public async Task<Post> GenerateAsync() {
    var summary = await _aiService.GetSummaryAsync(content, maxLength);
    if (summary == null || summary == "") return null;
    return new Post { Content = summary };
}
```

---

## 📄 License

Questo progetto è distribuito con licenza **MIT**. Vedi il file [LICENSE](LICENSE) per dettagli.

```
MIT License

Copyright (c) 2025 Marco Cavallo

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
```

---

## 👤 Autore

**Marco Cavallo**

- 🌐 Website: [artcava.net](https://artcava.net/)
- 💼 LinkedIn: [Marco Cavallo](https://linkedin.com/in/marcocavallo)
- 🐦 Twitter: [@artcava](https://twitter.com/artcava)
- 📧 Email: cavallo.marco@gmail.com
- 🏢 Location: Torino, Italy

---

## 🙏 Acknowledgments

- [Azure Functions](https://azure.microsoft.com/services/functions/) - Serverless platform
- [OpenAI](https://openai.com/) - AI models (GPT-4, DALL-E)
- [LinqToTwitter](https://github.com/JoeMayo/LinqToTwitter) - Twitter API wrapper
- [.NET Foundation](https://dotnetfoundation.org/) - Framework e community

---

## 📞 Support

- **Issues**: [GitHub Issues](https://github.com/artcava/XPoster/issues)
- **Discussions**: [GitHub Discussions](https://github.com/artcava/XPoster/discussions)
- **Email**: cavallo.marco@gmail.com

---

## 🌟 Star History

Se trovi questo progetto utile, considera di lasciare una ⭐ su GitHub!

[![Star History Chart](https://api.star-history.com/svg?repos=artcava/XPoster&type=Date)](https://star-history.com/#artcava/XPoster&Date)

---

<div align="center">

**Made with ❤️ in Torino, Italy**

[🏠 Homepage](https://xposterfunction.azurewebsites.net/) • 
[📖 Documentation](https://github.com/artcava/XPoster/wiki) • 
[🐛 Report Bug](https://github.com/artcava/XPoster/issues) • 
[💡 Request Feature](https://github.com/artcava/XPoster/issues)

</div>
