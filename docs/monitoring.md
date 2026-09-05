# Monitoring

XPoster uses **Azure Application Insights** for telemetry, structured logging, and alerting. This document covers setup, the SDK wiring in `Program.cs`, key metrics, KQL queries, alert rules, live debugging, and Infrastructure-as-Code provisioning.

---

## 1. Create the Application Insights Resource

1. In the **Azure Portal**, search for **Application Insights** and click **Create**.
2. Fill in the details:
   - **Name**: e.g. `xposter-appinsights`
   - **Resource Group**: same as your Function App (`XPosterRG`)
   - **Region**: same region as the Function App
   - **Resource Mode**: Workspace-based (recommended)
3. Click **Review + Create**, then **Create**.
4. Once created, navigate to the resource and copy the **Connection String** from the Overview blade.

> ⚠️ Use the **Connection String**, not the Instrumentation Key — the key-only format is deprecated.

---

## 2. Add the Connection String to the Function App

**Via Azure Portal:**
1. Go to **Function App → Configuration → Application Settings**.
2. Click **+ New application setting**.
3. Name: `APPLICATIONINSIGHTS_CONNECTION_STRING`
4. Value: paste the full connection string.
5. Click **Save** and confirm the restart.

**Via Azure CLI:**
```bash
az functionapp config appsettings set \\
  --name xposterfunction \\
  --resource-group XPosterRG \\
  --settings "APPLICATIONINSIGHTS_CONNECTION_STRING=InstrumentationKey=<key>;IngestionEndpoint=https://<region>.in.applicationinsights.azure.com/"
```

**For local development**, add the key to `src/local.settings.json`:
```json
{
  "IsEncrypted": false,
  "Values": {
    "APPLICATIONINSIGHTS_CONNECTION_STRING": "InstrumentationKey=<key>;IngestionEndpoint=https://<region>.in.applicationinsights.azure.com/"
  }
}
```

