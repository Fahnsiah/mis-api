using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MISAPI.DataModel.Models
{
    public class SubMenu : BaseModel
    {
        [Key, MaxLength(75)]
        public string Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(75)]
        public string MenuId { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
