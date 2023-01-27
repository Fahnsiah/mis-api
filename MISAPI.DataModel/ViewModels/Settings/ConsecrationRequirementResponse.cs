using System;
using System.Collections.Generic;
using System.Text;

namespace MISAPI.DataModel.ViewModels.Settings
{
    public class ConsecrationRequirementResponse: BaseViewModel
    {
        public int Id { get; set; }
        public int MinAdultBrother { get; set; }
        public int MinAdultSister { get; set; }
        public int MinJrBrother { get; set; }
        public int MinJrSister { get; set; }
        public decimal Fee { get; set; }
        public int CurrencyId { get; set; }
        public string Currency { get; set; }
        public string symbolFee { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
