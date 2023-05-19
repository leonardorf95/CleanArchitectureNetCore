using CleanArchitectureNetCore.Domain.Common;

namespace CleanArchitectureNetCore.Domain.Entities
{
  public class Video : BaseDomainModel
  {
    public int StreamerId { get; set; }
    public virtual Streamer? Streamer { get; set; }
    public string? Name { get; set; }
    public string? Url { get; set; }
  }
}
