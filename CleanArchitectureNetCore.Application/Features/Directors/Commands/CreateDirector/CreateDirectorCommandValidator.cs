using FluentValidation;

namespace CleanArchitectureNetCore.Application.Features.Directors.Commands.CreateDirector
{
  public class CreateDirectorCommandValidator: AbstractValidator<CreateDirectorCommand>
  {
    public CreateDirectorCommandValidator()
    {
      RuleFor(s => s.Name)
        .NotEmpty().WithMessage("(Nombre) no puede estar en blanco")
        .MaximumLength(50).WithMessage("(Nombre) no puede exceder los 50 caracteres");
      RuleFor(s => s.FirstName)
        .NotEmpty().WithMessage("(Apellidos) no puede estar en blanco");
    }
  }
}
