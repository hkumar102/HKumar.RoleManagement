using HKumar.RoleManagement.Entities.Db.Config;
using HKumar.RoleManagement.Entities.Db.Security;
using HKumar.RoleManagement.Models.Dto;

namespace HKumar.RoleManagement.Automapper
{
    /// <summary>
    /// 
    /// </summary>
    public class RoleManagementAutoMapperProfile : AutoMapper.Profile
    {
        public RoleManagementAutoMapperProfile()
        {
            #region DTO Mappings
            #region Config
            CreateMap<Operation, OperationDto>().ReverseMap();
            CreateMap<Menu, MenuDto>().ReverseMap();
            CreateMap<MenuType, MenuTypeDto>().ReverseMap();
            #endregion


            #region Security
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<RoleOperation, RoleOperationDto>().ReverseMap();
            CreateMap<RoleMenu, RoleMenuDto>().ReverseMap();
            #endregion
            #endregion
        }
    }
}
