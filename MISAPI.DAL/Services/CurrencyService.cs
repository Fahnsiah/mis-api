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
    public class CurrencyService : ICurrencyInterface
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public CurrencyService(
            DataContext context,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public CurrencyResponse Create(CurrencyRequest model)
        {
            try
            {
                var data = _mapper.Map<Currency>(model);
                if (data.IsDefault)
                {
                    var defaultData = _context.Currencies.Where(x => x.IsDefault == true).FirstOrDefault();
                    if (defaultData != null)
                    {
                        defaultData.IsDefault = false;
                        _context.Currencies.Update(defaultData);
                    }
                }
                data.CreatedOn = DateTime.UtcNow;
                data.IsDeleted = false;        

                // save account
                _context.Currencies.Add(data);
                _context.SaveChanges();

                return _mapper.Map<CurrencyResponse>(data);
            }
            catch (Exception ex)
            {
                return new CurrencyResponse()
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
            _context.Currencies.Update(data);
            _context.SaveChanges();
        }

        public IEnumerable<CurrencyResponse> GetAll()
        {
            var data = _context.Currencies.Where(x=>x.IsDeleted == false);            
            return _mapper.Map<IList<CurrencyResponse>>(data);
        }

        public CurrencyResponse GetById(int id)
        {
            var data = getData(id);
            return _mapper.Map<CurrencyResponse>(data);
        }

        public CurrencyResponse Update(int id, CurrencyRequest model)
        {
            if (model.IsDefault)
            {
                var defaultData = _context.Currencies.Where(x => x.IsDefault == true).FirstOrDefault();
                if (defaultData != null)
                {
                    defaultData.IsDefault = false;
                    _context.Currencies.Update(defaultData);
                }
            }

            var data = getData(id);
           
            // copy model to account and save
            _mapper.Map(model, data);
            data.UpdatedOn = DateTime.UtcNow;
            _context.Currencies.Update(data);
            _context.SaveChanges();

            return _mapper.Map<CurrencyResponse>(data);
        }
        private Currency getData(int id)
        {
            var data = _context.Currencies.Find(id);            
            if (data == null) throw new KeyNotFoundException("No data found");
            return data;
        }
    }
}
