
using MISAPI.DataModel.ViewModels;
using System.Collections.Generic;

namespace MISAPI.DAL.Interfaces
{
    public interface ICouncilTypeInterface
    {
        IEnumerable<CouncilTypeResponse> GetAll();
        CouncilTypeResponse GetById(int id);
        CouncilTypeResponse Create(CouncilTypeRequest model);
        CouncilTypeResponse Update(int id, CouncilTypeRequest model);
        void Delete(int id);
    }
}
