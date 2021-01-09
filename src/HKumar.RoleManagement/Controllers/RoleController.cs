using HKumar.RoleManagement.Interfaces.Providers;
using HKumar.RoleManagement.Interfaces.Services;
using HKumar.RoleManagement.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HKumar.RoleManagement.Controllers
{
    /// <summary>
    /// Account controller for handling security related things
    /// </summary>
    [Route("RoleManagement/[controller]")]
    //[RoleAutorize]
    public class RoleController : ControllerBase
    {
        #region Private properties
        private readonly IRoleManagementService _roleManagementService;
        private readonly IRoleManagementUserInformationProvider _userInformationProvider;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="securityService"></param>
        /// <param name="userInformationProvider"></param>
        public RoleController(
            IRoleManagementService securityService,
            IRoleManagementUserInformationProvider userInformationProvider)
        {
            _roleManagementService = securityService;
            _userInformationProvider = userInformationProvider;

        }

        /// <summary>
        /// Return the roles for the tenants
        /// </summary>
        /// <returns>ICollection&lt;RoleDto&gt;</returns>
        [HttpGet]
        public async Task<ICollection<RoleDto>> GetRoles()
        {
            return await _roleManagementService.GetRolesAsync();
        }

        /// <summary>
        /// Return the role by id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet("{roleId}")]
        public async Task<RoleDto> GetRoleById(int roleId)
        {
            return await _roleManagementService.GetRoleByIdAsync(roleId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PostRole([FromBody] RoleDto model)
        {
            if (model == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return this.Ok(await _roleManagementService.AddRoleAsync(model));

        }

        /// <summary>
        /// Delete role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> DeleteRole(RoleDto role)
        {
            await _roleManagementService.DeleteRoleAsync(role);
            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch]
        public async Task<ActionResult> PatchRole(int id, [FromBody] RoleDto model)
        {
            if (model == null) return BadRequest();

            await _roleManagementService.UpdateRoleAsync(model);

            return NoContent();

        }
    }

}