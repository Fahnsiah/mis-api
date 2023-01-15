using System.ComponentModel.DataAnnotations;


namespace MISAPI.DataModel.ViewModels.Accounts
{
    public class CreateRequest
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int RoleId { get; set; }
        //[Required]
        //[EnumDataType(typeof(RoleEnum))]
        //public string RoleEnum { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}