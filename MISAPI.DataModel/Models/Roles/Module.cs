using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MISAPI.DataModel.Models.Roles
{
    public class Module: BaseModel
    {
        [MaxLength(25)]
        public string Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        //foriegn key parent
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
