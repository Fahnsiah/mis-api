using System.ComponentModel.DataAnnotations;

namespace MISAPI.DataModel.ViewModels
{
    public class ForgotPasswordRequest
    {
        [Required, EmailAddress, MaxLength(150)]
        public string Email { get; set; }
    }
}