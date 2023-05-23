using CleanArchitectureNetCore.Domain.Common;

namespace CleanArchitectureNetCore.Domain.Entities
{
  public class Director : BaseDomainModel
  {
    public string? Name { get; set; }
    public string? FirstName { get; set; }
  }
}
