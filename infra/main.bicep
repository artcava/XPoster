// XPoster - Main Bicep entry point
// Deploys the full Azure infrastructure for XPoster
// Usage: az deployment group create --resource-group rg-xposter --template-file infra/main.bicep --parameters infra/main.bicepparam

targetScope = 'resourceGroup'

@description('Azure region for all resources')
param location string = 'italynorth'

@description('Environment tag (e.g. prod, staging)')
param environment string = 'prod'

@description('Storage account name (must be globally unique, 3-24 lowercase alphanumeric)')
param storageAccountName string = 'xposterdb'

@description('App Service Plan name')
param appServicePlanName string = 'ItalyNorthPlan'

@description('Function App name')
param functionAppName string = 'XPosterFunction'

@description('Application Insights name')
param appInsightsName string = 'XInsights'

@description('Key Vault name')
param keyVaultName string = 'kv-xposter'

// ============================================================
// MODULES
// ============================================================

module storage 'modules/storage.bicep' = {
  name: 'storage'
  params: {
    location: location
    storageAccountName: storageAccountName
    environment: environment
  }
}

module monitoring 'modules/monitoring.bicep' = {
  name: 'monitoring'
  params: {
    location: location
    appInsightsName: appInsightsName
    environment: environment
  }
}

module functionApp 'modules/function-app.bicep' = {
  name: 'functionApp'
  params: {
    location: location
    appServicePlanName: appServicePlanName
    functionAppName: functionAppName
    storageAccountName: storageAccountName
    appInsightsConnectionString: monitoring.outputs.connectionString
    keyVaultUri: keyVault.outputs.keyVaultUri
    environment: environment
  }
  dependsOn: [ storage, monitoring ]
}

module keyVault 'modules/key-vault.bicep' = {
  name: 'keyVault'
  params: {
    location: location
    keyVaultName: keyVaultName
    functionAppPrincipalId: functionApp.outputs.principalId
    environment: environment
  }
  dependsOn: [ functionApp ]
}

// ============================================================
// OUTPUTS
// ============================================================

output functionAppName string = functionApp.outputs.functionAppName
output keyVaultUri string = keyVault.outputs.keyVaultUri
output appInsightsConnectionString string = monitoring.outputs.connectionString
