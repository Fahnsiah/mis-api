using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace MISAPI.DAL.Interfaces
{
    public interface IEmailInterface
    {
        void Send(string to, string subject, string html, string from = null);
    }
}