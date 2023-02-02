using System;
using System.ComponentModel.DataAnnotations;

namespace MISAPI.DataModel
{
    public class BaseModel
    {
        [Required]
        public long UserLogId { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        public long? UpdateLogId { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
