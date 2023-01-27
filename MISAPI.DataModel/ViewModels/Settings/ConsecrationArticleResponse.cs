using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MISAPI.DataModel.ViewModels.Settings
{
    public class ConsecrationArticleResponse : BaseViewModel
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string Article { get; set; }
        public decimal Price { get; set; }
        public string SymbolPrice { get; set; }        
        public DateTime CreatedOn { get; set; }
    }
}
