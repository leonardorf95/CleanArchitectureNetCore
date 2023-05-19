using CleanArchitectureNetCore.Domain.Entities;

namespace CleanArchitectureNetCore.Application.Contracts.Persistence
{
  public interface IVideoRepository : IAsyncRepository<Video>
  {
    Task<Video> GetVideoByName(string name);
    Task<IEnumerable<Video>> GetVideoByUsername(string username);
  }
}
