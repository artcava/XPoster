# Deployment Guide

XPoster runs as an Azure Functions v4 app on the .NET 8 isolated worker model.
Three deployment methods are supported; **Option 1 (GitHub Actions)** is recommended for production.

## Option 1: GitHub Actions (Recommended)

The repository ships with `.github/workflows/ci.yml` that builds, tests, and deploys on every push to `master`.

### Setup Steps

1. **Create a Function App** in Azure Portal:
   - Runtime: `.NET 8 (Isolated)`
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
  --runtime-version 8 \
  --functions-version 4 \
  --storage-account xposterstorage

# 5. Configure App Settings
az functionapp config appsettings set \
  --name xposterfunction \
  --resource-group XPosterRG \
  --settings \
    "X_API_KEY=<value>" \
    "X_API_SECRET=<value>" \
    "AZURE_OPENAI_ENDPOINT=<value>" \
    "AZURE_OPENAI_KEY=<value>" \
    "CronSchedule=0 5 * * * *"

# 6. Deploy
cd src
func azure functionapp publish xposterfunction
```

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
- [ ] Application Insights resource linked to the Function App
- [ ] `CronSchedule` set correctly for production cadence
- [ ] Test manual trigger via Azure Portal → Functions → Test/Run
- [ ] Verify first execution in Application Insights → Live Metrics

## Managed Identity (Production Best Practice)

For enhanced security, use System-Assigned Managed Identity to access Azure OpenAI without storing API keys:

```csharp
// src/Program.cs
builder.Services.AddSingleton<OpenAIClient>(sp =>
{
    var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT"));
    return new OpenAIClient(endpoint, new DefaultAzureCredential());
});
```

1. Azure Portal → Function App → Identity → System assigned → **On**
2. Azure OpenAI → Access control (IAM) → Add role assignment → **Cognitive Services OpenAI User** → select the Function App identity
3. Remove `AZURE_OPENAI_KEY` from App Settings
