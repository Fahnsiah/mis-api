using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MIS_API.Entities.Roles
{
    public class Role : BaseEntity
    {
        public int Id { get; set; }

        
        [Required, StringLength(50)]
        public string Name { get; set; }


        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        [DefaultValue(true)]
        public bool Enabled { get; set; }

        [DefaultValue(true)]
        public bool IsDeleted { get; set; }


        //foreign key relationship       
        public long UserLogId { get; set; }
        public long? UpdateLogId { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
