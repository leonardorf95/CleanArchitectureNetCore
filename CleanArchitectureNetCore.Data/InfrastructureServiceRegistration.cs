using CleanArchitectureNetCore.Application.Contracts.Infrastucture;
using CleanArchitectureNetCore.Application.Contracts.Persistence;
using CleanArchitectureNetCore.Application.Models;
using CleanArchitectureNetCore.Infrastruture.Persistence.Context;
using CleanArchitectureNetCore.Infrastruture.Repositories;
using CleanArchitectureNetCore.Infrastruture.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureNetCore.Infrastruture
{
  public static class InfrastructureServiceRegistration
  {
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

      services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
      services.AddScoped<IUnitOfWork, UnitOfWork>();
      services.AddScoped(typeof(IVideoRepository), typeof(VideoRepository));
      services.AddScoped(typeof(IStreamerRepository), typeof(StreamerRepository));

      services.Configure<EmailsSettings>(options => configuration.GetSection("EmailSettings"));
      services.AddTransient(typeof(IEmailService), typeof(EmailService));

      return services;
    }
  }
}
