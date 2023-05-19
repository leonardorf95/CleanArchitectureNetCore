using AutoMapper;
using CleanArchitectureNetCore.Application.Contracts.Persistence;
using CleanArchitectureNetCore.Application.Dtos.Videos;
using MediatR;

namespace CleanArchitectureNetCore.Application.Features.Videos.Queries.GetVideoList
{
  public class GetVideosListHandler : IRequestHandler<GetVideosListQuery, List<VideosDto>>
  {
    public readonly IVideoRepository _videoRepository;
    public readonly IMapper _mapper;

    public GetVideosListHandler(IVideoRepository videoRepository, IMapper mapper)
    {
      _videoRepository = videoRepository;
      _mapper = mapper;
    }

    public async Task<List<VideosDto>> Handle(GetVideosListQuery request, CancellationToken cancellationToken)
    {
      var videosResult = await _videoRepository.GetVideoByUsername(request._UserName);

      return _mapper.Map<List<VideosDto>>(videosResult);
    }
  }
}

