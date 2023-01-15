using AutoMapper;
using MISAPI.DataModel.Models.Accounts;
using MISAPI.DataModel.Models.Roles;
using MISAPI.DataModel.ViewModels.Accounts;
using MISAPI.DataModel.ViewModels.RolePermissions;

namespace MISAPI.DAL.Helpers
{
    public class AutoMapperProfile : Profile
    {
        // mappings between model and entity objects
        public AutoMapperProfile()
        {
            CreateMap<Account, AccountResponse>();

            CreateMap<Account, AuthenticateResponse>();

            CreateMap<RegisterRequest, Account>();

            CreateMap<CreateRequest, Account>();

            CreateMap<UpdateRequest, Account>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        return true;
                    }
                ));
           
            CreateMap<RoleRequest, Role>();
            CreateMap<Role, RoleResponse>();

            CreateMap<RolePermissionRequest, RolePermission>();
            CreateMap<RolePermission, RolePermissionResponse>();

            CreateMap<Module, ModuleResponse>();
            CreateMap<Task, TaskResponse>();
            CreateMap<Action, ActionResponse>();

            CreateMap<RoleAddRemoveRequest, RolePermission>();            

        }
    }
}