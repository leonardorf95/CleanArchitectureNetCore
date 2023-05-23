using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitectureNetCore.Domain.Entities
{
  public class Actor
  {
    public string? Name { get; set; }
    public string? FirstName { get; set; }
    /// <summary>
    /// Evita que se agregue a la migracion
    /// </summary>
    [NotMapped]
    public string? FullName => $"{Name} {FirstName}";
    public virtual ICollection<Video> Videos { get; set; }
    public virtual ICollection<VideoActor> VideosActors { get; set; }
  }
}
