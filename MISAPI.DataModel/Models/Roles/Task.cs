using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MISAPI.DataModel.Models.Roles
{
    public class Task : BaseModel
    {
        [StringLength(25)]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        //foriegn key relationship
        public string ModuleId { get; set; }

        [ForeignKey("ModuleId")]
        public virtual Module Module { get; set; }


        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
