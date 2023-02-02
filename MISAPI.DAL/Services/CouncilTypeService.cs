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
    public class CouncilTypeService : ICouncilTypeInterface
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public CouncilTypeService(
            DataContext context,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public CouncilTypeResponse Create(CouncilTypeRequest model)
        {
            try
            {
                var data = _mapper.Map<CouncilType>(model);
                data.CreatedOn = DateTime.UtcNow;

                // save account
                _context.CouncilTypes.Add(data);
                _context.SaveChanges();

                return _mapper.Map<CouncilTypeResponse>(data);
            }
            catch (Exception ex)
            {
                return new CouncilTypeResponse()
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public void Delete(int id)
        {
            var data = getData(id);
            data.UpdatedOn = DateTime.UtcNow;
            _context.CouncilTypes.Update(data);
            _context.SaveChanges();
        }

        public IEnumerable<CouncilTypeResponse> GetAll()
        {

            var data = _context.CouncilTypes;
            return _mapper.Map<IList<CouncilTypeResponse>>(data);
        }

        public CouncilTypeResponse GetById(int id)
        {
            var data = getData(id);
            return _mapper.Map<CouncilTypeResponse>(data);
        }

        public CouncilTypeResponse Update(int id, CouncilTypeRequest model)
        {
            var data = getData(id);

            // copy model to account and save
            _mapper.Map(model, data);
            data.UpdatedOn = DateTime.UtcNow;
            _context.CouncilTypes.Update(data);
            _context.SaveChanges();

            return _mapper.Map<CouncilTypeResponse>(data);
        }
        private CouncilType getData(int id)
        {
            var data = _context.CouncilTypes.Find(id);            
            if (data == null) throw new KeyNotFoundException("No data found");
            return data;
        }
    }
}
