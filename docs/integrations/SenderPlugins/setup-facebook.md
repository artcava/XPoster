# Facebook Account Setup

> ⚠️ This guide uses the **Facebook API with Facebook Login** flow, which requires a Facebook Page account.

---

## Prerequisites

- A **Facebook Page**
- A **Facebook personal account** with Admin role on the Page
- Access to [developers.facebook.com](https://developers.facebook.com)

---

## Step 1 — Create a Meta Developer App

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

## Step 2 — Add Your Account as Administrator or Tester

In Development mode, the API only works for accounts with an explicit role in the app.

1. In the app dashboard, go to **App Roles → Roles**.
2. Under **Administrators** or **Testers**, add the Facebook account that owns the Page.
3. Accept the invitation if prompted.

---

## Step 3 — Generate a Short-Lived Access Token via Graph API Explorer

1. Open the [Graph API Explorer](https://developers.facebook.com/tools/explorer/).
2. In the top-right dropdown **Meta App**, select your app.
3. Click **Generate Access Token**.
4. In the permissions dialog, check all five of the following:
   - `public_profile`
   - `pages_read_engagement`
   - `pages_show_list`
   - `pages_manage_posts`
   - `business_management`

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

Store the `access_token` value in Azure Key Vault with the secret name **`FacebookAccessToken`**.

---

## Step 5 — Retrieve the Facebook Page ID

In the Graph API Explorer, paste the **long-lived token** and run:

```
GET /me/accounts
```

> ⚠️ If this returns only your personal user ID and no Pages, it means the `pages_show_list` permission was not granted. Regenerate the token (Step 3) making sure all four permissions are checked.

The response will contain:

```json
    {
      "access_token": "%MASKED%",
      "category": "Azienda di informatica",
      "category_list": [
        {
          "id": "1130035050388269",
          "name": "Azienda di informatica"
        }
      ],
      "name": "ArtCava Projects",
      "id": "<this-is-your-page-id>",
      "tasks": [
        "ADVERTISE",
        "ANALYZE",
        "CREATE_CONTENT",
        "MESSAGING",
        "MODERATE",
        "MANAGE"
      ]
    }
```

The `<this-is-your-page-id>` value is your Facebook Page ID. Store it in Azure Key Vault with the secret name **`FacebookPageId`**.

### Verify the connection

Confirm the account is reachable with the token:

```
GET /{FacebookPageId}?fields=id,name,username
```

You should see the Facebook Page name and username. If this call succeeds, the configuration is complete.

---

## Azure Key Vault Secret Names Reference

At the end of this setup, the following secrets must be stored in Azure Key Vault with **these exact names**, which XPoster reads via `IOptions<FacebookCredentials>`:

| Key Vault Secret Name | Value | How to obtain |
|---|---|---|
| `FacebookAccessToken` | Long-lived User Access Token | Step 4 |
| `FacebookAccountId` | Facebook Page numeric ID | Step 5 (`<this-is-your-page-id>`) |

> Never commit tokens to source control or expose them in logs. XPoster mask http calls with `ITelemetryInitializer`

---

## Token Management

| Token type | Expiration | Exchange endpoint |
|---|---|---|
| Short-lived User Token | ~1–2 hours | — |
| Long-lived User Token | never | `graph.facebook.com/v23.0/oauth/access_token` with `grant_type=fb_exchange_token` |

---

## References

- [Graph API Explorer](https://developers.facebook.com/tools/explorer/)
- [Access Token Debugger](https://developers.facebook.com/tools/debug/accesstoken/)
- [Meta App Dashboard](https://developers.facebook.com/apps/)
