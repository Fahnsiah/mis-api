using System.ComponentModel.DataAnnotations;

namespace MIS_API.Models.Accounts
{
    public class VerifyEmailRequest
    {
        [Required]
        public string Token { get; set; }
    }
}