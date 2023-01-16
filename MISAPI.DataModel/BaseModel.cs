using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
