using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MISAPI.DataModel.Models.Settings
{
    public class ConsecrationArticle : BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ArticleId { get; set; }

        [DefaultValue(true)]
        public bool IsDeleted { get; set; }

        [ForeignKey("ArticleId")]
        public virtual Article Article { get; set; }
    }
}
