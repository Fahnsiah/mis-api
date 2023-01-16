using Microsoft.EntityFrameworkCore;
using MISAPI.DataModel.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MISAPI.DataModel.Models.Roles
{
    public class Role : BaseModel
    {
        public int Id { get; set; }

        
        [Required, MaxLength(50)]
        public string Name { get; set; }


        [MaxLength(250)]
        public string Description { get; set; }


        [DefaultValue(true)]
        public bool Enabled { get; set; }

        [DefaultValue(true)]
        public bool IsDeleted { get; set; }


        public virtual IEnumerable<Account> Accounts { get; set; }
    }
}
