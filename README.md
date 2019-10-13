# Azure.Cosmos.DependencyInjection
Add CosmosClient to your project.

## Usage
```csharp
services.AddCosmosDb(
  Configuration["CosmosDb:Endpoint"], 
  Configuration["CosmosDb:Key"]
);
```
