using CleanArchitectureNetCore.Domain.Entities;

namespace CleanArchitectureNetCore.Application.Contracts.Persistence
{
  public interface IStreamerRepository : IAsyncRepository<Streamer>
  {
  }
}
