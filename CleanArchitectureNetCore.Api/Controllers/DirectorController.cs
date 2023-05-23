using CleanArchitectureNetCore.Application.Features.Directors.Commands.CreateDirector;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitectureNetCore.Api.Controllers
{
  [ApiController]
  [Route("/api/v1/[controller]")]
  public class DirectorController : ControllerBase
  {
    private readonly IMediator _mediator;

    public DirectorController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost(Name = "create-director")]
    [Authorize(Roles = "super admin")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> CreateDirector([FromBody] CreateDirectorCommand command)
    {
      var response = await _mediator.Send(command);

      return Ok(response);
    }
  }
}
