
using MISAPI.DataModel.ViewModels.RolePermissions;
using MISAPI.DataModel.ViewModels.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISAPI.DAL.Interfaces
{
    public interface IConsecrationRequirementInterface
    {
        IEnumerable<ConsecrationRequirementResponse> GetAll();
        ConsecrationRequirementResponse GetById(int id);
        ConsecrationRequirementResponse Create(ConsecrationRequirementRequest model);
        ConsecrationRequirementResponse Update(int id, ConsecrationRequirementRequest model);
    }
}
