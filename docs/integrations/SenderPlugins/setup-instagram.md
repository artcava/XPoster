# Instagram Account Setup

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

## Step 3 — Extend Access Token via Graph API Explorer

1. Open the [Graph API Explorer](https://developers.facebook.com/tools/explorer/).
2. In the top-right dropdown **Meta App**, select your app.
3. Click **Generate Access Token**.
4. In the permissions dialog, add the following:
   - `instagram_basic`
   - `instagram_content_publish`
   - `instagram_manage_comments`

5. Click **Generate Access Token** and complete the Facebook login consent screen.

The token displayed is a **short-lived User Access Token**, valid for approximately **1–2 hours**.

### Verify the token

Open the [Access Token Debugger](https://developers.facebook.com/tools/debug/accesstoken/), paste the token and click **Debug**. Confirm:
- **Type**: User
- **Scopes**: includes all four permissions above
- **Valid**: true

---

## Step 4 — Exchange for a Long-Lived Access Token

Short-lived tokens are not suitable for production. Exchange for a **long-lived token**.

Open the following URL in your browser (replace the three placeholders):

```
https://graph.facebook.com/v20.0/oauth/access_token?grant_type=fb_exchange_token&client_id={APP_ID}&client_secret={APP_SECRET}&fb_exchange_token={SHORT_LIVED_TOKEN}
```

- `APP_ID` and `APP_SECRET` are found in **App Settings → Basic** in the Meta App Dashboard.

The response will be:
```json
{
  "access_token": "EAABsbCS...",
  "token_type": "bearer"
}
```

Store the `access_token` value in Azure Key Vault with the secret name **`InstagramAccessToken`**.

---

## Step 5 — Retrieve the Instagram Account ID

The Instagram Business Account ID is needed to form API request URLs in XPoster.

### Step 5a — Find your Facebook Page

In the Graph API Explorer, paste the **long-lived token** and run:

```
GET /me/accounts
```

> ⚠️ If this returns only your personal user ID and no Pages, it means the `pages_show_list` permission was not granted. Regenerate the token (Step 5) making sure all four permissions are checked.

If you know your Page's vanity name (e.g. `ArtCavaProjects`), you can query it directly and skip Step 5b:

```
GET /ArtCavaProjects?fields=id,instagram_business_account
```

### Step 5b — Get the Instagram Business Account ID

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

The `instagram_business_account.id` value is your Instagram Account ID. Store it in Azure Key Vault with the secret name **`InstagramAccountId`**.

### Verify the connection

Confirm the account is reachable with the token:

```
GET /{InstagramAccountId}?fields=id,name,username
```

You should see the Instagram account name and username. If this call succeeds, the configuration is complete.

---

## Azure Key Vault Secret Names Reference

At the end of this setup, the following secrets must be stored in Azure Key Vault with **these exact names**, which XPoster reads via `IOptions<InstagramCredentials>`:

| Key Vault Secret Name | Value | How to obtain |
|---|---|---|
| `InstagramAccessToken` | Long-lived User Access Token | Step 4 |
| `InstagramAccountId` | Instagram Business Account numeric ID | Step 5b (`instagram_business_account.id`) |

> Never commit tokens to source control or expose them in logs. XPoster mask http calls with `ITelemetryInitializer`

---

## Token Management

| Token type | Expiration | Exchange endpoint |
|---|---|---|
| Short-lived User Token | ~1–2 hours | — |
| Long-lived User Token | never | `graph.facebook.com/v23.0/oauth/access_token` with `grant_type=fb_exchange_token` |

---

## References

- [Instagram Platform Overview](https://developers.facebook.com/documentation/instagram-platform)
- [Instagram API with Facebook Login — Overview](https://developers.facebook.com/docs/instagram-platform/instagram-api-with-facebook-login/overview)
- [Graph API Explorer](https://developers.facebook.com/tools/explorer/)
- [Access Token Debugger](https://developers.facebook.com/tools/debug/accesstoken/)
- [Meta App Dashboard](https://developers.facebook.com/apps/)
