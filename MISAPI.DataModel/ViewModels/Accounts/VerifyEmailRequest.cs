using System.ComponentModel.DataAnnotations;

namespace MISAPI.DataModel.ViewModels.Accounts
{
    public class VerifyEmailRequest
    {
        [Required]
        public string Token { get; set; }
    }
}