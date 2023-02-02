using AutoMapper;
using Microsoft.Extensions.Configuration;
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
    public class RolePermissionService : IRolePermissionInterface
    {
        private readonly DataContext _context;
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IConfiguration _configuration;

        public RolePermissionService(
            DataContext context,
            IMapper mapper,
            IOptions<AppSettings> appSettings,
            IConfiguration  configuration)
        {
            _context = context;
            _dbContext = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _configuration = configuration;
            //_configuration = _configuration.GetConnectionString("dbConnection");
        }

        public IEnumerable<MenuResponse> GetMenus()
        {
            var data = _context.Menus.Where(x=>x.Id != "AdminTasks").OrderBy(x => x.Id);
            return _mapper.Map<IList<MenuResponse>>(data);
        }

        public IEnumerable<SubMenuResponse> GetSubMenus()
        {
            var data = _context.SubMenus.OrderBy(x => x.Id);
            return _mapper.Map<IList<SubMenuResponse>>(data);
        }

        public IEnumerable<OperationResponse> GetOperations(string id)
        {
            var moduleOperationIds = _context.MenuOperations.Where(x => x.MenuId == id).Select(s=>s.OperationId).ToList();
            var data = _context.Operations.Where(x=> moduleOperationIds.Contains(x.Id)).OrderBy(x => x.Id);
            return _mapper.Map<IList<OperationResponse>>(data);
        }
        public RolePermissionResponse Create(RolePermissionRequest model)
        {
            try
            {
                var data = _mapper.Map<RolePermission>(model);
                var role = _context.RolePermissions.Where(x => x.RoleId == data.RoleId &&
                                                    x.MenuId == data.MenuId &&
                                                    x.SubMenuId == data.SubMenuId &&
                                                    x.OperationId == data.OperationId).FirstOrDefault();

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
        public bool UpdateAdminRoles()
        {
            try
            {
                if (!PrepareRoles())
                {
                    return false;
                }

                var moduleList = _context.Menus.ToList();

                foreach (var module in moduleList)
                {
                    var moduleOperations = _context.MenuOperations.Where(x => x.MenuId == module.Id).Select(s=>s.OperationId).ToList();
                    var operationList = _context.Operations.Where(x=> moduleOperations.Contains(x.Id)).ToList();
                    var subMenuList = _context.SubMenus.Where(x => x.MenuId == module.Id).ToList();
                    if (subMenuList.Count() > 0)
                    {
                        foreach (var subMenu in subMenuList)
                        {
                            foreach (var action in operationList)
                            {
                                if ((_context.RolePermissions.Where(x => x.MenuId == module.Id && x.SubMenuId == subMenu.Id && x.OperationId == action.Id).Count() == 0))
                                {
                                    var data = new RolePermission()
                                    {
                                        RoleId = 1,
                                        MenuId = module.Id,
                                        SubMenuId = subMenu.Id,
                                        OperationId = action.Id,
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
                        foreach (var action in operationList)
                        {
                            if ((_context.RolePermissions.Where(x => x.MenuId == module.Id && x.OperationId == action.Id).Count() == 0))
                            {
                                var data = new RolePermission()
                                {
                                    RoleId = 1,
                                    MenuId = module.Id,
                                    OperationId = action.Id,
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
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }
        
        public bool PrepareRoles()
        {
            try
            {
                DataContext dataContext = new DataContext(_configuration);
                var moduleList = StaticData.GetMenuList();
                List<Menu> newMenuList = new List<Menu>();
                foreach (var item in moduleList)
                {
                    if (dataContext.Menus.Where(x => x.Id == item.Id && x.Name == item.Name).Count() == 0)
                    {
                        newMenuList.Add(item);
                    }

                }
                dataContext.Menus.AddRange(newMenuList);
                dataContext.SaveChanges();

                dataContext = new DataContext(_configuration);
                var operationList = StaticData.GetOperationList();
                List<Operation> newOperationList = new List<Operation>();
                foreach (var item in operationList)
                {
                    if (dataContext.Operations.Where(x => x.Id == item.Id && x.Name == item.Name).Count() == 0)
                    {
                        newOperationList.Add(item);
                    }

                }
                dataContext.Operations.AddRange(newOperationList);
                dataContext.SaveChanges();

                dataContext = new DataContext(_configuration);
                var moduleOperationList = StaticData.GetMenuOpertionList();
                List<MenuOperation> newMenuOperationList = new List<MenuOperation>();
                foreach (var item in moduleOperationList)
                {
                    if (dataContext.MenuOperations.Where(x => x.MenuId == item.MenuId && x.OperationId == item.OperationId).Count() == 0)
                    {
                        newMenuOperationList.Add(item);
                    }

                }
                dataContext.MenuOperations.AddRange(newMenuOperationList);
                dataContext.SaveChanges();

                dataContext = new DataContext(_configuration);
                var subMenuList = StaticData.GetSubMenuList();
                List<SubMenu> newSubMenuList = new List<SubMenu>();
                foreach (var item in subMenuList)
                {
                    //_dbContext.Entry(item).State = EntityState.Detached;
                    if (dataContext.SubMenus.Where(x => x.Id == item.Id && x.MenuId == item.MenuId && x.Name == item.Name).Count() == 0)
                    {
                        newSubMenuList.Add(item);
                    }

                }                
                dataContext.SubMenus.AddRange(newSubMenuList);
                dataContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
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
                                                                    x.MenuId == item.MenuId &&
                                                                    x.SubMenuId == item.SubMenuId &&
                                                                    x.OperationId == item.OperationId).FirstOrDefault();
                    if (data == null)
                    {
                        if (item.Add)
                        {
                            var newData = new RolePermission()
                            {
                                RoleId = item.RoleId,
                                MenuId = item.MenuId,
                                SubMenuId = item.SubMenuId,
                                OperationId = item.OperationId,
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

        public IEnumerable<MenuOperationResponse> GetMenuOperations()
        {
            var data = _context.MenuOperations;
            return _mapper.Map<IList<MenuOperationResponse>>(data);
        }
    }
}
