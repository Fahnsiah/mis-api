using System.ComponentModel.DataAnnotations;


namespace MISAPI.DataModel.ViewModels
{
    public class CreateRequest
    {
      
        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string MiddleName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public int RoleId { get; set; }

        [Required]
        public int CouncilId { get; set; }


        [Required, EmailAddress, MaxLength(150)]
        public string Email { get; set; }

        [Required, MinLength(6), MaxLength(150)]
        public string Password { get; set; }

        [Required, Compare("Password"), MaxLength(50)]
        public string ConfirmPassword { get; set; }

        [Range(typeof(bool), "true", "true")]
        public bool AcceptTerms { get; set; }
    }
}