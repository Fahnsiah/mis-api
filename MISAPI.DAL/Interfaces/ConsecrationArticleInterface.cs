
using MISAPI.DataModel.ViewModels.RolePermissions;
using MISAPI.DataModel.ViewModels.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISAPI.DAL.Interfaces
{
    public interface IConsecrationArticleInterface
    {
        IEnumerable<ConsecrationArticleResponse> GetAll();
        ConsecrationArticleResponse GetById(int id);
        ConsecrationArticleResponse Create(ConsecrationArticleRequest model);
        ConsecrationArticleResponse Update(int id, ConsecrationArticleRequest model);
        void Delete(int id);
    }
}
