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

    //private readonly IStreamerRepository _streamerRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;
    private readonly ILogger<CreateStreamerCommandHandler> _logger;

    public CreateStreamerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService, ILogger<CreateStreamerCommandHandler> logger)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
      _emailService = emailService;
      _logger = logger;
    }

    public async Task<int> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
    {
      var streamerEntity = _mapper.Map<Streamer>(request);

      //var newStreamer = await _streamerRepository.AddAsync(streamerEntity);
      _unitOfWork.StreamerRepository.AddEntity(streamerEntity);
      var newStreamer = await _unitOfWork.Complete();

      if(newStreamer<= 0)
      {
        throw new Exception("Error al insertar stremaer");
      }

      string message = $"Se ha añadido un nuevo streamer ${streamerEntity.Id}";
      _logger.LogInformation(message);

      await SendEmail(streamerEntity, "luisfonseca9521@gmail.com");
      return streamerEntity.Id;
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
