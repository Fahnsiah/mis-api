using System.ComponentModel.DataAnnotations;

namespace MISAPI.DataModel.ViewModels
{
    public class ConsecrationRequirementRequest
    {
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

        [Required]
        public long UserLogId { get; set; }
    }
}
