
using MISAPI.DataModel.ViewModels;
using System.Collections.Generic;

namespace MISAPI.DAL.Interfaces
{
    public interface IProposedCouncilInterface
    {
        IEnumerable<ProposedCouncilResponse> GetAll();
        ProposedCouncilResponse GetById(int id);
        ProposedCouncilResponse Create(ProposedCouncilRequest model);
        ProposedCouncilResponse Update(int id, ProposedCouncilRequest model);
        void Delete(int id);
    }
}
