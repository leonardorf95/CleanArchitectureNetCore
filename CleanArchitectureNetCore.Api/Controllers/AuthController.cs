using CleanArchitectureNetCore.Application.Contracts.Identity;
using CleanArchitectureNetCore.Application.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureNetCore.Api.Controllers
{
  [ApiController]
  [Route("/api/v1/[controller]")]
  public class AuthController : ControllerBase
  {
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
      _authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthRespose>> Login([FromBody] AuthRequest request)
    {
      return Ok(await _authService.Login(request));
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegistrationResponse>> Register([FromBody] RegistrationRequest request)
    {
      return Ok(await _authService.Register(request));
    }
  }
}
