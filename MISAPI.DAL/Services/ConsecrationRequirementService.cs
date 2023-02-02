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
    public class ConsecrationRequirementService : IConsecrationRequirementInterface
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public ConsecrationRequirementService(
            DataContext context,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public ConsecrationRequirementResponse Create(ConsecrationRequirementRequest model)
        {
            try
            {
                var data = _mapper.Map<ConsecrationRequirement>(model);
                data.CreatedOn = DateTime.UtcNow;

                // save account
                _context.ConsecrationRequirements.Add(data);
                _context.SaveChanges();

                return _mapper.Map<ConsecrationRequirementResponse>(data);
            }
            catch (Exception ex)
            {
                return new ConsecrationRequirementResponse()
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public IEnumerable<ConsecrationRequirementResponse> GetAll()
        {
            var data = from cur in _context.Currencies
                       join consec in _context.ConsecrationRequirements on cur equals consec.Currency
                       select new ConsecrationRequirementResponse
                       {
                           Id = consec.Id,
                           MinAdultBrother = consec.MinAdultBrother,
                           MinAdultSister = consec.MinAdultSister,
                           MinJrBrother = consec.MinJrBrother,
                           MinJrSister = consec.MinJrSister,
                           Fee = consec.Fee,
                           CurrencyId = consec.CurrencyId,
                           Currency = cur.Name,
                           symbolFee = string.Format("{0}{1}", cur.Symbol, consec.Fee),
                           CreatedOn = consec.CreatedOn
                       };
            return data;
            //var data = _context.ConsecrationRequirements.Where(x=>x.IsDeleted == false);            
            //return _mapper.Map<IList<ConsecrationRequirementResponse>>(data);
        }

        public ConsecrationRequirementResponse GetById(int id)
        {
            var data = getData(id);
            return _mapper.Map<ConsecrationRequirementResponse>(data);
        }

        public ConsecrationRequirementResponse Update(int id, ConsecrationRequirementRequest model)
        {
            var data = getData(id);

            // copy model to account and save
            _mapper.Map(model, data);
            data.UpdateLogId = model.UserLogId;
            data.UpdatedOn = DateTime.UtcNow;
            _context.ConsecrationRequirements.Update(data);
            _context.SaveChanges();

            return _mapper.Map<ConsecrationRequirementResponse>(data);
        }
        private ConsecrationRequirement getData(int id)
        {
            var data = _context.ConsecrationRequirements.Find(id);
            if (data == null) throw new KeyNotFoundException("No data found");
            return data;
        }
    }
}
