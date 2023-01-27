using AutoMapper;
using MISAPI.DataModel.Models.Accounts;
using MISAPI.DataModel.Models.Roles;
using MISAPI.DataModel.Models.Settings;
using MISAPI.DataModel.ViewModels.Accounts;
using MISAPI.DataModel.ViewModels.RolePermissions;
using MISAPI.DataModel.ViewModels.Settings;

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

            CreateMap<ConsecrationRequirementRequest, ConsecrationRequirement>();
            CreateMap<ConsecrationRequirement, ConsecrationRequirementResponse>();

            CreateMap<ConsecrationArticleRequest, ConsecrationArticle>();
            CreateMap<ConsecrationArticle, ConsecrationArticleResponse>();

            CreateMap<RitualRequest, Ritual>();
            CreateMap<Ritual, RitualResponse>();

            CreateMap<CurrencyRequest, Currency>();
            CreateMap<Currency, CurrencyResponse>();

            CreateMap<ArticleRequest, Article>();
            CreateMap<Article, ArticleResponse>();

            CreateMap<RoleRequest, Role>();
            CreateMap<Role, RoleResponse>();

            CreateMap<RolePermissionRequest, RolePermission>();
            CreateMap<RolePermission, RolePermissionResponse>();

            CreateMap<Menu, MenuResponse>();
            CreateMap<SubMenu, SubMenuResponse>();
            CreateMap<Operation, OperationResponse>();
            CreateMap<MenuOperation, MenuOperationResponse>(); 

            CreateMap<RoleAddRemoveRequest, RolePermission>(); 

        }
    }
}