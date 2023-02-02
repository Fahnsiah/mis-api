using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MISAPI.DataModel.Models
{
    public class Operation: BaseModel
    {
        [Key, MaxLength(75)]
        public string Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        //foriegn key parent   
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
