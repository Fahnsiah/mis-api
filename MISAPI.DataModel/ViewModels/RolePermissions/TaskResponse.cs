using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISAPI.DataModel.ViewModels.RolePermissions
{
    public class TaskResponse: BaseViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ModuleId { get; set; }
    }
}
