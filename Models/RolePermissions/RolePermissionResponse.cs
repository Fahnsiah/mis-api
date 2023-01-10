
namespace MIS_API.Models.RolePermissions
{
    public class RolePermissionResponse: BaseModel
    {

        public int Id { get; set; }

        public string ModuleId { get; set; }

        public string TaskId { get; set; }

        public string ActionId { get; set; }

        public int RoleId { get; set; }
    }
}
