# Monitoring & Alerting

XPoster uses **Azure Application Insights** for telemetry, structured logging, and alerting.

## Connecting Application Insights

1. Create an Application Insights resource in Azure Portal (same resource group as the Function App).
2. Copy the **Connection String** (not the Instrumentation Key — it is deprecated).
3. Add it to App Settings:
   ```
   APPLICATIONINSIGHTS_CONNECTION_STRING = InstrumentationKey=...;IngestionEndpoint=...
   ```
4. The Functions runtime auto-discovers this setting and instruments all telemetry.

## Key Metrics to Monitor

| Metric | Description | Alert Threshold |
|---|---|---|
| **Execution Count** | Number of function invocations | — |
| **Success Rate** | % of executions without exception | < 95% |
| **Average Duration** | Mean execution time in ms | > 60 000 ms |
| **AI Token Usage** | Tokens consumed per run (custom dimension) | > monthly budget |
| **Failure Count** | Invocations ending in exception | > 3 in 1 hour |

## Useful KQL Queries

### Executions last 24 hours

```kql
requests
| where timestamp > ago(24h)
| where name == "XPosterFunction"
| summarize count() by bin(timestamp, 1h)
| render timechart
```

### Error rate by day

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

### Sender failure breakdown

```kql
traces
| where timestamp > ago(7d)
| where message contains "SendAsync failed"
| summarize failures = count() by tostring(customDimensions.sender)
| order by failures desc
```

## Setting Up Alerts

1. Azure Portal → Application Insights → **Alerts** → New alert rule
2. Recommended alerts:

| Alert Name | Signal | Condition | Severity |
|---|---|---|---|
| High Failure Rate | `requests/failed` | > 3 in 1 hour | Sev 1 |
| Long Execution | `requests/duration` | P95 > 60s | Sev 2 |
| Token Budget Exceeded | Custom metric | totalTokens > threshold | Sev 2 |
| Function Downtime | Availability | < 100% for 5 min | Sev 1 |

## Live Debugging

For real-time log streaming during deployment validation:

```bash
func azure functionapp logstream xposterfunction
```

Or use **Application Insights → Live Metrics** in the Azure Portal for a real-time dashboard with incoming requests, failures, and server telemetry.
