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
    public class RoleService : IRoleInterface
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public RoleService(
            DataContext context,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public RoleResponse Create(RoleRequest model)
        {
            try
            {
                var data = _mapper.Map<Role>(model);
                data.CreatedOn = DateTime.UtcNow;
                data.Enabled = true;
                data.IsDeleted = false;        

                // save account
                _context.Roles.Add(data);
                _context.SaveChanges();

                return _mapper.Map<RoleResponse>(data);
            }
            catch (Exception ex)
            {
                return new RoleResponse()
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
            _context.Roles.Update(data);
            _context.SaveChanges();
        }

        public IEnumerable<RoleResponse> GetAll()
        {
            var data = _context.Roles.Where(x=>x.IsDeleted == false && x.Id > 1);            
            return _mapper.Map<IList<RoleResponse>>(data);
        }

        public RoleResponse GetById(int id)
        {
            var data = getData(id);
            return _mapper.Map<RoleResponse>(data);
        }

        public RoleResponse Update(int id, RoleRequest model)
        {
            var data = getData(id);

            // copy model to account and save
            _mapper.Map(model, data);
            data.UpdatedOn = DateTime.UtcNow;
            _context.Roles.Update(data);
            _context.SaveChanges();

            return _mapper.Map<RoleResponse>(data);
        }
        private Role getData(int id)
        {
            var data = _context.Roles.Find(id);            
            if (data == null) throw new KeyNotFoundException("No data found");
            return data;
        }
    }
}
