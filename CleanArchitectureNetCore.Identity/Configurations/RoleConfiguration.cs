using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureNetCore.Identity.Configurations
{
  public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
  {
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
      builder.HasData(
          new IdentityRole
          {
            Id = "d35d0948-ec04-4eeb-8359-76db8b55cdb3",
            Name = "super admin",
            NormalizedName = "super admin"
          },
          new IdentityRole
          {
            Id = "a3f85b53-103c-4fda-bc15-32cd9edd4049",
            Name = "regular",
            NormalizedName = "regular"
          }
        );
    }
  }
}