> The key is already present (empty) in [`src/local.settings.json.example`](../src/local.settings.json.example). See [#29](https://github.com/artcava/XPoster/issues/29) for the full settings template.

---

## 3. SDK Wiring in Program.cs

XPoster uses the **`FunctionsApplication.CreateBuilder`** pattern introduced in Azure Functions v4 isolated worker (SDK ≥ 1.17). Application Insights is registered via two calls on `builder.Services`, followed immediately by a `LoggerFilterOptions` block that removes the default Application Insights log-level override — ensuring that all severity levels configured in code are actually forwarded to the telemetry pipeline.

```csharp
// Program.cs (excerpt — actual implementation)
var builder = FunctionsApplication.CreateBuilder(args);

builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights()
    .AddApplicationInsightsTelemetryProcessor<MaskUrlTelemetryProcessor>();

builder.Logging.Services.Configure<LoggerFilterOptions>(options =>
{
    LoggerFilterRule? defaultRule = options.Rules.FirstOrDefault(rule =>
        rule.ProviderName ==
        "Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider");
    if (defaultRule is not null)
        options.Rules.Remove(defaultRule);
});
```
The **`MaskUrlTelemetryProcessor`** is used to mask `access_token` over calls to Facebook Graph APIs, they require to pass it in QueryString.
**Why the `LoggerFilterOptions` block?** By default, the Functions host injects a filter rule that suppresses `Information`-level logs from reaching Application Insights. Removing that rule lets every `ILogger<T>` call (Debug, Information, Warning, Error) flow through to the telemetry pipeline without additional configuration.

No explicit `HostBuilder` or `.Build().Run()` wiring is required — `FunctionsApplication.CreateBuilder` manages the host lifecycle internally.

---

## 4. Key Metrics

| Metric | Description | Suggested Alert Threshold |
|---|---|---|
| **Execution Count** | Number of `XPosterFunction` invocations per hour | — |
| **Success Rate** | % of executions completing without unhandled exception | < 95% |
| **Average Duration** | Mean execution time in ms | > 60 000 ms (P95) |
| **AI Token Usage** | Tokens consumed per run (custom dimension `tokenCount`) | > monthly budget |
| **Failure Count** | Invocations ending in exception | > 3 in 1 hour |
| **Sender Failures** | `SendAsync` errors broken down by sender plugin | Any spike |
| **Fan-out Partial Failures** | Slots where at least one sender failed but others succeeded | Any occurrence |
| **Feed Fetch Failures** | `FeedService` HTTP errors and circuit breaker open events | > 3 in 1 hour |

---

## 5. KQL Queries

All queries are verified against the Azure Functions v4 isolated worker table schema (`requests`, `traces`, `dependencies`).

### Executions last 24 hours

```kql
requests
| where timestamp > ago(24h)
| where name == "XPosterFunction"
| summarize count() by bin(timestamp, 1h)
| render timechart
```

### Error rate by day (last 7 days)

```kql
traces
| where timestamp > ago(7d)
| where severityLevel >= 3
| summarize errorCount = count() by bin(timestamp, 1d)
| render barchart
```

### AI cost tracking (estimated)

```kql
dependencies
| where timestamp > ago(30d)
| where target contains "openai"
| extend tokenUsage = toint(customDimensions.tokenCount)
| summarize totalTokens = sum(tokenUsage), estimatedCostUSD = sum(tokenUsage) * 0.00006
```

### Per-sender publish outcome (last 7 days)

In a fan-out slot each sender's result is logged independently by `BaseOrchestrator.PostAsync`. This query breaks down publish success and failure per platform:

```kql
traces
| where timestamp > ago(7d)
| where message contains "[PostAsync]"
| extend
    platform  = tostring(customDimensions.platform),
    succeeded = tobool(customDimensions.succeeded)
| summarize
    successes = countif(succeeded == true),
    failures  = countif(succeeded == false)
    by platform
| order by failures desc
```

### Fan-out slots with partial failures (last 24 hours)

Identifies executions where at least one sender failed while others succeeded — useful for detecting platform-specific outages that do not cause a full slot failure:

```kql
traces
| where timestamp > ago(24h)
| where message contains "[PostAsync]"
| extend
    platform  = tostring(customDimensions.platform),
    succeeded = tobool(customDimensions.succeeded),
    invocationId = tostring(operation_Id)
| summarize
    total    = count(),
    failures = countif(succeeded == false)
    by invocationId
| where failures > 0 and failures < total
| order by failures desc
```

### Sender failure breakdown

```kql
traces
| where timestamp > ago(7d)
| where message contains "[PostAsync]" and tobool(customDimensions.succeeded) == false
| summarize failures = count() by tostring(customDimensions.platform)
| order by failures desc
```

### Feed fetch retries (last 24 hours)

```kql
traces
| where timestamp > ago(24h)
| where message contains "[FeedService] Retry"
| extend feedUrl = tostring(customDimensions.feedUrl)
| summarize retries = count() by feedUrl, bin(timestamp, 1h)
| order by retries desc
```

### Feed circuit breaker open events

```kql
traces
| where timestamp > ago(7d)
| where message contains "[FeedService] Circuit breaker opened"
| extend feedUrl = tostring(customDimensions.feedUrl)
| summarize opens = count() by feedUrl, bin(timestamp, 1d)
| order by opens desc
```

> 💡 To pin any query result to an Azure Dashboard, run it in the **Logs** blade and click the **Pin to dashboard** icon (📌) in the top-right corner of the results panel.

---

## 6. Fan-Out Dispatch Observability

As of the multi-platform fan-out feature (#176), each slot may target multiple senders. `BaseOrchestrator.PostAsync` dispatches all senders in parallel via `Task.WhenAll` and logs the outcome for each sender independently before returning the aggregate result.

### Fan-out structured log events

| Event | Severity | Message pattern | Key `customDimensions` |
|---|---|---|---|
| Sender dispatched | Information | `[PostAsync] Dispatching to {platform}` | `platform`, `hour`, `orchestratorType` |
| Sender succeeded | Information | `[PostAsync] {platform} published successfully` | `platform`, `hour`, `succeeded: true` |
| Sender skipped (null post) | Warning | `[PostAsync] {platform} returned null post — skipping` | `platform`, `hour` |
| Sender failed | Error | `[PostAsync] {platform} SendAsync returned false` | `platform`, `hour`, `succeeded: false` |
| Slot fully succeeded | Information | `[PostAsync] All senders completed for hour {hour}` | `hour`, `senderCount`, `succeeded: true` |
| Slot partially failed | Warning | `[PostAsync] Partial failure for hour {hour}: {failureCount}/{total} senders failed` | `hour`, `failureCount`, `total`, `succeeded: false` |

> All fan-out events carry `operation_Id` (the Azure Functions invocation ID), allowing correlation of all sender outcomes for a single slot execution in a single Logs query.

### Diagnosing a partial fan-out failure

When one sender fails while others succeed, the sequence of log events is:

1. `[PostAsync] Dispatching to {platform}` — Information — emitted once per sender before `Task.WhenAll`.
2. Per-sender outcome: **Sender succeeded** (Information) or **Sender failed** (Error) or **Sender skipped** (Warning).
3. `[PostAsync] Partial failure for hour {hour}` — Warning — emitted once if any sender returned `false`.

The **Fan-out slots with partial failures** KQL query in §5 surfaces this pattern directly.

---

## 7. Feed HTTP Client Resilience Observability

`FeedService` fetches RSS/Atom feeds via the named HTTP client `"Feed"`, protected by a Polly resilience pipeline (attempt timeout → retry → circuit breaker). Each pipeline event emits a structured `ILogger` trace that flows to Application Insights as a `traces` record with `customDimensions`.

### Structured log events

| Event | Severity | Message pattern | Key `customDimensions` |
|---|---|---|---|
| Retry attempt | Warning | `[FeedService] Retry {attempt}/{max} for {feedUrl} after {delay}ms — {reason}` | `feedUrl`, `attempt`, `max`, `delayMs`, `reason` |
| Circuit breaker opened | Error | `[FeedService] Circuit breaker opened for {feedUrl}. Break duration: {breakSeconds}s` | `feedUrl`, `breakSeconds` |
| Circuit breaker reset | Information | `[FeedService] Circuit breaker reset for {feedUrl}` | `feedUrl` |
| Attempt timeout | Warning | `[FeedService] Attempt timeout ({timeoutSeconds}s) reached for {feedUrl}` | `feedUrl`, `timeoutSeconds` |
| Feed fetch failed (all retries exhausted) | Error | `[FeedService] Failed to fetch feed {feedUrl} after {attempts} attempt(s): {exceptionMessage}` | `feedUrl`, `attempts`, `exceptionMessage` |

> These events are emitted by `FeedService` via the standard `ILogger<FeedService>` instance injected at construction. No additional telemetry client configuration is required beyond the Application Insights SDK wiring in `Program.cs`.

### Diagnosing a feed outage

When a feed starts failing, the sequence of log events is:

1. One or more **Retry attempt** (Warning) — the pipeline is retrying with exponential back-off.
2. If all retries are exhausted: **Feed fetch failed** (Error) for that execution slot.
3. After the failure ratio threshold is reached across the sampling window: **Circuit breaker opened** (Error) — subsequent executions skip the HTTP call entirely until the break duration elapses.
4. Once the break elapses, a single probe request is allowed. On success: **Circuit breaker reset** (Information).

The KQL queries in §5 (**Feed fetch retries** and **Feed circuit breaker open events**) surface this sequence directly in Application Insights Logs.

### Alert rule: feed circuit breaker opened

Add this alert alongside the existing rules in §8 to be notified when a feed circuit breaker opens:

| Alert | KQL Signal | Threshold | Severity |
|---|---|---|---|
| Feed circuit breaker opened | `traces \| where message contains "[FeedService] Circuit breaker opened"` | ≥ 1 in 1 h | Sev 2 – Warning |

**Bicep snippet:**

```bicep
resource feedCircuitBreakerAlert 'Microsoft.Insights/scheduledQueryRules@2022-06-15' = {
  name: 'XPoster-FeedCircuitBreakerOpened'
  location: resourceGroup().location
  properties: {
    description: 'Fires when the FeedService circuit breaker opens for any feed URL'
    severity: 2
    enabled: true
    scopes: [ appInsights.id ]
    evaluationFrequency: 'PT5M'
    windowSize: 'PT1H'
    criteria: {
      allOf: [
        {
          query: 'traces | where message contains "[FeedService] Circuit breaker opened" | summarize opens = count()'
          timeAggregation: 'Count'
          operator: 'GreaterThanOrEqual'
          threshold: 1
          failingPeriods: {
            numberOfEvaluationPeriods: 1
            minFailingPeriodsToAlert: 1
          }
        }
      ]
    }
    actions: {
      actionGroups: [ actionGroup.id ]
    }
  }
}
```

> These events are controlled by the Polly `AddStandardResilienceHandler` pipeline, whose parameters (attempt/total timeouts, retry count and base delay, circuit-breaker thresholds) are **hardcoded in `HttpClientExtensions.AddHttpClients()`** — there are no configuration knobs. See [configuration.md — Feed HTTP Client](configuration.md#feed-http-client) for the exact values per named client.

---

## 8. Setting Up Alerts

### Step-by-Step: Create an Alert via Azure Portal

The following example creates an alert for **more than 3 consecutive errors within 1 hour**:

1. Navigate to **Application Insights → Alerts → + Create → Alert rule**.
2. **Scope**: confirm it points to the Application Insights resource.
3. **Condition**:
   - Signal type: **Custom log search**
   - KQL query:
     ```kql
     traces
     | where severityLevel >= 3
     | where timestamp > ago(1h)
     | summarize errorCount = count()
     ```
   - Alert logic: **Greater than** threshold **3**
   - Evaluation frequency: `5 minutes` | Lookback period: `1 hour`
4. **Actions**: add or create an action group with an email or webhook notification.
5. **Details**: Severity **2 – Warning**, name `XPoster - Consecutive Errors`.
6. Click **Review + Create**.

### Recommended Alert Rules

| Alert | KQL Signal | Threshold | Severity |
|---|---|---|---|
| Consecutive errors | `traces \| where severityLevel >= 3` | > 3 in 1 h | Sev 2 – Warning |
| Token budget exceeded | `dependencies \| where target contains "openai" \| extend t = toint(customDimensions.tokenCount) \| summarize sum(t)` | > monthly budget | Sev 2 – Warning |
| High latency | `requests \| where name == "XPosterFunction" \| summarize avg(duration)` | > 60 000 ms | Sev 3 – Informational |
| Function downtime | Built-in **Availability** test on the Function App URL | < 100% | Sev 1 – Error |
| Feed circuit breaker opened | `traces \| where message contains "[FeedService] Circuit breaker opened"` | ≥ 1 in 1 h | Sev 2 – Warning |
| Fan-out partial failure | `traces \| where message contains "[PostAsync] Partial failure"` | ≥ 1 in 1 h | Sev 2 – Warning |

### IaC: Bicep Snippet

```bicep
resource consecutiveErrorsAlert 'Microsoft.Insights/scheduledQueryRules@2022-06-15' = {
  name: 'XPoster-ConsecutiveErrors'
  location: resourceGroup().location
  properties: {
    description: 'Fires when more than 3 errors are logged within 1 hour'
    severity: 2
    enabled: true
    scopes: [ appInsights.id ]
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
      actionGroups: [ actionGroup.id ]
    }
  }
}
```

---

## 9. Live Debugging

### Live Metrics (Azure Portal)

1. Start the function locally: `cd src && func start`
2. Open **Application Insights → Live Metrics** in the Azure Portal.
3. Trigger an execution (timer fires automatically, or use an HTTP trigger).
4. Observe incoming requests, dependency calls, exceptions, and custom traces in near real time.

> Live Metrics works in local development as long as `APPLICATIONINSIGHTS_CONNECTION_STRING` is set in `src/local.settings.json`.

### Log Stream (CLI)

For real-time log streaming directly from the deployed Function App:

```bash
func azure functionapp logstream xposterfunction
```
