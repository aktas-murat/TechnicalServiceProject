using TechnicalService.Core.Models.Email;

namespace TechnicalService.Core.Services.Email;

public interface IEmailService
{
    Task SendMailAsync(MailModel model);
}