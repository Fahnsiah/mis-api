using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MISAPI.DataModel.ViewModels.Settings
{
    public class RitualRequest
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; } 

        [Required]
        public long UserLogId { get; set; }
    }
}
