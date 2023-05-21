using Microsoft.AspNetCore.Identity;

namespace CleanArchitectureNetCore.Identity.Entities
{
  public class ApplicationUser : IdentityUser
  {
    public string Name { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
  }
}
