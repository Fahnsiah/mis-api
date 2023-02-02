using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MISAPI.DataModel.Models
{
    public class CouncilType
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        
        public long UserLogId { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        public long? UpdateLogId { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual IEnumerable<Council> Councils { get; set; }
    }
}
