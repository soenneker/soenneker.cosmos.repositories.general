using Soenneker.Cosmos.Repositories.Shared.Abstract;

namespace Soenneker.Cosmos.Repositories.General.Abstract;

/// <summary>
/// Defines repository operations for one typed-document discriminator in the shared <c>general</c> Cosmos container.
/// </summary>
/// <typeparam name="TDocument">The document type exposed by the repository.</typeparam>
public interface IGeneralRepository<TDocument> : ISharedRepository<TDocument> where TDocument : class
{
}
