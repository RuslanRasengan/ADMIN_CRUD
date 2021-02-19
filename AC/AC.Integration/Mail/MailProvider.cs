using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AC.Integration.Mail
{
    public class MailProvider : IMailProvider
    {
        private readonly NetworkCredential _credentials;

        private readonly string _fromEmail;

        public MailProvider(string email, string password)
        {
            _credentials = new NetworkCredential(email, password);
            _fromEmail = email;
        }

        public async Task SendTextAsync(string subject, string body, string email)
            => await SendAsync(subject, body, false, email);

        public async Task SendHtmlAsync(string subject, string body, string email)
            => await SendAsync(subject, body, true, email);

        private async Task SendAsync(string subject, string body, bool isHtml, string email)
        {
            var from = new MailAddress(_fromEmail);
            var to = new MailAddress(email);

            using (MailMessage mailMessage = new MailMessage(from, to))
            {
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = isHtml;

                using (SmtpClient sc = new SmtpClient(MailConstants.Host, MailConstants.Port))
                {
                    sc.EnableSsl = true;
                    sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                    sc.UseDefaultCredentials = true;
                    sc.Credentials = _credentials;

                    await sc.SendMailAsync(mailMessage);
                }
            }
        }
    }
}
