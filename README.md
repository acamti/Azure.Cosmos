# Azure.Cosmos.DependencyInjection
Add CosmosClient to your project.

## Usage
In your startup.cs file

```csharp
services.AddCosmosDb(
  Configuration["CosmosDb:Endpoint"], 
  Configuration["CosmosDb:Key"]
);
```
