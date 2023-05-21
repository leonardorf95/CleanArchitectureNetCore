using CleanArchitectureNetCore.Identity.Configurations;
using CleanArchitectureNetCore.Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureNetCore.Identity.Context
{
  public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser>
  {
    public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.ApplyConfiguration(new RoleConfiguration());
      builder.ApplyConfiguration(new UserConfiguration());
      builder.ApplyConfiguration(new UserRoleConfiguration());
    }
  }
}
