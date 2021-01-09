using HKumar.RoleManagement.Models;
using HKumar.RoleManagement.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Interface.Collections;

namespace HKumar.RoleManagement.Interfaces.Services
{
    public interface IRoleManagementService
    {
        #region Roles
        Task<ICollection<RoleDto>> GetRolesAsync();
        Task<RoleDto> GetRoleByIdAsync(int roleId);
        Task<RoleDto> AddRoleAsync(RoleDto model);
        Task DeleteRoleAsync(RoleDto model);
        Task UpdateRoleAsync(RoleDto model);
        #endregion

        #region Role Permissions
        Task<ICollection<RoleOperationDto>> GetRoleOperationAsync();
        Task<ICollection<RoleOperationDto>> GetRoleOperationByRoleIdAsync(int roleId);
        Task<RoleOperationDto> AddRoleOperationAsync(RoleOperationDto model);
        Task DeleteRoleOperationAsync(RoleOperationDto model);
        Task UpdateRoleOperationAsync(RoleOperationDto model);
        #endregion

        #region Role Menu
        Task<ICollection<RoleMenuDto>> GetRoleMenuAsync();
        Task<ICollection<RoleMenuDto>> GetRoleMenuByRoleIdAsync(int roleId);
        Task<RoleMenuDto> AddRoleMenuAsync(RoleMenuDto model);
        Task DeleteRoleMenuAsync(RoleMenuDto model);
        Task UpdateRoleMenuAsync(RoleMenuDto model);
        #endregion

        #region Operation
        Task<ICollection<OperationDto>> GetOperationAsync();
        #endregion

        #region Menu
        Task<ICollection<MenuDto>> GetMenusAsync();
        #endregion
    }
}
