using System.ComponentModel.DataAnnotations;

namespace MISAPI.DataModel.ViewModels
{
    public class CurrencyRequest
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(5)]
        public string Symbol { get; set; }

        [Required]
        public decimal RateToUSD { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }  
        
        public bool IsDefault { get; set; }

        [Required]
        public long UserLogId { get; set; }
    }
}
