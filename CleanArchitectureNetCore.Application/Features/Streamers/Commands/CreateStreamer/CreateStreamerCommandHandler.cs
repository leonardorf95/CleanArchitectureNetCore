using AutoMapper;
using CleanArchitectureNetCore.Application.Contracts.Infrastucture;
using CleanArchitectureNetCore.Application.Contracts.Persistence;
using CleanArchitectureNetCore.Application.Exceptions;
using CleanArchitectureNetCore.Application.Models;
using CleanArchitectureNetCore.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitectureNetCore.Application.Features.Streamers.Commands.CreateStreamer
{
  public class CreateStreamerCommandHandler : IRequestHandler<CreateStreamerCommand, int>
  {
    private readonly IStreamerRepository _streamerRepository;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;
    private readonly ILogger<CreateStreamerCommandHandler> _logger;

    public CreateStreamerCommandHandler(IStreamerRepository streamerRepository, IMapper mapper, IEmailService emailService, ILogger<CreateStreamerCommandHandler> logger)
    {
      _streamerRepository = streamerRepository;
      _mapper = mapper;
      _emailService = emailService;
      _logger = logger;
    }

    public async Task<int> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
    {
      var streamerEntity = _mapper.Map<Streamer>(request);

      var newStreamer = await _streamerRepository.AddAsync(streamerEntity);

      string message = $"Se ha añadido un nuevo streamer ${newStreamer.Id}";
      _logger.LogInformation(message);

      await SendEmail(newStreamer, "luisfonseca9521@gmail.com");
      return newStreamer.Id;
    }

    private async Task SendEmail(Streamer streamer, string emails)
    {
      var email = new Email
      {
        To = emails,
        Body = "La compañia streamer se agrego correctamente",
        Subject = "Nueva compañia"
      };

      try
      {
        await _emailService.SendEmailAsync(email);
      }
      catch (ValidationException ex)
      {
        string message = $"No se pudo enviar el correo exitosamente -> ${ex.Message}";
        _logger.LogError(message);
      }
    }
  }
}
