provider "azurerm" {
  version = "2.24.0"
}

variable "storage_account_name" {
    type = string
    default = "seanbeanbot"
}

variable "service_name" {
    type = string
    default = "seanbeanbot"
}

resource "azurerm_resource_group" "seanbeanbot" {
    name = service_name
    location = "Central Canada"
}

resource "azurerm_storage_account" "seanbeanbot"{
    name = storage_account_name
    resource_group_name = azurerm_resource_group.seanbeanbot.name
    location = azurerm_resource_group.seanbeanbot.location
    account_tier = "Standard"
    account_replication_type = "GRS"
}

resource "azurerm_linux_function" "seanbeanbot" {
}