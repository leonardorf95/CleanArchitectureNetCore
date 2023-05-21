using CleanArchitectureNetCore.Application.Contracts.Persistence;
using CleanArchitectureNetCore.Domain.Entities;
using CleanArchitectureNetCore.Infrastruture.Persistence.Context;

namespace CleanArchitectureNetCore.Infrastruture.Repositories
{
  public class StreamerRepository : RepositoryBase<Streamer>, IStreamerRepository
  {
    public StreamerRepository(ApplicationDbContext context) : base(context) { }
  }
}
