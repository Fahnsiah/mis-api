using System;
using System.ComponentModel.DataAnnotations;

namespace MISAPI.DataModel.ViewModels
{
    public class CouncilTypeRequest
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public long UserLogId { get; set; }
       
       
    }
}
