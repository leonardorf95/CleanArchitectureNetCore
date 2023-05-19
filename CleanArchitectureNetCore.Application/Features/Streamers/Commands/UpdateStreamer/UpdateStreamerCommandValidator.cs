using FluentValidation;

namespace CleanArchitectureNetCore.Application.Features.Streamers.Commands.UpdateStreamer
{
  public class UpdateStreamerCommandValidator : AbstractValidator<UpdateStreamerCommand>
  {
    public UpdateStreamerCommandValidator()
    {
      RuleFor(s => s.Name)
    .NotEmpty().WithMessage("(Nombre) no puede estar en blanco")
    .MaximumLength(50).WithMessage("(Nombre) no puede exceder los 50 caracteres");
      RuleFor(s => s.Url)
        .NotEmpty().WithMessage("(Url) no puede estar en blanco");
    }
  }
}
