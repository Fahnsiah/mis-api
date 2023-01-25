using MISAPI.DataModel.ViewModels.RolePermissions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MISAPI.DataModel.ViewModels.Accounts
{
    public class AuthenticateResponse : BaseViewModel
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public int CouncilId { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool IsVerified { get; set; }
        public string JwtToken { get; set; }

        public IEnumerable<RolePermissionResponse> Roles { get; set; }

        [JsonIgnore] // refresh token is returned in http only cookie
        public string RefreshToken { get; set; }
    }

}