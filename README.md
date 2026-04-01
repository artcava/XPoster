# XPoster 🚀

[![Azure Functions](https://img.shields.io/badge/Azure%20Functions-v4-0062AD?logo=azurefunctions&logoColor=white)](https://azure.microsoft.com/en-us/services/functions/)
[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12.0-239120?logo=csharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![OpenAI](https://img.shields.io/badge/OpenAI-Powered-412991?logo=openai&logoColor=white)](https://openai.com/)
[![License](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![Deployment](https://img.shields.io/badge/Deployed-Azure-blue)](https://xposterfunction.azurewebsites.net/)
[![Build and Deploy](https://github.com/artcava/XPoster/actions/workflows/master_xposterfunction.yml/badge.svg)](https://github.com/artcava/XPoster/actions/workflows/master_xposterfunction.yml)

> **AI-Powered Social Media Automation Platform**
> 
> XPoster is an Azure Function that automates content publishing across multiple social media platforms (Twitter/X, LinkedIn, Instagram) using artificial intelligence for content generation and curation.

---

## 📋 Table of Contents

- [Features](#features)
- [Architecture](#architecture)
- [Technologies](#technologies)
- [Getting Started](#getting-started)
- [Configuration](#configuration)
- [Deployment](#deployment)
- [Usage](#usage)
- [Scheduling](#scheduling)
- [Extensibility](#extensibility)
- [Testing](#testing)
- [Monitoring](#monitoring)
- [Roadmap](#roadmap)
- [Contributing](#contributing)
- [License](#license)

> 📐 For a deep-dive into architectural decisions, design patterns, ADRs, and extension contracts, see [ARCHITECTURE.md](ARCHITECTURE.md).

---

## Features

### 🤖 Content Generation
- **AI-Powered Summarization**: Intelligent RSS feed summaries using gpt-4.1-nano
- **Image Generation**: Automatic contextual image creation with gpt-image-1.5
- **Smart Hashtags**: Automatic keyword conversion to optimized hashtags
- **Multi-Strategy**: Support for different content generation algorithms

### 🌐 Multi-Platform Publishing
- **Twitter/X**: Automated posting with image support
- **LinkedIn**: Posts on personal profiles and company pages
- **Instagram**: Publishing via Graph API (in development)

### ⚙️ Automation & Scheduling
- **Timer-Based Execution**: Configurable automatic execution
- **Smart Scheduling**: Different posting strategies based on time
- **Conditional Logic**: Publishing only when appropriate
- **Flexible Configuration**: Customizable schedule via environment variables

### 📊 Enterprise Features
- **Application Insights**: Complete monitoring and telemetry
- **Structured Logging**: Detailed logs for debugging and audit
- **Error Handling**: Robust error management with retry logic
- **Dependency Injection**: Modular and testable architecture

---

## Architecture

> 📐 For the full architectural rationale, ADRs, design patterns, and Mermaid data-flow diagram, see **[ARCHITECTURE.md](ARCHITECTURE.md)**.

### High-Level Overview

```
┌────────────────────────────┐
│   Azure Timer Trigger      │
│   (configurable schedule)  │
└───────────┬────────────────┘
            │
            ▼
┌────────────────────────────┐
│   Generator Factory        │ ◄─── Strategy Pattern
│   (Time-based Selector)    │
└───────────┬────────────────┘
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

### Core Components

#### 1. **XFunction** (Entry Point)
Timer-triggered Azure Function that orchestrates the entire publishing workflow.

**Cron Expression**: Configurable via environment variable (default: `0 5 * * * *`)

#### 2. **GeneratorFactory** (Factory + Strategy Pattern)
Dynamically selects the appropriate generator based on current time.

| Time | Platform | Strategy |
|------|----------|----------|
| 06:00 | LinkedIn | Feed Summary |
| 08:00 | Twitter/X | Feed Summary |
| 14:00 | LinkedIn | Power Law |
| 16:00 | Twitter/X | Power Law |

#### 3. **Generators** (Content Strategy)
- **FeedGenerator**: Analyzes crypto RSS feeds, generates AI summaries, creates images
- **PowerLawGenerator**: Generates content based on statistical distribution
- **NoGenerator**: Placeholder for time slots without publishing

#### 4. **Services Layer**
- **AiService**: Interface with OpenAI (gpt-4.1-nano, gpt-image-1.5)
- **FeedService**: RSS parser with caching and intelligent filtering
- **CryptoService**: Crypto-currencies utilities

#### 5. **Sender Plugins** (Platform Abstraction)
- **XSender**: Twitter/X via LinqToTwitter
- **InSender**: LinkedIn via HTTP API
- **IgSender**: Instagram via Graph API (in development)

---

## Technologies

### Core Framework
- **.NET 8.0** - Main framework
- **Azure Functions v4** - Serverless compute
- **C# 12** - Programming language

### AI & ML
- **OpenAI** - gpt-4.1-nano for summarization
- **gpt-image-1.5** - Image generation

### Social Media APIs
- **LinqToTwitter 6.15.0** - Twitter/X integration
- **LinkedIn REST API v2** - LinkedIn publishing
- **Instagram Graph API** - Instagram (in development)

### Monitoring & Logging
- **Application Insights** - Telemetry and monitoring
- **ILogger** - Structured logging

### Utilities
- **System.ServiceModel.Syndication** - RSS parsing
- **Microsoft.Extensions.Http** - HTTP client factory

---

## Getting Started

### Prerequisites

- **.NET 8.0 SDK** ([Download](https://dotnet.microsoft.com/download/dotnet/8.0))
- **Azure Functions Core Tools** ([Install](https://docs.microsoft.com/azure/azure-functions/functions-run-local))
- **Visual Studio 2022** or **Visual Studio Code**
- **Azure Account** (with active subscription)
- **OpenAI API** (with gpt-4.1-nano and gpt-image-1.5 enabled)

### Clone the Repository

```bash
git clone https://github.com/artcava/XPoster.git
cd XPoster
```

### Restore Dependencies

```bash
dotnet restore
```

### Build the Project

```bash
dotnet build
```

### Run Tests

```bash
dotnet test
```

### Configure Local Settings

A template file with all required keys and inline documentation is versioned at [`src/local.settings.json.example`](src/local.settings.json.example).

Copy it and fill in your credentials before running the function locally:

```bash
cp src/local.settings.json.example src/local.settings.json
```

Then open `src/local.settings.json` and replace every empty string `""` with the actual value for each service. See the [Configuration](#configuration) section for details on where to obtain each credential.

> ⚠️ `local.settings.json` is listed in `.gitignore` and will **never** be committed. The `.example` variant is safe to version because it contains no real secrets.

> 📖 For the full expanded setup guide with troubleshooting tips, see [docs/getting-started.md](docs/getting-started.md).

---

## Configuration

### 1. Local Development

Create a `local.settings.json` file in the `src/` directory:

```json
{
  "IsEncrypted": false,
  "Values": {
    "CronSchedule": "0 5 * * * *",
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
    "AZURE_OPENAI_DEPLOYMENT_NAME": "gpt-4.1-nano"
  }
}
```

> 📖 Full configuration reference with types, defaults, and where to obtain each credential: [docs/configuration.md](docs/configuration.md).

### 2. Azure Configuration

#### App Settings (Azure Portal)

Navigate to **Azure Portal** → **Function App** → **Configuration** → **Application Settings**

Add the same variables from `local.settings.json`.

#### Managed Identity (Recommended)

For enhanced security, use Azure Managed Identity:

1. Enable **System Assigned Managed Identity** on the Function App
2. Assign appropriate roles on:
   - Azure OpenAI Service
   - Azure Key Vault (for secrets)
3. Modify `Program.cs` to use `DefaultAzureCredential`

```csharp
builder.Services.AddSingleton<OpenAIClient>(sp =>
{
    var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT"));
    return new OpenAIClient(endpoint, new DefaultAzureCredential());
});
```

---

## Deployment

### Option 1: GitHub Actions (Automated CI/CD)

The repository includes a GitHub Actions workflow (`.github/workflows/master_xposterfunction.yml`).

**Setup**:
1. Create a Function App in Azure Portal
2. Download the **Publish Profile** from the Function App
3. Add the content as a **Secret** in GitHub:
   - Name: `AZURE_FUNCTIONAPP_PUBLISH_PROFILE`
4. Every push to `master` triggers automatic deployment

### Option 2: Azure CLI

```bash
# Login
az login

# Create Resource Group
az group create --name XPosterRG --location westeurope

# Create Storage Account
az storage account create \
  --name xposterstorage \
  --resource-group XPosterRG \
  --location westeurope \
  --sku Standard_LRS

# Create Function App
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

### Option 3: Visual Studio

1. Right-click on the `XPoster` project
2. Select **Publish**
3. Choose **Azure** → **Azure Function App (Windows)**
4. Select or create a Function App
5. Click **Publish**

> 📖 Step-by-step guide with post-deployment checklist: [docs/deployment.md](docs/deployment.md).

---

## Usage

### Local Execution

```bash
cd src
func start
```

The function will run locally according to the configured cron expression.

### Manual Trigger (Azure Portal)

1. Go to **Azure Portal** → **Function App** → **Functions**
2. Select `XPosterFunction`
3. Click **Test/Run**
4. Click **Run**

### HTTP Trigger (Optional)

Add an HTTP trigger for testing:

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

## Scheduling

### Schedule Configuration

The execution frequency is configurable via the `CronSchedule` environment variable:

**Format**: 6-field cron expression: `{second} {minute} {hour} {day} {month} {dayOfWeek}`

**Configuration**:


```json
//local.settings.json
{
  "Values": {
    "CronSchedule": "0 5 * * * *"
  }
}
```

```bash
//Azure CLI
az functionapp config appsettings set
--name xposterfunction
--resource-group XPosterRG
--settings "CronSchedule=0 5 * * * *"
```

### Cron Expression Examples

| Schedule | Cron Expression | Description |
|----------|-----------------|-------------|
| **Default** | `0 5 */2 * * *` | Every 2 hours at :05 |
| **Hourly** | `0 0 * * * *` | Every hour on the hour |
| **Every 4 hours** | `0 0 */4 * * *` | Every 4 hours |
| **Business Hours** | `0 0 9,12,15,18 * * 1-5` | 9, 12, 15, 18 (Mon-Fri) |
| **Morning/Evening** | `0 0 8,20 * * *` | At 8:00 and 20:00 |
| **Daily** | `0 0 9 * * *` | Every day at 9:00 |
| **Quick Test** | `*/30 * * * * *` | Every 30 seconds (dev only) |

### Time-based Strategy (GeneratorFactory)

Modify `GeneratorFactory.cs` to customize which generator to use at each hour:

```csharp
private static readonly Dictionary<int, MessageSender> sendParameters = new()
{
{ 6, MessageSender.InSummaryFeed }, // LinkedIn Feed
{ 8, MessageSender.XSummaryFeed }, // Twitter Feed
{ 10, MessageSender.IgSummaryFeed }, // Instagram Feed (enable when ready)
{ 14, MessageSender.InPowerLaw }, // LinkedIn Power Law
{ 16, MessageSender.XPowerLaw }, // Twitter Power Law
{ 18, MessageSender.IgPowerLow }, // Instagram Power Law
};
```
---

### Best Practices

✅ **Testing**: Use frequent schedules in development (`*/5 * * * * *` = every 5 secs)
✅ **Production**: More conservative schedules to avoid rate limiting
✅ **Multi-environment**: Different schedules for Dev/Staging/Prod
✅ **Monitoring**: Check logs to confirm correct execution

---

## Extensibility

### Adding a New Platform

**1. Create the Sender Plugin**

```csharp
// src/SenderPlugins/TikTokSender.cs
public class TikTokSender : ISender
{
    public int MessageMaxLenght => 150;

    public async Task<bool> SendAsync(Post post)
    {
        // Implement TikTok API logic
        return true;
    }
}
```

**2. Register in DI Container**

```csharp
// src/Program.cs
builder.Services.AddTransient<TikTokSender>();
```

**3. Add Enum**

```csharp
// src/Abstraction/Enums.cs
public enum MessageSender
{
    // ...
    TikTokSummaryFeed,
}
```

**4. Configure Factory**

```csharp
// src/Implementation/GeneratorFactory.cs
case MessageSender.TikTokSummaryFeed:
    return GetInstance<FeedGenerator>(
        _serviceProvider.GetService(typeof(TikTokSender)) as ISender
    );
```

> 📖 Full extension guide with services and design constraints: [docs/extending-xposter.md](docs/extending-xposter.md).

### Adding a New Generator

```csharp
// src/Implementation/QuoteGenerator.cs
public class QuoteGenerator : BaseGenerator
{
    public override async Task<Post>? GenerateAsync()
    {
        // Logic to generate motivational quotes
        var quote = await _aiService.GetQuoteAsync();
        return new Post { Content = quote };
    }
}
```

---

## Testing

### Test Structure

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

### Running Tests

```bash
# All tests
dotnet test

# Specific tests
dotnet test --filter "FullyQualifiedName~FeedGenerator"

# With coverage
dotnet test --collect:"XPlat Code Coverage"
```

> 📖 Full testing strategy, mocking patterns, and coverage goals: [tests/README.md](tests/README.md).

### Mocking External Services

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

## Monitoring

### Application Insights Setup

#### 1. Create the Application Insights Resource

1. In the **Azure Portal**, search for **Application Insights** and click **Create**
2. Fill in the details:
   - **Name**: e.g. `xposter-appinsights`
   - **Resource Group**: same as your Function App (`XPosterRG`)
   - **Region**: same region as the Function App
   - **Resource Mode**: Workspace-based (recommended)
3. Click **Review + Create**, then **Create**
4. Once created, navigate to the resource and copy the **Connection String** (shown on the Overview blade)

#### 2. Link Application Insights to the Function App

Add the connection string as an **Application Setting** in the Function App:

**Via Azure Portal**:
1. Go to **Function App** → **Configuration** → **Application Settings**
2. Click **+ New application setting**
3. Name: `APPLICATIONINSIGHTS_CONNECTION_STRING`
4. Value: paste the full connection string copied above
5. Click **Save** and confirm the restart

**Via Azure CLI**:
```bash
az functionapp config appsettings set \
  --name xposterfunction \
  --resource-group XPosterRG \
  --settings "APPLICATIONINSIGHTS_CONNECTION_STRING=InstrumentationKey=<key>;IngestionEndpoint=https://<region>.in.applicationinsights.azure.com/"
```

#### 3. SDK Wiring in Program.cs

The `Microsoft.Azure.Functions.Worker.ApplicationInsights` package is used. It is automatically registered when the connection string is present in the environment. No explicit SDK code is required in `Program.cs` for Azure Functions v4 isolated worker beyond the standard host builder:

```csharp
// Program.cs — Application Insights is enabled automatically
// when APPLICATIONINSIGHTS_CONNECTION_STRING is set.
var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        // ... other registrations
    })
    .Build();
```

#### 4. Connection String Configuration

Add the following key to `local.settings.json` for local telemetry (optional but recommended for debugging):

```json
{
  "IsEncrypted": false,
  "Values": {
    "APPLICATIONINSIGHTS_CONNECTION_STRING": "InstrumentationKey=<key>;IngestionEndpoint=https://<region>.in.applicationinsights.azure.com/"
  }
}
```

> ⚠️ The key is already included in [`src/local.settings.json.example`](src/local.settings.json.example). See [#29](https://github.com/artcava/XPoster/issues/29) for the full settings template.

---

### Key Metrics

- **Execution Count**: Number of function executions
- **Success Rate**: % of successful executions
- **Average Duration**: Average execution time
- **AI Token Usage**: OpenAI token consumption

---

### KQL Queries

All queries below are verified against the Azure Functions v4 isolated worker table schema (`requests`, `traces`, `dependencies`).

```kql
// Executions last 24h
requests
| where timestamp > ago(24h)
| where name == "XPosterFunction"
| summarize count() by bin(timestamp, 1h)
| render timechart

// Error rate (severity >= 3 = Warning+)
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

> 💡 **Tip**: To pin any query result to an Azure Dashboard, run it in the **Logs** blade, click the **Pin to dashboard** icon (📌) in the top-right corner of the results panel, choose your dashboard, and click **Pin**.

---

### Live Metrics (Local Development)

Application Insights **Live Metrics** streams telemetry in near real-time with sub-second latency — useful to verify the function is behaving correctly during local development.

1. Start the function locally:
   ```bash
   cd src
   func start
   ```
2. In the Azure Portal, open your **Application Insights** resource
3. Click **Live Metrics** in the left-hand menu
4. Trigger a function execution (timer fires automatically, or use an HTTP trigger)
5. Observe incoming requests, dependency calls, exceptions, and custom traces in real time

> ℹ️ Live Metrics works even in local development as long as `APPLICATIONINSIGHTS_CONNECTION_STRING` is set in `local.settings.json`.

---

### Alerting Configuration

#### Step-by-Step: Create an Alert via Azure Portal

The following example creates an alert for **more than 3 consecutive errors within 1 hour**:

1. In the Azure Portal, navigate to your **Application Insights** resource
2. Select **Alerts** → **+ Create** → **Alert rule**
3. **Scope**: confirm it points to the Application Insights resource
4. **Condition**:
   - Click **+ Add condition**
   - Signal type: **Custom log search**
   - Enter the following KQL query:
     ```kql
     traces
     | where severityLevel >= 3
     | where timestamp > ago(1h)
     | summarize errorCount = count()
     ```
   - Alert logic: **Greater than** threshold **3**
   - Evaluation frequency: `5 minutes`
   - Lookback period: `1 hour`
5. **Actions**:
   - Click **+ Add action group** → **Create action group**
   - Add a notification: type **Email/SMS/Push/Voice**, fill in your email
   - Optionally add a **Webhook** action (e.g. to a Slack/Teams incoming webhook URL)
6. **Details**:
   - Severity: **2 – Warning**
   - Alert rule name: `XPoster - Consecutive Errors`
7. Click **Review + Create**

#### Recommended Alert Rules

| Alert | KQL signal | Threshold | Severity |
|-------|-----------|-----------|----------|
| Consecutive errors | `traces \| where severityLevel >= 3` | > 3 in 1h | Sev 2 – Warning |
| Token budget exceeded | `dependencies \| where target contains "openai" \| extend t = toint(customDimensions.tokenCount) \| summarize sum(t)` | > monthly budget | Sev 2 – Warning |
| High latency | `requests \| where name == "XPosterFunction" \| summarize avg(duration)` | > 60 000 ms | Sev 3 – Informational |
| Function downtime | Built-in **Availability** test on the Function App URL | < 100% | Sev 1 – Error |

#### IaC: Bicep Snippet for Alert Provisioning

Use the following Bicep snippet to provision the consecutive-errors alert rule as Infrastructure-as-Code:

```bicep
resource consecutiveErrorsAlert 'Microsoft.Insights/scheduledQueryRules@2022-06-15' = {
  name: 'XPoster-ConsecutiveErrors'
  location: resourceGroup().location
  properties: {
    description: 'Fires when more than 3 errors are logged within 1 hour'
    severity: 2
    enabled: true
    scopes: [
      appInsights.id
    ]
    evaluationFrequency: 'PT5M'
    windowSize: 'PT1H'
    criteria: {
      allOf: [
        {
          query: 'traces | where severityLevel >= 3 | summarize errorCount = count()'
          timeAggregation: 'Count'
          operator: 'GreaterThan'
          threshold: 3
          failingPeriods: {
            numberOfEvaluationPeriods: 1
            minFailingPeriodsToAlert: 1
          }
        }
      ]
    }
    actions: {
      actionGroups: [
        actionGroup.id
      ]
    }
  }
}
```

> 📖 Full KQL queries, alert thresholds, and live debugging instructions: [docs/monitoring.md](docs/monitoring.md).

---

## Roadmap

### ✅ Phase 1: Foundation (Complete)
- [x] Azure Function setup
- [x] Multi-platform sender architecture
- [x] AI integration (gpt-4.1-nano, gpt-image-1.5)
- [x] Twitter/X publishing
- [x] LinkedIn publishing
- [x] RSS feed parsing
- [x] CI/CD pipeline

### 🚧 Phase 2: Stabilization (In Progress)
- [ ] AI migration to Azure Foundry
- [ ] Linkedin auto-update authorization token
- [ ] Configuration externalization
- [ ] Enhanced error handling
- [ ] Comprehensive testing (80%+ coverage)

### 📅 Phase 3: Intelligence (Q1 2026)
- [ ] Post-publication analytics
- [ ] ML-based optimal timing
- [ ] Sentiment analysis
- [ ] A/B testing framework
- [ ] Trending hashtag detection
- [ ] Multi-language support

### 🎨 Phase 4: Admin Dashboard (Q2 2026)
- [ ] Web based UI
- [ ] Real-time analytics
- [ ] Manual post scheduling
- [ ] Content calendar
- [ ] Performance metrics
- [ ] Mobile app (MAUI)

### 🌍 Phase 5: Expansion (Q3 2026)
- [ ] Instagram publishing (complete setup)
- [ ] Threads (Meta) integration
- [ ] Mastodon support
- [ ] BlueSky protocol
- [ ] YouTube Shorts
- [ ] Podcast automation

---

## Contributing

Contributions, issues, and feature requests are welcome!

### How to Contribute

1. **Fork** the project
2. **Create** your feature branch (`git checkout -b feature/AmazingFeature`)
3. **Commit** your changes (`git commit -m 'Add some AmazingFeature'`)
4. **Push** to the branch (`git push origin feature/AmazingFeature`)
5. **Open** a Pull Request

### Guidelines

- Follow C# (.NET) coding conventions
- Add unit tests for new features
- Update documentation
- Keep commits atomic and descriptive
- Respect existing design patterns

### Coding Standards

```csharp
// ✅ Good
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

// ❌ Avoid
public async Task<Post> GenerateAsync() {
    var summary = await _aiService.GetSummaryAsync(content, maxLength);
    if (summary == null || summary == "") return null;
    return new Post { Content = summary };
}
```

---

## License

This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for details.

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

## Author

**Marco Cavallo**

- 🌐 Website: [xposter.artcava.net](https://xposter.artcava.net)
- 💼 LinkedIn: [Marco Cavallo](https://linkedin.com/in/artcava)
- 🐦 Twitter: [@artcava](https://twitter.com/artcava)
- 📧 Email: cavallo.marco@gmail.com
- 🏢 Location: Turin, Italy

---

## Acknowledgments

- [Azure Functions](https://azure.microsoft.com/services/functions/) - Serverless platform
- [OpenAI](https://openai.com/) - AI models (gpt-4.1-nano, gpt-image-1.5)
- [LinqToTwitter](https://github.com/JoeMayo/LinqToTwitter) - Twitter API wrapper
- [.NET Foundation](https://dotnetfoundation.org/) - Framework and community

---

## Support

- **Issues**: [GitHub Issues](https://github.com/artcava/XPoster/issues)
- **Discussions**: [GitHub Discussions](https://github.com/artcava/XPoster/discussions)
- **Email**: cavallo.marco@gmail.com

---

## Star History

If you find this project useful, consider leaving a ⭐ on GitHub!

[![Star History Chart](https://api.star-history.com/svg?repos=artcava/XPoster&type=Date)](https://star-history.com/#artcava/XPoster&Date)

---

<div align="center">

**Made with ❤️ in Turin, Italy**

[🏠 Homepage](https://xposter.artcava.net/) • 
[📖 Documentation](docs/index.md) • 
[🐛 Report Bug](https://github.com/artcava/XPoster/issues) • 
[💡 Request Feature](https://github.com/artcava/XPoster/issues)

</div>
