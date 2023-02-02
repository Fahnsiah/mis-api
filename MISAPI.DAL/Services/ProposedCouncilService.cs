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
    public class ProposedCouncilService : IProposedCouncilInterface
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public ProposedCouncilService(
            DataContext context,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public ProposedCouncilResponse Create(ProposedCouncilRequest model)
        {
            try
            {
                var data = _mapper.Map<ProposedCouncil>(model);
                data.CreatedOn = DateTime.UtcNow;
                data.IsDeleted = false;        

                // save account
                _context.ProposedCouncils.Add(data);
                _context.SaveChanges();

                return _mapper.Map<ProposedCouncilResponse>(data);
            }
            catch (Exception ex)
            {
                return new ProposedCouncilResponse()
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
            _context.ProposedCouncils.Update(data);
            _context.SaveChanges();
        }

        public IEnumerable<ProposedCouncilResponse> GetAll()
        {
            var data = from council in _context.Councils
                       join proposedCouncil in _context.ProposedCouncils on council equals proposedCouncil.Council
                       where proposedCouncil.IsDeleted == false
                       select new ProposedCouncilResponse
                       {
                           Id = proposedCouncil.Id,
                           CouncilId = proposedCouncil.CouncilId,
                           ProposedCouncilLocation = proposedCouncil.ProposedCouncilLocation,
                           ProposedCouncilParish = proposedCouncil.ProposedCouncilParish,
                           Comment = proposedCouncil.Comment,
                           ApplicationFeed = proposedCouncil.ApplicationFeed,
                           TransctionId = proposedCouncil.TransctionId,
                           Council = council.Name,
                           CreatedOn = proposedCouncil.CreatedOn,
                       };
            return data;

            //var data = _context.ProposedCouncils.Where(x => x.IsDeleted == false);
            //return _mapper.Map<IList<ProposedCouncilResponse>>(data);
        }

        public ProposedCouncilResponse GetById(int id)
        {
            var data = getData(id);
            return _mapper.Map<ProposedCouncilResponse>(data);
        }

        public ProposedCouncilResponse Update(int id, ProposedCouncilRequest model)
        {
            var data = getData(id);

            // copy model to account and save
            _mapper.Map(model, data);
            data.UpdatedOn = DateTime.UtcNow;
            _context.ProposedCouncils.Update(data);
            _context.SaveChanges();

            return _mapper.Map<ProposedCouncilResponse>(data);
        }
        private ProposedCouncil getData(int id)
        {
            var data = _context.ProposedCouncils.Find(id);            
            if (data == null) throw new KeyNotFoundException("No data found");
            return data;
        }
    }
}
