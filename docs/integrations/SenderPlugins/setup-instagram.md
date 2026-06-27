# Instagram Account Setup

> This document covers **only** the Instagram and Meta platform configuration required to enable programmatic publishing via the Instagram Platform API. For XPoster integration details, see [issue #72](https://github.com/artcava/XPoster/issues/72).

---

## Which API to use

Meta currently offers two configurations for Instagram publishing:

| | **Instagram API with Instagram Login** | Instagram API with Facebook Login |
|---|---|---|
| Login | Instagram credentials | Facebook credentials |
| Facebook Page required | ❌ No | ✅ Yes |
| API host | `graph.instagram.com` | `graph.facebook.com` |
| Content Publishing | ✅ | ✅ |
| Recommended | ✅ **Yes** | For legacy integrations only |

XPoster uses the **Instagram API with Instagram Login**, which is the current recommended path by Meta as of 2024 and removes the dependency on a Facebook Page.

> **Reference**: [developers.facebook.com/documentation/instagram-platform](https://developers.facebook.com/documentation/instagram-platform)

---

## Prerequisites

- An **Instagram account** (personal accounts must be converted — see Step 1)
- A **Facebook account** (required to access the Meta Developer Portal and create an app)
- Access to [developers.facebook.com](https://developers.facebook.com)

---

## Step 1 — Convert Instagram to a Business or Creator Account

The Instagram Platform API is **not available for personal accounts**. The Instagram Basic Display API, which historically served personal accounts, was **deprecated and shut down in 2024**. Programmatic publishing requires a **Professional account** (Business or Creator).

Conversion is free and reversible:

1. Open the Instagram app.
2. Go to **Settings → Account → Switch to Professional Account**.
3. Choose **Business** (recommended) or **Creator**.
4. Select a category and complete the optional contact info step.

> ✅ No content is lost. The account remains usable for normal Instagram activity after conversion.

---

## Step 2 — Create a Meta Developer App

1. Go to [developers.facebook.com](https://developers.facebook.com) and log in with your Facebook account.
2. Click **My Apps → Create App**.
3. When asked *"What do you want your app to do?"*, select **Other**, then click **Next**.
4. Select app type **Business**, then click **Next**.
5. Enter a name, a contact email, and optionally link a Business Portfolio. Click **Create App**.

---

## Step 3 — Add the Instagram Product (Business Login for Instagram)

1. In the app dashboard, scroll to **Add Products to Your App**.
2. Find **Instagram** and click **Set up**.
3. In the Instagram setup page, choose **API setup with Instagram login**.
4. Note the **Instagram App ID** and **Instagram App Secret** shown in this section — these are your app credentials.

> ⚠️ The Instagram App ID shown here may differ from the Meta App ID displayed in **App Settings → Basic**. Use the one from the Instagram product section.

---

## Step 4 — Configure Permissions

In the Instagram product dashboard, under **Permissions**, enable:

| Permission | Purpose |
|---|---|
| `instagram_business_basic` | Read profile info and media |
| `instagram_business_content_publish` | Publish photos and videos |

In **Development mode** these permissions are pre-approved and work immediately for accounts with a role in the app (see Step 5). No App Review is needed for personal use.

> ⚠️ These are the **new permission names** introduced with the Instagram Login flow. The old names (`instagram_basic`, `instagram_content_publish`) belong to the Facebook Login flow and are **not interchangeable**.

---

## Step 5 — Add Your Instagram Account as a Tester

In Development mode, the API only works for accounts explicitly assigned a role in the app.

1. In the app dashboard, go to **App Roles → Roles**.
2. Under **Testers**, click **Add Testers**.
3. Search for the Instagram username (not Facebook) of the account you want to publish from.
4. The invited account must **accept the invitation**: open the Instagram app → **Settings → Apps and Websites → Tester Invites** and accept.

> If this step is skipped, all API calls will return error code `10` (*Permission Denied*) even with a valid token.

---

## Step 6 — Generate a Short-Lived Access Token

With Instagram Login, token generation uses Instagram's own OAuth flow, not the Graph API Explorer.

### Option A — Via the App Dashboard (quickest for initial setup)

1. In the app dashboard, go to the **Instagram → API setup with Instagram login** section.
2. Click **Generate Token** next to your Instagram account.
3. Complete the Instagram OAuth consent screen, granting `instagram_business_basic` and `instagram_business_content_publish`.
4. Copy the **Instagram User Access Token** displayed.

### Option B — Via OAuth URL (for automation or re-generation)

Construct the authorization URL:

```
https://api.instagram.com/oauth/authorize
  ?client_id={instagram-app-id}
  &redirect_uri={your-redirect-uri}
  &scope=instagram_business_basic,instagram_business_content_publish
  &response_type=code
```

After the user authorizes, Instagram redirects to `{redirect_uri}?code={auth-code}`. Exchange the code for a token:

```
POST https://api.instagram.com/oauth/access_token

Content-Type: application/x-www-form-urlencoded
client_id={instagram-app-id}
client_secret={instagram-app-secret}
grant_type=authorization_code
redirect_uri={your-redirect-uri}
code={auth-code}
```

The response contains a **short-lived Instagram User Access Token** valid for **1 hour**.

---

## Step 7 — Exchange for a Long-Lived Access Token

Short-lived tokens are not suitable for production. Exchange for a **long-lived token** (valid 60 days):

```
GET https://graph.instagram.com/access_token
  ?grant_type=ig_exchange_token
  &client_secret={instagram-app-secret}
  &access_token={short-lived-token}
```

The response contains:
```json
{
  "access_token": "IGAAx...",
  "token_type": "bearer",
  "expires_in": 5183944
}
```

`expires_in` is in seconds — approximately 60 days.

### Refresh before expiry

Before the token expires (renew from day 50 onwards), call:

```
GET https://graph.instagram.com/refresh_access_token
  ?grant_type=ig_refresh_token
  &access_token={long-lived-token}
```

This resets the expiry to a fresh 60 days. The same token value is returned with an updated `expires_in`.

> ⚠️ Note: both exchange and refresh calls target `graph.instagram.com`, **not** `graph.facebook.com`. This is a key difference from the Facebook Login flow.

---

## Step 8 — Retrieve the Instagram Account ID

The Instagram Account ID (`IG_ACCOUNT_ID`) is required to construct API request URLs.

With Instagram Login, the ID is retrieved directly — no Facebook Page lookup is needed:

```
GET https://graph.instagram.com/v22.0/me
  ?fields=id,name,username
  &access_token={long-lived-token}
```

Example response:
```json
{
  "id": "17841400000000000",
  "name": "Your Name",
  "username": "yourusername"
}
```

The `id` value is your `IG_ACCOUNT_ID`. Store it in the `IG_ACCOUNT_ID` app setting.

---

## Step 9 — App Review (Production Only)

In **Development mode**, the setup above works only for accounts added as Testers (Step 5). For a private single-account automation like XPoster, **App Review is not required**.

App Review is only needed if the app will publish on behalf of **third-party Instagram accounts** (i.e., other users' accounts via OAuth). In that case:

1. Go to **App Review → Permissions and Features**.
2. Request `instagram_business_basic` and `instagram_business_content_publish`.
3. Provide screen recordings and usage descriptions.
4. Switch the app to **Live mode** after approval.

---

## App Settings Reference

At the end of this setup, you will have the following values to store securely (e.g. Azure Key Vault):

| Setting | Where to find it |
|---|---|
| `IG_ACCESS_TOKEN` | Generated in Step 7 (long-lived token) |
| `IG_ACCOUNT_ID` | Retrieved in Step 8 (`/me?fields=id`) |

> Never commit tokens to source control or expose them in logs.

---

## Token Management Summary

| Token type | Validity | Host | Notes |
|---|---|---|---|
| Short-lived Instagram User Token | ~1 hour | `api.instagram.com` | Only used to generate long-lived token |
| Long-lived Instagram User Token | 60 days | `graph.instagram.com` | Use in production; refresh before day 50 |

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
- [Instagram API with Instagram Login — Content Publishing](https://developers.facebook.com/docs/instagram-platform/instagram-api-with-instagram-login/content-publishing/)
- [Instagram API with Instagram Login — Overview](https://developers.facebook.com/docs/instagram-platform/overview/)
- [Meta Developer Portal](https://developers.facebook.com)
- [Access Token Debugger](https://developers.facebook.com/tools/debug/accesstoken/)
- Tracking issue: [#72](https://github.com/artcava/XPoster/issues/72)
