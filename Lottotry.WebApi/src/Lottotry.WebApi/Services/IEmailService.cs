using System.Threading.Tasks;

namespace Lottotry.WebApi.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body);
    }
}
