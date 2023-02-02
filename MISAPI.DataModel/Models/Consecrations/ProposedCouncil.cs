using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISAPI.DataModel.Models
{
    public class ProposedCouncil: BaseModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int CouncilId { get; set; }
        [Required]
        public int CouncilTypeId { get; set; }
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
        public bool IsDeleted { get; set; }

        [ForeignKey("CouncilId")]
        public virtual Council Council { get; set; }
       
    }
}
