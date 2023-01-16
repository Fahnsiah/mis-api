using System;
using System.Collections.Generic;
using System.Text;

namespace MISAPI.DataModel.Models.Councils
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string Currency { get; set; }
        public string CurrencySymbol { get; set; }

        public virtual IEnumerable<Council> Councils { get; set; }
    }
}
