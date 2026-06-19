# Azure AI Foundry — Setup Guide

This guide explains how to provision Azure AI Foundry and configure XPoster to use `AzureFoundryService` as the `IAiService` provider.

> **Provider capabilities:** Text (chat completion) + Image generation  
> **`AiProvider` enum value:** `AzureFoundry`

---

## 1. Create the Azure AI Foundry Resource

1. Open the [Azure Portal](https://portal.azure.com).
2. Search for **Azure AI Foundry** and click **Create**.
3. Choose subscription, resource group, region, and pricing tier.
4. After deployment, open the resource and note:
   - **Endpoint URL** (e.g. `https://<resource>.services.ai.azure.com/openai/v1`)
   - **Key 1** (or Key 2)

## 2. Create a Project and Deploy Models

1. Open [Azure AI Foundry Studio](https://ai.azure.com) for your resource.
2. Create a project (or use an existing one).
3. Deploy a **chat completion** model for summaries and prompt generation (e.g. `gpt-4o-mini`).
4. Deploy an **image generation** model (e.g. `dall-e-3` or `gpt-image-1.5`).
5. Save both deployment names.

Recommended mapping:
- `DeploymentName` → chat deployment
- `ImageDeploymentName` → image deployment

## 3. Retrieve Required Parameters

Collect these values from the Portal / Foundry Studio:

| Parameter | Where to find it |
|-----------|------------------|
| `Endpoint` | Resource overview blade → Endpoint (use the `/openai/v1` base URL) |
| `ApiKey` | Resource overview blade → Keys and Endpoint → Key 1 |
| `DeploymentName` | Foundry Studio → Deployments → chat model name |
| `ImageDeploymentName` | Foundry Studio → Deployments → image model name |

## 4. Configure XPoster

Set these values in `src/local.settings.json` (local) or Azure App Settings (production):

```json
{
  "Values": {
    "AiProvider": "AzureFoundry",
    "AzureFoundry__Endpoint": "https://<resource>.services.ai.azure.com/openai/v1",
    "AzureFoundry__ApiKey": "<secret>",
    "AzureFoundry__DeploymentName": "<chat-deployment>",
    "AzureFoundry__ImageDeploymentName": "<image-deployment>"
  }
}
```

## 5. Store Secrets Safely

For production environments:

- Use **Azure Function App Settings** for non-secret configuration.
- Store secrets (`ApiKey`) in **Azure Key Vault** and reference them from App Settings.
- Never commit secrets to source control. `local.settings.json` is in `.gitignore`.

## 6. Switch Provider via `AiProvider`

XPoster selects the AI provider per generator slot via the `AiProvider` enum value set in `GeneratorFactory`.

- `AiProvider=AzureFoundry` → uses `AzureFoundryService`
- `AiProvider=OpenAi` → uses `OpenAiService`
- `AiProvider=DeepSeekWithFal` → uses `HybridAiService`

If `AiProvider` is missing or invalid, XPoster falls back to the schedule default configured in `GeneratorFactory`.

## 7. Troubleshooting

### 401 / 403 Unauthorized

- Verify `AzureFoundry__ApiKey` is correct and belongs to the same resource as `Endpoint`.

### 404 Deployment Not Found

- Confirm `DeploymentName` and `ImageDeploymentName` match the exact names in Foundry Studio.
- Check region and project alignment.

### 429 Too Many Requests

- Reduce call frequency or increase capacity/quota in Foundry Studio.
- Check regional quota limits.

### Empty Summary or Image Output

- Verify that prompt templates include all required placeholders:
  - `SummarySystemPromptTemplate` must include `{MaxChars}`
  - `SummaryUserPromptTemplate` must include `{Text}`
  - `ImagePromptUserTemplate` must include `{Summary}`
