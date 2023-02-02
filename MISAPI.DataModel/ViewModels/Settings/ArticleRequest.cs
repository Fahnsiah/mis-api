using System;
using System.ComponentModel.DataAnnotations;

namespace MISAPI.DataModel.ViewModels
{
    public class ArticleRequest
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CurrencyId { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public long UserLogId { get; set; }
    }
}
