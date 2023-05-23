using MediatR;

namespace CleanArchitectureNetCore.Application.Features.Directors.Commands.CreateDirector
{
  public class CreateDirectorCommand : IRequest<int>
  {
    public string? Name { get; set; }
    public string? FirstName { get; set; }
  }
}
