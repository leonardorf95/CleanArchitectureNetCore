using CleanArchitectureNetCore.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureNetCore.Identity.Configurations
{
  public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
  {
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
      var hasher = new PasswordHasher<ApplicationUser>();

      builder.HasData(
        new ApplicationUser
        {
          Id = "1f83b7ea-3a74-4511-8ea0-3afa5a7a4fc2",
          Name = "Leonardo",
          FirstName = "Rangel",
          LastName = "Fonseca",
          Email = "luisfonseca9521+admin@gmail.com",
          NormalizedEmail = "luisfonseca9521+admin@gmail.com",
          UserName = "luisfonseca9521+admin@gmail.com",
          NormalizedUserName = "luisfonseca9521+admin@gmail.com",
          PasswordHash = hasher.HashPassword(null, "12345678"),
          EmailConfirmed = true
        },
        new ApplicationUser
        {
          Id = "5f20deee-ae2e-4781-ad2f-63051d691feb",
          Name = "Leonardo",
          FirstName = "Rangel",
          LastName = "Fonseca",
          Email = "luisfonseca9521+regular@gmail.com",
          NormalizedEmail = "luisfonseca9521+regular@gmail.com",
          UserName = "luisfonseca9521+regular@gmail.com",
          NormalizedUserName = "luisfonseca9521+regular@gmail.com",
          PasswordHash = hasher.HashPassword(null, "12345678"),
          EmailConfirmed = true
        }
        );
    }
  }
}
