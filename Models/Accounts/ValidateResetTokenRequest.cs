using System.ComponentModel.DataAnnotations;

namespace MIS_API.Models.Accounts
{
    public class ValidateResetTokenRequest
    {
        [Required]
        public string Token { get; set; }
    }
}