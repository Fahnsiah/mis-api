using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISAPI.DataModel.Models
{
    public class UserLog
    {
        public long Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int OperationId { get; set; }

        [Required, MaxLength(50)]
        public string ActionOn { get; set; }

        [Required]
        public DateTime ActionDate { get; set; }



        [ForeignKey("OperationId")]
        public virtual Action Role { get; set; }

    }
}
