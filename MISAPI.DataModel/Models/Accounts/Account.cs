using MISAPI.DataModel.Models.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MISAPI.DataModel.Models.Accounts
{
    public class Account
    {
        
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool AcceptTerms { get; set; }
        //public RoleEnum RoleEnum { get; set; }
        public string VerificationToken { get; set; }
        public DateTime? Verified { get; set; }
        public bool IsVerified => Verified.HasValue || PasswordReset.HasValue;
        public string ResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public DateTime? PasswordReset { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }

        public bool OwnsToken(string token)
        {
            return this.RefreshTokens?.Find(x => x.Token == token) != null;
        }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}