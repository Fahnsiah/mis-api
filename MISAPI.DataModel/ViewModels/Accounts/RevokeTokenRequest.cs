using System.ComponentModel.DataAnnotations;

namespace MISAPI.DataModel.ViewModels.Accounts
{
    public class RevokeTokenRequest
    {
        [Required, MaxLength(1500)]
        public string Token { get; set; }
    }
}