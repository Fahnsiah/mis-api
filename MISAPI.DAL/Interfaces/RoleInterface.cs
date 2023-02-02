using MISAPI.DataModel.ViewModels;
using System.Collections.Generic;

namespace MISAPI.DAL.Interfaces
{
    public interface IRoleInterface
    {
        IEnumerable<RoleResponse> GetAll();
        RoleResponse GetById(int id);
        RoleResponse Create(RoleRequest model);
        RoleResponse Update(int id, RoleRequest model);
        void Delete(int id);
    }
}
