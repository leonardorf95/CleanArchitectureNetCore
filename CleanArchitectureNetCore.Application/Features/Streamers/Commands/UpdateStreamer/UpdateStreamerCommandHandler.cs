using AutoMapper;
using CleanArchitectureNetCore.Application.Contracts.Persistence;
using CleanArchitectureNetCore.Application.Exceptions;
using CleanArchitectureNetCore.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitectureNetCore.Application.Features.Streamers.Commands.UpdateStreamer
{
  public class UpdateStreamerCommandHandler : IRequestHandler<UpdateStreamerCommand>
  {
    private readonly IStreamerRepository _streamerRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateStreamerCommandHandler> _logger;

    public UpdateStreamerCommandHandler(IStreamerRepository streamerRepository, IMapper mapper, ILogger<UpdateStreamerCommandHandler> logger)
    {
      _streamerRepository = streamerRepository;
      _mapper = mapper;
      _logger = logger;
    }

    public async Task<Unit> Handle(UpdateStreamerCommand request, CancellationToken cancellationToken)
    {
      var findStreamer = await _streamerRepository.GetByIdAsync(request.Id);

      if (findStreamer == null)
      {
        _logger.LogError($"No se encontro el streamer id {request.Id}");
        throw new NotFoundException(nameof(Streamer), request.Id);
      }

      findStreamer.Url = request.Url;
      findStreamer.Name = request.Name;

     var result =  await _streamerRepository.UpdateAsync(findStreamer);

      _logger.LogInformation($"La operación fue exitosa actualizando el streamer ${request.Id}");

      return Unit.Value;
    }
  }
}
