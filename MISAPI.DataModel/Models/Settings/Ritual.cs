using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MISAPI.DataModel.Models
{
    public class Ritual : BaseModel
    {
       
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [DefaultValue(true)]
        public bool IsDeleted { get; set; }
    }
}
