using AutoMapper;
using Microsoft.Extensions.Options;
using MISAPI.DAL.Helpers;
using MISAPI.DAL.Interfaces;
using MISAPI.DataModel.DataAccess;
using MISAPI.DataModel.Models.Settings;
using MISAPI.DataModel.ViewModels.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISAPI.DAL.Services
{
    public class ConsecrationArticleService : IConsecrationArticleInterface
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public ConsecrationArticleService(
            DataContext context,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public ConsecrationArticleResponse Create(ConsecrationArticleRequest model)
        {
            try
            {
                var result = _context.ConsecrationArticles.Where(x => x.ArticleId == model.ArticleId && x.IsDeleted == true).FirstOrDefault();
                if (result != null)
                {
                    result.IsDeleted = false;
                    _context.ConsecrationArticles.Update(result);
                    _context.SaveChanges();
                    var data = _mapper.Map<ConsecrationArticle>(result);
                    return _mapper.Map<ConsecrationArticleResponse>(data);
                }
                else
                {
                    var data = _mapper.Map<ConsecrationArticle>(model);
                    data.CreatedOn = DateTime.UtcNow;
                    data.IsDeleted = false;

                    // save account
                    _context.ConsecrationArticles.Add(data);
                    _context.SaveChanges();

                    return _mapper.Map<ConsecrationArticleResponse>(data);
                }
            }
            catch (Exception ex)
            {
                return new ConsecrationArticleResponse()
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public void Delete(int id)
        {
            var data = getData(id);

            data.IsDeleted = true;
            data.UpdatedOn = DateTime.UtcNow;
            _context.ConsecrationArticles.Update(data);
            _context.SaveChanges();
        }

        public IEnumerable<ConsecrationArticleResponse> GetAll()
        {
            var data = from art in _context.Articles
                       join consec in _context.ConsecrationArticles on art equals consec.Article
                       where consec.IsDeleted == false
                       select new ConsecrationArticleResponse
                       {
                           Id = consec.Id,
                           ArticleId = consec.ArticleId,
                           Article = art.Name,
                           Price = art.Price,
                           SymbolPrice = string.Format("{0} {1}", art.Currency.Symbol, art.Price),
                           CreatedOn = consec.CreatedOn
                       };
            return data;
            //var data = _context.ConsecrationArticles.Where(x=>x.IsDeleted == false);            
            //return _mapper.Map<IList<ConsecrationArticleResponse>>(data);
        }

        public ConsecrationArticleResponse GetById(int id)
        {
            var data = getData(id);
            return _mapper.Map<ConsecrationArticleResponse>(data);
        }

        public ConsecrationArticleResponse Update(int id, ConsecrationArticleRequest model)
        {
            var data = getData(id);

            // copy model to account and save
            _mapper.Map(model, data);
            data.UpdateLogId = model.UserLogId;
            data.UpdatedOn = DateTime.UtcNow;
            _context.ConsecrationArticles.Update(data);
            _context.SaveChanges();

            return _mapper.Map<ConsecrationArticleResponse>(data);
        }
        private ConsecrationArticle getData(int id)
        {
            var data = _context.ConsecrationArticles.Find(id);
            if (data == null) throw new KeyNotFoundException("No data found");
            return data;
        }
    }
}
