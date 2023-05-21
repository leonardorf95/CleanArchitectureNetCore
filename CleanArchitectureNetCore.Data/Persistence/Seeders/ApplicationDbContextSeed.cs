using CleanArchitectureNetCore.Domain.Entities;
using CleanArchitectureNetCore.Infrastruture.Persistence.Context;
using Microsoft.Extensions.Logging;

namespace CleanArchitectureNetCore.Infrastruture.Persistence.Seeders
{
  public class ApplicationDbContextSeed
  {
    public static async Task SeedAsync(ApplicationDbContext context, ILogger<ApplicationDbContextSeed> logger)
    {
      if (!context.Streamers!.Any())
      {
        context.Streamers!.AddRange(GetPreconfigureStreamer());
        await context.SaveChangesAsync();
        logger.LogInformation("Se agregaron datos de configuracions {context}", typeof(ApplicationDbContext).Name);
      }
    }

    private static IEnumerable<Streamer> GetPreconfigureStreamer()
    {
      return new List<Streamer>
      {
        new Streamer
        {
          Name = "Jkanime",
          Url = "jkanime.net"
        },
        new Streamer
        {
          Name = "Netflix",
          Url = "netflix.com"
        },
        new Streamer
        {
          Name = "animeFLV",
          Url = "animeflv.net"
        }
      };
    }
  }
}
