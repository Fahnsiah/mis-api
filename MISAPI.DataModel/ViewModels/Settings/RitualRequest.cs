using System.ComponentModel.DataAnnotations;

namespace MISAPI.DataModel.ViewModels
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
