using System.Threading.Tasks;

using Rifoms.Domain.Infrastructure.Helper;

namespace Rifoms.Domain.Infrastructure.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
