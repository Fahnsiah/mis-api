using MISAPI.DataModel.ViewModels;
using System.Collections.Generic;

namespace MISAPI.DAL.Interfaces
{
    public interface IConsecrationRequirementInterface
    {
        IEnumerable<ConsecrationRequirementResponse> GetAll();
        ConsecrationRequirementResponse GetById(int id);
        ConsecrationRequirementResponse Create(ConsecrationRequirementRequest model);
        ConsecrationRequirementResponse Update(int id, ConsecrationRequirementRequest model);
    }
}
