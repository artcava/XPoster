# Azure Foundry Setup

This guide explains how to provision Azure AI Foundry and configure XPoster to use `AzureFoundryService` as `IAiService` provider.

## 1. Create Azure AI Foundry Resource

1. Open the Azure Portal.
2. Create a new `Azure AI Foundry` (or Azure OpenAI-compatible) resource.
3. Choose subscription, resource group, region, and pricing tier.
4. After deployment, open the resource and note:
- Endpoint URL
- Keys (Key 1 / Key 2)

## 2. Create Project And Deploy Models

1. Open Azure AI Foundry Studio for your resource.
2. Create a project (or use an existing one).
3. Deploy a chat model (for summaries and prompt generation).
4. Deploy an image-capable model (for image generation).
5. Save both deployment names.

Recommended mapping:
- `DeploymentName`: chat deployment
- `ImageDeploymentName`: image deployment

## 3. Retrieve Required Parameters

Collect these values from Portal/Foundry:

- `Endpoint`: resource endpoint, for example `https://<resource>.openai.azure.com`
- `ApiKey`: resource key
- `DeploymentName`: chat deployment name
- `ImageDeploymentName`: image deployment name
- `ApiVersion`: API version accepted by your deployed models (default in XPoster: `2024-02-01`)

## 4. Configure XPoster

Set these values in local settings (`src/local.settings.json`) or Azure App Settings:

```json
{
  "Values": {
    "AiProvider": "AzureFoundry",
    "AzureFoundry__Endpoint": "https://<resource>.openai.azure.com",
    "AzureFoundry__ApiKey": "<secret>",
    "AzureFoundry__DeploymentName": "<chat-deployment>",
    "AzureFoundry__ImageDeploymentName": "<image-deployment>",
    "AzureFoundry__ApiVersion": "2024-02-01"
  }
}
```

## 5. Store Secrets Safely

For production:

- Use Azure Function App Settings for non-secret config.
- Store secrets (`ApiKey`) in Azure Key Vault.
- Reference Key Vault values from Function App Settings.
- Never commit secrets into source control.

## 6. Switch Provider Using `AiProvider`

XPoster supports provider selection via `AiProvider` for AI-enabled generator slots.

- `AiProvider=OpenAi` uses `OpenAiService`.
- `AiProvider=AzureFoundry` uses `AzureFoundryService`.

If `AiProvider` is missing or invalid, XPoster falls back to the schedule default provider configured in `GeneratorFactory`.

## 7. Troubleshooting

### 401 / 403 Unauthorized

- Verify `AzureFoundry__ApiKey` value.
- Ensure key belongs to the same resource as `Endpoint`.

### 404 Deployment Not Found

- Confirm `DeploymentName` and `ImageDeploymentName` match deployed model names exactly.
- Check region/project alignment.

### 400 Bad Request (API version)

- Set `AzureFoundry__ApiVersion` to a version supported by your deployment.
- Validate endpoint path format and trailing slash handling.

### 429 Too Many Requests

- Reduce call frequency or increase capacity/quota.
- Check model quota usage and regional limits.

### Empty Summary Or Image Output

- Verify prompt templates include required placeholders:
- `SummarySystemPromptTemplate` must include `{MaxChars}`
- `SummaryUserPromptTemplate` must include `{Text}`
- `ImagePromptUserTemplate` must include `{Summary}`
