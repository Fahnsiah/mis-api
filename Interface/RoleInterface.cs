using MIS_API.Models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIS_API.Interface
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
