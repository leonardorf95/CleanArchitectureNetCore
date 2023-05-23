using CleanArchitectureNetCore.Application.Contracts.Persistence;
using CleanArchitectureNetCore.Domain.Common;
using CleanArchitectureNetCore.Infrastruture.Persistence.Context;
using System.Collections;

namespace CleanArchitectureNetCore.Infrastruture.Repositories
{
  public class UnitOfWork : IUnitOfWork
  {
    private Hashtable _repositories;
    private readonly ApplicationDbContext _context;

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
        var repositoryType = typeof(IAsyncRepository<>);
        var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
        _repositories.Add(type, repositoryInstance);
      }

      return (IAsyncRepository<TEntity>)_repositories[type];
    }
  }
}
