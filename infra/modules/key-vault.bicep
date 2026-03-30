// XPoster - Key Vault module
// Uses Vault Access Policy model (not RBAC) — consistent with existing subscription setup
// Naming convention for secrets: {Platform}{SecretType} (e.g. LinkedInAccessToken, InstagramAccessToken)

@description('Azure region')
param location string

@description('Key Vault name')
param keyVaultName string

@description('Principal ID of XPosterFunction System Assigned Managed Identity')
param functionAppPrincipalId string

@description('Environment tag')
param environment string

resource keyVault 'Microsoft.KeyVault/vaults@2023-02-01' = {
  name: keyVaultName
  location: location
  properties: {
    sku: {
      family: 'A'
      name: 'standard' // Standard tier — no HSM required
    }
    tenantId: subscription().tenantId
    enableRbacAuthorization: false // Using Vault Access Policy model
    enableSoftDelete: true
    softDeleteRetentionInDays: 90
    enabledForDeployment: false
    enabledForTemplateDeployment: false
    enabledForDiskEncryption: false
    accessPolicies: [
      {
        tenantId: subscription().tenantId
        objectId: functionAppPrincipalId
        permissions: {
          secrets: [
            'get'
            'set'
            'list'
          ]
        }
      }
    ]
  }
  tags: {
    project: 'xposter'
    environment: environment
    'do-not-delete': 'true'
  }
}

output keyVaultName string = keyVault.name
output keyVaultUri string = keyVault.properties.vaultUri
output keyVaultId string = keyVault.id
