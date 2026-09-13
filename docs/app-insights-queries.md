# Application Insights Queries

KQL snippets to verify what happened inside a **workflow execution** (engine, nodes, orchestrator) *before* the dry-run senders fan out. Every message below is grepped from the actual source (`src/...`), so the filters match real structured logs in the `traces` table.

> ⚠️ **Sampling.** `src/host.json` enables Application Insights adaptive sampling for every telemetry type except `Request`. `traces` can therefore be sampled (default ~5/s). For lossless verification of a single run, set `"samplingSettings": { "isEnabled": false }` temporarily.

---

## 1. Log events to look for

| Where | Severity | Message pattern | Key `customDimensions` |
|---|---|---|---|
| `XFunction.Run` | Info | `XPoster Function started at: {Time}` | `Time` |
| `OrchestratorFactory.Resolve` | Info | `No slot profile for hour {Hour}, using NoOrchestrator` | `Hour` |
| `OrchestratorFactory.Resolve` | Info | `Creating orchestrator {OrchestratorType} for platforms [{SenderPlatforms}] at hour {Hour} with ContextKey={ContextKey}` | `OrchestratorType`, `SenderPlatforms`, `Hour`, `ContextKey` |
| `WorkflowExecutionEngine.ExecuteAsync` | Info | `Executing node '{NodeId}' of type '{NodeType}' for slot '{SlotKey}'` | `NodeId`, `NodeType`, `SlotKey` |
| `WorkflowExecutionEngine.ExecuteAsync` | Error | `Workflow '{SlotKey}' validation failed: {Error}` | `SlotKey`, `Error` |
| `WorkflowExecutionEngine.ExecuteAsync` | Error | `Workflow '{SlotKey}' contract validation failed: {Error}` | `SlotKey`, `Error` |
| `WorkflowExecutionEngine.ExecuteAsync` | Error | `Node '{NodeId}' failed: {Error}` | `NodeId`, `Error` |
| `WorkflowOrchestrator.OrchestrateAsync` | Error | `[WorkflowOrchestrator] Workflow '{SlotKey}' failed: {Error}` | `SlotKey`, `Error` |
| `WorkflowOrchestrator.OrchestrateAsync` | Error | `[WorkflowOrchestrator] Workflow '{SlotKey}' completed without {Key} in context. Nothing will be dispatched.` | `SlotKey`, `Key` |
| `BaseOrchestrator.PostAsync` / `DispatchAsync` | Info | `Sender {Sender} result: {Result}` | `Sender`, `Result` |
| `BaseOrchestrator.DispatchAsync` | Warning | `No post produced for sender {Sender} — skipping` | `Sender` |
| `DryRunSender.SendAsync` | Info | `[DryRun] Configuration probe succeeded ('{Key}' is present, length={Length})` | `Key`, `Length` |
| `DryRunSender.SendAsync` | Info | `[DryRun] Post content ({CharCount} chars): {Content} \| Image: {HasImage}` | `CharCount`, `Content`, `HasImage` |
| `DryRunSender.SendAsync` | Error | `[DryRun] Configuration probe failed: '{Key}' is missing or empty. ...` | `Key` |
| `ConfigurationSlotProfileProvider` | Warning | `[ConfigurationSlotProfileProvider] Slot '{Slot}' at hour {Hour} has no Workflow key; skipping.` | `Slot`, `Hour` |

The workflow nodes themselves (`FetchRssNode`, `AiTextNode`, `AiImageNode`, `FanOutSendNode`) do **not** log; the only per-step trace is `Executing node ...` emitted by the engine around each node.

---

## 2. Anchor a single run (operation_Id)

The timer fires at minute 50 every hour (`CronSchedule = 0 50 * * * *`); the slot is selected when the current **UTC hour** matches `Schedule__N__Hour`. For the example below the Azure slot is `Schedule__2` with `Hour=17`, workflow `Bitcoin`, senders `DryRunMaxLength` and `DryRunShortLength` — so the run happens at **17:50 UTC**.

```kql
// Find the operation_Id of the run at 17:50 UTC (adjust t0 to your slot)
let t0 = datetime("2026-09-06T17:50:00Z");
traces
| where timestamp between (t0 - 10m) and (t0 + 10m)
| where message has "XPoster Function started at"
| project operation_Id, started = timestamp
```

