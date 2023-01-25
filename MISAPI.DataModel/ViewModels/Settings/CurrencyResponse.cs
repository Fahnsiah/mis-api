using System;
using System.Collections.Generic;
using System.Text;

namespace MISAPI.DataModel.ViewModels.Settings
{
    public class CurrencyResponse: BaseViewModel
    {
        private string _defaultCurrency = string.Empty;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal RateToUSD { get; set; }
        public string Description { get; set; }
        public bool IsDefault { get; set; }
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
        public DateTime CreatedOn { get; set; }
    }
}
