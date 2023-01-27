
using MISAPI.DataModel.ViewModels.RolePermissions;
using MISAPI.DataModel.ViewModels.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISAPI.DAL.Interfaces
{
    public interface IRitualInterface
    {
        IEnumerable<RitualResponse> GetAll();
        RitualResponse GetById(int id);
        RitualResponse Create(RitualRequest model);
        RitualResponse Update(int id, RitualRequest model);
        void Delete(int id);
    }
}
