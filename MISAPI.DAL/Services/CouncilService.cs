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
    public class CouncilService : ICouncilInterface
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public CouncilService(
            DataContext context,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public CouncilResponse Create(CouncilRequest model)
        {
            try
            {
                var data = _mapper.Map<Council>(model);
                data.CreatedOn = DateTime.UtcNow;
                data.IsDeleted = false;        

                // save account
                _context.Councils.Add(data);
                _context.SaveChanges();

                return _mapper.Map<CouncilResponse>(data);
            }
            catch (Exception ex)
            {
                return new CouncilResponse()
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
            _context.Councils.Update(data);
            _context.SaveChanges();
        }

        public IEnumerable<CouncilResponse> GetAll()
        {
            var data = from council in _context.Councils
                       join country in _context.Countries on council.CountryId equals country.Id                       
                       where council.IsDeleted == false
                       select new CouncilResponse
                       {
                           Id = council.Id,
                           Name = council.Name,
                           Address = council.Address,
                           ConsecreatedOn = council.ConsecreatedOn,
                           CountryId = council.CountryId,
                           CreatedOn = council.CreatedOn,
                           IsCouncil = council.IsCouncil,
                           Country = country.Name                           
                       };
            return data;

            //var data = _context.Councils.Where(x => x.IsDeleted == false);
            //return _mapper.Map<IList<CouncilResponse>>(data);
        }

        public CouncilResponse GetById(int id)
        {
            var data = getData(id);
            return _mapper.Map<CouncilResponse>(data);
        }

        public CouncilResponse Update(int id, CouncilRequest model)
        {
            var data = getData(id);

            // copy model to account and save
            _mapper.Map(model, data);
            data.UpdatedOn = DateTime.UtcNow;
            _context.Councils.Update(data);
            _context.SaveChanges();

            return _mapper.Map<CouncilResponse>(data);
        }
        private Council getData(int id)
        {
            var data = _context.Councils.Find(id);            
            if (data == null) throw new KeyNotFoundException("No data found");
            return data;
        }
    }
}
