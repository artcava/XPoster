# Azure Blob Storage setup for IgSender

This guide explains how to create and configure the Azure Blob Storage container required by `IgSender` so that XPoster can upload images and generate time-limited SAS URLs for the Instagram Graph API.

---

## 1. Prerequisites

Before configuring Blob Storage, ensure you have:

- An Azure subscription with permissions to create resources.
- The XPoster Function App already deployed (or planned) in a resource group.
- The Azure CLI or Azure Portal access.

---

## 2. Create or reuse the Storage Account

1. Choose the same resource group and region used by the XPoster Function App to minimize latency and simplify management.
2. Create a **General-purpose v2** Storage Account (recommended) if you do not already have one suitable for blob storage.
3. Use standard performance and redundancy options aligned with your subscription defaults; no special performance tier is required for XPoster’s expected volume.

> Recommendation: Use a dedicated Storage Account for XPoster staging/production, but this is not strictly required as long as access control is correctly configured.

---

## 3. Create the `xposter-images` blob container

1. In the Storage Account, open **Containers** under the **Data storage** section.
2. Create a new container with:
   - **Name**: `xposter-images` (this is the default expected by the configuration).
   - **Public access level**: **Private (no anonymous access)**.
3. Confirm creation.

> Important: Do **not** enable anonymous public access on the container. XPoster uses SAS URLs with read-only permissions instead of a publicly accessible container.

---

## 4. Configure connection settings for XPoster

XPoster expects Blob Storage configuration via application settings, not through inline environment variable reads in the code.

### 4.1 Define app settings

Add the following settings to your Function App configuration (for example in `local.settings.json` for local development and in `Application Settings` for Azure):

- `AZURE_STORAGE_CONNECTION_STRING`  
  - Value: the Storage Account connection string from the Azure Portal (**Access keys** → **Connection string**).
  - Required: **Yes**.

- `AZURE_STORAGE_CONTAINER_NAME`  
  - Value: `xposter-images` (or a custom container name if you decide to override the default).
  - Required: **Optional** (if omitted, the implementation will default to `xposter-images`).

Ensure these settings are consistent across environments (local, staging, production), with environment-specific values handled by your deployment process.

---

## 5. (Recommended) Configure Managed Identity access

For production environments, prefer Managed Identity over connection-string-based access.

1. Enable a **System-assigned Managed Identity** on the XPoster Function App in the Azure Portal.
2. In the Storage Account, go to **Access control (IAM)** → **Add role assignment**.
3. Assign the role:
   - **Role**: `Storage Blob Data Contributor` (minimum required for read/write/delete of blobs).
   - **Scope**: This Storage Account (or narrower if desired).
   - **Principal**: The XPoster Function App’s Managed Identity.
4. Save the assignment.

> When Managed Identity is used, the code can switch to `DefaultAzureCredential` instead of a connection string, but the architectural constraint is that configuration is bound through `IOptions` and injected via DI. The storage lifecycle is always owned by `IBlobStorageService`, not by `IgSender` directly.

---

## 6. SAS URL policy for Instagram media uploads

XPoster does **not** expose the container publicly. Instead, `IBlobStorageService.UploadAsync` must upload the image and return a time-limited SAS URL.

When implementing or validating Blob Storage configuration, ensure the following behavior is supported:

1. The uploaded image is stored in the `xposter-images` container (or the container configured via `AZURE_STORAGE_CONTAINER_NAME`).
2. A SAS URL is generated with:
   - Permissions: **read-only** (`BlobSasPermissions.Read`).
   - Start time: `UtcNow.AddMinutes(-5)` to absorb small clock skew between Azure and Meta servers.
   - Expiry time: `UtcNow.AddMinutes(30)` for a 30-minute validity window.
3. The returned URL is a direct GET endpoint (no additional auth headers, no redirects), suitable for use as `media_url` in the Instagram Graph API.
4. Logs contain only non-sensitive information such as blob name and URI (never log the connection string or any secrets).

This approach is more secure than anonymous containers while being fully compatible with Meta’s media upload requirements.

---

## 7. Lifecycle management: automatic blob cleanup

Because Instagram posts are processed asynchronously and the blobs are only needed temporarily, configure a Lifecycle Management rule on the container as a safety net.

1. In the Storage Account, go to **Data management** → **Lifecycle management**.
2. Create a new rule:
   - Scope: Apply to the `xposter-images` container.
   - Condition: Blob age greater than **1 day**.
   - Action: **Delete blob**.
3. Enable the rule.

> The polling function (`XPosterContainerPollingFunction`) will also delete blobs after publish or failure, but the lifecycle rule ensures cleanup in case of unexpected failures or state inconsistencies.

---

## 8. Integration expectations for XPoster

Once the Storage Account and container are configured as above, XPoster can rely on them through `IBlobStorageService`:

- `IgSender` calls `IBlobStorageService.UploadAsync` to upload JPEG images and obtain SAS URLs.
- The service uses the configured connection string and container name via `IOptions` in `Program.cs`, with `BlobServiceClient` registered as a singleton.
- The same Storage Account can later be used for additional senders or staging/production environments by adjusting app settings only.