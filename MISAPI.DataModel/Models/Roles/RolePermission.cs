using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MISAPI.DataModel.Models.Roles
{
    public class RolePermission
    {
        public int Id { get; set; }

        [Required]
        public string ModuleId { get; set; }
       
        public string TaskId { get; set; }

        [Required]
        public string ActionId { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }


        [DefaultValue(true)]
        public bool IsDeleted { get; set; }

        //foreign keys relationship
        public int RoleId { get; set; }
        public long UserLogId { get; set; }       
        public long? UpdateLogId { get; set; }


        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
