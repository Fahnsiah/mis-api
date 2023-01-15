using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISAPI.DataModel.ViewModels.RolePermissions
{
    public class RoleResponse: BaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public DateTime CreatedOn { get; set; }
        //public DateTime? UpdatedOn { get; set; }
        public bool Enabled { get; set; }
    }
}
