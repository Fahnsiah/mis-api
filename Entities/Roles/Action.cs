using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MIS_API.Entities.Roles
{
    public class Action:BaseEntity
    {
        [StringLength(25)]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }


        //foriegn keys relationship      
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
