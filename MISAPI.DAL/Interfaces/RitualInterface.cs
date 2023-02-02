using MISAPI.DataModel.ViewModels;
using System.Collections.Generic;

namespace MISAPI.DAL.Interfaces
{
    public interface IRitualInterface
    {
        IEnumerable<RitualResponse> GetAll();
        RitualResponse GetById(int id);
        RitualResponse Create(RitualRequest model);
        RitualResponse Update(int id, RitualRequest model);
        void Delete(int id);
    }
}
