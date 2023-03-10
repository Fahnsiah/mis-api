using System;

namespace MISAPI.DataModel.ViewModels
{
    public class ArticleResponse: BaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string SymbolPrice { get; set; }
        public int CurrencyId { get; set; }
        public string Currency { get; set; }
        public string Symbol { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        //public Currency Currency { get; set; }
    }
}
