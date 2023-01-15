using System.ComponentModel.DataAnnotations;

namespace MISAPI.DataModel.ViewModels.Accounts
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}