namespace CleanArchitectureNetCore.Domain.Entities
{
  public class VideoActor
  {
    public int VideoId { get; set; } 
    public virtual Video? Video { get; set; }
    public int ActorId { get; set; }
    public virtual Actor? Actor { get; set; }  
  }
}
