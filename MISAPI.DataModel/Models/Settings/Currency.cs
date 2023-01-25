using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MISAPI.DataModel.Models.Settings
{
    public class Currency: BaseModel
    {
        private string _defaultCurrency = string.Empty;

        [Key]
        public int Id { get; set; }


        [Required, MaxLength(50)]
        public string Name { get; set; }


        [Required, MaxLength(5)]
        public string Symbol { get; set; }


        [Required]
        public decimal RateToUSD { get; set; }

        [DefaultValue(false)]
        public bool IsDefault { get; set; }

        [NotMapped]
        public string DefaultCurrency
        {
            get
            {
                return _defaultCurrency;
            }
            set
            {
                _defaultCurrency = IsDefault ? "YES" : "NO";
            }
        }

        [MaxLength(250)]
        public string Description { get; set; }

        [DefaultValue(true)]
        public bool IsDeleted { get; set; }
    }
}
