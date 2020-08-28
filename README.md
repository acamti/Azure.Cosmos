# Acamti.Azure.Cosmos
Add CosmosProxy to your project.

[![Build Status](https://dev.azure.com/acamti/OpenSource/_apis/build/status/Nugets/Nuget-Azure.Cosmos?branchName=master)](https://dev.azure.com/acamti/OpenSource/_build/latest?definitionId=1&branchName=master)

`Azure.Cosmos` [![NuGet](https://img.shields.io/nuget/v/Acamti.Azure.Cosmos.svg)](https://nuget.org/packages/Acamti.Azure.Cosmos) [![Nuget](https://img.shields.io/nuget/dt/Acamti.Azure.Cosmos.svg)](https://nuget.org/packages/Acamti.Azure.Cosmos)


## Usage

In your AppSettings.json file
```json
"CosmosDb:ConnectionString":
      "AccountEndpoint=https://...",```

In your startup.cs file
```csharp
.AddCosmosProxy((settings, configuration) => 
    { 
        configuration.GetSection("CosmosDb").Bind(settings); 
    },
    new CosmosClientOptions { ApplicationName = "Your Application Name" }
);
```
