using System;

namespace MISAPI.DataModel.ViewModels
{
    public class CouncilResponse: BaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCouncil { get; set; }
        public int CountryId { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string CouncilType { get; set; }
        public DateTime ConsecreatedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
