using MISAPI.DataModel.ViewModels;
using System.Collections.Generic;

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
