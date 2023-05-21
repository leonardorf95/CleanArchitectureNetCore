using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureNetCore.Identity.Configurations
{
  public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
  {
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
      builder.HasData(
        new IdentityUserRole<string>
        {
          RoleId = "d35d0948-ec04-4eeb-8359-76db8b55cdb3",
          UserId = "1f83b7ea-3a74-4511-8ea0-3afa5a7a4fc2"
        },
        new IdentityUserRole<string>
        {
          RoleId = "a3f85b53-103c-4fda-bc15-32cd9edd4049",
          UserId = "5f20deee-ae2e-4781-ad2f-63051d691feb"
        }
        );
    }
  }
}
