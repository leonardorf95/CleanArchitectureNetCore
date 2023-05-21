using CleanArchitectureNetCore.Application.Features.Streamers.Commands.CreateStreamer;
using CleanArchitectureNetCore.Application.Features.Streamers.Commands.DeleteStreamer;
using CleanArchitectureNetCore.Application.Features.Streamers.Commands.UpdateStreamer;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitectureNetCore.Api.Controllers
{
  [ApiController]
  [Route("/api/v1/[controller]")]
  public class StreamerController : ControllerBase
  {
    private readonly IMediator _mediator;

    public StreamerController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost(Name = "create-streamer")]
    [Authorize(Roles = "super admin")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> CreateStreamer([FromBody] CreateStreamerCommand command)
    {
      var response = await _mediator.Send(command);

      return Ok(response);
    }

    [HttpPut(Name = "update-streamer")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateStreamer([FromBody] UpdateStreamerCommand command)
    {
      await _mediator.Send(command);

      return NoContent();
    }

    [HttpDelete("{id}", Name = "remove-streamer")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteStreamer(int id)
    {
      var command = new DeleteStreamerCommand { Id = id };
      await _mediator.Send(command);

      return NoContent();
    }
  }
}
