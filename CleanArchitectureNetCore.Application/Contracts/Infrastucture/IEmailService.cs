using CleanArchitectureNetCore.Application.Models;

namespace CleanArchitectureNetCore.Application.Contracts.Infrastucture
{
  public interface IEmailService
  {
    Task<bool> SendEmailAsync(Email options);
  }
}
