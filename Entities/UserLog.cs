using MIS_API.Entities.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MIS_API.Entities
{
    public class UserLog
    {
        public long Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ActionId { get; set; }

        [Required]
        public string ActionOn { get; set; }

        [Required]
        public DateTime ActionDate { get; set; }

        //foreign keys relationship
        //public ICollection<Role> Roles { get; set; }

        //public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
