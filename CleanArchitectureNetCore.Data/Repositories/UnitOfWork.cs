using CleanArchitectureNetCore.Application.Contracts.Persistence;
using CleanArchitectureNetCore.Domain.Common;
using CleanArchitectureNetCore.Infrastruture.Persistence.Context;
using System.Collections;

namespace CleanArchitectureNetCore.Infrastruture.Repositories
{
  public class UnitOfWork : IUnitOfWork
  {
    /// <summary>
    /// Creat una tabla temporal con la instancia de la entidad generada
    /// </summary>
    private Hashtable _repositories;

    /// <summary>
    /// DbContext de la conexion de la base de datos
    /// </summary>
    private readonly ApplicationDbContext _context;

    private IVideoRepository _videoRepository;
    private IStreamerRepository _streamerRepository;

    /// <summary>
    /// Implementación de unit of work para repositorios personalizados
    /// </summary>
    public IVideoRepository VideoRepository => _videoRepository ??= new VideoRepository(_context);
    public IStreamerRepository StreamerRepository => _streamerRepository ??= new StreamerRepository(_context);

    public UnitOfWork(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<int> Complete()
    {
      return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
      _context.Dispose();
    }

    public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
    {
      if (_repositories == null)
      {
        _repositories = new Hashtable();
      }

      var type = typeof(TEntity).Name;

      if (!_repositories.ContainsKey(type))
      {
        var repositoryType = typeof(RepositoryBase<>);
        var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
        _repositories.Add(type, repositoryInstance);
      }

      return (IAsyncRepository<TEntity>)_repositories[type];
    }
  }
}
