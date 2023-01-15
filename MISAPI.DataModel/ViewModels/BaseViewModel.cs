using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISAPI.DataModel.ViewModels
{
    public class BaseViewModel
    {
        private bool _success = true;
        
        public bool Success
        {
            get
            {
                return _success;
            }
            set
            {
                _success = value;
            }
        }
        public string Message { get; set; }
    }
}
