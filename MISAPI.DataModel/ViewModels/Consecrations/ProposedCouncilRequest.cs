using System.ComponentModel.DataAnnotations;

namespace MISAPI.DataModel.ViewModels
{
    public class ProposedCouncilRequest
    {
        [Required]
        public int CouncilId { get; set; }
        [Required, MaxLength(150)]
        public string ProposedCouncilLocation { get; set; }
        [Required, MaxLength(150)]
        public string ProposedCouncilParish { get; set; }
        [MaxLength(500)]
        public string Comment { get; set; }
        [Required]
        public decimal ApplicationFeed { get; set; }
        [Required]
        public string TransctionId { get; set; }
        
        [Required]
        public long UserLogId { get; set; }
    }
}
