
using MISAPI.DataModel.ViewModels;
using System.Collections.Generic;

namespace MISAPI.DAL.Interfaces
{
    public interface ICouncilInterface
    {
        IEnumerable<CouncilResponse> GetAll();
        CouncilResponse GetById(int id);
        CouncilResponse Create(CouncilRequest model);
        CouncilResponse Update(int id, CouncilRequest model);
        void Delete(int id);
    }
}
