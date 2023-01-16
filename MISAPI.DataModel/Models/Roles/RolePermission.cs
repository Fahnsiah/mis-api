using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MISAPI.DataModel.Models.Roles
{
    public class RolePermission : BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(25)]
        public string ModuleId { get; set; }

        [MaxLength(25)]
        public string TaskId { get; set; }

        [Required, MaxLength(25)]
        public string ActionId { get; set; }

        [DefaultValue(true)]
        public bool IsDeleted { get; set; }

        //foreign keys relationship
        public int RoleId { get; set; }


        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
