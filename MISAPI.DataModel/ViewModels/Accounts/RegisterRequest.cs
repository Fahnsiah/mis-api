using System.ComponentModel.DataAnnotations;

namespace MISAPI.DataModel.ViewModels.Accounts
{
    public class RegisterRequest
    {
        [Required]
        public int RoleId { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [MinLength(6)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Range(typeof(bool), "true", "true")]
        public bool AcceptTerms { get; set; }
    }
}