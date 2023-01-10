using System.ComponentModel.DataAnnotations;

namespace MIS_API.Models.Accounts
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}