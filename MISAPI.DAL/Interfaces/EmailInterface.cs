namespace MISAPI.DAL.Interfaces
{
    public interface IEmailInterface
    {
        void Send(string to, string subject, string html, string from = null);
    }
}