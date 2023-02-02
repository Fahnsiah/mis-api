using System;

namespace MISAPI.DataModel.ViewModels
{
    public class CouncilTypeResponse: BaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
