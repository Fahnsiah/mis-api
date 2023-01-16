using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MISAPI.DataModel.Models.Councils
{
    public class CouncilType
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }

        public virtual IEnumerable<Council> Councils { get; set; }
    }
}
