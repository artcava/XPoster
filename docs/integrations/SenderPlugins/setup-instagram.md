# Instagram Setup

> ⚠️ **Not yet active** — Instagram support is tracked in [#72](https://github.com/artcava/XPoster/issues/72). The sender plugin (`IgSender`) exists but is not production-ready. Do not enable Instagram slots in `OrchestratorFactory` until all prerequisites below are satisfied.

## Overview

XPoster publishes image posts to Instagram via the **Instagram Graph API v20.0** using a two-step flow:
1. Create a media container (`POST /{ig-user-id}/media`)
2. Publish the container (`POST /{ig-user-id}/media_publish`)

The API requires the image to be hosted at a **publicly accessible URL** (no redirects, no authentication). XPoster uses Azure Blob Storage to serve this URL.

---

## Account Requirements

> ⚠️ The Instagram Graph API is **not available for personal accounts**. It is exclusively designed for Business and Creator accounts.

The Basic Display API (which supported personal accounts) was deprecated and shut down in 2024. As of 2026, the only supported path for programmatic publishing is the Graph API, which requires:

- An **Instagram Business or Creator** account (not a personal/private account)
- The account must be **connected to a Facebook Page**
- A **Meta Developer App** of type Business with the Instagram Graph API product added

Converting a personal account to Business/Creator is free and can be done from Instagram app settings → Account → Switch to Professional Account.

---

## Part 1 — Instagram Platform Prerequisites (Manual)

Complete these steps before any code deployment. They are one-time manual operations.

### 1.1 Meta Developer App

1. Go to [Meta for Developers](https://developers.facebook.com) and create a new app (type: **Business**).
2. Add the **Instagram Graph API** product to the app.
3. In App Review, request the following permissions:
   - `instagram_basic`
   - `instagram_content_publish`
   - `pages_read_engagement`

### 1.2 Connect Instagram to a Facebook Page

1. In the Meta Business Suite, link your Instagram Business/Creator account to a Facebook Page.
2. In the Meta Developer App, add the Facebook Page under **Instagram Graph API → Instagram Accounts**.

### 1.3 Generate a Long-Lived Access Token

1. Generate a short-lived User Access Token from the [Graph API Explorer](https://developers.facebook.com/tools/explorer/).
2. Exchange it for a **long-lived token** (valid 60 days) via:
   ```
   GET https://graph.facebook.com/v20.0/oauth/access_token
     ?grant_type=fb_exchange_token
     &client_id={app-id}
     &client_secret={app-secret}
     &fb_exchange_token={short-lived-token}
   ```
3. Store the token in the `IG_ACCESS_TOKEN` app setting (Azure Key Vault or Function App Configuration).

> ⚠️ Long-lived tokens expire after **60 days**. Manual rotation is required until a refresh flow is implemented (tracked separately).

### 1.4 Retrieve the Instagram Account ID

```
GET https://graph.facebook.com/v20.0/me/accounts?access_token={token}
```
From the response, locate your Page, then:
```
GET https://graph.facebook.com/v20.0/{page-id}?fields=instagram_business_account&access_token={token}
```
Store the returned `id` in the `IG_ACCOUNT_ID` app setting.

---

## Part 2 — Azure Blob Storage Setup

Instagram requires images to be served from a public URL. XPoster uses Azure Blob Storage for this purpose.

1. Create (or reuse) an **Azure Storage Account** in the same resource group as the Function App.
2. Create a container named `xposter-images` with **Blob (anonymous read)** access level.
3. Add a **lifecycle rule** to auto-delete blobs older than 1 day (images are ephemeral — only needed during API processing).
4. For production, prefer **Managed Identity** with `DefaultAzureCredential` and the `Storage Blob Data Contributor` role assigned to the Function App identity.

> ⚠️ The blob URL passed to Instagram must be a **direct JPEG file URL** with no redirects. Google Drive, OneDrive, and similar sharing links are rejected by Meta's media upload pipeline.

---

## Part 3 — App Settings

Add the following settings to the Function App Configuration (or `local.settings.json` for local development):

| Variable | Required | Description |
|---|---|---|
| `IG_ACCESS_TOKEN` | ✅ | Long-lived Instagram Graph API access token |
| `IG_ACCOUNT_ID` | ✅ | Instagram Business Account numeric ID |
| `AZURE_STORAGE_CONNECTION_STRING` | ✅ | Azure Storage connection string (or use Managed Identity) |
| `AZURE_STORAGE_CONTAINER_NAME` | Optional | Blob container name (default: `xposter-images`) |

All secrets must be stored in **Azure Key Vault** and referenced via the Key Vault Configuration Provider. Never hardcode tokens or connection strings.

---

## Part 4 — Image Requirements

The Instagram Graph API enforces strict image constraints:

- **Format**: JPEG only (PNG, MPO, JPS are not supported)
- **Aspect ratio**: between 4:5 and 1.91:1
- **Minimum width**: 320px
- **Maximum width**: 1440px
- **Maximum file size**: 8 MB

`IgSender` validates the JPEG format via magic bytes (`FF D8`) before uploading. Posts with non-JPEG images are rejected with a warning log and `return false`.

---

## Part 5 — Known Limitations and Production Gaps

The following issues are tracked in [#72](https://github.com/artcava/XPoster/issues/72) and must be resolved before enabling Instagram slots in production:

| # | Gap | Status |
|---|---|---|
| 1 | `UploadImageToPublicUrl` throws `NotImplementedException` | 🔴 Open |
| 2 | `IBlobStorageService` not yet implemented or registered | 🔴 Open |
| 3 | `access_token` currently sent in JSON body (must be query param) | 🟠 Open |
| 4 | Raw API error response logged (may echo token) | 🟠 Open |
| 5 | No Polly retry-after handling for HTTP 429 (25 posts/24h limit) | 🟡 Open |
| 6 | No `container_status` polling before `/media_publish` | 🟡 Open |
| 7 | Token expiry (60 days) — no automated refresh flow | 🟡 Open |

---

## Part 6 — Enabling Instagram Slots

Once all prerequisites are met and staging validation is complete, re-enable the Instagram time slots in `OrchestratorFactory`:

```csharp
{ 10, MessageSender.IgSummaryFeed },
{ 18, MessageSender.IgPowerLow },
```

This step is gated on successful end-to-end staging validation with a real Instagram Business account.

---

## References

- [Instagram Graph API — Content Publishing](https://developers.facebook.com/docs/instagram-platform/instagram-graph-api/reference/ig-user/media/)
- [IG User Media Publish endpoint](https://developers.facebook.com/docs/instagram-platform/instagram-graph-api/reference/ig-user/media_publish/)
- [Meta for Developers — Graph API Explorer](https://developers.facebook.com/tools/explorer/)
- Tracking issue: [#72](https://github.com/artcava/XPoster/issues/72)
