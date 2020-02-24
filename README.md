# Azure.Cosmos.DependencyInjection
Add CosmosClient to your project.

[![Build Status](https://dev.azure.com/acamti/OpenSource/_apis/build/status/Nugets/Nuget-Azure.Cosmos.DependencyInjection?branchName=master)](https://dev.azure.com/acamti/OpenSource/_build/latest?definitionId=1&branchName=master)

`Azure.Cosmos.DependencyInjection` [![NuGet](https://img.shields.io/nuget/v/Acamti.Azure.Cosmos.DependencyInjection.svg)](https://nuget.org/packages/Acamti.Azure.Cosmos.DependencyInjection) [![Nuget](https://img.shields.io/nuget/dt/Acamti.Azure.Cosmos.DependencyInjection.svg)](https://nuget.org/packages/Acamti.Azure.Cosmos.DependencyInjection)


## Usage
In your startup.cs file

```csharp
services.AddCosmosDb(
  Configuration["CosmosDb:Endpoint"], 
  Configuration["CosmosDb:Key"]
);
```
