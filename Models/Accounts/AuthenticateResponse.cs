using MIS_API.Models.RolePermissions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MIS_API.Models.Accounts
{
    public class AuthenticateResponse
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool IsVerified { get; set; }
        public string JwtToken { get; set; }

        public IEnumerable<RolePermissionResponse> Roles { get; set; }

        [JsonIgnore] // refresh token is returned in http only cookie
        public string RefreshToken { get; set; }
    }

}