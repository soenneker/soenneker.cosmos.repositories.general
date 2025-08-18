using Soenneker.Cosmos.Repositories.Shared.Abstract;

namespace Soenneker.Cosmos.Repositories.General.Abstract;

/// <summary>
/// A data persistence abstraction layer for Cosmos DB General type documents
/// </summary>
/// <typeparam name="TDocument"></typeparam>
public interface IGeneralRepository<TDocument> : ISharedRepository<TDocument> where TDocument : class
{
}