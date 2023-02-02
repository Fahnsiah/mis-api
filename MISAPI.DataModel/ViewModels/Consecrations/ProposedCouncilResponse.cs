using System;

namespace MISAPI.DataModel.ViewModels
{
    public class ProposedCouncilResponse: BaseViewModel
    {
        public int Id { get; set; }
        public int CouncilId { get; set; }
        public string ProposedCouncilLocation { get; set; }
        public string ProposedCouncilParish { get; set; }
        public string Comment { get; set; }
        public decimal ApplicationFeed { get; set; }
        public string TransctionId { get; set; }
        public string Council { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
