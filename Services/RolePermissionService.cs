using AutoMapper;
using Microsoft.Extensions.Options;
using MIS_API.Entities.Roles;
using MIS_API.Helpers;
using MIS_API.Interface;
using MIS_API.Models.RolePermissions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MIS_API.Services
{
    public class RolePermissionService : IRolePermissionInterface
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public RolePermissionService(
            DataContext context,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public IEnumerable<ModuleResponse> GetModules()
        {
            var data = _context.Modules.OrderBy(x => x.Id);
            return _mapper.Map<IList<ModuleResponse>>(data);
        }

        public IEnumerable<TaskResponse> GetTasks()
        {
            var data = _context.Tasks.OrderBy(x => x.Id);
            return _mapper.Map<IList<TaskResponse>>(data);
        }

        public IEnumerable<ActionResponse> GetActions()
        {
            var data = _context.Actions.OrderBy(x => x.Id);
            return _mapper.Map<IList<ActionResponse>>(data);
        }
        public RolePermissionResponse Create(RolePermissionRequest model)
        {
            try
            {
                var data = _mapper.Map<RolePermission>(model);
                var role = _context.RolePermissions.Where(x => x.RoleId == data.RoleId &&
                                                    x.ModuleId == data.ModuleId &&
                                                    x.TaskId == data.TaskId &&
                                                    x.ActionId == data.ActionId).FirstOrDefault();

                if (role != null)
                {
                    data.Id = role.Id;

                    role.IsDeleted = false;
                    role.UpdatedOn = DateTime.Now;

                    _context.RolePermissions.Update(role);
                    _context.SaveChanges();
                }
                else
                {
                    data.CreatedOn = DateTime.UtcNow;

                    // save account
                    _context.RolePermissions.Add(data);
                    _context.SaveChanges();
                }

                return _mapper.Map<RolePermissionResponse>(data);
            }
            catch (Exception ex)
            {
                return new RolePermissionResponse()
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
            _context.RolePermissions.Update(data);
            _context.SaveChanges();
        }

        public IEnumerable<RolePermissionResponse> GetAll()
        {
            var data = _context.RolePermissions.Where(x => x.IsDeleted == false);
            return _mapper.Map<IList<RolePermissionResponse>>(data);
        }

        public IEnumerable<RolePermissionResponse> GetAllByRole(int id)
        {
            var data = _context.RolePermissions.Where(x => x.RoleId == id && x.IsDeleted==false);
            return _mapper.Map<IList<RolePermissionResponse>>(data);
        }

        public RolePermissionResponse GetById(int id)
        {
            var data = getData(id);
            return _mapper.Map<RolePermissionResponse>(data);
        }

        public RolePermissionResponse Update(int id, RolePermissionRequest model)
        {
            var data = getData(id);

            // copy model to account and save
            _mapper.Map(model, data);
            data.UpdatedOn = DateTime.UtcNow;
            _context.RolePermissions.Update(data);
            _context.SaveChanges();

            return _mapper.Map<RolePermissionResponse>(data);
        }
        public void AddAdminRoles()
        {
            try
            {
                var moduleList = _context.Modules.ToList();
                var actionList = _context.Actions.ToList();

                foreach (var module in moduleList)
                {
                    var taskList = _context.Tasks.Where(x => x.ModuleId == module.Id).ToList();
                    if (taskList.Count() > 0)
                    {
                        foreach (var task in taskList)
                        {
                            foreach (var action in actionList)
                            {
                                if ((_context.RolePermissions.Where(x => x.ModuleId == module.Id && x.TaskId == task.Id && x.ActionId == action.Id).Count() == 0))
                                {
                                    var data = new RolePermission()
                                    {
                                        RoleId = 1,
                                        ModuleId = module.Id,
                                        TaskId = task.Id,
                                        ActionId = action.Id,
                                        CreatedOn = DateTime.Now,
                                        IsDeleted = false,
                                        UpdateLogId = 1
                                    };
                                    _context.RolePermissions.Add(data);
                                }
                            }

                        }
                    }
                    else
                    {
                        foreach (var action in actionList)
                        {
                            if ((_context.RolePermissions.Where(x => x.ModuleId == module.Id && x.ActionId == action.Id).Count() == 0))
                            {
                                var data = new RolePermission()
                                {
                                    RoleId = 1,
                                    ModuleId = module.Id,
                                    ActionId = action.Id,
                                    CreatedOn = DateTime.Now,
                                    IsDeleted = false,
                                    UpdateLogId = 1
                                };
                                _context.RolePermissions.Add(data);
                            }
                        }
                    }

                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
        private RolePermission getData(int id)
        {
            var data = _context.RolePermissions.Find(id);
            if (data == null) throw new KeyNotFoundException("No data found");
            return data;
        }

        public void AddRemoveAll(IEnumerable<RoleAddRemoveRequest> model)
        {
            try
            {
                foreach (var item in model)
                {
                    var data = _context.RolePermissions.Where(x => x.RoleId == item.RoleId &&
                                                                    x.ModuleId == item.ModuleId &&
                                                                    x.TaskId == item.TaskId &&
                                                                    x.ActionId == item.ActionId).FirstOrDefault();
                    if (data == null)
                    {
                        if (item.Add)
                        {
                            var newData = new RolePermission()
                            {
                                RoleId = item.RoleId,
                                ModuleId = item.ModuleId,
                                TaskId = item.TaskId,
                                ActionId = item.ActionId,
                                UserLogId = item.UserLogId,
                                CreatedOn = DateTime.Now
                            };
                            _context.RolePermissions.Add(newData);
                            _context.SaveChanges();
                        }                        
                    }
                    else
                    {
                        if (!item.Add)
                        {
                            var updateData = _context.RolePermissions.Find(data.Id);
                            updateData.IsDeleted = true;
                            updateData.UpdatedOn = DateTime.UtcNow;
                            _context.RolePermissions.Update(updateData);
                            _context.SaveChanges();
                        }
                        else
                        {
                            if (data.IsDeleted)
                            {

                                var updateData = _context.RolePermissions.Find(data.Id);
                                updateData.IsDeleted = false;
                                updateData.UpdatedOn = DateTime.UtcNow;
                                _context.RolePermissions.Update(updateData);
                                _context.SaveChanges();
                            }
                        }
                    }

                    
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}
