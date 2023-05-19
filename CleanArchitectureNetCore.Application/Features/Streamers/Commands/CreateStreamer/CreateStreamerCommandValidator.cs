using FluentValidation;

namespace CleanArchitectureNetCore.Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandValidator : AbstractValidator<CreateStreamerCommand>
    {
        public CreateStreamerCommandValidator()
        {
            RuleFor(s => s.Name)
              .NotEmpty().WithMessage("(Nombre) no puede estar en blanco")
              .MaximumLength(50).WithMessage("(Nombre) no puede exceder los 50 caracteres");
            RuleFor(s => s.Url)
              .NotEmpty().WithMessage("(Url) no puede estar en blanco");
        }
    }
}
