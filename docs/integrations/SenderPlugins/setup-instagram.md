# Instagram Account Setup

> This document covers **only** the Instagram and Meta platform configuration required to enable programmatic publishing via the Instagram Graph API. For XPoster integration details, see [issue #72](https://github.com/artcava/XPoster/issues/72).

---

## Prerequisites

Before starting, verify you have:

- A **Facebook personal account** (required to own a Business Page and a Meta Developer App)
- An **Instagram account** (personal is fine as a starting point — it will be converted to Business/Creator)
- Access to the **Meta Developer Portal**: [developers.facebook.com](https://developers.facebook.com)

---

## Step 1 — Convert Instagram to a Business or Creator Account

The Instagram Graph API is **not available for personal accounts**. The Instagram Basic Display API, which historically served personal accounts, was **deprecated and shut down in 2024**. As of 2026, the only supported path for programmatic publishing is the Graph API, which requires a **Professional account** (Business or Creator).

Conversion is free and reversible:

1. Open the Instagram app.
2. Go to **Settings → Account → Switch to Professional Account**.
3. Choose **Business** (recommended for API publishing) or **Creator**.
4. Select a category and complete the optional contact info step.

> ✅ After conversion the account remains fully usable for normal Instagram activity. No content is lost.

---

## Step 2 — Create a Facebook Page

The Instagram Graph API routes all requests through a **Facebook Page**. An Instagram Business account must be linked to a Page before the API can be used.

If you don’t have a Page yet:

1. On Facebook, click **Pages → Create new Page**.
2. Give it a name (it can be a test page — it does not need to be public).
3. Complete the minimal required fields and publish.

---

## Step 3 — Link Instagram to the Facebook Page

1. Go to your Facebook Page.
2. Open **Settings → Linked Accounts** (or **Professional Dashboard → Settings → Instagram**).
3. Click **Connect Instagram**.
4. Log in with your Instagram credentials and confirm the connection.

Alternatively, via **Meta Business Suite** ([business.facebook.com](https://business.facebook.com)):

1. Go to **Settings → Accounts → Instagram accounts**.
2. Click **Add** and follow the OAuth flow.

> ⚠️ This step is **mandatory**. Without the Page–Instagram link, all Graph API calls return an authorization error regardless of the token scopes.

---

## Step 4 — Create a Meta Developer App

1. Go to [developers.facebook.com](https://developers.facebook.com) and log in.
2. Click **My Apps → Create App**.
3. Under **Use case**, select **Content Management** → **Manage messaging and content on Instagram**, then click **Next**.
4. Optionally connect a Business Portfolio, then click **Next**.
5. Give the app a name, enter a contact email, and click **Create App**.

> The app type must be **Business**. Consumer-type apps cannot add the Instagram Graph API product.

---

## Step 5 — Add Instagram Graph API Product

1. Inside the app dashboard, go to **Customize** under the *Manage messaging and content on Instagram* use case.
2. Select **API Setup with Facebook Login**.
3. Under **Permissions**, add all required scopes:
   - `instagram_basic`
   - `instagram_content_publish`
   - `pages_read_engagement`
   - `pages_show_list`

> In **Development mode** these permissions are available immediately without App Review, but they only work for accounts explicitly added as Testers or Administrators of the app (see Step 6).

---

## Step 6 — Add Your Instagram Account as a Tester

While the app is in Development mode (the default state), the API only accepts requests on behalf of accounts that have been granted a role in the app.

1. In the app dashboard, go to **App Roles → Roles**.
2. Under **Testers**, click **Add** and enter the Facebook account linked to your Instagram.
3. The invited account must **accept the invitation**: open Facebook Notifications → accept the developer role.
4. On Instagram, also go to **Settings → Apps and Websites** and verify the app appears as authorized.

> If you skip this step, token generation will succeed but API calls will return error code `10` (*Not authorized*).

---

## Step 7 — Generate a Short-Lived Access Token

1. Open the **Graph API Explorer**: [developers.facebook.com/tools/explorer](https://developers.facebook.com/tools/explorer)
2. In the top-right dropdown, select the app you just created.
3. Click **Get Token → Get User Access Token**.
4. In the permissions dialog, check:
   - `instagram_basic`
   - `instagram_content_publish`
   - `pages_read_engagement`
   - `pages_show_list`
5. Click **Generate Access Token** and complete the OAuth consent flow.
6. Select the Instagram account you want to publish from, click **Save**, then **Got it**.

The token shown in the Explorer is a **short-lived User Access Token** valid for approximately **1–2 hours**.

---

## Step 8 — Exchange for a Long-Lived Access Token

Short-lived tokens are not usable in production. Exchange them for a **long-lived token** (valid 60 days).

Call the following endpoint from a browser or curl:

```
GET https://graph.facebook.com/v20.0/oauth/access_token
  ?grant_type=fb_exchange_token
  &client_id={your-app-id}
  &client_secret={your-app-secret}
  &fb_exchange_token={short-lived-token}
```

- `{your-app-id}` and `{your-app-secret}` are found in the app dashboard under **App Settings → Basic**.
- The response contains `access_token` (the long-lived token) and `expires_in` (seconds, approximately 5,184,000 ≈ 60 days).

Verify the token and confirm its scopes via the **Access Token Debugger**:

```
https://developers.facebook.com/tools/debug/accesstoken/
```

Paste the token and click **Debug**. Confirm:
- **Type**: User
- **Expires**: ~60 days from now
- **Scopes**: includes `instagram_basic`, `instagram_content_publish`, `pages_read_engagement`

> ⚠️ Long-lived tokens expire after **60 days**. To avoid disruption, renew them **before day 50** by calling the same exchange endpoint with the still-valid long-lived token.

---

## Step 9 — Retrieve the Instagram Account ID

The numeric Instagram Account ID (`IG_ACCOUNT_ID`) is needed to form API request URLs.

**Step 9a** — Get your Facebook Pages:
```
GET https://graph.facebook.com/v20.0/me/accounts
  ?access_token={long-lived-token}
```
Note the `id` of the Page connected to your Instagram account.

**Step 9b** — Get the linked Instagram Business Account ID:
```
GET https://graph.facebook.com/v20.0/{page-id}
  ?fields=instagram_business_account
  &access_token={long-lived-token}
```

The response contains:
```json
{
  "instagram_business_account": {
    "id": "17841400000000000"
  },
  "id": "{page-id}"
}
```

The `instagram_business_account.id` value is your `IG_ACCOUNT_ID`.

Alternatively, from the **Graph API Explorer**, search the `instagram_business_account.id` field from the debugger output under **Granular Scopes → instagram_basic**.

---

## Step 10 — App Review (Production Only)

In **Development mode**, everything above works only for accounts with a role in the app (Admins, Testers). This is sufficient for a single-owner automation.

If the app needs to act on behalf of **third-party Instagram accounts**, it must pass **Meta App Review**:

1. Go to **App Review → Permissions and Features**.
2. Request each permission used (`instagram_content_publish`, etc.).
3. Provide screen recordings and a written description of how the app uses each permission.
4. Switch the app to **Live mode** after approval.

> For a private automation (posting to your own account only), App Review is **not required**. Development mode is sufficient indefinitely.

---

## Token Management Summary

| Token type | Validity | Use |
|---|---|---|
| Short-lived User Token | ~1–2 hours | Only for generating long-lived tokens |
| Long-lived User Token | 60 days | Use in production; renew before day 50 |
| Page Token | Never expires | Not used for Instagram content publishing |

> Tokens must be stored securely (e.g. Azure Key Vault). Never commit tokens to source control or expose them in logs.

---

## Image Requirements

The Instagram Graph API enforces strict constraints on images submitted for publishing:

| Constraint | Requirement |
|---|---|
| Format | JPEG only (PNG, GIF, MPO, JPS not accepted) |
| Aspect ratio | Between 4:5 (portrait) and 1.91:1 (landscape) |
| Minimum width | 320 px |
| Maximum width | 1440 px |
| Maximum file size | 8 MB |
| Color space | sRGB recommended |

Images must be hosted at a **publicly accessible URL** (direct JPEG URL, no authentication, no redirects). Sharing links from Google Drive, OneDrive, or similar services are rejected by Meta’s media pipeline.

---

## Rate Limits

| Limit | Value |
|---|---|
| Content publishing | 25 posts per 24 hours per account |
| API calls | 200 calls per hour per user token |

Exceeding the publishing limit returns HTTP `429`. The `Retry-After` header indicates when the limit resets.

---

## References

- [Meta Developer Portal](https://developers.facebook.com)
- [Graph API Explorer](https://developers.facebook.com/tools/explorer)
- [Access Token Debugger](https://developers.facebook.com/tools/debug/accesstoken/)
- [Instagram Graph API — IG User Media endpoint](https://developers.facebook.com/docs/instagram-platform/instagram-graph-api/reference/ig-user/media/)
- [Instagram Graph API — Content Publishing guide](https://developers.facebook.com/docs/instagram-platform/content-publishing)
- [Meta Business Suite](https://business.facebook.com)
