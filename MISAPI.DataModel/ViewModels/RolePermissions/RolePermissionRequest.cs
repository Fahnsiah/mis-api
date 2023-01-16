using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MISAPI.DataModel.ViewModels.RolePermissions
{
    public class RolePermissionRequest
    {
        [Required, MaxLength(25)]
        public string ModuleId { get; set; }
                
        [MaxLength(25)]
        public string TaskId { get; set; }

        [Required, MaxLength(25)]
        public string ActionId { get; set; }

        [Required]
        public int RoleId { get; set; }

        [Required]
        public long UserLogId { get; set; }
        public long? UpdateLogId { get; set; }

    }
}
