using System.ComponentModel.DataAnnotations;

namespace MISAPI.DataModel.ViewModels.Accounts
{
    public class ValidateResetTokenRequest
    {
        [Required]
        public string Token { get; set; }
    }
}