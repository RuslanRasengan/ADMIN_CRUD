using System.Threading.Tasks;

namespace AC.Integration.Mail
{
    public interface IMailProvider
    {
        Task SendTextAsync(string subject, string body, string email);
        Task SendHtmlAsync(string subject, string body, string email);
    }
}
