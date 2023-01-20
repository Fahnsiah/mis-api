﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace MISAPI.DataModel.Models.Roles
{
    public class RolePermission : BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(25)]
        public string MenuId { get; set; }

        [MaxLength(25)]
        public string SubMenuId { get; set; }

        [Required, MaxLength(25)]
        public string OperationId { get; set; }

        [DefaultValue(true)]
        public bool IsDeleted { get; set; }

        //foreign keys relationship
        public int RoleId { get; set; }


        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        [ForeignKey("MenuId")]
        public virtual Menu Menu { get; set; }

        [ForeignKey("SubMenuId")]
        public virtual SubMenu SubMenu { get; set; }

        [ForeignKey("OperationId")]
        public virtual Operation Operation { get; set; }
    }
}
