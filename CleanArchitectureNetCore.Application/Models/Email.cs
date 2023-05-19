namespace CleanArchitectureNetCore.Application.Models
{
  public class Email
  {
    public List<string> To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
  }
}
