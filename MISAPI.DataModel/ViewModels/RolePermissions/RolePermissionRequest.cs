using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MISAPI.DataModel.ViewModels.RolePermissions
{
    public class RolePermissionRequest
    {
        [Required]
        public string ModuleId { get; set; }
                
        public string TaskId { get; set; }

        [Required]
        public string ActionId { get; set; }

        [Required]
        public int RoleId { get; set; }

        [Required]
        public long UserLogId { get; set; }
        public long? UpdateLogId { get; set; }

    }
}
