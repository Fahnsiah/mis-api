using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISAPI.DataModel.Models
{
    public class Council
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsCouncil { get; set; }
        [Required]
        public int CouncilTypeId { get; set; }
        [Required]
        public int CountryId { get; set; }
        [Required, StringLength(150)]
        public string Address { get; set; }
        public DateTime ConsecreatedOn { get; set; }
        public int ProposedCouncilId { get; set; }
        //[Required]
        public long? UserLogId { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        public long? UpdateLogId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [Required]
        public bool IsDeleted { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        [ForeignKey("CouncilTypeId")]
        public virtual CouncilType CouncilType { get; set; }
    }
}
