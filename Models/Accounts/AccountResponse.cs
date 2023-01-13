using MIS_API.Entities.Roles;
using System;

namespace MIS_API.Models.Accounts
{
    public class AccountResponse
    {
        public int Id { get; set; }
        //public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }

        //public DateTime Created { get; set; }
        //public DateTime? Updated { get; set; }
        //public bool IsVerified { get; set; }
    }
}