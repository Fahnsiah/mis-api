using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using MIS_API.Helpers;
using MIS_API.Interface;

namespace MIS_API.Services
{
   

    public class EmailService : IEmailInterface
    {
        private readonly AppSettings _appSettings;

        public EmailService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public void Send(string to, string subject, string html, string from = null)
        {
            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from ?? _appSettings.EmailFrom));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            // send email
            ////using var smtp = new SmtpClient();
            ////smtp.Connect(_appSettings.SmtpHost, _appSettings.SmtpPort, SecureSocketOptions.StartTls);
            ////smtp.Authenticate(_appSettings.SmtpUser, _appSettings.SmtpPass);
            ////smtp.Send(email);
            ////smtp.Disconnect(true);
        }
    }
}