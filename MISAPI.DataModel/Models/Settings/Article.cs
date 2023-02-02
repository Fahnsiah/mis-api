using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISAPI.DataModel.Models
{
    public class Article: BaseModel
    {
        [Key]
        public int Id { get; set; }


        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CurrencyId { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [DefaultValue(true)]
        public bool IsDeleted { get; set; }

        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }
    }
}
