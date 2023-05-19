using AutoMapper;
using CleanArchitectureNetCore.Application.Contracts.Persistence;
using CleanArchitectureNetCore.Application.Exception;
using CleanArchitectureNetCore.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitectureNetCore.Application.Features.Streamers.Commands.DeleteStreamer
{
  public class DeleteStreamerCommandHandler : IRequestHandler<DeleteStreamerCommand>
  {
    private readonly IStreamerRepository _streamerRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<DeleteStreamerCommandHandler> _logger;

    public DeleteStreamerCommandHandler(IStreamerRepository streamerRepository, IMapper mapper, ILogger<DeleteStreamerCommandHandler> logger)
    {
      _streamerRepository = streamerRepository;
      _mapper = mapper;
      _logger = logger;
    }

    public async Task<Unit> Handle(DeleteStreamerCommand request, CancellationToken cancellationToken)
    {
      var findStreamer = await _streamerRepository.GetByIdAsync(request.Id);

      if (findStreamer == null)
      {
        _logger.LogError($"No se encontro el streamer id {request.Id}");
        throw new NotFoundException(nameof(Streamer), request.Id);
      }

      await _streamerRepository.DeleteAsync(findStreamer);
      _logger.LogInformation($"La operación fue exitosa de eliminacion el streamer ${request.Id}");

      return Unit.Value;
    }
  }
}
