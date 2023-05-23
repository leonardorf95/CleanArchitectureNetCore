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
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateStreamerCommandHandler> _logger;

    public UpdateStreamerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateStreamerCommandHandler> logger)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
      _logger = logger;
    }

    public async Task<Unit> Handle(UpdateStreamerCommand request, CancellationToken cancellationToken)
    {
      //var findStreamer = await _streamerRepository.GetByIdAsync(request.Id);
      var streamerToUpdate = await _unitOfWork.StreamerRepository.GetByIdAsync(request.Id);

      if (streamerToUpdate == null)
      {
        _logger.LogError($"No se encontro el streamer id {request.Id}");
        throw new NotFoundException(nameof(Streamer), request.Id);
      }

      _mapper.Map(request, streamerToUpdate, typeof(UpdateStreamerCommand), typeof(Streamer));

      _unitOfWork.StreamerRepository.UpdateEntity(streamerToUpdate);

      var result = await _unitOfWork.Complete();

      _logger.LogInformation($"La operación fue exitosa actualizando el streamer ${request.Id}");

      return Unit.Value;
    }
  }
}
