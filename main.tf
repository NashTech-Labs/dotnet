resource "azurerm_resource_group" "example" {
  name     = "terraform-POC"
  location = var.resource_group_location
}

resource "azurerm_storage_account" "example" {
  name                     = "terrafrom1"
  resource_group_name      = azurerm_resource_group.example.name
  location                 = var.resource_group_location
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

resource "azurerm_service_plan" "example" {
  name                = "terraform_service_plan"
  location            = var.resource_group_location
  resource_group_name = azurerm_resource_group.example.name
  os_type             = "Linux"
  sku_name            = "S1"
}

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
}

resource "azurerm_function_app_function" "example" {
  name            = "terraform"
  function_app_id = azurerm_linux_function_app.example.id
  language        = "CSharp"
  test_data = jsonencode({
    "name" = "Azure"
  })
  config_json = jsonencode({
    "bindings" = [
      {
        "authLevel" = "function"
        "direction" = "in"
        "methods" = [
          "get",
          "post",
        ]
        "name" = "req"
        "type" = "httpTrigger"
      },
      {
        "direction" = "out"
        "name"      = "$return"
        "type"      = "http"
      },
    ]
  })
}