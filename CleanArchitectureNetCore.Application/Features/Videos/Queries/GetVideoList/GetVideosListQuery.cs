using CleanArchitectureNetCore.Application.Dtos.Videos;
using MediatR;

namespace CleanArchitectureNetCore.Application.Features.Videos.Queries.GetVideoList
{
  public class GetVideosListQuery : IRequest<List<VideosDto>>
  {
    public string _UserName { get; set; } = string.Empty;

    public GetVideosListQuery(string? userName) => _UserName = userName ?? throw new ArgumentNullException(nameof(userName));
  }
}
