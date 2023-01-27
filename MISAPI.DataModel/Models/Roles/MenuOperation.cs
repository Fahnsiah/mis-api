using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MISAPI.DataModel.Models.Roles
{
    public class MenuOperation
    {
        [MaxLength(75)]
        public string MenuId { get; set; }

        [MaxLength(75)]
        public string OperationId { get; set; }

        public long UserLogId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
