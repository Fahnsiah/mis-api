using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MISAPI.DataModel.Models.Councils
{
    public class Council
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int No { get; set; }
        public int CouncilTypeId { get; set; }
        public int CountryId { get; set; }
        public string Address { get; set; }
        public DateTime ConsecreatedOn { get; set; }      
        public long? UserLogId { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        public long? UpdateLogId { get; set; }
        public DateTime? UpdatedOn { get; set; }


        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        [ForeignKey("CouncilTypeId")]
        public virtual CouncilType CouncilType { get; set; }
    }
}
