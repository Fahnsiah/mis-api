using AutoMapper;
using Microsoft.Extensions.Options;
using MISAPI.DAL.Helpers;
using MISAPI.DAL.Interfaces;
using MISAPI.DataModel.DataAccess;
using MISAPI.DataModel.Models;
using MISAPI.DataModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MISAPI.DAL.Services
{
    public class ArticleService : IArticleInterface
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public ArticleService(
            DataContext context,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            try
            {
                _context = context;
                _mapper = mapper;
                _appSettings = appSettings.Value;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public ArticleResponse Create(ArticleRequest model)
        {
            try
            {
                var data = _mapper.Map<Article>(model);
                data.CreatedOn = DateTime.UtcNow;
                data.IsDeleted = false;        

                // save account
                _context.Articles.Add(data);
                _context.SaveChanges();

                return _mapper.Map<ArticleResponse>(data);
            }
            catch (Exception ex)
            {
                return new ArticleResponse()
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
            _context.Articles.Update(data);
            _context.SaveChanges();
        }

        public IEnumerable<ArticleResponse> GetAll()
        {
            var data = from cur in _context.Currencies
                       join art in _context.Articles on cur equals art.Currency
                       where art.IsDeleted == false
                       select new ArticleResponse
                       {
                           Id = art.Id,
                           Name = art.Name,
                           Price = art.Price,
                           SymbolPrice = string.Format("{0} {1}", cur.Symbol, art.Price),
                           Description = art.Description,
                           CurrencyId = art.CurrencyId,
                           Currency = cur.Name,
                           Symbol = cur.Symbol,
                           CreatedOn = art.CreatedOn
                       };

            return data;

            //var data = _context.Articles.Where(x=>x.IsDeleted == false);            
            //return _mapper.Map<IList<ArticleResponse>>(data);
        }

        public ArticleResponse GetById(int id)
        {
            var data = getData(id);
            return _mapper.Map<ArticleResponse>(data);
        }

        public ArticleResponse Update(int id, ArticleRequest model)
        {
            var data = getData(id);

            // copy model to account and save
            _mapper.Map(model, data);
            data.UpdatedOn = DateTime.UtcNow;
            _context.Articles.Update(data);
            _context.SaveChanges();

            return _mapper.Map<ArticleResponse>(data);
        }
        private Article getData(int id)
        {
            var data = _context.Articles.Find(id);            
            if (data == null) throw new KeyNotFoundException("No data found");
            return data;
        }
    }
}
