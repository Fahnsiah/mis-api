using MISAPI.DataModel.ViewModels;
using System.Collections.Generic;

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
