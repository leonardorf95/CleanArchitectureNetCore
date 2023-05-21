using CleanArchitectureNetCore.Domain.Common;
using CleanArchitectureNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureNetCore.Infrastruture.Persistence.Context
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //  optionsBuilder.UseSqlServer(connectionString);
    //}

    public DbSet<Streamer>? Streamers { get; set; }
    public DbSet<Video>? Videos { get; set; }

    public override int SaveChanges()
    {
      SetTimesStamps();
      return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
      SetTimesStamps();
      return await base.SaveChangesAsync(cancellationToken);
    }

    private void SetTimesStamps()
    {
      var entities = ChangeTracker.Entries()
          .Where(x => x.Entity is BaseDomainModel &&
            (x.State == EntityState.Added ||
              x.State == EntityState.Modified ||
              x.State == EntityState.Deleted));

      foreach (var entity in entities)
      {
        var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time (Mexico)"));

        switch (entity.State)
        {
          case EntityState.Added:
            ((BaseDomainModel)entity.Entity).CreatedAt = now;
            ((BaseDomainModel)entity.Entity).UpdatedAt = now;
            break;
          case EntityState.Modified:
            ((BaseDomainModel)entity.Entity).UpdatedAt = now;
            break;
          case EntityState.Deleted:
            ((BaseDomainModel)entity.Entity).DeletedAt = now;
            break;
        }
      }
    }
  }
}
