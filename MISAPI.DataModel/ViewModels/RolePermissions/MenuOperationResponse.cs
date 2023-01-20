using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISAPI.DataModel.ViewModels.RolePermissions
{
    public class MenuOperationResponse : BaseViewModel
    {
        public string MenuId { get; set; }

        public string OperationId { get; set; }
    }
}
