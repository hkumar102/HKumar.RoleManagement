using HKumar.RoleManagement.Attributes;
using HKumar.RoleManagement.Interfaces.Services;
using HKumar.RoleManagement.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWork.Interface.Providers;

namespace HKumar.RoleManagement.Controllers
{
    /// <summary>
    /// Controller used for assigning menu to the roles
    /// </summary>
    [Route("RoleManagement/[controller]")]
    [RoleAutorize]
    public class RoleMenuController : ControllerBase
    {
        #region Private properties
        private readonly IRoleManagementService _roleManagementService;
        private readonly IUserInformationProvider _userInformationProvider;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="securityService"></param>
        /// <param name="userInformationProvider"></param>
        public RoleMenuController(
            IRoleManagementService securityService,
            IUserInformationProvider userInformationProvider)
        {
            _roleManagementService = securityService;
            _userInformationProvider = userInformationProvider;
        }

        /// <summary>
        /// Return the roleMenus by roleid
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet("Role/{roleId}")]
        public async Task<ICollection<RoleMenuDto>> GetRoleMenuByRoleId(int roleId)
        {
            return await _roleManagementService.GetRoleMenuByRoleIdAsync(roleId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PostMenu([FromBody] RoleMenuDto model)
        {
            if (model == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _roleManagementService.AddRoleMenuAsync(model);
            return this.Ok(result);

        }

        /// <summary>
        /// Delete role by id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> DeleteRoleMenu([FromBody] RoleMenuDto model)
        {
            await _roleManagementService.DeleteRoleMenuAsync(model);
            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch]
        public async Task<ActionResult> PatchRoleMenu([FromBody] RoleMenuDto model)
        {
            if (model == null) return BadRequest();

            await _roleManagementService.UpdateRoleMenuAsync(model);

            return NoContent();

        }

    }
}
