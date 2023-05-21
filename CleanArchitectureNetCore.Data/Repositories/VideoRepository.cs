using CleanArchitectureNetCore.Application.Contracts.Persistence;
using CleanArchitectureNetCore.Domain.Entities;
using CleanArchitectureNetCore.Infrastruture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureNetCore.Infrastruture.Repositories
{
  public class VideoRepository : RepositoryBase<Video>, IVideoRepository
  {
    public VideoRepository(ApplicationDbContext context) : base(context) { }

    public async Task<Video> GetVideoByName(string name)
    {
      return await _context.Videos!.Where(v => v.Name == name).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<Video>> GetVideoByUsername(string username)
    {
      return await _context.Videos!.Where(v => v.Name == username).ToListAsync();
    }
  }
}
