using Application.Models.Infrastructure;

namespace Application.Persistence.Infrastructure;

public interface IEmailSender
{
    Task<bool> SendEmailAsync(Email email);
}