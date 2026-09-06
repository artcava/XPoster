# Deployment Guide

XPoster runs as an Azure Functions v4 app on the .NET 10 isolated worker model.
Three deployment methods are supported; **Option 1 (GitHub Actions)** is recommended for production.

## Option 1: GitHub Actions (Recommended)

The repository ships with `.github/workflows/ci.yml` that builds, tests, and deploys on every push to `master`.

### Setup Steps

1. **Create a Function App** in Azure Portal:
   - Runtime: `.NET 10 (Isolated)`
   - OS: Windows
   - Hosting plan: Consumption (Serverless)

2. **Register an App Registration** in Azure Active Directory and configure a **Federated Credential** for GitHub Actions:
   - Azure Portal → Azure Active Directory → App registrations → New registration
   - Under **Certificates & secrets → Federated credentials**, add a credential with:
     - Issuer: `https://token.actions.githubusercontent.com`
     - Subject: `repo:artcava/XPoster:ref:refs/heads/master`

3. **Grant the App Registration access** to the Function App:
   - Function App → Access control (IAM) → Add role assignment → **Contributor** → select the App Registration

4. **Add the following secrets** to your GitHub repository (Settings → Secrets and variables → Actions):
   - `AZUREAPPSERVICE_CLIENTID` — App Registration (client) ID
   - `AZUREAPPSERVICE_TENANTID` — Azure tenant ID
   - `AZUREAPPSERVICE_SUBSCRIPTIONID` — Azure subscription ID

5. Push to `master` — the workflow triggers automatically.

### Monitoring the Workflow

```
GitHub → Actions → ci → Latest run
```

If the workflow fails, check the logs for `dotnet publish` or deployment errors.

---

## Option 2: Azure CLI

```bash
# 1. Login
az login

# 2. Create Resource Group
az group create --name XPosterRG --location westeurope

# 3. Create Storage Account
az storage account create \
  --name xposterstorage \
  --resource-group XPosterRG \
  --location westeurope \
  --sku Standard_LRS

# 4. Create Function App
az functionapp create \
  --name xposterfunction \
  --resource-group XPosterRG \
  --consumption-plan-location westeurope \
  --runtime dotnet-isolated \
  --runtime-version 10 \
  --functions-version 4 \
  --storage-account xposterstorage

# 5. Configure App Settings
az functionapp config appsettings set \
  --name xposterfunction \
  --resource-group XPosterRG \
  --settings \
    "KEYVAULT_URI=https://<your-keyvault-name>.vault.azure.net/" \
    "OpenAI__ApiKey=<value>" \
    "OpenAI__Endpoint=https://api.openai.com/v1/" \
    "OpenAI__TextModelName=gpt-4.1-nano" \
    "OpenAI__ImageModelName=gpt-image-1.5" \
    "CronSchedule=0 50 * * * *"

# 6. Deploy
cd src
func azure functionapp publish xposterfunction
```

> ⚠️ Sender credentials (Twitter/X, LinkedIn, Instagram, Facebook) are **not** set via App Settings — they are loaded from Azure Key Vault at application startup via the **Azure Key Vault Configuration Provider** (`AddAzureKeyVault` registered in `Program.cs`) and injected into senders through standard `IOptions` binding. See [Configuration Reference — Key Vault](configuration.md#key-vault) for the required secret names and role assignment.

> ⚠️ The posting behaviour is fully config-driven. In addition to the settings above, production App Settings must define the workflow DAGs (**`Workflows__*`**), the prompt steps (**`PromptSteps__*`**), and the schedule (**`Schedule__*`**) — mirroring the canonical block in `src/local.settings.json.example` (slot 0 → hour 6 `Bitcoin`, slot 1 → hour 14 `PowerLaw`). There is no global `AiProvider` setting: each AI node selects its own provider via `Workflows__<key>__Nodes__N__Parameters__Provider`. See [Configuration Reference — Workflows](configuration.md#workflows-node-dags) for the node catalogue.

> ⚠️ **Never put dry-run senders (`DryRunMaxLength`, `DryRunShortLength`) or `ForceHour` in production App Settings.** Dry-run is a *schedule slot* whose senders are the dry-run platforms (they log the post instead of publishing); `ForceHour` only ever applies in the Development environment (`LocalOverrideTimeProvider`). See [Configuration Reference — Scheduler](configuration.md#scheduler) for details.

---

## Option 3: Visual Studio Code

1. Install the **Azure Functions** extension for Visual Studio Code
2. Sign in to Azure via the **Azure** side panel (`Shift+Alt+A`)
3. In the Azure panel, expand your subscription and locate the **Function App**
4. Right-click the Function App → **Deploy to Function App...**
5. Select the repository root when prompted for the folder to deploy

> ⚠️ Ensure `dotnet publish` completes successfully before deploying. VS Code deploys the current workspace — make sure all App Settings are configured in Azure Portal before the first run.

---

## Post-Deployment Checklist

- [ ] All App Settings configured (see [Configuration Reference](configuration.md))
- [ ] `Workflows__*`, `PromptSteps__*`, and `Schedule__*` sections present — they define what each UTC hour publishes
- [ ] `KEYVAULT_URI` set and Function App Managed Identity granted **Key Vault Secrets User** role
- [ ] Application Insights resource linked to the Function App
- [ ] `CronSchedule` set to fire hourly (`0 50 * * * *`) — the per-hour slot selection comes from `Schedule__*`, not the cron
- [ ] No dry-run senders (`DryRunMaxLength` / `DryRunShortLength`) in the production `Schedule__*` slots
- [ ] `ForceHour` **not** present in App Settings
- [ ] Test manual trigger via Azure Portal → Functions → Test/Run
- [ ] Verify first execution in Application Insights → Live Metrics

## Managed Identity (Production Best Practice)

Assign a **System-assigned Managed Identity** to the Function App to authenticate against Azure Key Vault and (optionally) Azure AI Foundry without storing secrets in App Settings:

1. Azure Portal → Function App → Identity → System assigned → **On**
2. Azure Key Vault → Access control (IAM) → Add role assignment → **Key Vault Secrets User** → select the Function App identity
3. (If any workflow node uses `Provider: AzureFoundry`) Azure AI Foundry resource → Access control (IAM) → Add role assignment → **Cognitive Services OpenAI User** → select the Function App identity; omit `AzureFoundry__ApiKey` from App Settings

The Azure Key Vault Configuration Provider (`AddAzureKeyVault` in `Program.cs`) uses `DefaultAzureCredential`, which picks up the Managed Identity automatically in production — no code changes required.
