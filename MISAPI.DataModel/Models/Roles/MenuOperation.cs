using System;
using System.ComponentModel.DataAnnotations;

namespace MISAPI.DataModel.Models
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
