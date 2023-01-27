using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MISAPI.DataModel.Models.Settings
{
    public class ConsecrationRequirement: BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int MinAdultBrother { get; set; }
        [Required]
        public int MinAdultSister { get; set; }
        [Required]
        public int MinJrBrother { get; set; }
        [Required]
        public int MinJrSister { get; set; }
        [Required]
        public decimal Fee { get; set; }
        [Required]
        public int CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }
    }
}
