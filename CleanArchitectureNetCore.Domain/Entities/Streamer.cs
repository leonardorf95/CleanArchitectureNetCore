using CleanArchitectureNetCore.Domain.Common;

namespace CleanArchitectureNetCore.Domain.Entities
{
  public class Streamer : BaseDomainModel
  {
    public string? Name { get; set; }
    public string? Url { get; set; }
  }
}
