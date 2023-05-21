using CleanArchitectureNetCore.Application.Models.Identity;

namespace CleanArchitectureNetCore.Application.Contracts.Identity
{
  public interface IAuthService
  {
    Task<AuthRespose> Login(AuthRequest request);
    Task<RegistrationResponse> Register(RegistrationRequest request);
  }
}
