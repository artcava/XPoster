# Azure AI Foundry — Setup Guide

This guide explains how to provision Azure AI Foundry and configure XPoster to use `AzureFoundryService` as the AI provider.

> **Provider capabilities:** Text (`ITextToTextProvider`) + Image generation (`ITextToImageProvider`)  
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
- `AzureFoundry__DeploymentName` → chat deployment
- `AzureFoundry__ImageDeploymentName` → image deployment

## 3. Retrieve Required Parameters

Collect these values from the Portal / Foundry Studio:

| Parameter | Where to find it |
|-----------|------------------|
| `AzureFoundry__Endpoint` | Resource overview blade → Endpoint (use the `/openai/v1` base URL) |
| `AzureFoundry__ApiKey` | Resource overview blade → Keys and Endpoint → Key 1 |
| `AzureFoundry__DeploymentName` | Foundry Studio → Deployments → chat model name |
| `AzureFoundry__ImageDeploymentName` | Foundry Studio → Deployments → image model name |

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

All other settings (`SummaryTemperature`, prompt templates, etc.) have sensible defaults and can be omitted if the defaults suit your use case. See `src/local.settings.json.example` for the full list.

## 5. Store Secrets Safely

For production environments:

- Use **Azure Function App Settings** for non-secret configuration.
- Store secrets (`AzureFoundry__ApiKey`) in **Azure Key Vault** and reference them from App Settings.
- Never commit secrets to source control. `local.settings.json` is in `.gitignore`.

## 6. Switch Provider via `AiProvider`

XPoster selects the AI provider per orchestrator slot via the `AiProvider` setting. Available values:

| `AiProvider` value | Text provider | Image provider |
|--------------------|---------------|----------------|
| `OpenAi` | `OpenAiService` | `OpenAiService` |
| `AzureFoundry` | `AzureFoundryService` | `AzureFoundryService` |
| `DeepSeek` | `DeepSeekService` | ❌ none — posts published text-only |
| `Perplexity` | `PerplexityService` | ❌ none — posts published text-only |
| `FalAi` | ❌ none | `FalAiImageService` |

## 7. Troubleshooting

### 401 / 403 Unauthorized

- Verify `AzureFoundry__ApiKey` is correct and belongs to the same resource as `AzureFoundry__Endpoint`.

### 404 Deployment Not Found

- Confirm `AzureFoundry__DeploymentName` and `AzureFoundry__ImageDeploymentName` match the exact names in Foundry Studio.
- Check region and project alignment.

### 429 Too Many Requests

- Reduce call frequency or increase capacity/quota in Foundry Studio.
- Check regional quota limits.

### Empty Summary or Image Output

- Verify that prompt templates include all required placeholders:
  - `AzureFoundry__SummarySystemPromptTemplate` must include `{MaxChars}`
  - `AzureFoundry__SummaryUserPromptTemplate` must include `{Text}`
  - `AzureFoundry__ImagePromptUserTemplate` must include `{Summary}`
