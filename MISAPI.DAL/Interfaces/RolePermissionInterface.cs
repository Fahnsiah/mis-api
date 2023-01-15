using MISAPI.DataModel.ViewModels.RolePermissions;
using System.Collections.Generic;

namespace MISAPI.DAL.Interfaces
{
    public interface IRolePermissionInterface
    {
        void AddRemoveAll(IEnumerable<RoleAddRemoveRequest>  model);
        IEnumerable<ModuleResponse> GetModules();
        IEnumerable<TaskResponse> GetTasks();
        IEnumerable<ActionResponse> GetActions();
        IEnumerable<RolePermissionResponse> GetAll();
        IEnumerable<RolePermissionResponse> GetAllByRole(int id);
        RolePermissionResponse GetById(int id);
        RolePermissionResponse Create(RolePermissionRequest model);
        RolePermissionResponse Update(int id, RolePermissionRequest model);
        void Delete(int id);
        void AddAdminRoles();
    }
}
