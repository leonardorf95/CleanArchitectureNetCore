using CleanArchitectureNetCore.Domain.Common;

namespace CleanArchitectureNetCore.Application.Contracts.Persistence
{
  public interface IUnitOfWork : IDisposable
  {
    /// <summary>
    /// Método generico que instancia cualquier entidad de la base de datos y que a su vez puede realizar las operaciones basicas CRUD
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns></returns>
    IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;

    /// <summary>
    /// Método generico que ejecuta la transacción y genera el registro en la base de datos
    /// </summary>
    /// <returns></returns>
    Task<int> Complete();

    /// <summary>
    /// Instancia personalida para implementar los repositorios personalidos
    /// </summary>
    IStreamerRepository StreamerRepository {  get; }

    IVideoRepository VideoRepository { get; }
  }
}
