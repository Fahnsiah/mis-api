
namespace MISAPI.DataModel.ViewModels
{
    public class RolePermissionResponse: BaseViewModel
    {

        public int Id { get; set; }

        public string MenuId { get; set; }

        public string SubMenuId { get; set; }

        public string OperationId { get; set; }

        public int RoleId { get; set; }
    }
}
