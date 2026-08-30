[![](https://img.shields.io/nuget/v/soenneker.cosmos.repositories.general.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.cosmos.repositories.general/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.cosmos.repositories.general/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.cosmos.repositories.general/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.cosmos.repositories.general.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.cosmos.repositories.general/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.cosmos.repositories.general/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.cosmos.repositories.general/actions/workflows/codeql.yml)

# Soenneker.Cosmos.Repositories.General

An abstract Cosmos repository base for multiple typed-document models stored in the shared `general` container.

## Installation

```bash
dotnet add package Soenneker.Cosmos.Repositories.General
```

## Define a repository

The package does not register a concrete service. Derive from `GeneralRepository<TDocument>`, where the document extends `TypedDocument`, and provide the discriminator stored in its `EntityType` property.

```csharp
public interface IWidgetRepository : IGeneralRepository<WidgetDocument>
{
}

public sealed class WidgetRepository : GeneralRepository<WidgetDocument>, IWidgetRepository
{
    protected override string EntityType => "widget";

    public WidgetRepository(
        ICosmosContainerUtil containerUtil,
        IConfiguration configuration,
        ILogger<GeneralRepository<WidgetDocument>> logger,
        IUserContext userContext,
        IBackgroundQueue backgroundQueue,
        IMemoryStreamUtil memoryStreamUtil)
        : base(containerUtil, configuration, logger, userContext, backgroundQueue, memoryStreamUtil)
    {
    }
}
```

Register your implementation as scoped because the repository consumes scoped user context:

```csharp
services.AddScoped<IWidgetRepository, WidgetRepository>();
```

The Cosmos container, user context, background queue, memory-stream utility, configuration, and logging dependencies must also be registered. This package deliberately does not choose their lifetimes for the application.

## Behavior

All derived repositories use the `general` container. `GetAll`, `GetAllIds`, `DeleteAll`, `DeleteAllPaged`, and `DeleteAllPagedParallel` limit their work to documents whose `EntityType` equals the derived repository's discriminator. The rest of the inherited `ICosmosRepository<TDocument>` API provides point reads, queries, writes, conditional ETag operations, paging, and audit support.

Documents must use the partition-key shape expected by `Soenneker.Cosmos.Repository` and the configured container. Choose stable, unique `EntityType` values; two repository types using the same value operate on the same documents.

Delete-all operations are permanent and are not transactional across the full result set. Failures and cancellation propagate after any already completed deletes.
