// XPoster - Bicep parameters file for production
// Reference: https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/parameter-files

using './main.bicep'

param location = 'italynorth'
param environment = 'prod'
param storageAccountName = 'xposterdb'
param appServicePlanName = 'ItalyNorthPlan'
param functionAppName = 'XPosterFunction'
param appInsightsName = 'XInsights'
param keyVaultName = 'kv-xposter'
