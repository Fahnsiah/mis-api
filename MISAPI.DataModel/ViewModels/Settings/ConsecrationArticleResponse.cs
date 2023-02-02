using System;

namespace MISAPI.DataModel.ViewModels
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
