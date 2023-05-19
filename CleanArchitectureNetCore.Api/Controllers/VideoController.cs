using CleanArchitectureNetCore.Application.Dtos.Videos;
using CleanArchitectureNetCore.Application.Features.Videos.Queries.GetVideoList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitectureNetCore.Api.Controllers
{
  [ApiController]
  [Route("/api/v1/[controller]")]
  public class VideoController : ControllerBase
  {
    private readonly IMediator _mediator;

    public VideoController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet("{username}", Name = "get-video")]
    [ProducesResponseType(typeof(IEnumerable<VideosDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<VideosDto>>> GetVideosByUsername(string username)
    {
      var query = new GetVideosListQuery(username);
      var response = await _mediator.Send(query);

      return Ok(response);
    }
  }
}
