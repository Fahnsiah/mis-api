
using MISAPI.DataModel.ViewModels.RolePermissions;
using MISAPI.DataModel.ViewModels.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISAPI.DAL.Interfaces
{
    public interface IArticleInterface
    {
        IEnumerable<ArticleResponse> GetAll();
        ArticleResponse GetById(int id);
        ArticleResponse Create(ArticleRequest model);
        ArticleResponse Update(int id, ArticleRequest model);
        void Delete(int id);
    }
}
