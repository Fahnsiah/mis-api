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
    public class RitualService : IRitualInterface
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public RitualService(
            DataContext context,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public RitualResponse Create(RitualRequest model)
        {
            try
            {
                var data = _mapper.Map<Ritual>(model);                
                data.CreatedOn = DateTime.UtcNow;
                data.IsDeleted = false;        

                // save account
                _context.Rituals.Add(data);
                _context.SaveChanges();

                return _mapper.Map<RitualResponse>(data);
            }
            catch (Exception ex)
            {
                return new RitualResponse()
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
            _context.Rituals.Update(data);
            _context.SaveChanges();
        }

        public IEnumerable<RitualResponse> GetAll()
        {
            var data = _context.Rituals.Where(x=>x.IsDeleted == false);            
            return _mapper.Map<IList<RitualResponse>>(data);
        }

        public RitualResponse GetById(int id)
        {
            var data = getData(id);
            return _mapper.Map<RitualResponse>(data);
        }

        public RitualResponse Update(int id, RitualRequest model)
        {
            var data = getData(id);
           
            // copy model to account and save
            _mapper.Map(model, data);
            data.UpdatedOn = DateTime.UtcNow;
            _context.Rituals.Update(data);
            _context.SaveChanges();

            return _mapper.Map<RitualResponse>(data);
        }
        private Ritual getData(int id)
        {
            var data = _context.Rituals.Find(id);            
            if (data == null) throw new KeyNotFoundException("No data found");
            return data;
        }
    }
}
