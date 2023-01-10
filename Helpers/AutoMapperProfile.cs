using AutoMapper;
using MIS_API.Entities;
using MIS_API.Entities.Roles;
using MIS_API.Models.Accounts;
using MIS_API.Models.RolePermissions;
using MIS_API.Models.Roles;

namespace MIS_API.Helpers
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

                        // ignore null role
                        if (x.DestinationMember.Name == "RoleEnum" && src.RoleEnum == null) return false;

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

        }
    }
}