---

## 3. Full timeline of one run

```kql
let t0 = datetime("2026-09-06T17:50:00Z");
let runStart = traces
  | where timestamp between (t0 - 10m) and (t0 + 10m)
  | where message has "XPoster Function started at"
  | project operation_Id;
traces
| where operation_Id in (runStart)
| order by timestamp asc
| project timestamp, severityLevel, operation_Id,
    message,
    NodeId = customDimensions.NodeId,
    NodeType = customDimensions.NodeType,
    SlotKey = customDimensions.SlotKey,
    Error = customDimensions.Error
```

---

## 4. Slot selection — did the right orchestrator fire?

```kql
traces
| where timestamp >= datetime("2026-09-06T17:00:00Z")
| where message has "Creating orchestrator"
| project timestamp,
    OrchestratorType = customDimensions.OrchestratorType,
    Hour = customDimensions.Hour,
    Senders = customDimensions.SenderPlatforms,
    ContextKey = customDimensions.ContextKey
```

If nothing shows, check the miss path:

```kql
traces
| where timestamp >= datetime("2026-09-06T17:00:00Z")
| where message has "No slot profile for hour"
| project timestamp, Hour = customDimensions.Hour
```

---

## 5. Node sequence — what ran in the workflow BEFORE the dry-runs

Bitcoin DAG: `fetch-rss` (FetchRss) → `generate-summary` (AiText) → `generate-image-prompt` (AiText) → `generate-image` (AiImage) → `fan-out-send` (FanOutSend).

```kql
traces
| where timestamp >= datetime("2026-09-06T17:00:00Z")
| where message has "Executing node"
| project timestamp,
    NodeId = customDimensions.NodeId,
    NodeType = customDimensions.NodeType,
    SlotKey = customDimensions.SlotKey
| order by timestamp asc
```

---

## 6. Workflow failures before the dry-runs

```kql
traces
| where timestamp >= datetime("2026-09-06T17:00:00Z")
| where message has_any (
    "validation failed",
    "contract validation failed",
    "Node '",
    "[WorkflowOrchestrator] Workflow"
  )
| project timestamp, severityLevel, message,
    SlotKey = customDimensions.SlotKey,
    NodeId = customDimensions.NodeId,
    Error = customDimensions.Error
```

---

## 7. Dry-run outcome (after the workflow fan-out)

```kql
let t0 = datetime("2026-09-06T17:50:00Z");
let runStart = traces
  | where timestamp between (t0 - 10m) and (t0 + 10m)
  | where message has "XPoster Function started at"
  | project operation_Id;
traces
| where operation_Id in (runStart)
| where message has_any ("[DryRun]", "Sender ")
| project timestamp, severityLevel, message,
    ProbeKey = customDimensions.Key,
    Length = customDimensions.Length,
    CharCount = customDimensions.CharCount,
    HasImage = customDimensions.HasImage,
    Sender = customDimensions.Sender,
    Result = customDimensions.Result
```

---

## 8. Provider / configuration diagnostics for the day

```kql
traces
| where timestamp >= datetime("2026-09-06")
| where severityLevel >= 3
| where message has_any (
    "returned 429",
    "malformed",
    "image generation failed",
    "b64_json",
    "is empty",
    "No sender",
    "No slot profile",
    "has no Workflow key",
    "resolved to no valid senders"
  )
| project timestamp, severityLevel, message,
    Provider = customDimensions.Provider
```

---

## 9. Reading the results

- **Queries 4+5 both populated, 7 shows `[DryRun] Configuration probe succeeded`** → the workflow completed and the dry-run senders validated config + post (no publish happens).
- **5 has all 5 `Executing node` rows but 7 has no `[DryRun]` probe** → the terminal node `fan-out-send` likely failed: `Node 'fan-out-send' failed` or `[WorkflowOrchestrator] Workflow 'Bitcoin' completed without Workflow.SendResults in context` (query 6).
- **4 matches but 5 is empty** → `OrchestratorFactory` resolved the slot but the engine never executed a node (check `XPoster Function started`/`ended` gap on query 3).
- **4 empty** → the slot profile was not selected for that hour: wrong UTC hour, or a `[ConfigurationSlotProfileProvider]` warning about the slot (query 8).