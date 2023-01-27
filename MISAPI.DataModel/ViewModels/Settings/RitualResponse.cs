using System;
using System.Collections.Generic;
using System.Text;

namespace MISAPI.DataModel.ViewModels.Settings
{
    public class RitualResponse: BaseViewModel
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
