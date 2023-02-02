using System.ComponentModel.DataAnnotations;

namespace MISAPI.DataModel.ViewModels
{
    public class ResetPasswordRequest
    {
        [Required, MaxLength(1500)]
        public string Token { get; set; }

        [Required, MinLength(6), MaxLength(150)]
        public string Password { get; set; }

        [Required, Compare("Password"), MaxLength(150)]
        public string ConfirmPassword { get; set; }
    }
}