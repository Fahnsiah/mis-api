using MISAPI.DataModel.ViewModels;
using System.Collections.Generic;

namespace MISAPI.DAL.Interfaces
{
    public interface IRolePermissionInterface
    {
        void AddRemoveAll(IEnumerable<RoleAddRemoveRequest>  model);
        IEnumerable<MenuResponse> GetMenus(); 
        IEnumerable<MenuOperationResponse> GetMenuOperations(); 
         IEnumerable<SubMenuResponse> GetSubMenus();
        IEnumerable<OperationResponse> GetOperations(string id);
        IEnumerable<RolePermissionResponse> GetAll();
        IEnumerable<RolePermissionResponse> GetAllByRole(int id);
        RolePermissionResponse GetById(int id);
        RolePermissionResponse Create(RolePermissionRequest model);
        RolePermissionResponse Update(int id, RolePermissionRequest model);
        void Delete(int id);
        bool UpdateAdminRoles();
    }
}
