
using MISAPI.DataModel.ViewModels.RolePermissions;
using MISAPI.DataModel.ViewModels.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
