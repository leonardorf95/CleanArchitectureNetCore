using CleanArchitectureNetCore.Application.Contracts.Infrastucture;
using CleanArchitectureNetCore.Application.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace CleanArchitectureNetCore.Infrastruture.Services
{
  public class EmailService : IEmailService
  {
    public EmailsSettings _emailSettings { get; }
    public ILogger<EmailService> _logger { get; }

    public EmailService(IOptions<EmailsSettings> emailSettings, ILogger<EmailService> logger)
    {
      _emailSettings = emailSettings.Value;
      _logger = logger;
    }

    public async Task<bool> SendEmailAsync(Email options)
    {
      var client = new SendGridClient(_emailSettings.Apikey);
      var subject = options.Subject;
      var to = new EmailAddress(options.To);
      var body = options.Body;

      var from = new EmailAddress
      {
        Email = _emailSettings.FromAddress,
        Name = _emailSettings.FromName
      };

      var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, body, body);
      var response = await client.SendEmailAsync(sendGridMessage);

      if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK)
        return true;

      _logger.LogError("El email no pudo enviars, existen errores");
      return false;
    }
  }
}
