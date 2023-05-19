using CleanArchitectureNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureNetCore.Data.Context
{
  public class ApplicationDbContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      var connectionString = "Server=DESKTOP-2FTLAUM\\SQLEXPRESS;Database=test-architecture;User ID=sa;Password=Admin$01;TrustServerCertificate=True;";
      optionsBuilder.UseSqlServer(connectionString);
    }

    public DbSet<Streamer>? Streamers { get; set; }
    public DbSet<Video>? Videos { get; set; }
  }
}
