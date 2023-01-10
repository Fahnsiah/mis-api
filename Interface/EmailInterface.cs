using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using MIS_API.Helpers;

namespace MIS_API.Interface
{
    public interface IEmailInterface
    {
        void Send(string to, string subject, string html, string from = null);
    }
}