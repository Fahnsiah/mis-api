using MISAPI.DataModel.ViewModels;
using System.Collections.Generic;

namespace MISAPI.DAL.Interfaces
{
    public interface ICurrencyInterface
    {
        IEnumerable<CurrencyResponse> GetAll();
        CurrencyResponse GetById(int id);
        CurrencyResponse Create(CurrencyRequest model);
        CurrencyResponse Update(int id, CurrencyRequest model);
        void Delete(int id);
    }
}
