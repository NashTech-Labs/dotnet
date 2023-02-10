Terraform: Azure Provisioning
========================================

Terraform code used to Create Azure Infra

## Usage

```hcl-terraform
resource "azurerm_linux_function_app" "example" {
  name                = "terraform2"
  location            = var.resource_group_location
  resource_group_name = azurerm_resource_group.example.name
  service_plan_id     = azurerm_service_plan.example.id

  storage_account_name       = azurerm_storage_account.example.name
  storage_account_access_key = azurerm_storage_account.example.primary_access_key

  site_config {
    application_stack {
     dotnet_version = "6.0"
    }
  }
```

## Inputs


## Azure Provider

| Name   | Description                               | Type        |
|--------|-------------------------------------------|-------------|
| name   | Name of the created Infra.           | version            |
| azurerm| provider "azurerm" { features {} }   | "=3.0.0"           |                    

## Changelog

* **1.0.0**
    * Release version 1.
