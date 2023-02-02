using System.ComponentModel.DataAnnotations;

namespace MISAPI.DataModel.ViewModels
{
    public class ValidateResetTokenRequest
    {
        [Required, MaxLength(1500)]
        public string Token { get; set; }
    }
}