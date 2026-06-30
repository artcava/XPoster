# Instagram Account Setup

> This document covers **only** the Instagram and Meta platform configuration required to enable programmatic publishing via the Instagram Platform API. For XPoster integration details, see [issue #72](https://github.com/artcava/XPoster/issues/72).

> ⚠️ This guide uses the **Instagram API with Facebook Login** flow, which requires an Instagram Business account linked to a Facebook Page. This is the recommended path if you already have a Facebook Page connected to your Instagram account.

---

## Prerequisites

- An **Instagram Business or Creator account** (personal accounts must be converted — see Step 1)
- A **Facebook Page** connected to the Instagram account (see Step 2)
- A **Facebook personal account** with Admin role on the Page
- Access to [developers.facebook.com](https://developers.facebook.com)

---

## Step 1 — Convert Instagram to a Business or Creator Account

The Instagram Platform API is **not available for personal accounts**. The Instagram Basic Display API, which historically served personal accounts, was **deprecated and shut down in 2024**. Programmatic publishing requires a **Professional account** (Business or Creator).

Conversion is free and reversible:

1. Open the Instagram app.
2. Go to **Settings → Account → Switch to Professional Account**.
3. Choose **Business** (recommended) or **Creator**.
4. Select a category and complete the optional contact info step.

> ✅ No content is lost. The account remains fully usable for normal Instagram activity after conversion.

---

## Step 2 — Connect Instagram to a Facebook Page

The Facebook Login flow routes all API requests through a Facebook Page. The Instagram Business account must be linked to a Page.

1. On Facebook, go to your Page.
2. Open **Settings → Linked Accounts** (or **Professional Dashboard → Settings → Instagram**).
3. Click **Connect Instagram** and complete the login flow.

Alternatively via Meta Business Suite ([business.facebook.com](https://business.facebook.com)):
1. Go to **Settings → Accounts → Instagram accounts**.
2. Click **Add** and follow the OAuth flow.

> ⚠️ This link is mandatory. Without it, the `instagram_business_account` field will not be accessible via the Graph API.

---

## Step 3 — Create a Meta Developer App

1. Go to [developers.facebook.com](https://developers.facebook.com) and log in with your Facebook account.
2. Click **My Apps → Create App**.
3. Select app type **Business**, then click **Next**.
4. Enter a name, a contact email, and click **Create App**.
5. In the app dashboard, go to **Facebook Login → Settings** and add the following **Valid OAuth Redirect URI**:
   ```
   https://developers.facebook.com/tools/explorer/
   ```
   This allows using the Graph API Explorer to generate tokens without setting up a real redirect endpoint.

---

## Step 4 — Add Your Account as Administrator or Tester

In Development mode, the API only works for accounts with an explicit role in the app.

1. In the app dashboard, go to **App Roles → Roles**.
2. Under **Administrators** or **Testers**, add the Facebook account that owns the Page.
3. Accept the invitation if prompted.

---

## Step 5 — Generate a Short-Lived Access Token via Graph API Explorer

1. Open the [Graph API Explorer](https://developers.facebook.com/tools/explorer/).
2. In the top-right dropdown **Meta App**, select your app.
3. Click **Generate Access Token**.
4. In the permissions dialog, check all four of the following:
   - `instagram_basic`
   - `instagram_content_publish`
   - `pages_show_list`
   - `pages_read_engagement`
5. Click **Generate Access Token** and complete the Facebook login consent screen.

The token displayed is a **short-lived User Access Token**, valid for approximately **1–2 hours**.

### Verify the token

Open the [Access Token Debugger](https://developers.facebook.com/tools/debug/accesstoken/), paste the token and click **Debug**. Confirm:
- **Type**: User
- **Scopes**: includes all four permissions above
- **Valid**: true

---

## Step 6 — Exchange for a Long-Lived Access Token

Short-lived tokens are not suitable for production. Exchange for a **long-lived token** valid for 60 days.

Open the following URL in your browser (replace the three placeholders):

```
https://graph.facebook.com/v20.0/oauth/access_token?grant_type=fb_exchange_token&client_id={APP_ID}&client_secret={APP_SECRET}&fb_exchange_token={SHORT_LIVED_TOKEN}
```

- `APP_ID` and `APP_SECRET` are found in **App Settings → Basic** in the Meta App Dashboard.

The response will be:
```json
{
  "access_token": "EAABsbCS...",
  "token_type": "bearer",
  "expires_in": 5183999
}
```

`expires_in` ≈ 5,184,000 seconds ≈ **60 days**.

Store the `access_token` value in Azure Key Vault with the secret name **`IgAccessToken`**.

> ⚠️ Tokens expire after 60 days. To renew, repeat Steps 5 and 6 before expiry. Automated refresh is tracked in [#72](https://github.com/artcava/XPoster/issues/72).

---

## Step 7 — Retrieve the Instagram Account ID

The Instagram Business Account ID is needed to form API request URLs in XPoster.

### Step 7a — Find your Facebook Page

In the Graph API Explorer, paste the **long-lived token** and run:

```
GET /me/accounts
```

> ⚠️ If this returns only your personal user ID and no Pages, it means the `pages_show_list` permission was not granted. Regenerate the token (Step 5) making sure all four permissions are checked.

If you know your Page's vanity name (e.g. `ArtCavaProjects`), you can query it directly and skip Step 7b:

```
GET /ArtCavaProjects?fields=id,instagram_business_account
```

### Step 7b — Get the Instagram Business Account ID

Using the Page ID from the previous step:

```
GET /{page-id}?fields=instagram_business_account
```

The response will contain:

```json
{
  "instagram_business_account": {
    "id": "17841400000000000"
  },
  "id": "{page-id}"
}
```

The `instagram_business_account.id` value is your Instagram Account ID. Store it in Azure Key Vault with the secret name **`IgAccountId`**.

### Verify the connection

Confirm the account is reachable with the token:

```
GET /{IgAccountId}?fields=id,name,username
```

You should see the Instagram account name and username. If this call succeeds, the configuration is complete.

---

## Step 8 — App Review (Production Only)

In **Development mode**, everything above works only for accounts with a role in the app. For a private single-account automation like XPoster, **App Review is not required**.

App Review is only needed if the app will publish on behalf of **third-party Instagram accounts**. In that case, request the following permissions via **App Review → Permissions and Features**:
- `instagram_basic`
- `instagram_content_publish`
- `pages_show_list`
- `pages_read_engagement`

---

## Azure Key Vault Secret Names Reference

At the end of this setup, the following secrets must be stored in Azure Key Vault with **these exact names**, which XPoster reads via `IOptions<IgCredentials>`:

| Key Vault Secret Name | Value | How to obtain |
|---|---|---|
| `IgAccessToken` | Long-lived User Access Token | Step 6 |
| `IgAccountId` | Instagram Business Account numeric ID | Step 7b (`instagram_business_account.id`) |

> ✅ **Part 1 completed (June 2026)** — Both secrets have been registered in Key Vault with the names above.

> Never commit tokens to source control or expose them in logs.

---

## Token Management

| Token type | Validity | Exchange endpoint |
|---|---|---|
| Short-lived User Token | ~1–2 hours | — |
| Long-lived User Token | 60 days | `graph.facebook.com/v20.0/oauth/access_token` with `grant_type=fb_exchange_token` |

---

## Image Requirements

| Constraint | Requirement |
|---|---|
| Format | **JPEG only** (PNG, GIF, MPO, JPS not accepted) |
| Aspect ratio | Between 4:5 (portrait) and 1.91:1 (landscape) |
| Minimum width | 320 px |
| Maximum width | 1440 px |
| Maximum file size | 8 MB |
| Color space | sRGB recommended |

Images must be hosted at a **direct, publicly accessible URL** — no authentication, no redirects. Sharing links from Google Drive, OneDrive, or similar services are rejected by Meta's media pipeline.

---

## Rate Limits

| Limit | Value |
|---|---|
| Content publishing | **50 posts per 24 hours** per account |
| API calls | 200 calls per hour per user token |

Exceeding the publishing limit returns HTTP `429`. The `Retry-After` header indicates when the limit resets.

---

## References

- [Instagram Platform Overview](https://developers.facebook.com/documentation/instagram-platform)
- [Instagram API with Facebook Login — Overview](https://developers.facebook.com/docs/instagram-platform/instagram-api-with-facebook-login/overview)
- [Graph API Explorer](https://developers.facebook.com/tools/explorer/)
- [Access Token Debugger](https://developers.facebook.com/tools/debug/accesstoken/)
- [Meta App Dashboard](https://developers.facebook.com/apps/)
- Tracking issue: [#72](https://github.com/artcava/XPoster/issues/72)
