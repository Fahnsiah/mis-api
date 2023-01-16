using System.ComponentModel.DataAnnotations;

namespace MISAPI.DataModel.ViewModels.Accounts
{
    public class AuthenticateRequest
    {
        [Required, EmailAddress, MaxLength(150)]
        public string Email { get; set; }

        [Required, MaxLength(150)]
        public string Password { get; set; }
    }
}