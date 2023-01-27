using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MISAPI.DataModel.Models.Roles
{
    public class Menu: BaseModel 
    {
        [Key, MaxLength(75)]
        public string Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
