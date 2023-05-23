using CleanArchitectureNetCore.Domain.Common;

namespace CleanArchitectureNetCore.Domain.Entities
{
  public class Video : BaseDomainModel
  {
    public int StreamerId { get; set; }
    public virtual Streamer? Streamer { get; set; }
    public string? Name { get; set; }
    public string? Url { get; set; }
    public int VideoId { get; set; }
    public virtual Director? Director { get; set; }
    public virtual ICollection<Actor>? Actors { get; set; }
    public virtual ICollection<VideoActor>? VideoActors { get; set; }
  }
}
