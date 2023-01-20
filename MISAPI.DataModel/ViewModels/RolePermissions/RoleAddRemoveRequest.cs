using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MISAPI.DataModel.ViewModels.RolePermissions
{
    public class RoleAddRemoveRequest : BaseViewModel
    {
        [Required, MaxLength(25)]
        public string MenuId { get; set; }

        [MaxLength(25)]
        public string SubMenuId { get; set; }

        [Required, MaxLength(25)]
        public string OperationId { get; set; }

        [Required]
        public int RoleId { get; set; }

        [Required]
        public bool Add { get; set; }

        [Required]
        public long UserLogId { get; set; }
        public long? UpdateLogId { get; set; }

    }
}
