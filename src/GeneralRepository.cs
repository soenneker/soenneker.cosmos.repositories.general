using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Soenneker.Cosmos.Container.Abstract;
using Soenneker.Cosmos.Repositories.General.Abstract;
using Soenneker.Cosmos.Repositories.Shared;
using Soenneker.Documents.Typed;
using Soenneker.Utils.BackgroundQueue.Abstract;
using Soenneker.Utils.MemoryStream.Abstract;
using Soenneker.Utils.UserContext.Abstract;

namespace Soenneker.Cosmos.Repositories.General;

///<inheritdoc cref="IGeneralRepository{TDocument}"/>
public abstract class GeneralRepository<TDocument> : SharedRepository<TDocument>, IGeneralRepository<TDocument> where TDocument : TypedDocument
{
    public override string ContainerName => "general";

    protected GeneralRepository(ICosmosContainerUtil cosmosContainerUtil, IConfiguration config, ILogger<GeneralRepository<TDocument>> logger,
        IUserContext userContext, IBackgroundQueue backgroundQueue, IMemoryStreamUtil memoryStreamUtil) : base(cosmosContainerUtil, config, logger, userContext,
        backgroundQueue, memoryStreamUtil)
    {
    }
}