using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MISAPI.DataModel.ViewModels.RolePermissions
{
    public class RoleRequest
    {
        //public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }


        [Required]
        public long UserLogId { get; set; }
    }
}
