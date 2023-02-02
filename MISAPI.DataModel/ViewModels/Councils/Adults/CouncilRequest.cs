using System;
using System.ComponentModel.DataAnnotations;

namespace MISAPI.DataModel.ViewModels
{
    public class CouncilRequest
    {
        [Required]
        public bool IsCouncil { get; set; }
        [Required]
        public int CountryId { get; set; }
        [Required, StringLength(150)]
        public string Address { get; set; }
        public DateTime ConsecreatedOn { get; set; }
        [Required]
        public long UserLogId { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
       
    }
}
